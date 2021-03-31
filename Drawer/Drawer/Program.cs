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
            Action<object> Updates;
            ImageBox box = new ImageBox(new Vector2f(100,100), new Vector2i(124,140), "TestImage.jpg");
            //Console.WriteLine("*create box*");
            IImageBox proxyBox = new ProxyImageBox(box);
            //Console.WriteLine("*create proxy*");
            //_components.Add(box);
            _components.Add(proxyBox);

            //Updates += box.Update;
            Updates = proxyBox.Update;
            
            while(Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.Black);

                TryDrag();
                Updates(Keyboard.IsKeyPressed(Keyboard.Key.Space));

                //Window.Draw(box.Drawable);
                Window.Draw(proxyBox.Drawable);

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
                        //Console.WriteLine("Drag");
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