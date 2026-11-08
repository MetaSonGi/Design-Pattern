using UnityEngine;

// 노란 열쇠가 있어야 열리는 문. 알림을 받을 때마다 열림/닫힘이 바뀌고, 문짝이 경첩을 축으로 부드럽게 회전한다.
public class DoorYellow : Door
{
    [Tooltip("문을 열기 위해 필요한 열쇠 이름. 비우면 열쇠 없이 열린다.")]
    public string requiredKey = "YellowKey";

    [Tooltip("열렸을 때 회전 각도(Y축)")]
    public float openAngle = 90f;

    [Tooltip("초당 회전 속도(도)")]
    public float speed = 180f;

    Quaternion closedRotation;

    void Awake()
    {
        closedRotation = transform.localRotation;
    }

    public override void OpenOrClose()
    {
        if (!KeyRing.Has(requiredKey))
        {
            Debug.Log($"{name}: '{requiredKey}' 열쇠가 없어 문이 열리지 않습니다.");
            return;
        }
        if (IsOpen) Close(); else Open();
    }

    void Open()
    {
        IsOpen = true;
        Debug.Log($"{name}: 문 열림");
    }

    void Close()
    {
        IsOpen = false;
        Debug.Log($"{name}: 문 닫힘");
    }

    void Update()
    {
        Quaternion target = IsOpen ? closedRotation * Quaternion.Euler(0f, openAngle, 0f) : closedRotation;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, target, speed * Time.deltaTime);
    }
}
