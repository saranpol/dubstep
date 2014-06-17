using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject goTerrain;
	public float speed;

	private Vector3 targetPosition;


	void Start() {
		targetPosition = transform.position;
	}

	void Update() {
		if (Input.GetMouseButtonDown (0) && GUIUtility.hotControl == 0) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (goTerrain.collider.Raycast (ray, out hit, Mathf.Infinity)) {
				targetPosition = hit.point;
			}
		}

		if (targetPosition != transform.position) {
			//transform.position = Vector3.Lerp (transform.position, targetPosition, speed * Time.deltaTime); 
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}

	}
}
