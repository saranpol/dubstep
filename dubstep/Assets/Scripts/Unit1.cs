using UnityEngine;
using System.Collections;

public class Unit1 : MonoBehaviour {

	public float speed;
	public float range;
	public float targetPositionZ;
	public GameObject explosion;
	public bool isEnemy;
	public bool isDead = false;
	//public Material enemyMaterial;
	public Vector3 targetPosition;
	//public Renderer mRenderer;
	public SpriteRenderer mSprite;
	private NavMeshAgent agent;
	private Animator animator;
	private HashIDs hash;
	public int health = 500;
	public int damage = 1;
	public int deadTime = 60;


	void Start() {
		agent = GetComponent<NavMeshAgent>();
		animator = mSprite.GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

		if (!isEnemy){
			//mRenderer.material = enemyMaterial;
			FaceCamera fc = mSprite.GetComponent<FaceCamera>();
			fc.flip = true;
		}
	}

	
	public void SetupUnit() {
		//
	}
	
	public void setTargetPosition(Vector3 pos) {
		//		targetPosition = pos;
	}

	void Update() {
		if(isDead){
			deadTime--;
			if(deadTime <= 0)
				killObject();
			return;
		}

		//if (targetPosition != transform.position) {
		//	transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		//}
		//targetPosition = new Vector3 (transform.position.x, 0.0f, isEnemy ? -targetPositionZ : targetPositionZ);
		targetPosition = new Vector3 (0.0f, 0.0f, isEnemy ? -targetPositionZ : targetPositionZ);
		agent.SetDestination (targetPosition);

		bool foundEnemy = false;
		Collider[] colliders = Physics.OverlapSphere(transform.position, range);
		foreach (Collider hit in colliders) {
			GameObject o = hit.gameObject;
			if(o.CompareTag("Unit1")){
				Unit1 u = o.GetComponent <Unit1>();
				if(u.isEnemy != isEnemy){
					animator.SetBool(hash.standBool, true);
					agent.speed = 0f;
					u.hasBeenShot(damage);
					foundEnemy = true;
					break;
				}
			}
		}

		if (!foundEnemy) {
			animator.SetBool(hash.standBool, false);
			agent.speed = speed;
		}

	}

	
//	void FixedUpdate() {
//		Vector3 movement = new Vector3 (0.0f, 0.0f, isEnemy ? -1.0f : 1.0f);
//		rigidbody.AddForce (movement*speed*Time.deltaTime);
//	}
	
	public void killObject() {
		//Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}

	public void processDead() {
		collider.enabled = false;
		isDead = true;
		agent.speed = 0;
		animator.SetBool(hash.deadBool, true);
	}

	public void hasBeenShot(int d) {
		health -= d;
		if(health <= 0){
			processDead();
		}
	}


	//	void OnCollisionEnter(Collision collision) {
//		Debug.Log ("colission begin" + collision.gameObject.tag);
//		if (collision.gameObject.CompareTag ("Wall Enemy")) {
//			killObject();
//		}
//		if (collision.gameObject.CompareTag ("Wall Player")) {
//			killObject();
//		}
//		
//		//		if (collision.gameObject.CompareTag ("Ground")) {
//		//			if(Mathf.Abs(collision.relativeVelocity.y) > 10.0){
//		//				killObject();
//		//			}
//		//		}
//		
//	}

}
