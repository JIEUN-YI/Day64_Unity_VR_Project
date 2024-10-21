using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject arrowModelPerfab;

    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
       {
            Debug.Log("화살과 타켓 충돌");
            HitArrow();
        }
    }
    
    public void MoveArrow(float distance)
    {
        Debug.Log("앞방향으로 힘을 받아서 화살 움직이기");
        // transform.Translate(Vector3.forward * distance * 3 * Time.deltaTime);
        // rigidbody.AddForce(Vector3.forward * distance * 10f, ForceMode.Impulse);
        rigidbody.AddForce(transform.forward * distance * 30f, ForceMode.Impulse);
        Debug.Log("이동");
    }

    public void HitArrow()
    {
        Debug.Log("현재위치에 새로운 화살을 생성");
        GameObject hitArrow = Instantiate(arrowModelPerfab, gameObject.transform.position, gameObject.transform.rotation);
        Debug.Log("기존의 화살을 삭제");
        Destroy(gameObject);
    }
}
