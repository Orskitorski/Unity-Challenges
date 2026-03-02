using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Burner : MonoBehaviour
{

    private bool mouseEntered = false;

    void Update()
    {
        if (mouseEntered && Input.GetMouseButtonDown(0)) //Checks if the mouse is pressed down while hovering over the gameobject, and then calls the burn function if both conditions are met.
        {
            burn();
        }
    }

    public void OnMouseEnter() //Checks if the mouse is hovering over the gameobject
    {
        mouseEntered = true;
        Debug.Log("MouseEntered");
    }

    public void OnMouseExit() //Checks if the mouse is NOT hovering over the gameobject
    {
        mouseEntered=false;
    }

    void burn()
    {
        Debug.Log("Burning");
    }

}
