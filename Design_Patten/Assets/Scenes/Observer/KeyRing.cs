using System.Collections.Generic;

// 플레이어가 가진 열쇠 목록 (예제용 간단한 보관함). DoorYellow가 열쇠 조건을 확인할 때 사용한다.
public static class KeyRing
{
    static readonly HashSet<string> keys = new HashSet<string>();

    public static void Add(string key) { if (!string.IsNullOrEmpty(key)) keys.Add(key); }
    public static bool Remove(string key) { return keys.Remove(key); }
    public static bool Has(string key) { return string.IsNullOrEmpty(key) || keys.Contains(key); }
    public static void Clear() { keys.Clear(); }
}
