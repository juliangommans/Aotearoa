using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.


public class GridManager : MonoBehaviour {

	// Using Serializable allows us to embed a class with sub properties in the inspector.
	[System.Serializable]
	public class Count
	{
		public int minimum;             //Minimum value for our Count class.
		public int maximum;             //Maximum value for our Count class.


		//Assignment constructor.
		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}


	public float columns = 8;                                         //Number of columns in our game board.
	public float rows = 8;                                            //Number of rows in our game board.
	public Count wallCount = new Count (5, 9);                      //Lower and upper limit for our random number of walls per level.

	public GameObject floorTile;

	public GameObject kauriLoc;
	public GameObject moaLoc;
	public GameObject flaxLoc;
	public GameObject pounamuLoc;

//	private GameObject instance;
	private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.
	private List <Vector3> gridPositions = new List <Vector3> ();   //A list of possible locations to place tiles.


	//Clears our list gridPositions and prepares it to generate a new board.
	void InitialiseList ()
	{
		//Clear our list gridPositions.
		gridPositions.Clear ();

		//Loop through x axis (columns).
		for(float x = 0; x < columns; x++)
		{
			//Within each column, loop through y axis (rows).
			for(float y = 0; y < rows; y++)
			{
				//At each index add a new Vector3 to our list with the x and y coordinates of that position.
				if (y % 2 == 0) {
					gridPositions.Add (new Vector3 ((x * 1.2f + 0.6f), y, 0f));
				} else {
					gridPositions.Add (new Vector3 ((x * 1.2f), y, 0f));
				}
			}
		}
	}


	//Sets up the outer walls and floor (background) of the game board.
	void BoardSetup ()
	{
		//Instantiate Board and set boardHolder to its transform.
		boardHolder = new GameObject ("Board").transform;

		//Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
		for(float x = 0; x < columns; x++)
		{
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for(float y = 0; y < rows; y++)
			{
//				//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
//				GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
//
//				//Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
//				if(x == -1 || x == columns || y == -1 || y == rows)
//					toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];


				GameObject toInstantiate = floorTile;
				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
				if (y % 2 == 0) {
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 ((x * 1.2f + 0.6f), y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent (boardHolder);
					instance.GetComponent<GroundLogic> ().SetCoords (x, y);
				} else {
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 ((x * 1.2f), y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent (boardHolder);
					instance.GetComponent<GroundLogic> ().SetCoords (x, y);
				}

				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.

			}
		}
	}


	//RandomPosition returns a random position from our list gridPositions.
	Vector3 RandomPosition ()
	{
		//Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
		int randomIndex = Random.Range (0, gridPositions.Count);

		//Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
		Vector3 randomPosition = gridPositions[randomIndex];

		//Remove the entry at randomIndex from the list so that it can't be re-used.
		gridPositions.RemoveAt (randomIndex);

		//Return the randomly selected Vector3 position.
		return randomPosition;
	}


	//LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
	void LayoutObjectAtRandom (GameObject resource, string name)
	{
		int count = 16;

		for(int i = 0; i < count; i++)
		{
			Vector3 randomPosition = RandomPosition();

			RaycastHit2D hit = Physics2D.Raycast (new Vector2(randomPosition.x,randomPosition.y),Vector2.zero);
			if (hit.collider != null) {
				GroundLogic tile = hit.collider.gameObject.GetComponent<GroundLogic>();
				tile.resource = name;
				Debug.Log ("should be 16 of these " + name);
				Instantiate(resource, randomPosition, Quaternion.identity);
			}


		}
	}

	public void SetupScene ()
	{
		//Creates the outer walls and floor.
		BoardSetup ();

		//Reset our list of gridpositions.
		InitialiseList ();

		LayoutObjectAtRandom (kauriLoc, "Kauri");
		LayoutObjectAtRandom (moaLoc, "Moa");
		LayoutObjectAtRandom (pounamuLoc, "Pounamu");
		LayoutObjectAtRandom (flaxLoc, "Flax");

	}
}