using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _pauseBeforeNextLevel = 5.0f;
    
    private GameObject _player;
    private bool _isPlayerMoveToTargetCenter = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (_isPlayerMoveToTargetCenter)
        {
            _player.gameObject.transform.position = Vector3.MoveTowards(_player.gameObject.transform.position, transform.position, 0.1f);
        }
    }

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

            GameObject[] clockHands = GameObject.FindGameObjectsWithTag("ClockHand");

            foreach (GameObject clockHand in clockHands)
            {
                clockHand.GetComponent<RotateClockHand>().StartRotate();
            }

            Camera.main.GetComponent<AudioSource>().enabled = false;

            SoundManager.Instance.PlayFinishLevel();

            _isPlayerMoveToTargetCenter = true;

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
