using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorYellow : Door
{
    bool isClosed;
    public override void OpenOrClose()
    {
        //if (Inventory.Instance.HasItem("YellowKey"))
        //{
        //    if (isClosed)
        //    {
        //        isClosed = false;
        //        Oepn();
        //    }
        //    else
        //    {
        //        isClosed = true;
        //        Close();
        //    }
        //}
    }

    void Open()
    {
        //문 열기 구현
    }

    void Close()
    {
        //문 닫기 구현
    }
}
