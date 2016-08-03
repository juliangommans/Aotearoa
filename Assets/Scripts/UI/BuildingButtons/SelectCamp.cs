using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectCamp : MonoBehaviour {

	GameObject currentPlayer;
	GameObject gameManager;
	CampLogic campLogic;

	void Start (){
		gameManager = GameObject.Find ("GameManager");
		campLogic = GetComponent<CampLogic> ();
	}

	void Update () {
		currentPlayer = gameManager.GetComponent<RoundManager> ().currentPlayer;
	}

	public void CampPlacement(){
//		if (GetComponent<CampLogic> ().cost.CanAfford (currentPlayer)) {
		gameManager.GetComponent<ObjectPlacer> ().currentState = ObjectPlacer.StructureState.CAMP;
//		} else {
//			Debug.Log ("YOURE BROKE CAMP");
//			// NEED MORE OBVIOUS DISPLAY OF INACCESS TO STRUCTURE
//		}
	}
}
