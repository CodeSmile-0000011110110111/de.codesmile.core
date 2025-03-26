// Copyright (C) 2021-2024 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using UnityEditor;
using UnityEngine;

namespace CodeSmile.Components.Pool
{
	[DisallowMultipleComponent]
	public sealed class ReleasePooledObjectOnDisable : MonoBehaviour
	{
		public PrefabInstancePool Pool { get; set; }

		private void OnDisable() => Pool?.ReleaseInstance(gameObject);
	}
}
