using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.Utils
{
	/// <summary>
	/// Represents an INI configuration which can be loaded and saved from and to files.
	/// </summary>
	public class IniConfiguration
	{
		/// <summary>
		/// Represents a section with a name.
		/// </summary>
		private class Section
		{
			private readonly string _name;
			private readonly List<int> _lines = new List<int>();

			private readonly Dictionary<string, Property> _properties = new Dictionary<string, Property>();

			/// <summary>
			/// Gets the list of line indicies where the property is assigned a value.
			/// </summary>
			public IList<int> Lines { get { return _lines; } }

			/// <summary>
			/// Gets all the properies within this section.
			/// </summary>
			public IDictionary<string, Property> Properties { get { return _properties; } }

			/// <summary>
			/// Initialises a new instance of <see cref="Section"/>.
			/// </summary>
			public Section() : this(String.Empty) { }

			/// <summary>
			/// Initializes a new instance of <see cref="Section"/> with a name.
			/// </summary>
			/// <param name="name">The name.</param>
			public Section(string name)
			{
				_name = name;
			}
		}

		/// <summary>
		/// Represents a property with a name and a value.
		/// </summary>
		private class Property
		{
			private readonly string _name;
			private readonly List<int> _lines = new List<int>();

			/// <summary>
			/// Gets or sets the value of the property.
			/// </summary>
			public string Value { get; set; }

			/// <summary>
			/// Gets the list of line indicies where the property is assigned a value.
			/// </summary>
			public IList<int> Lines { get { return _lines; } }

			/// <summary>
			/// Initialises a new instance of <see cref="Property"/>.
			/// </summary>
			/// <param name="name">The name.</param>
			public Property(string name)
			{
				_name = name;
			}
		}

		private readonly List<string> _lines = new List<string>();
		private readonly Dictionary<string, Section> _sections = new Dictionary<string, Section>();

		/// <summary>
		/// Initialises a new instance of <see cref="IniConfiguration"/>.
		/// </summary>
		public IniConfiguration()
		{
			_sections[String.Empty] = new Section();
		}

		/// <summary>
		/// Initialises a new instance of <see cref="IniConfiguration"/> from a file.
		/// </summary>
		/// <param name="path">The path to the ini file to open.</param>
		public IniConfiguration(string path)
			: this()
		{
			string line;
			using (var sr = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
				while ((line = sr.ReadLine()) != null)
					_lines.Add(line);

			Parse();

            
		}

		/// <summary>
		/// Writes the configuration to an ini file.
		/// </summary>
		/// <param name="path">The path of the ini file to save as.</param>
		public async Task Save(string path)
		{
			using (var sw = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
				foreach (var line in _lines)
					await sw.WriteLineAsync(line);
		}

		/// <summary>
		/// Gets or sets the value of a property.
		/// </summary>
		/// <param name="sectionName">The name of the section.</param>
		/// <param name="propertyName">The name of the property.</param>
		public string this[string sectionName, string propertyName]
		{
			get { return GetProperty(sectionName, propertyName); }
			set { SetProperty(sectionName, propertyName, value); }
		}

		/// <summary>
		/// Checks if a property exists (has a value).
		/// </summary>
		/// <param name="sectionName">The name of the section.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <returns>True if the property exists with a value otherwise false.</returns>
		public bool PropertyExists(string sectionName, string propertyName)
		{
			if (!_sections.ContainsKey(sectionName))
				return false;

			var properties = _sections[sectionName].Properties;
			if (!properties.ContainsKey(propertyName))
				return false;

			return true;
		}

		/// <summary>
		/// Gets the value of a property with the specified name in the specified section.
		/// </summary>
		/// <param name="sectionName">The name of the section.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="defaultValue">The value to return if the property doesn't exist.</param>
		/// <returns>The value of the property or the default value if the property doesn't exist.</returns>
		public string GetProperty(string sectionName, string propertyName, string defaultValue = null)
		{
			if (!_sections.ContainsKey(sectionName))
				return defaultValue;

			var properties = _sections[sectionName].Properties;
			if (!properties.ContainsKey(propertyName))
				return defaultValue;

			return properties[propertyName].Value;
		}

		/// <summary>
		/// Gets the value of a property with the specified name in the specified section.
		/// </summary>
		/// <param name="sectionName">The name of the section.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="defaultValue">The value to return if the property doesn't exist.</param>
		/// <returns>The value of the property or the default value if the property doesn't exist.</returns>
		public bool GetPropertyBoolean(string sectionName, string propertyName, bool defaultValue = default(bool))
		{
			string value = GetProperty(sectionName, propertyName);
			if (value == null)
				return defaultValue;

			bool result;
			if (!Boolean.TryParse(value, out result))
				return defaultValue;

			return result;
		}

		/// <summary>
		/// Gets the value of a property with the specified name in the specified section.
		/// </summary>
		/// <param name="sectionName">The name of the section.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="defaultValue">The value to return if the property doesn't exist.</param>
		/// <returns>The value of the property or the default value if the property doesn't exist.</returns>
		public int GetPropertyInt32(string sectionName, string propertyName, int defaultValue = default(int))
		{
			if (!_sections.ContainsKey(sectionName))
				return defaultValue;

			var properties = _sections[sectionName].Properties;
			if (!properties.ContainsKey(propertyName))
				return defaultValue;

			int result;
			return Int32.TryParse(properties[propertyName].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ?
				result : defaultValue;
		}

		/// <summary>
		/// Gets the value of a property with the specified name in the specified section.
		/// </summary>
		/// <param name="sectionName">The name of the section.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="defaultValue">The value to return if the property doesn't exist.</param>
		/// <returns>The value of the property or the default value if the property doesn't exist.</returns>
		public double GetPropertyDouble(string sectionName, string propertyName, double defaultValue = default(double))
		{
			if (!_sections.ContainsKey(sectionName))
				return defaultValue;

			var properties = _sections[sectionName].Properties;
			if (!properties.ContainsKey(propertyName))
				return defaultValue;

			double result;
			return Double.TryParse(properties[propertyName].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ?
				result : defaultValue;
		}

		/// <summary>
		/// Sets or adds the property with the specified name in the specified section.
		/// </summary>
		/// <param name="sectionName">The name of the section.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="value">The value to set the property to.</param>
		public void SetProperty(string sectionName, string propertyName, string value)
		{
			Section section = GetOrAddSection(sectionName);

			Property property;
			if (section.Properties.ContainsKey(propertyName)) {
				property = section.Properties[propertyName];
				property.Value = value;

				int lastLineIndex = property.Lines.Last();
				_lines[lastLineIndex] = GetPropertySetValueLine(propertyName, value);
			} else {
				section.Properties[propertyName] = property = new Property(propertyName);
				property.Value = value;

				if (section.Lines.Count > 0) {
					int lastLineIndex = section.Lines.Last() + 1;
					_lines.Insert(lastLineIndex, GetPropertySetValueLine(propertyName, value));
					property.Lines.Add(lastLineIndex);
				} else {
					if (_lines.Count > 0 && !String.IsNullOrWhiteSpace(_lines.Last()))
						_lines.Add(String.Empty);
					_lines.Add(GetPropertySetValueLine(propertyName, value));
					property.Lines.Add(_lines.Count - 1);
				}
			}
		}

		private string GetPropertySetValueLine(string propertyName, string value)
		{
            if (value.Contains(" "))
                return propertyName + " = \"" + value + "\"";
            else
                return propertyName + " = " + value;
		}

		private void InsertLine(int index, string line)
		{
			foreach (Section section in _sections.Values)
				foreach (Property property in section.Properties.Values)
					for (int i = 0; i < property.Lines.Count; i++)
						if (property.Lines[i] <= index)
							property.Lines[i]++;

			_lines.Insert(index, line);
		}

		/// <summary>
		/// Gets a section or adds it if it doesn't exist.
		/// </summary>
		/// <param name="sectionName">Name of the section.</param>
		/// <returns>The section.</returns>
		private Section GetOrAddSection(string sectionName)
		{
			if (_sections.ContainsKey(sectionName)) {
				return _sections[sectionName];
			} else {
				Section section = new Section(sectionName);
				if (_lines.Count > 0 && !String.IsNullOrWhiteSpace(_lines.Last()))
					_lines.Add(String.Empty);
				_lines.Add("[" + sectionName + "]");
				section.Lines.Add(_lines.Count - 1);

				return _sections[sectionName] = section;
			}
		}

		/// <summary>
		/// Gets a property or adds it if it doesn't exist.
		/// </summary>
		/// <param name="sectionName">Name of the section.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>The property.</returns>
		private Property GetOrAddProperty(string sectionName, string propertyName)
		{
			var dict = _sections[sectionName].Properties;
			if (!dict.ContainsKey(propertyName))
				return dict[propertyName] = new Property(propertyName);
			else
				return dict[propertyName];
		}

		/// <summary>
		/// Parses all the configuration lines.
		/// </summary>
		private void Parse()
		{
			string currentSectionName = String.Empty;
			for (int i = 0; i < _lines.Count; i++) {
				try {
					Parse(i, _lines[i], ref currentSectionName);
				} catch { }
			}
		}

		/// <summary>
		/// Parses a single configuration line.
		/// </summary>
		/// <param name="lineIndex">The index of the line.</param>
		/// <param name="line">The contents of the line.</param>
		/// <param name="currentSectionName">The name of the current section.</param>
		private void Parse(int lineIndex, string line, ref string currentSectionName)
		{
			char c;
			var reader = new StringReader(line);
			reader.SkipWhitespace();

			// First character
			if (!reader.TryRead(out c))
				return;

			if (c == '[') {
				// Read section name
				var sectionNameBuilder = new StringBuilder();
				while (reader.TryRead(out c) && c != ']') {
					sectionNameBuilder.Append(c);
				}
				if (c != ']')
					throw new Exception("Invalid section name");

				// Set and add section
				currentSectionName = sectionNameBuilder.ToString().Trim();
				Section section;
				if (!_sections.TryGetValue(currentSectionName, out section))
					_sections.Add(currentSectionName, section = new Section(currentSectionName));
				section.Lines.Add(lineIndex);
			} else if (c != ';' && c != '#') {
				// Read property name and value
				var propertyNameBuilder = new StringBuilder();
				propertyNameBuilder.Append(c);
				while (reader.TryRead(out c) && c != '=' && c != ':') {
					propertyNameBuilder.Append(c);
				}
				if (c != '=' && c != ':')
					throw new Exception("Expected = or : after property name");

				string propertyName = propertyNameBuilder.ToString().Trim();
				string value = ReadPropertyValue(reader);

				// Set or add property
				Property property = GetOrAddProperty(currentSectionName, propertyName);
				property.Value = value;
				property.Lines.Add(lineIndex);
			}
		}

		/// <summary>
		/// Reads a property value that supports quotes and escaping.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <returns>The property value as a string or null if there is no value.</returns>
		private string ReadPropertyValue(TextReader reader)
		{
			reader.SkipWhitespace();

			var result = new StringBuilder();
			bool singleQuotes = false;
			bool doubleQuotes = false;
			bool quoted = false;
			char c;

			// First character
			if (!reader.TryRead(out c))
				return null;
			;

			if (c == '\'')
				singleQuotes = quoted = true;
			else if (c == '"')
				doubleQuotes = quoted = true;
			else
				result.Append(c);

			// Next characters
			do {
				if (!reader.TryRead(out c))
					break;

				if (c == '\\') {
					// Not yet implemented in OpenRCT2
					// result.Append(ReadEscapedCharacter(reader));
					result.Append(c);
				} else if ((c == ';' || c == '#') && !quoted) {
					break;
				} else if (c == '\'' && singleQuotes) {
					singleQuotes = false;
					break;
				} else if (c == '"' && doubleQuotes) {
					doubleQuotes = false;
					break;
				} else {
					result.Append(c);
				}
			} while (true);

			if (singleQuotes || doubleQuotes)
				throw new Exception("No end quote(s)");

			if (!quoted)
				return result.ToString().TrimEnd();

			return result.ToString();
		}

		/// <summary>
		/// Read an escaped character e.g. "\n". Must be performed after the backslash has been read.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <returns>The escaped character.</returns>
		private char ReadEscapedCharacter(TextReader reader)
		{
			char c;
			if (!reader.TryRead(out c))
				throw new Exception("Expected escape character");

			switch (c) {
			case '0':
				return '\0';
			case 't':
				return '\t';
			case 'r':
				return '\r';
			case 'n':
				return '\n';
			case 'x':
				char[] hexCode = new char[4];
				if (reader.ReadBlock(hexCode, 0, 4) != 4)
					throw new Exception("Wrong format for escaped unicode character.");
				return (char)Int32.Parse(new string(hexCode), NumberStyles.AllowHexSpecifier);
			default:
				return c;
			}
		}
	}
}