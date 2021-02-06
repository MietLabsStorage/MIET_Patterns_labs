using SFML.Graphics;
using SFML.System;

namespace Drawer
{
    public interface IImageBox: IDraggableAndDroppable
    {
        /// <summary>
        /// position
        /// </summary>
        Vector2f Position { get; set; }
        
        /// <summary>
        /// size
        /// </summary>
        Vector2i Size { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        Sprite Sprite { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        Texture Texture { get; set; }
        
        /// <summary>
        /// update
        /// </summary>
        void Update();
        
        
    }
}