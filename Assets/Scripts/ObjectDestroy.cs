using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject != null)
        {
            Destroy(coll.gameObject);

        }
        
    }
}
