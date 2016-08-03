using UnityEngine;
using System.Collections;

public class CancelTrade : MonoBehaviour {

	public void CloseTradeWindow(){
		GameObject.Find ("TradePanel").SetActive (false);
	}
}
