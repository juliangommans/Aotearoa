using UnityEngine;
using System.Collections;

public class CampLogic : MonoBehaviour {

	public BaseCosts cost;

	void Start(){
		cost = new BaseCosts ();
		cost.Multiplier = 1;
		cost.KauriCost = 2;
		cost.FlaxCost = 2;
		cost.KauriCost = 1;
		cost.KumaraCost = 3;
	}

}
