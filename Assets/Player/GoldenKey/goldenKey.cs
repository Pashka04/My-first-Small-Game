using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenKey : MonoBehaviour
{
    private bool isPickedUp = false; // ����������, �����������, ������ �� ���� �������

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            // ���� ����� ������� � ����� � ���� ��� �� ������, ��������� ����
            isPickedUp = true;
            gameObject.SetActive(false); // �������� ���� �� �����
        }
    }
    public bool IsPickedUp()
    {
        // ����� ��� ��������, ������ �� ���� �������
        return isPickedUp;
    }


}
