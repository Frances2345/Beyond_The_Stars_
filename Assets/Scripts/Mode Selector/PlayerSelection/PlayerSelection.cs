using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSelection: MonoBehaviour
{
    public void AM()
    {
        SceneManager.LoadScene("LV1");
    }

    public void EU()
    {
        SceneManager.LoadScene("");
        Debug.Log("proximamente");
    }

    public void AS()
    {
        SceneManager.LoadScene("");
        Debug.Log("proximamente");
    }

   
    public void Return()
    {
        SceneManager.LoadScene("ModeSelection");
    }
}
