using UnityEngine;

public class player_smoke : MonoBehaviour
{
    public GameObject smokeBombPrefab; 
    public Transform throwPoint;       
    public float throwCooldown = 2f;  
    private float lastThrowTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > lastThrowTime + throwCooldown)
        {
            Instantiate(smokeBombPrefab, throwPoint.position, throwPoint.rotation);
            lastThrowTime = Time.time;
        }
    }
}