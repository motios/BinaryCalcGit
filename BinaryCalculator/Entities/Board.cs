using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCalculator.Entities
{
    public class Board
    {
        #region fields

        private Soldier[] soldiers;
        private int boardLen;
        public List<int[]> Positions{ get{ return results; } }
        private List<int[]> results;

        #endregion //fields

        public Board(int lengthOfWay, int soldiersCount)//(int boardLen,int soldierCount)
        {
            results = new List<int[]>();
            soldiers = new Soldier[soldiersCount];
            this.boardLen = lengthOfWay;
            initSoldiers();
        }

        //init soldeirs 
        private void initSoldiers()
        {
            //set soldiers position
            for (int i = 0; i < soldiers.Length && i < boardLen; i++)
            {
                soldiers[i] = new Soldier() { Position = i };
            }
            saveResult();

            //set reference to nextSoldier
            for (int i = 0; i < soldiers.Length; i++)
            {
                soldiers[i].NextSoldier = i + 1 < soldiers.Length ? soldiers[i + 1] : null;
            }
        }

        //start 
        public void Go()
        {
            bool isNotChanged = false;
            while (!isNotChanged)//do until have changes
            {
                //last soldier(right) forward to end of board
                lastSoldierSteps(soldiers[soldiers.Length - 1]);

                //try to move forward another soldier from first wuthout last
                foreach (var soldier in soldiers)
                {
                    if (soldier.NextSoldier != null)
                    {
                        soldierStep(soldier);
                    }
                }
                //check for soldiers changes
                isNotChanged = withoutChanges();
            }


        }


        //check for changes for all soldiers
        //if no changes - > end of game
        private bool withoutChanges()
        {
            foreach (var soldier in soldiers)
            {
                if (soldier.IsPositionChanged)
                {
                    return false;
                }
            }
            return true;
        }

        //try lastSoldier to move forward
        private void lastSoldierSteps(Soldier soldier)
        {
            soldier.IsPositionChanged = false;
            var position = soldier.Position;
            while (position < boardLen-1)
            {
                position = ++soldier.Position;
                soldier.IsPositionChanged = true;
                saveResult();
            }
        }

        //try non lastSoldier to move forward, and try to return lastSoldier to left
        private void soldierStep(Soldier soldier)
        {
            soldier.IsPositionChanged = false;
            var position = soldier.Position;
            if (stepIsPossible(soldier))
            {
                soldier.Position++;
                soldier.IsPositionChanged = true;
                tryToMoveLastSoldierToBack();
            }
        }

        //try to return lastSoldier to left
        private void tryToMoveLastSoldierToBack()
        {
            if (soldiers.Length > 1)
            {
                var soldierPosition = soldiers[soldiers.Length - 2].Position;
                if (soldierPosition + 1 < soldiers[soldiers.Length - 1].Position)
                {
                    soldiers[soldiers.Length - 1].Position = ++soldierPosition;
                    soldiers[soldiers.Length - 1].IsPositionChanged = true;
                }
                saveResult();
            }

        }

        //check if can possible move soldier one step forward
        private bool stepIsPossible(Soldier soldier)
        {
            var nextPosition = soldier.NextSoldier != null ? soldier.NextSoldier.Position : -1;
            //check if not end of board, current soldier is not a last soldier, next soldier not stay together
            return (soldier.Position + 1) < boardLen - 1 && nextPosition > -1 && soldier.Position + 1 != nextPosition;
        }

        //save result 
        private void saveResult()
        {
            int[] result = new int[soldiers.Length];
            for (int i = 0; i < soldiers.Length; i++)
            {
                result[i] = soldiers[i].Position;
            }
            results.Add(result);
        }


        
       
    }
}
