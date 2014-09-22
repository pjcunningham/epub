using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPUB {
    public class Package {

        public Package(string name, byte[] data) {
            this.Name = name;
            this.MimeType = MimeMapping.GetMimeMapping(name);
            this.Data = data;
        }

        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }

    }
}
