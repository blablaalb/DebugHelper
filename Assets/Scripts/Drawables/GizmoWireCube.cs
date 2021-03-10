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
        GizmoWireCube otherGWC = other as GizmoWireCube;
        return otherGWC.Equals(this.Origin) && otherGWC.Equals(this.Size);
    }
}