using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//記得加這個才能對Scene做操作
using static allcontrol;

public class StartMenu : MonoBehaviour
{
    public void ChangeScene() //記得加public不然等等在加按鈕事件的時候讀不到
    {
        //用LoadScene(buildIndex)來更換目前顯示的Scene
        GameManger.Instance.score = 0;
        SceneManager.LoadScene("Hello");
    }
    public void Changetogame() //記得加public不然等等在加按鈕事件的時候讀不到
    {
        //用LoadScene(buildIndex)來更換目前顯示的Scene
        SceneManager.LoadScene("lv1");
    }
}