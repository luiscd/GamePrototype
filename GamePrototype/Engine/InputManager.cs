using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class InputManager
    {

        private KeyboardState keyState;
        private KeyboardState lastKeyState;
        private bool isPressed;

        public void UpdateState()
        {
            keyState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            isPressed = true;
            return keyState.IsKeyDown(key);
        }

        public bool IsKeyUp(Keys key)
        {
            return keyState.IsKeyUp(key);
        }

        public void SaveLastState()
        {
            lastKeyState = keyState;
        }

        public bool LastKeyState(Keys key)
        {
            return lastKeyState.IsKeyUp(key);
        }

    }
}
