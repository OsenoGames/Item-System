using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OsenoGames.ItemSystem
{

	public class ISQualityDatabase : ScriptableObject
	{
		//[SerializeField]
		public List<ISQuality> dataBase = new List<ISQuality>();
	}
}