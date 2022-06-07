using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    private Animation anim;

    private float moveSpeed = 10.0f;
    private float turnSpeed = 720.0f;

    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");
    private float r => Input.GetAxis("Mouse X");

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"H : {h}");
        Debug.Log($"V : {v}");

        var dir = v * Vector3.forward + h * Vector3.right;
        if (dir.sqrMagnitude > 1.0f)
            dir = dir.normalized;
        tr.Translate(Time.deltaTime * moveSpeed * dir);

        tr.Rotate(Vector3.up * r * Time.deltaTime * turnSpeed);

        PlayerAnim(h, v);
    }

    private void PlayerAnim(float h, float v)
    {
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);
        }
    }
}
