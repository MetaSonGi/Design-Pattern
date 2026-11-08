using System.Collections.Generic;
using UnityEngine;

// 옵저버 패턴의 "주체(Subject)": 등록된 문 목록을 가지고 있다가 버튼이 눌리면 모두에게 알린다.
public class SwitchButton : MonoBehaviour
{
    public List<Door> doors = new List<Door>();

    public void AddDoor(Door door)
    {
        if (door == null) return;
        if (doors.Contains(door))
            Debug.Log("이미 해당 문이 리스트에 존재합니다.");
        else
            doors.Add(door);
    }

    public void RemoveDoor(Door door)
    {
        if (!doors.Remove(door))
            Debug.Log("해당 문이 리스트에 없어 제거하지 않았습니다.");
    }

    // UI 버튼의 OnClick에 연결
    public void OnClickSwitchButton()
    {
        NotifyDoors();
    }

    public void NotifyDoors()
    {
        // 알림 도중 목록이 바뀌어도 안전하도록 복사본으로 순회, 삭제된 문은 건너뜀
        foreach (Door d in new List<Door>(doors))
        {
            if (d != null) d.OpenOrClose();
        }
    }
}
