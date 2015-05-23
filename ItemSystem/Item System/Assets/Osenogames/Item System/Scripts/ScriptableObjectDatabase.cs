using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace OsenoGames
{

	public class ScriptableObjectDatabase<T> : ScriptableObject where T: class
	{
		[SerializeField] 
		List<T> dataBase = new List<T>();

		public void Add(T item)
		{
			dataBase.Add(item);
			EditorUtility.SetDirty(this);
		}
		
		public void Insert(int index, T item)
		{
			dataBase.Insert(index, item);
			EditorUtility.SetDirty(this);
		}
		
		public void Remove(T item)
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
		
		public T Get(int index)
		{
			return dataBase.ElementAt(index);
		}
		
		public void Replace(int index, T item)
		{
			dataBase[index] = item;
			EditorUtility.SetDirty(this);
		}



		public U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
		{
			string dbFullPath = @"Assets/"+dbPath+"/"+dbName;

			U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;
			
			if(db == null)
			{
				//check if the folder exists
				if(!AssetDatabase.IsValidFolder("Assets/"+dbPath))
					AssetDatabase.CreateFolder("Assets", dbPath);

				//create the database and refresh the AssetDatabase

				db = ScriptableObject.CreateInstance<U>() as U;
				AssetDatabase.CreateAsset(db,dbFullPath);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}
			return db;
		}
	}
}