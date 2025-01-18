using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    void Start()
    {
        gameOverPanel.SetActive(false);
        
        
    }

    
    void Update()
    {
        
    }
    public  IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        gameOverPanel.SetActive(true);
    }
}
