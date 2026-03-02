using UnityEngine;
using System.Collections;

public class Burner : MonoBehaviour
{
    [SerializeField] GameObject fireParticles;
    private bool mouseEntered = false;
    public bool burning = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //If mouse has entered object, player clicks and object is not burning: call burn function
        if (mouseEntered && Input.GetMouseButtonDown(0) && !burning)
        {
            Burn();
        }
    }

    //If mouse enters bounds of object, set mouseEntered to true
    public void OnMouseEnter()
    {
        mouseEntered = true;
        Debug.Log("MouseEntered");
    }

    //If mouse exits bounds of object, set mouseEntered to false
    public void OnMouseExit()
    {
        mouseEntered = false;
    }

    //Object starts burning
    public void Burn()
    {
        burning = true;
        fireParticles.GetComponent<ParticleSystem>().Play();
        StartCoroutine(BurnTime());
        Debug.Log("Burning");
    }

    //Plays burning animation. Stops particles and deletes object after about 10 seconds
    private IEnumerator BurnTime()
    {
        anim.Play("ObjectBurn");
        yield return new WaitForSeconds(10f);
        StartCoroutine("Delete");
        fireParticles.GetComponent<ParticleSystem>().Stop();
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
