using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuSystemTest : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("ModeSelection");
    }

    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
