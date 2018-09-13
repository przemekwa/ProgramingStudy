using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class ScaleRatio : IStudyTest
    {
        public void Study()
        {

            int w0 = 4256;
            int h0 = 2832;

           double ratio =  Convert.ToDouble(w0) / Convert.ToDouble(h0);

                double scale = Convert.ToDouble(Math.Sqrt((w0*h0) / 10_000_000));

                var h= Math.Floor(h0/scale);
                var w= Math.Floor(ratio*h0/scale);

                w0 = Convert.ToInt32(w);
                h0 = Convert.ToInt32(h);


            var q = w0*h0;
                


        }
    }
}
