# HAERENGA
This repository is for a Haerenga, A final major project game made by [Paula Vales](https://www.linkedin.com/in/paula-vales-b26940338/) and [E-Jay Tripoli](https://www.linkedin.com/in/edver-tripoli-a1b24230a/). Visit us at [haerenga.site](https://haerenga.site/)

<p align="center">
  <img width="400" alt="Haerenga" src="https://github.com/user-attachments/assets/263c6f41-1c39-4fd7-8166-7b6a6528e2ae" />
</p>

<table align="center">
  <tr>
    <td><video height="260" controls src="https://github.com/user-attachments/assets/74cee781-8775-495e-950c-acade988e489"></video></td>
    <td><video height="260" controls src="https://github.com/user-attachments/assets/508c89c5-e5d6-47fd-a94a-72473610142d"></video></td>
  </tr>
</table>

## What it is
A 2D Precision-platformer with puzzle-based progression. Explore mysterious islands, master movement abilities, and chart constellations to guide your journey.

## My Contribution
### Movement System

- **Input layer:** `InputManager` wraps Unity's Input System and exposes clean per-frame values (move vector, jump pressed/held/released, dash, hook), so `PlayerController` never reads devices directly.
- **Physics-based running:** The player is a `Rigidbody2D`. Horizontal velocity is set directly from input in `FixedUpdate`, which gives tight, responsive control.
- **Reliable ground detection**
- **Game-feel jumping:**
  - Coyote time lets you jump shortly after walking off a ledge.
  - A jump buffer saves a jump pressed just before you land.
  - Releasing jump early cuts the jump short, so jump height depends on how long you hold the button.
  - A fall multiplier and a maximum fall speed control how fast you drop.
- **Wall cling and wall jump:** Box casts on each side detect walls. Pushing into a wall makes the player cling and drains stamina until the player slides off. A wall jump pushes the player away from the wall and briefly locks horizontal input so they can't steer straight back into it.
- **Dash:** A short, fixed-speed burst in the facing direction with a cooldown. Landing resets the cooldown.
- **Grappling hook:** Fires a ray in input direction after a short wind-up animation. If the ray hits a grapple point and no terrain is in the way, the player is pulled to it, with an animated rope drawn by a `LineRenderer`.
- **Ability progression:** Dash, grappling hook, double jump and the upgraded wall jump are unlocked through `PlayerManager`. Before the wall jump upgrade, wall jumps are weaker and you can only cling for a limited time; after it, jumps are stronger and clinging has no time limit.
- **Feedback:** Animator parameters, sprite flipping and randomised, pitch-varied footstep, jump, land and death sounds make movement feel responsive.

### Level Design

- **Environment interactions:** Bounce pads, sideways bouncers and bubble columns hook into the controller to launch the player.
- **Interaction introduction:** "Drip-fed" to the player as they become accustom to the games movement and its abilities.


### Tech
- Unity Version 6
- C#
- Git for Version Control
- Visual Studio
- Adobe Premiere Pro

### Inputs
- Keyboard and Mouse
- PlayStation Controllers

### Installing
The game can be installed [here](https://e-jayy.itch.io/haerenga)

### Executing the program
Once at the itch page, download and extract the zip file. Open the extracted folder and run the 'Haerenga' executable.
