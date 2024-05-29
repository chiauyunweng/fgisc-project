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
    int point = GameManger.Instance.score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isJumping==false)
        {
            rb.velocity = new Vector2(0, jump);
            isJumping=true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping=false;
        if(collision.gameObject.tag == "tree")
        {
            point--;
            giftText.text = "ÉúÃüÖµ" + point;
            GameManger.Instance.score = point;
            if (point == 0)
            {
                gm.Gameover();
            }


        }
    }
}
