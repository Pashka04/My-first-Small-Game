using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedZone : MonoBehaviour
{
    public goldenKey key;
    private Collider2D lockedCollider;

    private void Start()
    {
        lockedCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (key.IsPickedUp())
        {
            // если у игрока есть ключ, отключает box collider
            lockedCollider.enabled = false;
        }
        else
        {
            // если у игрока нету ключа, включает box collider
            lockedCollider.enabled = true;
        }
    }

}   

















