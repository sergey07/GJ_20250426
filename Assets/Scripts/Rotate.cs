using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float _speed = 50.0f;

    private void Update()
    {
        float rot = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rot * _speed * Time.deltaTime);
    }
}
