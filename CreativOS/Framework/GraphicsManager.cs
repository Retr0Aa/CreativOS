using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosTTF;
using CreativOS.Framework.GraphicsElements;
using CreativOS.Framework.GraphicsElements.Controls;
using CreativOS.Framework.Processes;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CreativOS.Framework
{
    public class GraphicsManager
    {
        Canvas canvas;
        CGSSurface surface;
        
        TTFFont notoRegular;
        TTFFont notoItalic;
        TTFFont notoBold;

        // Graphics Elements
        Taskbar taskbar;
        List<Window> windows;

        List<Process> processes;

        public GraphicsManager(List<Process> processes)
        {
            taskbar = new Taskbar();
            windows = new List<Window>();

            this.processes = processes;

            foreach (var process in processes)
            {
                if (process is DesktopProcess)
                {
                    windows.Add(new Window(600, 400, 100, 100, ((DesktopProcess) process).controls, "Hello World!"));
                }
            }
        }

        public void AddProcessGraphic(Process process)
        {
            processes.Add(process);

            windows.Add(new Window(600, 400, 100, 100, ((DesktopProcess)process).controls, "Hello World!"));
        }

        public void StartGraphics()
        {
            MouseManager.ScreenWidth = 1280;
            MouseManager.ScreenHeight = 720;

            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1280, 720, ColorDepth.ColorDepth32));
            surface = new CGSSurface(canvas);

            notoRegular = new TTFFont(File.ReadAllBytes(@"1:\NotoSans-Regular.ttf"));
            notoItalic = new TTFFont(File.ReadAllBytes(@"1:\NotoSans-Italic.ttf"));
            notoBold = new TTFFont(File.ReadAllBytes(@"1:\NotoSans-Bold.ttf"));
        }

        public void RenderGraphics()
        {
            // Clear the canvas
            canvas.Clear(Color.Gray);

            // Update and render all windows
            for (int i = 0; i < windows.Count; i++)
            {
                windows[i].RenderElement(canvas, surface, notoRegular, notoItalic, notoBold);
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

            // Render the taskbar
            taskbar.RenderElement(canvas, surface, notoRegular, notoItalic, notoBold);

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
