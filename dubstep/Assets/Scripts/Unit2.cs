using UnityEngine;
using System.Collections;

public class Unit2 : MonoBehaviour {
	
	public float speed;
	public GameObject explosion;
	public bool isEnemy;
	public Material enemyMaterial;
	//	private Vector3 targetPosition;


	public void SetupUnit() {
		if (isEnemy)
			renderer.material = enemyMaterial;
	}

	public void setTargetPosition(Vector3 pos) {
		//		targetPosition = pos;
	}
	
	void Update() {
		//if (targetPosition != transform.position) {
		//	transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		//}
	}
	
	void FixedUpdate() {
		Vector3 movement = new Vector3 (0.0f, 0.0f, isEnemy ? -1.0f : 1.0f);
		rigidbody.AddForce (movement*speed*Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Wall Enemy")) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if (collision.gameObject.CompareTag ("Wall Player")) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if (isEnemy && collision.gameObject.CompareTag ("Player")) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

}
