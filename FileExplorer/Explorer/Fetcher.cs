using FileExplorer.Files;
using FileExplorer.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;

namespace FileExplorer.Explorer
{
    public static class Fetcher
    {
        public static List<FileModel> GetFiles(string directory) {

            List<FileModel> files= new List<FileModel>();
            if (!directory.IsDirectory())
                return files;

            // 예외 처리
            string currentFile = "";

            // 모든 파일을 가져오는 코드
            try {
                foreach (string file in Directory.GetFiles(directory)) {
                    currentFile = file;

                    // 확장자가 아닌지 확인
                    if (Path.GetExtension(file) != ".lnk") {
                        FileInfo fInfo = new FileInfo(file);
                        FileModel fModel = new FileModel() {
                            Icon = IconHelper.GetIconOfFile(file, true, false),
                            Name = fInfo.Name,
                            Path = fInfo.FullName,
                            DateCreated = fInfo.CreationTime,
                            DateModified = fInfo.LastWriteTime,
                            Type = FileType.File,
                            SizeBytes = fInfo.Length
                        };

                        files.Add(fModel);
                    }
                }

                return files;
            }

            catch (IOException io) {
                MessageBox.Show(
                    $"IO Exception getting files in directory: {io.Message}",
                    "디렉터리에서 파일을 가져오는 중 예외가 발생했습니다.");
            }
            catch (UnauthorizedAccessException noAccess) {
                MessageBox.Show(
                    $"No access for a file: {noAccess.Message}",
                    "디렉터리에서 파일을 가져오는 중 예외가 발생했습니다.");
            }
            catch (Exception e) {
                MessageBox.Show(
                    $"Failed to get files in '{directory}' || " +
                    $"Something to do with '{currentFile}'\n" +
                    $"Exception: {e.Message}", "오류");
            }

            return files;
        }

        public static List<FileModel> GetDirectories(string directory) {

            List<FileModel> directories = new List<FileModel>();

            if(!directory.IsDirectory())
                return directories;

            string currentDirectory = "";

            try {

                foreach(string dir in Directory.GetDirectories(directory)) {
                    currentDirectory = dir;

                    DirectoryInfo dInfo = new DirectoryInfo(dir);
                    FileModel dModel = new FileModel() {

                        Icon = IconHelper.GetIconOfFile(dir, true, true),
                        Name = dInfo.Name,
                        Path = dInfo.FullName,
                        DateCreated = dInfo.CreationTime,
                        DateModified = dInfo.LastWriteTime,
                        Type = FileType.Folder,
                        SizeBytes = 0
                    };

                    directories.Add(dModel);
                }

                foreach (string file in Directory.GetFiles(directory)) {
                    if (Path.GetExtension(file) == ".lnk") {
                        string realDirPath = ExplorerHelpers.GetShortcutTargetFolder(file);
                        FileInfo dInfo = new FileInfo(realDirPath);
                        FileModel dModel = new FileModel() {
                            Icon = IconHelper.GetIconOfFile(realDirPath, true, true),
                            Name = dInfo.Name,
                            Path = dInfo.FullName,
                            DateCreated = dInfo.CreationTime,
                            DateModified = dInfo.LastWriteTime,
                            Type = FileType.Folder,
                            SizeBytes = 0
                        };

                        directories.Add(dModel);
                    }
                }

                return directories;
            }
            catch (IOException io) {
                MessageBox.Show(
                    $"IO Exception getting folders in directory: {io.Message}",
                    "Exception getting folders in directory");
            }
            catch (UnauthorizedAccessException noAccess) {
                MessageBox.Show(
                    $"No access for a directory: {noAccess.Message}",
                    "Exception getting folders in directory");
            }
            catch (Exception e) {
                MessageBox.Show(
                    $"Failed to get directories in '{directory}' || " +
                    $"Something to do with '{currentDirectory}'\n" +
                    $"Exception: {e.Message}", "Error");
            }

            return directories;
        }
    }

}
    

