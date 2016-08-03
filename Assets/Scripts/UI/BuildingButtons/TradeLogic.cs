using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TradeLogic : MonoBehaviour {

	public GameObject tradePanel;
	int tradeBonus = 1;
	int tradeCount;
	int currentResourceCount;
	string currentResource;
	string tradedResource;
	public bool legitTrade;


	void Awake(){
		tradePanel = GameObject.Find ("TradePanel");
		tradePanel.SetActive (false);
	}

	public void SetupTrade(string resource, int roadCount){
		tradePanel.SetActive (true);
		tradedResource = resource;
		currentResource = null;
		GameObject.Find ("SelectedResource").GetComponent<TradeImage> ().SelectCorrectResource (resource);
		GameObject.Find ("YourResource").GetComponent<TradeImage> ().SelectCorrectResource (currentResource);
		GameObject.Find ("ResourceNotifier").GetComponent<Text> ().text = "";
		if (roadCount > 3) {
			tradeCount = 1;
		} else {
			tradeCount = 4 - roadCount;
		}
		GameObject.Find ("RoadCount").GetComponent<Text> ().text = "X" + tradeCount;
	// image display for resources
		// logic for the changing of resources
	}

	public void AcceptTrade(){
		if (legitTrade) {
			tradePanel.SetActive (false);
			TradePlayersResources ();
		} else {
			GameObject.Find ("ResourceNotifier").GetComponent<Text> ().text = "You need more " + currentResource + " to trade sorry.";
		}
		// deduct/add resources
	}

	public void SetResource(int selection){
		switch (selection) {
		case (0):
			Debug.Log ("YOU SELECTED NOTHING");
			currentResource = null;
			break;
		case (1): 
			currentResource = "Kumara";
			currentResourceCount = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer.GetComponent<NewPlayer> ().data.Kumara;
			break;
		case (2): 
			currentResource = "Flax";
			currentResourceCount = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer.GetComponent<NewPlayer> ().data.Flax;
			break;
		case (3): 
			currentResource = "Kauri";
			currentResourceCount = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer.GetComponent<NewPlayer> ().data.Kauri;
			break;
		case (4): 
			currentResource = "Pounamu";
			currentResourceCount = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer.GetComponent<NewPlayer> ().data.Pounamu;
			break;
		case (5): 
			currentResource = "Moa";
			currentResourceCount = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer.GetComponent<NewPlayer> ().data.Moa;
			break;
		}

		CheckPlayerResources ();
		GameObject.Find ("YourResource").GetComponent<TradeImage> ().SelectCorrectResource (currentResource);
	}

	void CheckPlayerResources(){
		if (currentResourceCount < tradeCount) {
			legitTrade = false;
		} else {
			legitTrade = true;
		}
		UpdateUIMessage ();
	}

	void UpdateUIMessage(){
		if (legitTrade) {
			GameObject.Find ("ResourceNotifier").GetComponent<Text> ().color = Color.green;
			GameObject.Find ("ResourceNotifier").GetComponent<Text> ().text = "You will lose " + tradeCount + " " + currentResource + " if you accept this trade";
		} else {
			GameObject.Find ("ResourceNotifier").GetComponent<Text> ().color = Color.red;
			GameObject.Find ("ResourceNotifier").GetComponent<Text> ().text = "You need at least " + tradeCount + " " + currentResource + " to trade";
		}
	}

	void TradePlayersResources(){
		NewPlayer currentPlayer = GameObject.Find ("GameManager").GetComponent<RoundManager> ().currentPlayer.GetComponent<NewPlayer> ();
		// Resources you are trading away
		switch (currentResource) {
		case ("Kumara"):
			currentPlayer.data.Kumara -= tradeCount;
			break;
		case ("Flax"):
			currentPlayer.data.Flax -= tradeCount;
			break;
		case ("Kauri"):
			currentPlayer.data.Kauri -= tradeCount;
			break;
		case ("Pounamu"):
			currentPlayer.data.Pounamu -= tradeCount;
			break;
		case ("Moa"):
			currentPlayer.data.Moa -= tradeCount;
			break;
		}
		// Resources you are gaining
		switch (tradedResource) {
		case ("Kumara"):
			currentPlayer.data.Kumara += tradeBonus;
			break;
		case ("Flax"):
			currentPlayer.data.Flax += tradeBonus;
			break;
		case ("Kauri"):
			currentPlayer.data.Kauri += tradeBonus;
			break;
		case ("Pounamu"):
			currentPlayer.data.Pounamu += tradeBonus;
			break;
		case ("Moa"):
			currentPlayer.data.Moa += tradeBonus;
			break;
		}
	}
}
