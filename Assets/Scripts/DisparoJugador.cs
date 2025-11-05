using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public GameObject balaPrefab;
    public float velocidadBala = 70f;

    private Collider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
            Debug.Log("pium 🗣");
        }
    }

    void Disparar()
    {
        if (balaPrefab == null)
        {
            Debug.LogError("ERROR: El campo 'Bala Prefab' no está asignado.");
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direccion = (mousePos - transform.position).normalized;

        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = direccion * velocidadBala;
        }

        Collider2D balaCollider = bala.GetComponent<Collider2D>();

        if (playerCollider != null && balaCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, balaCollider);
        }
    }
}