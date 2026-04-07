using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            PlatformControls p = col.GetComponent<PlatformControls>();
            p.CoinsCollected++;
            Debug.Log(p.CoinsCollected);
            Destroy(this.gameObject);
        }
    }
}
