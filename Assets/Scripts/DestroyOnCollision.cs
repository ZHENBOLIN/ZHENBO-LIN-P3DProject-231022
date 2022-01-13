using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameManager gameManager;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("DeathlyHallow"))
        {
            Destroy(collision.gameObject);
            gameManager.DeathlyHollowsNumber++;
        }
    }




}
