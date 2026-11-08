using UnityEngine;

// MonoBehaviour 싱글톤: 씬에 하나만 존재하고, 씬이 바뀌어도 유지된다.
// Unity는 MonoBehaviour 클래스 이름과 파일 이름이 같아야 컴포넌트로 붙일 수 있으므로 파일명(SingletonManger)과 맞췄다.
public class SingletonManger : MonoBehaviour
{
    // 게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    // 이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    // 보안을 위해 private으로.
    private static SingletonManger instance = null;

    public bool IsPaused { get; private set; }

    void Awake()
    {
        if (null == instance)
        {
            // 이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            // 씬 전환이 되더라도 파괴되지 않게 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // 씬 이동 후 그 씬에도 매니저가 있으면 이전 씬의 인스턴스를 계속 쓰고, 새로 생긴 자신은 삭제한다.
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if (instance == this) instance = null;
    }

    // 게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. 씬에 매니저가 없으면 null.
    public static SingletonManger Instance
    {
        get { return instance; }
    }

    public void InitGame()
    {
        ContinueGame();
    }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        InitGame();
    }

    public void StopGame()
    {
        PauseGame();
    }
}
