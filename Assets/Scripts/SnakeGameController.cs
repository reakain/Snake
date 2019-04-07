using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public class SnakeGameController : MonoBehaviour
    {
        int highScore = 0;
        public GameObject snakeCamera;// = Resources.Load<GameObject>("Assets/Prefab/SnakeCamera.prefab");
        public GameObject startPrefab;// = Resources.Load("Assets/Prefab/StartPrefab.prefab");
        public GameObject snakeGamePrefab;// = Resources.Load("Assets/Prefab/SnakeGamePrefab.prefab");
        public GameObject gameOverPrefab;// = Resources.Load("Assets/Prefab/GameOverPrefab.prefab");

        private void Start()
        {
            LoadSnakeGameInstance(0);
        }

        public void StartScreen()
        {
            Object.Destroy(GetComponentInChildren<GameOverScreen>().gameObject);
            Instantiate(startPrefab, this.transform);
            GetComponentInChildren<StartScreen>().SetHighScore(highScore);
        }

        public void InstantiateGame()
        {
            Object.Destroy(GetComponentInChildren<StartScreen>().gameObject);
            Instantiate(snakeGamePrefab,this.transform);
        }

        public void GameOver(int score)
        {

            Object.Destroy(GetComponentInChildren<SpawnFood>().gameObject);
            Instantiate(gameOverPrefab, this.transform);
            GetComponentInChildren<GameOverScreen>().SetScore(score);
            if (score > highScore)
            {
                highScore = score;
            }
        }

        void ClearScreen()
        {
            Object.Destroy(GetComponentInChildren<GameOverScreen>().gameObject);
            Object.Destroy(GetComponentInChildren<StartScreen>().gameObject);
            Object.Destroy(GetComponentInChildren<SpawnFood>().gameObject);
            Object.Destroy(GetComponentInChildren<Camera>().gameObject);
        }

        void SetCamera()
        {
            Instantiate(snakeCamera, this.transform);
        }

        public void LoadSnakeGameInstance(int score)
        {
            SetCamera();
            highScore = score;
            StartScreen();
        }

        public int CloseSnakeGameInstance()
        {
            ClearScreen();
            return highScore;
        }
    }
}