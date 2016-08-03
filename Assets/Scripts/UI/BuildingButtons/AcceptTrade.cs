using UnityEngine;
using System.Collections;

public class AcceptTrade : MonoBehaviour {

	public void Trade(){
		GameObject.Find ("TradeButton").GetComponent<TradeLogic> ().AcceptTrade ();
	}
}
