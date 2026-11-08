# Design-Pattern
유니티 디자인 패턴 예제 — **옵저버(Observer)**, **싱글톤(Singleton)** (Unity 프로젝트: `Design_Patten/`)

## 예제
| 패턴 | 폴더 | 동작 |
|---|---|---|
| 옵저버 | `Assets/Scenes/Observer` | `SwitchButton`(주체)이 등록된 `Door`(관찰자)들에게 알림 → `DoorYellow`는 `YellowKey`가 `KeyRing`에 있으면 열림/닫힘을 토글하고 부드럽게 회전 |
| 싱글톤 | `Assets/Scenes/Singleton` | `SingletonManger`(MonoBehaviour 싱글톤, 씬 전환 유지)로 일시정지/재개(`Time.timeScale`), `GameMgr`(일반 C# 지연 싱글톤)로 상태·재시작 횟수 관리 |

## 2026-11 수정 내역
- **컴파일 오류 수정**: `SingletonManger.cs` 안의 클래스 이름(`SinglePatten`)이 파일명과 달라 Unity가 컴포넌트를 붙이지 못하던 문제 → `SingletonManger`로 통일 (.meta GUID 유지)
- **글자 깨짐 수정**: 원본이 CP949로 저장돼 GitHub·다른 PC에서 한글 주석이 깨지던 것을 UTF-8로 변환
- 옵저버: 관찰자 중복 등록·null 참조 방지, 알림 중 목록 변경에 안전하도록 복사본 순회, 열쇠 보관용 `KeyRing` 추가, 문 열림 애니메이션
- 싱글톤: 중복 인스턴스 제거, 파괴 시 인스턴스 해제, UI에서 매니저 null 체크, `GameMgr` 생성자 private
- `.gitignore`: 프로젝트가 하위 폴더에 있어 `/Library/` 같은 루트 기준 패턴이 안 먹던 문제 → 슬래시 없는 패턴으로 변경

## 검증
Unity API 스텁 + Mono `mcs -warnaserror+`로 컴파일, 동작 점검 13항목 통과 (문 등록/해제·중복 방지, 열쇠 없을 때 안 열림, 토글, 싱글톤 유일성·일시정지·재개·재시작 횟수 등). Unity 에디터 실기 실행은 미검증.

## 참고
이미 커밋된 `Library/`·`obj/`·`Logs/`·`UserSettings/` 폴더(약 100MB)는 `.gitignore`를 바꿔도 저장소에 남아 있습니다. 정리하려면 로컬에서:
```bash
git rm -r --cached Design_Patten/Library Design_Patten/obj Design_Patten/Logs Design_Patten/UserSettings
git commit -m "Remove generated Unity folders" && git push
```
