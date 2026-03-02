using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Burner : MonoBehaviour
{

    private bool mouseEntered = false;

    void Start()
    {
       
    }

    void Update()
    {
        if (mouseEntered && Input.GetMouseButtonDown(0))
        {
            burn();
        }
    }

    public void OnMouseEnter()
    {
        mouseEntered = true;
        Debug.Log("MouseEntered");
    }

    public void OnMouseExit()
    {
        mouseEntered=false;
    }

    void burn()
    {
        Debug.Log("Burning");
    }

}
