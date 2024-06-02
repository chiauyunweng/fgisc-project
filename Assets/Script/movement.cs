using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float movementSpeed=10f;
    public float startPositon;
    public float endPositon;
    private float startTime;
    private float acceleration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //float elapsedTime = Time.time - startTime;
        //Debug.Log(elapsedTime);
        //if (elapsedTime >= 15f)
        //{
        //    movementSpeed = 15f;
        //    Debug.Log(movementSpeed);
        //}

        transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= endPositon)
        {
            if(gameObject.tag == "tree")
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector2(startPositon, transform.position.y);

            }
        }
    }
}
