using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movementSpeed;
    public float startPositon;
    public float endPositon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
