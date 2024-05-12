using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeerMove : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> bodyParts;
    public Transform segmentPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bodyParts = new List<Transform>();
        bodyParts.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        for (int i = bodyParts.Count - 1; i > 0; i--)
        {
            bodyParts[i].position = bodyParts[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );


    }

    private void ResetState()
    {
        for(int i = 1; i < bodyParts.Count; i++)
        {
            Destroy(bodyParts[i].gameObject);
        }
        bodyParts.Clear();
        bodyParts.Add(this.transform);

        this.transform.position = new Vector3(0,0,0);
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = bodyParts[bodyParts.Count - 1].position;

        bodyParts.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gift")
        {
            Grow();
        }else if(other.tag == "obstacle")
        {
            ResetState();
        }
    }
}
