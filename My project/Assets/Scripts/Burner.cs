using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Burner : MonoBehaviour
{

    private bool mouseEntered = false;
    public bool burning = false;
    [SerializeField] GameObject fireParticles;

    void Start()
    {

    }

    void Update()
    {
        if (mouseEntered && Input.GetMouseButtonDown(0) && !burning)
        {
            Burn();
        }
    }

    public void OnMouseEnter()
    {
        mouseEntered = true;
        Debug.Log("MouseEntered");
    }

    public void OnMouseExit()
    {
        mouseEntered = false;
    }

    public void Burn()
    {
        burning = true;
        fireParticles.GetComponent<ParticleSystem>().Play();
        Debug.Log("Burning");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLIDE");
        Burner obj = collision.GetComponent<Burner>();
        if (obj.burning == true)
        {
            obj.Burn();
        }
    }
}
