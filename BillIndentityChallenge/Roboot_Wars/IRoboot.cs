using System;
using System.Collections.Generic;
using System.Text;

namespace BillIndentityChallenge.Roboot_Wars
{
    public interface IRoboot
    {
        MoveResult Move(MoveRequest request);
    }
}
