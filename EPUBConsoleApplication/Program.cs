using EPUB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPUBConsoleApplication {
    class Program {
        static void Main(string[] args) {

            var fileName = @"C:\EpubTestsuite-20140729\ConcurrencyinCCookbook.epub";
            //var fileName = @"C:\EpubTestsuite-20140729\RavenDB2xBeginnersGuide.epub";

            using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read)) {

                var epubfile = Reader.Read(stream);
                foreach(var package in epubfile.Packages) {
                    Console.WriteLine(string.Format("Package Name : {0}; Mime Type : {1}", package.Name, package.MimeType));
                }


                Console.ReadKey();

            }
        }
    }
}
