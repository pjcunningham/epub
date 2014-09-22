using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace EPUB {

    public class Reader {

        public static EPubFile Read(string filename) {
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read)) {
                return Reader.Read(stream);
            }
        }

        public static EPubFile Read(Stream stream) {
            var result = new EPubFile();
            var packages = new List<Package>();
            using (ZipArchive archive = new ZipArchive(stream)) {
                foreach (ZipArchiveEntry entry in archive.Entries) {
                    Debug.Print(entry.FullName);
                    using (var ms = new MemoryStream()) {
                        entry.Open().CopyTo(ms);
                        var package = new Package(entry.FullName, ms.ToArray());
                        packages.Add(package);
                        if (entry.FullName == "META-INF/container.xml") {
                            string opf;
                            if (TryGetOPF(package.Data, out opf)) {
                                result.OPF = opf;
                            }
                        }
                    }
                }
            }

            result.SetPackages(packages);

            // Process OPF Package
            var opfPackage = result.Packages.FirstOrDefault(q => q.Name == result.OPF);
            if (opfPackage != null) {

                Metadata metadata;
                if (TryParseMetadata(opfPackage.Data, out metadata)) {
                    result.SetMetadata(metadata);
                }

            }
            return result;
        }


        private static bool TryGetOPF(byte[] data, out string opf) {

            opf = null;
            try {
                using (XmlTextReader reader = new XmlTextReader(new StringReader(UTF8Encoding.UTF8.GetString(data)))) {
                    XElement xElement = XElement.Load(reader);
                    XNamespace ns = (xElement.Attribute("xmlns") != null) ? xElement.Attribute("xmlns").Value : XNamespace.None;
                    var rootFile = xElement.Descendants(ns + "rootfile").FirstOrDefault(q => q.Attribute("media-type") != null && q.Attribute("media-type").Value.Equals("application/oebps-package+xml", System.StringComparison.InvariantCultureIgnoreCase)).Attribute("full-path");
                    if (rootFile != null) {
                        opf = rootFile.Value;
                        return true;
                    } else {
                        return false;
                    }
                }
            } catch {
                return false;
            }

        }

        private static bool TryParseMetadata(byte[] data, out Metadata metadata) {
            metadata = null;
            return false;
        }

    }

}
