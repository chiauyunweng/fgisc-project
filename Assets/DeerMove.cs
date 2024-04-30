using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerMove : MonoBehaviour
{
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direction);
    }
}
