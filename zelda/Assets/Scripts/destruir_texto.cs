using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir_texto : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(gameObject);
        }
    }

}
