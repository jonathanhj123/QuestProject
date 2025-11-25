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
    private AudioSource _Ambience;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip keyPickup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<BoxCollider2D>();
        uiRoot = UI.GetComponent<UIDocument>().rootVisualElement;
        keyLabel = uiRoot.Q<VisualElement>("key");
        uiDoc = UI.GetComponent<UIDocument>();


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
        _Ambience.PlayOneShot(keyPickup, 0.5f);
        door.isTrigger = true;
        keyLabel.style.unityBackgroundImageTintColor = new StyleColor(new Color32(255, 255, 255, 255));
    }
    public void WinGame()
    {
        uiRoot= winElement;
        Debug.Log("You win");
        SceneManager.LoadScene("WinScene");
    }

    public void jumpsound()
    {
        _Ambience.PlayOneShot(jump, 0.5f);
    }
}
