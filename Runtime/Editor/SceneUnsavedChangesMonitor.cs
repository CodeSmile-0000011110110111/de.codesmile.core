// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace CodeSmileEditor.Editor
{
	public class SceneUnsavedChangesMonitor : EditorWindow
	{
		private Label m_Label;
		private Scene m_ActiveScene;
		private Boolean m_IsActiveSceneDirty;

		[MenuItem("Tools/Scene Unsaved Changes Monitor")]
		private static void ShowWindow()
		{
			var window = GetWindow<SceneUnsavedChangesMonitor>();
			window.titleContent = new GUIContent("Scene Unsaved Changes Monitor");
			window.Show();
		}

		private void CreateGUI()
		{
			m_Label = new Label();
			m_Label.style.color = Color.black;
			rootVisualElement.Add(m_Label);

			var activeScene = EditorSceneManager.GetActiveScene();
			UpdateLabel(activeScene.IsValid() && activeScene.isDirty);
		}

		private void Update()
		{
			var activeScene = EditorSceneManager.GetActiveScene();
			if (activeScene != m_ActiveScene)
			{
				m_ActiveScene = activeScene;
				m_IsActiveSceneDirty = activeScene.IsValid() && activeScene.isDirty;
				UpdateLabel(m_IsActiveSceneDirty);
			}

			if (activeScene.IsValid() && activeScene.isDirty != m_IsActiveSceneDirty)
			{
				m_IsActiveSceneDirty = activeScene.isDirty;
				UpdateLabel(m_IsActiveSceneDirty);
			}
		}

		private void UpdateLabel(Boolean isDirty)
		{
			if (isDirty)
			{
				m_Label.style.backgroundColor = Color.red;
				m_Label.text = "Scene has unsaved changes!";
			}
			else
			{
				m_Label.style.backgroundColor = Color.green;
				m_Label.text = "Scene is saved.";
			}
		}
	}
}
