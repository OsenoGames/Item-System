using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		void BottomStatusBar()
		{
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			GUILayout.Label("Bottom Status Bar");
			GUILayout.EndHorizontal();
		}
	}
}
