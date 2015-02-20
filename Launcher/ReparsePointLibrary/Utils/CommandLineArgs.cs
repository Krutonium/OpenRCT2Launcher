using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelperLibrary {
    internal class CommandLineArgs : Dictionary<string, string> {
        /// <summary>
        /// Creates a dictionarty with the arguments from the list of arguments
        /// </summary>
        /// <param name="args">The commandline arguments</param>
        /// <remarks>Accepts the following: {-,--,/}param{ ,=,:}((",')value(",'))</remarks>
        public CommandLineArgs(string[] args) {
            var Spliter = new Regex(@"^-{1,2}|^/|=|:", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            var Remover = new Regex(@"^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            string parameter = null;

            // Valid parameters forms:
            // {-,/,--}param{ ,=,:}((",')value(",'))
            // Examples: 
            // -param1 value1 --param2 /param3:"Test-:-work" 
            //   /param4=happy -param5 '--=nice=--'
            foreach (string Txt in args) {
                // Look for new parameters (-,/ or --) and a
                // possible enclosed value (=,:)
                var parts = Spliter.Split(Txt, 3);

                switch (parts.Length) {
                    // Found a value (for the last parameter 
                    // found (space separator))
                    case 1:
                        if (parameter != null) {
                            if (!ContainsKey(parameter)) {
                                parts[0] = Remover.Replace(parts[0], "$1");
                                Add(parameter, parts[0]);
                            }
                            parameter = null;
                        }
                        // else Error: no parameter waiting for a value (skipped)
                        break;

                    // Found just a parameter
                    case 2:
                        // The last parameter is still waiting. 
                        // With no value, set it to true.
                        if (parameter != null) {
                            if (!ContainsKey(parameter))
                                Add(parameter, "true");
                        }
                        parameter = parts[1];
                        break;

                    // Parameter with enclosed value
                    case 3:
                        // The last parameter is still waiting. 
                        // With no value, set it to true.
                        if (parameter != null) {
                            if (!ContainsKey(parameter))
                                Add(parameter, "true");
                        }

                        parameter = parts[1];

                        // Remove possible enclosing characters (",')
                        if (!ContainsKey(parameter)) {
                            parts[2] = Remover.Replace(parts[2], "$1");
                            Add(parameter, parts[2]);
                        }

                        parameter = null;
                        break;
                }
            }
            // In case a parameter is still waiting
            if (parameter == null) return;
            if (!ContainsKey(parameter))
                Add(parameter, "true");
        }

        public static string[] ArgsFromDictionary(IDictionary<string, string> args) {
            return args.Select(s => "/" + s.Key + "=\"" + s.Value + "\"").ToArray();
        }
    }
}
