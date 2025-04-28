using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _pauseBeforeNextLevel = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            GameObject[] gears = GameObject.FindGameObjectsWithTag("Gear");

            foreach (GameObject gear in gears)
            {
                gear.GetComponent<RotateGear>().StartRotate();
            }

            StartCoroutine(ShowPanel());
        }
    }

    IEnumerator ShowPanel()
    {
        yield return new WaitForSeconds(_pauseBeforeNextLevel);

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
