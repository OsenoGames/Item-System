using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem
{
	public interface IISEquipable 
	{
		//public EquipmentSlot equipmentSlot;
		ISEquipmentSlot EquipmentSlot{get;}
		bool Equip();
	}
}