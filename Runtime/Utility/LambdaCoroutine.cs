// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace CodeSmile.Utility
{
	public static class LambdaCoroutine
	{
		public static IEnumerator InvokeNextFrame(Action action)
		{
			yield return null;

			action?.Invoke();
		}

		public static IEnumerator InvokeEndOfFrame(Action action)
		{
			yield return new WaitForEndOfFrame();

			action?.Invoke();
		}
	}
}
