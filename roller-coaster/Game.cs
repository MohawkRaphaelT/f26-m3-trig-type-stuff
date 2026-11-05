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
    int position = 0;

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Roller Coaster");
        Window.SetSize(360, 400);
    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        Vector2[] circlePoints = new Vector2[360+1];
        // loop through angles in increments of 1
        for (int i = 0; i < circlePoints.Length; i++)
        {
            circlePoints[i] = GetPointOnLoopedyLoop(i);
        }

        Draw.LineSize = 5;
        Draw.LineColor = Color.Red;
        Draw.PolyLine(circlePoints);

        Draw.LineSize = 0;
        Draw.FillColor = Color.Black;
        for (int i = 0; i < 12; i++)
        {
            Vector2 pointOnRollercoaster = GetPointOnLoopedyLoop(position + i);
            Draw.Circle(pointOnRollercoaster, 10);
        }

        // If P down, move the guy
        if (Input.IsKeyboardKeyDown(KeyboardKey.P))
        {
            position += 1;
        }

        // Reset
        if (Input.IsKeyboardKeyPressed(KeyboardKey.Space))
        {
            position = 0;
        }
    }

    Vector2 GetPointOnLoopedyLoop(int angleDeg)
    {
        // Go from 90 counter-clockwise to -270
        int angleDegrees = 90 - angleDeg;
        float angleRadians = angleDegrees / 360f * MathF.Tau;
        // Calculate points on circle
        float x = MathF.Cos(angleRadians);
        float y = MathF.Sin(angleRadians);
        Vector2 point = new Vector2(x, y);
        Vector2 start = new Vector2(0, 175);
        Vector2 offset = new Vector2(angleDeg, 0);
        Vector2 finalPoint = point * 150 + start + offset;

        return finalPoint;
    }
}
