using UnityEngine;
using System.Collections;
using UnityEditor;

public class UndoButton : MonoBehaviour {

	public void UndoPreviousActions(){
		GameObject.Find ("GameManager").GetComponent<GameManager> ().UndoPreviousAction ();
	}
}
