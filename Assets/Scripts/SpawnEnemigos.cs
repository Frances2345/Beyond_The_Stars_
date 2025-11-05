using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public Transform jugador;
    public float distanciaExtra = 2f;
    public float tiempoEntreSpawns = 2f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tiempoEntreSpawns)
        {
            AstroTrooperSpawn();
            timer = 0f;
        }
    }

    void AstroTrooperSpawn()
    {
        if (enemigoPrefab == null || jugador == null)
        {
            Debug.LogError("ERROR: Prefab de enemigo o referencia del jugador no asignada en SpawnEnemigos.");
            return;
        }

        Debug.Log("llego un astro trooper");

        Vector3 position = jugador.position;

        Vector3 esquinaInferiorIzq = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 esquinaSuperiorDer = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        float xMin = esquinaInferiorIzq.x - distanciaExtra;
        float xMax = esquinaSuperiorDer.x + distanciaExtra;
        float yMin = esquinaInferiorIzq.y - distanciaExtra;
        float yMax = esquinaSuperiorDer.y + distanciaExtra;

        int borde = Random.Range(0, 4);
        Vector3 spawnPos = Vector3.zero;

        switch (borde)
        {
            case 0:
                spawnPos = new Vector3(xMin, Random.Range(yMin, yMax), 0);
                break;
            case 1:
                spawnPos = new Vector3(xMax, Random.Range(yMin, yMax), 0);
                break;
            case 2:
                spawnPos = new Vector3(Random.Range(xMin, xMax), yMin, 0);
                break;
            case 3:
                spawnPos = new Vector3(Random.Range(xMin, xMax), yMax, 0);
                break;
        }

        Instantiate(enemigoPrefab, spawnPos, Quaternion.identity);

    
    }

}