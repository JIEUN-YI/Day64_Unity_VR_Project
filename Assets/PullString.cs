using System.Collections;
using UnityEngine;

public class PullString : MonoBehaviour
{
    /*
    [SerializeField] BowController bowController; // Bow�� BowController
    LineRenderer lineRenderer; // ���η����� �ҷ�����

    Vector3 startPos; // ���η������� ������ġ
    // [SerializeField] GameObject rightHand; // ������ ��Ʈ�ѷ��� ��ġ�� �ҷ�����
    // Transform nowRightHand; // ����ؼ� ������ ������ġ �ҷ�����
    Vector3 nowRightHand; // ����ؼ� ������ ������ġ �ҷ�����
    Vector3 stringPoint; // ���� ������ ��ġ

    Coroutine SetRightHandR; // �������� ��ġ�� ����ؼ� ����

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPos = lineRenderer.GetPosition(1); // ���η������� ������ġ
    }

    public void SetRightHandPos()
    {
        SetRightHandR = StartCoroutine(SetRightHand());
    }
    public void ExitSetRightHand()
    {
        StopCoroutine(SetRightHandR);
        lineRenderer.SetPosition(1, startPos); // ������ġ�� �ǵ�����
    }

    IEnumerator SetRightHand()
    {
        while (true)
        {
            nowRightHand = bowController.nowRightHand; // BowController�� ���� �������� ��ġ�� �ҷ���
            stringPoint = nowRightHand;
            yield return null;
        }
    }
    */
    /* Space.World ��� �� ����� ����Ǵ� string
        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            startPos = lineRenderer.GetPosition(1); // ���η������� ������ġ
        }

        public void SetRightHandPos()
        {
            Debug.Log("���� �������� ��ġ�� ����");
            SetRightHandR = StartCoroutine(SetRightHand());
        }

        public void ExitSetRightHand()
        {
            StopCoroutine(SetRightHandR);
            lineRenderer.SetPosition(1, startPos); // ������ġ�� �ǵ�����
        }

        IEnumerator SetRightHand()
        {
            while (true)
            {
                nowRightHand = rightHand.transform; // ���� �������� ��ġ ����
                stringPoint = nowRightHand.transform.position; 
                lineRenderer.SetPosition(1, stringPoint); // ���η������� ��ġ�� ����
                Debug.Log("������ ��ġ�� ����");
                yield return null;
            }
        }
        */
}
