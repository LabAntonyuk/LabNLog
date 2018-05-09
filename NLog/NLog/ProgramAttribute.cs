using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    public class ProgramAttribute : System.Attribute
    {
        private string name;
        private string info;

        public ProgramAttribute(string name, string info)
        {
            this.name = name;
            this.info = info;
        }

        public virtual string ProgramName
        {
            get { return name; }
        }

        public virtual string ProgramInfo
        { 
            get { return info; }
        }
    }
}
