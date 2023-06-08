using Raylib_cs;
using System.Numerics;

namespace Raycaster_raylib
{
    public class Player
    {
        public static Player? Instance;

        Vector2 position;
        float rotation;

        int health;
        float speed = 5f;

        public Player(Vector2 startingPosition, float initialRotation)
        {
            Instance = this;

            position = startingPosition;
            rotation = initialRotation;
        }

        ~Player() 
        { 
            Instance = null;
        }

        public void Update()
        {
            if (Renderer.Instance.RenderingMap)
            {
                Renderer.Instance?.DrawPixelMap((int)position.X, (int)position.Y, Color.RED);
            }
        }
    }
}
