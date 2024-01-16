using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�

    void LateUpdate()
    {
        if (target != null)
        {
            // �÷��̾��� ���� ��ġ
            Vector3 desiredPosition = target.position;


            // ���� ī�޶��� ��ġ���� �÷��̾��� ��ġ�� �ε巴�� �̵�
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // ī�޶� ��ġ ������Ʈ
            transform.position = smoothedPosition;
        }
    }
}
