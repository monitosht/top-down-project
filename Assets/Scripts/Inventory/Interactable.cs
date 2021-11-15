using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public float radius;
    private bool inRange;

    private GameObject player;
    private PlayerInputHandler inputHandler;

    public virtual void Interact()
    {
        //Debug.Log("Interacting with "+transform.name);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inputHandler = player.GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        if(inRange)
        {
            if(inputHandler.InteractInput)
            {
                Interact();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);        
    }

    #region Collider Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
            //ebug.Log("in range true");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = false;
            //Debug.Log("in range false");
        }
    }
    #endregion
}
