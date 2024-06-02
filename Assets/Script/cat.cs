using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static allcontrol;

public class cat : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float jump;
    bool isJumping;
    public Gamemanger gm;
    [SerializeField] private Text giftText;
    [SerializeField] public AudioSource touchTree;
    int point = GameManger.Instance.score;

    void Start()
    {
        giftText.text = ": " + point;
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow)) && isJumping==false)
        {
            rb.velocity = new Vector2(0, jump);
            isJumping=true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping=false;
        if(collision.tag == "tree")
        {
            touchTree.Play();
            point--;
            giftText.text = ": " + point;
            GameManger.Instance.score = point;
            if (point == 0)
            {
                gm.Gameover();
            }
        }
    }
}
