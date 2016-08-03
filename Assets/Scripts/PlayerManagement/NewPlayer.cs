using UnityEngine;
using System.Collections;

public class NewPlayer : MonoBehaviour {

	public BasePlayer data;
	GameObject[] ownedLands;

	void Start () {
		data = new BasePlayer();
		data.PlayerName = "this player";
		data.PlayerColor = Color.red;
		data.Kauri = 1;
		data.Flax = 1;
		data.Kumara = 2;
		data.StartingCamps = 2;
		data.StartingRoads = 3;
	}
		
	public void GatherResources (){
		ownedLands = GameObject.FindGameObjectsWithTag ("Ground");
		foreach(GameObject land in ownedLands){
			if (land.GetComponent<GroundLogic> ().occupied) {
				if (land.GetComponent<GroundLogic> ().owner.GetComponent<NewPlayer>().data.PlayerName == this.gameObject.GetComponent<NewPlayer>().data.PlayerName) {
					ProcessResources (land.GetComponent<GroundLogic> ());
				}
			}
		}
	}

	public void CreateScore(){
		this.data.Score = 0;
		this.data.Score += this.data.LandPoints;
		this.data.Score += this.data.RoadPoints/3;
	}

	void ProcessResources (GroundLogic land){
		if (land.resource == "Kauri") {
			this.data.Kauri += land.multiplier;
		}
		if (land.resource == "Moa") {
			this.data.Moa += land.multiplier;
		}
		if (land.resource == "Pounamu") {
			this.data.Pounamu += land.multiplier;
		}
		if (land.resource == "Flax") {
			this.data.Flax += land.multiplier;
		}
		this.data.Kumara += land.multiplier;
	}

	public bool StartingPhase(){
		if (this.data.StartingRoads > 0 || this.data.StartingCamps > 0) {
			return true;
		} else {
			if (GameObject.Find ("GameManager").GetComponent<RoundManager> ().roundCount < 1) {
				return true;
			} else {
				return false;
			}
		}
	}
}
