using Cosmos.System.Graphics;
using CosmosTTF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativOS.Framework.GraphicsElements
{
    public class Taskbar : IGraphicsElement
    {
        public int height = 30;

        public void RenderElement(Canvas canvas, CGSSurface surface, TTFFont notoRegular, TTFFont notoItalic, TTFFont notoBold)
        {
            canvas.DrawFilledRectangle(Color.Black, 0, 720 - height, 1280, height);
        }
    }
}
