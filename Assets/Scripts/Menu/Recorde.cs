using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recorde : MonoBehaviour {

    public Text highscore;

	// Use this for initialization
	void Start () {
        highscore.text = "" + PlayerPrefs.GetInt("highscore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
