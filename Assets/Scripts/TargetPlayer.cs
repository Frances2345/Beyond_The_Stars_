using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public GameObject jugador;
    public float velocidad = 2f;
    public float tiempoEspera = 20f;

    private bool llegoAlBorde = false;
    private bool esperando = false;
    private float contador = 0f;

    void Update()
    {
        if (jugador == null) return;

        if (!llegoAlBorde)
        {
            Vector3 borde = PosicionEnBordeCamara();
            transform.position = Vector3.MoveTowards(transform.position, borde, velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, borde) < 0.1f)
            {
                llegoAlBorde = true;
                esperando = true;
                contador = 0f;
            }
        }
        else if (esperando)
        {
            contador += Time.deltaTime;
            if (contador >= tiempoEspera)
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

    Vector3 PosicionEnBordeCamara()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        viewportPos.x = Mathf.Clamp01(viewportPos.x);
        viewportPos.y = Mathf.Clamp01(viewportPos.y);
        return Camera.main.ViewportToWorldPoint(viewportPos);
    }
}
