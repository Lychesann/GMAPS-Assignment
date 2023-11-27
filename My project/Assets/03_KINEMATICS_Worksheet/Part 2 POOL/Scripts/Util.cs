using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        float px = p1.x - p2.x;
        float py = p1.y - p2.y;
        float mag = px * px + py * py;
        return Mathf.Sqrt(mag);
    }
}

