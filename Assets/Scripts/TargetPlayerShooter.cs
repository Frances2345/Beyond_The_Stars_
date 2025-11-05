using UnityEngine;

public class TargetPlayerShooter : MonoBehaviour
{
    public GameObject jugador;
    public GameObject balaPrefab;
    public float velocidad = 2f;
    public float tiempoEspera = 20f;
    public float tiempoEntreDisparos = 1f;
    public float velocidadBala = 8f;

    private bool llegoAlBorde = false;
    private bool esperando = false;
    private float contadorEspera = 0f;
    private float tiempoDisparo = 0f;

    void Update()
    {
        if (jugador == null)
        {
            GameObject jugadorObj = GameObject.Find("Player");
            if (jugadorObj != null)
            {
                jugador = jugadorObj;
                Debug.Log(name + ": jugador asignado automáticamente -> " + jugador.name);
            }
            else
            {
                Debug.LogWarning(name + ": No se encontró un objeto llamado 'Player' en la escena.");
            }
        }


        if (!llegoAlBorde)
        {
            Vector3 borde = PosicionEnBordeCamara();
            transform.position = Vector3.MoveTowards(transform.position, borde, velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, borde) < 0.1f)
            {
                llegoAlBorde = true;
                esperando = true;
                contadorEspera = 0f;
            }
        }
        else if (esperando)
        {
            contadorEspera += Time.deltaTime;
            tiempoDisparo += Time.deltaTime;

            if (tiempoDisparo >= tiempoEntreDisparos)
            {
                Disparar();
                tiempoDisparo = 0f;
            }

            if (contadorEspera >= tiempoEspera)
            {
                esperando = false;
            }
        }
        else
        {
            Vector3 direccion = (jugador.transform.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }

    void Disparar()
    {
        if (balaPrefab != null && jugador != null)
        {
            Vector3 direccion = (jugador.transform.position - transform.position).normalized;
            GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direccion * velocidadBala;
            }


        }
    }

    Vector3 PosicionEnBordeCamara()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        viewportPos.x = Mathf.Clamp01(viewportPos.x);
        viewportPos.y = Mathf.Clamp01(viewportPos.y);
        return Camera.main.ViewportToWorldPoint(viewportPos);
    }
}
