using Cosmos.System.Graphics;
using Cosmos.System;
using System.Drawing;
using CosmosTTF;

namespace CreativOS.Framework.GraphicsElements.Controls
{
    public abstract class Button : Control
    {
        private int width, height;
        private string label;

        private bool isClicked = false;

        public Button(int width, int height, int x, int y, string label) : base(x, y)
        {
            this.width = width;
            this.height = height;
            this.label = label;
        }

        public override void RenderControl(Canvas canvas, CGSSurface surface, TTFFont notoRegular, TTFFont notoItalic, TTFFont notoBold)
        {
            // Draw the button with gradient effect
            if (isClicked)
            {
                // Reverse gradient (light to dark)
                int gradientCounter = 100;
                for (int yinc = 0; yinc < height; yinc++)
                {
                    if (gradientCounter >= 0)
                    {
                        canvas.DrawLine(Color.FromArgb(100 - gradientCounter, 100 - gradientCounter / 2, 255 - gradientCounter), x, y + yinc, width + x, y + yinc);
                        gradientCounter -= 2;
                    }
                }
            }
            else
            {
                // Normal gradient (dark to light)
                int gradientCounter = 100;
                for (int yinc = 0; yinc < height; yinc++)
                {
                    if (gradientCounter >= 0)
                    {
                        canvas.DrawLine(Color.FromArgb(gradientCounter - 50, gradientCounter - 10, gradientCounter + 50), x, y + yinc, width + x, y + yinc);
                        gradientCounter -= 2;
                    }
                }
            }

            notoRegular.DrawToSurface(surface, 16, x + 3, y + height - 4, label, Color.White);

            canvas.DrawRectangle(Color.FromArgb(19, 56, 92), x, y, width, height);
            canvas.DrawRectangle(Color.FromArgb(19, 56, 92), x - 1, y - 1, width + 2, height + 2);
            canvas.DrawRectangle(Color.FromArgb(19, 56, 92), x + 1, y + 1, width - 2, height - 2);
            canvas.DrawRectangle(Color.FromArgb(29, 66, 102), x + 3, y + 3, width - 5, height - 5);

            // Handle click detection
            HandleClick();
        }

        private void HandleClick()
        {
            int mouseX = (int)MouseManager.X;
            int mouseY = (int)MouseManager.Y;

            // Check if the mouse is within the button's bounds
            if (mouseX >= x && mouseX <= x + width && mouseY >= y && mouseY <= y + height)
            {
                // Check if the left mouse button is clicked
                if (MouseManager.MouseState == MouseState.Left && !isClicked)
                {
                    isClicked = true;  // Button is clicked

                    OnClick();
                }
                else if (MouseManager.MouseState == MouseState.None)
                {
                    // Reset click state when the mouse button is released
                    isClicked = false;
                }
            }
        }

        protected abstract void OnClick();
    }
}
