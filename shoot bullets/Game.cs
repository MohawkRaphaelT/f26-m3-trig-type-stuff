// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    Vector2 target;
    Vector2 player;
    Bullet[] bullets = new Bullet[9];

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Bullet Hell");
        Window.SetSize(400, 400);

        target = Window.Size / 2;
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = new Bullet();
        }
    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);
        player = Input.GetMousePosition();
        float radius = 20;

        // Move target
        if (Input.IsMouseButtonDown(MouseButton.Left) == true)
        {
            target = Input.GetMousePosition();
        }

        // Shoot
        if (Input.IsKeyboardKeyPressed(KeyboardKey.Space) == true)
        {
            // what is the angle to the target?
            Vector2 vectorFromPlayerToTarget = target - player;
            float y = vectorFromPlayerToTarget.Y;
            float x = vectorFromPlayerToTarget.X;
            // RADIANS!
            float angleFromPlayerToTarget = MathF.Atan2(y, x);

            float spreadRangeDegrees = 65;
            float spreadRangeRadians = spreadRangeDegrees / 360 * MathF.Tau;

            Draw.LineSize = 1;
            Draw.LineColor = Color.Blue;
            for (int i = 0; i < bullets.Length; i++)
            {
                float percent = i / (float)bullets.Length;
                float angle =
                    angleFromPlayerToTarget
                    - spreadRangeRadians / 2
                    + spreadRangeRadians * percent;
                Vector2 direction = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
                bullets[i].Setup(player, direction * 100);
            }
        }

        foreach (Bullet bullet in bullets)
            bullet.UpdatePosition();

        Draw.LineColor = Color.Black;
        Draw.FillColor = Color.Black;
        Draw.Circle(player, radius);

        Draw.LineSize = 3;
        Draw.LineColor = Color.Red;
        Draw.FillColor = new Color(0,0,0,0);
        Draw.Circle(target, radius);
        Draw.Line(target - Vector2.UnitX * radius, target + Vector2.UnitX * radius);
        Draw.Line(target - Vector2.UnitY * radius, target + Vector2.UnitY * radius);

        foreach (Bullet bullet in bullets)
            bullet.Render();

    }
}
