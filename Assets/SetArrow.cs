using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArrow : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // 화살 오브젝트가 Bow 태그와 충돌 시
        if (other.gameObject.tag == "BowHandle")
        {
            BowController bowController = other.gameObject.GetComponentInParent<BowController>();
            bowController.IsReady(); // 화살 장착 모델 활성화
            Destroy(gameObject); // 현재 화살 오브젝트 삭제
        }
    }
}
