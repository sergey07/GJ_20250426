using UnityEngine;

public enum GearType { Left, Right  }

[SelectionBase]
public class RotateGear : MonoBehaviour
{
    [SerializeField] private GearType _gearType;
    [SerializeField] private float _speed = 180.0f;

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

        float rotateY = _speed * Time.fixedDeltaTime;

        if (_gearType == GearType.Left)
        {
            rotateY = -rotateY;
        }

        transform.Rotate(0, rotateY, 0);
    }
}
