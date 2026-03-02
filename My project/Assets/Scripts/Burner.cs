using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections;

public class Burner : MonoBehaviour
{

    private bool mouseEntered = false;
    private bool burning = false;
    [SerializeField] GameObject fireParticles;

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
        StartCoroutine(BurnTime(5f));
        Debug.Log("Burning");
    }

    private IEnumerator BurnTime(float waitForSeconds)
    {
        var renderer = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(waitForSeconds);
        renderer.color = Color.black;
    }

}
