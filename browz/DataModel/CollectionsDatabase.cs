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
    internal class SortedCollectionList : SortedList<string, FileEntryCollection>
    {
        public SortedCollectionList() : base((IComparer<string>)new CaseInsensitiveComparer())
        {

        }

        public void Add(FileEntryCollection p_fec) {
            base.Add(p_fec.Name, p_fec);
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
        public IList<string> CollectionNames
        {
            get { return _collections.Keys; }
        }

        /// <summary>
        /// Boolean indicating whether or not there are any collections in this database.
        /// </summary>
        public bool Empty
        {
            get { return _collections.Count != 0; }
        }

        #endregion

        #region Database modification

        /// <summary>
        /// Adds file extensions to exclude from the search.
        /// </summary>
        /// <param name="p_extensions">The extensions to exclude</param>
        public void AddExcludedExtensions(IEnumerable<string> p_extensions)
        {
            _extensions.AddRange(p_extensions.Where(e => !_extensions.Contains(e));
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
            foreach (var kvp in _directories.DirectoryDictionary) {
                var files = Directory.EnumerateFiles(kvp.Key, "*",
                    (kvp.Value ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)).Where(e => !_extensions.Contains(Path.GetExtension(e)));
                _master.AddEntries(files);
            }
        }

        /// <summary>
        /// Add a single FileEntry to all of the collections.
        /// </summary>
        /// <param name="p_path">The path to the file to add</param>
        public void AddFileEntry(string p_path)
        {
            _master.AddEntry(p_path);
        }

        /// <summary>
        /// Add a new OrganizedCollection object to the CollectionsDatabase
        /// </summary>
        /// <param name="p_name">The name of the new OrganizedCollection</param>
        /// <returns>The name if successful, null if a collection with that name exists</returns>
        public string AddCollection(string p_name)
        {
            if (String.IsNullOrEmpty(p_name) || HasCollection(p_name)) { return null; }
            _collections.Add(new FileEntryCollection(p_name, _master.Entries));
            return p_name;
        }

        /// <summary>
        /// Returns a copy of the entries with the specified tag, or null if it doesn't exist
        /// </summary>
        /// <param name="p_collection">The collection to search</param>
        /// <param name="p_tag">The tag to find</param>
        public IEnumerable<FileEntry> GetEntriesTaggedAs(string p_collection, string p_tag)
        {
            return (HasCollection(p_collection)) ? _collections[p_collection].GetEntriesTaggedAs(p_tag) : null;
        }

        /// <summary>
        /// Returns the collection with the specified name, or null if it doesn't exist.
        /// </summary>
        /// <param name="p_collection">The collection to find</param>
        public FileEntryCollection GetCollection(string p_collection)
        {
            return _collections[p_collection] ?? null;
        }

        /// <summary>
        /// Renames the appropriate collection.
        /// </summary>
        /// <param name="p_oldName">The current name of the collection</param>
        /// <param name="p_newName">The new name of the collection</param>
        /// <returns>Bool indicating success of rename</returns>
        public string RenameCollection(string p_oldName, string p_newName)
        {
            if (String.IsNullOrEmpty(p_newName) || String.IsNullOrEmpty(p_oldName) || HasCollection(p_oldName)) { return null; }
            _collections.Add(new FileEntryCollection(p_newName, _collections[p_oldName].Entries));
            _collections.Remove(p_oldName);
            return p_newName;
        }

        /// <summary>
        /// Removes the specified collection from the database.
        /// </summary>
        /// <param name="p_collection">The collection to remove</param>
        /// <returns>Bool indicating success of removal</returns>
        public bool RemoveCollection(string p_collection)
        {
            return _collections.Remove(p_collection);
        }

        #endregion

        private bool HasCollection(string p_name)
        {
            return _collections.Keys.Contains(p_name);
        }

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
