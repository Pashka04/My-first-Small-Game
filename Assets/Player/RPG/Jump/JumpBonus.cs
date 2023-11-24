using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBonus : MonoBehaviour
{
    public float jumpBonus = 5.0f; // Бонус к высоте перемещения
    public float bonusDuration = 15.0f; // Продлжительность времени действия боонуса

    private PlayerController playerController; // Ссылка на скрипт управления игроком
    private float originalJumpForce; // Исходная высота прыжка игрока
    //public Image bonusIcon; // Иконка бонуса на экране

    void Start()
    {
        // Находим объект игрока и получаем ссылку на скрипт управления игроком
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            // Сохраняем исходную высоту прыжка
            originalJumpForce = playerController.GetJumpForce();
        }
        else
        {
            Debug.LogError("Не удалось найти объект игрока или скрипт управления игроком.");
        }
        //bonusIcon.enabled = false; // Начально скрываем иконку бонуса
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //// Показываем иконку бонуса
            //bonusIcon.enabled = true;

            // Если игрок подобрал бонус, запускаем корутину для временного увеличения силы прыжка
            StartCoroutine(ApplyJumpBonus());
            
        }
    }

    IEnumerator ApplyJumpBonus()
    {
        if (playerController != null)
        {
            // Увеличиваем силу прыжка на 15 секунд
            playerController.SetJumpForce(originalJumpForce + jumpBonus);
        }
        
        yield return new WaitForSeconds(bonusDuration);

        if (playerController != null)
        {
            // Возвращаем силу прыжка обратно к исходному значению
            playerController.SetJumpForce(originalJumpForce);
        }

        Destroy(gameObject);
        //// Скрываем иконку бонуса
        //bonusIcon.enabled = false;
    }
}
