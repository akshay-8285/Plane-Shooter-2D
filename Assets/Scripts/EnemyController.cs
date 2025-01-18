using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform [] gunPoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject explosenPrefab;
    [SerializeField] private GameObject damageSparkel;
    [SerializeField] private GameObject coin;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bulletSound;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip explosenSound;
     private float health = 10f;
     private float damage = 0;
     private float barSize = 1f;

    void Start()
    {
        damage = barSize / health; // damage find kiya h jo h barsize 1 or health  10 to 1/10 = 0.1

        muzzleFlash.SetActive(false);
        StartCoroutine(EnemyFire());
    }

    
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        
    }
    public IEnumerator EnemyFire()
    {
        while (true)
        {
           yield return new WaitForSeconds(fireRate);
           Shoot();
           muzzleFlash.SetActive(true);
           yield return new WaitForSeconds(0.04f);
           muzzleFlash.SetActive(false);

        }
    }
    private void Shoot()
    {
        for (int i = 0; i < gunPoint.Length; i++)
        {
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);
            audioSource.PlayOneShot(bulletSound,0.5f);                 
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage();
            audioSource.PlayOneShot(damageSound);
            Destroy(collision.gameObject); // Destrtoy kiya player bullet ko jo enemy ke sath collide hua 
            GameObject sparkel = Instantiate(damageSparkel, collision.transform.position, Quaternion.identity);
            Destroy(sparkel, 0.5f);
             // sparkel effect ko instantiate kiya
            if(health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosenSound,Camera.main.transform.position,0.5f);
                Destroy(gameObject);
                GameObject enemyExplosen =Instantiate(explosenPrefab, transform.position, Quaternion.identity);
                Instantiate(coin, transform.position, Quaternion.identity);
                Destroy(enemyExplosen, 0.5f);
            }
            
        }
    }
    public void TakeDamage()
    {
        if(health >0) // health = 10 > 0 mtlb hamari health zero se badi h to damage le sakte hn 
        {        

            health -= 1f;        // halth me se 1 kam kiya mtlb health = 9 ban gai 
            barSize = barSize - damage;  // barsiz h hamara 1 to isme se minus kara humne damage mtlb 1 - 0.1 = 0.9
            healthbar.SetSize(barSize); // halthbar ka size set kara gh jo h 0.9 or ye kam hoga 1 me se 
            
        }
        
    }
     
}
