using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioSource hitSound; // 과녁 소리
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HitArrow")
        {
            Debug.Log("화살과 타켓 충돌");
            ShootArrow shootArrow = collision.gameObject.GetComponent<ShootArrow>();
            // 부딪힌 위치를 출력 - 배열이므로 가장 먼저 출력한 위치
            Vector3 point = collision.contacts[0].point;
            shootArrow.HitArrow(point);
            hitSound.Play();
        }
    }
}
