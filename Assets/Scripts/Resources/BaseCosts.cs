using UnityEngine;
using System.Collections;

public class BaseCosts : MonoBehaviour {

	private int kauriCost; // wood
	private int flaxCost;
	private int kumaraCost; // sweet potato
	private int moaCost; // large flightless bird
	private int pounamuCost; // greenstone

	private int multiplier;

	public int KauriCost{ get; set; }
	public int FlaxCost{ get; set; }
	public int KumaraCost{ get; set; }
	public int MoaCost{ get; set; }
	public int PounamuCost{ get; set; }

	public int Multiplier{ get; set; }

	void Awake (){
		this.multiplier = 0;
		this.KauriCost = 0;
		this.FlaxCost = 0;
		this.KumaraCost = 0;
		this.MoaCost = 0;
		this.PounamuCost = 0;
	}

	public bool CanAfford (GameObject player){
		bool outcome = true;
		if (player.GetComponent<NewPlayer> ().data.Kauri < this.KauriCost) {
			outcome = false;
		}
		if (player.GetComponent<NewPlayer> ().data.Flax < this.FlaxCost) {
			outcome = false;
		}
		if (player.GetComponent<NewPlayer> ().data.Kumara < this.KumaraCost) {
			outcome = false;
		}
		if (player.GetComponent<NewPlayer> ().data.Moa < this.MoaCost) {
			outcome = false;
		}
		if (player.GetComponent<NewPlayer> ().data.Pounamu < this.PounamuCost) {
			outcome = false;
		}
		return outcome;
	}

	public void DeductResources (GameObject player){
		player.GetComponent<NewPlayer> ().data.Kauri -= this.KauriCost;
		player.GetComponent<NewPlayer> ().data.Flax -= this.FlaxCost;
		player.GetComponent<NewPlayer> ().data.Kumara -= this.KumaraCost;
		player.GetComponent<NewPlayer> ().data.Moa -= this.MoaCost;
		player.GetComponent<NewPlayer> ().data.Pounamu -= this.PounamuCost;
	}
}
