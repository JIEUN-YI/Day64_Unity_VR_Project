using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;

    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveArrow(float distance)
    {
        Debug.Log("앞방향으로 힘을 받아서 화살 움직이기");
        // transform.Translate(Vector3.forward * distance * 3 * Time.deltaTime);
        // rigidbody.AddForce(Vector3.forward * distance * 10f, ForceMode.Impulse);
        rigidbody.AddForce(transform.forward * distance * 10f, ForceMode.Impulse);
        Debug.Log("이동");
    }

}
