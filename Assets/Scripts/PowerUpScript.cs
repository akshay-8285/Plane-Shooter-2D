using System.Collections;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private GameObject[] cloudPrefab;
    void Start()
    {
        StartCoroutine(spawnPowerUp());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator spawnPowerUp()
    {
        int randomDiretion = Random.Range(-2, 2);
        int randomIndex = Random.Range(0, cloudPrefab.Length);

        yield return new WaitForSeconds(3f);
        Instantiate(powerUpPrefab, new Vector2(Random.Range(-2, 2), transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Instantiate(cloudPrefab[randomIndex], new  Vector2(randomDiretion,transform.position.y), Quaternion.identity);
    }
}
