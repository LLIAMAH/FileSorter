using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSorter.Classes
{
    internal class FileMgr
    {
        internal static IList<IFileItem> GetFiles(string pathName)
        {
            var di = new DirectoryInfo(pathName);
            if (!di.Exists)
                throw new DirectoryNotFoundException(pathName);

            var result = new List<IFileItem>();
            result.AddRange(GetFiles(di));

            return result;
        }

        private static IEnumerable<IFileItem> GetFiles(DirectoryInfo di)
        {
            var result = new List<IFileItem>();
            var subDirs = di.GetDirectories();
            if (subDirs.Any())
            {
                foreach (var directoryInfo in subDirs)
                    result.AddRange(GetFiles(directoryInfo));
            }
            else
                result.AddRange(CollectFileData(di.GetFiles()));

            return result;
        }

        private static IEnumerable<IFileItem> CollectFileData(FileInfo[] files)
        {
            return files.Any()
                ? files.Select(fileInfo => new FileItem(fileInfo)).Cast<IFileItem>().ToList()
                : new List<IFileItem>();
        }
    }
}
