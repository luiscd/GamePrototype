using GamePrototype.Engine;
using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace GamePrototype.GameWorld
{
    public class Level
    {
        private int worldSize;
        private int chunkSize;
        private int tileSize;
        private List<int[,]> layers = new List<int[,]>();
        private int[,] layer;
        private int[,] world;
        private ReadXML readXML;

        public int TileRadius { get; set; }
        public int WorldWidth { get; set; }
        public int WorldHeight { get; set; }
        public static List<Tile> VisibleTiles = new List<Tile>();

        private Texture2D spriteSheet;
        private int xOffset;
        private int yOffset;

        public Level(Texture2D spriteSheet)
        {
            chunkSize = 16;
            worldSize = 4;
            tileSize = 16;
            TileRadius = 8;
            WorldWidth = chunkSize * worldSize;
            WorldHeight = chunkSize * worldSize;
            this.spriteSheet = spriteSheet;
        }

        public void LoadLevel()
        {
            readXML = new ReadXML();
            XmlNodeList nodes = readXML.GetNodes();
            LoadArray(nodes);

            xOffset = (WorldWidth * tileSize) / 2;
            yOffset = (WorldHeight * tileSize) / 2;

            LoadLayerFloor();
            LoadLayerWalls();
        }

        private void LoadLayerFloor()
        {
            for (int i = 0; i < layers[0].GetLength(0); i++)
            {
                for (int j = 0; j < layers[0].GetLength(1); j++)
                {
                    Tile.Tiles.Add(new FloorTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset)));
                }
            }
        }

        private void LoadLayerWalls()
        {
            for (int i = 0; i < layers[1].GetLength(0); i++)
            {
                for (int j = 0; j < layers[1].GetLength(1); j++)
                {
                    var value = layers[1][i, j];

                    if (value == 1)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 1));

                    if (value == 2)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 2));

                    if (value == 6)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 3));

                    if (value == 25)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 4));

                    if (value == 26)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 5));

                    if (value == 30)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 6));

                    if (value == 97)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 7));

                    if (value == 102)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 8));

                    if (value == 121)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 9));

                    if (value == 122)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 10));

                    if (value == 126)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, spriteSheet, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 11));
                }
            }
        }

        private void LoadArray(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                string text = node.InnerText;
                string[] dummyRows = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                string[] rows = new string[dummyRows.Length - 1];

                Array.Copy(dummyRows, 1, rows, 0, rows.Length);

                layer = new int[WorldWidth, WorldHeight];

                for (int x = 0; x < WorldWidth; x++)
                {
                    string[] values = rows[x].Split(',', StringSplitOptions.RemoveEmptyEntries);

                    for (int y = 0; y < WorldHeight; y++)
                    {
                        if (int.TryParse(values[y], out int parsedValue))
                        {
                            layer[x, y] = parsedValue;
                        }
                    }
                }

                layers.Add(layer);
            }
        }

        //private static void PopulateWorld(int[,] world, int chunkSize, int worldSize)
        //{
        //    Debug.WriteLine(chunkSize);

        //    for (int i = 0; i < worldSize; i++)
        //    {
        //        for (int j = 0; j < worldSize; j++)
        //        {
        //            int[,] chunk = new int[chunkSize, chunkSize];
        //            PlaceChunkInWorld(world, chunk, chunkSize, i, j);
        //        }
        //    }
        //}

        //private static void PlaceChunkInWorld(int[,] world, int[,] chunk, int chunkSize, int xIndex, int yIndex)
        //{
        //    for (int i = 0; i < chunkSize; i++)
        //    {
        //        for (int j = 0; j < chunkSize; j++)
        //        {
        //            world[xIndex * chunkSize + i, yIndex * chunkSize + j] = chunk[i, j];
        //        }
        //    }
        //}

        //private static int GetArrayValue(int position)
        //{
        //    return position;
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in VisibleTiles)
            {
                tile.Draw(spriteBatch);
            }
        }

    }
}
