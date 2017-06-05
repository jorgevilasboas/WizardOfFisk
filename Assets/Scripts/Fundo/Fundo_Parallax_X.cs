using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundo_Parallax_X : MonoBehaviour {

    public float velocidade;
    public float altura_cenario;
    public float pos_y_min;

    // Dados do Sistema
    private GameObject Sistema;
    
    void Start () {
        // Procura o objeto Sistema
        Sistema = GameObject.Find("Sistema");
        // Pega Velocidade do Sistema
        pos_y_min = Sistema.GetComponent<Sistema_Inimigos>().getPos_y_min();
        altura_cenario = GetComponentInChildren<SpriteRenderer>().bounds.size.y;
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= pos_y_min - altura_cenario)
        {
            transform.position = new Vector3(0, altura_cenario-1, 11);
        }
        transform.position = transform.position + Vector3.up * velocidade * Time.deltaTime * -1;
	}
}
