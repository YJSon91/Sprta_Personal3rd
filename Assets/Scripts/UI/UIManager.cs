using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Data Source")]
    [SerializeField] private Character playerCharacter;

    [Header("UI Panels")]
    [SerializeField] private UIStatus statusPanel;
    [SerializeField] private UIInventory inventoryPanel;

    [Header("UI Root")]
    [SerializeField] private CanvasGroup uiMainMenuCanvasGroup;

    private bool isMainMenuOpen = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 시작할 때 메뉴를 끈 상태로 만들고, 마우스를 잠급니다.
        uiMainMenuCanvasGroup.alpha = 0f;
        uiMainMenuCanvasGroup.interactable = false;
        uiMainMenuCanvasGroup.blocksRaycasts = false;
        isMainMenuOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMainMenu();
        }
    }

    public void ToggleMainMenu()
    {
        isMainMenuOpen = !isMainMenuOpen;

        if (isMainMenuOpen)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            uiMainMenuCanvasGroup.alpha = 1f;
            uiMainMenuCanvasGroup.interactable = true;
            uiMainMenuCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            uiMainMenuCanvasGroup.alpha = 0f;
            uiMainMenuCanvasGroup.interactable = false;
            uiMainMenuCanvasGroup.blocksRaycasts = false;
            CloseAllPanels();
        }
    }

    public void ShowStatusUI()
    {
        inventoryPanel.Hide();
        statusPanel.Show();
    }

    public void ShowInventoryUI()
    {
        statusPanel.Hide();
        inventoryPanel.Show();
    }

    public void CloseAllPanels()
    {
        statusPanel.Hide();
        inventoryPanel.Hide();
    }
}