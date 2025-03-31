using UnityEngine;

public class Cura : MonoBehaviour
{
    public int vidaDoJogador = 100;
    public int vidaMaxima = 100;
    public int pocaoCura = 20;
    public int numeroPocoes = 3;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            UsarPocao();
        }
    }

    void UsarPocao()
    {
        
        if (numeroPocoes > 0 && vidaDoJogador < vidaMaxima)
        {
            vidaDoJogador += pocaoCura;
            numeroPocoes--;

            
            if (vidaDoJogador > vidaMaxima)
            {
                vidaDoJogador = vidaMaxima;
            }

            Debug.Log("Conseguiu usar, vida: " + vidaDoJogador + ", poções restantes: " + numeroPocoes);
        }
        else
        {
            Debug.Log("Nao deuu");
        }
    }   
}
