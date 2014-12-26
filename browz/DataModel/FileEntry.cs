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
        /// Serialization constructor.
        /// </summary>
        public FileEntry(SerializationInfo p_info, StreamingContext p_context)
        {
            _fullPath = (string)p_info.GetValue(Serialization.FileEntryFullPath, typeof(string));
        }

        #endregion

        //explicit conversion from string to FileEntry
        public static explicit operator FileEntry(string s)
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

        #endregion

        #region ISerializable

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Serialization.FileEntryFullPath, _fullPath, typeof(string));
        }

        #endregion

        #region IEquatable

        public bool Equals(FileEntry other)
        {
            return this.FileName.Equals(other.FileName);
        }

        #endregion
    }
}
