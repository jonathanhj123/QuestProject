using UnityEngine;

public class LogicScript : MonoBehaviour
{

    private BoxCollider2D door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void keyEnter()
    {
        door.isTrigger = true;
    }
}
