using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter.Classes
{
    public class FileManager
    {
        /// public enum Change
        /// {
        ///     Empty,              <= do nothing
        ///     Move,               <= move
        ///     Rename,             <= 
        ///     AttachmentAdded,    <= have to create folder with file NEW name first
        ///     Grouped             <= have to create folder with file NEW name first
        /// }        

        internal static void Process(List<IFileItem> files)
        {
            for (int i = 0; i < files.Count; i++)
            {
                var fi = new FileInfo(files[i].FullName);
                if (!fi.Exists)
                    continue;

                var deleteOperation = files[i].ChangesStatus.Where(o => o.Change == Change.Delete).SingleOrDefault();
                if (deleteOperation != null)
                {
                    File.Delete(files[i].FullName);
                    continue;
                }

                var renameOperation = files[i].ChangesStatus.Where(o => o.Change == Change.Rename).SingleOrDefault();
                if (renameOperation != null)
                    files[i] = RenameFile(files[i], renameOperation.Value as String);

                var moveOperation = files[i].ChangesStatus.Where(o => o.Change == Change.Move).SingleOrDefault();
                var groupOperation = files[i].ChangesStatus.Where(o => o.Change == Change.Grouped).SingleOrDefault();
                var attachmentOperation = files[i].ChangesStatus.Where(o => o.Change == Change.AttachmentAdded).SingleOrDefault();

                if (moveOperation != null)
                    files[i] = MoveFile(files[i], moveOperation.Value as String, groupOperation, attachmentOperation);
                else if (groupOperation != null || attachmentOperation != null)
                    files[i] = GroupAndAttachmentFile(files[i], groupOperation, attachmentOperation);
            }
        }

        private static IFileItem GroupAndAttachmentFile(IFileItem fileItem, ChangesStatus groupOperation, ChangesStatus attachmentOperation)
        {
            if (groupOperation != null && attachmentOperation != null)
                return MoveFileGroupAndAttachment(fileItem, fileItem.PathDirectory, groupOperation.Value as String, attachmentOperation.Value as IFileAttachment);
            else if (groupOperation != null)
                return MoveFileGroup(fileItem, fileItem.PathDirectory, groupOperation.Value as String);
            else if (attachmentOperation != null)
                return MoveFileAttachment(fileItem, fileItem.PathDirectory, attachmentOperation.Value as IFileAttachment);

            return fileItem; // return itself if all operations are null;
        }

        private static IFileItem MoveFile(IFileItem fileItem, string pathToMove, ChangesStatus groupOperation, ChangesStatus attachmentOperation)
        {
            if (groupOperation != null && attachmentOperation != null)
                return MoveFileGroupAndAttachment(fileItem, pathToMove, groupOperation.Value as String, attachmentOperation.Value as IFileAttachment); // done !!!
            else if (groupOperation != null)
                return MoveFileGroup(fileItem, pathToMove, groupOperation.Value as String);
            else if (attachmentOperation != null)
                return MoveFileAttachment(fileItem, pathToMove, attachmentOperation.Value as IFileAttachment);
            return MoveFile(fileItem, pathToMove); // done !!!
        }

        private static IFileItem MoveFile(IFileItem fileItem, string pathToMove)
        {
            var fileNewFullName = DefineFileNewFullName(pathToMove, fileItem.FileName, fileItem.Extension);

            return FileMove(fileItem.FullName, fileNewFullName);
        }

        private static IFileItem MoveFileGroupAndAttachment(IFileItem fileItem, string pathToMove, string groupName, IFileAttachment attachment)
        {
            // check and create path to the group/attachment directory
            var newPathToMove = Path.Combine(pathToMove, groupName, fileItem.FileName);
            var di = new DirectoryInfo(newPathToMove);
            if (!di.Exists)
                di.Create();

            var fileName = String.Format("{0}{1}",fileItem.FileName, fileItem.Extension);
            var attachmentName = String.Format("{0}{1}", attachment.FileName, attachment.Extension);

            var fileNewFullName = Path.Combine(di.FullName, fileName);
            var attachmentNewFullName = Path.Combine(di.FullName, attachmentName);

            FileMove(attachment.FullName, attachmentNewFullName);
            return FileMove(fileItem.FullName, fileNewFullName);
        }

        private static IFileItem MoveFileGroup(IFileItem fileItem, string pathToMove, string groupName)
        {
            // check and create path to the group directory
            var newPathToMove = Path.Combine(pathToMove, groupName);
            var di = new DirectoryInfo(newPathToMove);
            if (!di.Exists)
                di.Create();

            var fileName = String.Format("{0}{1}", fileItem.FileName, fileItem.Extension);
            var fileNewFullName = Path.Combine(di.FullName, fileName);
            return FileMove(fileItem.FullName, fileNewFullName);
        }

        private static IFileItem MoveFileAttachment(IFileItem fileItem, string pathToMove, IFileAttachment attachment)
        {
            // check and create path to the attachment directory
            var newPathToMove = Path.Combine(pathToMove, fileItem.FileName);
            var di = new DirectoryInfo(newPathToMove);
            if (!di.Exists)
                di.Create();

            var fileName = String.Format("{0}{1}", fileItem.FileName, fileItem.Extension);
            var fileNewFullName = Path.Combine(di.FullName, fileName);

            var attachmentName = String.Format("{0}{1}", attachment.FileName, attachment.Extension);
            var attachmentNewFullName = Path.Combine(di.FullName, attachmentName);

            FileMove(attachment.FullName, attachmentNewFullName);
            return FileMove(fileItem.FullName, fileNewFullName);
        }

        private static IFileItem RenameFile(IFileItem fileItem, string newName)
        {
            var fileNewFullName = DefineFileNewFullName(fileItem.PathDirectory, newName, fileItem.Extension);
            return FileMove(fileItem.FullName, fileNewFullName, fileItem.ChangesStatus.Where(o => o.Change != Change.Rename));
        }

        private static string DefineFileNewFullName(string directory, string newName, string extension)
        {
            var name = string.Format("{0}{1}", newName, extension);
            return Path.Combine(directory, name);
        }

        private static IFileItem FileMove(string source, string destination, IEnumerable<ChangesStatus> enumerable = null)
        {
            var fiSource = new FileInfo(source);
            if (!fiSource.Exists)
                return new FileItem();

            var fiDestination = new FileInfo(destination);
            if (fiDestination.Exists)
                destination = CreateNewNameForDestination(destination);

            try
            {
                File.Move(source, destination);
            }
            catch
            {
                return new FileItem(source, enumerable);
            }

            if(enumerable == null || enumerable.Count() == 0)
                return new FileItem(destination);

            return new FileItem(destination, enumerable);
        }

        private static string CreateNewNameForDestination(string destination)
        {
            var fi = new FileInfo(destination);

            var counter = 1;
            while(fi.Exists)
            {
                var dir = fi.Directory;
                var name = GetNameOnly(fi.Name);
                var extension = fi.Extension;

                var newName = string.Format("{0} ({1}){2}", name, counter, extension);
                destination = Path.Combine(dir.FullName, newName);
                fi = new FileInfo(destination);
                counter++;
            }

            return fi.FullName;
        }

        private static string GetNameOnly(string nameWitExtension)
        {
            var fileNameSplitted = nameWitExtension.Split(new char[] { '.' });
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
    }
}
