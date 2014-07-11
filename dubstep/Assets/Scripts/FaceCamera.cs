using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	public bool flip = false;

	void Update() {
		//transform.LookAt(Camera.main.transform.position, Vector3.up);
		transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
		if(flip)
			transform.Rotate (new Vector3 (0f, 180f, 0f));
	}
}
