// Copyright (C) 2021-2024 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using UnityEditor;
using UnityEngine;

namespace CodeSmile.Components.Utility.Destroy
{
	[RequireComponent(typeof(ParticleSystem))]
	internal sealed class DestroyParticleSystemAfterDuration : MonoBehaviour
	{
		private void OnEnable()
		{
			var psMain = GetComponent<ParticleSystem>().main;
			Destroy(gameObject, psMain.duration + psMain.startDelay.constant);
		}
	}
}
