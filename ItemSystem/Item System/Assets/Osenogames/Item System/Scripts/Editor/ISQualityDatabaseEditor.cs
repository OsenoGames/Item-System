using UnityEngine;
using UnityEditor;
using System.Collections;

namespace OsenoGames.ItemSystem.Editor
{
	public class ISQualityDatabaseEditor : EditorWindow
	{
		ISQualityDatabase qualityDatabase;
		ISQuality selectedItem;
		Texture2D selectedTexture;

		const int SPRITE_BUTTON_SIZE = 92;
		const string DATABASE_FILE_NAME = @"OsenoQualityDatabase.asset";
		const string DATABASE_FOLDER_NAME = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/"+DATABASE_FOLDER_NAME+"/"+DATABASE_FILE_NAME;

		[MenuItem("Oseno/Database/Quality Editor %#i")]
		public static void Init()
		{
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
			window.minSize = new Vector2(400, 300);
			window.title = "Quality Database";
			window.Show();
		}

		void OnEnable()
		{
			qualityDatabase = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

			if(qualityDatabase == null)
			{
				if(!AssetDatabase.IsValidFolder("Assets/"+DATABASE_FOLDER_NAME))
					AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
				qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
				AssetDatabase.CreateAsset(qualityDatabase,DATABASE_FULL_PATH);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}
			selectedItem = new ISQuality();
		}
		void OnGUI()
		{
			AddQualityToDatabase();
		}

		void AddQualityToDatabase()
		{
			selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);
			if(selectedItem.Icon)
				selectedTexture = selectedItem.Icon.texture;
			else
				selectedTexture = null;

			if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
			{
				int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
				EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlerID);
			}
			string commandName = Event.current.commandName;
			if(commandName == "ObjectSelectorUpdated")
			{
				selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
				Repaint();
			}
			if(GUILayout.Button("Save"))
			{
				if(selectedItem==null)
					return;

				qualityDatabase.dataBase.Add(selectedItem);

				selectedItem = new ISQuality();

				ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
				window.Close();
			}

		}

	}
}