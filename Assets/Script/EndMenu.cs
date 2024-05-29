using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static allcontrol;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
   
        public void ChangeScene2() //記得加public不然等等在加按鈕事件的時候讀不到
        {
            //用LoadScene(buildIndex)來更換目前顯示的Scene
            SceneManager.LoadScene(3);
            GameManger.Instance.score = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
