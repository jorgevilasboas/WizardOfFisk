using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro_Movimentacao : MonoBehaviour {
    
    // Dados do Sistema
    private GameObject Sistema;
    private float velocidade;
    private float pos_y_max;
    public GameObject Tiro;

    void Start () {
        // Procura o objeto Sistema
        Sistema = GameObject.Find("Sistema");
        // Pega Velocidade do Sistema
        velocidade = Sistema.GetComponent<Sistema_Atirar>().getVelocidade_Tiro();
        // Pega o limite do tiro do Sistema
        pos_y_max = Sistema.GetComponent<Sistema_Inimigos>().getPos_y_max();
    }
	
	void Update () {
        transform.Translate(0, velocidade, 0);
        VerificaSePassou();
    }

    // Destroi tiro se chegar no final da tela
    void VerificaSePassou()
    {
        if (transform.position.y > pos_y_max)
        {
            Destroy(Tiro);
        }
    }
}
