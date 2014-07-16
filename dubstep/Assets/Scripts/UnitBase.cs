using UnityEngine;
using System.Collections;

public class UnitBase : MonoBehaviour {

	public int health;
	public int healthMax;
	public SpriteRenderer spriteGreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		spriteGreen.transform.localScale = new Vector3((float)health/(float)healthMax, 1f, 1f);
	}
}
