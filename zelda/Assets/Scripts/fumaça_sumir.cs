using UnityEngine;

public class fumaça_sumir : MonoBehaviour
{
    public float duration = 5f;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, duration); 
    }

    void Update()
    {
       
        if (sprite != null)
        {
            Color color = sprite.color;
            color.a -= Time.deltaTime / duration;
            sprite.color = color;
        }
    }
}