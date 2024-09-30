using Cosmos.System;
using Cosmos.System.Graphics;
using CreativOS.Framework.GraphicsElements;
using System.Collections.Generic;
using System.Drawing;

namespace CreativOS.Framework
{
    public class GraphicsManager
    {
        Canvas canvas;

        // Graphics Elements
        Taskbar taskbar;
        List<Window> windows;

        public GraphicsManager()
        {
            taskbar = new Taskbar();
            windows = new List<Window>();

            // Adding some windows for demonstration
            windows.Add(new Window(600, 400, 300, 100));
            windows.Add(new Window(600, 400, 100, 100));
        }

        public void StartGraphics()
        {
            MouseManager.ScreenWidth = 1280;
            MouseManager.ScreenHeight = 720;

            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1280, 720, ColorDepth.ColorDepth32));
        }

        public void RenderGraphics()
        {
            // Clear the canvas
            canvas.Clear(Color.Gray);

            // Render the taskbar
            taskbar.RenderElement(canvas);

            // Update and render all windows
            for (int i = 0; i < windows.Count; i++)
            {
                windows[i].RenderElement(canvas);
                windows[i].Update();

                // Check if the window is active and bring it to the top
                if (windows[i].IsActive())
                {
                    // Move the active window to the end of the list (bring it on top)
                    Window activeWindow = windows[i];
                    windows.RemoveAt(i);  // Remove from its current position
                    windows.Add(activeWindow);  // Add to the end (on top)
                    break;  // Only move one window per frame
                }
            }

            // Draw the mouse cursor
            int mouseX = (int)MouseManager.X;
            int mouseY = (int)MouseManager.Y;
            canvas.DrawFilledCircle(Color.Black, mouseX, mouseY, 6 - 2);
            canvas.DrawFilledCircle(Color.White, mouseX, mouseY, 5 - 2);

            // Display the canvas
            canvas.Display();
        }
    }
}
