# Simple Pet Movement

This repository contains scripts for implementing a simple pet movement behavior in Unity. The simple approach allows for creating follower objects that mimic the movements of a designated leader object, resulting in a chain-like formation where the leader moves ahead and the followers trail behind.

### Overview
The pet movement approach consists of two main components: the leader and the follower. The leader object is controlled by the player and serves as the guiding force for the followers. The followers, on the other hand, track the movements of the leader and adjust their positions accordingly to maintain a specified distance.

### Features
- Leader-Follower Architecture: The system is based on a leader-follower architecture, where the leader object controls the movement direction, and the follower objects follow behind.
- Customizable Parameters: Various parameters such as movement speed, follow offset, maximum distance, and stop distance are provided to customize the behavior of the followers.
- Integration with Animator: Optional integration with Unity's Animator component allows for visual feedback on the movement state of both the leader and followers.

### Usage
- Leader Setup: Attach the Leader script to the GameObject that you want to act as the leader. Customize the movement parameters and assign any necessary references in the Inspector.
- Follower Setup: Attach the PetMovement script to the GameObjects that you want to act as followers. Assign the leader GameObject to the leaderTransform field of each follower.
- Customization: Customize the movement parameters of each follower in the Inspector to achieve the desired behavior.
- Gameplay Integration: Use triggers or other gameplay mechanics to dynamically add followers to the leader as needed during gameplay.

### Video
https://github.com/khizarfarooq30/Simple-Pet-Movement/assets/24452001/e7dd4dab-6324-4ae8-adaf-df4260e3612f

# Contributions
Contributions to improve or extend the functionality of the pet movement system are welcome! Feel free to fork the repository, make your changes, and submit a pull request.

# License
This project is licensed under the [MIT License](https://opensource.org/license/mit/).


