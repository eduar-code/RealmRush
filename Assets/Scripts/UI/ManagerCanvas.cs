using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCanvas : MonoBehaviour
{
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject enemySpawn;
    [SerializeField] GameObject enviroment;
    [SerializeField] GameObject objectGold;
    [SerializeField] TextMeshProUGUI enemyTower;
    [SerializeField] TextMeshProUGUI enemyHealth;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource soundGame;
    [SerializeField] Animator enemyattack;
    [SerializeField] int enemyEntered = 3;
    [SerializeField] float remainingTime;
    int countEnemy;
    int pre_enemyhealt;

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            SetTimer();
        }
    }

    public void SetTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0 && countEnemy < enemyEntered)
        {
            remainingTime = 0;
            // nextLevel
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int secods = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = " Time: " + string.Format("{0:00}:{1:00}", minutes, secods);
    }

    public void GameOver()
    {
        soundGame.Stop();
        enviroment.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void EnemyWhoentered()
    {
        enemyTower.text = "Enemy in tower: " + ++countEnemy;
        enemyattack.SetTrigger("attack");

        if (countEnemy >= enemyEntered)
        {
            GameOver();
        }
    }

    public void DisplayEnemyHealth(int val)
    {
        if (val > pre_enemyhealt)
        {
            enemyHealth.text = "Enemy Health: " + val.ToString();
            pre_enemyhealt = val;
        }
    }

    public void AddWithdrawGold(string val, int amount)
    {
        if (val == "--")
        {
            objectGold.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            objectGold.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }
        objectGold.GetComponent<Animator>().SetTrigger("addGold");
        objectGold.GetComponent<TextMeshProUGUI>().text = val + " " + amount;
    }

    public void LoadSceneGame(string name)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadGame(name));
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        StartCoroutine(Restar());
    }

    public void ExitGame()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator LoadGame(string name)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(name);
    }

    IEnumerator Restar()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }

}
