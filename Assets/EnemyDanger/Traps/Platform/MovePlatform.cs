using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector2 dir;
    public float speed = 3f;
    public bool MoveY = false;
    private bool MoveUP = true;

    bool moveingRight = true;

    private float distanceXright;
    private float distanceXleft;
    private float distanceYup;
    private float distanceYdown;


    private void Start()
    {
        distanceXright = transform.position.x + dir.x;
        distanceXleft = transform.position.x - dir.x;
        distanceYup = transform.position.y + dir.y;
        distanceYdown = transform.position.y - dir.y;


    }


    void Update()
    {
        if (transform.position.x > distanceXright)
        {
            moveingRight = false;

        }
        else if (transform.position.x < distanceXleft)
        {
            moveingRight = true;
        }
        if (transform.position.y > distanceYup)
        {
            MoveUP = false;

        }
        else if (transform.position.y < distanceYdown)
        {
            MoveUP = true;
        }     
            
        if (!MoveY)
        {
            if (moveingRight)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

            }
            else
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        }
        else
        {
           if (MoveUP)
           {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
           }
           else 
           {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
           }
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
