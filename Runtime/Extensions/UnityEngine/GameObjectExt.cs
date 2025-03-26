// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using UnityEditor;
using UnityEngine;

namespace CodeSmile.Extensions.UnityEngine
{
	public static class GameObjectExt
	{
		public static T GetOrAddComponent<T>(this GameObject go) where T : Component =>
			go.TryGetComponent(out T result) ? result : go.AddComponent<T>();

		public static Component GetOrAddComponent(this GameObject go, Type componentType) =>
			go.TryGetComponent(componentType, out var result) ? result : go.AddComponent(componentType);

		public static void TryAddComponent<T>(this GameObject gameObject) where T : Component
		{
			if (gameObject.TryGetComponent(out T _) == false)
				gameObject.AddComponent<T>();
		}

		public static void DestroyAllChildren(this GameObject go) => go.transform.DestroyAllChildren();
	}
}
