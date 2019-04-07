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

        public bool LoadGameOnStart = false;

        GameObject camera;
        GameObject startScreen;
        GameObject gameScreen;
        GameObject endScreen;

        private void Start()
        {
            if (LoadGameOnStart)
            {
                LoadSnakeGameInstance(0);
            }
        }

        public void StartScreen()
        {
            if (endScreen != null)
            {
                Object.Destroy(endScreen);
            }
            startScreen = Instantiate(startPrefab, this.transform);
            startScreen.GetComponent<StartScreen>().SetHighScore(highScore);
        }

        public void InstantiateGame()
        {
            if (startScreen != null)
            {
                Object.Destroy(startScreen);
            }
            gameScreen = Instantiate(snakeGamePrefab,this.transform);
        }

        public void GameOver(int score)
        {
            if (gameScreen != null)
            {
                Object.Destroy(gameScreen);
            }
            endScreen = Instantiate(gameOverPrefab, this.transform);
            endScreen.GetComponent<GameOverScreen>().SetScore(score);
            if (score > highScore)
            {
                highScore = score;
            }
        }

        void ClearScreen()
        {
            if (endScreen != null)
            {
                Object.Destroy(endScreen);
            }
            if (startScreen != null)
            {
                Object.Destroy(startScreen);
            }
            if (gameScreen != null)
            {
                Object.Destroy(gameScreen);
            }
            if (camera != null)
            {
                Object.Destroy(camera);
            }
        }

        void SetCamera()
        {
            camera = Instantiate(snakeCamera, this.transform);
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