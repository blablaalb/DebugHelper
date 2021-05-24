using System;
using UnityEngine;

namespace GizmoDrawer.Printables
{
    [Serializable]
    internal class Message : IPrintable
    {
        private readonly string _message;
        private readonly SeverityLevel _severityLevel;

        public Message(string text, SeverityLevel severityLevel)
        {   

        }

        public void Print()
        {
        }

        public bool Equals(IPrintable other)
        {
            Message otherPrintable = other as Message;
            return otherPrintable != null && otherPrintable._message.Equals(this._message) && otherPrintable.Equals(this._severityLevel);
        }

        public override bool Equals(object other)
        {
            Message otherPrintable = other as Message;
            return otherPrintable != null && Equals(otherPrintable);
        }
    }
}