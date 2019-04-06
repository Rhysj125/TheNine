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

        private static readonly string RESOURCE_DIRECTORY = "Prefabs/";

        private static readonly string ENEMY_DIRECTORY = RESOURCE_DIRECTORY + "Enemies/";
        private static readonly string ROOM_DIRECTORY = RESOURCE_DIRECTORY + "Floor Tiles/";
        private static readonly string ITEM_DIRECTORY = RESOURCE_DIRECTORY + "Items/";

        /// <summary>
        /// Returns a list of GameObject's within the enemy resource folder.
        /// </summary>
        /// <param name="level">The level of room tiles to get. Higher level = Harder enemies.</param>
        /// <returns></returns>
        public static List<GameObject> GetEnemies(int level)
        {
                GameObject[] enemies = Resources.LoadAll<GameObject>(RESOURCE_DIRECTORY + ENEMY_DIRECTORY);

                return enemies.ToList();
        }

        /// <summary>
        /// Returns a list of GameObject's within the Room Tile resource folder.
        /// </summary>
        /// <param name="level">The level of room tiles to get. Different level's have different rooms possibilities.</param>
        /// <returns>List of GameObject of room tiles.</returns>
        public static List<GameObject> GetRoomTiles(int level)
        {
            GameObject[] roomTiles = Resources.LoadAll<GameObject>(ROOM_DIRECTORY);

            return roomTiles.ToList();
        }

    }
}
