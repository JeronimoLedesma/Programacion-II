using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public Vector2 velocidadInicial;
    private Rigidbody2D rb;
    bool seMuve;
    public GameObject gameOver;
    public GameObject winScreen;
    public TMPro.TextMeshProUGUI puntaje;
    public int puntos;
    void Start()
    {
        puntos = 0;
        puntaje.text = puntos.ToString();
        rb = GetComponent<Rigidbody2D>();
        seMuve = false;
        gameOver.SetActive(false);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!seMuve)
        {
            rb.velocity = velocidadInicial;
            seMuve = true;
        }
        Win();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            puntos++;
            puntaje.text = puntos.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("GameOver"))
        {
            rb.velocity = Vector2.zero;
            gameOver.SetActive(true);
        }
    }

    void Win()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0) 
        { 
            rb.velocity = Vector2.zero;
            winScreen.SetActive(true);
        }
    }
}
