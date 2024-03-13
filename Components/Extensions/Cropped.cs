using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class CroppedExtensions
{
    public static Vector2 Cropped(this Vector2 @this, Surface value)
    {
        var resized = @this.Resized(value);
        var cropped = resized - @this;

        var @thisNormalized = @this;
        @thisNormalized.Normalize();
        var croppedNormalized = cropped;
        croppedNormalized.Normalize();
        if (croppedNormalized == @thisNormalized)
            return Vector2.Zero;
        else
            return cropped;
    }
}
