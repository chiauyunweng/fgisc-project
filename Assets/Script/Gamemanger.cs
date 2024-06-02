using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Gamemanger : MonoBehaviour
{
    public GameObject tree;
    public GameObject treeSpawnPosition;
    private float spawnTime;
    float timer;
    public GameObject GameOverScene;
    public Text scoreText;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        spawnTime = Random.Range(0.5f, 1.5f);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        float score = Time.time - startTime;
        scoreText.text = "Score:" + Mathf.FloorToInt(score).ToString();
        if(timer >= spawnTime)
        {
            float elapsedTime = Time.time - startTime;
            if (elapsedTime >= 15f)
            {
                spawnTime = Random.Range(0.7f, 1.0f);
            }
            else
            {
                spawnTime = Random.Range(1.0f, 1.5f);
            }
            
            Instantiate(tree,treeSpawnPosition.transform);
            timer = 0;
        }
    }

    public void Gameover()
    {
        Time.timeScale = 0;
        GameOverScene.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene("start");

    }
}
