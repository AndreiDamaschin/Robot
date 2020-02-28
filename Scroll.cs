using UnityEngine;


public class Scroll : MonoBehaviour
{
    float y = 45;

    void OnMouseDrag()
    {
        y += Input.GetAxis("Mouse Y") * 200 * Time.deltaTime;
        y = y > 45 ? y = 45 : y < -30 ? y = -30 : y;
        Create.localPosition.Set(50, y, 0);
        transform.localPosition = Create.localPosition;
        if (!Create.space)
        {
            Create.localPosition.Set(75, -y + 90, 50);
            Create.parts.transform.localPosition = Create.localPosition;
        }
    }
}
