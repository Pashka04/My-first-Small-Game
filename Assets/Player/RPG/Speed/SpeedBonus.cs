using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    public float speedBonus = 5.0f; // Бонус к скорости перемещения
    public float bonusDuration = 15.0f; // Продолжительность времени действия бонуса

    private PlayerController playerController; // Ссылка на скрипт управления игроком
    private float originalSpeed; // Исходная скорость перемещения

    void Start()
    {
        // Находим объект игрока и получаем ссылку на скрипт управления игроком
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            // Сохраняем исходную скорость перемещения
            originalSpeed = playerController.GetMoveSpeed();
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
            // Если игрок подобрал бонус, запускаем корутину для временного увеличения скорости
            StartCoroutine(ApplySpeedBonus());
        }
    }

    IEnumerator ApplySpeedBonus()
    {
        // Увеличиваем скорость на время действия бонуса
        if (playerController != null)
        {
            playerController.SetMoveSpeed(originalSpeed + speedBonus);
        }

        yield return new WaitForSeconds(bonusDuration);

        // Возвращаем скорость обратно к исходному значению
        if (playerController != null)
        {
            playerController.SetMoveSpeed(originalSpeed);
        }

        Destroy(gameObject);
    }
}
