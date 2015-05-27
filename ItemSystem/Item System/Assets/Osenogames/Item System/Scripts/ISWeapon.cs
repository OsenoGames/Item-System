﻿using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem
{
	[System.Serializable]
	public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISEquipable, IISQameObject 
	{
		[SerializeField] int _minDamage;
		[SerializeField] int _durability;
		[SerializeField] int _maxDruability;
		[SerializeField] ISEquipmentSlot _equipmentSlot;
		[SerializeField] GameObject _prefab;

		public ISWeapon()
		{
			_equipmentSlot = new ISEquipmentSlot();
			_prefab = new GameObject();
		}

		public ISWeapon(int durability, int maxDurability, ISEquipmentSlot equipmentSlot, GameObject prefab)
		{
			_durability = durability;
			_maxDruability = maxDurability;
			_equipmentSlot = equipmentSlot;
			_prefab = prefab;
		}

		public int MinDamage 
		{
			get {return _minDamage;}
			set {_minDamage = value;}
		}

		public int Attack ()
		{
			throw new System.NotImplementedException ();
		}

		public int Durability
		{
			get {return _durability; }
		}

		public int MaxDurability
		{
			get{return _maxDruability;}
		}

		public void TakeDamage(int amount)
		{
			_durability -= amount;

			if(_durability < 0)
				_durability = 0;

			if(_durability==0)
				Brake();
		}

		public void Repair()
		{
			_maxDruability--;
			if(_maxDruability>0)
				_durability=_maxDruability;
		}

		public void Brake()
		{
			_durability = 0;
		}

		public ISEquipmentSlot EquipmentSlot
		{
			get{return _equipmentSlot;}
		}

		public bool Equip()
		{
			throw new System.NotImplementedException ();
		}

		public GameObject Prefab
		{
			get{return _prefab;}
		}
	}
}