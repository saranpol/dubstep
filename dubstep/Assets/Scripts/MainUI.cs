using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	void OnGUI () {
		int w = Screen.width;
		int h = Screen.height;



		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			//Application.LoadLevel(1);
		}
		
		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			//Application.LoadLevel(2);
		}
	}
}
