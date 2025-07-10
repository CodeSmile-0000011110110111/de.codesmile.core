// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using CodeSmile;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CodeSmileEditor
{
	public static class EditorIO
	{
		public static void TryCreateAndImportPath(String assetPath)
		{
			var fullPath = Path.GetFullPath($"{Application.dataPath}/../{assetPath}");
			if (Directory.Exists(fullPath) == false)
			{
				Directory.CreateDirectory(fullPath);
				AssetDatabase.ImportAsset(assetPath);
			}
		}

		public static String GetFullPathFromAssetPath(String assetPath) =>
			Path.GetFullPath($"{Application.dataPath}/../{assetPath}").ToForwardSlashes();
	}
}
