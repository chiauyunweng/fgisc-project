using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanger : MonoBehaviour
{
    public GameObject tree;
    public GameObject treeSpawnPosition;
    private float spawnTime;
    float timer;
    public GameObject GameOverScene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        spawnTime = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= spawnTime)
        {
            spawnTime = Random.Range(2.0f, 5.0f);
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
