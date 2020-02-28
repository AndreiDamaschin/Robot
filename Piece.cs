using UnityEngine;


public class Piece : MonoBehaviour
{
    byte max = 10;
    sbyte min = -10;
    public Color color;
    public Material material;
    public Vector3 localScale;
    public Vector3 localPosition;
    public PrimitiveType primitiveType;
    public float localRotationX, localRotationY, localRotationZ;

    void OnMouseDrag()
    {
        if (localPosition.x == 0 && localPosition.y == 0 && localPosition.z == 0)
        {
            if (Create.Piece == null)
                Create.Piece = this;
            localScale = transform.localScale;
            localPosition = transform.localPosition;
            material = transform.GetComponent<Renderer>().material;
            material.color = Color.red;
        }
        else if (Create.Piece != this)
        {
            material.color = Color.red;
            Create.Piece.material.color = Create.Piece.color;
            Create.Piece = this;
        }
        localPosition = Create.Position(localPosition, true);
        if (localPosition.x > max)
            localPosition.x = max;
        if (localPosition.x < min)
            localPosition.x = min;
        if (localPosition.y > max)
            localPosition.y = max;
        if (localPosition.y < min)
            localPosition.y = min;
        if (localPosition.z > max)
            localPosition.z = max;
        if (localPosition.z < min)
            localPosition.z = min;
        transform.localPosition = localPosition;
    }

    public Piece GetData(PrimitiveType primitiveType, bool Collider)
    {
        this.primitiveType = primitiveType;
        if (Collider != true)
            GetComponent<Collider>().enabled = false;
        return this;
    }
}
