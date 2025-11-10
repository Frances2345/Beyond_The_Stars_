using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject jugador;
    public float fuerzaDash = 20f;
    public float duracionDash = 0.3f;
    public float cooldown = 1f;

    private bool estaDasheando = false;
    private bool enCooldown = false;
    private Vector2 direccion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !estaDasheando && !enCooldown)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            direccion = new Vector2(h, v).normalized;

            if (direccion.magnitude == 0)
                direccion = Vector2.up;

            StartCoroutine(HacerDash());
        }
    }

    System.Collections.IEnumerator HacerDash()
    {
        estaDasheando = true;
        enCooldown = true;

        float tiempo = 0;
        while (tiempo < duracionDash)
        {
            jugador.transform.Translate((Vector3)direccion * fuerzaDash * Time.deltaTime);
            tiempo += Time.deltaTime;
            yield return null;
        }

        estaDasheando = false;
        yield return new WaitForSeconds(cooldown);
        enCooldown = false;
    }
}