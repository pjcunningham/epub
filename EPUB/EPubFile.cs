using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EPUB {

    public class EPubFile {

        public EPubFile() {
            OPF = "OEBPS/content.opf";
        }

        public IReadOnlyList<Package> Packages { get; private set; }
        public Metadata Metadata {get; private set; }

        public string OPF { get; set; }

        internal void SetMetadata(Metadata metadata) {
            this.Metadata = metadata;
        }

        internal void SetPackages(IList<Package> packages) {
            this.Packages = new ReadOnlyCollection<Package>(packages);
        }
        
    }
}
