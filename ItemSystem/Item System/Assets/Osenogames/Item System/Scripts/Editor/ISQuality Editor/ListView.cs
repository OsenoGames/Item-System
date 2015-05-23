using UnityEngine;
using UnityEditor;
using System.Collections;

namespace OsenoGames.ItemSystem.Editor
{
	public partial class ISQualityDatabaseEditor
	{


		void ListView()
		{
			_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));

			DisplayQualities();

			EditorGUILayout.EndScrollView();

		}

		void DisplayQualities()
		{
			for(int cnt = 0; cnt < qualityDatabase.Count; cnt++)
			{
				GUILayout.BeginHorizontal("Box");
				if(qualityDatabase.Get(cnt).Icon)
					selectedTexture = qualityDatabase.Get(cnt).Icon.texture;
				else
					selectedTexture = null;

				if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
				{
					int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
					EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlerID);
					selectedIndex = cnt;
				}
				string commandName = Event.current.commandName;
				if(commandName == "ObjectSelectorUpdated")
				{
					if(selectedIndex != -1)
					{
						qualityDatabase.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
						Repaint();
					}
				}

				GUILayout.BeginVertical();
				qualityDatabase.Get(cnt).Name = GUILayout.TextField(qualityDatabase.Get(cnt).Name);
				if(GUILayout.Button("x",GUILayout.Width(30), GUILayout.Height(25)))
				{
					if(EditorUtility.DisplayDialog("Delete Quality", "Are you sure you want to Delete " + qualityDatabase.Get(cnt).Name + " from the database","Delete","Cancel"))
						qualityDatabase.Remove(cnt);

				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}
		}
	}
}