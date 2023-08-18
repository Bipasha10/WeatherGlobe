using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private Transform earth;
    private float xAngle, yAngle;

    // Start is called before the first frame update
    void Start()
    {
        RotateObject();
    }


    private void RotateObject()
    {
        Quaternion horRotation = Quaternion.AngleAxis(xAngle, Vector3.right);

        Quaternion verRotation = Quaternion.AngleAxis(yAngle, Vector3.up);

        earth.rotation = horRotation * verRotation;

        Delegates.OnUpdatedPointerPosition?.Invoke(xAngle, yAngle);
    }
    public float HorizontalRotation
    {
        get => xAngle;
        set
        {
            xAngle = value;
            RotateObject();
        }
    }

    public float VerticalRotation
    {
        get => yAngle;
        set
        {
            yAngle = value;
            RotateObject();
        }
    }
}
