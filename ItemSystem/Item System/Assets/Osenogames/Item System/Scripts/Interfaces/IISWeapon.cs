using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem
{

	public interface IISWeapon 
	{
		int MinDamage {get; set;}
		int Attack();
	}
}