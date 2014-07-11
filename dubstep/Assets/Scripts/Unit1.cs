using UnityEngine;
using System.Collections;

public class Unit1 : MonoBehaviour {

	public float speed;
	public float targetPositionZ;
	public GameObject explosion;
	public bool isEnemy;
	//public Material enemyMaterial;
	public Vector3 targetPosition;
	//public Renderer mRenderer;
	public SpriteRenderer mSprite;
	private NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
	}

	
	public void SetupUnit() {
		if (isEnemy){
			//mRenderer.material = enemyMaterial;
			FaceCamera fc = mSprite.GetComponent<FaceCamera>();
			fc.flip = true;
		}
	}
	
	public void setTargetPosition(Vector3 pos) {
		//		targetPosition = pos;
	}

	void Update() {
		//if (targetPosition != transform.position) {
		//	transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		//}
		//targetPosition = new Vector3 (transform.position.x, 0.0f, isEnemy ? -targetPositionZ : targetPositionZ);
		targetPosition = new Vector3 (0.0f, 0.0f, isEnemy ? -targetPositionZ : targetPositionZ);
		agent.SetDestination (targetPosition);
	}

	
//	void FixedUpdate() {
//		Vector3 movement = new Vector3 (0.0f, 0.0f, isEnemy ? -1.0f : 1.0f);
//		rigidbody.AddForce (movement*speed*Time.deltaTime);
//	}
	
	public void killObject() {
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Wall Enemy")) {
			killObject();
		}
		if (collision.gameObject.CompareTag ("Wall Player")) {
			killObject();
		}
		
		//		if (collision.gameObject.CompareTag ("Ground")) {
		//			if(Mathf.Abs(collision.relativeVelocity.y) > 10.0){
		//				killObject();
		//			}
		//		}
		
	}

}
