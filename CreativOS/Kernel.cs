using Cosmos.System;
using CreativOS.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CreativOS
{
    public class Kernel : Sys.Kernel
    {
        public GraphicsManager graphicsManager;

        protected override void BeforeRun()
        {
            System.Console.WriteLine("CreativOS Started Successfully!");

            graphicsManager = new GraphicsManager();
            graphicsManager.StartGraphics();
        }

        protected override void Run()
        {
            graphicsManager.RenderGraphics();
        }
    }
}
