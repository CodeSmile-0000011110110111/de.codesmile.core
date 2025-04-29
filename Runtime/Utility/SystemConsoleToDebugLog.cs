// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace CodeSmile.Utility
{
	public static class SystemConsoleToDebugLog
	{
		private static TextWriter m_ConsoleWriter;

		public static void Activate()
		{
			if (m_ConsoleWriter == null)
			{
				m_ConsoleWriter = Console.Out;
				Console.SetOut(new DebugLogWriter());
			}
		}

		public static void Deactivate()
		{
			if (m_ConsoleWriter != null)
			{
				Console.SetOut(m_ConsoleWriter);
				m_ConsoleWriter = null;
			}
		}

		[InitializeOnLoadMethod]
		private static void OnLoad() => Activate();

		private class DebugLogWriter : TextWriter
		{
			private readonly StringBuilder m_StringBuilder = new();
			public override Encoding Encoding => Encoding.Default;

			public override void Write(String text)
			{
				lock (m_StringBuilder)
					m_StringBuilder.Append(text);

				if (text != null && text.Length > 0 && text[text.Length - 1] == '\n')
					Flush();
			}

			public override void Write(Char character)
			{
				lock (m_StringBuilder)
					m_StringBuilder.Append(character);

				if (character == '\n')
					Flush();
			}

			public override void Write(Char[] value, Int32 index, Int32 count) => Write(new String(value, index, count));

			public override void Flush()
			{
				String message;
				lock (m_StringBuilder)
				{
					m_StringBuilder.Insert(0, "> ");
					if (m_StringBuilder.Length > 0)
						m_StringBuilder.Length--; // ignore newline, Debug.Log adds its own

					message = m_StringBuilder.ToString();
					m_StringBuilder.Clear();
				}

				Debug.Log(message);
			}
		}
	}
}
