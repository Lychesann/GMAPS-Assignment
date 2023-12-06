using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //This is using the magnitude from HVector2D to get the distance of p1 and p2
        return (p2 - p1).Magnitude();
    }
}

