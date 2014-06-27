using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject goTerrain;
	public float speed;
	public GameObject explosion;

	private Vector3 targetPosition;


	void Start() {
		targetPosition = transform.position;
	}


	public float radius;
	public float power;
	void ApplyBomb(Vector3 explosionPos) {
		Instantiate (explosion, explosionPos, Quaternion.identity);

		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders) {
			if(hit.CompareTag("Player"))
				continue;
			if (hit && hit.rigidbody)
				hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 3.0F);
			
		}
	}

	public void setTargetPosition(Vector3 pos) {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(pos);
		if (goTerrain.collider.Raycast (ray, out hit, Mathf.Infinity)) {
			targetPosition = hit.point;
			ApplyBomb(targetPosition);
		}
	}

    void LateUpdate() {
        // Move Player
        if (targetPosition != transform.position) {
            //transform.position = Vector3.Lerp (transform.position, targetPosition, speed * Time.deltaTime); 
            Vector3 v = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
			v.y = transform.position.y;
			transform.position = v;
        }
        
    }
}
