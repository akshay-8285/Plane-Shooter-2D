using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private Button pauseButton,resumeButton,exitButton ,tryAgainButton;
    [SerializeField] private TMP_Text endText;
    void Start()
    {
        Time.timeScale = 1f;
        endText.gameObject.SetActive(false);
        levelCompletePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        pauseButton.onClick.AddListener(OnClickPauseButton);
        resumeButton.onClick.AddListener(OnClickResumeButton);
        exitButton.onClick.AddListener(OnClickExitButton);
        tryAgainButton.onClick.AddListener(OnClickTryAgainButton);
        

        
        
        
    }

    
    void Update()
    {
        
    }
    public  void  GameOver()
    {
        
        gameOverPanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void  OnClickPauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        
    }
    public void OnClickResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);

    }
    public void OnClickExitButton()
    {
        Application.Quit();
        Debug.Log("Click Exit Button");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Press Exit ");
    }
    public void OnClickTryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2f);
        endText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;
        levelCompletePanel.SetActive(true); 
        pauseButton.gameObject.SetActive(false);
        
    }
    
}
