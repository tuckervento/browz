using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace browz.DataModel
{
    [Serializable()]
    public class CollectionsDatabase : ISerializable
    {
        private readonly string _name;
        private FileEntryCollection _master;
        private IEnumerable<OrganizedCollection> _collections;
        private DirectoryList _directories;

        #region Constructors

        /// <summary>
        /// Creates a new CollectionsDatabase object with the given name.
        /// </summary>
        /// <param name="p_name">The name of the new CollectionsDatabase</param>
        public CollectionsDatabase(string p_name)
        {
            _name = p_name;
            _master = new FileEntryCollection("Master");
            _collections = new List<OrganizedCollection>();
            _directories = new DirectoryList();
        }

        /// <summary>
        /// Creates a new CollectionsDatabase object with the given name and initializes it with the given collection.
        /// </summary>
        /// <param name="p_name">The name of the new CollectionsDatabase</param>
        /// <param name="p_master">The master list for the database</param>
        /// <param name="p_directories">The directories of the master list</param>
        public CollectionsDatabase(string p_name, FileEntryCollection p_master, DirectoryList p_directories) 
        {
            _name = p_name;
            _master = p_master;
            _collections = new List<OrganizedCollection>();
            _directories = p_directories;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The directories searched through for this database.
        /// </summary>
        public DirectoryList DirectoryList
        {
            get { return _directories; }
        }

        /// <summary>
        /// The master list of files used for the various collections.
        /// </summary>
        public IReadOnlyList<FileEntry> FileMasterList
        {
            get { return _master.Entries; }
        }

        #endregion

        #region Database modification

        /// <summary>
        /// Search through directories as specified by the DirectoryList of this database, and store all of the found files in the master list.
        /// </summary>
        public void GenerateMasterList()
        {
            _master = new FileEntryCollection("Master");
            foreach (var kvp in _directories.DirectoryDictionary) {
                var files = Directory.EnumerateFiles(kvp.Key, "*",
                    (kvp.Value ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
                _master.AddEntries(files);
            }
        }

        /// <summary>
        /// Add a new OrganizedCollection object to the CollectionsDatabase
        /// </summary>
        /// <param name="p_name">The name of the new OrganizedCollection</param>
        /// <returns>True if successful, false if a collection with that name exists</returns>
        public bool AddCollection(string p_name)
        {
            return this.AddCollection(new OrganizedCollection(p_name));
        }

        /// <summary>
        /// Add a new OrganizedCollection object to the CollectionsDatabase
        /// </summary>
        /// <param name="p_collection">The name of the new OrganizedCollection</param>
        /// <returns>True if successful, false if a collection with that name exists</returns>
        public bool AddCollection(OrganizedCollection p_collection)
        {
            if (HasCollection(p_collection.Name)) { return false; }
            _collections = _collections.Union(new OrganizedCollection[] { p_collection });
            return true;
        }

        public bool AddToCollection(string p_collection, string p_tag, string p_entry)
        {
            return this.AddToCollection(p_collection, p_tag, new string[] { p_entry });
        }

        public bool AddToCollection(string p_collection, string p_tag, IEnumerable<string> p_entries)
        {
            if (!HasCollection(p_collection)) { return false; }
            _collections.Single(e => e.Name == p_collection).AddEntriesToGroup(p_tag, p_entries);
            return true;
        }

        #endregion

        private bool HasCollection(string p_name)
        {
            return _collections.Any(e => e.Name == p_name);
        }
    }
}
