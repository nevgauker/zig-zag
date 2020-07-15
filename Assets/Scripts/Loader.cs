using UnityEngine;
using UnityEngine.SceneManagement;


public class Loader : MonoBehaviour
{
    public void loadSettings(){
        SceneManager.LoadScene("SettingsScene");
    }
     public void loadMain(){
        SceneManager.LoadScene("MainScene");
    }
}
