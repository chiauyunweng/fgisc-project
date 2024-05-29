using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static allcontrol;


public class showButton : MonoBehaviour

{
    public GameObject show;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManger.Instance.score > 0)
        {
            show.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
