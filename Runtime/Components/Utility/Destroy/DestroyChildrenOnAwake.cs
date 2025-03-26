// Copyright (C) 2021-2024 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using CodeSmile.Extensions.UnityEngine;
using UnityEditor;
using UnityEngine;

namespace CodeSmile.Components.Utility.Destroy
{
	[DisallowMultipleComponent]
	public sealed class DestroyChildrenOnAwake : MonoBehaviour
	{
		private void Awake()
		{
			transform.DestroyAllChildren();
			Destroy(this);
		}
	}
}
