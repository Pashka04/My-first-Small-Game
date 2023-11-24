using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float smoothTime;

    [SerializeField] private Transform player;


    public void FixedUpdate()
    {
        Vector3 position = GetComponent<Transform>().position;

        position.x = Mathf.Lerp(position.x, player.position.x, smoothTime);
        position.y = Mathf.Lerp(position.y, player.position.y, smoothTime);

        GetComponent<Transform>().position = position;
    }
}
