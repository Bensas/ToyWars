using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameSceneManager : MonoBehaviour
    {
    
        public static GameSceneManager Instance;

        [SerializeField] private int currentLevel;
        [SerializeField] private List<string> gameLevels;
        
        private static int _currentLevel = 0;
        
        private static AsyncOperation asyncLoad;

        private void Awake()
        {
            if (Instance != null)
            {
                if (Instance != this)
                {
                    Destroy(transform.gameObject);
                }
            }
            else
            {
                Instance = this;
            
                DontDestroyOnLoad(transform.gameObject);
                _currentLevel = currentLevel;
            }
        }
        
        public void LoadNextLevel()
        {
            if (_currentLevel < gameLevels.Count)
            {
                SceneManager.LoadScene(gameLevels[_currentLevel]);
                _currentLevel++;
            }
            else
            {
                SceneManager.LoadScene("Victory");
            }
        }

        public void LoadCurrentLevel()
        {
            SceneManager.LoadScene(gameLevels[_currentLevel]);
        }
        
        public bool IncrementLevel()
        {
            _currentLevel += 1;
            return _currentLevel < gameLevels.Count;
        }
        
        public string GetCurrentLevel()
        {
            return gameLevels[_currentLevel];
        }

        public void LoadVictoryScene()
        {
            SceneManager.LoadScene("Victory");
        }
        
        public void LoadDefeatScene()
        {
            SceneManager.LoadScene("Defeat");
        }
        
        public void LoadMainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
        
        public void LoadLoadingScene()
        {
            SceneManager.LoadScene("Loading");
        }
        
        public void LoadFirstLevel()
        {
            _currentLevel = 0;
            LoadLoadingScene();
        }
    }
}
