using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativOS.Framework
{
    public abstract class Process
    {
        protected ProcessInfo info;

        protected Process(ProcessInfo info)
        {
            this.info = info;
        }

        public abstract void StartProcess();

        public abstract void UpdateProcess();
    }

    public struct ProcessInfo
    {
        public ProcessType type;
        public string id;

        public ProcessInfo(ProcessType type, string id)
        {
            this.type = type;
            this.id = id;
        }
    }

    public enum ProcessType
    {
        None = 0,
        ConsoleApp = 1,
        DesktopApp = 2
    }
}
