using System;
using System.Windows;

namespace ProgramingStudy
{
    public abstract class StanGry : ICloneable, IStudyTest
    {
        public int Poziom { get; set; }

        public abstract object Clone();

        public void Study()
        {
            throw new NotImplementedException();
        }
    }


    public class Gra : StanGry
    {
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
