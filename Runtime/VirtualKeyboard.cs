using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Adrenak.Vboard {
    public class VirtualKeyboard : MonoBehaviour {
        [Serializable] public class KeystrokeEvent : UnityEvent<string> { }
        [Serializable] public class TextUpdateEvent : UnityEvent<string> { }
        [Serializable] public class SubmissionEvent : UnityEvent<string> { }

        [SerializeField] InputField inputField = null;

        public KeystrokeEvent onKeystroke = new KeystrokeEvent();
        public UnityEvent onBackstroke = new UnityEvent();
        public TextUpdateEvent onTextUpdated = new TextUpdateEvent();
        public SubmissionEvent onSubmit = new SubmissionEvent();

        string input = string.Empty;

        public string Input {
            get { return input; }
            private set {
                input = value;
                inputField.text = input;
                onTextUpdated.Invoke(input);
            }
        }

        public void Clear() {
            Input = string.Empty;
        }

        public void Append(string key) {
            if (key.Length == 1) {
                Input += key;
                onKeystroke.Invoke(key);
            }
            else
                HandleSpecialKey(key);
        }

        public void Backspace() {
            onBackstroke.Invoke();
            if (Input.Length > 0)
                Input = Input.Substring(0, Input.Length - 1);
        }

        public void Space() {
            Input += " ";
        }

        public void Submit() {
            onSubmit.Invoke(Input);
        }

        public void Toggle() {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        void HandleSpecialKey(string key) {
            switch (key) {
                case "_PERIOD_":
                    Append(".");
                    break;
                case "_COMMA_":
                    Append(",");
                    break;
                case "_SPACE_":
                    Append(" ");
                    break;
                case "_RETURN_":
                    Submit();
                    break;
                case "_BACKSPACE_":
                    Backspace();
                    break;
            }
        }
    }
}