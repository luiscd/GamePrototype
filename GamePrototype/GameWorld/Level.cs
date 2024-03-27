using GamePrototype.Engine;
using GamePrototype.GameWorld.Tiles;
using GamePrototype.Objects.Weapons;
using GamePrototype.UI.Singulars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public static List<PowerUp> VisiblePowerUps = new List<PowerUp>();
        public static List<Objects.Object> VisibleObjects = new List<Objects.Object>();

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

            var rand = new Random();
            var position = new Vector2(rand.Next(100), rand.Next(100));

            Objects.Object.Weapons.Add(
                new Sword()
                {
                    Position = position,
                    CollisionBox = new Rectangle((int)position.X, (int)position.Y, 16, 16)
                });

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


        private List<ArrayObject> GetArrayValues(int[,] array, int value)
        {
            return Enumerable.Range(0, array.GetLength(0))
                       .SelectMany(i => Enumerable.Range(0, array.GetLength(1))
                       .Select(j => new ArrayObject
                       {
                           Row = i,
                           Col = j,
                           Value = array[i, j]
                       }))
                       .Where(item => item.Value == value)
                       .ToList();
        }

        private List<int> GetDistinctArrayValues(int[,] array)
        {
            return Enumerable.Range(0, array.GetLength(0))
                               .SelectMany(i => Enumerable.Range(0, array.GetLength(1))
                                                           .Select(j => layers[1][i, j]))
                               .Distinct()
                               .Where(value => value != default(int))
                               .ToList();
        }

        private void LoadLayerWalls()
        {
            var distictValues = GetDistinctArrayValues(layers[1]);

            foreach (var distinctValue in distictValues.Select((value, i) => new { i, value }))
            {
                var result = GetArrayValues(layers[1], distinctValue.value);
                foreach (var layer in result)
                {
                    Vector2 position = new Vector2((layer.Col * tileSize) - xOffset, (layer.Row * tileSize) - yOffset);
                    Tile.Tiles.Add(new WallTile(xOffset, yOffset, tileSize, position, distinctValue.i + 1)
                    {
                        CollisionBox = new Rectangle((int)position.X, (int)position.Y, 8, 8)
                    });
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

            foreach (var pUp in VisiblePowerUps)
            {
                pUp.Draw(spriteBatch);
            }

            foreach (var weapon in VisibleObjects)
            {
                weapon.Draw(spriteBatch);
            }

            //foreach(var tile in WallTile.Walls)
            //{
            //    tile.Draw(spriteBatch);
            //}
        }

    }


    public class ArrayObject
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Value { get; set; }
    }
}
