using System;
using System.Numerics;

namespace MohawkGame2D;

public class Bullet
{
    Vector2 position = Vector2.UnitX * 100000;
    Vector2 velocity;

    public void Setup(Vector2 position, Vector2 velocity)
    {
        this.position = position;
        this.velocity = velocity;
    }

    public void UpdatePosition()
    {
        position += velocity * Time.DeltaTime;
    }

    public void Render()
    {
        Draw.LineSize = 0;
        Draw.FillColor = Color.Red;
        Draw.Circle(position, 5);
    }
}
