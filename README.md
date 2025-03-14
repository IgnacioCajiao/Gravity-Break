# Gravity-Break
Use gravity inversion to navigate the level, collect oxygen tanks to survive, activate the switch to open the exit portal, and escape.
 
## Controls
- **A** and **D**: Move left and right.
- **Space**: Inverts gravity.

# Design Rationale and Gameplay Impact

## System Design 
The game includes three key systems: oxygen depletion, gravity inversion, and switches triggering portals. The oxygen meter and oxygen pick-ups make it so the player has to move through the level quickly, which adds difficulty. The gravity inversion mechanic adds a unique way to navigate the level and adds challenge to movement, and the switch system provides an objective and requirement to finish the level.

## Event Flow
When the player comes into contact with the oxygen tanks it increases the players oxygen level to full, and then continues to slowly run out until you pick up another one. And when the player comes into contact with the lever it switches up and opens the exit portal at the end of the level.

## Events and Responsiveness
Each of the events in the level provides immediate feedback and has a clear purpose, enhancing the responsiveness and engagement of the game. The event in the game can be reused and can enable many new level layouts and puzzles involving switch locations and oxygen locations to make more difficult or fun levels.

## Challenges and Solutions
I had some small issues making the tilemap and sprite sheet for the ground blocks because the asset pack just had separate PNGs. I also had an issue when flipping the player sprite to match the gravity flip, because rotating the sprite caused the player to flip into the ground. To fix this, I made the player move +1 on the y-axis or –1 on the y-axis at the same time as rotating so the player flips but stays in the same place. Aside from that, I didn’t have any other major issues, as I have made many other 2D platformers in this course that I could go back and refer to.
