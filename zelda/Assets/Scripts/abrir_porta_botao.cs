using UnityEngine;

public class abrir_porta_botao : MonoBehaviour
{
    public GameObject porta;
    private bool jogadorPerto = false;
    public GameObject E;

    void Update()
    {
        
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(porta);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorPerto = true;
            E.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorPerto = false;
            E.SetActive(false);
        }
    }
}
