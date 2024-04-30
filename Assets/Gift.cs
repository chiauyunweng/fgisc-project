using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public Collider2D foodArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector3(Random.Range(foodArea.bounds.min.x, foodArea.bounds.max.x),
            Random.Range(foodArea.bounds.min.y, foodArea.bounds.max.y), 0);
    }
}
