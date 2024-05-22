using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public static int rand;
    public Sprite[] gift_img;
    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
  
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        rand = Random.Range(0, gift_img.Length);
        GetComponent<SpriteRenderer>().sprite = gift_img[rand];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
        if(other.tag == "obstacle")
        {
            RandomizePosition();
        }
    }
}
