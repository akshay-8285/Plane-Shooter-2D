using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
   
    [SerializeField] private Renderer meshRenderer;
    [SerializeField] private float scrollSpeed = 0.5f;
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2 (0f , scrollSpeed * Time.deltaTime);
        
    }
}
