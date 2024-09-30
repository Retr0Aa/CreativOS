using CreativOS.Framework.GraphicsElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativOS.Framework.Processes
{
    public abstract class DesktopProcess : Process
    {
        public List<Control> controls;

        protected DesktopProcess(string id) : base(new ProcessInfo(ProcessType.DesktopApp, id))
        {
            controls = new List<Control>();
        }
    }
}
