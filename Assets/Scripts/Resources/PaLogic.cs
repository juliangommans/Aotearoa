using UnityEngine;
using System.Collections;

public class PaLogic : MonoBehaviour {

	public BaseCosts cost;

	void Start(){
		cost = new BaseCosts ();
		cost.Multiplier = 2;
		cost.KumaraCost = 5;
		cost.FlaxCost = 2;
		cost.KauriCost = 3;
		cost.MoaCost = 2;
		cost.PounamuCost = 2;
	}

}
