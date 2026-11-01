# 🪙 Carrom Mobile Game (Unity 2D)

An open-source 2D mobile Carrom board game project built with C# and designed for cross-platform mobile play. 

## 📂 Project Architecture & Scripts

The game logic is structured around modular C# scripts managing physics, input, scoring, and game state:

* **`StrikerController.cs`** - Handles touch inputs, dragging mechanics, and the impulse physics applied to shoot the striker.
* **`PocketDetector.cs`** - Detects when coins or the striker enter pockets, handling scoring and foul triggers.
* **`GameManager.cs`** - Master controller managing turn switching, player scores, fouls, and active game modes (Local 2-Player or vs AI).
* **`CoinSpawner.cs`** - Automatically initializes and positions the classic circular Carrom board coin layout (Queen, white coins, and black coins) at startup.
* **`TrajectoryLine.cs`** - Renders a real-time aiming vector preview when the player pulls back the striker.
* **`AudioManager.cs`** - Centralized sound manager handling triggers for striker shots, coin impacts, pocket scores, and fouls.
* **`BotAI.cs`** - Manages computer opponent decision-making and automated shot calculations for single-player mode.
* **`CoinCollision.cs`** - Detects physical impact velocities between coins and triggers dynamic collision sound effects.

## 🕹️ Features
* 👥 **Dual Game Modes:** Play local multiplayer (Player vs Player) or challenge the AI bot.
* 🎯 **Precision Aiming:** Visual trajectory lines to help line up your shots.
* 🔊 **Dynamic Audio:** Real-time collision-based sound effects and score alerts.
* 📱 **Mobile-First Design:** Lightweight architecture optimized for mobile platforms.

## 🛠️ Tech Stack
* **Engine:** Unity (2D Physics Engine)
* **Language:** C#
* **Version Control:** Git / GitHub
