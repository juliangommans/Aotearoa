using UnityEngine;
using System.Collections;

public class ChangeTradeResource : MonoBehaviour {

	public void ChangeResource(int selection){
		GameObject.Find ("TradeButton").GetComponent<TradeLogic> ().SetResource (selection);
	}
}
