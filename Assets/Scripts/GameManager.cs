using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject _panelStartMenu;
    [SerializeField] private GameObject _panelFinishLevel;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _panelFinishGame;

    private bool _isPaused;

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
        Init();
    }

    public void Init()
    {
        Pause();
        _panelStartMenu.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        LevelToggler.Instance.FirstLevel();
        Resume();
    }

    public void Pause()
    {
        _isPaused = true;
        Camera.main.GetComponent<AudioSource>().enabled = false;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        _isPaused = false;
        Camera.main.GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1.0f;
    }

    public bool IsPaused()
    {
        return _isPaused;
    }

    public void ShowFinishLevelPanel()
    {
        Pause();
        _panelFinishLevel.gameObject.SetActive(true);
    }

    public void HideFinishLevelPanel()
    {
        _panelFinishLevel.gameObject.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        Pause();
        _panelGameOver.gameObject.SetActive(true);
    }

    public void ShowFinishGamePanel()
    {
        Pause();
        _panelFinishGame.gameObject.SetActive(true);
    }
}
