using UnityEngine;
using UnityEditor;
using System.Collections;

namespace OsenoGames.ItemSystem.Editor
{
	public partial class ISQualityDatabaseEditor : EditorWindow
	{
		ISQualityDatabase qualityDatabase;
		Texture2D selectedTexture;
		int selectedIndex = -1;  // index for the selected icon in scroll view
		Vector2 _scrollPos;      // scroll position for the list view

		const int SPRITE_BUTTON_SIZE = 46;
		const string DATABASE_NAME = @"OsenoQualityDatabase.asset";
		const string DATABASE_PATH = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/"+DATABASE_PATH+"/"+DATABASE_NAME;

		[MenuItem("Oseno/Database/Quality Editor %#w")]
		public static void Init()
		{
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
			window.minSize = new Vector2(400, 300);
			window.title = "Quality Database";
			window.Show();
		}

		void OnEnable()
		{
			qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
			qualityDatabase = qualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
		}
		void OnGUI()
		{
			if(qualityDatabase == null)
			{
				Debug.LogWarning("Quality database not loaded");
			}
			ListView();
			GUILayout.BeginHorizontal("box", GUILayout.ExpandWidth(true));
			BottomBar();
			GUILayout.EndHorizontal();
		}

		void BottomBar()
		{
			GUILayout.Label("Quanties: " + qualityDatabase.Count);
			if(GUILayout.Button("Add"))
			{
				qualityDatabase.Add(new ISQuality());
			}
		}
	//	void AddQualityToDatabase()
	//	{
	//		selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);
	//		if(selectedItem.Icon)
	//			selectedTexture = selectedItem.Icon.texture;
	//		else
	//			selectedTexture = null;
	//
	//		if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
	//		{
	//			int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
	//			EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlerID);
	//		}
	//		string commandName = Event.current.commandName;
	//		if(commandName == "ObjectSelectorUpdated")
	//		{
	//			selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
	//			Repaint();
	//		}
	//		if(GUILayout.Button("Save"))
	//		{
	//			if(selectedItem==null)
	//				return;
	//
	//			if(selectedItem.Name == "")
	//				return;
	//
	//
	//			qualityDatabase.Add(selectedItem);
	//			selectedItem = new ISQuality();
	//
	//			//ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
	//			//window.Close();
	//		}
	//
	//	}

	}
}