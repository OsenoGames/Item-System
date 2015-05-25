using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem.Editor
{
	public partial class ISObjectEditor 
	{
		void ItemDetails()
		{
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.Label("Detial View");
			GUILayout.EndHorizontal();
		}
	}
}
