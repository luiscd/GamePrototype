using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GamePrototype.Engine
{
    public class GlobalVariables
    {
        public static Dictionary<string, Texture2D>  GameTexturesDictionary = new Dictionary<string, Texture2D>();
        public static float Scale { get; set; } = 2f;

        public Texture2D SpriteSheet { get; set; }

        public static Texture2D LoadSpriteSheet()
        {
            return Game1._Content.Load<Texture2D>("spriteSheet");
        }

        public static void LoadTextures()
        {
            GameTexturesDictionary.Add("playerIdleDown", SpritePlayerIdleDown());
            GameTexturesDictionary.Add("playerIdleUp", SpritePlayerIdleUp());
            GameTexturesDictionary.Add("playerIdleRight", SpritePlayerIdleRight());
            GameTexturesDictionary.Add("playerIdleLeft", SpritePlayerIdleLeft());
            GameTexturesDictionary.Add("playerMoveDown", SpritePlayerMoveDown());
            GameTexturesDictionary.Add("playerMoveUp", SpritePlayerMoveUp());
            GameTexturesDictionary.Add("playerMoveRight", SpritePlayerMoveRight());
            GameTexturesDictionary.Add("playerMoveLeft", SpritePlayerMoveLeft());
            GameTexturesDictionary.Add("playerAttackUp", SpritePlayerAttackUp());
            GameTexturesDictionary.Add("playerAttackDown", SpritePlayerAttackDown());
            GameTexturesDictionary.Add("playerAttackLeft", SpritePlayerAttackLeft());
            GameTexturesDictionary.Add("playerAttackRight", SpritePlayerAttackRight());
        }

        #region Player Sprites
        private static Texture2D SpritePlayerIdleDown()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_idle_down_anim_strip_6");
        }

        private static Texture2D SpritePlayerIdleRight()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_idle_right_anim_strip_6");
        }

        private static Texture2D SpritePlayerIdleLeft()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_idle_left_anim_strip_6");
        }

        private static Texture2D SpritePlayerIdleUp()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_idle_up_anim_strip_6");
        }

        private static Texture2D SpritePlayerMoveDown()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_run_down_anim_strip_6");
        }

        private static Texture2D SpritePlayerMoveUp()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_run_up_anim_strip_6");
        }

        private static Texture2D SpritePlayerMoveLeft()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_run_left_anim_strip_6");
        }

        private static Texture2D SpritePlayerMoveRight()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_run_right_anim_strip_6");
        }

        private static Texture2D SpritePlayerAttackUp()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_attack_up_anim_strip_6");
        }

        private static Texture2D SpritePlayerAttackDown()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_attack_down_anim_strip_6");
        }

        private static Texture2D SpritePlayerAttackLeft()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_attack_left_anim_strip_6");
        }

        private static Texture2D SpritePlayerAttackRight()
        {
            return Game1._Content.Load<Texture2D>("Top_Down_Adventure_Pack_v.1.0/Top_Down_Adventure_Pack_v.1.0/Char_Sprites/char_attack_right_anim_strip_6");
        }
        #endregion
    }
}
