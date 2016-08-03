using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundManager : MonoBehaviour {

	public enum GameState {
		START,
		PLAYER1,
		PLAYER2,
		PLAYER3,
		PLAYER4,
		LOSE,
		WIN
	}

	public int roundCount;
	public bool endTurnSwitch = false;

	public bool collectResources = false;

	public GameState currentState;
	GameObject primaryPlayer;
	GameObject enemy;
	public GameObject currentPlayer;
	public GameObject[] players;
	Text playerMessage;

	void Awake () {
		roundCount = 0;
		currentPlayer = null;
		currentState = GameState.START;
		playerMessage = GameObject.Find ("PlayerMessage").GetComponent<Text> ();
	}
		
	void Update () {

		switch (currentState) {
		case(GameState.START):
			currentPlayer = null;
			break;
		case(GameState.PLAYER1):
			PlayerTurnActions (0,3);
			break;
		case(GameState.PLAYER2):
			PlayerTurnActions (1,2);
			break;
		case(GameState.PLAYER3):
			PlayerTurnActions (2,1);
			break;
		case(GameState.PLAYER4):
			PlayerTurnActions (3,0);
			break;
		case(GameState.LOSE):
			currentPlayer = null;
			// Score logic is there, just need to check it
			break;
		case(GameState.WIN):
			currentPlayer = null;
			// Score logic is there, just need to check it
			break;
		}
		CheckWinCondition ();
	}

	void PlayerTurnActions(int index, int handycap){
		currentPlayer = players [index];
		if (collectResources) {
			players [index].GetComponent<NewPlayer>().GatherResources ();
			if (roundCount == 1) {
				players [index].GetComponent<NewPlayer> ().data.Kumara -= handycap;
			}
			playerMessage.text = "It is " + players [index].GetComponent<NewPlayer> ().data.PlayerName + "'s turn.";
			playerMessage.color = players [index].GetComponent<NewPlayer> ().data.PlayerColor;

			collectResources = false;
		}
	}
		
	void CheckWinCondition(){
		if (currentPlayer != null) {
			if (currentPlayer.GetComponent<NewPlayer> ().data.Score >= GetComponent<GameManager> ().totalScore) {
				currentState = GameState.WIN;
				playerMessage.text = "Congradulations " + currentPlayer.GetComponent<NewPlayer> ().data.PlayerName + " You've Won :D";
			}
		}
	}

	public void CreatePlayers(GameObject[] playerList){
		players = playerList;
	}
}
