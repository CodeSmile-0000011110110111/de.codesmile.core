// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using CodeSmile.Extensions.System;
using System;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace CodeSmileEditor.Core
{
	public static class AssetUtility
	{
		private static Assembly[] s_Assemblies;
		private static readonly Int32 s_DllStringLength = ".dll".Length;

		public static Boolean IsEditorPath(String assetPath) => assetPath.ToLower().Contains("/editor/");

		public static Boolean IsEditorAssembly(String assetPath)
		{
			var assemblyName = CompilationPipeline.GetAssemblyNameFromScriptPath(assetPath);
			if (assemblyName != null && assemblyName.Length > s_DllStringLength)
			{
				// strip ".dll" from name
				assemblyName = assemblyName.Substring(0, assemblyName.Length - s_DllStringLength);

				foreach (var assembly in s_Assemblies)
				{
					if ((assembly.flags & AssemblyFlags.EditorAssembly) != 0 && assemblyName.Equals(assembly.name))
						return true;
				}
			}

			return false;
		}

		[InitializeOnLoadMethod]
		private static void OnLoad() => s_Assemblies = CompilationPipeline.GetAssemblies();
	}
}
