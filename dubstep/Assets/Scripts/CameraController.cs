using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 targetOffset;
	private float zoomSpeed;
	
	void Start () {
		zoomSpeed = 10.0f;
		offset = transform.position;
		targetOffset = offset;
	}
	
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}

	void zoomOut(float d) {
		Vector3 v = targetOffset * (1.0f+d);
		if (v.x > 44.3)
			return;
		targetOffset = v;
	}

	void zoomIn(float d) {
		Vector3 v = targetOffset * (1.0f-d);
		if (v.x < 3.2)
			return;
		targetOffset = v;
	}

	void updateOffset() {
		if(offset != targetOffset)
			offset = Vector3.Lerp (offset, targetOffset, zoomSpeed * Time.deltaTime); 

	}

	void Update() {

		updateOffset ();

		if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) 
		{
			zoomSpeed = 100.0f;

			Vector2 curDist = Input.GetTouch(0).position - Input.GetTouch(1).position; //current distance between finger touches
			Vector2 prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition)); //difference in previous locations using delta positions
			float touchDelta = curDist.magnitude - prevDist.magnitude;
			float speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
			float speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;
			
			float varianceInDistances = 0;
			float minPinchSpeed = 0;
			//float cam_speed = 1;
			if ((touchDelta + varianceInDistances <= 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
			{
				zoomOut(-touchDelta/Screen.width*2.0f);
				//camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + (1 * cam_speed),15,90);
			}
			
			if ((touchDelta + varianceInDistances > 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
			{
				zoomIn(touchDelta/Screen.width*2.0f);
				//camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - (1 * cam_speed),15,90);
			}
			
		}


		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			zoomOut(0.1f);
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			zoomIn(0.1f);
		}
	}
}
