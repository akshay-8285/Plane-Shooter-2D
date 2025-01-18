using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CoinScript coinScript;
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    [SerializeField] private GameObject particle;
    
    private float minX, maxX;
    private float minY, maxY;
    private float padding = 0.8f;
    private float health = 20f;
    private float damage = 0f;
    private float fillAmount = 1f;

    void Start()
    {
        damage = fillAmount / health;
        FindBoudaries();
    }

   
    void Update()
    {
        float horizontal= Input.GetAxis("Horizontal")* Time.deltaTime * speed;
        float veritcal = Input.GetAxis("Vertical")* Time.deltaTime * speed;
        float newposX = Mathf.Clamp(transform.position.x + horizontal,minX,maxX);
        float newposY = Mathf.Clamp(transform.position.y + veritcal,minY,maxY);   
        transform.position = new Vector2(newposX , newposY );

        
           
        
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
            Destroy(coll.gameObject);
            if(health <= 0)
            {
                Destroy(gameObject);
                GameObject playerExplosen = Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(playerExplosen, 2f);

            }
            
            
        }
        if(coll.gameObject.tag == "Coin")
        {
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
