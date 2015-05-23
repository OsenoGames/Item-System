using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace OsenoGames.ItemSystem
{

	public class ISQualityDatabase : ScriptableObject
	{
	//	[SerializeField]
		List<ISQuality> dataBase = new List<ISQuality>();
	
		public void Add(ISQuality item)
		{
			dataBase.Add(item);
			EditorUtility.SetDirty(this);
		}

		public void Insert(int index, ISQuality item)
		{
			dataBase.Insert(index, item);
			EditorUtility.SetDirty(this);
		}

		public void Remove(ISQuality item)
		{
			dataBase.Remove(item);
			EditorUtility.SetDirty(this);
		}

		public void Remove(int index)
		{
			dataBase.RemoveAt(index);
			EditorUtility.SetDirty(this);
		}

		public int Count
		{
			get{return dataBase.Count;}
		}

		public ISQuality Get(int index)
		{
			return dataBase.ElementAt(index);
		}

		public void Replace(int index, ISQuality item)
		{
			dataBase[index] = item;
			EditorUtility.SetDirty(this);
		}
	}
}