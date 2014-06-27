using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float panSpeed;
	public float panMinX;
	public float panMaxX;
	private Vector3 offset;
	private Vector3 targetZoomOffset;
	private Vector3 panOffset;
	private float zoomSpeed;
	
	void Start () {
		zoomSpeed = 10.0f;
		offset = transform.position;
		targetZoomOffset = offset;
		panOffset = Vector3.zero;
	}
	
	void LateUpdate () {
		//transform.position = player.transform.position + offset;
		transform.position = panOffset + offset;
	}

	void zoomOut(float d) {
		Vector3 v = targetZoomOffset * (1.0f+d);
		if (v.y > 62.74426)
			return;
		targetZoomOffset = v;
	}

	void zoomIn(float d) {
		Vector3 v = targetZoomOffset * (1.0f-d);
		if (v.y < 4.785985)
			return;
		targetZoomOffset = v;
	}

	void updateOffset() {
		if(offset != targetZoomOffset)
			offset = Vector3.Lerp (offset, targetZoomOffset, zoomSpeed * Time.deltaTime); 

	}

	void Update() {

		updateOffset ();

		// Zoom Touch

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

		// Zoom Mouse

		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			zoomOut(0.1f);
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			zoomIn(0.1f);
		}

		// Pan Touch
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			float f = Mathf.Cos(Mathf.PI/4.0f) * transform.position.y/650.0f;
			float new_x = panOffset.x + (-touchDeltaPosition.x)*f + (touchDeltaPosition.y)*f;
			float new_z = panOffset.z + (-touchDeltaPosition.x)*f + (-touchDeltaPosition.y)*f;
			if(new_x >= panMaxX)
				new_x = panMaxX;
			if(new_z >= panMaxX)
				new_z = panMaxX;
			if(new_x <= panMinX)
				new_x = panMinX;
			if(new_z <= panMinX)
				new_z = panMinX;
			panOffset.x = new_x;
			panOffset.z = new_z;

		}


		// Pan Mouse
		if(SystemInfo.deviceType == DeviceType.Desktop){
			if (Input.mousePosition.x <= 0) {
				float d = Time.deltaTime*panSpeed;
				float new_x = panOffset.x - d;
				float new_z = panOffset.z - d;
				if(new_x >= panMinX)
					panOffset.x = new_x;
				if(new_z >= panMinX)
					panOffset.z = new_z;

			}
			if (Input.mousePosition.x >= Screen.width) {
				float d = Time.deltaTime*panSpeed;
				float new_x = panOffset.x + d;
				float new_z = panOffset.z + d;
				if(new_x <= panMaxX)
					panOffset.x = new_x;
				if(new_z <= panMaxX)
					panOffset.z = new_z;
			}
			if (Input.mousePosition.y <= 0) {
				float d = Time.deltaTime*panSpeed;
				float new_x = panOffset.x + d;
				float new_z = panOffset.z - d;
				if(new_x <= panMaxX)
					panOffset.x = new_x;
				if(new_z >= panMinX)	
					panOffset.z = new_z;
			}
			if (Input.mousePosition.y >= Screen.height) {
				float d = Time.deltaTime*panSpeed;
				float new_x = panOffset.x - d;
				float new_z = panOffset.z + d;
				if(new_x >= panMinX)
					panOffset.x = new_x;
				if(new_z <= panMaxX)
					panOffset.z = new_z;
			}
		}



	}
}
