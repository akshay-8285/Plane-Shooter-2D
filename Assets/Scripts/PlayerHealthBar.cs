
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
   [SerializeField] private UnityEngine.UI.Image playerBar;
    void Start()
    {
        
    }

    
    void Update()
    {
       
        
    }
    public void SetAmount(float amount)
    {
        playerBar.fillAmount = amount;
    }
}
