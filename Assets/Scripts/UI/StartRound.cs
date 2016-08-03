using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartRound : MonoBehaviour {

	public GameObject basePlayer;
	Color playerColor;
	Vector3 baseLocation;

	GameObject player1;
	GameObject player2;
	GameObject player3;
	GameObject player4;

	GameObject[] playerList;
	bool threePlayers;
	bool fourPlayers;

	RoundManager roundManager;

	void Awake(){
		roundManager = GameObject.Find ("GameManager").GetComponent<RoundManager> ();
		baseLocation = new Vector3 (1000f, 1000f, this.transform.position.z);
		BuildPlayers ();

	}

	public void StartGame(){
		AssignAttributes ();
		BuildPlayerArray ();
		roundManager.CreatePlayers (playerList);
		roundManager.currentState = RoundManager.GameState.PLAYER1;

		GameObject.Find ("ScoreTotal").GetComponent<Text> ().text = "/ " + GameObject.Find ("GameManager").GetComponent<GameManager> ().totalScore; 
		GameObject.Find ("SetupGame").SetActive (false);
		GameObject.Find ("Undo").SetActive (false);
	}

	void BuildPlayers(){
		player1 = Instantiate (basePlayer, baseLocation, this.transform.rotation) as GameObject;
		player2 = Instantiate (basePlayer, baseLocation, this.transform.rotation) as GameObject;
		player3 = Instantiate (basePlayer, baseLocation, this.transform.rotation) as GameObject;
		player4 = Instantiate (basePlayer, baseLocation, this.transform.rotation) as GameObject;
	}

	void AssignAttributes(){
		player1.GetComponent<NewPlayer> ().data.PlayerName = GameObject.Find("Player1Text").GetComponent<InputField>().text;
		player1.GetComponent<NewPlayer> ().data.PlayerColor = GetColor(GameObject.Find("Player1Color"));;

		player2.GetComponent<NewPlayer> ().data.PlayerName = GameObject.Find("Player2Text").GetComponent<InputField>().text;
		player2.GetComponent<NewPlayer> ().data.PlayerColor = GetColor(GameObject.Find("Player2Color"));; 

		player3.GetComponent<NewPlayer> ().data.PlayerName = GameObject.Find("Player3Text").GetComponent<InputField>().text;
		player3.GetComponent<NewPlayer> ().data.PlayerColor = GetColor(GameObject.Find("Player3Color"));;

		player4.GetComponent<NewPlayer> ().data.PlayerName = GameObject.Find("Player4Text").GetComponent<InputField>().text;
		player4.GetComponent<NewPlayer> ().data.PlayerColor = GetColor(GameObject.Find("Player4Color"));;
	}

	Color GetColor(GameObject selection){
		switch(selection.GetComponent<Dropdown>().value){
		case(0):
			return Color.magenta;
		case(1):
			return Color.blue;
		case(2):
			return Color.cyan;
		case(3):
			return Color.yellow;
		default:
			return Color.white;
		}
	}

	void BuildPlayerArray(){
		//Game Setup - minimum of 2 players
		int playerCount = 2;

		//Game Setup - checking if players 3 and/or 4 have been selected
		if (GameObject.Find ("Player3ControllerSelect").GetComponent<Dropdown> ().value != 0) {
			playerCount++;
			threePlayers = true;
		}
		if (GameObject.Find ("Player4ControllerSelect").GetComponent<Dropdown> ().value != 0) {
			playerCount++;
			fourPlayers = true;

		}

		//Game Setup - adding players to the list
		playerList = new GameObject[playerCount];

		playerList [0] = player1;
		playerList [1] = player2;
		if (threePlayers)
			playerList [2] = player3;
		if (fourPlayers && !threePlayers)
			playerList [2] = player4;
		else if (fourPlayers)
			playerList [3] = player4;
	}
}
