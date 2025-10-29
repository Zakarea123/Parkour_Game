#ParkourGame (Demo)

A **2D parkour-style demo game** built in **Godot Engine using C#**, showcasing core platformer mechanics such as movement, jumping, enemies, and checkpoints.  
This project was developed as a personal learning experience and serves as a playable demonstration of my growing skills in **game design, programming, and UI development**.

---

##What the Project Does

**ParkourGame** is a short, fast-paced 2D platformer demo featuring:
- Smooth **left/right movement** and **jump mechanics**  
- **Health system** with three lives before a full reset  
- **Slime enemies** that challenge the player through two levels of increasing difficulty  
- **Checkpoint system** that saves progress when a level is completed  
- Functional **Pause Menu** and **Main Menu** built in Godot  
- Complete C# integration for gameplay logic and UI management  

---

##How to Get Started

###Play the Game
1. **Download the latest release** or clone this repository.  
2. Ensure all files remain in the same folder as the executable.  
3. Run the game by simply **double-clicking `ParkourGame.exe`**.  
   - No installation or additional setup is required.  
   - All assets and dependencies are included in the download.  

###Explore the Code
1. Open the project in **Godot 4.x** (C# version).  
2. Browse through the scripts to see how movement, UI, and enemy behavior are implemented.

---

##Learning Resources & Credits

- **Game Assets:** [Brackeys Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle)  
- **Tutorial Inspiration:** [Brackeys – “Make a 2D Platformer in Godot”](https://www.youtube.com/watch?v=LOhfqjmasi0&t=3886s)  

All game logic, structure, and UI implementation were independently built and customized by **Zakarea Alammour**.

---

##Where to Get Help

If you encounter issues, have suggestions, or want to discuss improvements:
- Open an **Issue** on this GitHub repository  
- Or contact me directly via my GitHub profile: [@Zakarea123](https://github.com/)

---

##Maintainer & Contributor

**Created and maintained by:**  
🧑‍💻 **Zakarea Alammour**  
> Sole developer responsible for game design, programming, and UI implementation.

---

##Tech Stack

- **Engine:** Godot 4 (C# scripting)  
- **Language:** C#  
- **Export Target:** Windows (.exe)  
- **Genre:** 2D Platformer / Parkour Demo

---

## How to Run Unit Tests (Optional)

This project includes automated tests built using the GDUnit4 testing framework, integrated with JetBrains Rider to run tests outside the Godot editor.  
All test scripts are located inside the `Testing` folder within the project directory.

---

###Requirements

- Download the *ZIP folder* of this repository or *clone* it  
- Make sure **.NET 9.0 SDK** is installed on your system  
  👉 [Download it here](https://dotnet.microsoft.com/en-us/download)

---

###Setup Instructions

1. **Extract** the ZIP folder / clone anywhere on your computer.  
2. **Open** the project in the IDE (Rider, VS, etc).  
3.(**Only in Rider**) => The tests should automatically appear in the **Tests** window.  

If the tests don’t appear automatically or you are using a different IDE, open a terminal in the project folder and run:

```bash
dotnet clean
dotnet restore
dotnet build
```

After building successfully, run:

```bash
dotnet test
```
Resualt of the tests should appear like this =>
`x tests successful`, `x tests failed`, etc.

---

###Refreshing the Test Window in JetBrains Rider

If the tests still don’t appea in Rider:

1. In the top-left menu of Rider, go to **Tests**.  
2. In the last section of the dropdown menu, select **“Refresh Unit Test Tree.”**  
3. The tests should now appear in the Tests window and can be run directly from there.

---

###Troubleshooting

If you encounter build or version issues:

- Make sure the **.NET 9.0 SDK** is correctly installed and up to date.  
- Rebuild the project:

```bash
dotnet build
```

Then try running the tests again:

```bash
dotnet test
```
