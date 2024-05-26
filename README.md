# Simple Pet Movement

This repository contains scripts for implementing a simple pet movement behavior in Unity. The simple approach allows for creating follower objects that mimic the movements of a designated leader object, resulting in a chain-like formation where the leader moves ahead and the followers trail behind.

### Overview
The pet movement approach consists of two main components: the leader and the follower. The leader object is controlled by the player and serves as the guiding force for the followers. The followers, on the other hand, track the movements of the leader and adjust their positions accordingly to maintain a specified distance.

### Features
- **Leader-Follower Architecture**: The system is based on a leader-follower architecture, where the leader object controls the movement direction, and the follower objects follow behind.
- **Customizable Parameters**: Various parameters such as movement speed, follow offset, maximum distance, and stop distance are provided to customize the behavior of the followers.
- **Integration with Animator**: Optional integration with Unity's Animator component allows for visual feedback on the movement state of both the leader and followers.
- **Advanced Formation Strategies**: New strategies for pet movement have been implemented, including:
  - Box Formation
  - Chained Snake-like Formation
  - Crazy Circular Formation
  - Golden Ratio Formation
  - Golden Ratio with Repel Formation
  - Leader Repel Formation
  - Row-Column Adaptive Formation
  - Circular Formation
  - Pet Repel Pet Formation

### Usage
- **Leader Setup**: Attach the `Leader` script to the GameObject that you want to act as the leader. Customize the movement parameters and assign any necessary references in the Inspector.
- **Follower Setup**: Attach the `PetMovement` script to the GameObjects that you want to act as followers. Assign the leader GameObject to the leaderTransform field of each follower.
- **Customization**: Customize the movement parameters of each follower in the Inspector to achieve the desired behavior.
- **Formation Strategy**: During gameplay, you can dynamically assign different formation strategies to the followers using number keys (1-9, 0, Q, E) for various strategies as per your need.
- **Gameplay Integration**: Use triggers or other gameplay mechanics to dynamically add followers to the leader as needed during gameplay.

### Scripts

#### Leader.cs
This script controls the leader's movement and manages the addition of followers. Key features include:
- Adjustable movement speed and angular speed.
- Option to enable upward movement.
- Parameters for maximum distance, stop distance, and follow offset.
- Formation parameters like repel amount, golden ratio settings, and grid dimensions.
- Dynamic formation adjustment when a follower is added.

#### PetMovement.cs
This script manages the movement behavior of the followers. Key features include:
- Reference to the leader object.
- Dynamic assignment of different movement strategies using keyboard input.
- Initialization of followers and their default strategy.

### Video
https://github.com/khizarfarooq30/Simple-Pet-Movement/assets/24452001/e7dd4dab-6324-4ae8-adaf-df4260e3612f

https://github.com/khizarfarooq30/Simple-Pet-Movement/assets/24452001/becc2997-989e-47e5-8ddc-e18da8dac489

### Contributions
Contributions to improve or extend the functionality of the pet movement system are welcome! Feel free to fork the repository, make your changes, and submit a pull request.

### License
This project is licensed under the [MIT License](https://opensource.org/license/mit/).
