using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject tutorialPanel;
    private GameObject gameButton;

    private void Awake()
    {
        tutorialPanel  = GameObject.Find("Tutorial Panel").gameObject;
        gameButton = GameObject.Find("Game").gameObject;

        tutorialPanel.SetActive(false);

    }
    public void PlayGame()
    {
        StartCoroutine("TutorialandthenGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator TutorialandthenGame()
    {
        gameButton.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        tutorialPanel.SetActive(true); 
        yield return new WaitForSeconds(7.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
