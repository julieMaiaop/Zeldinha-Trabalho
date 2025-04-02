using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pegar_smoke : MonoBehaviour
{

    public TMP_Text smokeText;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            smokeText.text = "Utilize Q para usar a granada";
        }
    }
   
}
