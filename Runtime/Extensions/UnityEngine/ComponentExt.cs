// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using UnityEditor;
using UnityEngine;

namespace CodeSmile.Extensions.UnityEngine
{
	public static class ComponentExt
	{
		public static T GetOrAddComponent<T>(this Component component) where T : Component =>
			component.TryGetComponent(out T result) ? result : component.gameObject.AddComponent<T>();

		public static void TryAddComponent<T>(this Component component) where T : Component
		{
			if (component.TryGetComponent(out T _) == false)
				component.gameObject.AddComponent<T>();
		}

		public static void DestroyAllChildren(this Component component) => component.gameObject.DestroyAllChildren();
	}
}
