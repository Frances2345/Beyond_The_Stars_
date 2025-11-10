using UnityEngine;

public class TargetPlayerShooter : MonoBehaviour
{
    public GameObject balaPrefab;
    public float velocidad = 2f;
    public float tiempoEspera = 2f;
    public float tiempoEntreDisparos = 1f;
    public float velocidadBala = 8f;
    public float distanciaSpawn = 10f;

    private GameObject jugador;
    private bool esperando = true;
    private float contadorEspera = 0f;
    private float tiempoDisparo = 0f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador == null)
            return;

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
            contadorEspera += Time.deltaTime;
            tiempoDisparo += Time.deltaTime;

            if (tiempoDisparo >= tiempoEntreDisparos)
            {
                Disparar();
                tiempoDisparo = 0f;
            }

            if (contadorEspera >= tiempoEspera)
                esperando = false;
        }
        else
        {
            Vector3 direccion = (jugador.transform.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;

            tiempoDisparo += Time.deltaTime;
            if (tiempoDisparo >= tiempoEntreDisparos)
            {
                Disparar();
                tiempoDisparo = 0f;
            }
        }
    }

    void Disparar()
    {
        if (balaPrefab == null || jugador == null) return;

        Vector3 direccion = (jugador.transform.position - transform.position).normalized;
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.linearVelocity = direccion * velocidadBala;
    }
}
