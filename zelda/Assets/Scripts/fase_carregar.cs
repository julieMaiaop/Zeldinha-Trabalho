using UnityEngine;
using UnityEngine.SceneManagement;

public class fase_carregar : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Dungeon 2");
    }
}
