using System;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class DirectionExtensions
{
    // в тапле первое поле отображает направление по горизонтали,
    // второе – по вертикали:
    // Leftwards – вверх, Rightwards – вниз
    public static (Directions.Onedimensional.Enum, Directions.Onedimensional.Enum) Direction(Vector2 velocity) =>
    (Math.Sign(velocity.X), Math.Sign(velocity.Y)) switch
    {
        (-1, -1) =>
        (Directions.Onedimensional.Enum.Leftwards, Directions.Onedimensional.Enum.Leftwards),
        (1, -1) =>
        (Directions.Onedimensional.Enum.Rightwards, Directions.Onedimensional.Enum.Leftwards),
        (-1, 1) =>
        (Directions.Onedimensional.Enum.Leftwards, Directions.Onedimensional.Enum.Rightwards),
        (1, 1) =>
        (Directions.Onedimensional.Enum.Rightwards, Directions.Onedimensional.Enum.Rightwards),
        _ => throw new NotImplementedException()
    };
}
