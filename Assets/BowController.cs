using System.Collections;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [Header ("Arrow")]
    [SerializeField] GameObject arrowModel; // ȭ�� ������ �� ������Ʈ
    [SerializeField] Vector3 arrowStartPos; // ȭ�� ���� �⺻ ��ġ

    [Header("String")]
    [SerializeField] LineRenderer lineRenderer; // ���η����� �ҷ�����
    [SerializeField] GameObject rightHand; // ������ ��Ʈ�ѷ��� ��ġ�� �ҷ�����
    Vector3 nowRightHand; // ������ ������ġ
    Vector3 stringStartPos; // ���η������� ������ġ
    Coroutine SetRightHandR; // �������� ��ġ�� ����ؼ� �����ϴ� �ڷ�ƾ

    private void Start()
    {
        arrowModel.SetActive(false); // ������ �����ϸ� ��Ȱ��ȭ�� ����
        arrowStartPos = arrowModel.transform.position;
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
        lineRenderer.SetPosition(1, stringStartPos); // ������ġ�� �ǵ�����
        IsFire();
    }
    IEnumerator SetRightHand()
    {
        while (true)
        {
            Debug.Log($"���� ������ ���� - x : {rightHand.transform.position.x} y : {rightHand.transform.position.y} z : {rightHand.transform.position.z}");
            nowRightHand = transform.InverseTransformPoint
                (new Vector3(rightHand.transform.position.x,
                             rightHand.transform.position.y,
                             rightHand.transform.position.z)); // ���� ��ǥ�� ���÷� ��ȯ
            Debug.Log($"���� ������ ���� - x : {nowRightHand.x} y : {nowRightHand.y} z : {nowRightHand.z}");
            lineRenderer.SetPosition(1, nowRightHand);
            arrowModel.transform.position = new Vector3(rightHand.transform.position.x,
                                                        rightHand.transform.position.y,
                                                        rightHand.transform.position.z);
            Debug.Log($"���� ȭ�� ��ġ - x : {arrowModel.transform.position.x} y : {arrowModel.transform.position.y} z : {arrowModel.transform.position.z}");
            yield return null;
        }
    }

    /// <summary>
    /// ArrowController���� ȭ��� Ȱ�� Ʈ���ŷ� �浹�ϴ� ��� ȭ���� ������ �� ó�� ���̰� �ϴ� �Լ�
    /// </summary>
    public void IsReady()
    {
        arrowModel.SetActive(true);
    }

    /// <summary>
    /// ArrowController���� ȭ���� �߻�Ǵ� ���, ȭ���� ������� ��ó�� ���̰� ��Ȱ��ȭ �� ������ ��ġ�� �ǵ����� �Լ�
    /// </summary>
    public void IsFire()
    {
        arrowModel.SetActive(false);
    }
}
