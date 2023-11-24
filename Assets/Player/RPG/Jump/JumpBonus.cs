using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBonus : MonoBehaviour
{
    public float jumpBonus = 5.0f; // ����� � ������ �����������
    public float bonusDuration = 15.0f; // ���������������� ������� �������� �������

    private PlayerController playerController; // ������ �� ������ ���������� �������
    private float originalJumpForce; // �������� ������ ������ ������
    //public Image bonusIcon; // ������ ������ �� ������

    void Start()
    {
        // ������� ������ ������ � �������� ������ �� ������ ���������� �������
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            // ��������� �������� ������ ������
            originalJumpForce = playerController.GetJumpForce();
        }
        else
        {
            Debug.LogError("�� ������� ����� ������ ������ ��� ������ ���������� �������.");
        }
        //bonusIcon.enabled = false; // �������� �������� ������ ������
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //// ���������� ������ ������
            //bonusIcon.enabled = true;

            // ���� ����� �������� �����, ��������� �������� ��� ���������� ���������� ���� ������
            StartCoroutine(ApplyJumpBonus());
            
        }
    }

    IEnumerator ApplyJumpBonus()
    {
        if (playerController != null)
        {
            // ����������� ���� ������ �� 15 ������
            playerController.SetJumpForce(originalJumpForce + jumpBonus);
        }
        
        yield return new WaitForSeconds(bonusDuration);

        if (playerController != null)
        {
            // ���������� ���� ������ ������� � ��������� ��������
            playerController.SetJumpForce(originalJumpForce);
        }

        Destroy(gameObject);
        //// �������� ������ ������
        //bonusIcon.enabled = false;
    }
}
