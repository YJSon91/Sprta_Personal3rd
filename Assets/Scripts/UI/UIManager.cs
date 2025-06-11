using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Data Source")]
    [SerializeField] private Character playerCharacter;

    [Header("UI Panels")]
    [SerializeField] private UIStatus statusPanel;
    [SerializeField] private UIInventory inventoryPanel;

    [Header("UI Buttons")]
    [SerializeField] private GameObject statusButton;
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject backButton;

    [Header("UI Root")]
    [SerializeField] private CanvasGroup uiMainMenuCanvasGroup;

    [Header("Tutorial")]
    [SerializeField] private GameObject tutorialPanel; // ▼▼▼ 튜토리얼 패널 참조 추가

    private bool isMainMenuOpen = false;
    private bool isTutorialActive = false; // ▼▼▼ 튜토리얼 상태 플래그 추가
        
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
        // 튜토리얼 패널이 설정되어 있다면, 튜토리얼 모드로 시작
        if (tutorialPanel != null && tutorialPanel.activeSelf)
        {
            isTutorialActive = true;
            Time.timeScale = 0f; // 게임 일시정지

            // 메인 메뉴 UI는 숨김 처리
            uiMainMenuCanvasGroup.alpha = 0f;
            uiMainMenuCanvasGroup.interactable = false;
            uiMainMenuCanvasGroup.blocksRaycasts = false;
            isMainMenuOpen = false;

            // 튜토리얼 패널을 볼 수 있도록 커서는 보이게 처리
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else // 튜토리얼 패널이 없다면, 기존 게임 시작 로직 실행
        {
            isTutorialActive = false;
            uiMainMenuCanvasGroup.alpha = 0f;
            uiMainMenuCanvasGroup.interactable = false;
            uiMainMenuCanvasGroup.blocksRaycasts = false;
            isMainMenuOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        // 튜토리얼 상태일 때 아무 키나 눌리면 튜토리얼을 종료
        if (isTutorialActive && Input.anyKeyDown)
        {
            EndTutorial();
            return; // 튜토리얼 종료 후 다른 입력은 무시
        }

        // 튜토리얼 중이 아닐 때만 Tab 키가 작동하도록 함
        if (!isTutorialActive && Input.GetKeyDown(KeyCode.Tab))
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
            CloseAllPanels();
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
        statusButton.SetActive(false);
        inventoryButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void ShowInventoryUI()
    {
        statusPanel.Hide();
        inventoryPanel.Show();
        statusButton.SetActive(false);
        inventoryButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void CloseAllPanels()
    {
        statusPanel.Hide();
        inventoryPanel.Hide();
        statusButton.SetActive(true);
        inventoryButton.SetActive(true);
        backButton.SetActive(false);
    }
    private void EndTutorial()
    {
        isTutorialActive = false;
        tutorialPanel.SetActive(false); // 튜토리얼 패널 숨기기

        Time.timeScale = 1f; // 게임 재개
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
        Cursor.visible = false;
    }
}