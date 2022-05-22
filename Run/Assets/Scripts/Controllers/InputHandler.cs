using UnityEngine;

public class InputHandler : MonoBehaviour, IInputHandler
{
    private Vector3 _position;
    private float _horizontalAxis;
    private bool _isHeld = false;

    public float GetInputHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isHeld = true;
            _position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isHeld = false;
            _position = Vector3.zero;
        }
        if (_isHeld)
        {
            Vector3 offset = _position - Input.mousePosition;
            _horizontalAxis = offset.x / Screen.width;
            _position = Input.mousePosition;
        }

        return _horizontalAxis;
    }
}
