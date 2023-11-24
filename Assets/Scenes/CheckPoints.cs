using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Transform player;
    public int index;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        if (DataContenier.checkpointIndex == index)
        {
            player.position = transform.position;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (index > DataContenier.checkpointIndex)
            {
                DataContenier.checkpointIndex = index;
            }
           
        }
    }

}

