using GamePrototype.Engine;
using GamePrototype.GameWorld.Tiles;
using GamePrototype.UI.Singulars;
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

        private int xOffset;
        private int yOffset;

        public Level()
        {
            chunkSize = 16;
            worldSize = 4;
            tileSize = 16;
            TileRadius = 8;
            WorldWidth = chunkSize * worldSize;
            WorldHeight = chunkSize * worldSize;
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
            LoadPowerUps();
        }

        private void LoadLayerFloor()
        {
            for (int i = 0; i < layers[0].GetLength(0); i++)
            {
                for (int j = 0; j < layers[0].GetLength(1); j++)
                {
                    Tile.Tiles.Add(new FloorTile(xOffset, yOffset, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset)));
                }
            }
        }

        private void LoadLayerWalls()
        {
            Vector2 position = Vector2.Zero;

            for (int i = 0; i < layers[1].GetLength(0); i++)
            {
                for (int j = 0; j < layers[1].GetLength(1); j++)
                {
                    var value = layers[1][i, j];

                    if (value == 1)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 1));

                    if (value == 2)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 2));

                    if (value == 6)
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset), 3));

                    if (value == 25)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 4)
                        {
                            CollisionBox = new Rectangle((int)position.X, (int)position.Y, 16, 8)
                        });
                    }

                    if (value == 26)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 5)
                        {
                            CollisionBox = new Rectangle((int)position.X, (int)position.Y, 16, 8)
                        });
                    }

                    if (value == 30)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 6)
                        {
                            CollisionBox = new Rectangle((int)position.X, (int)position.Y, 8, 16)
                        });
                    }

                    if (value == 97)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 7)
                        {
                            CollisionBox = new Rectangle((int)position.X, (int)position.Y, 8, 16)
                        });
                    }

                    if (value == 102)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 8)
                        {
                            CollisionBox = new Rectangle((int)position.X + 8, (int)position.Y, 8, 16)
                        });
                    }

                    if (value == 121)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 9)
                        {
                            CollisionBox = new Rectangle((int)position.X, (int)position.Y + 8, 16, 8)
                        });
                    }

                    if (value == 122)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 10)
                        {
                            CollisionBox = new Rectangle((int)position.X, (int)position.Y + 8, 16, 8)
                        });
                    }

                    if (value == 126)
                    {
                        position = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset);
                        Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, 11)
                        {
                            CollisionBox = new Rectangle((int)position.X, (int)position.Y + 8, 16, 8)
                        });
                    }
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

        private void LoadPowerUps()
        {
            var rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                var position = new Vector2(rand.Next(100), rand.Next(100));
                PowerUp.PowerUps.Add(
                   new PowerUp()
                   {
                       Position = position,
                       CollisionBox = new Rectangle((int)position.X, (int)position.Y, 8, 8)
                   });
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

        public void Update(GameTime gameTime)
        {
            foreach (var pUp in PowerUp.PowerUps)
            {
                pUp.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in VisibleTiles)
            {
                tile.Draw(spriteBatch);
            }

            foreach (var pUp in PowerUp.PowerUps)
            {
                pUp.Draw(spriteBatch);
            }

            //foreach(var tile in WallTile.Walls)
            //{
            //    tile.Draw(spriteBatch);
            //}
        }

    }
}
