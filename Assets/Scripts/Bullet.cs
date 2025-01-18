using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        
        
    }
}
