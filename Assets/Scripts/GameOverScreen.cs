using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SnakeGame
{
    public class GameOverScreen : MonoBehaviour
    {
        public Text endScore;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                this.GetComponentInParent<SnakeGameController>().StartScreen();
            }
        }

        public void SetScore(int score)
        {
            endScore.text = score.ToString();
        }
    }
}