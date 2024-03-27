using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 5f; // Velocidade de movimento do inimigo

    private void Start()
    {
        // Inicia o movimento do inimigo
        moveEnemy();
    }

    private void moveEnemy()
    {
        // Movimento horizontal cont�nuo
        InvokeRepeating("moveHorizontal", 0f, 2f);
    }

    private void moveHorizontal()
    {
        // Movimento horizontal do inimigo
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto de colis�o � o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Implemente a l�gica para danificar o jogador aqui
            Debug.Log("O jogador colidiu com o inimigo!");
        }
    }
}
