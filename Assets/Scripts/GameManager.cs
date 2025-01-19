using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(1);
        
    }
    public void OnClickExitButton()
    {
        Application.Quit();
        Debug.Log("Click Exit Button");
    }
    public void OnClickNextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        


    }
    
}
