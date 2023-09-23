using Godot;
using System;

public class Ball : KinematicBody2D
{
    private int speed = 500;
    private Vector2 velocity = Vector2.Zero;

    public override void _Ready()
    {
        InitializeBallDirection();
    }

    private void InitializeBallDirection()
    {
        GD.Randomize();
        int[] xArray = new int[] { -1, 1 };
        float[] yArray = new float[] { -0.5f, 0.5f };
        velocity.x = xArray[GD.Randi() % 2];
        velocity.y = yArray[GD.Randi() % 2];
    }

        public override void _PhysicsProcess(float delta)
        {
            var colliding = MoveAndCollide(velocity * speed * delta);
            if (colliding != null)
            {
                velocity = velocity.Bounce(colliding.Normal);
            }
        }
}