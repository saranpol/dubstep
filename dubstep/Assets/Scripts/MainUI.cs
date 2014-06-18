﻿using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	public GameObject gameControllerObject;
	private GameController gameController;

	void Start () {
		gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnGUI () {
		int w = Screen.width;
		int h = Screen.height;

		int bw = Mathf.RoundToInt(1.0f / 7.0f * w);
		int bh = Mathf.RoundToInt(1.0f / 6.0f * h);
		int y = h - bh;
		int x = 0;

		if(GUI.Button(new Rect(x,y,bw,bh), "X")) {
			gameController.GenUnit1();
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

}
