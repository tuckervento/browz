using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace browz.DataModel
{
    public class DirectoryList
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
        /// Adds the given directories into the DirectoryList with the associate bool value.
        /// </summary>
        /// <param name="p_directories">The directories to add</param>
        /// <param name="p_recursive">Whether the directories should be searched recursively</param>
        public void AddDirectories(IEnumerable<string> p_directories, bool p_recursive)
        {
            foreach (var d in p_directories) {
                _pathList[d] = p_recursive;
            }
        }

        /// <summary>
        /// A read-only copy of the directories in this DirectoryList
        /// </summary>
        public IReadOnlyList<string> Directories
        {
            get { return _pathList.Keys.ToList(); }
        }
    }
}
