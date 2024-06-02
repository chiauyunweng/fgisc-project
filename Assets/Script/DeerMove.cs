using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using static allcontrol;


public class DeerMove : MonoBehaviour
{
    
    private Vector2 direction = Vector2.zero;
    private Vector2 last_direction = Vector2.zero;
    private List<Transform> bodyParts;
    public Transform[] segmentPrefab;
    // Start is called before the first frame update
    //[SerializeField] Canvas GameOverCanvas;
    [SerializeField] private Text giftText;
    [SerializeField] public AudioSource touchGift;
    [SerializeField] public AudioSource touchObstacle;
    int point=GameManger.Instance.score;

    void Start()
    {
        Time.timeScale = 1;
        bodyParts = new List<Transform>();
        bodyParts.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        last_direction = direction;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(last_direction == Vector2.down)
            {
                if(bodyParts.Count == 1)
                {
                    direction = Vector2.up;
                }
                else
                {
                    ResetState();
                    SceneManager.LoadScene("gameOver");
                }
            }
            else
            {
                direction = Vector2.up;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (last_direction == Vector2.up)
            {
                if(bodyParts.Count == 1)
                {
                    direction = Vector2.down;
                }
                else
                {
                    ResetState();
                    SceneManager.LoadScene("gameOver");
                }
                
            }
            else
            {
                direction = Vector2.down;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (last_direction == Vector2.right)
            {
                if(bodyParts.Count == 1)
                {
                    direction = Vector2.left;
                }
                else
                {
                    ResetState();
                    SceneManager.LoadScene("gameOver");
                }
            }
            else
            {
                direction = Vector2.left;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (last_direction == Vector2.left)
            {
                if(bodyParts.Count == 1)
                {
                    direction = Vector2.right;
                }
                else
                {
                    ResetState();
                    SceneManager.LoadScene("gameOver");
                }
            }
            else
            {
                direction = Vector2.right;
            }
            
        }
    }

    void FixedUpdate()
    {
        for (int i = bodyParts.Count - 1; i > 0; i--)
        {
            bodyParts[i].position = bodyParts[i - 1].position;
        }
        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y,
            0.0f
        );


    }

    private void ResetState()
    {
        for (int i = 1; i < bodyParts.Count; i++)
        {
            Destroy(bodyParts[i].gameObject);
        }
        bodyParts.Clear();
        bodyParts.Add(this.transform);
        direction = Vector2.zero;
        this.transform.position = new Vector3(0, 0, 0);
        giftText.text = "score：0";


    }
    private void GrowGift()
    {
        Transform segment = Instantiate(this.segmentPrefab[0]);
        segment.position = bodyParts[bodyParts.Count - 1].position;
        bodyParts.Add(segment);
    }
    private void GrowHead()
    {
        Transform segment = Instantiate(this.segmentPrefab[1]);
        segment.position = bodyParts[bodyParts.Count - 1].position;
        bodyParts.Add(segment);        
  
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gift")
        {
            touchGift.Play();

            if (Gift.rand == 3)
            {
                GrowHead();
                point++;
                giftText.text = "score：" + point;
                GameManger.Instance.score = point;
            }
            else
            {
                GrowGift();
            }
        }
        else if(other.tag == "obstacle")
        {
            touchObstacle.Play();
            ResetState();
            SceneManager.LoadScene("gameOver");
            
        }
    }
}
