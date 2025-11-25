using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LogicS : MonoBehaviour
{
    public GameObject UI;
    private VisualElement uiRoot;
    private Button restartButton;
    void Start()
    {
        uiRoot = UI.GetComponent<UIDocument>().rootVisualElement;
        restartButton = uiRoot.Q<Button>("restart");
        restartButton.clicked += RestarGame;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestarGame()
    {
            SceneManager.LoadScene("PlayScene");
    }
}
