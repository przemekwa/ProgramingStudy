using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy
{
    public class Prototyp : ICloneable
    {
        public Point PolozeniePoint { get; set; }

        public Point PolozeniePunkt { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class TestPrototyp
    {
        public TestPrototyp()
        {
            var obj1 = new Prototyp
            {
                PolozeniePoint = new Point(0, 0),
                PolozeniePunkt = new Point(1, 1)
            };


            var obj2 = (Prototyp)obj1.Clone();
        }
    }
}
