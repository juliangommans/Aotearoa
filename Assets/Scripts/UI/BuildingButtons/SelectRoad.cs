using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectRoad : MonoBehaviour {

	GameObject currentPlayer;
	GameObject gameManager;
	RoadLogic roadLogic;

	void Start (){
		gameManager = GameObject.Find ("GameManager");
		roadLogic = GetComponent<RoadLogic> ();
	}

	void Update () {
		currentPlayer = gameManager.GetComponent<RoundManager> ().currentPlayer;
	}

	public void RoadPlacement(){
//		if (GetComponent<RoadLogic> ().cost.CanAfford (currentPlayer)) {
		gameManager.GetComponent<ObjectPlacer> ().currentState = ObjectPlacer.StructureState.ROAD;
//		} else {
//			Debug.Log ("YOURE BROKE roadz");
//		}
	}
}
