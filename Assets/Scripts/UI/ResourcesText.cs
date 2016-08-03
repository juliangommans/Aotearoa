using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcesText : MonoBehaviour {

	GameObject currentPlayer;
	GameObject currentStructure;
	NewPlayer playerData;
	int roundCount;

	void Awake(){
		currentStructure = GameObject.Find ("GameManager").GetComponent<ObjectPlacer> ().currentStructure;
		currentPlayer = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer;
		roundCount = GameObject.Find ("GameManager").GetComponent<RoundManager> ().roundCount;
	}

	void LateUpdate () {

		currentStructure = GameObject.Find ("GameManager").GetComponent<ObjectPlacer> ().currentStructure;
		currentPlayer = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer;
		roundCount = GameObject.Find ("GameManager").GetComponent<RoundManager> ().roundCount;

		if (currentPlayer != null) {
			
			playerData = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer.GetComponent<NewPlayer> ();

			GameObject.Find ("PlayerName").GetComponent<Text> ().text = playerData.data.PlayerName;
			GameObject.Find ("PlayerPanel").GetComponent<Image> ().color = playerData.data.PlayerColor;

			playerData.CreateScore ();
			GameObject.Find ("ScorePoints").GetComponent<Text> ().text = "" + playerData.data.Score;

			GameObject.Find ("KumaraCount").GetComponent<Text> ().text = "" + playerData.data.Kumara;
			GameObject.Find ("KauriCount").GetComponent<Text> ().text = "" + playerData.data.Kauri;
			GameObject.Find ("PounamuCount").GetComponent<Text> ().text = "" + playerData.data.Pounamu;
			GameObject.Find ("MoaCount").GetComponent<Text> ().text = "" + playerData.data.Moa;
			GameObject.Find ("FlaxCount").GetComponent<Text> ().text = "" + playerData.data.Flax;

			GameObject.Find ("RoundCount").GetComponent<Text> ().text = "" + roundCount;

			if (currentPlayer.GetComponent<NewPlayer>().StartingPhase()) {
				if (currentPlayer.GetComponent<NewPlayer>().data.StartingCamps > 0) {
					GameObject.Find ("PlayerMessage").GetComponent<Text> ().text = "Starting Camps: " + currentPlayer.GetComponent<NewPlayer>().data.StartingCamps;
				} else if (currentPlayer.GetComponent<NewPlayer>().data.StartingRoads >= 0) {
					GameObject.Find ("PlayerMessage").GetComponent<Text> ().text = "Starting Roads: " + currentPlayer.GetComponent<NewPlayer>().data.StartingRoads;
				} 
			}
		}
	}
}
