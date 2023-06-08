using Raylib_cs;

namespace Raycaster_raylib
{
    internal class Program
    {
        static int width = 800;
        static int height = 600;

        static int pixelSize = 10;

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, "Raycaster");
            Renderer renderer = new Renderer(pixelSize, width, height);
            Player player = new Player(new System.Numerics.Vector2(2, 3), 0);

            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                // GAMELOOP

                InputHandler.HandleInput();
                renderer.Render();
                player.Update();

                // GAMELOOP

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}