using BillIndentityChallenge.Roboot_Wars;
using BillIndentityChallenge.SuperMarket_Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BillIndentityChallenge
{
    [TestClass]
    public class UnitTest1
    {
        private IRoboot _iroboot;
        private ICheckout _icheckout;
        public UnitTest1()
        {
            _iroboot = new Robot();
            _icheckout = new SuperMarketKata();
        }
        [TestMethod]
        public void FirstRobotMovement_Test()
        {
            //1 2 N
            //LMLMLMLMM

            string[] inst = new string[] { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            MoveResult moveResult = new MoveResult();
            var request = new MoveRequest()
            {
                Coordinate = new Coordinate(1, 2),
                Orientation = EnumData.Orientation.N,
                Grid = new Grid(5, 5),
            };
            foreach (var item in inst)
            {
                if (item == "L")
                {
                    request.Instruction = EnumData.Instruction.L;
                }
                else if (item == "R")
                {
                    request.Instruction = EnumData.Instruction.R;
                }
                else if (item == "M")
                {
                    request.Instruction = EnumData.Instruction.M;
                }
                moveResult = _iroboot.Move(request);
                request.Coordinate = moveResult.Coordinate;
                request.Orientation = moveResult.Orientation;
            }

            Assert.AreEqual(moveResult.Coordinate.X, 1);
            Assert.AreEqual(moveResult.Coordinate.Y, 3);
            Assert.AreEqual(moveResult.Orientation, EnumData.Orientation.N);
        }
        [TestMethod]
        public void SecondRobotMovement_Test()
        {
            //3 3 E
            //MMRMMRMRRM

            string[] inst = new string[] { "M", "M", "R", "M", "M", "R", "M", "R", "R", "M" };
            MoveResult moveResult = new MoveResult();
            var request = new MoveRequest()
            {
                Coordinate = new Coordinate(3, 3),
                Orientation = EnumData.Orientation.E,
                Grid = new Grid(5, 5),
            };
            foreach (var item in inst)
            {
                if (item == "L")
                {
                    request.Instruction = EnumData.Instruction.L;
                }
                else if (item == "R")
                {
                    request.Instruction = EnumData.Instruction.R;
                }
                else if (item == "M")
                {
                    request.Instruction = EnumData.Instruction.M;
                }
                moveResult = _iroboot.Move(request);
                request.Coordinate = moveResult.Coordinate;
                request.Orientation = moveResult.Orientation;
            }

            Assert.AreEqual(moveResult.Coordinate.X, 5);
            Assert.AreEqual(moveResult.Coordinate.Y, 1);
            Assert.AreEqual(moveResult.Orientation, EnumData.Orientation.E);
        }
        [TestMethod]
        public void GetTotalPrice_Test()
        {
            string[] scan = new string[] { "B", "A", "B" };
            var totalPrice = _icheckout.GetTotalPrice(ScanItem(scan));
            Assert.AreEqual(totalPrice, 95);
        }
        [TestMethod]
        public void Scan_Test()
        {
            var items = _icheckout.Scan("B");
            Assert.AreEqual<Items>(items, items);
        }
        private List<Items> ScanItem(string[] parms)
        {
            List<Items> scanItems = new List<Items>();
            foreach (var item in parms)
            {
                var items = _icheckout.Scan(item);
                scanItems.Add(new Items() { SKU = items.SKU, UnitPrice = items.UnitPrice, SpecialPrice = items.SpecialPrice });
            }
            return scanItems;
        }
    }
}
