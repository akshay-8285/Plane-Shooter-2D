using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // public CharacterDbs characterDbs;
    // public SpriteRenderer characterPrefab;
    //private int selectedOption = 0;
    [SerializeField] private CoinScript coinScript;
    [SerializeField] private PowerUpScript powerUpScript;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private float speed = 10f;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip destroyExplosenclip;
    [SerializeField] private AudioClip coinSound , powerUpSound;
    [SerializeField] private GameObject damageEffect;
    
    private float minX, maxX;
    private float minY, maxY;
    private float padding = 0.8f;
    private float health = 20f;
    private float damage = 0f;
    private float fillAmount = 1f;
    private Color green;
    private Color red;
    private Color yellow;

    void Start()
    {
        // if(!PlayerPrefs.HasKey("SelectedOption"))
        // {
        //     LoadGame();
        // }
        // else
        // {
        //     selectedOption = 0;
        // }
        // UpdateCharacter( selectedOption);
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
            audioSource.PlayOneShot(damageSound,0.2f);
            Destroy(coll.gameObject);
            if(health <= 0)
            {
                GameObject damageEffectObj = Instantiate(damageEffect, coll.transform.position, Quaternion.identity);
                Destroy(damageEffectObj, 2f);
                AudioSource.PlayClipAtPoint(destroyExplosenclip,Camera.main.transform.position,0.5f);
                Destroy(gameObject);
                GameObject playerExplosen = Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(playerExplosen, 2f);
                uiManager. GameOver();
                

            }
            
            
        }
        if(coll.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound,1f);
            Destroy(coll.gameObject);
            coinScript.CoinCount();
            
        }
        if(coll.gameObject.tag == "PowerUp")
        {
            audioSource.PlayOneShot(powerUpSound,1f);
            Destroy(coll.gameObject);
            StartCoroutine(powerUpScript.spawnPowerUp());
            playerHealthBar.SetAmount(1f);
            health = 20f;
            fillAmount = 1f;
            SetColor();
        }
    }
    public void PlayerTakeDamage()
    {
        if(health > 0)
        {
            health -= 1f;
            fillAmount = fillAmount - damage;
            playerHealthBar.SetAmount(fillAmount);
            SetColor();
            

            
        }
        

    }
    public void SetColor()
    {
        switch(health)
        {
            case 20:
                green = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                playerHealthBar.SetColor(green);
                break;
            case 10:
                yellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);
                playerHealthBar.SetColor(yellow);
                break;
            case 5:
                red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                playerHealthBar.SetColor(red);
                break;
        }
    }
    // public void UpdateCharacter(int selectedOption)
    // {
    //     Character character  = characterDbs.GetCharacter(selectedOption);
    //     characterPrefab.sprite = character.characterPrefab;
       
        
    // }
    // public void LoadGame()
    // {
    //     selectedOption = PlayerPrefs.GetInt("SelectedOption");
    // }

    

}
