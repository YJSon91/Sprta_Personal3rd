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
    [SerializeField] private GameObject tutorialPanel; // ���� Ʃ�丮�� �г� ���� �߰�

    private bool isMainMenuOpen = false;
    private bool isTutorialActive = false; // ���� Ʃ�丮�� ���� �÷��� �߰�
        
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
        // Ʃ�丮�� �г��� �����Ǿ� �ִٸ�, Ʃ�丮�� ���� ����
        if (tutorialPanel != null && tutorialPanel.activeSelf)
        {
            isTutorialActive = true;
            Time.timeScale = 0f; // ���� �Ͻ�����

            // ���� �޴� UI�� ���� ó��
            uiMainMenuCanvasGroup.alpha = 0f;
            uiMainMenuCanvasGroup.interactable = false;
            uiMainMenuCanvasGroup.blocksRaycasts = false;
            isMainMenuOpen = false;

            // Ʃ�丮�� �г��� �� �� �ֵ��� Ŀ���� ���̰� ó��
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else // Ʃ�丮�� �г��� ���ٸ�, ���� ���� ���� ���� ����
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
        // Ʃ�丮�� ������ �� �ƹ� Ű�� ������ Ʃ�丮���� ����
        if (isTutorialActive && Input.anyKeyDown)
        {
            EndTutorial();
            return; // Ʃ�丮�� ���� �� �ٸ� �Է��� ����
        }

        // Ʃ�丮�� ���� �ƴ� ���� Tab Ű�� �۵��ϵ��� ��
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
        tutorialPanel.SetActive(false); // Ʃ�丮�� �г� �����

        Time.timeScale = 1f; // ���� �簳
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ�� ���
        Cursor.visible = false;
    }
}