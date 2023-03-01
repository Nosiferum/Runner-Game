using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Managers
{
    public class InputManager : MonoBehaviour
    {
        public static Vector2 Delta { get; private set; }

        private Vector2 _screenRes;

        private Vector2 _current;
        private Vector2 _previous;

        private void Start()
        {
            _screenRes.x = Screen.width;
            _screenRes.y = Screen.height;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _previous = _current = Input.mousePosition;

            }

            if (Input.GetMouseButton(0))
            {
                _previous = _current;
                _current = Input.mousePosition;

                Delta = (_current - _previous) / _screenRes;
            }

            if (Input.GetMouseButtonUp(0))
                Delta = Vector2.zero;
        }
    }
}


