using UnityEngine;

public class pegar_smoke : MonoBehaviour
{
    public GameObject mascara;
    public GameObject textSmoke;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            mascara.SetActive(true);
            textSmoke.SetActive(true);
        }
    }
}
