using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour {

	RoundManager roundManager;
	GameObject undoButton;

	void Start(){
		roundManager = GameObject.Find ("GameManager").GetComponent<RoundManager> ();
		undoButton = GameObject.Find ("Undo");
	}

	public void EndCurrentTurn(){
		if (roundManager.currentState == RoundManager.GameState.PLAYER1) {
			roundManager.collectResources = true;
			roundManager.currentState = RoundManager.GameState.PLAYER2;
		}else if (roundManager.currentState == RoundManager.GameState.PLAYER2) {
			if (roundManager.players.Length > 2) {
				roundManager.collectResources = true;
				roundManager.currentState = RoundManager.GameState.PLAYER3;
			} else {
				FinalTurn ();
			}
		}else if (roundManager.currentState == RoundManager.GameState.PLAYER3) {
			if (roundManager.players.Length > 3) {
				roundManager.collectResources = true;
				roundManager.currentState = RoundManager.GameState.PLAYER4;
			} else {
				FinalTurn ();
			}
		}else if (roundManager.currentState == RoundManager.GameState.PLAYER4) {

			FinalTurn ();
		}
		// Stops next player from being able to place whatever the last selected structure was
		GameObject.Find ("GameManager").GetComponent<ObjectPlacer> ().currentState = ObjectPlacer.StructureState.EMPTY;
		undoButton.SetActive (false);
	}

	// This is called at various steps depending on the # of players
	void FinalTurn(){
		roundManager.collectResources = true;
		roundManager.currentState = RoundManager.GameState.PLAYER1;
		roundManager.roundCount++;

	}
}
