using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBonus : MonoBehaviour
{
    public int damageBonus = 1; // Бонус к урону
    public float bonusDuration = 15.0f; // Продолжительность времени действия бонуса

    private PlayerController playerController; // Ссылка на скрипт управления игроком
    private int attackDamage; // Исходный урон


    void Start()
    {
        // Находим объект игрока и получаем ссылку на скрипт управления игроком
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            attackDamage = playerController.GetAttack();
        }
        else
        {
            Debug.LogError("Не удалось найти объект игрока или скрипт управления игроком.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Если игрок подобрал бонус, запускаем корутину для временного увеличения урона
            StartCoroutine(ApplyDamageBonus());
        }
    }

    IEnumerator ApplyDamageBonus()
    {
        // Увеличиваем урон на время действия бонуса
        if (playerController != null)
        {
            playerController.SetAttack(attackDamage + damageBonus);
        }

        yield return new WaitForSeconds(bonusDuration);

        // Возвращаем урон обратно к исходному значению
        if (playerController != null)
        {
            playerController.SetAttack(attackDamage);
        }

        Destroy(gameObject);
    }
}
