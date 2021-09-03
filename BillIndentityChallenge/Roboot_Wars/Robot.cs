using System;
using System.Collections.Generic;
using System.Text;

namespace BillIndentityChallenge.Roboot_Wars
{
    public class Robot : IRoboot
    {
        private const int numOrientations = 4;
        public MoveResult Move(MoveRequest request)
        {
            MoveResult moveResult = new MoveResult();
            try
            {
                switch (request.Instruction)
                {
                    case EnumData.Instruction.R:
                        moveResult.Orientation = (EnumData.Orientation)Enum.ToObject(typeof(EnumData.Orientation), (((int)request.Orientation + numOrientations + 1) % numOrientations));
                        moveResult.Coordinate = request.Coordinate;
                        break;
                    case EnumData.Instruction.L:
                        moveResult.Orientation = (EnumData.Orientation)Enum.ToObject(typeof(EnumData.Orientation), (((int)request.Orientation + numOrientations - 1) % numOrientations));
                        moveResult.Coordinate = request.Coordinate;
                        break;
                    case EnumData.Instruction.M:
                        Coordinate newPos;
                        switch (request.Orientation)
                        {
                            case EnumData.Orientation.N:
                                newPos = new Coordinate(request.Coordinate.X, request.Coordinate.Y + 1);
                                moveResult.Orientation = request.Orientation;
                                break;
                            case EnumData.Orientation.E:
                                newPos = new Coordinate(request.Coordinate.X + 1, request.Coordinate.Y);
                                moveResult.Orientation = request.Orientation;
                                break;
                            case EnumData.Orientation.S:
                                newPos = new Coordinate(request.Coordinate.X, request.Coordinate.Y - 1);
                                moveResult.Orientation = request.Orientation;
                                break;
                            case EnumData.Orientation.W:
                                newPos = new Coordinate(request.Coordinate.X - 1, request.Coordinate.Y);
                                moveResult.Orientation = request.Orientation;
                                break;
                            default:
                                newPos = new Coordinate(-1, -1);
                                break;
                        }
                        if (request.Grid.IsValid(newPos))
                        {
                            moveResult.Coordinate = newPos;
                        }
                        else
                        {
                            moveResult = new MoveResult();
                        }
                        break;
                }
            }
            catch
            {
                return moveResult;
            }
            return moveResult;
        }
    }
}
