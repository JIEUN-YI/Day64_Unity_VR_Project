using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HitArrow")
        {
            Debug.Log("ȭ��� Ÿ�� �浹");
            ShootArrow shootArrow = collision.gameObject.GetComponent<ShootArrow>();
            shootArrow.HitArrow();
        }
    }
}
