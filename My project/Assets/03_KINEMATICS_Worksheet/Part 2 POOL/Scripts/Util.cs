using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        return Mathf.Sqrt(p2.x *2 - p1.x * 2 + p2.y *2 + p1.y*2);
    }
}

