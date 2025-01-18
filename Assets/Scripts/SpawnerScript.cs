using System.Collections;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject [] enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            int randomDiretion = Random.Range(-2, 2);
            int randomIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomIndex], new Vector2(randomDiretion, transform.position.y), Quaternion.identity);
            Debug.Log("Enemy Spawned");
        }
        
    }
}
