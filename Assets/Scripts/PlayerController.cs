using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CoinScript coinScript;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private float speed = 10f;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip destroyExplosenclip;
    [SerializeField] private AudioClip coinSound;
    
    private float minX, maxX;
    private float minY, maxY;
    private float padding = 0.8f;
    private float health = 20f;
    private float damage = 0f;
    private float fillAmount = 1f;

    void Start()
    {
        gameOverPanel.SetActive(false);
        damage = fillAmount / health;
        FindBoudaries();
    }

   
    void Update()
    {
        // float horizontal= Input.GetAxis("Horizontal")* Time.deltaTime * speed;
        // float veritcal = Input.GetAxis("Vertical")* Time.deltaTime * speed;
        // float newposX = Mathf.Clamp(transform.position.x + horizontal,minX,maxX);
        // float newposY = Mathf.Clamp(transform.position.y + veritcal,minY,maxY);   
        // transform.position = new Vector2(newposX , newposY );

        if(Input.GetMouseButton(0))
        {
            Vector2 newPose = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            transform.position = Vector2.Lerp(transform.position, newPose,speed * Time.deltaTime);
        }
           
        
    }
    public void FindBoudaries()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

        
    }
    
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("EnemyBullet"))
        {

            PlayerTakeDamage();
            audioSource.PlayOneShot(damageSound,0.5f);
            Destroy(coll.gameObject);
            if(health <= 0)
            {
                AudioSource.PlayClipAtPoint(destroyExplosenclip,Camera.main.transform.position,0.5f);
                Destroy(gameObject);
                GameObject playerExplosen = Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(playerExplosen, 2f);
                uiManager. GameOver();
                

            }
            
            
        }
        if(coll.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound);
            Destroy(coll.gameObject);
            coinScript.CoinCount();
            
        }
    }
    public void PlayerTakeDamage()
    {
        if(health > 0)
        {
            health -= 1f;
            fillAmount = fillAmount - damage;
            playerHealthBar.SetAmount(fillAmount);
            

            
        }
        

    }
    

}
