﻿// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeSmileEditor.Luny.Generator
{
	public class AssetCollection<T> where T : Object
	{
		private static Dictionary<String, T> m_Assets;

		public T this[String key] => m_Assets.TryGetValue(key, out var value) ? value : null;

		public AssetCollection()
		{
			if (m_Assets == null)
			{
				m_Assets = new Dictionary<String, T>();

				var assetGuids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");
				foreach (var assetGuid in assetGuids)
				{
					var path = AssetDatabase.GUIDToAssetPath(assetGuid);
					var asset = AssetDatabase.LoadAssetAtPath<T>(path);
					Debug.Assert(asset != null,
						$"asset load failed! Perhaps used after StartAssetEditing or during 'InitializeOnLoad'? Path: {path}");

					m_Assets.Add(asset.name, asset);
				}
			}
		}
	}

	public sealed class AssemblyDefinitionAssets : AssetCollection<AssemblyDefinitionAsset> {}
}
