using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int startBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    [SerializeField] TextMeshProUGUI displayBalance;
    
    void Awake() {
        currentBalance = startBalance;    
        UpdateDisplay();
    }

    public void Deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdrawl(int amount){
        currentBalance -= Mathf.Abs(amount);
        if(currentBalance <= 0){
            GetComponent<GameOver>().HandleGameOver();
            Debug.Log("Game Over");
        }
        UpdateDisplay();
    }

    void ReloadScene(){
        Scene index = SceneManager.GetActiveScene();
        SceneManager.LoadScene(index.buildIndex);
    }

    void UpdateDisplay(){
        displayBalance.text = "Gold: " + currentBalance;
    }
}
