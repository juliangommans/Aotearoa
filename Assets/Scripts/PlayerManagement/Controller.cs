using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public string type;

	public int startingCamps;
	public int startingRoads;
	public bool startingPhase;

	void Start () {
		type = "Human";
		startingPhase = true;
		int startingCamps = 2;
		int startingRoads = 3;
	}
		
}
