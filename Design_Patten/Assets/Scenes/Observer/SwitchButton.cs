using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public List<Door> doors = new List<Door>();

    public void AddDoor(Door door)
    {
        if (doors.Contains(door))
        {
            Debug.Log("이미 해당 문이 리스트에 존재하고 있음.");
        }
        else
        {
            doors.Add(door);
        }
    }

    public void RemoveDoor(Door door)
    {
        if (doors.Contains(door))
        {
            doors.Remove(door);
        }
        else
        {
            Debug.Log("문이 리스트에 존재하지 않아서 제거하지 못함.");
        }
    }

    public void OnClickSwitchButton()
    {
        NotifyDoors();
    }

    public void NotifyDoors()
    {
        foreach (Door d in doors)
        {
            d.OpenOrClose();
        }
    }
}
