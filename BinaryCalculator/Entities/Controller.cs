using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///         //  last soldier must go to end
//1. set current soldier = last element
//      IsPositionChanged = false
//      until(hasNext board indx)
//          current soldier(last element) goto forward
//          IsPositionChanged = true
//          save(print) states

//  other soldier go to one step
//2. set current soldier=first Soldier
//      IsPositionChanged = false
//      if nextSoldier =null(end)
//          if all soldiers IsPositionChanged=false => end
//      try to go forward to 1 step 
//          if it not posible => 
//              
//3. result = only points of soldiers, without board
//      need to set to show board + soldiers


//
/// </summary>

namespace BinaryCalculator.Entities
{
    public class Controller
    {
        #region fields

        private Board board;
        private int lengthOfWay;
        private int soldiersCount;

        #endregion //fields

        public Controller(int lengthOfWay, int soldiersCount)
        {
            this.lengthOfWay = lengthOfWay;
            this.soldiersCount = soldiersCount;
            board = new Board(lengthOfWay,soldiersCount);
        }

        //print result
        private void printResult(int [] result)
        {
            var resultStr = string.Empty;
            foreach (var item in setResult(result))
            {
                resultStr += item;
            }
            Console.WriteLine(resultStr);
        }

        //complete result with board data and soldiersData
        private int [] setResult(int[] result)
        {
            int[] boardResult = new int[lengthOfWay];
            for (int i = 0; i < result.Length; i++)
            {
                boardResult[result[i]] = 1;
            }
            return boardResult;
        }

        //start 
        public void CalculateVariants()
        {
            board.Go();
            var results = board.Positions;
            Console.WriteLine($"board len: {lengthOfWay}, soldiers: {soldiersCount}, total variants: {results.Count}");
            foreach (var item in results)
            {
                printResult(item);
            }
            Console.WriteLine($"board len: {lengthOfWay}, soldiers: {soldiersCount}, total variants: {results.Count}");
            Console.ReadLine();
        }

        
    }
}
