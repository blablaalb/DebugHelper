using System;
using UnityEngine;

namespace DebugHelper.Printables
{
    [Serializable]
    public class Message : IPrintable
    {
        private readonly string _message;
        private readonly SeverityLevel _severityLevel;
        private readonly string _colorName;

        public Message(string text, SeverityLevel severityLevel)
        {
            this._message = text;
            this._severityLevel = severityLevel;

            switch (_severityLevel)
            {
                case SeverityLevel.DEBUG:
                    _colorName = "gray";
                    break;
                case SeverityLevel.WARNING:
                _colorName = "yellow";
                    break;
                case SeverityLevel.ERROR:
                _colorName = "red";
                    break;
            }
        }

        public string Print()
        {
            return $"<color={_colorName}>{_message}</color>";
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