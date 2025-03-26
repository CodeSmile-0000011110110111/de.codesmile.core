// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using UnityEditor;
using UnityEngine;

namespace CodeSmile.Extensions.System
{
	public static class StringExt
	{
		public static String ToForwardSlashes(this String str) => str.Replace('\\', '/');
	}
}
