using UnityEngine;
using System.Collections;

public class Burner : MonoBehaviour
{
    [SerializeField] GameObject fireParticles;
    private bool mouseEntered = false;
    public bool burning = false;
    public float heat = 0;
    public bool heatingUp;
    private bool beingGrabbed = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MouseCheck();

        if (heatingUp)
        {
            heat += Time.deltaTime * 2;
        }
        else if (heat > 0 && !heatingUp)
        {
            heat -= Time.deltaTime;
        }

        if (heatingUp && heat > 5 && !burning)
        {
            Burn();
        }
    }

    //If mouse has entered object, player clicks and object is not burning: call burn function
    void MouseCheck()
    {
        if (mouseEntered && Input.GetMouseButtonDown(0) && !burning)
        {
            Burn();
        }
        if (mouseEntered && Input.GetMouseButtonDown(1))
        {
            beingGrabbed = true;
        }
        else if (mouseEntered && Input.GetMouseButtonUp(1))
        {
            beingGrabbed = false;
        }
        if (beingGrabbed)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 screen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPos = new Vector2(screen.x, screen.y);
        transform.position = worldPos;
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
        fireParticles.GetComponent<ParticleSystem>().Stop();
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
