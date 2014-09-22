using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EPUB {
    public class Metadata {

        public IReadOnlyList<string> Publishers { get; private set; }
        public IReadOnlyList<string> Rights { get; private set; }
        public IReadOnlyList<string> Subjects { get; private set; }
        public IReadOnlyList<string> Titles { get; private set; }
        public IReadOnlyList<string> Types { get; private set; }

        internal void SetPublishers(IList<string> list) {
            this.Publishers = new ReadOnlyCollection<string>(list);
        }

        internal void SetRights(IList<string> list) {
            this.Rights = new ReadOnlyCollection<string>(list);
        }

        internal void SetSubjects(IList<string> list) {
            this.Subjects = new ReadOnlyCollection<string>(list);
        }

        internal void SetTitles(IList<string> list) {
            this.Titles = new ReadOnlyCollection<string>(list);
        }

        internal void SetTypes(IList<string> list) {
            this.Types = new ReadOnlyCollection<string>(list);
        }

    }
}
