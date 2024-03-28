using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCanvas : MonoBehaviour
{

    //[SerializeField] GameObject mainPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject enemySpawn;
    [SerializeField] GameObject enviroment;
    [SerializeField] AudioSource soundGame;
    [SerializeField] int enemyEntered = 3;
    int countEnemy = 0;


    // void Awake()
    // {
    //     enviroment.SetActive(false);
    //     enemySpawn.SetActive(false);
    // }


    void Update()
    {

    }

    public void StartGame()
    {
        StartCoroutine(PlayGame());
    }

    public void ManuGame()
    {
        Time.timeScale = 1;
        StartCoroutine(Menu());
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

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync("Game");
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync("MainScene");
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

    public void EnemyWhoentered()
    {
        countEnemy++;
        if (countEnemy == enemyEntered)
        {
            soundGame.Stop();
            enviroment.SetActive(false);
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
