using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBanlance;

    public int CurrentBanlance { get { return currentBanlance; } }

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake()
    {
        currentBanlance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBanlance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBanlance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBanlance < 0)
        {
            //Lose the game
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBanlance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
