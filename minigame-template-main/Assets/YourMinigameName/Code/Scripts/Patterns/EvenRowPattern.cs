using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    internal class EvenRowPattern : Pattern
    {
        public override string Name => "Even Row Pattern";

        public override bool[,] GetPatternMatrix()
        {
            return new bool[10, 10]
            {
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
            };
        }
    }
}
