using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	public GUITexture button0;
    public GUITexture button1;
    public GUIText testText;
    public PlayerController playerController;

    private GameController gc;


	void Start () {
		GameObject g = GameObject.FindWithTag ("GameController");
		if (g != null)
			gc = g.GetComponent <GameController>();
		if (gc == null)
			Debug.Log ("Cannot find 'GameController' script");
	}

	void OnGUI () {
		int w = Screen.width;
		int h = Screen.height;

		int bw = Mathf.RoundToInt(1.0f / 7.0f * w);
		int bh = Mathf.RoundToInt(1.0f / 6.0f * h);
		int y = h - bh;
		int x = 0;

		if(GUI.Button(new Rect(x,y,bw,bh), "X")) {
			gc.GenUnit1();
		}
		x += bw;

		if(GUI.Button(new Rect(x,y,bw,bh), "A")) {

		}
		x += bw;
		if(GUI.Button(new Rect(x,y,bw,bh), "B")) {
		}
		x += bw;
		if(GUI.Button(new Rect(x,y,bw,bh), "C")) {
		}
		x += bw;
		if(GUI.Button(new Rect(x,y,bw,bh), "D")) {
		}
		x += bw;
		if(GUI.Button(new Rect(x,y,bw,bh), "E")) {
		}
		x += bw;

		if(GUI.Button(new Rect(x,y,w-x,bh), "E")) {
		}
	
	}



    bool check_button0(Vector2 pos){
        if(button0.HitTest(pos)){
            testText.text = "button0";
            return true;
        }
        return false;
    }

    bool check_button1(Vector2 pos){
        if(button1.HitTest(pos)){
            testText.text = "button1";
            return true;
        }
        return false;
    }
    
    void checkInput() {
        if(GUIUtility.hotControl != 0)
            return;

        // Tab
        int tapCount = Input.touchCount;
        for (int i=0; i<tapCount; i++) {
            Touch touch = Input.GetTouch(i);
            if(touch.phase == TouchPhase.Began){
                if(check_button0(touch.position))
                    continue;
                if(check_button1(touch.position))
                    continue;
                playerController.setTargetPosition(touch.position);
            }
        }
        if (tapCount > 0)
            return;

        
        // Mouse
        if (Input.GetMouseButtonDown(0)) {
            bool hit = false;
            hit |= check_button0(Input.mousePosition);
            hit |= check_button1(Input.mousePosition);
            
            if(!hit)
                playerController.setTargetPosition(Input.mousePosition);
        }
    }

    void Update() {
        checkInput ();
    }

}
