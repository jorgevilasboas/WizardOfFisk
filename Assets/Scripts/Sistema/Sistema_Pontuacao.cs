using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sistema_Pontuacao : MonoBehaviour
{

    public Text pontos;

    private int score;
    private int Muda_Ponto;
    private GameObject Sistema;
    private static Sistema_Pontuacao instance;
    public static Sistema_Pontuacao Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Sistema_Pontuacao>();
            }

            return instance;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public void SetScore(int score)
    {
        this.score += score;
        if (this.score >= GetHighScore())
        {
            SetHighscore(this.score);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SetHighscore(int score)
    {
        PlayerPrefs.SetInt("highscore", score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    private void Start()
    {
        Muda_Ponto = 50;
        // Procura o objeto Sistema
        Sistema = GameObject.Find("Sistema");
    }

    void Update()
    {        
        pontos.text = "" + GetScore();
        if(score >= Muda_Ponto)
        {
            Sistema.GetComponent<Sistema_Inimigos>().setVelocidade_inimigos(1.05f);
            Sistema.GetComponent<Sistema_Inimigos>().setTempo_respawn(0.95f);
            Sistema.GetComponent<Sistema_Atirar>().setTempo_Recarga(0.95f);
            Muda_Ponto += 50;
        }
    }
}