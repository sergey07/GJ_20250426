using UnityEngine;

public class LevelToggler : MonoBehaviour
{
    public static LevelToggler Instance { get; private set; }

    [SerializeField] private GameObject _requiredPart;
    [SerializeField] private GameObject[] _levels;

    private int _curLevel = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }
    }

    public void FirstLevel()
    {
        _curLevel = 0;
        UpdateLevel(_curLevel);
    }

    public void NextLevel()
    {
        Debug.Log("NextLevel");
        if (IsLastLevel())
        {
            GameManager.Instance.ShowFinishGamePanel();
        }
        else
        {
            _curLevel++;
            UpdateLevel(_curLevel);
        }
    }

    public bool IsLastLevel()
    {
        Debug.Log("IsLastLevel");
        Debug.Log(_curLevel == _levels.Length - 1);
        return _curLevel == _levels.Length - 1;
    }

    public void RestartLevel()
    {
        UpdateLevel(_curLevel);
    }

    private void UpdateLevel(int curLevel)
    {
        // Reset phisic
        _requiredPart.GetComponent<Rigidbody>().isKinematic = true;
        _requiredPart.GetComponent<Rigidbody>().isKinematic = false;

        _requiredPart.transform.position = new Vector3(0, 60, -3);

        for (int i = 0; i < _levels.Length; i++)
        {
            if (i == curLevel)
            {
                _levels[i].SetActive(true);
            }
            else
            {
                _levels[i].SetActive(false);
            }
        }
    }
}
