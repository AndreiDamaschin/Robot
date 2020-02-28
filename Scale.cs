using UnityEngine;


public class Scale : MonoBehaviour
{
    byte min = 1;
    byte max = 20;
    float step = 0.1f;

    void OnMouseDrag()
    {
        if (!Create.space && Create.Piece != null)
        {
            switch (name)
            {
                case "X+":
                    Create.Piece.localScale.x += step;
                    if (Create.Piece.localScale.x > max)
                        Create.Piece.localScale.x = max;
                    break;
                case "X-":
                    Create.Piece.localScale.x -= step;
                    if (Create.Piece.localScale.x < min)
                        Create.Piece.localScale.x = min;
                    break;
                case "Y+":
                    Create.Piece.localScale.y += step;
                    if (Create.Piece.localScale.y > max)
                        Create.Piece.localScale.y = max;
                    break;
                case "Y-":
                    Create.Piece.localScale.y -= step;
                    if (Create.Piece.localScale.y < min)
                        Create.Piece.localScale.y = min;
                    break;
                case "Z+":
                    Create.Piece.localScale.z += step;
                    if (Create.Piece.localScale.z > max)
                        Create.Piece.localScale.z = max;
                    break;
                case "Z-":
                    Create.Piece.localScale.z -= step;
                    if (Create.Piece.localScale.z < min)
                        Create.Piece.localScale.z = min;
                    break;
            }
            Create.Piece.transform.localScale = Create.Piece.localScale;
        }
        else if (Create.space && Create.Part != null)
        {
            switch (name)
            {
                case "X+":
                    Create.Part.localScale.x += step;
                    if (Create.Part.localScale.x > max)
                        Create.Part.localScale.x = max;
                    break;
                case "X-":
                    Create.Part.localScale.x -= step;
                    if (Create.Part.localScale.x < min)
                        Create.Part.localScale.x = min;
                    break;
                case "Y+":
                    Create.Part.localScale.y += step;
                    if (Create.Part.localScale.y > max)
                        Create.Part.localScale.y = max;
                    break;
                case "Y-":
                    Create.Part.localScale.y -= step;
                    if (Create.Part.localScale.y < min)
                        Create.Part.localScale.y = min;
                    break;
                case "Z+":
                    Create.Part.localScale.z += step;
                    if (Create.Part.localScale.z > max)
                        Create.Part.localScale.z = max;
                    break;
                case "Z-":
                    Create.Part.localScale.z -= step;
                    if (Create.Part.localScale.z < min)
                        Create.Part.localScale.z = min;
                    break;
            }
            Create.Part.transform.localScale = Create.Part.localScale;
        }
        else
            return;
    }
}
