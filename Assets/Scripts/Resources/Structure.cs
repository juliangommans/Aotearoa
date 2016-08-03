using UnityEngine;
using System.Collections;

public class Structure : MonoBehaviour {

	private GameObject owner;
	private GameObject currentPlayer;
	private GameObject gameManager;

	public GameObject Owner{ get; set; }

	void Start (){
		gameManager = GameObject.Find ("GameManager");
		if (gameManager.GetComponent<RoundManager> ().currentPlayer != null) {
			currentPlayer = gameManager.GetComponent<RoundManager> ().currentPlayer;
			this.Owner = currentPlayer;
			this.GetComponent<SpriteRenderer> ().color = currentPlayer.GetComponent<NewPlayer> ().data.PlayerColor;
		}
	}
}
