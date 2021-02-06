using SFML.Graphics;
using SFML.System;

namespace Drawer
{
    public class ImageBox : IImageBox
    {
        private bool _isDraged;
        public bool IsDragged { get; }

        private Vector2i _mouseCoordinates;
        public Vector2i MouseCoordinates { get; }

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
        }

        public Vector2f Position
        {
            get => Sprite.Position;
            set => Sprite.Position = new Vector2f(value.X, value.Y);
        }

        public Vector2i Size { get; set; }
        public Sprite Sprite { get; set; }

        public Texture Texture { get; set; }

        public void Update()
        {
            if (_isDraged) Move(_mouseCoordinates);
        }

        public ImageBox(Vector2f position, Vector2i size, string file)
        {
            Size = new Vector2i(size.X, size.Y);
            Texture = new Texture(file);
            Sprite = new Sprite(Texture, new IntRect(new Vector2i(0, 0), (Vector2i) Texture.Size))
            {
                Position = new Vector2f(position.X, position.Y)
            };
        }
    }
}