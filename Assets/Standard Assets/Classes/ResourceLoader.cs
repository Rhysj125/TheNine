using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Standard_Assets.Classes
{
    /// <summary>
    /// Loads requested resources from resources folder.
    /// </summary>
    class ResourceLoader
    {

        // Base Directory for prefabs.
        private static readonly string RESOURCE_DIR = "Prefabs/";

        // Directories for different types of game resources.
        private static readonly string ENEMY_DIR = RESOURCE_DIR + "Enemies/";
        private static readonly string ROOM_DIR = RESOURCE_DIR + "Floor Tiles/";
        private static readonly string ITEM_DIR = RESOURCE_DIR + "Items/";
        private static readonly string PORTAL_DIR = RESOURCE_DIR + "Portal/Portal";

        /// <summary>
        /// Returns a list of GameObject's within the enemy resource folder.
        /// </summary>
        /// <param name="level">The level of room tiles to get. Higher level = Harder enemies.</param>
        /// <returns></returns>
        public static List<GameObject> GetEnemies(int level)
        {
            GameObject[] enemies = Resources.LoadAll<GameObject>(ENEMY_DIR);

            return enemies.ToList();
        }

        /// <summary>
        /// Returns a list of GameObject's within the Room Tile resource folder.
        /// </summary>
        /// <param name="level">The level of room tiles to get. Different level's have different rooms possibilities.</param>
        /// <returns>List of GameObject of room tiles.</returns>
        public static List<GameObject> GetRoomTiles(int level)
        {
            GameObject[] roomTiles = Resources.LoadAll<GameObject>(ROOM_DIR);

            return roomTiles.ToList();
        }

        /// <summary>
        /// Returns a list of GameObject's within the Items resource folder.
        /// </summary>
        /// <returns>List of GameObject of room tiles.</returns>
        public static List<GameObject> GetItems()
        {
            GameObject[] items = Resources.LoadAll<GameObject>(ITEM_DIR);

            return items.ToList();
        }

        public static GameObject GetPortal()
        {
            return Resources.Load<GameObject>(PORTAL_DIR);
        }
    }
}
