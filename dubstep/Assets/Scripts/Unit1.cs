using UnityEngine;
using System.Collections;

public class Unit1 : MonoBehaviour {

	public float speed;

	private Vector3 targetPosition;
	
	
	public void setTargetPosition(Vector3 pos) {
		targetPosition = pos;
	}
	
	void Update() {
		if (targetPosition != transform.position) {
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}
	}
}
