using System;
using Managers;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIButtonsLogic : MonoBehaviour
    {
        [SerializeField] private MainMenuSoundController _menuSoundController;

        private void Start()
        {
            Cursor.visible = true;
        }

        public void LoadMenuScene() => GameSceneManager.Instance.LoadMainMenu();
        public void LoadLevelScene() => GameSceneManager.Instance.LoadLoadingScene();
        public void RestartGame() => GameSceneManager.Instance.LoadFirstLevel();
        public void CloseGame() => Application.Quit();

        public void ButtonSelect() =>
            _menuSoundController.PlaySound(_menuSoundController.SoundsLibrary.ButtonHighlight);
    }
}