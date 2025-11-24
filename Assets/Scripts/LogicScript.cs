using UnityEngine;
using UnityEngine.UIElements;

public class LogicScript : MonoBehaviour
{

    private BoxCollider2D door;
    public UIDocument UI;
    private Label keyLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<BoxCollider2D>();
        keyLabel = GetComponent().rootVisualElement.Q(key);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void keyEnter()
    {
        door.isTrigger = true;
        keyLabel.tintColor =  new Color(255f, 255f, 255f, 255f);
    }
}
