using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    class ProxyImageBox : IImageBox
    {
        private RectangleShape RectangleShape { get; set; }
        private ImageBox ImageBox { get; set; }
        private bool _isImage = false;

        public Vector2f Position { get => ImageBox.Position; set => ImageBox.Position = value; }
        public Vector2i Size { get =>ImageBox.Size; set => ImageBox.Size = value; }

        //rewriten
        public Drawable Drawable => _isImage ? ImageBox.Drawable : RectangleShape;

        public bool IsDragged => ImageBox.IsDragged;

        public Vector2i MouseCoordinates => ImageBox.MouseCoordinates;

        public ProxyImageBox(ImageBox imageBox)
        {
            this.ImageBox = imageBox;
            RectangleShape = new RectangleShape(new Vector2f(ImageBox.Size.X, ImageBox.Size.Y));
        }

        //rewriten
        public void Update(object e)
        {
            ImageBox.Update(e);
            RectangleShape.Position = ImageBox.Position;
            if ((e as bool?) ?? false)
            {
                _isImage = true;
            }

        }

        public void Drag()
        {
            ImageBox.Drag();
        }

        public void Drop()
        {
            ImageBox.Drop();
        }

        public bool IsMouseIn(Vector2i mouseCoordinates)
        {
            return ImageBox.IsMouseIn(mouseCoordinates);
        }

        public void Move(Vector2i mouseCoordinates)
        {
            ImageBox.Move(mouseCoordinates);
        }
    }
}
