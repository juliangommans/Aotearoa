using UnityEngine;
using System.Collections;

public class UndoButton : MonoBehaviour {

	public void UndoPreviousActions(){
		GameObject.Find ("GameManager").GetComponent<GameManager> ().UndoPreviousAction ();
	}
}
