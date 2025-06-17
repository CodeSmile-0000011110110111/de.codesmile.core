// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using CodeSmile;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CodeSmileEditor.Core
{
	public static class EditorIO
	{
		public static void TryCreateDirectory(String assetPath)
		{
			var generatedFullPath = Path.GetFullPath($"{Application.dataPath}/../{assetPath}");
			if (!Directory.Exists(generatedFullPath))
			{
				Directory.CreateDirectory(generatedFullPath);
				AssetDatabase.ImportAsset(assetPath);
			}
		}

		public static String GetFullPathFromAssetPath(String assetPath) =>
			Path.GetFullPath($"{Application.dataPath}/../{assetPath}").ToForwardSlashes();
	}
}
