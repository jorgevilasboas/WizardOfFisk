using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sistema_GameOver : MonoBehaviour {

    public Text highScoreText;
    public Text scoreText;
    // Use this for initialization
    void Start () {
        highScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        scoreText.text = PlayerPrefs.GetInt("score", 0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
