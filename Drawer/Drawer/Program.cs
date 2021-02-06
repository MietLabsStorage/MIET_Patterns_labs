using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Drawer
{
    class Program
    {
        static List<IDraggableAndDroppable> _components = new List<IDraggableAndDroppable>();
        private static RenderWindow Window;
        
        static void Main(string[] args)
        {
            Window = new RenderWindow(new VideoMode(800, 600), "NoProxy");
            Window.Closed += (object sender, EventArgs e) => Window.Close();
            Action Updates = () => { };
            ImageBox box = new ImageBox(new Vector2f(100,100), new Vector2i(100,100), "TestImage.jpg");
            _components.Add(box);
            Updates += box.Update;
            
            while(Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.White);

                TryDrag();
                Updates();

                Window.Draw(box.Sprite);
                    
                Window.Display();
            }
        }

        public static void TryDrag()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Vector2i mouseCoordinates = Mouse.GetPosition(Window);
                //Console.WriteLine(Mouse.GetPosition());
                foreach (var component in _components)
                {
                    if (component.IsMouseIn(mouseCoordinates))
                    {
                        component.Drag();
                    }
                }
            }
            else
            {
                _components.Where((x => x.IsDragged)).FirstOrDefault()?.Drop();
            }
        }
    }
}