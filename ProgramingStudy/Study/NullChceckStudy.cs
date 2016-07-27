using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public static class NullChceck
    {
        public static TRezult With<TInput, TRezult>(this TInput o, Func<TInput, TRezult> evaluator)
            where TRezult : class
            where TInput : class
        {
            return o == null ? null : evaluator(o);
        }
    }
    
    class NullChceckStudy : IStudyTest
    {
        public void Study()
        {
            Object f = null;
        }
    }
}
