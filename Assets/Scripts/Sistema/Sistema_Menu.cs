using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sistema_Menu : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Botao_Jogo_01()
    {
        SceneManager.LoadScene("Cena 04 - Jogo 01");
    }

    public void Botao_Creditos()
    {
        SceneManager.LoadScene("Cena 02 - Creditos");
    }

    public void Botao_Recorde()
    {
        SceneManager.LoadScene("Cena 03 - Recorde");
    }

    public void Botao_Sair()
    {
        Application.Quit();
    }

    public void Botao_Menu()
    {
        SceneManager.LoadScene("Cena 01 - Menu");
    }
}
