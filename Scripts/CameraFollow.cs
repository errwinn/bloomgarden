using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Target;
    Vector3 camOffSet;
    // Start is called before the first frame update
    void Start()
    {
        camOffSet = transform.position - Target.position;
    }

    private void FixedUpdate()
    {
        Vector3 extra = new Vector3(2f, 2f, 0);

        transform.position = Target.position + camOffSet;
    }
}
