using UnityEngine;
using System;

[Serializable]
public class GizmoWireCube : IDrawable
{
    public readonly Vector3 Origin;
    public readonly Vector3 Size;

    public GizmoWireCube(Vector3 origin, Vector3 size)
    {
        Origin = origin;
        Size = size;
    }

    public void Draw()
    {
        Gizmos.DrawWireCube(Origin, Size);
    }

    public bool Equals(IDrawable other)
    {
        GizmoWireCube otherGC = other as GizmoWireCube;
        return otherGC != null && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
    }

    public override bool Equals(object other)
    {
        GizmoWireCube otherGC = other as GizmoWireCube;
        return otherGC != null && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
    }
}