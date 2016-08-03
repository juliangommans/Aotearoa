using UnityEngine;
using System.Collections;

public class RoadLogic : MonoBehaviour {
	
	public BaseCosts cost;

	void Start(){
		cost = new BaseCosts ();
		cost.FlaxCost = 1;
		cost.KumaraCost = 2;
	}
}
