using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v2
{
    class Inventory
    {
        private const int ITEM_TYPES = 3;  //how many total items are available for the player
        private const int SPAWNS = 3;


        public int InvStick { get { return InvArr[0]; } }
        public int InvStone { get { return InvArr[1]; } }
        public int InvArrow { get { return InvArr[2]; } }

        public int SpawnedSticks { get { return SpawnArr[0]; } }
        public int SpawnedStones { get { return SpawnArr[1]; } }
        public int SpawnedBird { get { return SpawnArr[2]; } }

        //Tracking the score
        private int _score = 0;
        public int Score { get { return _score; } }

        static private int[] InvArr = new int[ITEM_TYPES]; //Array to reference items in player backpack
        static private int[] SpawnArr = new int[SPAWNS]; //Array to manage spawning triggers

        public Inventory()
        {
            InvArr[0] = InvStick;
            InvArr[1] = InvStone;
            InvArr[2] = InvArrow;

            SpawnArr[0] = SpawnedSticks;
            SpawnArr[1] = SpawnedStones;
            SpawnArr[2] = SpawnedBird;
        }

        public void ChangeInv(bool effect, int item) //Method for tracking/changing quantities of resources in the backpack
        {
            if (item == 2) //If the item is an arrow:
            {
                if (effect == true)
                    InvArr[item] += 3; //Create 3 arrows
                else
                    InvArr[item]--;
            }
            else
            {
                if (effect == true)
                    InvArr[item] ++;
                else
                    InvArr[item] --;
            }
        }

        public void ChangeSpawn(bool effect, int item) //Manages changes in spawning
        {
            if (effect == true)
                SpawnArr[item]++;
            else
                SpawnArr[item]--;
        }

        public void ChangeScore() //Manages score
        {
            _score++;
        }

        public void Reset() //Resets all inventory items if the game is reset
        {
            for (int i = 0; i < InvArr.Length; i++)
                InvArr[i] = 0;
            for (int i = 0; i < SpawnArr.Length; i++)
                SpawnArr[i] = 0;
            _score = 0;
        }
    }
}
