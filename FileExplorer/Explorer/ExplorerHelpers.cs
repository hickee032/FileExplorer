using Shell32;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileExplorer.Explorer
{
    public static class ExplorerHelpers
    {
        //경로가 파일인지 확인
        public static bool IsFile(this string path) {
            return !string.IsNullOrEmpty(path) && File.Exists(path);
        }

        //경로가 디렉토리인지 확인
        public static bool IsDirectory(this string path) {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path);
        }

        //경로가 드라이브인지 확인
        public static bool IsDrive(this string path) {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path);
        }


        //경로 내의 파일 이름을 가져옵니다
        public static string GetFileName(this string fullpath) {
            return Path.GetFileName(fullpath);
        }

        //파일이 있는 디렉터리의 디렉터리 경로를 반환
        public static string GetParentDirectory(this string fullpath) {
            return Path.GetFileName(fullpath);
        }
        
        //경로가 파일의 바로 가기인지 확인
        public static bool CheckpathIsShortcutFile(string path) {
            return File.Exists(GetShortcutTargetFolder(path));
        }

        
        public static string GetShortcutTargetFolder(string shortcutFilename) {
            string pathOnly = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);

            if (folderItem != null) {
                ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;

        }
    }
}
