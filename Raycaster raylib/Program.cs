using Raylib_cs;

namespace Raycaster_raylib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(300, 300, "Raycaster");
            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawLine(0, 0, 300, 300, Color.WHITE);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}