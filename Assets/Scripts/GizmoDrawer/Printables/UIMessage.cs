using System.Collections.Generic;
using GizmoDrawer.Drawables;
using System.Collections;
using UnityEngine;
using System;

namespace GizmoDrawer.Printables
{
    public struct UIMessage : IEquatable<UIMessage>
    {
        public readonly IPrintable Printable;
        public readonly int Count;

        public UIMessage(IPrintable printable, int count)
        {
            this.Printable = printable;
            this.Count = count;
        }


        public bool Equals(UIMessage other)
        {
            return other.Printable.Equals(this.Printable) && other.Count.Equals(this.Count);
        }

        public bool Equals(object other)
        {
            return other is UIMessage pam && Equals(pam);
        }
    }
}