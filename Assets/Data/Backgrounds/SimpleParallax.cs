using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleParallax : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float startXPos;
    [SerializeField] float endXPos;

    private void Start()
    {
        startXPos = gameObject.transform.position.x;
        endXPos = startXPos * -1;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        if (transform.position.x > endXPos)
        {
            transform.position = new Vector2(startXPos, transform.position.y);
        }
    }

}
