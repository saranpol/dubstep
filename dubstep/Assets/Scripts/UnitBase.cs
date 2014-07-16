using UnityEngine;
using System.Collections;

public class UnitBase : MonoBehaviour {

	public int health;
	public int healthMax;
	public SpriteRenderer spriteGreen;

	void Start () {
	
	}
	
	void Update () {

	}

	void updateHealthUI() {
		spriteGreen.transform.localScale = new Vector3((float)health/(float)healthMax, 1f, 1f);
	}

	public void updateHealth(int v) {
		health = Mathf.Clamp (health + v, 0, healthMax);
		updateHealthUI ();
	}
}
