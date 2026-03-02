using UnityEngine;

public class SpreadRadius : MonoBehaviour
{
    //Gets the colliding object and checks if it is currently burning, if not: start burning-function on object
    void OnTriggerEnter2D(Collider2D collision)
    {
        Burner obj = collision.GetComponent<Burner>();

        if (obj.burning == false)
        {
            obj.Burn();
        }
    }
}
