using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            if (LevelToggler.Instance.IsLastLevel())
            {
                GameManager.Instance.ShowFinishGamePanel();
            }
            else
            {
                GameManager.Instance.ShowFinishLevelPanel();
            }
        }
    }
}
