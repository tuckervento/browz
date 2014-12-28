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
        private IEnumerable<FileEntryCollection> _collection;

        #region Constructors

        /// <summary>
        /// Creates a new OrderedCollection with the specified name.
        /// </summary>
        /// <param name="p_name">The name of the new OrderedCollection</param>
        public OrganizedCollection(string p_name)
        {
            _name = p_name;
            _collection = new List<FileEntryCollection>();
        }

        /// <summary>
        /// Creates a new OrderedCollection with the specified name.
        /// </summary>
        /// <param name="p_name">The name of the new OrderedCollection</param>
        /// <param name="p_collection">The initial entries for the OrderedCollection</param>
        public OrganizedCollection(string p_name, IEnumerable<FileEntryCollection> p_collection)
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
            _collection = (IEnumerable<FileEntryCollection>)p_info.GetValue(Serialization.OrderedCollectionDictionary, typeof(IEnumerable<FileEntryCollection>));
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
        public IEnumerable<FileEntryCollection> Collection
        {
            get { return _collection; }
        }

        /// <summary>
        /// A list of all the group names in the collection
        /// </summary>
        public IEnumerable<string> GroupNames
        {
            get { foreach (var fec in _collection) { yield return fec.Name; } }
        }

        #endregion

        /// <summary>
        /// Returns a copy of the entries in the specified group, or null if it doesn't exist
        /// </summary>
        /// <param name="p_name">The name of the group to return</param>
        public IReadOnlyList<FileEntry> GetGroup(string p_name)
        {
            return _collection.Any(e => e.Name == p_name) ?_collection.Single(e=> e.Name == p_name).Entries : null;
        }

        #region Collection modification

        /// <summary>
        /// Adds the specified group to the collection.  If a group with that name already exists, the two will be unioned.
        /// </summary>
        /// <param name="p_group">The group to add</param>
        public void AddGroup(FileEntryCollection p_group)
        {
            if (_collection.Any(e => e.Name == p_group.Name))
                _collection.Single(e => e.Name == p_group.Name).Union(p_group);
            else
                _collection.Union(new FileEntryCollection[] { p_group });
        }

        /// <summary>
        /// Adds the specified entries to the collection.  If a group with that name already exists, the two will be unioned.
        /// </summary>
        /// <param name="p_name">The name of the group to add</param>
        /// <param name="p_entries">The entries to add</param>
        public void AddEntriesToGroup(string p_name, IEnumerable<FileEntry> p_entries)
        {
            if (_collection.Any(e => e.Name == p_name))
                _collection.Single(e => e.Name == p_name).AddEntries(p_entries);
            else
                _collection.Union(new FileEntryCollection[] { new FileEntryCollection(p_name, p_entries) });
        }

        /// <summary>
        /// Adds the specified entries to the collection.  If a group with that name already exists, the two will be unioned.
        /// </summary>
        /// <param name="p_name">The name of the group to add</param>
        /// <param name="p_entries">The entries to add</param>
        public void AddEntriesToGroup(string p_name, IEnumerable<string> p_entries)
        {
            this.AddEntriesToGroup(p_name, p_entries.Cast<FileEntry>());
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
