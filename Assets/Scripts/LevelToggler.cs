using UnityEngine;

public class LevelToggler : MonoBehaviour
{
    public static LevelToggler Instance { get; private set; }

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

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (IsLastLevel())
            {
                FirstLevel();
            }
            else
            {
                NextLevel();
            }
        }
    }

    public void FirstLevel()
    {
        _curLevel = 0;
        UpdateLevel(_curLevel);
    }

    public void NextLevel()
    {
        _curLevel++;
        UpdateLevel(_curLevel);
    }

    public bool IsLastLevel()
    {
        return _curLevel == _levels.Length - 1;
    }

    private void UpdateLevel(int curLevel)
    {
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
