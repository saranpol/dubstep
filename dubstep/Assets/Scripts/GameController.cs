using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject unit1;
	public GameObject unit2;

	private GameObject player;


	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	//public GUIText scoreText;
	//public GUIText restartText;
	//public GUIText gameOverText;
	
	//private bool gameOver;
	//private bool restart;
	//private int score;
	



	void Start () {
		Application.targetFrameRate = 60;

	
		//gameOver = false;
		//restart = false;
		
		//restartText.text = "";
		//gameOverText.text = "";
		
		//score = 0;
		//updateScore ();
		StartCoroutine (SpawnWaves ());
	}


	public void GenUnit1() {
		GameObject player = GameObject.FindWithTag ("Player");

		Vector3 p = new Vector3(player.transform.position.x, 0.5f, -30.0f);
		Quaternion r = Quaternion.identity;
		GameObject o = Instantiate (unit1, p, r) as GameObject;
		Unit1 u = o.GetComponent <Unit1>();
		u.setTargetPosition (player.transform.position);

//		u.setTargetPosition (player.transform.position);
	}


	public void GenUnit2() {
		GameObject player = GameObject.FindWithTag ("Player");
		
		Vector3 p = new Vector3(player.transform.position.x, spawnValues.y, -spawnValues.z);
		Quaternion r = Quaternion.identity;
		GameObject o = Instantiate (unit2, p, r) as GameObject;
		Unit2 u = o.GetComponent <Unit2>();
		u.isEnemy = false;
		u.SetupUnit();
		u.setTargetPosition (player.transform.position);
		
		//		u.setTargetPosition (player.transform.position);
	}



	
	
	void Update () {
//		if (restart) {
//			if (Input.GetKeyDown (KeyCode.R)) {
//				Application.LoadLevel (Application.loadedLevel);
//			}
//		}
	}
	
	
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i=0; i<hazardCount; i++) {
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					GameObject o = Instantiate (unit2, spawnPosition, spawnRotation) as GameObject;
					Unit2 u = o.GetComponent <Unit2>();
					u.isEnemy = true;
					u.SetupUnit();
				}

				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					GameObject o = Instantiate (unit2, spawnPosition, spawnRotation) as GameObject;
					Unit2 u = o.GetComponent <Unit2>();
					u.isEnemy = false;
					u.SetupUnit();
				}

				yield return new WaitForSeconds (spawnWait);
			}
			
			yield return new WaitForSeconds (waveWait);
			
//			if (gameOver)
//			{
//				restartText.text = "Press 'R' for Restart";
//				restart = true;
//				break;
//			}
		}
	}

}
