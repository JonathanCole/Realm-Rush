using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    void Start(){
        gameOverCanvas.enabled = false;
    }

    public void HandleGameOver(){
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        //FindObjectOfType<WeaponSwitcher>().enabled = false; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
