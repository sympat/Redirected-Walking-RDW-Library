# Redirected-walking-RDW-API
<p align="center">
  <img 
    width="80%"
    src="/Resources/teaser_video.gif"
  >
</p>

본 프로젝트는 컴퓨터 그래픽스 연구실 소속으로, 손쉽게 Redirected walking을 구현해서 simulation 할 수 있고 공유할 수 있는 API를 만들기 위해 진행되었습니다. 해당 프로젝트의 현재 버전은 시연은 가능하나 완벽히 배포 가능한 상태는 아니며 연구실 구성원들의 QA를 통해서 개발 중인 단계입니다. 현재는 구성원마다 독자적으로 이것을 확장 및 수정하여 사용하고 있습니다.

Redirected walking (RDW)는 사용자가 좁은 실제 공간과 충돌하지 않으면서 넓은 가상 공간을 실제로 걸어서 탐험할 수 있도록 사용자 동작을 조작하는 기법을 말합니다. 구체적으로 RDW는 사용자가 해당 기법에 적용되었는지를 인식 했냐에 따라서 subtle 방식 (Redirection) 과 overt 방식 (Reset)으로 나뉘며, 각 기법마다 서로 장단점이 존재하기 때문에 최근까지 연구된 대부분의 이론에서는 두 기법을 섞어서 사용하고 있습니다. 

RDW API는 Unity를 통해서 가상 현실 보행 기법인 Redirected walking을 Unity3D 상에서 쉽게 simulation 하기 위해 만들어졌습니다. 해당 API의 특징은 다음과 같습니다.
* Redirection 분야에서 많이 사용되고 있는 Steer-to-Center (S2C) 를 탑재
* 자신이 제안한 새로운 Redirection 혹은 Reset algorithm을 쉽게 추가 및 교체
* Single User가 아닌 2명 이상의 Multi user를 지원
* Simulation 과정 시각화
* 다양한 형태의 가상 환경에서의 Simulation 가능 (장애물 존재 등)
* 그 외 python의 시각화 및 통계 tool과 연계 및 ML-agents를 통한 강화 학습 기반 Redirection algorithm (SRL 등) 추가가 가능하도록 구현중

