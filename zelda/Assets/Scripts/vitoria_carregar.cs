
using UnityEngine;
using UnityEngine.SceneManagement;

public class vitoria_carregar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("vitoria");
    }
}
