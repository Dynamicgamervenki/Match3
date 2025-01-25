Match-3 Game (Candy Crush Style)
A simple yet engaging Match-3 game created in Unity in under 7 hours. Inspired by games like Candy Crush, this project demonstrates core game mechanics such as tile matching, smooth animations, and dynamic gameplay.

Features
Fully functional Match-3 mechanics (horizontal and vertical matches).
Smooth animations for gem swaps and movements.
Automatic refill of the board when matches are cleared.
Support for different gem types (blue, green, red, yellow, purple).
Simple and efficient implementation using C# scripts in Unity.
Project Structure
Scripts
Board.cs: Manages the game board, spawns gems, checks for matches, and handles gem destruction and refill logic. 
Gem.cs: Handles individual gem behaviors, such as swiping, movement, and interaction with the board. 
MatchFinder.cs: Detects all matches on the board and maintains a list of matched gems. 
Setup Instructions
Requirements
Unity Editor (Version 2022.3.16f1 or higher) teps to Run the Game**
Clone this repository:
bash
Copy
Edit
git clone https://github.com/your-username/Match3Game.git
Open the project in Unity:
Launch Unity Hub.
Click on Open Project.
Navigate to the cloned project folder and select it.
Set up the scene:
Create a new Unity Scene or use the provided one.
Add a GameObject and attach the Board.cs script to it.
Configure the Board settings:
Set the width and height of the board.
Assign the bgTilePrefab for background tiles.
Assign gems (drag different gem prefabs into the array).
Add another GameObject and attach the MatchFinder.cs script to it.
Play the game:
Press the Play button in the Unity Editor to start the game.
Swipe gems using the mouse to create matches.
Code Overview
Board.cs
Initializes the game board with random gems.
Detects matches using the MatchesAt method.
Handles gem destruction, refilling, and shifting rows down when matches are cleared.
Gem.cs
Manages gem movements and swipe interactions.
Updates gem positions in the grid and validates valid moves using coroutines.
MatchFinder.cs
Checks the board for horizontal and vertical matches.
Uses a list (currentMatches) to store all matched gems and ensure no duplicates.
How It Works
Gems are randomly spawned on the board, ensuring no matches are present at initialization.
Players can swipe gems to adjacent positions:
Valid moves are checked based on the resulting matches.
If no matches are made, gems return to their original positions.
Matches trigger:
Matched gems are destroyed.
Gems above the destroyed ones "fall" to fill the empty spaces.
New gems are spawned to fill the top rows.
Gameplay continues until no more valid moves are possible (logic to detect this can be implemented later).
Customization
Add more gem types by creating new prefabs and assigning them in the Board script.
Change the grid size by modifying the width and height values in the Board script.
Modify gem movement speed via the gemSpeed parameter.
Known Limitations
The game currently lacks sound effects and a scoring system.
There's no UI for start/restart screens or displaying scores.
Detecting when no more valid moves exist is not implemented.
Future Enhancements
Add a scoring system to reward players for creating matches.
Implement power-ups for larger matches (e.g., 4 or 5 gems in a row).
Introduce levels with different grid sizes and gem types.
Add animations and sound effects for a polished experience.
License
This project is open-source and available for anyone to use and improve. Feel free to customize it for your own projects!