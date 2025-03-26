// // Copyright (C) 2021-2024 Steffen Itterheim
// // Refer to included LICENSE file for terms and conditions.
//
// using System;
// using UnityEditor;
// using UnityEngine;
//
// namespace CodeSmile.Utility
// {
// 	/// <summary>
// 	///     Stores a transform in a ScriptableObject asset. This can be used, for instance, to remember transform changes
// 	///     in play mode and apply them back after exiting play mode.
// 	/// </summary>
// 	[CreateAssetMenu(fileName = "Transform Asset", menuName = "CodeSmile/Transform Asset", order = 0)]
// 	public sealed class TransformAsset : ScriptableObject
// 	{
// 		public Boolean InLocalSpace = true;
// 		public Vector3 Position = Vector3.zero;
// 		public Quaternion Rotation = Quaternion.identity;
// 		public Vector3 Scale = Vector3.one;
//
// 		public void AssignValuesTo(Transform target)
// 		{
// 			if (target != null)
// 			{
// 				if (InLocalSpace)
// 					target.SetLocalPositionAndRotation(Position, Rotation);
// 				else
// 					target.SetPositionAndRotation(Position, Rotation);
//
// 				target.localScale = Scale;
// 			}
// 		}
//
// 		public void ApplyValuesFrom(Transform source, Boolean inLocalSpace = true)
// 		{
// 			if (source != null)
// 			{
// 				InLocalSpace = inLocalSpace;
// 				Position = inLocalSpace ? source.localPosition : source.position;
// 				Rotation = inLocalSpace ? source.localRotation : source.rotation;
// 				Scale = source.localScale;
// 			}
// 		}
// 	}
// }
