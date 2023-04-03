using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
 
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                 GameManager.instance.NoteHit();

                if (transform.position.y > -37 && transform.position.y > -38.5)
                {
                    GameManager.instance.NormalHit();
                }
            }
        }

        Exit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator") 
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
        }
    }

    void Exit()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Qyit");
            Application.Quit();
        }
    }
}
