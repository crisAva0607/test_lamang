using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeepney : MonoBehaviour
{
    public GameObject player;
    public GameObject vehicle;

    private bool isRiding = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRiding = true;
            player.transform.parent = vehicle.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRiding = false;
            player.transform.parent = null;
        }
    }

    void Update()
    {
        if (isRiding)
        {
            // Add your control logic here
        }
    }
}
