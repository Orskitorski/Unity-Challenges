using UnityEngine;

public class manager : MonoBehaviour
{

    [SerializeField] GameObject square;
    [SerializeField] GameObject triangle;
    [SerializeField] GameObject circle;

    void Update()
    {
        Vector3 screen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPos = new Vector2(screen.x, screen.y);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(square, worldPos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(circle, worldPos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(triangle, worldPos, Quaternion.identity);
        }
    }
}
