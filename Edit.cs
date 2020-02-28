using UnityEngine;


public class Edit : MonoBehaviour
{
    void OnMouseDown()
    {
        Create.space = false;
        Create.editTranslate = true;
        Create.localScale.Set(1, 1, 1);
        Create.localEulerAngles.Set(0, 0, 0);
        Create.S = (short)Create.part.Length;
        for (Create.s = 0; Create.s < Create.S; Create.s++)
        {
            Create.localPosition.Set(0, Create.s * -20, 0);
            Create.part[Create.s].transform.localScale = Create.localScale;
            Create.part[Create.s].transform.SetParent(Create.parts.transform);
            Create.part[Create.s].transform.localPosition = Create.localPosition;
            Create.part[Create.s].transform.localEulerAngles = Create.localEulerAngles;
        }
    }
}
