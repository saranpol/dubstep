using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	public GUITexture button0;
    public GUITexture button1;
	public GUITexture button2;
	public GUITexture button3;
	public GUITexture button4;
	public GUITexture button5;
	public GUITexture button6;


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
		bh = Mathf.RoundToInt(1.0f / 6.0f * h);

		updateButtonTexture (button0);
		updateButtonTexture (button1);
		updateButtonTexture (button2);
		updateButtonTexture (button3);
		updateButtonTexture (button4);
		updateButtonTexture (button5);
		updateButtonTexture (button6);
	}




    
    void checkInput() {
        if(GUIUtility.hotControl != 0)
            return;

        // Tab
        int tapCount = Input.touchCount;
        for (int i=0; i<tapCount; i++) {
            Touch touch = Input.GetTouch(i);
            if(touch.phase == TouchPhase.Began){
                if(check_button0(touch.position)) continue;
                if(check_button1(touch.position)) continue;
				if(check_button2(touch.position)) continue;
				if(check_button3(touch.position)) continue;
				if(check_button4(touch.position)) continue;
				if(check_button5(touch.position)) continue;
				if(check_button6(touch.position)) continue;

				if(touch.position.y > bh && (tapCount == 1))
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
			hit |= check_button2(Input.mousePosition);
			hit |= check_button3(Input.mousePosition);
			hit |= check_button4(Input.mousePosition);
			hit |= check_button5(Input.mousePosition);
			hit |= check_button6(Input.mousePosition);

			if(!hit && Input.mousePosition.y > bh)
            	playerController.setTargetPosition(Input.mousePosition);
        }
    }

    void Update() {
        checkInput ();
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
			gc.GenUnit1();
			return true;
		}
		return false;
	}

	bool check_button2(Vector2 pos){
		if(button2.HitTest(pos)){
			testText.text = "button2";
			return true;
		}
		return false;
	}
	
	bool check_button3(Vector2 pos){
		if(button3.HitTest(pos)){
			testText.text = "button3";
			return true;
		}
		return false;
	}

	bool check_button4(Vector2 pos){
		if(button4.HitTest(pos)){
			testText.text = "button4";
			return true;
		}
		return false;
	}
	
	bool check_button5(Vector2 pos){
		if(button5.HitTest(pos)){
			testText.text = "button5";
			return true;
		}
		return false;
	}

	bool check_button6(Vector2 pos){
		if(button6.HitTest(pos)){
			testText.text = "button6";
			return true;
		}
		return false;
	}
	


}
