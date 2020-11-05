using UnityEngine;
using UnityEngine.UI;

namespace Adrenak.Vboard {
    [RequireComponent(typeof(Button))]
    public class VirtualKey : MonoBehaviour {
        VirtualKeyboard board;

        public void Start() {
            board = GetComponentInParent<VirtualKeyboard>();
            GetComponent<Button>().onClick.AddListener(() => {
                board.Append(gameObject.name);
            });
        }
    }
}
