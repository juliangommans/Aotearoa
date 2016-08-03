using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{
	public GameObject dummyUndoPlayer;
	public GameObject dummyUndoGroundTile;
	GameObject undoPlayer;
	GameObject undoStructure;
	GameObject undoGroundTile;
	GameObject currentPlayer;
	GameObject currentStructure;
	GameObject currentGroundTile;
//	public bool canUndo;

	GameObject undoButton;

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private GridManager boardScript;   
	private RoundManager roundManager;
	public int totalScore;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//Get a component reference to the attached GridManager script
		boardScript = GetComponent<GridManager>();
		roundManager = GetComponent<RoundManager> ();
		//Call the InitGame function to initialize the first level 
		InitGame();
	}

	void InitGame()
	{
		boardScript.SetupScene();
		totalScore = 20;

		undoPlayer = Instantiate (dummyUndoPlayer, new Vector3(1000f,1000f), transform.rotation) as GameObject;
		undoGroundTile = Instantiate (dummyUndoGroundTile, new Vector3 (100f, 1000f), transform.rotation) as GameObject;
		undoButton = GameObject.Find ("Undo");
	}

	public void SetupUndo(GameObject structure, GameObject player, GameObject land){

		UndoGroundLogic (land);
		UndoStructureLogic (structure);
		UndoPlayerLogic (player);

//		canUndo = true;
		undoButton.SetActive (true);
	}

	public void UndoPreviousAction(){
//		if (canUndo) {

		//undoing the land
		SetOldGroundStats (undoGroundTile, currentGroundTile);

		//undoing the structure
		Destroy(currentStructure); // Pa logic slightly more complicated

		//undoing the player
		SetOldPlayerStats (undoPlayer, GetComponent<RoundManager>().currentPlayer);

		undoButton.SetActive (false);
//		}
	}

	void UndoGroundLogic (GameObject land){

		currentGroundTile = land; 
		SetOldGroundStats (land, undoGroundTile);

	}

	void UndoStructureLogic(GameObject structure){
		if (undoStructure != null)
			Destroy (undoStructure);

		currentStructure = structure;
		undoStructure = Instantiate (structure, structure.transform.position, structure.transform.rotation) as GameObject;
		undoStructure.SetActive (false);
	}

	void UndoPlayerLogic(GameObject player){
		currentPlayer = player;
		SetOldPlayerStats (currentPlayer, undoPlayer);
	}

	void SetOldPlayerStats(GameObject originalPlayer, GameObject storedPlayer){
		NewPlayer op = originalPlayer.GetComponent<NewPlayer> ();
		NewPlayer sp = storedPlayer.GetComponent<NewPlayer> ();

		sp.data.Kumara = op.data.Kumara;
		sp.data.Kauri = op.data.Kauri;
		sp.data.Pounamu = op.data.Pounamu;
		sp.data.Moa = op.data.Moa;
		sp.data.Flax = op.data.Flax;
		sp.data.Score = op.data.Score;

		sp.data.LandPoints = op.data.LandPoints;
		sp.data.RoadPoints = op.data.RoadPoints;
		sp.data.StartingCamps = op.data.StartingCamps;
		sp.data.StartingRoads = op.data.StartingRoads;
	}

	void SetOldGroundStats(GameObject originalLand, GameObject storedLand){
		GroundLogic ol = originalLand.GetComponent<GroundLogic> ();
		GroundLogic sl = storedLand.GetComponent<GroundLogic> ();

		sl.hasPa = ol.hasPa;
		sl.placedStructure = ol.placedStructure;
		sl.occupied = ol.occupied;
		sl.multiplier = ol.multiplier;
		sl.roads = ol.roads;
		sl.owner = ol.owner;
	}
}