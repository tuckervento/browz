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
        private IEnumerable<FileEntry> _collection;

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
        public FileEntryCollection(string p_name, IEnumerable<FileEntry> p_entries)
        {
            _name = p_name;
            _collection = p_entries;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public FileEntryCollection(SerializationInfo p_info, StreamingContext p_context)
        {
            _name = (string)p_info.GetValue(Serialization.FileEntryCollectionName, typeof(string));
            _collection = (IEnumerable<FileEntry>)p_info.GetValue(Serialization.FileEntryCollectionEntries, typeof(IEnumerable<FileEntry>));
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
                return _collection.Select(c => c.Tag).Distinct();
            }
        }

        #endregion

        #region Collection modification

        /// <summary>
        /// Adds the specified files to the collection. (duplicates are ignored)
        /// </summary>
        /// <param name="p_entries">The FileEntry objects to add</param>
        public void AddEntries(IEnumerable<FileEntry> p_entries)
        {
            if (p_entries != null && p_entries.Any())
                _collection = _collection.Union(p_entries);
        }

        /// <summary>
        /// Adds the specified files to the collection. (duplicates are ignored)
        /// </summary>
        /// <param name="p_entries">The entries to add</param>
        public void AddEntries(IEnumerable<string> p_entries)
        {
            if (p_entries != null && p_entries.Any())
                _collection = _collection.Union(p_entries.Cast<FileEntry>());
        }

        /// <summary>
        /// Adds the specified file to the collection. (duplicates are ignored)
        /// </summary>
        /// <param name="p_entry">The FileEntry object to add</param>
        public void AddEntry(FileEntry p_entry)
        {
            if (p_entry != null)
                _collection = _collection.Union(new FileEntry[]{p_entry});
        }

        /// <summary>
        /// Adds the specified file to the collection. (duplicates are ignored)
        /// </summary>
        /// <param name="p_entry">The entry to add</param>
        public void AddEntry(string p_entry)
        {
            if (!String.IsNullOrWhiteSpace(p_entry))
                _collection = _collection.Union(new FileEntry[] { (FileEntry)p_entry });
        }

        /// <summary>
        /// Removes the specified file from the collection, if it exists.
        /// </summary>
        /// <param name="p_entry">The entry to remove</param>
        public void RemoveEntry(FileEntry p_entry)
        {
            _collection = _collection.Where(e => !e.Equals(p_entry));
        }

        /// <summary>
        /// Removes the specified file from the collection, if it exists.
        /// </summary>
        /// <param name="p_entry">The entry to remove</param>
        public void RemoveEntry(string p_entry)
        {
            _collection = _collection.Where(e => !e.Equals((FileEntry)p_entry));
        }

        /// <summary>
        /// Sets the tag on the specified entry.
        /// </summary>
        /// <param name="p_entry">The entry to tag</param>
        /// <param name="p_tag">The tag to use</param>
        /// <returns>Returns false if the entry doesn't exist</returns>
        public bool TagEntryAs(string p_entry, string p_tag)
        {
            if (!_collection.Any(e => e.Equals(p_entry))) { return false; }
            _collection.Single(e => e.Equals(p_entry)).Tag = p_tag;
            return true;
        }

        /// <summary>
        /// Tags the specified entries.
        /// </summary>
        /// <param name="p_tag">The name of the tag</param>
        /// <param name="p_entries">The entries to tag</param>
        public void TagEntriesAs(string p_tag, IEnumerable<string> p_entries)
        {
            foreach (var entry in p_entries)
            {
                TagEntryAs(p_tag, entry);
            }
        }

        #endregion

        /// <summary>
        /// Returns a copy of the entries with the specified tag, or null if it doesn't exist
        /// </summary>
        /// <param name="p_tag">The tag to find</param>
        public IEnumerable<FileEntry> GetEntriesTaggedAs(string p_tag)
        {
            foreach (var fe in _collection.Where(e => e.Tag == p_tag)) { yield return fe; }
        }

        #region ISerializable

        public void GetObjectData(SerializationInfo p_info, StreamingContext p_context)
        {
            p_info.AddValue(Serialization.FileEntryCollectionName, _name, typeof(string));
            p_info.AddValue(Serialization.FileEntryCollectionEntries, _collection, typeof(IEnumerable<FileEntry>));
        }

        #endregion
    }
}
