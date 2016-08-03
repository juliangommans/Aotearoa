using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StructureImage : MonoBehaviour {

	public Sprite roadImage;
	public Sprite campImage;
	public Sprite paImage;

//	GameObject currentPlayer;

	public void SetEmpty(GameObject currentPlayer){
		GetComponent<Image> ().color = new Color (0, 0, 0, 0);
	}

	public void SetRoad(GameObject currentPlayer){
		GetComponent<Image> ().sprite = roadImage;
		GetComponent<Image> ().color = currentPlayer.GetComponent<NewPlayer>().data.PlayerColor;
	}

	public void SetCamp(GameObject currentPlayer){
		GetComponent<Image> ().sprite = campImage;
		GetComponent<Image> ().color = currentPlayer.GetComponent<NewPlayer>().data.PlayerColor;
	}

	public void SetPa(GameObject currentPlayer){
		GetComponent<Image> ().sprite = paImage;
		GetComponent<Image> ().color = currentPlayer.GetComponent<NewPlayer>().data.PlayerColor;
	}
}
