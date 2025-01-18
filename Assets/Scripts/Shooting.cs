using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject playerbullet;
    [SerializeField] private GameObject muzzleLeFlash;
    [SerializeField] private Transform [] playerGunPoint;
    void Start()
    {
        muzzleLeFlash.SetActive(false);

        StartCoroutine(Fire());
        
    }

    
    void Update()
    {
        
        
    }

    private IEnumerator Fire()
    {
       
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            PlayerShooting();
            muzzleLeFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            muzzleLeFlash.SetActive(false);
            
            

        }
            
        
    }
    public void PlayerShooting()
    {
        for(int i = 0; i< playerGunPoint.Length; i++)
        {
            Instantiate(playerbullet , playerGunPoint[i].position, Quaternion.identity);
        }
    }
}
