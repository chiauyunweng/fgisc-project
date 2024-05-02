using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeerMove : MonoBehaviour
{
    Vector3 direction;
    public Transform bodyPrefab;
    public List<Transform> bodies = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.7f;
        bodies.Add(transform);
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
        for (int i = bodies.Count - 1; i > 0; i--)
        {
            bodies[i].position = bodies[i - 1].position;
        }
        transform.Translate(direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gift"))
        {
            //bodies.Add(Instantiate(bodyPrefab));
            bodies.Add(Instantiate(bodyPrefab, transform.position, Quaternion.identity));
        }
        if (collision.CompareTag("obstacle"))
        {
           ResetStage();
        }
    }
    private void ResetStage()
    {
        transform.position = Vector3.zero;
        direction = Vector3.zero;

        for(int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }
        bodies.Add(transform);
    }
}
