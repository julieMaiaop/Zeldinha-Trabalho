using UnityEngine;

public class orientar_local : MonoBehaviour
{
    public Transform espadaColetavel;  
    public Transform saida;           
    public GameObject seta;           

    public float distanciaMinima = 0.5f;
    private bool espadaColetada = false;

    void Update()
    {
        if (seta == null) return;

        
        Transform alvo = espadaColetada ? saida : espadaColetavel;

        if (alvo != null)
        {
           
            Vector3 direcao = (alvo.position - transform.position).normalized;
            seta.transform.position = transform.position + direcao * distanciaMinima;

            
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            seta.transform.rotation = Quaternion.Euler(0, 0, angulo);

            
            seta.SetActive(true);
        }
        else
        {
            seta.SetActive(false);
        }
    }

   
    public void ColetarEspada()
    {
        espadaColetada = true;
        
        seta.GetComponent<SpriteRenderer>().color = Color.green;
    }
}