﻿// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Compilation;
#endif
using System;
using System.IO;
using UnityEngine;
using Assembly = System.Reflection.Assembly;
using Object = UnityEngine.Object;

namespace CodeSmile
{
	public static class EditorAssetUtility
	{
		/// <summary>
		/// Editor-only: Imports the asset, ie to pick up latest changes without forcing an entire Refresh().
		/// </summary>
		/// <param name="asset"></param>
		public static void Import(Object asset)
		{
#if UNITY_EDITOR
			if (asset != null)
				AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(asset));
#endif
		}

		public static void Import(String assetPath)
		{
#if UNITY_EDITOR
			if (assetPath != null)
				AssetDatabase.ImportAsset(assetPath);
#endif
		}

		public static Assembly GetAssemblyForAssetPath(String assetPath)
		{
			Assembly assembly = null;

#if UNITY_EDITOR
			try
			{
				var assemblyName = CompilationPipeline.GetAssemblyNameFromScriptPath(assetPath);
				if (assemblyName != null)
					assembly = Assembly.Load(Path.GetFileNameWithoutExtension(assemblyName));
			}
			catch (Exception) {} // suppress errors
#endif

			return assembly;
		}
	}
}
