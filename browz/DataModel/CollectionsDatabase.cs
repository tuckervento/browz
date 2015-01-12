using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace browz.DataModel
{
    [Serializable()]
    internal class SortedCollectionList : List<FileEntryCollection>
    {
        //this cast doesn't work
        internal SortedCollectionList()
            : base()
        {
        }

        internal int Add(FileEntryCollection p_fec)
        {
            base.Add(p_fec);
            this.Sort();
            return base.IndexOf(p_fec);
        }

        internal void Sort()
        {
            base.Sort((x, y) => string.Compare(x.Name, y.Name));
        }

        internal FileEntryCollection this[string s]
        {
            get { return base[this.IndexOf(s)]; }
        }

        internal void Remove(string p_name)
        {
            base.RemoveAt(this.IndexOf(p_name));
        }

        internal int IndexOf(string p_name)
        {
            return base.FindIndex(c => c.Name == p_name);
        }
    }

    [Serializable()]
    public class CollectionsDatabase : ISerializable
    {
        private readonly string _name;
        private FileEntryCollection _master;
        private SortedCollectionList _collections;
        private DirectoryList _directories;
        private List<string> _extensions;

        #region Constructors

        /// <summary>
        /// Creates a new CollectionsDatabase object with the given name.
        /// </summary>
        /// <param name="p_name">The name of the new CollectionsDatabase</param>
        public CollectionsDatabase(string p_name)
        {
            _name = p_name;
            _master = new FileEntryCollection("Master");
            _collections = new SortedCollectionList();
            _directories = new DirectoryList();
            _extensions = new List<string>();
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
            _collections = new SortedCollectionList();
            _directories = p_directories;
            _extensions = new List<string>();
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public CollectionsDatabase(SerializationInfo p_info, StreamingContext p_context)
        {
            _name = (string)p_info.GetValue(Serialization.CollectionsDatabaseName, typeof(string));
            _master = (FileEntryCollection)p_info.GetValue(Serialization.CollectionsDatabaseMaster, typeof(FileEntryCollection));
            _collections = (SortedCollectionList)p_info.GetValue(Serialization.CollectionsDatabaseCollections, typeof(SortedCollectionList));
            _directories = (DirectoryList)p_info.GetValue(Serialization.CollectionsDatabaseDirs, typeof(DirectoryList));
            _extensions = (List<string>)p_info.GetValue(Serialization.CollectionsDatabaseExtensions, typeof(List<string>));
        }

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
        }

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

        /// <summary>
        /// The number of different collections within the database.
        /// </summary>
        public int CollectionCount
        {
            get { return _collections.Count(); }
        }

        /// <summary>
        /// An alphabetical list of the collection (view) names.
        /// </summary>
        public IEnumerable<string> CollectionNames
        {
            get { return _collections.Select(c => c.Name); }
        }

        /// <summary>
        /// Boolean indicating whether or not there are any collections in this database.
        /// </summary>
        public bool Empty
        {
            get { return _collections.Count == 0; }
        }

        #endregion

        #region Database modification

        /// <summary>
        /// Adds file extensions to exclude from the search.
        /// </summary>
        /// <param name="p_extensions">The extensions to exclude</param>
        public void AddExcludedExtensions(IEnumerable<string> p_extensions)
        {
            _extensions.AddRange(p_extensions.Where(e => !_extensions.Contains(e)));
        }

        /// <summary>
        /// Clears the list of excluded extensions.
        /// </summary>
        public void ClearExcludedExtensions()
        {
            _extensions.Clear();
        }

        /// <summary>
        /// Search through directories as specified by the DirectoryList of this database, and store all of the found files in the master list.
        /// </summary>
        public void GenerateMasterList()
        {
            _master = new FileEntryCollection("Master");
            if (_extensions.Count > 0)
            {
                foreach (var kvp in _directories.DirectoryDictionary)
                {
                    var files = Directory.EnumerateFiles(kvp.Key, "*",
                        (kvp.Value ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)).Where(e => !_extensions.Contains(Path.GetExtension(e)));
                    _master.AddEntries(files);
                }
            }
            else
            {
                foreach (var kvp in _directories.DirectoryDictionary)
                {
                    var files = Directory.EnumerateFiles(kvp.Key, "*", (kvp.Value ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
                    _master.AddEntries(files);
                }
            }

            foreach (var collection in _collections)
            {
                collection.Clear(_master.Entries);
            }
        }

        /// <summary>
        /// Add a new OrganizedCollection object to the CollectionsDatabase
        /// </summary>
        /// <param name="p_name">The name of the new OrganizedCollection</param>
        /// <returns>The index of the new collection</returns>
        public int AddCollection(string p_name)
        {
            return _collections.Add(new FileEntryCollection(p_name, _master.Entries)); ;
        }

        /// <summary>
        /// Returns a copy of the entries with the specified tag, or null if it doesn't exist
        /// </summary>
        /// <param name="p_collection">The collection to search</param>
        /// <param name="p_tag">The tag to find</param>
        public IEnumerable<FileEntry> GetEntriesTaggedAs(int p_collection, string p_tag)
        {
            return _collections[p_collection].GetEntriesTaggedAs(p_tag);
        }

        /// <summary>
        /// Returns the collection with the specified name, or null if it doesn't exist.
        /// </summary>
        /// <param name="p_collection">The collection to find</param>
        public FileEntryCollection GetCollection(int p_collection)
        {
            return _collections[p_collection] ?? null;
        }

        /// <summary>
        /// Renames the appropriate collection.
        /// </summary>
        /// <param name="p_collection">The index of the collection</param>
        /// <param name="p_newName">The new name of the collection</param>
        /// <returns>Index of new collection</returns>
        public int RenameCollection(int p_collection, string p_newName)
        {
            _collections[p_collection].Name = p_newName;
            _collections.Sort();
            return _collections.IndexOf(p_newName);
        }

        /// <summary>
        /// Removes the specified collection from the database.
        /// </summary>
        /// <param name="p_collection">The collection to remove</param>
        public void RemoveCollection(int p_collection)
        {
            _collections.RemoveAt(p_collection);
        }

        #endregion

        #region ISerializable

        public void GetObjectData(SerializationInfo p_info, StreamingContext p_context)
        {
            p_info.AddValue(Serialization.CollectionsDatabaseName, _name, typeof(string));
            p_info.AddValue(Serialization.CollectionsDatabaseMaster, _master, typeof(FileEntryCollection));
            p_info.AddValue(Serialization.CollectionsDatabaseCollections, _collections, typeof(SortedCollectionList));
            p_info.AddValue(Serialization.CollectionsDatabaseDirs, _directories, typeof(DirectoryList));
            p_info.AddValue(Serialization.CollectionsDatabaseExtensions, _extensions, typeof(List<string>));
        }

        #endregion
    }
}
