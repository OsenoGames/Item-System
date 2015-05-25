using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		void TopTabBar()
		{
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			WeaponTab();
			ArmorTab();
			GUILayout.Button("Potions");
			About();
			GUILayout.EndHorizontal();

		}

		void WeaponTab()
		{
			GUILayout.Button("Weapon");
		}

		void ArmorTab()
		{
			GUILayout.Button("Armor");
		}

		void About()
		{
			GUILayout.Button("About");
		}
	}
}