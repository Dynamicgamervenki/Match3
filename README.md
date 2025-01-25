# Match-3 Game (Candy Crush Style) 🎮

A simple yet engaging Match-3 game created in Unity in under 7 hours. Inspired by games like Candy Crush, this project demonstrates core game mechanics such as tile matching, smooth animations, and dynamic gameplay.

## Features ✨

* Fully functional Match-3 mechanics (horizontal and vertical matches)
* Smooth animations for gem swaps and movements
* Automatic refill of the board when matches are cleared
* Support for different gem types: 🟦 🟩 🟥 🟨 🟪
* Simple and efficient implementation using C# scripts in Unity

## Project Structure 📂

### Core Scripts

* **`Board.cs`**: Manages the game board, spawns gems, checks for matches, and handles gem destruction and refill logic.
* **`Gem.cs`**: Handles individual gem behaviors, such as swiping, movement, and interaction with the board.
* **`MatchFinder.cs`**: Detects all matches on the board and maintains a list of matched gems.

## Getting Started 🚀

### Requirements

* Unity Editor: Version 2022.3.16f1 or higher

### Instructions

1. **Clone the repository:**

    ```bash
    git clone [https://github.com/your-username/Match3Game.git](https://github.com/your-username/Match3Game.git)
    ```

2. **Open the project in Unity:**
   * Launch the Unity Hub.
   * Click "Open" and navigate to the cloned `Match3Game` folder.
   * Click "Open Project."

3. **Set up the scene:**
   * In the Unity Editor, navigate to the `Scenes` folder.
   * Open the main scene file (e.g., `MainScene.unity`).

4. **Create a new GameObject:**
   * Right-click in the Hierarchy and select "Create" -> "Empty."
   * Rename the new GameObject to "Board."
   * Add the `Board.cs` script to the "Board" GameObject.
   * In the Inspector, configure the Board settings:
     * Set the width and height of the board.
     * Assign the `bgTilePrefab` for background tiles.
     * Drag and drop gem prefabs into the Gems array.

5. **Create a new GameObject for `MatchFinder`:**
   * Create another Empty GameObject.
   * Add the `MatchFinder.cs` script to this GameObject.

6. **Play the game:**
   * Press the Play button in the Unity Editor.
   * Swipe gems using the mouse to create matches.

### Player Interaction

* Players swipe gems to adjacent positions.
* Valid moves are checked based on the resulting matches.
* If no matches are made, gems return to their original positions.

### Match Handling

* Matched gems are destroyed.
* Gems above the destroyed ones "fall" to fill empty spaces.
* New gems are spawned to fill the top rows.

### Repeat

* The game continues until no more valid moves are possible (future enhancement).

## Customization 🛠️

* **Add more gem types**: Create new gem prefabs and add them to the Gems array in `Board.cs`.
* **Change the grid size**: Modify the width and height values in the Board component.
* **Adjust gem movement speed**: Update the `gemSpeed` parameter in `Board.cs` for faster or slower animations.

## Future Enhancements 🌟

* **Scoring System**: Reward players for creating matches.
* **Power-Ups**: Introduce special effects for bigger matches (e.g., bombs, rainbow gems).
* **Sound Effects and Music**: Add audio for matches, swipes, and gameplay events.
* **Level System**: Implement levels with increasing difficulty.

## Screenshots 📸

<!-- Uploading "Match3 - SampleScene - Windows, Mac, Linux - Unity 6 (6000.0.34f1) _DX11_ 2025-01-25 15-05-24.mp4"... -->

* Initial Board
* Match Cleared
* Refilling Board

## Contributing 🤝

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License 📜

This project is open-source and available under the MIT License.
