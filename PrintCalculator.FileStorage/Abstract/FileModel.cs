using System;

namespace PrintCalculator.FileStorage.Abstract
{
    /// <summary>
    /// Base data model for files
    /// </summary>
    public interface IFileModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// File extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Type of file
        /// </summary>
        public FileType Type { get; set; }
    }

    public enum FileType
    {
        Unknown, Image, Document
    }
}
