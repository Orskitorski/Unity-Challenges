using UnityEngine;

public class SpreadRadius : MonoBehaviour
{
    [SerializeField] Burner burner;
    
    //Gets the colliding object and checks if it is currently burning, if not: start burning-function on object as long as the other object is burning
    void OnTriggerStay2D(Collider2D collision)
    {
        Burner obj = collision.GetComponent<Burner>();

        if (!obj.burning && burner.burning)
        {
            obj.Burn();
        }
    }
}
