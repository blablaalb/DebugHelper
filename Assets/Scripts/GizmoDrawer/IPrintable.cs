using System;

namespace GizmoDrawer
{
    public interface IPrintable : IEquatable<IPrintable>
    {
        void Print();
    }
}
