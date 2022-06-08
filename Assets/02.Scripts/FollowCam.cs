using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;

    private Transform camTr;

    [Range(2.0f, 20.0f)]
    public float distance = 3.0f;
    [Range(0.0f, 10.0f)]
    public float height = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        camTr.position = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);
        camTr.LookAt(targetTr.position);
    }
}
