using UnityEngine;

public class SingletonUI : MonoBehaviour
{
    // pause 버튼을 누르면 게임 일시정지 (다시 누르면 재개)
    public void OnClickBtnPause()
    {
        var manager = SingletonManger.Instance;
        if (manager == null)
        {
            Debug.LogWarning("씬에 SingletonManger가 없습니다. 빈 오브젝트에 SingletonManger를 붙이세요.");
        }
        else if (manager.IsPaused)
        {
            manager.ContinueGame();
        }
        else
        {
            manager.PauseGame();
        }

        // MonoBehaviour가 아닌 일반 클래스 싱글톤도 같은 방식으로 호출할 수 있다.
        GameMgr.Instance.TogglePause();
    }
}

// 일반 C# 클래스 싱글톤: 처음 접근할 때 만들어진다(지연 생성). 씬에 오브젝트가 필요 없다.
public class GameMgr
{
    // 게임매니저의 인스턴스를 담는 전역변수
    private static GameMgr instance;

    // 게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameMgr Instance
    {
        get
        {
            // 게임 인스턴스가 없다면 하나 생성해서 넣어준다.
            if (null == instance) instance = new GameMgr();
            return instance;
        }
    }

    // 외부에서 new로 만들지 못하게 private 생성자
    private GameMgr() { }

    public bool IsPaused { get; private set; }
    public int RestartCount { get; private set; }

    public void InitGame() { IsPaused = false; }
    public void PauseGame() { IsPaused = true; }
    public void ContinueGame() { IsPaused = false; }
    public void TogglePause() { IsPaused = !IsPaused; }
    public void RestartGame() { RestartCount++; InitGame(); }
    public void StopGame() { IsPaused = true; }
}
