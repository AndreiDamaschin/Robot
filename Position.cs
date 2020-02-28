using UnityEngine;


public class Position : MonoBehaviour
{
    float step = 0.1f;
    byte max =(byte)(Create.space ? 10 : 30);
    sbyte min = (sbyte)(Create.space ? -10 : -30);

    void OnMouseDrag()
    {
        if (!Create.space && Create.Piece != null)
        {
            switch (name)
            {
                case "X+":
                    Create.Piece.localPosition.x += step;
                    if (Create.Piece.localPosition.x > max)
                        Create.Piece.localPosition.x = max;
                    break;
                case "X-":
                    Create.Piece.localPosition.x -= step;
                    if (Create.Piece.localPosition.x < min)
                        Create.Piece.localPosition.x = min;
                    break;
                case "Y+":
                    Create.Piece.localPosition.y += step;
                    if (Create.Piece.localPosition.y > max)
                        Create.Piece.localPosition.y = max;
                    break;
                case "Y-":
                    Create.Piece.localPosition.y -= step;
                    if (Create.Piece.localPosition.y < min)
                        Create.Piece.localPosition.y = min;
                    break;
                case "Z+":
                    Create.Piece.localPosition.z += step;
                    if (Create.Piece.localPosition.z > max)
                        Create.Piece.localPosition.z = max;
                    break;
                case "Z-":
                    Create.Piece.localPosition.z -= step;
                    if (Create.Piece.localPosition.z < min)
                        Create.Piece.localPosition.z = min;
                    break;
            }
            Create.Piece.transform.localPosition = Create.Piece.localPosition;
        }
        else if (Create.space && Create.Part != null)
        {
            switch (name)
            {
                case "X+":
                    Create.Part.localPosition.x += step;
                    if (Create.Part.localPosition.x > max)
                        Create.Part.localPosition.x = max;
                    break;
                case "X-":
                    Create.Part.localPosition.x -= step;
                    if (Create.Part.localPosition.x < min)
                        Create.Part.localPosition.x = min;
                    break;
                case "Y+":
                    Create.Part.localPosition.y += step;
                    if (Create.Part.localPosition.y > max)
                        Create.Part.localPosition.y = max;
                    break;
                case "Y-":
                    Create.Part.localPosition.y -= step;
                    if (Create.Part.localPosition.y < min)
                        Create.Part.localPosition.y = min;
                    break;
                case "Z+":
                    Create.Part.localPosition.z += step;
                    if (Create.Part.localPosition.z > max)
                        Create.Part.localPosition.z = max;
                    break;
                case "Z-":
                    Create.Part.localPosition.z -= step;
                    if (Create.Part.localPosition.z < min)
                        Create.Part.localPosition.z = min;
                    break;
            }
            Create.Part.transform.localPosition = Create.Part.localPosition;
        }
        else
            return;
    }
}
