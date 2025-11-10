using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public float velocidad = 2f;
    public float tiempoEspera = 2f;
    public float distanciaSpawn = 10f;

    private GameObject jugador;
    private bool esperando = true;
    private float contador = 0f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador == null)
        {
            Debug.LogWarning("No se encontró el jugador en la escena.");
            return;
        }

        Vector2 offset = Random.insideUnitCircle.normalized * distanciaSpawn;
        transform.position = (Vector2)jugador.transform.position + offset;
    }

    void Update()
    {
        if (jugador == null)
        {
            jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador == null) return;
        }

        if (esperando)
        {
            contador += Time.deltaTime;
            if (contador >= tiempoEspera)
                esperando = false;
        }
        else
        {
            Vector2 posJugador = jugador.transform.position;
            Vector2 posEnemigo = transform.position;
            transform.position = Vector2.MoveTowards(posEnemigo, posJugador, velocidad * Time.deltaTime);
        }
    }
}
