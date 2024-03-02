using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class InputManager
    {

        private KeyboardState currentKeyState;
        private Keys lastKeyPressed;
        private bool isPressed;

        public void UpdateState()
        {
            currentKeyState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            isPressed = true;
            return currentKeyState.IsKeyDown(key);
        }

        public bool IsKeyUp(Keys key)
        {
            isPressed = false;
            return currentKeyState.IsKeyUp(key);
        }

        public void SaveLastKeyPressed(Keys key)
        {
            lastKeyPressed = key;
        }

        public bool IsLastKeyPressedEqual(Keys key)
        {
            return lastKeyPressed == key;
        }

    }
}
