using System;
using System.IO;

namespace HelperLibrary {
    public class FileActions {
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
