using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject triggerObject1;
    public GameObject triggerObject2;
    public GameObject triggerObject3;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerPosition.position);

        if (distance < 15.0f) // Если игрок находится близко к объекту с триггером
        {
            triggerObject1.SetActive(true); // Включаем триггер
            triggerObject2.SetActive(true);
            triggerObject3.SetActive(true);
        }
        else
        {
            triggerObject1.SetActive(false); // Выключаем триггер
            triggerObject2.SetActive(false);
            triggerObject3.SetActive(false);
        }
    }

}
