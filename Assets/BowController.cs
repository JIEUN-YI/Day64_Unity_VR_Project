using System.Collections;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [Header ("Arrow")]
    [SerializeField] GameObject arrowModel; // 화살 장전용 모델 오브젝트
    [SerializeField] Transform arrowModelPos; // 화살 모델의 위치
    [SerializeField] Transform arrowStartPos; // 화살 모델의 기본 위치

    [Header("String")]
    [SerializeField] LineRenderer lineRenderer; // 라인렌더러 불러오기
    [SerializeField] GameObject rightHand; // 오른손 컨트롤러의 위치를 불러오기
    Vector3 nowRightHand; // 오른손 현재위치
    Vector3 stringStartPos; // 라인랜더러의 시작위치
    Coroutine SetRightHandR; // 오른손의 위치를 계속해서 설정하는 코루틴

    private void Start()
    {
        arrowModel.SetActive(false); // 게임이 시작하면 비활성화로 시작
        arrowStartPos = arrowModelPos;
        stringStartPos = lineRenderer.GetPosition(1); // 라인랜더러의 시작위치 저장
    }
    /// <summary>
    /// 활 시위를 잡아 당기면서
    /// </summary>
    public void SetRightHandPos()
    {
        Debug.Log("현재 오른손의 위치를 저장");
        SetRightHandR = StartCoroutine(SetRightHand());
    }
    /// <summary>
    /// 활 시위를 놓는 순간
    /// </summary>
    public void ExitSetRightHand()
    {
        StopCoroutine(SetRightHandR);
        lineRenderer.SetPosition(1, stringStartPos); // 시작위치로 되돌리기
    }
    IEnumerator SetRightHand()
    {
        while (true)
        {
            Debug.Log($"현재 오른손 월드 - x : {rightHand.transform.position.x} y : {rightHand.transform.position.y} z : {rightHand.transform.position.z}");
            nowRightHand = transform.InverseTransformPoint
                (new Vector3(rightHand.transform.position.x,
                             rightHand.transform.position.y,
                             rightHand.transform.position.z)); // 월드 좌표를 로컬로 변환
            Debug.Log($"현재 오른손 로컬 - x : {nowRightHand.x} y : {nowRightHand.y} z : {nowRightHand.z}");
            lineRenderer.SetPosition(1, nowRightHand);
            Debug.Log("시위 이동");
            yield return null;
        }
    }

    /// <summary>
    /// ArrowController에서 화살과 활이 트리거로 충돌하는 경우 화살이 장착된 것 처럼 보이게 하는 함수
    /// </summary>
    public void IsReady()
    {
        arrowModel.SetActive(true);
    }

    /// <summary>
    /// ArrowController에서 화살이 발사되는 경우, 화살이 사라지는 것처럼 보이게 비활성화 후 원래의 위치로 되돌리는 함수
    /// </summary>
    public void IsFire()
    {
        arrowModel.SetActive(false);
        arrowModel.transform.position = arrowStartPos.position;
    }
}
