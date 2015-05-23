using UnityEngine;
using System.Collections;

namespace OsenoGames.ItemSystem
{
	public interface IISObject 
	{

		string Name {get; set;}
		int Value {get; set;}
		Sprite Icon {get; set;}
		int Burden {get; set;}
		ISQuality Quality {get; set;}



		//these go to other interfaces
		//equip
		//questItem flag
	}
}