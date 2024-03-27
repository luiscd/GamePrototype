using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GamePrototype.UI.Singulars;
using GamePrototype.Engine;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace GamePrototype.UI.UiBars
{
    public class ActionBar
    {
        public static List<ItemBox> Items = new List<ItemBox>();

        InputManager inputManager;

        public ActionBar(UI ui)
        {
            inputManager = new InputManager();

            for (int i = 0; i < 5; i++)
            {
                Items.Add(new ItemBox()
                {
                    Position = new Vector2(ui.ActionBarRectangle.Center.X + i * 18 - 2 * 16, ui.ActionBarRectangle.Y + 6),
                    IsSelected = i == 0,
                });
            }

        }

        public void Update(GameTime gameTime)
        {
            inputManager.UpdateState();

            if (inputManager.IsKeyDown(Keys.D1))
            {
                ResetSelectedItems();
                Items[0].IsSelected = true;
            }

            if (inputManager.IsKeyDown(Keys.D2))
            {
                ResetSelectedItems();
                Items[1].IsSelected = true;
            }

            if (inputManager.IsKeyDown(Keys.D3))
            {
                ResetSelectedItems();
                Items[2].IsSelected = true;
            }

            if (inputManager.IsKeyDown(Keys.D4))
            {
                ResetSelectedItems();
                Items[3].IsSelected = true;
            }

            if (inputManager.IsKeyDown(Keys.D5))
            {
                ResetSelectedItems();
                Items[4].IsSelected = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in Items)
            {
                item.Draw(spriteBatch);
            }
        }

        private void ResetSelectedItems()
        {
            Items.FirstOrDefault(item => item.IsSelected).IsSelected = false;
        }
    }
}
