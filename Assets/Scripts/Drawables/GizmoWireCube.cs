using UnityEngine;
using System;

[Serializable]
public class GizmoWireCube : IDrawable
{
    private readonly Color _color;

    public readonly Vector3 Origin;
    public readonly Vector3 Size;

    public GizmoWireCube(Vector3 origin, Vector3 size, Color color)
    {
        _color = color;
        Origin = origin;
        Size = size;
    }

    public void Draw()
    {
        Color previousColor = Gizmos.color;
        Gizmos.color = _color;
        Gizmos.DrawWireCube(Origin, Size);
        Gizmos.color = previousColor;
    }

    public bool Equals(IDrawable other)
    {
        return other is GizmoWireCube otherGC && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
    }

    public override bool Equals(object other)
    {
        return other is GizmoWireCube otherGC && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
    }
}
