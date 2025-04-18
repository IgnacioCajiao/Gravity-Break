# Gravity-Break
Use gravity inversion to navigate the level, collect oxygen tanks to survive, activate the switch to open the exit portal, and escape.
 
## Controls
- **A** and **D**: Move left and right.
- **Space**: Inverts gravity.

---

# Design Rationale and Gameplay Impact: Assignment #2: Event-Driven System Implementation

## System Design 
The game includes three key systems: oxygen depletion, gravity inversion, and switches triggering portals. The oxygen meter and oxygen pick-ups make it so the player has to move through the level quickly, which adds difficulty. The gravity inversion mechanic adds a unique way to navigate the level and adds challenge to movement, and the switch system provides an objective and requirement to finish the level.

## Event Flow
When the player comes into contact with the oxygen tanks it increases the players oxygen level to full, and then continues to slowly run out until you pick up another one. And when the player comes into contact with the lever it switches up and opens the exit portal at the end of the level.

## Events and Responsiveness
Each of the events in the level provides immediate feedback and has a clear purpose, enhancing the responsiveness and engagement of the game. The event in the game can be reused and can enable many new level layouts and puzzles involving switch locations and oxygen locations to make more difficult or fun levels.

## Challenges and Solutions
I had some small issues making the tilemap and sprite sheet for the ground blocks because the asset pack just had separate PNGs. I also had an issue when flipping the player sprite to match the gravity flip, because rotating the sprite caused the player to flip into the ground. To fix this, I made the player move +1 on the y-axis or –1 on the y-axis at the same time as rotating so the player flips but stays in the same place. Aside from that, I didn’t have any other major issues, as I have made many other 2D platformers in this course that I could go back and refer to.

---

# Design Rationale and Gameplay Impact: Assignment #3: AI System Implementation

## How AI behaviors influence player strategy and decision-making
So the AI I added to the game is a slime looking alien that patrols platforms waiting for the player to land there so it can steal their oxygen, by sticking to the player and sucking on their oxygen tank. This leads to the players oxygen tank running out faster. So if the player lands on this platform and gets attacked by the alien you essentially have to speed run the rest of the level if you want to survive. So, it still give the player a chance but, makes it harder to complete the level. In this game since you have the ability to control gravity seeing a platform with one of these alien, will either make the player take the chance and go on the platform possibly avoiding it, or they are confident enough to speed run the level, that they don't care. The player could also find an alternate route under or around the platform depending on how skillfull and creative they are with the ability to control gravity.

## How player actions dynamically alter AI states and responses
The alien AI patrols platforms waiting for the player to land on them. If the players lands on the platform the alien will hear them and start to chase them, increasing in speed, from its patrol state. If the player leaves the platform the alien will go back into patrol state. If the player is chased by the alien and caught the alien will attach itself to the players oxygen tank and consume its oxygen, leading to a higher oxygen depletion rate for the player, causing the player to have to reach the next oxygen tank faster if they want to live.

## Challenges faced during implementation and their solutions
This AI ended up being way harder than I thought due to making sure all the states transitioned properly and making sure the none of the states conflicted with each other and when they happened. The coding just turned into a big puzzle of variables and flags that took a bunch of trial and error, but eventually with making sure I had variable for the states and making sure the flags and calls were in the right places I finally got everything to work. Aside from that I had of bunch of weird collider issue when adding the enemy AI, I think due to where the patrol point where, and where the players transform was, when the enemy would move it would sometimes move into the ground, I fixed this by just enabling the rigidbody y axis constraint, as an easy fix. Some other small things like weird error that I think are from me not having that much experience using tilemaps and tilecolliders, also me not really knowing how unity 6 works that well, and the new API contantly reminding me to use linearVelocity now.
