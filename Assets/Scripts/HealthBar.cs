using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform bar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
