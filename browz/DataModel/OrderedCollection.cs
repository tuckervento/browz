using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace browz.DataModel
{
    [Serializable()]
    public class OrderedCollection : ISerializable
    {
        private Dictionary<string, FileEntryCollection> _collection;
        private string _name;

        #region Constructors

        /// <summary>
        /// Creates a new OrderedCollection with the specified name.
        /// </summary>
        /// <param name="p_name">The name of the new OrderedCollection</param>
        public OrderedCollection(string p_name)
        {
            _name = p_name;
            _collection = new Dictionary<string, FileEntryCollection>();
        }

        /// <summary>
        /// Creates a new OrderedCollection with the specified name.
        /// </summary>
        /// <param name="p_name">The name of the new OrderedCollection</param>
        /// <param name="p_collection">The initial entries for the OrderedCollection</param>
        public OrderedCollection(string p_name, Dictionary<string, FileEntryCollection> p_collection)
        {
            _name = p_name;
            _collection = p_collection;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public OrderedCollection(SerializationInfo p_info, StreamingContext p_context)
        {
            _name = (string)p_info.GetValue(Serialization.OrderedCollectionName, typeof(string));
            _collection = (Dictionary<string, FileEntryCollection>)p_info.GetValue(Serialization.OrderedCollectionDictionary, typeof(Dictionary<string, FileEntryCollection>));
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
        public IReadOnlyDictionary<string, FileEntryCollection> Collection
        {
            get { return _collection; }
        }

        /// <summary>
        /// A list of all the group names in the collection
        /// </summary>
        public IReadOnlyList<string> GroupNames
        {
            get { return _collection.Keys.ToList(); }
        }

        #endregion

        /// <summary>
        /// Returns a copy of the entries in the specified group, or null if it doesn't exist
        /// </summary>
        /// <param name="p_name">The name of the group to return</param>
        public IReadOnlyList<FileEntry> GetGroup(string p_name)
        {
            return _collection.ContainsKey(p_name) ?_collection[p_name].Entries : null;
        }

        #region Collection modification

        /// <summary>
        /// Adds the specified group to the collection.  If a group with that name already exists, the two will be unioned.
        /// </summary>
        /// <param name="p_name">The name of the group to add</param>
        /// <param name="p_group">The group to add</param>
        public void AddGroup(string p_name, FileEntryCollection p_group)
        {
            if (_collection.ContainsKey(p_name))
                _collection[p_name].Union(p_group);
            else
                _collection[p_name] = p_group;
        }

        /// <summary>
        /// Adds the specified entries to the collection.  If a group with that name already exists, the two will be unioned.
        /// </summary>
        /// <param name="p_name">The name of the group to add</param>
        /// <param name="p_entries">The entries to add</param>
        public void AddEntriesToGroup(string p_name, IEnumerable<FileEntry> p_entries)
        {
            if (_collection.ContainsKey(p_name))
                _collection[p_name].AddEntries(p_entries);
            else
                _collection[p_name] = new FileEntryCollection(p_name, p_entries);
        }

        /// <summary>
        /// Adds the specified entries to the collection.  If a group with that name already exists, the two will be unioned.
        /// </summary>
        /// <param name="p_name">The name of the group to add</param>
        /// <param name="p_entries">The entries to add</param>
        public void AddEntriesToGroup(string p_name, IEnumerable<string> p_entries)
        {
            if (_collection.ContainsKey(p_name))
                _collection[p_name].AddEntries(p_entries);
            else
                _collection[p_name] = new FileEntryCollection(p_name, p_entries.Cast<FileEntry>());
        }

        #endregion

        #region ISerializable

        public void GetObjectData(SerializationInfo p_info, StreamingContext p_context)
        {
            p_info.AddValue(Serialization.OrderedCollectionName, _name, typeof(string));
            p_info.AddValue(Serialization.OrderedCollectionDictionary, _collection, typeof(Dictionary<string, FileEntryCollection>));
        }

        #endregion
    }
}
