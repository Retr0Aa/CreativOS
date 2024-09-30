using Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using CreativOS.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using CreativOS.Framework.Processes.DesktopApps;

namespace CreativOS
{
    public class Kernel : Sys.Kernel
    {
        public static Kernel Instance { get; set; }

        public GraphicsManager graphicsManager;
        public List<Process> processes;

        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(new CosmosVFS());

            System.Console.WriteLine("CreativOS Started Successfully!");

            Instance = this;

            processes = new List<Process>();

            processes.Add(new DebugApp());

            graphicsManager = new GraphicsManager(processes);
            graphicsManager.StartGraphics();
        }

        public void AddProcess(Process process)
        {
            processes.Add(process);
            graphicsManager.AddProcessGraphic(process);
        }

        protected override void Run()
        {
            graphicsManager.RenderGraphics();

            foreach (var process in processes)
            {
                process.UpdateProcess();
            }
        }
    }
}
