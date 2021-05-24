using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using System.Linq;
using DebugHelper.Printables;

namespace DebugHelper
{
    public class Writer : MonoBehaviour
    {
        private static Writer _instance;
        private Vector2 _scrollPosition = Vector2.zero;
        private List<UIMessage> _uiMessages = new List<UIMessage>();

        public static Writer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Writer>();
                    if (_instance == null)
                    {
                        GameObject messageWriterGO = new GameObject();
                        messageWriterGO.name = "Message Writer";
                        messageWriterGO.transform.position = Vector3.zero;
                        messageWriterGO.transform.rotation = Quaternion.identity;
                        _instance = messageWriterGO.AddComponent(typeof(Writer)) as Writer;
                    }
                }
                return _instance;
            }
        }

        internal void OnGUI()
        {
            float height = Screen.height;
            float width = Screen.width;

            _scrollPosition = GUI.BeginScrollView(new Rect(0, 0, width, height), _scrollPosition, new Rect(0, 0, width - 20, height + 1000));

            PrintMessages();


            // gstyle.normal.background 
            // GUI.Box(new Rect(0, height + 1000 - 20, width - 20, 20), $"{_padtp.DateTime}", gstyle);
            // GUI.Label(new Rect(0, height + 1000 - 20, width - 20, 20),);

            GUI.EndScrollView();
        }

        public void Print(string message, SeverityLevel level)
        {
            Message msg = new Message(message, level);
            if (!_uiMessages.Any(x => x.Printable != null && x.Printable.Equals(msg)))
            {
                UIMessage uiMsg = new UIMessage(msg, _uiMessages.Count + 1);
                _uiMessages.Add(uiMsg);
            }
        }

        private void PrintMessages()
        {
            foreach(UIMessage uiMsg in _uiMessages){
                uiMsg.Print();
            }
        }
    }
}

