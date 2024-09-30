using Cosmos.System.Graphics;
using CosmosTTF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativOS.Framework
{
    public interface IGraphicsElement
    {
        public void RenderElement(Canvas canvas, CGSSurface surface, TTFFont notoRegular, TTFFont notoItalic, TTFFont notoBold);
    }
}
