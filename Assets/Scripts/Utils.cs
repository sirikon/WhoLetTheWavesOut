using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Utils
{
    public static float DistanceBetween(Vector3 a, Vector3 b)
    {
        return (a - b).magnitude;
    }
        
    public static Vector3 DirectionFromAToB(Vector3 a, Vector3 b)
    {
        var heading = b - a;
        var distance = heading.magnitude;
        return heading / distance;
    }
}
