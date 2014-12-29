using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace browz.DataModel
{
    [Serializable()]
    public class OrganizedCollection : ISerializable
    {
        private string _name;
        private FileEntryCollection _collection;

        #region Constructors

        /// <summary>
        /// Creates a new OrderedCollection with the specified name.
        /// </summary>
        /// <param name="p_name">The name of the new OrderedCollection</param>
        public OrganizedCollection(string p_name)
        {
            _name = p_name;
            _collection = new FileEntryCollection();
        }

        /// <summary>
        /// Creates a new OrderedCollection with the specified name.
        /// </summary>
        /// <param name="p_name">The name of the new OrderedCollection</param>
        /// <param name="p_collection">The initial entries for the OrderedCollection</param>
        public OrganizedCollection(string p_name, FileEntryCollection p_collection)
        {
            _name = p_name;
            _collection = p_collection;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public OrganizedCollection(SerializationInfo p_info, StreamingContext p_context)
        {
            _name = (string)p_info.GetValue(Serialization.OrderedCollectionName, typeof(string));
            _collection = (FileEntryCollection)p_info.GetValue(Serialization.OrderedCollectionDictionary, typeof(FileEntryCollection));
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
        /// A copy of the entire collection
        /// </summary>
        public FileEntryCollection Collection
        {
            get { return _collection; }
        }

        /// <summary>
        /// A list of all the group names in the collection
        /// </summary>
        public IEnumerable<string> GroupNames
        {
            get {
                var ret = new List<string>();
                foreach (var fec in _collection.Entries) { if (!ret.Contains(fec.Tag)) { ret.Add(fec.Tag); } }
                return ret;
            }
        }

        #endregion

        /// <summary>
        /// Returns a copy of the entries in the specified group, or null if it doesn't exist
        /// </summary>
        /// <param name="p_name">The name of the group to return</param>
        public IEnumerable<FileEntry> GetEntriesTaggedAs(string p_name)
        {
            foreach (var fe in _collection.Entries.Where(e => e.Tag == p_name)) { yield return fe; }
        }

        #region Collection modification

        /// <summary>
        /// Tags the specified entries of the collection.
        /// </summary>
        /// <param name="p_tag">The name of the tag</param>
        /// <param name="p_entries">The entries to tag</param>
        public void TagEntriesAs(string p_tag, IEnumerable<string> p_entries)
        {
            foreach (var entry in p_entries)
            {
                _collection.TagEntryAs(entry, p_tag);
            }
        }

        #endregion

        #region ISerializable

        public void GetObjectData(SerializationInfo p_info, StreamingContext p_context)
        {
            p_info.AddValue(Serialization.OrderedCollectionName, _name, typeof(string));
            p_info.AddValue(Serialization.OrderedCollectionDictionary, _collection, typeof(IEnumerable<FileEntryCollection>));
        }

        #endregion
    }
}
