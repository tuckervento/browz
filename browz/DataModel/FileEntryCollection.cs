using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace browz.DataModel
{
    [Serializable()]
    public class FileEntryCollection : ISerializable
    {
        private string _name;
        private List<FileEntry> _collection;

        #region Constructors

        /// <summary>
        /// Creates a new FileEntryCollection with the given name.
        /// </summary>
        /// <param name="p_name">The name of the new collection</param>
        public FileEntryCollection(string p_name)
        {
            _name = p_name;
            _collection = new List<FileEntry>();
        }

        /// <summary>
        /// Creates a new FileEntryCollection with the given name and entries.
        /// </summary>
        /// <param name="p_name">The name of the new collection</param>
        /// <param name="p_entries">The entries to store in the collection</param>
        public FileEntryCollection(string p_name, IEnumerable<FileEntry> p_entries) : this(p_name)
        {
            _collection.AddRange(p_entries.Select(e => new FileEntry(e.FullPath)));
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public FileEntryCollection(SerializationInfo p_info, StreamingContext p_context)
        {
            _name = (string)p_info.GetValue(Serialization.FileEntryCollectionName, typeof(string));
            _collection = (List<FileEntry>)p_info.GetValue(Serialization.FileEntryCollectionEntries, typeof(List<FileEntry>));
        }

        #endregion

        #region Properties

        /// <summary>
        /// The name of the collection
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// A copy of the entries in the collection
        /// </summary>
        public IReadOnlyList<FileEntry> Entries
        {
            get { return _collection.ToList(); }
        }

        /// <summary>
        /// A list of all the tags in the collection
        /// </summary>
        public IEnumerable<string> Tags
        {
            get
            {
                IEnumerable<string> tags = new string[]{};

                foreach (var entry in _collection)
                {
                    tags = tags.Union(entry.Tags);
                }

                return tags.Distinct();
            }
        }

        #endregion

        #region Collection modification

        /// <summary>
        /// Clears and replaces the FileEntry objects in this collection.
        /// </summary>
        /// <param name="p_newCollection">The new FileEntry objects</param>
        public void Clear(IEnumerable<FileEntry> p_newCollection)
        {
            var names = p_newCollection.Select<FileEntry, string>(e => e.FullPath);
            _collection.RemoveAll(p => !names.Contains(p.FullPath));
        }

        /// <summary>
        /// Adds the specified files to the collection. (duplicates are ignored)
        /// </summary>
        /// <param name="p_entries">The entries to add</param>
        public void AddEntries(IEnumerable<string> p_entries)
        {
            if (p_entries != null && p_entries.Any())
                _collection.AddRange(p_entries.Select<string, FileEntry>(e => new FileEntry(e)));
        }

        /// <summary>
        /// Adds the specified file to the collection. (duplicates are ignored)
        /// </summary>
        /// <param name="p_entry">The entry to add</param>
        public void AddEntry(string p_entry)
        {
            if (!String.IsNullOrWhiteSpace(p_entry))
                _collection.Add((FileEntry)p_entry);
        }

        /// <summary>
        /// Removes
        /// </summary>
        /// <param name="enumerable"></param>
        public void RemoveEntries(System.Windows.Forms.ListBox.SelectedObjectCollection selectedObjectCollection)
        {
            _collection.RemoveAll(e => selectedObjectCollection.Contains(e));
        }

        /// <summary>
        /// Tags the specified entries.
        /// </summary>
        /// <param name="p_tag">The name of the tag</param>
        /// <param name="p_entries">The entries to tag</param>
        public void TagEntriesAs(string p_tag, System.Windows.Forms.ListBox.SelectedObjectCollection p_entries)
        {
            foreach (var entry in p_entries)
            {
                this._collection.Find(e => e == (FileEntry)entry).AddTag(p_tag);
            }
        }

        public void UntagEntriesAs(string p_tag, System.Windows.Forms.ListBox.SelectedObjectCollection p_entries)
        {
            foreach (var entry in p_entries)
            {
                this._collection.Find(e => e == (FileEntry)entry).RemoveTag(p_tag);
            }
        }

        #endregion

        /// <summary>
        /// Returns a copy of the entries with the specified tag, or null if it doesn't exist
        /// </summary>
        /// <param name="p_tag">The tag to find</param>
        public IEnumerable<FileEntry> GetEntriesTaggedAs(string p_tag)
        {
            foreach (var fe in _collection.Where(e => e.HasTag(p_tag))) { yield return fe; }
        }

        #region ISerializable

        public void GetObjectData(SerializationInfo p_info, StreamingContext p_context)
        {
            p_info.AddValue(Serialization.FileEntryCollectionName, _name, typeof(string));
            p_info.AddValue(Serialization.FileEntryCollectionEntries, _collection, typeof(List<FileEntry>));
        }

        #endregion
    }
}
