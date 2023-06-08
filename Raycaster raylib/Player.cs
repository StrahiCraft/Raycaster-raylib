using Raylib_cs;
using System.Numerics;

namespace Raycaster_raylib
{
    public class Player
    {
        public static Player? Instance;

        Vector2 position;
        float rotation;
        Vector2 direction;

        int health;
        float speed = 5f;

        public Player(Vector2 startingPosition, float initialRotation)
        {
            Instance = this;

            position = startingPosition;
            rotation = initialRotation;

            RotatePlayer(0);
        }

        ~Player() 
        { 
            Instance = null;
        }

        public void Update()
        {
            if (Renderer.Instance.RenderingMap) 
            {
                Vector2 centeredPosition = new Vector2(position.X - 0.5f, position.Y - 0.5f);

                Renderer.Instance?.DrawPlayer(centeredPosition);

                Renderer.Instance?.DrawDirectionRay(position, direction);

                Raylib.DrawText("X: " + position.X + " Y: " + position.Y + " ROTATION: " + rotation, 0, 0, 20, Color.BLACK);
            }


        }

        public void MovePlayer(int multiplier)
        {
            Vector2 newPosition = position + direction * multiplier * Raylib.GetFrameTime();

            if (Renderer.Instance?.map[(int)newPosition.Y][(int)newPosition.X] == '.')
            {
                position = newPosition;
            }
        }

        public void RotatePlayer(float angle)
        {
            rotation += angle * Raylib.GetFrameTime();

            rotation %= 2 * float.Pi;

            if(rotation < 0)
            {
                rotation = 2 * float.Pi - angle * Raylib.GetFrameTime();
            }

            direction.X = (float)Math.Cos(rotation) * speed;
            direction.Y = (float)Math.Sin(rotation) * speed;
        }
    }
}
