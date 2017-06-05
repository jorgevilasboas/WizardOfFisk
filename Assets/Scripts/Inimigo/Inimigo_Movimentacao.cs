using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Movimentacao : MonoBehaviour
{

    // Dados do Inimigo
    [Header("Prefab do Proprio Inimigo")]
    public GameObject Inimigo;

    // Dados do Sistema
    private GameObject Sistema;
    private float velocidade;
    private float pos_y_min;
    private float altura_inimigo_y;

    void Start()
    {
        // Procura o objeto Sistema
        Sistema = GameObject.Find("Sistema");
        // Pega Velocidade do Sistema
        velocidade = Sistema.GetComponent<Sistema_Inimigos>().getVelocidade_inimigos();
        // Pega a Posicao Y da Camera
        pos_y_min = Sistema.GetComponent<Sistema_Inimigos>().getPos_y_min();
        // Pega a altura do objeto
        altura_inimigo_y = GetComponentInChildren<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Movimenta com uma velocidade
        transform.Translate(0, velocidade, 0);
        VerificaSePerdeu();
    }

    // Funcao para ver se chega no final da tela
    void VerificaSePerdeu()
    {
        if (transform.position.y - (altura_inimigo_y / 2) < pos_y_min)
        {
            int score = Sistema.GetComponent<Sistema_Pontuacao>().Score;
            PlayerPrefs.SetInt("score", score);
            Debug.Log(score);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cena 06 - GameOver");
            //Destroy(Inimigo);
        }
    }

    
    void OnTriggerEnter2D(Collider2D obj)
    {
        // Funcao se acertar o inimigo
        if(obj.gameObject.CompareTag("Tiro"))
        {
            Sistema_Pontuacao.Instance.SetScore(10);
            Destroy(Inimigo);
            Destroy(obj.gameObject);
            //DestroyEnemy(obj.GetComponent<Inimigo_Movimentacao>().gameObject);
        }
    }

    public void AdicionaPontuação() {
        Sistema.GetComponent<Sistema_Pontuacao>().Score += Sistema.GetComponent<Sistema_Pontuacao>().Score;
            

    }

    private void DestroyEnemy(GameObject inimigo)
    {
        Sistema_Pontuacao.Instance.SetScore(10);
        Destroy(this.gameObject);
    }
}