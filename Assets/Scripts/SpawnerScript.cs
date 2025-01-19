using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    [SerializeField] private GameObject [] enemyPrefab;
    [SerializeField] private int enemyspawn = 5;
    [SerializeField] private float eneSpawnTime;
    private bool lastEnemySpawn = false;
    private bool gameover = false;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover && lastEnemySpawn&& FindAnyObjectByType<EnemyController>()==null)
        {
            StartCoroutine(uiManager.LevelComplete());
        }
        
    }
    public IEnumerator SpawnEnemy()
    {
        
        for(int i = 0; i < enemyspawn; i++)
        {
            yield return new WaitForSeconds(eneSpawnTime);
            int randomDiretion = Random.Range(-2, 2);
            int randomIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomIndex], new Vector2(randomDiretion, transform.position.y), Quaternion.identity);
            Debug.Log("Enemy Spawned");
            
            

        }
        lastEnemySpawn = true;
            
        
        
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "CheckPoint")
        {
            Debug.Log("CheckPoint");
            StartCoroutine(SpawnEnemy());
        }
    }
}
