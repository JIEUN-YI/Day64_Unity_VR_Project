using System.Collections;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] public AudioSource stringSound; // 화살 당기기 소리

    [Header("Arrow")]
    [SerializeField] GameObject arrowModel; // 화살 장전용 모델 오브젝트
    [SerializeField] Vector3 arrowStartPos; // 화살 모델의 기본 위치
    [SerializeField] Transform arrowRoation;
    [SerializeField] GameObject aim;
    bool isArrow; // 화살의 장착 여부

    [Header("String")]
    [SerializeField] LineRenderer lineRenderer; // 라인렌더러 불러오기
    [SerializeField] GameObject rightHand; // 오른손 컨트롤러의 위치를 불러오기
    Vector3 nowRightHand; // 오른손 현재위치
    Vector3 stringStartPos; // 라인랜더러의 시작위치
    Coroutine SetRightHandR; // 오른손의 위치를 계속해서 설정하는 코루틴

    [SerializeField] float distance; // 활 시위를 당긴 거리를 저장하기 위한 변수
    [SerializeField] GameObject shootArrowPrefab; // 새로 생성할 화살 프리팹
    GameObject nowArrow; // 현재 발사할 화살
    private void Start()
    {
        aim.SetActive(false);
        arrowModel.SetActive(false); // 게임이 시작하면 비활성화로 시작
        arrowStartPos = arrowModel.transform.localPosition; // 활을 기준으로 화살 모델의 시작위치
        stringStartPos = lineRenderer.GetPosition(1); // 라인랜더러의 시작위치 저장
        isArrow = false; // 장착되지 않음
    }

    /// <summary>
    /// 활 시위를 잡아 당기면서
    /// </summary>
    public void SetRightHandPos()
    {
        //Debug.Log("현재 오른손의 위치를 저장");
        stringSound.Play();
        SetRightHandR = StartCoroutine(SetRightHand());
    }
    /// <summary>
    /// 활 시위를 놓는 순간
    /// </summary>
    public void ExitSetRightHand()
    {
        //stringSound.Stop();
        StopCoroutine(SetRightHandR);
        aim.SetActive(false);
        if (isArrow == true)
        {
            // Debug.Log($"거리 : {distance}");
            lineRenderer.SetPosition(1, stringStartPos); // 시작위치로 되돌리기
                                                         // Debug.Log("줄 원위치");
            nowArrow = IsFire();
            ShootArrow shootArrow = nowArrow.GetComponent<ShootArrow>();
            shootArrow.MoveArrow(distance);
            // Debug.Log($"화살의 위치 : {nowArrow.transform.position.x}, {nowArrow.transform.position.y}, {nowArrow.transform.position.z}");
        }
        if (isArrow == false)
        {
            lineRenderer.SetPosition(1, stringStartPos); // 시작위치로 되돌리기
            //Debug.Log("줄 원위치");
        }
    }
    IEnumerator SetRightHand()
    {
        distance = 0;
        while (distance < 0.6f)
        {
            aim.SetActive(true);
            //Debug.Log($"현재 오른손 월드 - x : {rightHand.transform.position.x} y : {rightHand.transform.position.y} z : {rightHand.transform.position.z}");
            nowRightHand = transform.InverseTransformPoint
                (new Vector3(rightHand.transform.position.x,
                             rightHand.transform.position.y,
                             rightHand.transform.position.z)); // 월드 좌표를 로컬로 변환
            Debug.Log($"현재 오른손 로컬 - x : {nowRightHand.x} y : {nowRightHand.y} z : {nowRightHand.z}");
            lineRenderer.SetPosition(1, nowRightHand);
            arrowModel.transform.position = new Vector3(rightHand.transform.position.x,
                                                        rightHand.transform.position.y,
                                                        rightHand.transform.position.z);
            distance = Vector3.Distance(stringStartPos, nowRightHand);
            //yield return new WaitForSeconds(0.5f);
            //stringSound.Stop();
            Debug.Log($"현재 화살 위치 - x : {arrowModel.transform.position.x} y : {arrowModel.transform.position.y} z : {arrowModel.transform.position.z}");
            yield return null;
        }
        yield return null;
        /*
        while (true)
        {
            aim.SetActive(true);
            //Debug.Log($"현재 오른손 월드 - x : {rightHand.transform.position.x} y : {rightHand.transform.position.y} z : {rightHand.transform.position.z}");
            nowRightHand = transform.InverseTransformPoint
                (new Vector3(rightHand.transform.position.x,
                             rightHand.transform.position.y,
                             rightHand.transform.position.z)); // 월드 좌표를 로컬로 변환
            Debug.Log($"현재 오른손 로컬 - x : {nowRightHand.x} y : {nowRightHand.y} z : {nowRightHand.z}");
            lineRenderer.SetPosition(1, nowRightHand);
            arrowModel.transform.position = new Vector3(rightHand.transform.position.x,
                                                        rightHand.transform.position.y,
                                                        rightHand.transform.position.z);
            //yield return new WaitForSeconds(0.5f);
            //stringSound.Stop();
            Debug.Log($"현재 화살 위치 - x : {arrowModel.transform.position.x} y : {arrowModel.transform.position.y} z : {arrowModel.transform.position.z}");
            yield return null;
        }
        */
    }

    /// <summary>
    /// ArrowController에서 화살과 활이 트리거로 충돌하는 경우 화살이 장착된 것 처럼 보이게 하는 함수
    /// </summary>
    public void IsReady()
    {
        arrowModel.transform.localPosition = arrowStartPos; // 장착 시 원래 화살의 시작 위치
        isArrow = true;
        arrowModel.SetActive(true);
    }

    /// <summary>
    /// ArrowController에서 화살이 발사되는 경우, 화살이 사라지는 것처럼 보이게 비활성화 후 원래의 위치로 되돌리는 함수
    /// </summary>
    public GameObject IsFire()
    {
        //Debug.Log("화살 모델링 비활성화");
        arrowModel.SetActive(false);
        //Debug.Log("화살 오브젝트 생성");
        // 오른손 컨트롤러의 위치 기준으로 생성 , 활 기준으로 방향
        // nowArrow = Instantiate(shootArrowPrefab, rightHand.transform.position, transform.rotation);
        nowArrow = Instantiate(shootArrowPrefab, rightHand.transform.position, arrowRoation.rotation);
        // Debug.Log($"화살의 위치 : {nowArrow.transform.position.x}, {nowArrow.transform.position.y}, {nowArrow.transform.position.z}");
        isArrow = false;
        return nowArrow;
    }
}
