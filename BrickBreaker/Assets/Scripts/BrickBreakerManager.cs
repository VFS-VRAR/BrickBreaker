using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickBreakerManager : MonoBehaviour
{
    [SerializeField] private GameObject looseScreen;
    [SerializeField] private GameObject wonScreen;
    public static int numberOfBricks = 35;
    private bool wonGame;
    private bool looseGame;

    private void Update()
    {
        if((wonGame || looseGame) && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            numberOfBricks = 35;
            SceneManager.LoadScene("SampleScene");
        }

        if(numberOfBricks == 0)
        {
            WonGame();
        }
    }
    public void LooseGame()
    {
        looseScreen.SetActive(true);
        looseGame = true;

        Time.timeScale = 0;
    }

    public void WonGame()
    {
        wonScreen.SetActive(true);
        wonGame = true;

        Time.timeScale = 0;
    }
}
