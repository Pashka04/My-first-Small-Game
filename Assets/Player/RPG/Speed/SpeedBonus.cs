using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    public float speedBonus = 5.0f; // ����� � �������� �����������
    public float bonusDuration = 15.0f; // ����������������� ������� �������� ������

    private PlayerController playerController; // ������ �� ������ ���������� �������
    private float originalSpeed; // �������� �������� �����������

    void Start()
    {
        // ������� ������ ������ � �������� ������ �� ������ ���������� �������
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            // ��������� �������� �������� �����������
            originalSpeed = playerController.GetMoveSpeed();
        }
        else
        {
            Debug.LogError("�� ������� ����� ������ ������ ��� ������ ���������� �������.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���� ����� �������� �����, ��������� �������� ��� ���������� ���������� ��������
            StartCoroutine(ApplySpeedBonus());
        }
    }

    IEnumerator ApplySpeedBonus()
    {
        // ����������� �������� �� ����� �������� ������
        if (playerController != null)
        {
            playerController.SetMoveSpeed(originalSpeed + speedBonus);
        }

        yield return new WaitForSeconds(bonusDuration);

        // ���������� �������� ������� � ��������� ��������
        if (playerController != null)
        {
            playerController.SetMoveSpeed(originalSpeed);
        }

        Destroy(gameObject);
    }
}
