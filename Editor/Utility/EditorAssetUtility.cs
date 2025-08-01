﻿// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using CompilationAssembly = UnityEditor.Compilation.Assembly;
using Object = UnityEngine.Object;

namespace CodeSmileEditor
{
	public static class EditorAssetUtility
	{
		private static CompilationAssembly[] s_Assemblies;
		private static readonly Int32 s_DllStringLength = ".dll".Length;

		/// <summary>
		/// Test if the path points to a Lua script (.lua extension).
		/// </summary>
		/// <param name="assetPath"></param>
		/// <returns></returns>
		public static Boolean IsLuaScript(String assetPath) => Path.GetExtension(assetPath) == ".lua";

		/// <summary>
		/// Test if the path is in an "Editor" folder, or a child thereof.
		/// </summary>
		/// <param name="assetPath"></param>
		/// <returns></returns>
		public static Boolean IsEditorPath(String assetPath) => assetPath.ToLower().Contains("/editor/");

		/// <summary>
		/// Test if the path is in a "Modding" folder, or a child thereof.
		/// </summary>
		/// <param name="assetPath"></param>
		/// <returns></returns>
		public static Boolean IsModdingPath(String assetPath) => assetPath.ToLower().Contains("/modding/");

		/// <summary>
		/// Test if the current path is within an editor assembly definition. Does not check for "Editor" folders.
		/// </summary>
		/// <param name="assetPath"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Re-Imports the asset. Useful if auto-refresh is disabled and you want to pick up latest changes
		/// without forcing an entire Refresh().
		/// </summary>
		/// <param name="asset"></param>
		public static void Import(Object asset)
		{
			if (asset != null)
				AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(asset));
		}

		[InitializeOnLoadMethod]
		private static void OnLoad() => s_Assemblies = CompilationPipeline.GetAssemblies();
	}
}
