using UnityEngine;

public class pegar_smoke : MonoBehaviour
{
    public GameObject mascara;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            mascara.SetActive(true); 
        }
    }
}
