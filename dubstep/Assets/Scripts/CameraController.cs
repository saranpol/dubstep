using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 targetOffset;
	
	void Start () {
		offset = transform.position;
		targetOffset = offset;
	}
	
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}

	void zoomOut() {
		Vector3 v = targetOffset * 1.1f;
		if (v.x > 44.3)
			return;
		targetOffset = v;
	}

	void zoomIn() {
		Vector3 v = targetOffset * 0.9f;
		if (v.x < 3.2)
			return;
		targetOffset = v;
	}

	void updateOffset() {
		if(offset != targetOffset)
			offset = Vector3.Lerp (offset, targetOffset, 10 * Time.deltaTime); 

	}

	void Update() {

		updateOffset ();

		if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) 
		{
			
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
				zoomOut();
				//camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + (1 * cam_speed),15,90);
			}
			
			if ((touchDelta + varianceInDistances > 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
			{
				zoomIn();
				//camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - (1 * cam_speed),15,90);
			}
			
		}


		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			zoomOut();
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			zoomIn();
		}
	}
}
