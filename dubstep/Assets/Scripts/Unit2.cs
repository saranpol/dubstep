using UnityEngine;
using System.Collections;

public class Unit2 : MonoBehaviour {
	
	public float speed;
	
	//	private Vector3 targetPosition;
	
	
	public void setTargetPosition(Vector3 pos) {
		//		targetPosition = pos;
	}
	
	void Update() {
		//if (targetPosition != transform.position) {
		//	transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		//}
	}
	
	void FixedUpdate() {
		Vector3 movement = new Vector3 (0.0f, 0.0f, 1.0f);
		rigidbody.AddForce (movement*speed*Time.deltaTime);
	}
}
