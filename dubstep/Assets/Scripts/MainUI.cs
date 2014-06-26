using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	public GUITexture button0;
	public GUITexture button1;


	public GUIText testText;
    public PlayerController playerController;

    private GameController gc;
	private int bh;

	void Start () {
		GameObject g = GameObject.FindWithTag ("GameController");
		if (g != null)
			gc = g.GetComponent <GameController>();
		if (gc == null)
			Debug.Log ("Cannot find 'GameController' script");
	}


	void updateButtonTexture(GUITexture t){
		t.pixelInset = new Rect(t.transform.position.x, t.transform.position.y, bh, bh);
	}

	void OnGUI () {
		//int w = Screen.width;
		int h = Screen.height;

		//int bw = Mathf.RoundToInt(1.0f / 7.0f * w);
		bh = Mathf.RoundToInt(1.0f / 5.0f * h);

		updateButtonTexture (button0);
		updateButtonTexture (button1);
	}




    
    void checkInput() {
        if(GUIUtility.hotControl != 0)
            return;

        // Tab
        int tapCount = Input.touchCount;

        for (int i=0; i<tapCount; i++) {
            Touch touch = Input.GetTouch(i);
            if(touch.phase == TouchPhase.Began){
				bool hit = false;
                hit |= check_button0(touch.position);
				hit |= check_button1(touch.position);

				//if(touch.position.y > bh && (tapCount == 1))
				if(!hit)
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

			//if(!hit && Input.mousePosition.y > bh)
			if(!hit)
            	playerController.setTargetPosition(Input.mousePosition);
        }
    }

    void Update() {
        checkInput ();
    }








	bool check_button0(Vector2 pos){
		if(button0.HitTest(pos)){
			testText.text = "button0";
			gc.GenUnit2();
			return true;
		}
		return false;
	}
	
	bool check_button1(Vector2 pos){
		if(button1.HitTest(pos)){
			testText.text = "button1";
			gc.GenUnit1();
			return true;
		}
		return false;
	}
	


}
