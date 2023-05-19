using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonController : MonoBehaviour
    {
        private Button _button;
        
        public void OnSelect(BaseEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}