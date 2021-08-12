using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReloadScene(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
