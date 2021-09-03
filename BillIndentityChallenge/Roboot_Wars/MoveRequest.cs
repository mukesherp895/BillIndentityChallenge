using System;
using System.Collections.Generic;
using System.Text;

namespace BillIndentityChallenge.Roboot_Wars
{
    public class MoveRequest
    {
        public EnumData.Instruction Instruction { get; set; }
        public Grid Grid { get; set; }
        public Coordinate Coordinate { get; set; }
        public EnumData.Orientation Orientation { get; set; }
    }
}
