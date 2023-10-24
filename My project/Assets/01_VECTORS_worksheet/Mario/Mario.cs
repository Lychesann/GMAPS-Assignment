using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = planet.position - transform.position;
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force);

        gravityNorm = gravityNorm.normalized;
        rb.AddForce(gravityNorm * gravityStrength);
        float angle = Vector3.SignedAngle(gravityNorm, moveDir , Vector3.right);

        rb.MoveRotation(Quaternion.Euler(new Vector3 (0, 0, angle)));


        DebugExtension.DebugArrow(Vector3.zero, gravityDir, Color.red);
        DebugExtension.DebugArrow(Vector3.zero, moveDir, Color.blue);
    }
}


