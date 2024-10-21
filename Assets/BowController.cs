using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BowController : MonoBehaviour
{

    [Header ("Arrow")]
    [SerializeField] GameObject arrowModel; // ȭ�� ������ �� ������Ʈ
    [SerializeField] Vector3 arrowStartPos; // ȭ�� ���� �⺻ ��ġ
    [SerializeField] Transform arrowRoation;

    [Header("String")]
    [SerializeField] LineRenderer lineRenderer; // ���η����� �ҷ�����
    [SerializeField] GameObject rightHand; // ������ ��Ʈ�ѷ��� ��ġ�� �ҷ�����
    Vector3 nowRightHand; // ������ ������ġ
    Vector3 stringStartPos; // ���η������� ������ġ
    Coroutine SetRightHandR; // �������� ��ġ�� ����ؼ� �����ϴ� �ڷ�ƾ

    [SerializeField] float distance; // Ȱ ������ ��� �Ÿ��� �����ϱ� ���� ����
    [SerializeField] GameObject shootArrowPrefab; // ���� ������ ȭ�� ������
    GameObject nowArrow; // ���� �߻��� ȭ��
    private void Start()
    {
        arrowModel.SetActive(false); // ������ �����ϸ� ��Ȱ��ȭ�� ����
        arrowStartPos = arrowModel.transform.localPosition; // Ȱ�� �������� ȭ�� ���� ������ġ
        stringStartPos = lineRenderer.GetPosition(1); // ���η������� ������ġ ����
    }
 
    /// <summary>
    /// Ȱ ������ ��� ���鼭
    /// </summary>
    public void SetRightHandPos()
    {
        Debug.Log("���� �������� ��ġ�� ����");
        SetRightHandR = StartCoroutine(SetRightHand());
    }
    /// <summary>
    /// Ȱ ������ ���� ����
    /// </summary>
    public void ExitSetRightHand()
    {
        StopCoroutine(SetRightHandR);
        distance = Vector3.Distance(stringStartPos, nowRightHand);
        // Debug.Log($"�Ÿ� : {distance}");
        lineRenderer.SetPosition(1, stringStartPos); // ������ġ�� �ǵ�����
        Debug.Log("�� ����ġ");
        nowArrow = IsFire();
        ShootArrow shootArrow = nowArrow.GetComponent<ShootArrow>();
        shootArrow.MoveArrow(distance);
        // Debug.Log($"ȭ���� ��ġ : {nowArrow.transform.position.x}, {nowArrow.transform.position.y}, {nowArrow.transform.position.z}");
    }
    IEnumerator SetRightHand()
    {
        while (true)
        {
            //Debug.Log($"���� ������ ���� - x : {rightHand.transform.position.x} y : {rightHand.transform.position.y} z : {rightHand.transform.position.z}");
            nowRightHand = transform.InverseTransformPoint
                (new Vector3(rightHand.transform.position.x,
                             rightHand.transform.position.y,
                             rightHand.transform.position.z)); // ���� ��ǥ�� ���÷� ��ȯ
            //Debug.Log($"���� ������ ���� - x : {nowRightHand.x} y : {nowRightHand.y} z : {nowRightHand.z}");
            lineRenderer.SetPosition(1, nowRightHand);
            arrowModel.transform.position = new Vector3(rightHand.transform.position.x,
                                                        rightHand.transform.position.y,
                                                        rightHand.transform.position.z);
            //Debug.Log($"���� ȭ�� ��ġ - x : {arrowModel.transform.position.x} y : {arrowModel.transform.position.y} z : {arrowModel.transform.position.z}");
            yield return null;
        }
    }

    /// <summary>
    /// ArrowController���� ȭ��� Ȱ�� Ʈ���ŷ� �浹�ϴ� ��� ȭ���� ������ �� ó�� ���̰� �ϴ� �Լ�
    /// </summary>
    public void IsReady()
    {
        arrowModel.transform.localPosition = arrowStartPos; // ���� �� ���� ȭ���� ���� ��ġ
        arrowModel.SetActive(true);
    }

    /// <summary>
    /// ArrowController���� ȭ���� �߻�Ǵ� ���, ȭ���� ������� ��ó�� ���̰� ��Ȱ��ȭ �� ������ ��ġ�� �ǵ����� �Լ�
    /// </summary>
    public GameObject IsFire()
    {
        Debug.Log("ȭ�� �𵨸� ��Ȱ��ȭ");
        arrowModel.SetActive(false);
        Debug.Log("ȭ�� ������Ʈ ����");
        // nowArrow = Instantiate(shootArrowPrefab, rightHand.transform.position, Quaternion.LookRotation(Vector3.forward));
                                                // ������ ��Ʈ�ѷ��� ��ġ �������� ���� , Ȱ �������� ����
        // nowArrow = Instantiate(shootArrowPrefab, rightHand.transform.position, transform.rotation);
         nowArrow = Instantiate(shootArrowPrefab, rightHand.transform.position, arrowRoation.rotation);
        // Debug.Log($"ȭ���� ��ġ : {nowArrow.transform.position.x}, {nowArrow.transform.position.y}, {nowArrow.transform.position.z}");
        return nowArrow;
    }
}
