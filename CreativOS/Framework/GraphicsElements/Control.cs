using Cosmos.System.Graphics;
using CosmosTTF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativOS.Framework.GraphicsElements
{
    public abstract class Control
    {
        protected int x, y;
        protected int defaultX, defaultY;

        public abstract void RenderControl(Canvas canvas, CGSSurface surface, TTFFont notoRegular, TTFFont notoItalic, TTFFont notoBold);

        protected Control(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.defaultX = x;
            this.defaultY = y;
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetPositionX() { return this.x; }
        public int GetPositionY() { return this.y; }

        public int GetDefaultX() { return this.defaultX; }
        public int GetDefaultY() { return this.defaultY; }
    }
}
