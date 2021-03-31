using SFML.Graphics;
using SFML.System;

namespace Drawer
{
    public class ImageBox : IImageBox
    {
        private bool _isDraged;
        public bool IsDragged { get; }

        private Vector2i _mouseCoordinates;

        public Vector2i MouseCoordinates { get => _mouseCoordinates; }

        public void Drag()
        {
            _isDraged = true;
        }

        public void Drop()
        {
            _isDraged = false;
        }

        public bool IsMouseIn(Vector2i mouseCoordinates)
        {
            _mouseCoordinates = mouseCoordinates;
            return mouseCoordinates.X > Position.X && mouseCoordinates.X < Position.X + Size.X &&
                   mouseCoordinates.Y > Position.Y && mouseCoordinates.Y < Position.Y + Size.Y;
        }

        public void Move(Vector2i mouseCoordinates)
        {
            Position = new Vector2f((float) (mouseCoordinates.X - Size.X / 2),
                (float) (mouseCoordinates.Y - Size.Y / 2));
            if (Sprite != null)
            { 
                Sprite.Position = Position; 
            }
        }

        public Vector2i Size { get; set; }

        private string File { get; set; }
        private Sprite Sprite { get; set; }
        public Drawable Drawable 
        {
            get
            {
                if(Sprite == null)
                {
                    Texture Texture = new Texture(File);
                    Sprite = new Sprite(Texture, new IntRect(new Vector2i(0, 0), Size));
                    Sprite.Position = new Vector2f(Position.X, Position.Y);

                }
                return Sprite;
            }
        }

        public void Update(object e)
        {
            if (_isDraged) Move(_mouseCoordinates);
        }

        public ImageBox(Vector2f position, Vector2i size, string file)
        {
            Size = new Vector2i(size.X, size.Y);
            File = file;
            Position = position;                    
        }

        public Vector2f Position { get; set; }


    }
}