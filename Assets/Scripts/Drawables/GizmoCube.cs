using UnityEngine;
using System;

[Serializable]
public class GizmoCube : IDrawable
{
    public readonly Vector3 Origin;
    public readonly Vector3 Size;

    public GizmoCube(Vector3 origin, Vector3 size)
    {
        Origin = origin;
        Size = size;
    }

    public void Draw()
    {
        Gizmos.DrawCube(Origin, Size);
    }

    public bool Equals(IDrawable other)
    {
        GizmoCube otherGC = other as GizmoCube;
        return otherGC != null && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
    }

    public override bool Equals(object other)
    {
        GizmoCube otherGC = other as GizmoCube;
        return otherGC != null && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
    }
}