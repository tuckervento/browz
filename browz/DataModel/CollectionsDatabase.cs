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
        private Dictionary<string, OrderedCollection> _collections;
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
            _collections = new Dictionary<string, OrderedCollection>();
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
            _collections = new Dictionary<string,OrderedCollection>();
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
            foreach (var kvp in _directories.DirectoryDictionary) {
                var files = Directory.EnumerateFiles(kvp.Key, "*",
                    (kvp.Value ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
                _master.AddEntries(files);
            }
        }

        #endregion
    }
}
