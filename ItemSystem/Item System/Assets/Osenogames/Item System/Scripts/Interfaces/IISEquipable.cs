using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem
{

	public interface IISEquipable 
	{
		ISEquipmentSlot EquipmentSlot{get;}
		bool Equip();

	}
}