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

            // for exception handling
            string currentFile = "";

            // code for getting all files
            try {
                foreach (string file in Directory.GetFiles(directory)) {
                    currentFile = file;

                    // Checks if it isn't an extension.
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
                    "Exception getting files in directory");
            }
            catch (UnauthorizedAccessException noAccess) {
                MessageBox.Show(
                    $"No access for a file: {noAccess.Message}",
                    "Exception getting files in directory");
            }
            catch (Exception e) {
                MessageBox.Show(
                    $"Failed to get files in '{directory}' || " +
                    $"Something to do with '{currentFile}'\n" +
                    $"Exception: {e.Message}", "Error");
            }

            return files;
        }
    }
}
