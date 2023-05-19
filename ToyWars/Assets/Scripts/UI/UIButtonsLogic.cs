using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIButtonsLogic : MonoBehaviour
    {
        [SerializeField] private MainMenuSoundController _menuSoundController;
        
        
        public void LoadMenuScene() => SceneManager.LoadScene("Main Menu");
        public void LoadLevelScene() => SceneManager.LoadScene("BedroomScene");
        public void CloseGame() => Application.Quit();

        public void ButtonSelect() =>
            _menuSoundController.PlaySound(_menuSoundController.SoundsLibrary.ButtonHighlight);
    }
}