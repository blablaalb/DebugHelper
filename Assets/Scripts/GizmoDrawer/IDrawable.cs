using System;

namespace GizmoDrawer
{
    public interface IDrawable : IEquatable<IDrawable>
    {
        void Draw();
    }
}
