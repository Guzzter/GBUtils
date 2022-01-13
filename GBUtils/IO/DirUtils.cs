using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GBUtils.IO
{
    public static class DirUtils
    {
        /// <summary>
        /// Iterate through path starting from root and check if directory needs to be created
        /// </summary>
        /// <param name="path">full directory path</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CreatePathIfNotExist(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            }

            // Verify if drive is valid, otherwise return false
            string pathBuilder = Path.GetPathRoot(path);
            if (!DriveExists(pathBuilder) || path.Equals(pathBuilder, StringComparison.OrdinalIgnoreCase))
            {
                // Drive is invalid
                return false;
            }

            // Iterate through path starting from root and check if directory needs to be created
            path = path.Replace(pathBuilder, "");
            var parts = path.Split(new char[] { '\\' });
            foreach (var part in parts)
            {
                pathBuilder = Path.Combine(pathBuilder, part);
                if (!Directory.Exists(pathBuilder))
                {
                    Directory.CreateDirectory(pathBuilder);
                }
            }

            // Path is valid
            return true;
        }

        public static void CreateSubDir(string targetBaseDir, string targetSubdir)
        {
            string newPath = Path.Combine(targetBaseDir, targetSubdir);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
        }

        public static void DeleteWhenEmpty(string folder)
        {
            // Auto cleanup empty dirs
            if (Directory.Exists(folder) && Directory.GetFiles(folder).Length == 0)
            {
                Directory.Delete(folder);
            }
        }

        public static bool DriveExists(string driveLetterWithColonAndSlash)
        {
            if (string.IsNullOrWhiteSpace(driveLetterWithColonAndSlash))
            {
                throw new ArgumentException($"'{nameof(driveLetterWithColonAndSlash)}' cannot be null or whitespace.", nameof(driveLetterWithColonAndSlash));
            }

            driveLetterWithColonAndSlash = Path.GetPathRoot(driveLetterWithColonAndSlash);
            return DriveInfo.GetDrives().Any(x => x.Name == driveLetterWithColonAndSlash);
        }

        public static string GetExecutingDriveFromApplication(string appendDirs = "")
        {
            return Path.Combine(Path.GetPathRoot(GetExecutingPathFromApplication()), appendDirs);
        }

        public static string GetExecutingPathFromApplication()
        {
            string filePath = Assembly.GetExecutingAssembly().CodeBase;
            filePath = filePath.Replace("file:///", string.Empty);
            filePath = filePath.Replace("/", "\\");
            return filePath;
        }
    }
}