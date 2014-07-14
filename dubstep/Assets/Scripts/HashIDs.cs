using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
	// Here we store the hash tags for various strings used in our animators.
	public int standBool;
	public int deadBool;
	
	
	void Awake ()
	{
		standBool = Animator.StringToHash("Stand");
		deadBool = Animator.StringToHash("Dead");
	}
}