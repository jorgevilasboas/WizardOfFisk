using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_Inimigos : MonoBehaviour {

    // Configuracoes da tela
    private float altura_tela;
    private float largura_tela;
    private float pos_x_min;
    private float pos_x_max;
    private float pos_y_min;
    private float pos_y_max;
    private float pos_x_inimigo;
    private float pox_y_inimigo;

    // Objetos Inimigos
    [Header("Inimigos")]
    [Space(5)]
    public GameObject[] Inimigos;

    // Dados do Respaw
    [Header("Configuracao Respawn")]
    [Space(5)]
    public float tempo_respawn;
    private float tempo_atual;

    // Dados do Inimigo
    [Header("Configuracao Inimigo")]
    [Space(5)]
    public float velocidade_inimigos;

    void Start () {
        altura_tela = Screen.height;
        largura_tela = Screen.width;

        pos_x_min = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1)).x;
        pos_x_max = Camera.main.ScreenToWorldPoint(new Vector3(largura_tela, 0, 1)).x;
        pos_y_min = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1)).y;
        pos_y_max = Camera.main.ScreenToWorldPoint(new Vector3(0, altura_tela, 1)).y;

        pos_x_inimigo = Camera.main.ScreenToWorldPoint(Inimigos[0].transform.position).x;
        pox_y_inimigo = Camera.main.ScreenToWorldPoint(Inimigos[0].transform.position).y;

        tempo_atual = 0.0f;
    }
	
	void Update () {
        if(tempo_respawn != 0)
        {
            // Aumenta o tempo por frame
            tempo_atual += Time.deltaTime;

            // Se chegar no tempo desejado, cria um objeto e reseta o tempo 
            if (tempo_atual > tempo_respawn)
            {
                var random = Random.Range(pos_x_min, pos_x_max);
                var largura_inimigo_x = Inimigos[Random.Range(0, Inimigos.Length)].GetComponentInChildren<SpriteRenderer>().bounds.size.x;
                var altura_inimigo_y = Inimigos[Random.Range(0, Inimigos.Length)].GetComponentInChildren<SpriteRenderer>().bounds.size.y;

                float posicaoDeInstanciarX = random;

                if (random - (largura_inimigo_x / 2) < pos_x_min)
                {
                    posicaoDeInstanciarX += largura_inimigo_x / 2;
                }
                else if (random + (largura_inimigo_x / 2) > pos_x_max)
                {
                    posicaoDeInstanciarX -= largura_inimigo_x / 2;
                }
                Instantiate(Inimigos[Random.Range(0, Inimigos.Length)], (new Vector3(posicaoDeInstanciarX, pos_y_max + (altura_inimigo_y / 2), 1.0f)), (Quaternion.identity));
                tempo_atual = 0.0f;
            }
        }        
	}

    public float getVelocidade_inimigos()
    {
        return velocidade_inimigos;
    }

    public void setVelocidade_inimigos(float velocidade_inimigos)
    {
        this.velocidade_inimigos *= velocidade_inimigos;
    }

    public float getPos_y_min()
    {
        return pos_y_min;
    }

    public float getPos_y_max()
    {
        return pos_y_max;
    }

    public float getTempo_respawn()
    {
        return tempo_respawn;
    }

    public void setTempo_respawn(float tempo_respawn)
    {
        this.tempo_respawn *= tempo_respawn;
    }
}
