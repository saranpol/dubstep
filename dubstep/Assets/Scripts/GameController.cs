using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject unit1;
	public GameObject unit2;

	private GameObject player;

	void Start () {
		Application.targetFrameRate = 60;
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
		
		Vector3 p = new Vector3(player.transform.position.x, 0.5f, -30.0f);
		Quaternion r = Quaternion.identity;
		GameObject o = Instantiate (unit2, p, r) as GameObject;
		Unit2 u = o.GetComponent <Unit2>();
		u.setTargetPosition (player.transform.position);
		
		//		u.setTargetPosition (player.transform.position);
	}
}
