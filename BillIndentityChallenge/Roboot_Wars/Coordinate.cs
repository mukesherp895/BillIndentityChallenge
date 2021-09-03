using System;
using System.Collections.Generic;
using System.Text;

namespace BillIndentityChallenge.Roboot_Wars
{
    public struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return (string.Format("{0} {1}", X, Y));
        }
    }
}
