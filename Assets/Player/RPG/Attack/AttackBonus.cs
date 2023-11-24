using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBonus : MonoBehaviour
{
    public int damageBonus = 1; // ����� � �����
    public float bonusDuration = 15.0f; // ����������������� ������� �������� ������

    private PlayerController playerController; // ������ �� ������ ���������� �������
    private int attackDamage; // �������� ����


    void Start()
    {
        // ������� ������ ������ � �������� ������ �� ������ ���������� �������
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            attackDamage = playerController.GetAttack();
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
            // ���� ����� �������� �����, ��������� �������� ��� ���������� ���������� �����
            StartCoroutine(ApplyDamageBonus());
        }
    }

    IEnumerator ApplyDamageBonus()
    {
        // ����������� ���� �� ����� �������� ������
        if (playerController != null)
        {
            playerController.SetAttack(attackDamage + damageBonus);
        }

        yield return new WaitForSeconds(bonusDuration);

        // ���������� ���� ������� � ��������� ��������
        if (playerController != null)
        {
            playerController.SetAttack(attackDamage);
        }

        Destroy(gameObject);
    }
}
