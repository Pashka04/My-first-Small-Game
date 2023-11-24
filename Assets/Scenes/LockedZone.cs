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
            // ���� � ������ ���� ����, ��������� box collider
            lockedCollider.enabled = false;
        }
        else
        {
            // ���� � ������ ���� �����, �������� box collider
            lockedCollider.enabled = true;
        }
    }

}   

















