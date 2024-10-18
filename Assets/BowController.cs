using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] GameObject arrowModel; // ȭ�� ������ �� ������Ʈ
    [SerializeField] Transform arrowModelPos; // ȭ�� ���� �⺻ ��ġ
    [SerializeField] Transform startPos; // ȭ�� ���� �⺻ ��ġ

    private void Start()
    {
        arrowModel.SetActive(false); // ������ �����ϸ� ��Ȱ��ȭ�� ����
        startPos = arrowModelPos;
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
        arrowModel.transform.position = startPos.position;
    }
}
