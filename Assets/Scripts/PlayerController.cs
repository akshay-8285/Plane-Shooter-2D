using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    [SerializeField] private float speed = 0.2f;
    void Start()
    {
        
    }

   
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float newpos = transform.position.x + horizontal  * Time.deltaTime * speed;
        transform.position = new Vector2(newpos , transform.position.y );

        
           
        
    }
}
