using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HitArrow")
        {
            Debug.Log("화살과 타켓 충돌");
            ShootArrow shootArrow = collision.gameObject.GetComponent<ShootArrow>();
            shootArrow.HitArrow();
        }
    }
}
