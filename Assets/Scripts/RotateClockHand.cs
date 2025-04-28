using UnityEngine;

public class RotateClockHand : MonoBehaviour
{
    [SerializeField] float _speed = 180.0f;

    private bool _isRotated = false;

    public void StartRotate()
    {
        _isRotated = true;
    }

    public void StopRotate()
    {
        _isRotated = false;
    }

    public void FixedUpdate()
    {
        if (!_isRotated)
        {
            return;
        }

        float rotateX = -_speed * Time.fixedDeltaTime;
        transform.Rotate(rotateX, 0, 0);
    }
}
