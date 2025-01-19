# Balloon Shooter Game

## Controls

- Press `Q` to quit the game at any time.

## Overview

The Balloon Shooter Game is a first-person shooter game where the player shoots darts at balloons passing in front of them. The goal is to pop as many balloons as possible to increase the player's score.

## Features

- Randomly generated balloons with varying velocities.
- Balloons disappear if not popped within a certain time.
- Different types of balloons with different score values (1, 3, and 5 points).
- Darts are shot in the direction of the mouse cursor.
- The longer the mouse button is held, the farther the dart is shot.
- A scoring system that updates the player's score when balloons are popped.
- A menu system to start the game.

## Implementation Details

### Balloon Physics

- Balloons are generated with a random velocity vector in the (Y, Z) plane.
- Balloons appear in a predefined rectangle in front of the player.
- Balloons have a negative Z speed, null X speed, and variable Y speed.
- Bouncy balloons act as obstacles to increase or decrease the game's difficulty.

### Dart Shooting Mechanism

- Darts are shot in the direction of the mouse cursor using raycasting.
- The dart's speed increases the longer the mouse button is held, with a minimum speed of 10 and a maximum speed of 20.
- The dart's speed is computed by clamping the value between the minimum and maximum speeds.

### Scoring System

- The player's score is displayed on the screen.
- The score is incremented when a dart touches a balloon.
- Different types of balloons give different points (1, 3, or 5 points).
- A scoreboard system keeps track of the top 10 scores.

### Menu System

- A simple menu with a "Play" button to start the game.
- The game starts when the "Play" button is pressed.

## How to Play

1. Start the game from the main menu by pressing the "Play" button.
2. Use the mouse to aim and shoot darts at the balloons.
3. Hold the mouse button to increase the dart's speed.
4. Pop as many balloons as possible to increase your score.

## Future Improvements

- Implement different difficulty levels.
- Add more types of balloons with varying behaviors.
- Enhance the scoring system with player names and score saving.
- Improve the menu system with additional settings and options.

## Development

### Project Structure

- `Assets/Scripts/`: Contains all the scripts used in the game.
- `Assets/Prefabs/`: Contains the prefabs for balloons and darts.
- `Assets/Scenes/`: Contains the game scenes, including the main menu and game scene.

### Key Scripts

- `GameManager.cs`: Manages the game state and persists across scenes.
- `MenuManager.cs`: Handles the main menu interactions.
- `Balloon.cs`: Base class for balloons with different score values.
- `DartShooter.cs`: Handles the dart shooting mechanism.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you have any suggestions or improvements.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.