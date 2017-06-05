using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo_Apresentacao : MonoBehaviour
{

    public Light luz;

    [Header("Cofiguração da luz.")]
    [Space(5)]
    public float velocidade = -0.002f;

    [Space(2)]
    [Range(0.1f, 7.9f)]
    public float intensidade_minima = 0.1f;

    [Space(2)]
    [Range(0.1f, 7.9f)]
    public float intensidade_maxima = 1.7f;

    [Header("Objetos")]
    public GameObject Imagem_1;
    public GameObject Imagem_2;

    private int contador = 0;

    // Use this for initialization
    void Start()
    {
        luz.intensity = 0.2f;
        Imagem_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //Modifica a intensidade
        luz.intensity += velocidade;

        if ((luz.intensity < intensidade_minima) || (luz.intensity > intensidade_maxima))
        {
            velocidade = velocidade * -1;
            contador++;
        }

        if (contador > 2)
        {
            Imagem_1.SetActive(false);
            Imagem_2.SetActive(true);
        }

        //Muda de Cena
        if (contador > 4)
        {
            SceneManager.LoadScene("Cena 05 - Musica");
        }
    }
}
