using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectPa : MonoBehaviour {

	GameObject currentPlayer;
	GameObject gameManager;
	PaLogic paLogic;

	void Start (){
		gameManager = GameObject.Find ("GameManager");
		paLogic = GetComponent<PaLogic> ();
	}

	void Update () {
		currentPlayer = gameManager.GetComponent<RoundManager> ().currentPlayer;
	}

	public void PaPlacement(){
		gameManager.GetComponent<ObjectPlacer> ().currentState = ObjectPlacer.StructureState.PA;
	}
}
