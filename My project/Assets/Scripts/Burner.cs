using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Burner : MonoBehaviour
{

    private bool mouseEntered = false;
    private bool burning = false;
    [SerializeField] GameObject fireParticles;

    void Start()
    {
       
    }

    void Update()
    {
        if (mouseEntered && Input.GetMouseButtonDown(0) && !burning)
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
        burning = true;
        fireParticles.GetComponent<ParticleSystem>().Play();
        Debug.Log("Burning");
    }

}
