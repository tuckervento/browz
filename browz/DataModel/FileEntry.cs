using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace browz.DataModel
{
    [Serializable()]
    public class FileEntry : ISerializable, IEquatable<FileEntry>
    {
        private readonly string _fullPath;
        private List<string> _tags;

        #region Constructors

        /// <summary>
        /// Creates a new FileEntry object.
        /// </summary>
        /// <param name="p_fullpath">The absolute path of the file to reference</param>
        public FileEntry(string p_fullpath)
        {
            _fullPath = p_fullpath;
            _tags = new List<string>();
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public FileEntry(SerializationInfo p_info, StreamingContext p_context)
        {
            _fullPath = (string)p_info.GetValue(Serialization.FileEntryFullPath, typeof(string));
            _tags = (List<string>)p_info.GetValue(Serialization.FileEntryTag, typeof(List<string>));
        }

        #endregion

        //explicit conversion from string to FileEntry
        public static explicit operator FileEntry(String s)
        {
            FileEntry fe = new FileEntry(s);
            return fe;
        }

        #region Properties

        /// <summary>
        /// The absolute path of the referenced file
        /// </summary>
        public string FullPath
        {
            get { return _fullPath; }
        }

        /// <summary>
        /// The name of the referenced file
        /// </summary>
        public string FileName
        {
            get { return System.IO.Path.GetFileName(_fullPath); }
        }

        /// <summary>
        /// The tag for the referenced file
        /// </summary>
        public IEnumerable<string> Tags
        {
            get { return (_tags.Count == 0) ? new List<string>() { "untagged" } : _tags; }
        }

        public void ClearTags()
        {
            _tags.Clear();
        }

        public void AddTag(string p_tag)
        {
            _tags.Add(p_tag);
        }

        public void RemoveTag(string p_tag)
        {
            _tags.Remove(p_tag);
        }

        public bool HasTag(string p_tag)
        {
            return (_tags.Count != 0) ? _tags.Contains(p_tag) : p_tag.Equals("untagged");
        }

        #endregion

        #region ISerializable

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Serialization.FileEntryFullPath, _fullPath, typeof(string));
            info.AddValue(Serialization.FileEntryTag, _tags, typeof(List<string>));
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Tests equality based on file name.
        /// </summary>
        /// <param name="other">The other FileEntry to compare</param>
        /// <returns></returns>
        public bool Equals(FileEntry other)
        {
            return this.FileName.Equals(other.FileName);
        }

        /// <summary>
        /// Tests equality based on file name.
        /// </summary>
        /// <param name="other">The name of the other file to compare</param>
        public bool Equals(string other)
        {
            return this.FileName.Equals(other);
        }

        #endregion
    }
}
