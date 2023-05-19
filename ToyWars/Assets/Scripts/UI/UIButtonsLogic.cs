using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIButtonsLogic : MonoBehaviour
    {
        public void LoadMenuScene() => SceneManager.LoadScene("Main Menu");
        public void LoadLevelScene() => SceneManager.LoadScene("BedroomScene");
        public void CloseGame() => Application.Quit();

        public void ButtonSelect() =>
            SoundController.instace.PlaySound(SoundController.instace.SoundsLibrary.ButtonHighlight);
    }
}