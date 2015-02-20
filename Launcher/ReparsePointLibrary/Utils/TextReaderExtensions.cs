using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HelperLibrary
{
	public static class TextReaderExtensions
	{
		/// <summary>
		/// Reads the next character from the text reader without changing the state of the reader. A return value indicates
		/// whether it was successful or not.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <param name="c">The character read.</param>
		/// <returns>True if a character was read successfully, otherwise false.</returns>
		public static bool TryPeek(this TextReader reader, out char c)
		{
			int result = reader.Peek();
			if (result == -1) {
				c = Char.MinValue;
				return false;
			} else {
				c = (char)result;
				return true;
			}
		}

		/// <summary>
		/// Reads the next character from the text reader. A return value indicates whether it was sucessful or not.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <param name="c">The character read.</param>
		/// <returns>True if a character was read sucessfully, otherwise false.</returns>
		public static bool TryRead(this TextReader reader, out char c)
		{
			int result = reader.Read();
			if (result == -1) {
				c = Char.MinValue;
				return false;
			} else {
				c = (char)result;
				return true;
			}
		}

		/// <summary>
		/// Continues to read characters until a whitespace character is read or no more characters can be read. The whitespace
		/// character is not included in the return string and is only peeked.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <returns>A string repesenting all the characters before the first encountered whitespace character or no more
		/// characters could be read.</returns>
		public static string ReadToWhitespace(this TextReader reader)
		{
			var sb = new StringBuilder();

			char c;
			while (reader.TryPeek(out c) && !Char.IsWhiteSpace(c)) {
				reader.Read();
				sb.Append(c);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Repeatedly reads characters which are whitespace until it reaches a non-whitespace character or no more characters
		/// could be read.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		public static void SkipWhitespace(this TextReader reader)
		{
			char c;
			while (reader.TryPeek(out c) && Char.IsWhiteSpace(c)) {
				reader.Read();
			}
		}

		/// <summary>
		/// Continues to read characters until the string that has been read so far does no longer match a regular expression.
		/// All the characters that were read that did match the regular expression are returned.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <param name="regex">
		/// The regular expression to match the read string against. This should allow strings that could
		/// potentially still be valid if there are more characters. This is more useful for stopping when an invalid character
		/// is reached etc.
		/// </param>
		/// <returns>The read string that matches the regular expression.</returns>
		public static string ReadRegex(this TextReader reader, string regex)
		{
			return ReadRegex(reader, new Regex(regex));
		}

		/// <summary>
		/// Continues to read characters until the string that has been read so far does no longer match a regular expression.
		/// All the characters that were read that did match the regular expression are returned.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <param name="regex">
		/// The regular expression to match the read string against. This should allow strings that could
		/// potentially still be valid if there are more characters. This is more useful for stopping when an invalid character
		/// is reached etc.
		/// </param>
		/// <returns>The read string that matches the regular expression.</returns>
		public static string ReadRegex(this TextReader reader, Regex regex)
		{
			var sb = new StringBuilder();
			char c;
			while (reader.TryPeek(out c)) {
				sb.Append(c);

				string currentText = sb.ToString();
				if (!regex.IsMatch(currentText))
					return currentText.Remove(currentText.Length - 1);

				reader.Read();
			}

			return sb.ToString();
		}

		/// <summary>
		/// Checks if any more characters can be read.
		/// </summary>
		/// <param name="reader">The text reader.</param>
		/// <returns>True if another character can be read, otherwise false.</returns>
		public static bool CanRead(this TextReader reader)
		{
			return (reader.Peek() != -1);
		}
	}
}
