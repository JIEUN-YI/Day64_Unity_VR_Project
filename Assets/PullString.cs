using System.Collections;
using UnityEngine;

public class PullString : MonoBehaviour
{
    /*
    [SerializeField] BowController bowController; // Bow의 BowController
    LineRenderer lineRenderer; // 라인렌더러 불러오기

    Vector3 startPos; // 라인랜더러의 시작위치
    // [SerializeField] GameObject rightHand; // 오른손 컨트롤러의 위치를 불러오기
    // Transform nowRightHand; // 계속해서 오른손 현재위치 불러오기
    Vector3 nowRightHand; // 계속해서 오른손 현재위치 불러오기
    Vector3 stringPoint; // 시위 렌더러 위치

    Coroutine SetRightHandR; // 오른손의 위치를 계속해서 설정

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPos = lineRenderer.GetPosition(1); // 라인랜더러의 시작위치
    }

    public void SetRightHandPos()
    {
        SetRightHandR = StartCoroutine(SetRightHand());
    }
    public void ExitSetRightHand()
    {
        StopCoroutine(SetRightHandR);
        lineRenderer.SetPosition(1, startPos); // 시작위치로 되돌리기
    }

    IEnumerator SetRightHand()
    {
        while (true)
        {
            nowRightHand = bowController.nowRightHand; // BowController의 현재 오른손의 위치를 불러옴
            stringPoint = nowRightHand;
            yield return null;
        }
    }
    */
    /* Space.World 사용 시 제대로 실행되는 string
        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            startPos = lineRenderer.GetPosition(1); // 라인랜더러의 시작위치
        }

        public void SetRightHandPos()
        {
            Debug.Log("현재 오른손의 위치를 저장");
            SetRightHandR = StartCoroutine(SetRightHand());
        }

        public void ExitSetRightHand()
        {
            StopCoroutine(SetRightHandR);
            lineRenderer.SetPosition(1, startPos); // 시작위치로 되돌리기
        }

        IEnumerator SetRightHand()
        {
            while (true)
            {
                nowRightHand = rightHand.transform; // 현재 오른손의 위치 저장
                stringPoint = nowRightHand.transform.position; 
                lineRenderer.SetPosition(1, stringPoint); // 라인랜더러의 위치를 수정
                Debug.Log("시위의 위치를 변경");
                yield return null;
            }
        }
        */
}
