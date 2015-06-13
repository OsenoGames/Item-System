using UnityEngine;
using UnityEditor;
using System.Collections;

namespace OsenoGames.ItemSystem
{
	[System.Serializable]
	public class ISObject : IISObject 
	{
		[SerializeField]string _name;
		[SerializeField]Sprite  _icon;
		[SerializeField]int _value;
		[SerializeField]int _burden;
		[SerializeField]ISQuality _quality;

		public string Name 
		{
			get {return _name;}
			set {_name = value;}
		}

		public int Value 
		{
			get {return _value;}
			set {_value = value;}
		}

		public Sprite Icon 
		{
			get {return _icon;}
			set {_icon = value;}
		}

		public int Burden 
		{
			get {return _burden;}
			set {_burden = value;}
		}

		public ISQuality Quality 
		{
			get {return _quality;}
			set {_quality = value;}
		}

		ISQualityDatabase qdb;
		int qualitySelectedIndex = 0;
		string[] option;

		public virtual void OnGUI()	
		{
			GUILayout.BeginVertical();
			_name = EditorGUILayout.TextField("Name: ", _name);
			_value = System.Convert.ToInt32(EditorGUILayout.TextField("Value", _value.ToString()));
			_burden = System.Convert.ToInt32(EditorGUILayout.TextField("Burden", _burden.ToString()));
			DisplayIcon();
			DisplayQuality();
			GUILayout.EndVertical();
		}

		public void DisplayIcon()
		{
			GUILayout.Label("Icon");
		}

		public int SelectedQualityID
		{
			get{return qualitySelectedIndex;}
		}

		public ISObject()
		{
			string DATABASE_NAME = @"OsenoQualityDatabase.asset";
			string DATABASE_PATH = @"Database";
			qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
			option = new string[qdb.Count];
			for(int cnt = 0; cnt < qdb.Count; cnt++)
				option[cnt] = qdb.Get(cnt).Name;

		}

		public void DisplayQuality()
		{
			EditorGUILayout.Popup("Quality",qualitySelectedIndex,option);
			_quality = qdb.Get(SelectedQualityID);

		}
	}
}
