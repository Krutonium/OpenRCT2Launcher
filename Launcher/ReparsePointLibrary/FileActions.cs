using System;
using System.IO;

namespace HelperLibrary {
    public class FileActions {
        /// <summary>
        /// Copies all contents of a directory to another directory
        /// </summary>
        /// <param name="sourcePath">The path where the files should be copied from</param>
        /// <param name="targetPath">The path where the files should be copied to</param>
        /// <returns>The number of duplicate filenames</returns>
        public static int CopyDirectory(string sourcePath, string targetPath) {
            var doubles = 0;

            if (!Directory.Exists(sourcePath)) return 0;
            if (!Directory.Exists(targetPath)) Directory.CreateDirectory(targetPath);

            foreach (var file in Directory.GetFiles(sourcePath)) {
                var destination = Path.Combine(targetPath, Path.GetFileName(file));
                try {
                    File.Copy(file, destination);
                } catch (Exception) {
                    // File already exists at destination
                    doubles++;
                }
            }

            foreach (var dir in Directory.GetDirectories(sourcePath)) {
                var destination = Path.Combine(targetPath, Path.GetFileName(dir));
                doubles += CopyDirectory(dir, destination);
            }

            return doubles;
        }

        /// <summary>
        /// Removes all contents of specified directory
        /// </summary>
        /// <param name="path">The path to the folder that should be emptied</param>
        public static void ClearDirectory(string path) {
            if (!Directory.Exists(path)) return;

            foreach (var file in Directory.GetFiles(path)) {
                File.Delete(file);
            }
            foreach (var dir in Directory.GetDirectories(path)) {
                Directory.Delete(dir, true);
            }
        }
    }
}
