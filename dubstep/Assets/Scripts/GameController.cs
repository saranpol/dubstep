using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject unit1;

	private GameObject player;

	void Start () {

	}


	public void GenUnit1() {
		GameObject player = GameObject.FindWithTag ("Player");

		Vector3 p = new Vector3(player.transform.position.x, 0, -30);
		Quaternion r = Quaternion.identity;
		GameObject o = Instantiate (unit1, p, r) as GameObject;
		Unit1 u = o.GetComponent <Unit1>();
		u.setTargetPosition (player.transform.position);

//		u.setTargetPosition (player.transform.position);
	}
}
