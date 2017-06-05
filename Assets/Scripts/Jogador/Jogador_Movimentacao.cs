using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador_Movimentacao : MonoBehaviour {

    public GameObject Cenario;
    public float velocidade;
    public float pos_x;

    private bool canMove;

    void Start () {
        canMove = false;
	}
	
	void Update () {
		if(Input.touchCount > 0) {
            CheckPlayer();

            if (canMove) {
                MovePlayer();
            }
        }
	}

    private void CheckPlayer()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if(hit) {
            canMove = hit.transform.CompareTag("Player");
        } else {
            canMove = false;
        }
    }

    private void MovePlayer()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        this.transform.position = new Vector3(pos.x, this.transform.position.y, this.transform.position.z);
    }
}
