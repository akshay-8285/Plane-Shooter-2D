using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinScript : MonoBehaviour
{
    
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text coinCollect;
    int coinCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    
    public void CoinCount()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
        coinCollect.text = "COINS :" + coinCount.ToString();

    }

}
