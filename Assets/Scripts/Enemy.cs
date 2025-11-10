using UnityEngine;

public class Enemy : Entity
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalaJugador"))
        {
            Morir();
        }
    }

}

