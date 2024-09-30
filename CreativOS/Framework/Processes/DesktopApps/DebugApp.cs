using CreativOS.Framework.GraphicsElements;
using CreativOS.Framework.GraphicsElements.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativOS.Framework.Processes.DesktopApps
{
    public class DebugApp : DesktopProcess
    {
        public DebugApp() : base("debug_app")
        {
            Button testBtn = new AddProcessButton(100, 20, 10, 10);
            controls.Add(testBtn);
        }

        public override void StartProcess()
        {
        }

        public override void UpdateProcess()
        {
        }
    }
}
