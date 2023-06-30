using UnityEngine;

namespace Utils
{
    public class InputUtils
    {
        public bool IsFiring { get; private set; } = false;
        public bool OnFiringDown { get; private set; } = false;
        public bool OnFiringUp { get; private set; } = false;
        
        // On Joystick, triggers are axis, therefore there is Input.GetButtonDown() and Input.GetButtonUp()
        public void HandleFireInput()
        {
            if (Input.GetAxisRaw("Fire1") > 0)
            {
                OnFiringDown = !IsFiring;
                IsFiring = true;
            }
            else
            {
                OnFiringUp = IsFiring;
                IsFiring = false;
            }
        }
    }
}