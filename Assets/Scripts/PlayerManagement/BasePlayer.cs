using UnityEngine;
using System.Collections;

public class BasePlayer : MonoBehaviour  {

	private string playerName;
	private Color playerColor;

	private int kauri; // wood
	private int flax;
	private int kumara; // sweet potato
	private int moa; // large flightless bird
	private int pounamu; // greenstone

	private int landPoints;
	private int roadPoints;
	private int roadCount;
	private int score;

	private int startingCamps;
	private int startingRoads;

	public string PlayerName{ get; set; }
	public Color PlayerColor{ get; set; }

	public int Kauri{ get; set; }
	public int Flax{ get; set; }
	public int Kumara{ get; set; }
	public int Moa{ get; set; }
	public int Pounamu{ get; set; }

	public int LandPoints{ get; set; }
	public int RoadPoints{ get; set; }
	public int RoadCount{ get; set; }
	public int Score{ get; set; }

	public int StartingCamps{ get; set; }
	public int StartingRoads{ get; set; }

	void Awake (){
		this.playerName = "Error";
		this.playerColor = Color.white;
		this.Kauri = 0;
		this.Flax = 0;
		this.Kumara = 0;
		this.Moa = 0;
		this.Pounamu = 0;

		this.LandPoints = 0;
		this.RoadCount = 0;
		this.RoadPoints = 0;
		this.Score = 0;

		this.StartingCamps = 0;
		this.StartingRoads = 0;
	}

}
