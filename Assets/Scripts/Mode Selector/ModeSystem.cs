using UnityEngine;
using UnityEngine.SceneManagement;


public class ModeSystem : MonoBehaviour
{
    public void Hystory()
    {
        SceneManager.LoadScene("PlayerSelection");
    }

    public void Titan()
    {
        Debug.Log("proximamente");
        SceneManager.LoadScene("");
    }

    public void Rush()
    {
        SceneManager.LoadScene("");
        Debug.Log("proximamente");
    }

    public void Test()
    {
        SceneManager.LoadScene("");
        Debug.Log("proximamente");
    }
    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
}
