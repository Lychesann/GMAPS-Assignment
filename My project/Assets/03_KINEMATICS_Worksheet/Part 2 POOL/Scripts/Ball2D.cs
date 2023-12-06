using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0); //To get the starting position of the white ball
    public HVector2D Velocity = new HVector2D(0, 0); //To get the starting velocity of the white ball

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        //getting the x and y positions of the white ball
        Position.x = transform.position.x; 
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        //To get the position at 2 Hvector2D objects
        HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        float distance = Util.FindDistance(a, b); //This is to make sure that the mouse is colliding with the ball and not outside of it
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {

        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //This is to get the speed of the ball
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;
        
        //Change the position of the ball according to the speed that was used on the ball
        Position.x += displacementX;
        Position.y += displacementY;

        transform.position = new Vector2(Position.x, Position.y);
    }
}

