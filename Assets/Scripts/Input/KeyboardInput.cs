using UnityEngine;

namespace Scripts.InputSystem
{
    public sealed class KeyboardInput : IInput
    {
        private KeyCode _leftBtn;
        private KeyCode _rightBtn;
        private KeyCode _fireBtn;

        public KeyboardInput(KeyCode leftBtn, KeyCode rightBtn, KeyCode fireBtn)
        {
            _leftBtn = leftBtn;
            _rightBtn = rightBtn;
            _fireBtn = fireBtn;
        }

        public float GetHorizontal()
        {
            if (Input.GetKey(_leftBtn)) return -1f;
            if (Input.GetKey(_rightBtn)) return 1f;
            return 0f;
        }

        public bool IsFirePressed() => Input.GetKeyDown(_fireBtn);
    }
}