using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ProgramingStudy
{
    public abstract class StudyBase
    {
        protected Logger _log;

        public StudyBase()
        {
            _log = LogManager.GetCurrentClassLogger();

        }
    }
}
