using System.Collections.Generic;
using System.IO;

namespace LauncherWPF.Data
{

    /// <summary>
    ///     Some useful extensions for various objects.
    /// </summary>
    public static class Extensions
    {

        /// <summary>
        ///     Iterates across each individual line in the <see cref="StreamReader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="StreamReader"/> to iterate over.</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<string> Lines(this StreamReader reader)
        {
            string s;
            while ((s = reader.ReadLine()) != null) yield return s;
        }

    }

}