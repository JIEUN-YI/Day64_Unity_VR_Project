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
            Debug.Log("ȭ��� Ÿ�� �浹");
            HitArrow();
        }
    }
    
    public void MoveArrow(float distance)
    {
        Debug.Log("�չ������� ���� �޾Ƽ� ȭ�� �����̱�");
        // transform.Translate(Vector3.forward * distance * 3 * Time.deltaTime);
        // rigidbody.AddForce(Vector3.forward * distance * 10f, ForceMode.Impulse);
        rigidbody.AddForce(transform.forward * distance * 30f, ForceMode.Impulse);
        Debug.Log("�̵�");
    }

    public void HitArrow()
    {
        Debug.Log("������ġ�� ���ο� ȭ���� ����");
        GameObject hitArrow = Instantiate(arrowModelPerfab, gameObject.transform.position, gameObject.transform.rotation);
        Debug.Log("������ ȭ���� ����");
        Destroy(gameObject);
    }
}
