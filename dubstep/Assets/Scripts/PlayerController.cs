using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject goTerrain;
	public float speed;


	private Vector3 targetPosition;


	void Start() {
		targetPosition = transform.position;
	}


	public void setTargetPosition(Vector3 pos) {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(pos);
		if (goTerrain.collider.Raycast (ray, out hit, Mathf.Infinity)) {
			targetPosition = hit.point;
		}
	}

    void Update() {
        // Move Player
        if (targetPosition != transform.position) {
            //transform.position = Vector3.Lerp (transform.position, targetPosition, speed * Time.deltaTime); 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        
    }
}
