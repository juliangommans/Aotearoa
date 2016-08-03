using UnityEngine;
using System.Collections;

public class SelectTrade : MonoBehaviour {

	public void TradeResources(){
		GameObject.Find ("GameManager").GetComponent<ObjectPlacer>().currentState = ObjectPlacer.StructureState.TRADE;
	}
}
