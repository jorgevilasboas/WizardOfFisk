using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_Atirar : MonoBehaviour {

    // Objeto Tiro
    [Header("Prefab Tiro")]
    [Space(5)]
    public GameObject Tiro;
    public float Velocidade_Tiro;
    public float Tempo_Recarga;
    private float tempo_atual;
    public float Distancia_x;
    public float Distancia_y;

    // Objeto Jogador
    [Header("Prefab Jogador")]
    [Space(5)]
    public Transform Jogador;

    // Use this for initialization
    void Start () {
        tempo_atual = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        // Aumenta o tempo por frame
        tempo_atual += Time.deltaTime;

        // Se chegar no tempo desejado, cria um objeto e reseta o tempo 
        if (tempo_atual > Tempo_Recarga)
        {
            Instantiate(Tiro, (new Vector3(Jogador.position.x + Distancia_x, Jogador.position.y + Distancia_y, Jogador.position.z)), (Quaternion.identity));
            tempo_atual = 0.0f;
        }
    }

    public float getVelocidade_Tiro()
    {
        return Velocidade_Tiro;
    }

    public void setTempo_Recarga(float Tempo_Recarga)
    {
        this.Tempo_Recarga *= Tempo_Recarga;
    }
}
