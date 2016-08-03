using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TradeImage : MonoBehaviour {

	public Sprite kumaraImage;
	public Sprite kauriImage;
	public Sprite flaxImage;
	public Sprite pounamuImage;
	public Sprite moaImage;


	public void SetEmpty(){
		// need a way to show a clear image
	}

	public void SetKumara(){
		GetComponent<Image> ().sprite = kumaraImage;
	}
	public void SetKauri(){
		GetComponent<Image> ().sprite = kauriImage;
	}
	public void SetMoa(){
		GetComponent<Image> ().sprite = moaImage;
	}
	public void SetPounamu(){
		GetComponent<Image> ().sprite = pounamuImage;
	}
	public void SetFlax(){
		GetComponent<Image> ().sprite = flaxImage;
	}

	public void SelectCorrectResource(string resource){
		switch (resource) {
		case("Kumara"):
			SetKumara ();
			break;
		case("Kauri"):
			SetKauri ();
			break;
		case("Moa"):
			SetMoa ();
			break;
		case("Pounamu"):
			SetPounamu ();
			break;
		case("Flax"):
			SetFlax ();
			break;
		default:
			SetEmpty ();
			break;
		}
	}
}