# Requirement
+ Unity 2019.4.10+
+ Unity Hub 2.4+
+ Unity [ML Agents](https://github.com/Unity-Technologies/ml-agents) package 1.6+ (기본적으로 포함되어 있음)

# How to use
1. Clone 한 뒤에, Unity Hub를 통해서 Clone된 디렉토리를 추가하여 Unity 프로젝트로 실행합니다.
2. **_Scenes_** -> **_RDWSimulation_** scene 을 실행합니다.
3. scene 상에 있는 **_RDSSimulation_** 객체에 부착되어 있는 **_RDWSimulationManager_** 의 값들을 적절하게 조절해줍니다.
4. 해당 scene을 실행합니다.

<p align="center">
  <img 
    width="50%"
    src="/Resources/how_to_use_1.png"
  >
  <img 
    width="50%"
    src="/Resources/how_to_use_2.png"
  >
</p>
<p align="center">
  <img 
    width="50%"
    src="/Resources/how_to_use_3.png"
  >
</p>

# RDWSimulationManager Options
* **Simulation Setting**
  + Use Visualization: 시뮬레이션을 Unity scene 상에서 보이게 해서 진행할지를 결정
  + Use Debug Mode: 각 object들의 외곽선이나 user의 경로 등을 시각화할지 결정
  + Use Continous Simulation: 모든 Unit들이 시뮬레이션을 완료했을 때, 전체 시뮬레이션을 끝내지 않고 반복해서 다시 진행할지 결정
* **Prefab Setting**: 실험에 사용될 Prefab들을 지정
* **(Real/Virutal) Space Setting**
  + Use Predefinded Space: 미리 정의된 Space를 사용할지 결정
  + Name: Space 객체의 이름
  + Predefined Space: 사용할 Space 객체
  + Position: Space 객체의 위치
  + Rotation: Space 객체의 회전 값
* **Unit Setting**
  + Redirect Type: 적용할 Redirection algorithm 종류
  + Reset Type: 적용할 Reset algorithm 종류
  + Episode Type: 사용하고자 하는 Episode 종류
  + Episode File Name: Pre-define Episode 사용시, 정의된 episode 파일
  + Use Random Start: 임의의 위치에서 unit을 시작할지 결정
  + User Prefab: 실험에 사용될 user 객체
  + User Start Rotation: user의 시작 회전값
  + Real Start Position: 실제 user의 시작 위치
  + Virutal Start Position: 가상 user의 시작 위치
  + Translation Speed: user의 이동 속도
  + Rotation Speed: user의 회전 속도

이 외의 옵션들은 현재 개발 중이며, 해당 옵션을 조절할 시 정상적으로 작동되지 않을 가능성이 있으니 주의.

# Class Diagram
MonoBehaviour 클래스를 상속받아서 Unity의 Component로서 Object에 부착할 수 있는 클래스는 RDWSimulationManager 1가지로 구성됩니다.

## Manager Module
### Builder
* Builder 디자인 패턴이 적용되었으며, 입력받은 인자들을 토대로 적절한 객체 (RedirectedUnit, 2DGeometry 등)를 생성해주는 부분입니다.
### Setting
* 시뮬레이션에 필요한 객체를 생성하기 위한 인자값들을 입력받으며, 내부적으로 Builder를 호출하여 객체를 가져옵니다.
### RDWSimulationManager
* 시뮬레이션을 1 스텝을 진행시키거나, 시뮬레이션이 끝났는지를 검사하는 것과 같이 전체 시뮬레이션을 관리하는 역할을 합니다.
* 시뮬레이션 내에 존재하는 모든 RedirectedUnit 들을 관리하며 시뮬레이션이 진행될 때마다 관리하고 있는 모든 RedirectedUnit들에게 전파합니다. 

## Simulation Unit Module
* 시뮬레이션에서 가상과 실제 각각에 대해서 한명의 사용자와 그 사용자가 서있는 공간을 묶어서 관리합니다.
* 시뮬레이션이 진행될때마다 지정된 Controller를 통해서 사용자를 움직인 뒤에 이 움직임에 Redirection을 적용합니다.
* 공간 상에서 사용자 의 상태(공간 안에 있다, 밖에 있다 등)를 판단한 뒤에 내부적으로 State 디자인 패턴을 통해서 해당 상태를 계속해서 갱신하고 관리합니다. 그리고 이 상태에 따라서 Reset을 적용합니다.

<p align="center">
  <img 
    width="100%"
    src="/Resources/class_diagram_1.png"
  >
</p>

## 2DGeometry Module
### Object2D
* 시뮬레이션 환경을 위에서 바라본 2차원 형태를 나타내며, 시뮬레이션 상의 모든 객체는 내부적으로 2DGeometry 형태로 저장됩니다.
* 최상위 객체로 Object2D가 있으며, 구체적으로 어떤 형태인지에 따라서 Circle2D, Polygon2D로 나뉩니다.
### Transform2D
* Transform2D를 통해서 어떤 물체의 외곽선을 2차원 형태로 나타내고 이것의 위치, 회전, 스케일 값을 관리합니다.
* Adapter 디자인 패턴을 응용하여 Unity에서 제공하는 3차원 Transform 중에서 두개의 차원 값을 적절하게 선택해서 반환하거나 관련된 함수를 내부적으로 호출하는 방식으로 구현되었습니다.

## Method Module
### Controller
* 시뮬레이션에서 사용자 에이전트가 어떤 식으로 움직일지를 결정합니다.
* 내부적으로 Episode 라는 객체를 통해서 사용자 에이전트의 경로 패턴을 저장합니다.
### Redirector
* 시뮬레이션에 적용할 Redirection 기법을 결정합니다. 
* Redirection은 실제 공간과 충돌을 방지하기 위해 사용자의 경로를 왜곡하는 방식을 말합니다.
### Resetter
* 시뮬레이션에 적용할 Reset 기법을 결정합니다.
* Reset은 사용자가 실제 공간의 장애물이나 경계에 도달했을 때 사용자의 이동을 재조정하는 방식을 말합니다.

<p align="center">
  <img 
    width="100%"
    src="/Resources/class_diagram_2.png"
  >
</p>
