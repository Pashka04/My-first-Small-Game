using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenKey : MonoBehaviour
{
    private bool isPickedUp = false; // Переменная, указывающая, поднят ли ключ игроком

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            // Если игрок подошел к ключу и ключ еще не поднят, поднимаем ключ
            isPickedUp = true;
            gameObject.SetActive(false); // Скрываем ключ из сцены
        }
    }
    public bool IsPickedUp()
    {
        // Метод для проверки, поднят ли ключ игроком
        return isPickedUp;
    }


}
