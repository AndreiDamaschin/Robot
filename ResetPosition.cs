using UnityEngine;


public class ResetPosition : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Create.textMeshNrOfPosition.text == "Nr")
            return;
        Create.S = 0;
        Create.i = Create.part.Length;
        Create.I = (int.Parse(Create.textMeshNrOfPosition.text) - 1) * Create.i;
        for(Create.s = (short)Create.I; Create.s < Create.i + Create.I; Create.s++, Create.S++)
        {
            Create.move[Create.s, 0] = Create.part[Create.S].transform.localScale.x;
            Create.move[Create.s, 1] = Create.part[Create.S].transform.localScale.y;
            Create.move[Create.s, 2] = Create.part[Create.S].transform.localScale.z;
            Create.move[Create.s, 3] = Create.part[Create.S].transform.localPosition.x;
            Create.move[Create.s, 4] = Create.part[Create.S].transform.localPosition.y;
            Create.move[Create.s, 5] = Create.part[Create.S].transform.localPosition.z;
            Create.move[Create.s, 6] = Create.part[Create.S].transform.localEulerAngles.x;
            Create.move[Create.s, 7] = Create.part[Create.S].transform.localEulerAngles.y;
            Create.move[Create.s, 8] = Create.part[Create.S].transform.localEulerAngles.z;
        }
    }
}
