using UnityEditor;
using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem.Editor
{
	public partial class ISObjectEditor : EditorWindow 
	{

		[MenuItem("Oseno/Database/Item System Editor %#i")]
		public static void Init()
		{
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
			window.minSize = new Vector2(800, 600);
			window.title = "Item System";
			window.Show();
		}
		void OnEable ()
		{

		}

		void OnGUI()
		{
			TopTabBar();
			GUILayout.BeginHorizontal();
			ListView();
			ItemDetails();
			GUILayout.EndHorizontal();
			BottomStatusBar();
		}
	}
}