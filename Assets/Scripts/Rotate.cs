using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 50.0f;
    [SerializeField] private GameObject _requiredPart;

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPaused() && _requiredPart.GetComponent<Rigidbody>().isKinematic == false)
        {
            float rot = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, rot * _speed * Time.fixedDeltaTime);
        }
    }
}
