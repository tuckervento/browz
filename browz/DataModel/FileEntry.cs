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
        private string _tag;

        #region Constructors

        /// <summary>
        /// Creates a new FileEntry object.
        /// </summary>
        /// <param name="p_fullpath">The absolute path of the file to reference</param>
        public FileEntry(string p_fullpath)
        {
            _fullPath = p_fullpath;
        }

        /// <summary>
        /// Creates a new FileEntry object.
        /// </summary>
        /// <param name="p_fullpath">The absolute path of the file to reference</param>
        /// <param name="p_tag">The tag for the file</param>
        public FileEntry(string p_fullpath, string p_tag)
        {
            _fullPath = p_fullpath;
            _tag = p_tag;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public FileEntry(SerializationInfo p_info, StreamingContext p_context)
        {
            _fullPath = (string)p_info.GetValue(Serialization.FileEntryFullPath, typeof(string));
            _tag = (string)p_info.GetValue(Serialization.FileEntryTag, typeof(string));
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
        /// The file extension of the referenced file
        /// </summary>
        public string FileExtension
        {
            get { return System.IO.Path.GetExtension(_fullPath); }
        }

        /// <summary>
        /// The tag for the referenced file
        /// </summary>
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        #endregion

        #region ISerializable

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Serialization.FileEntryFullPath, _fullPath, typeof(string));
            info.AddValue(Serialization.FileEntryTag, _tag, typeof(string));
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
