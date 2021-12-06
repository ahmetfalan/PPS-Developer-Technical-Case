using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject settingsPanel;

    public Toggle toggleBigProjectile;
    public Toggle toggleRedProjectile;
    public Toggle toggleExplodeProjectile;


    public Slider slider;
    public Text text;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        text.text = "Amount of Projectile: " + slider.value.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (Time.timeScale == 0)
        {
            InputManager.Instance.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inGamePanel.SetActive(false);
            settingsPanel.SetActive(true);
        }
        else
        {
            InputManager.Instance.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inGamePanel.SetActive(true);
            settingsPanel.SetActive(false);
        }
    }

    bool TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
