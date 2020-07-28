using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.Models
{
   public class RandomNumber
    {
        public long GetRandomNumb()
        {
            long WorkOrderID = 0;
            var rand = new Random();
            var bytes = new byte[1];
            rand.NextBytes(bytes);
            for (int i = 1; i <= 9; i++)
            {
                WorkOrderID = +(rand.Next(1, 9) + (DateTime.Now.Ticks / 1000000000000));
            }

            return WorkOrderID;

        }
    }
}
