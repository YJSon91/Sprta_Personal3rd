# Sprta_Personal3rd
스파르타 유니티 심화 개인과제
이 프로젝트는 Unity 엔진을 공부하하기 위해 수행한 과제입니다. 캐릭터의 성장과 아이템 장착, 적과의 전투 등 RPG의 핵심적인 요소를 구현하는 것을 목표로 합니다.

🎮 게임 개요
플레이어는 기사 캐릭터를 조종하여 게임 월드를 탐험합니다. 스탯을 관리하고, 인벤토리의 아이템을 장착/사용하며, 상태 머신 기반의 AI를 가진 적과 전투를 벌입니다. 이 프로젝트는 RPG 게임의 기본 시스템을 구축하고 학습하는 과정을 담고 있습니다.

✨ 주요 기능
캐릭터 시스템

레벨, 경험치, 체력, 골드, 공격력, 방어력 등 기본 스탯 관리
경험치 획득 시 UI에 슬라이드 바로 시각적 표현
UI 시스템

UIManager를 통한 중앙 집중식 UI 관리 (싱글톤 패턴)
Tab 키를 이용한 메인 메뉴 활성화 (게임 일시정지 및 마우스 커서 제어 포함)
게임 시작 시 튜토리얼 패널 팝업 기능
상태창(Status): 캐릭터의 현재 스탯(장비 포함)을 실시간으로 표시
인벤토리(Inventory):
고정된 크기의 슬롯(9칸) 표시
보유한 아이템만 아이콘 표시, 빈칸은 빈 슬롯으로 표시
아이템 장착 시 슬롯에 'E' 마크 표시
아이템 장착/해제 토글 기능
아이템 및 장비 시스템

ScriptableObject를 활용한 데이터 기반 아이템 관리
장비(Equipment)와 소모품(Consumable) 등 아이템 타입 구분
장비 장착 시 캐릭터의 최종 스탯에 합산되어 반영
적 AI 시스템

상태 머신(State Machine) 기반의 AI 로직 (대기, 추격, 공격 상태)
카메라 워크

Cinemachine을 이용한 부드러운 카메라 추적
🧑‍💻 팀원 소개
손영준 - 모든 기능 개발
📅 개발 기간
2025년 6월 4일 ~ 2025년 6월 11일
🛠 사용한 기술
Engine: Unity Engine
Language: C#
Core Systems:
UGUI (UI 시스템)
Cinemachine
ScriptableObject (아이템 데이터 관리)
Unity Event System (이벤트 기반 로직)
Prefab (UI 및 오브젝트 재사용)
🖼️ 에셋
UI & Icons: Kenney.nl (UI Pack, Input Pack 등)
Icons: Pixel Art Icon Pack - RPG
3D Model: mixamo (Paladin W/Prop J Nordstrom)
