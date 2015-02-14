using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary {
    public class FileActions {
        public static void CopyDirectory(string sourcePath, string targetPath) {
            if (!Directory.Exists(sourcePath)) return;
            if (!Directory.Exists(targetPath)) Directory.CreateDirectory(targetPath);

            foreach (var file in Directory.GetFiles(sourcePath)) {
                var destination = Path.Combine(targetPath, Path.GetFileName(file));
                File.Copy(file, destination);
            }

            foreach (var dir in Directory.GetDirectories(sourcePath)) {
                var destination = Path.Combine(targetPath, Path.GetFileName(dir));
                CopyDirectory(dir, destination);
            }
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
