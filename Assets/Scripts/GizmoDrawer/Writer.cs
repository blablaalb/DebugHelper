using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using GizmoDrawer.Printables;

namespace GizmoDrawer
{
    public class Writer
    {
        public Vector2 scrollPosition = Vector2.zero;
        private UIMessage _uiMessage = new UIMessage(new Message("Message", SeverityLevel.DEBUG), 1);

        public void OnGUI()
        {
            float height = Screen.height;
            float width = Screen.width;
            // PrintMessages();

            scrollPosition = GUI.BeginScrollView(new Rect(0, 0, width, height), scrollPosition, new Rect(0, 0, width - 20, height + 1000));

            // GUI.Button(new Rect(width - 200, height + 1000 - 20, 200, 20), "text");
            GUIStyle gstyle = GUI.skin.box;
            gstyle.alignment = TextAnchor.MiddleLeft;


            // gstyle.normal.background 
            // GUI.Box(new Rect(0, height + 1000 - 20, width - 20, 20), $"{_padtp.DateTime}", gstyle);
            // GUI.Label(new Rect(0, height + 1000 - 20, width - 20, 20),);
            DrawBox();

            GUI.EndScrollView();
        }

        private void DrawBox()
        {
            float height = 40f;
            float width = Screen.width - 20f;
            GUIStyle gstyle = GUI.skin.box;
            gstyle.alignment = TextAnchor.MiddleLeft;
            gstyle.fontSize = 20;
            Debug.Log(gstyle.fontSize);
            GUI.Box(new Rect(0, 0, width, height), $"{_uiMessage.Count}", gstyle);
        }

        public void Print(string message, SeverityLevel level)
        {
        }

        private void PrintMessages()
        {
            throw new NotImplementedException("PrintMessages not implemented");
        }
    }
}

