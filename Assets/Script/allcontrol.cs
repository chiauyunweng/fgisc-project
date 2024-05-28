using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allcontrol : MonoBehaviour
{
    // Start is called before the first frame update

    public class GameManger
    {
        private static GameManger _instance;

        public static GameManger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManger();
                return _instance;
            }
        }
        public int score = 0;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
