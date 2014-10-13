using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(String.IsNullOrEmpty(this.FullName))
                    return string.Empty;

                var fi = new FileInfo(this.FullName);
                return fi.Extension;
            }
        }
        public string FullName { get; set; }
        public string PathDirectory
        {
            get
            {
                if (String.IsNullOrEmpty(this.FullName))
                    return string.Empty;

                var fi = new FileInfo(this.FullName);
                var di = fi.Directory;
                return di.FullName;
            }
        }
        public ChangesStatusCollection ChangesStatus
        {
            get
            {
                if (_changesStatus == null)
                    _changesStatus = new ChangesStatusCollection();

                return _changesStatus;
            }
        }

        public string Changes
        {
            get
            {
                return this.ChangesStatus.ToString();
            }
        }

        public FileItem()
        {
            Checked = false;
        }

        public FileItem(FileInfo item)
        {
            Checked = false;
            FullName = item.FullName;
            FileName = GetFileName(this.FullName);
        }

        public FileItem(string pathToFile)
        {
            Checked = false;
            FullName = pathToFile;
            FileName = GetFileName(this.FullName);
        }

        public FileItem(string pathToFile, IEnumerable<Classes.ChangesStatus> changes)
        {
            Checked = false;
            FullName = pathToFile;
            FileName = GetFileName(this.FullName);
            foreach (var item in changes)
                this.ChangesStatus.Add(item);
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.FileName, this.Extension);
        }

        private static string GetFileName(string fullName)
        {
            var fi = new FileInfo(fullName);
            var fileNameFull = fi.Name;

            var fileNameSplitted = fileNameFull.Split(new char[] { '.' });
            switch (fileNameSplitted.Length)
            {
                case 1: return fileNameSplitted[0];
                case 2: return fileNameSplitted[0];
                case 0: throw new Exception("Problem in name detection");
                default:
                    {
                        string result = string.Empty;
                        for (int i = 0; i < fileNameSplitted.Length - 1; i++)
                            result += String.Format("{0}.", fileNameSplitted[i]);

                        result = result.TrimEnd(new char[] { '.' });
                        return result;
                    }
            }
        }

        public bool HasRename
        {
            get { return this.ChangesStatus.Where(o => o.Change == Change.Rename).FirstOrDefault() != null; }
        }
    }

    public class ChangesStatusCollection : List<ChangesStatus>
    {
        public new void Add(ChangesStatus item)
        {
            var res = this.Where(o => o.Change == item.Change).SingleOrDefault();
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
                return String.Empty;

            if (this.Count == 1)
                return this.First().ToString();

            var result = string.Empty;
            foreach (var item in this)
                result += String.Format("{0}; ", item.ToString());

            result = result.TrimEnd(new char[] { ';', ' ' });

            return String.Format("{0}.", result);
        }
    }

    public interface IFileItem
    {
        bool Checked { get; set; }
        string FileName { get; set; }
        string Extension { get; }
        string FullName { get; set; }
        string PathDirectory { get; }
        string Changes { get; }
        ChangesStatusCollection ChangesStatus { get; }
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
            return String.Format("{0}: \"{1}\"", GetString(this.Change), this.Name.ToString());
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
        public static List<FileItem> Files
        {
            get
            {
                if (_files == null)
                    _files = new List<FileItem>();

                return _files;
            }
        }

        public static List<FileItem> RefreshFiles(string filter, string rootFolder)
        {
            if (String.IsNullOrEmpty(rootFolder))
                return new List<FileItem>();

            DirectoryInfo di = new DirectoryInfo(rootFolder);
            if (!di.Exists)
                return new List<FileItem>();

            return ApplyFiles(GetFiles(filter, di));
        }

        private static List<FileItem> ApplyFiles(List<FileInfo> list)
        {
            var result = new List<FileItem>();
            foreach(var item in list)
                result.Add(new FileItem(item));

            return result;
        }

        private static List<FileInfo> GetFiles(string filter, DirectoryInfo di)
        {
            var list = new List<FileInfo>();

            DirectoryInfo[] directories = null;
            try
            {
                directories = di.GetDirectories();
                if (directories.Count() == 0)
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
            var listParsedFilter = new List<String>();
            foreach (var item in parsedFilter)
                listParsedFilter.Add(item.Trim());

            var result = new List<FileInfo>();
            foreach(var file in fileInfo)
            {
                foreach(var item in listParsedFilter)
                {
                    if (file.Extension.Equals(String.Format(".{0}",item), StringComparison.OrdinalIgnoreCase))
                        result.Add(file);
                }
            }

            return result;
        }
    }
}
