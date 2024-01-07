using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonogameTest01;

public class Ray : IIntersectionGiving
{
    private Vector2 _vector;
    private FlatAngle _angle;

    public Vector2 Location { get => _vector; set => _vector = value; }
    public Vector2 Vector { get => new(0, 0); set => _vector += value; }
    public FlatAngle Angle { get => _angle; set => _angle = value; }

    public Vector2 Intersection(IIntersectionGiving value) =>
        value1.Angle != value2.Angle ||
        value1.C == value2.C;

    public Vector2 Intersection(Ray value) =>
        value1.Angle != value2.Angle ||
        value1.C == value2.C;

    public Ray(Vector2 vector, FlatAngle angle)
    {
        _vector = vector;
        _angle = angle;
    }
}