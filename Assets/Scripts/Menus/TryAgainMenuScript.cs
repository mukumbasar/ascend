using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TryAgainMenuScript : MonoBehaviour
{
    private GameObject scoreText;

    private GameObject tryAgainPanel;
    private GameObject tryAgainScoreText;


    private void Awake()
    {

        
        tryAgainPanel = GameObject.Find("Try Again Panel");
        tryAgainPanel.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            scoreText = GameObject.Find("Score Text");
            tryAgainPanel.SetActive(true);
            tryAgainScoreText = GameObject.Find("Try Again Score Text");
            tryAgainScoreText.GetComponent<TextMeshProUGUI>().text = scoreText.GetComponent<TextMeshProUGUI>().text;
            scoreText.GetComponent<TextMeshProUGUI>().enabled = false;
            Time.timeScale = 0;

        }
    }

    public void RestartTheScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");

    }
}
