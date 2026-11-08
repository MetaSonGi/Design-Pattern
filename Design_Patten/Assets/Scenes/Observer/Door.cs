using UnityEngine;

// 옵저버 패턴의 "관찰자(Observer)": 스위치(SwitchButton)가 알리면 각 문이 스스로 반응한다.
public abstract class Door : MonoBehaviour
{
    public bool IsOpen { get; protected set; }

    // 스위치가 눌렸다는 알림을 받았을 때 호출된다.
    public abstract void OpenOrClose();
}
