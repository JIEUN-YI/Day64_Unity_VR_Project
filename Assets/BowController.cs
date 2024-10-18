using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] GameObject arrowModel; // 화살 장전용 모델 오브젝트
    [SerializeField] Transform arrowModelPos; // 화살 모델의 기본 위치
    [SerializeField] Transform startPos; // 화살 모델의 기본 위치

    private void Start()
    {
        arrowModel.SetActive(false); // 게임이 시작하면 비활성화로 시작
        startPos = arrowModelPos;
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
        arrowModel.transform.position = startPos.position;
    }
}
