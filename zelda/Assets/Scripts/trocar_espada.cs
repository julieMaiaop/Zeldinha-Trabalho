using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class trocar_espada : MonoBehaviour
{
    public Sprite spriteNormal;
    public Sprite spriteMelhorada;
    public GameObject espada;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteNormal;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Espada"))
        {
            sr.sprite = spriteMelhorada;
            FindObjectOfType<orientar_local>().ColetarEspada();
        }
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            espada.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if(Input.GetMouseButtonUp(0))
        {
            espada.GetComponent<SpriteRenderer>().color = Color.white;
        }


    }

}