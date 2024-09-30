using CreativOS.Framework.Processes.DesktopApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativOS.Framework.GraphicsElements.Controls
{
    public class AddProcessButton : Button
    {
        public AddProcessButton(int width, int height, int x, int y) : base(width, height, x, y, "Test Add Process")
        {
        }

        protected override void OnClick()
        {
            Kernel.Instance.AddProcess(new DebugApp());
        }
    }
}
