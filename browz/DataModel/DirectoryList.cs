using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace browz.DataModel
{
    [Serializable()]
    public class DirectoryList : ISerializable
    {
        //bool determines if the directory should be recursive searched
        private Dictionary<string, bool> _pathList;

        /// <summary>
        /// Creates a new DirectoryList object.
        /// </summary>
        public DirectoryList()
        {
            _pathList = new Dictionary<string, bool>();
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public DirectoryList(SerializationInfo p_info, StreamingContext p_context)
        {
            _pathList = (Dictionary<string, bool>)p_info.GetValue(Serialization.DirectoryList, typeof(Dictionary<string, bool>));
        }

        /// <summary>
        /// Adds the given directory into the DirectoryList with the associate bool value.
        /// </summary>
        /// <param name="p_directory">The directory to add</param>
        /// <param name="p_recursive">Whether the directories should be searched recursively</param>
        public void Add(string p_directory, bool p_recursive)
        {
            _pathList[p_directory] = p_recursive;
        }

        /// <summary>
        /// Clear the list of directories.
        /// </summary>
        public void Clear()
        {
            _pathList.Clear();
        }

        /// <summary>
        /// A read-only copy of the directories in this DirectoryList
        /// </summary>
        public IReadOnlyList<string> Directories
        {
            get { return _pathList.Keys.ToList(); }
        }

        /// <summary>
        /// A read-only copy of the directories and their matching bool value
        /// </summary>
        public IReadOnlyDictionary<string, bool> DirectoryDictionary
        {
            get { return _pathList; }
        }

        #region ISerializable

        public void GetObjectData(SerializationInfo p_info, StreamingContext p_context)
        {
            p_info.AddValue(Serialization.DirectoryList, _pathList, typeof(Dictionary<string, bool>));
        }

        #endregion
    }
}
