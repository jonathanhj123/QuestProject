using UnityEngine;

public class keyScript : MonoBehaviour
{
    private LogicScript logic;
    private SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        spr.enabled = false;
        logic.keyEnter();
    }
}
