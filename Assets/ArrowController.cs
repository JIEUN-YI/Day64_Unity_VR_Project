using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ȭ�� ������Ʈ�� Bow �±׿� �浹 ��
        if(other.gameObject.tag == "BowHandle")
        {
            BowController bowController = other.gameObject.GetComponentInParent<BowController>();
            bowController.IsReady(); // ȭ�� ���� �� Ȱ��ȭ
            Destroy(gameObject); // ���� ȭ�� ������Ʈ ����
        }
    }
}
