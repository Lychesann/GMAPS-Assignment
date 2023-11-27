using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);
        moveDir.Normalize();
        moveDir *= -1;

        rb.AddForce(rb.velocity);
        gravityDir.Normalize();
        
        rb.AddForce(gravityDir.ToUnityVector2() * gravityStrength);

        //float angle = Vector3.SignedAngle(Vector3.up, moveDir,  Vector3.forward);

        //rb.MoveRotation(Quaternion.Euler(angle));

        //DebugExtension.DebugArrow(Vector3.zero, Mario.ToUnityVector3(), Color.red);
        //DebugExtension.DebugArrow(Vector3.zero, Mario.ToUnityVector3(), Color.blue);
    }
}
