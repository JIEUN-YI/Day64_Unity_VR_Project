using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HitArrow")
        {
            Debug.Log("ȭ��� Ÿ�� �浹");
            other.gameObject.transform.position = transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
