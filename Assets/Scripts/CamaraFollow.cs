using UnityEngine;

public class CamaraFollow: MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset;
    public float suavizado = 5f;

    void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 posicionDeseada = jugador.position + offset;
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);
        }
    }
}
