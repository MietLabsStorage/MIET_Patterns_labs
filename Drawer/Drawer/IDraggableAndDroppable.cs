using SFML.System;

namespace Drawer
{
    public interface IDraggableAndDroppable
    {
        /// <summary>
        /// is component dragged now
        /// </summary>
        bool IsDragged { get; }
        
        /// <summary>
        /// current mouse coordinates
        /// </summary>
        Vector2i MouseCoordinates { get; }
        
        /// <summary>
        /// drag gomponent
        /// </summary>
        void Drag();

        /// <summary>
        /// drop component
        /// </summary>
        void Drop();

        /// <summary>
        /// is mouse coordinates in component;
        /// </summary>
        /// <param name="mouseCoordinates">mouse coordinates</param>
        /// <returns></returns>
        bool IsMouseIn(Vector2i mouseCoordinates);

        /// <summary>
        /// move component
        /// </summary>
        /// <param name="mouseCoordinates"></param>
        void Move(Vector2i mouseCoordinates);
    }
}