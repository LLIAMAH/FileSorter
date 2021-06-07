﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSorter.Classes
{
    public class FileItem : IFileItem, IFileAttachment
    {
        private ChangesStatusCollection _changesStatus = null;

        public bool Checked { get; set; }
        public string FileName { get; set; }
        public string Extension
        {
            get
            {
                if(string.IsNullOrEmpty(this.FullName))
                    return string.Empty;

                var fi = new FileInfo(this.FullName);
                return fi.Extension;
            }
        }
        public string FullName { get; set; }
        public string ParentDir { get; set; }
        public string PathDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(this.FullName))
                    return string.Empty;

                var fi = new FileInfo(this.FullName);
                var di = fi.Directory;
                return di?.FullName;
            }
        }
        public ChangesStatusCollection ChangesStatus => _changesStatus ?? (_changesStatus = new ChangesStatusCollection());

        public string Changes => this.ChangesStatus.ToString();

        public FileItem()
        {
            Checked = false;
        }

        public FileItem(FileInfo item)
        {
            Checked = false;
            FullName = item.FullName;
            FileName = GetFileName(this.FullName);
            ParentDir = GetParentDirectory(this.FullName);
        }

        public FileItem(string pathToFile)
        {
            Checked = false;
            FullName = pathToFile;
            FileName = GetFileName(this.FullName);
            ParentDir = GetParentDirectory(this.FullName);
        }

        public FileItem(string pathToFile, IEnumerable<ChangesStatus> changes)
        {
            Checked = false;
            FullName = pathToFile;
            FileName = GetFileName(this.FullName);
            ParentDir = GetParentDirectory(this.FullName);
            foreach (var item in changes)
                this.ChangesStatus.Add(item);
        }

        public override string ToString()
        {
            return $"{this.FileName}{this.Extension}";
        }

        private static string GetFileName(string fullName)
        {
            var fi = new FileInfo(fullName);
            var fileNameFull = fi.Name;

            var fileNameSeparated = fileNameFull.Split(new char[] { '.' });
            switch (fileNameSeparated.Length)
            {
                case 1: return fileNameSeparated[0];
                case 2: return fileNameSeparated[0];
                case 0: throw new Exception("Problem in name detection");
                default:
                    {
                        var result = string.Empty;
                        for (var i = 0; i < fileNameSeparated.Length - 1; i++)
                            result += $"{fileNameSeparated[i]}.";

                        result = result.TrimEnd(new char[] { '.' });
                        return result;
                    }
            }
        }

        private static string GetParentDirectory(string fullName)
        {
            var di = new DirectoryInfo(fullName);
            return di?.Parent?.Name;
        }

        public bool HasRename
        {
            get { return this.ChangesStatus.FirstOrDefault(o => o.Change == Change.Rename) != null; }
        }
    }

    public class ChangesStatusCollection : List<ChangesStatus>
    {
        public new void Add(ChangesStatus item)
        {
            var res = this.SingleOrDefault(o => o.Change == item.Change);
            if (res == null)
            {
                base.Add(item);
                return;
            }

            res.Name = item.Name;
            res.Value = item.Value;
        }

        public override string ToString()
        {
            if (this.Count == 0)
                return string.Empty;

            if (this.Count == 1)
                return this.First().ToString();

            var result = this.Aggregate(string.Empty, (current, item) => current + $"{item}; ");

            result = result.TrimEnd(new char[] { ';', ' ' });

            return $"{result}.";
        }
    }

    public interface IFileItem
    {
        bool Checked { get; set; }
        string FileName { get; set; }
        string Extension { get; }
        string ParentDir { get; set; }
        string FullName { get; set; }
        string PathDirectory { get; }
    }

    public interface IFileAttachment
    {
        string FileName { get; set; }
        string Extension { get; }
        string FullName { get; set; }
        string PathDirectory { get; }
    }

    public enum Change
    {
        Empty = 0,
        Move,
        Rename,
        AttachmentAdded,
        Grouped,
        Delete
    }

    public class ChangesStatus
    {
        public Change Change { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return $"{GetString(this.Change)}: \"{this.Name}\"";
        }

        private static string GetString(Change change)
        {
            switch(change)
            {
                case Change.Empty: return "<empty>";
                case Change.Move: return "Move";
                case Change.Rename: return "Rename";
                case Change.AttachmentAdded: return "Attachment";
                case Change.Grouped: return "Group name";
                case Change.Delete: return "Delete";
                default: return "<empty>";
            }
        }
    }

    public class FilesContext
    {
        private static List<FileItem> _files = null;
        public static List<FileItem> Files => _files ?? (_files = new List<FileItem>());

        public static List<IFileItem> RefreshFiles(string filter, string rootFolder)
        {
            if (string.IsNullOrEmpty(rootFolder))
                return new List<IFileItem>();

            var di = new DirectoryInfo(rootFolder);
            if (!di.Exists)
                return new List<IFileItem>();

            return ApplyFiles(GetFiles(filter, di));
        }

        private static List<IFileItem> ApplyFiles(List<FileInfo> list)
        {
            return new List<IFileItem>(list.Select(item => new FileItem(item)).ToList());
        }

        private static List<FileInfo> GetFiles(string filter, DirectoryInfo di)
        {
            var list = new List<FileInfo>();

            DirectoryInfo[] directories = null;
            try
            {
                directories = di.GetDirectories();
                if (!directories.Any())
                {
                    list.AddRange(FilteredList(filter, di.GetFiles()));
                    return list;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return list;
            }

            list.AddRange(FilteredList(filter, di.GetFiles()));

            foreach (var dir in directories)
                list.AddRange(GetFiles(filter, dir));

            return list;
        }

        // Need optimization!!!!!
        private static List<FileInfo> FilteredList(string filter, FileInfo[] fileInfo)
        {
            var parsedFilter = filter.Split(new char[] { ';' });
            var listParsedFilter = parsedFilter.Select(item => item.Trim()).ToList();

            var result = new List<FileInfo>();
            foreach (var file in fileInfo)
                result.AddRange(
                    from item in listParsedFilter
                    where file.Extension.Equals($".{item}", StringComparison.OrdinalIgnoreCase)
                    select file);

            return result;
        }
    }
}
