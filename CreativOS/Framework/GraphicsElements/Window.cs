using Cosmos.System.Graphics;
using Cosmos.System;
using System.Drawing;
using System.Collections.Generic;
using CreativOS.Framework.GraphicsElements.Controls;
using CosmosTTF;

namespace CreativOS.Framework.GraphicsElements
{
    public class Window : IGraphicsElement
    {
        private int width;
        private int height;
        private int posX;
        private int posY;
        private string title;
        private bool isDragging = false;
        private int dragOffsetX;
        private int dragOffsetY;
        private int topBarHeight;
        private static Window activeWindow = null;  // Tracks the currently focused window

        private List<Control> controls;

        public Window(int width, int height, int posX, int posY, List<Control> controls, string title)
        {
            this.width = width;
            this.height = height;
            this.posX = posX;
            this.posY = posY;
            this.title = title;

            topBarHeight = 20;

            this.controls = controls;
        }

        public bool IsActive()
        {
            return activeWindow == this;  // Check if this window is the active one
        }

        public void Update()
        {
            // Get mouse coordinates from MouseManager
            int mouseX = (int)MouseManager.X;
            int mouseY = (int)MouseManager.Y;

            // If the window is currently being dragged or is the active window
            if (isDragging || activeWindow == this)
            {
                // Check if the left mouse button is released, stop dragging
                if (MouseManager.MouseState == MouseState.None)
                {
                    isDragging = false;
                    activeWindow = null;  // Release active window
                }
                // Update position if still dragging
                else if (isDragging)
                {
                    posX = mouseX - dragOffsetX;
                    posY = mouseY - dragOffsetY;
                }
            }

            // Check if mouse clicked inside title bar and no other window is active
            if (MouseManager.MouseState == MouseState.Left && activeWindow == null)
            {
                if (mouseX >= posX && mouseX <= posX + width && mouseY >= posY && mouseY <= posY + topBarHeight)
                {
                    // Start dragging and make this window active
                    isDragging = true;
                    activeWindow = this;
                    dragOffsetX = mouseX - posX;
                    dragOffsetY = mouseY - posY;
                }
            }
        }

        public void RenderElement(Canvas canvas, CGSSurface surface, TTFFont notoRegular, TTFFont notoItalic, TTFFont notoBold)
        {
            // Shadow effect
            for (int i = 0; i < 5; i++)
            {
                if (i * 40 < 100)
                    canvas.DrawRectangle(Color.FromArgb(i * 50, i * 50, i * 50), posX - i, posY - i, width + i * 2, height + i * 2);
            }

            // Draw window body
            canvas.DrawFilledRectangle(Color.White, posX, posY, width, height);
            canvas.DrawRectangle(Color.Black, posX, posY, width, height);

            // Draw title bar
            int gradientCounter = 100;
            for (int y = 0; y < topBarHeight; y++)
            {
                if (gradientCounter >= 0)
                {
                    canvas.DrawLine(Color.FromArgb(gradientCounter, gradientCounter, gradientCounter), posX, posY + y, width + posX, posY + y);
                    gradientCounter-=2;
                }
            }

            if (activeWindow == this)
                canvas.DrawFilledRectangle(Color.Blue, posX, posY, width, 3);

            notoBold.DrawToSurface(surface, 16, posX + 3, posY + topBarHeight - 3, title, Color.White);

            canvas.DrawRectangle(Color.Black, posX, posY, width, topBarHeight);

            foreach (var control in controls)
            {
                control.SetPosition(posX + 1 + control.GetDefaultX(), posY + topBarHeight + 1 + control.GetDefaultY());

                control.RenderControl(canvas, surface, notoRegular, notoItalic, notoBold);
            }
        }
    }
}
