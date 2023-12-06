using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        float dx = Velocity.x *dt; //To get the velocity on the x axis per frame
        float dy = Velocity.y *dt;//To get the velocity on the y axis per frame
        float dz = Velocity.z *dt;//To get the velocity on the z axis per frame

        transform.Translate(new Vector3(dx, dy, dz)); //translate accordingly on the x,y,z axis
    }
}
