using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{

    private BoxCollider2D door;
    public GameObject UI;
    public GameObject key;

    private VisualElement keyLabel;
    private VisualElement uiRoot;

    private UIDocument uiDoc;
    private VisualElement winElement;
    private PlayerControls controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<BoxCollider2D>();
        uiRoot = UI.GetComponent<UIDocument>().rootVisualElement;
        keyLabel = uiRoot.Q<VisualElement>("key");
        uiDoc = UI.GetComponent<UIDocument>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void keyEnter()
    {
        Destroy(key);
            if (keyLabel == null)
        {
            Debug.Log("KeyLabel is null");
        }
        door.isTrigger = true;
        keyLabel.style.unityBackgroundImageTintColor = new StyleColor(new Color32(255, 255, 255, 255));
    }
    public void WinGame()
    {
        uiRoot= winElement;
        Debug.Log("You win");
        SceneManager.LoadScene("WinScene");
    }

    public void canMove()
    {
        controller.canMove();
    }
}
