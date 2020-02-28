using UnityEngine;


public class Rotation : MonoBehaviour
{
    byte step = 1;

    void OnMouseDrag()
    {
        if (!Create.space && Create.Piece != null)
        {
            switch (name)
            {
                case "X+":
                    Create.Piece.transform.Rotate(step, 0, 0);
                    break;
                case "X-":
                    Create.Piece.transform.Rotate(-step, 0, 0);
                    break;
                case "Y+":
                    Create.Piece.transform.Rotate(0, step, 0);
                    break;
                case "Y-":
                    Create.Piece.transform.Rotate(0, -step, 0);
                    break;
                case "Z+":
                    Create.Piece.transform.Rotate(0, 0, step);
                    break;
                case "Z-":
                    Create.Piece.transform.Rotate(0, 0, -step);
                    break;
            }
        }
        else if (Create.space && Create.Part != null)
        {
            switch (name)
            {
                case "X+":
                    Create.Part.transform.Rotate(step, 0, 0);
                    break;
                case "X-":
                    Create.Part.transform.Rotate(-step, 0, 0);
                    break;
                case "Y+":
                    Create.Part.transform.Rotate(0, step, 0);
                    break;
                case "Y-":
                    Create.Part.transform.Rotate(0, -step, 0);
                    break;
                case "Z+":
                    Create.Part.transform.Rotate(0, 0, step);
                    break;
                case "Z-":
                    Create.Part.transform.Rotate(0, 0, -step);
                    break;
            }
        }
        else
            return;
    }
}
