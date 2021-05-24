using System.Collections.Generic;
using DebugHelper.Drawables;
using System.Collections;
using UnityEngine;
using System;

namespace DebugHelper.Printables
{
    public struct UIMessage : IEquatable<UIMessage>
    {
        public readonly Message Printable;
        public readonly int Count;

        public UIMessage(Message printable, int count)
        {
            this.Printable = printable;
            this.Count = count;
        }

        public void Print()
        {
            Rect rect = new Rect(DrawBox());
            GUIStyle gstyle = GUI.skin.label;
            gstyle.richText = true;
            gstyle.fontSize = 25;
            rect.x = 30;
            GUI.Label(rect, Printable.Print(), gstyle);
        }

        private Rect DrawBox()
        {
            float height = 40f;
            float width = Screen.width - 20f;
            GUIStyle gstyle = GUI.skin.box;
            gstyle.alignment = TextAnchor.MiddleLeft;
            gstyle.fontSize = 25;
            gstyle.richText = true;
            Rect rect = new Rect(0, 0, width, height);
            GUI.Box(rect, $"{Count}", gstyle);
            return rect;
        }

        public bool Equals(UIMessage other)
        {
            return other.Printable.Equals(this.Printable) && other.Count.Equals(this.Count);
        }

        public bool Equals(object other)
        {
            return other is UIMessage uiMsg && Equals(uiMsg);
        }
    }
}