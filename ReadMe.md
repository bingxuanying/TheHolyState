# Game Basic Information #

## Summary ##

The holy state is an RTS game. In the game, you need to gather resources, build more units, and defeat your enemies. It is hard to defeat your enemies at the start of the game, so you need to carefully calculate the resources and the time you need to build your strongest army and destroy all of the resources your enemies. There are two races you can choose: Goblin and Ghosts. The Goblins can use resources to build single strong element allies. The ghosts can auto-build relatively weak soldiers, but for free. The ghosts also have slime allies, which can jump into the water and pollute it. In polluted water, one slime can be split into two slimes.

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this like a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

# Main Roles #

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics

*Pathfinding* - In this project, we put a lot of efforts into moving and physics. Since players only use the mouse to set the destination of the allies, we need a pathfinding algorithm to help allies find the right way to destination. First, we tried A* Algorithm; the algorithm works excellent. However, we could not find an easy way to generate a map for the algorithm. In the worst situation, we may even need to redraw the whole map. Luckily, we found a [repo](https://github.com/h8man/NavMeshPlus), which helps Unity’s NavMesh to work in a 2D environment. With some adjustments, we got an excellent pathfinding system. 

*Physics* - For the physics part, we put walls, water, and ground into separate tilemaps, which allowed us to build a collider for different tiles. The box collider worked great on the characters and buildings. 


## Animation and Visuals

**List your assets including their sources, and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

*Mouse Input* - Since the game is an RTS game, we chose the mouse and keyboard as the only available input devices. However, Unity does not have strong support for mouse operations like drag and drop. Even we used event system to implement the drag and drop operations, the event system did not have a bubble mechanism that allows other objects to receive events again, and only the first layer (usually camera) have the chance to receive listened events. Therefore, we used a lot of dirty hacks to reach our design target. One of the dirty hacks is polling mouse events in the update function and use Raycasting to determine the selected object. 

## Game Logic

*HP* – We implemented a general HP status bar on every character’s head. Some destroyable buildings also have an HP bar. The HP Bar also help to indicate the characters are your allies or enemies. 

*Attack* – We have two attack method: Melee attack and range attack. The attack controller exposes many settings like range, damage, attack speed, etc. These settings help us reuse the controller in different character prefabs. Melee attack also integrated with the moving controller to do the pathfinding. 

*Moving* – The moving controller works together with the NavMesh Agent. The moving controller can control the start and stop of pathfinding. It also provides a method to allow AI Enemy to use the pathfinding system.

*Selection* – We use the event system to handle the selection of units. The selection also supports range selection via drag and drop. 
AI Enemy – Currently, we implemented a simple, aggressive AI enemy that will find the nearest player’s unit and attack it. The AI Enemy also behaves differently on melee units and range units: range units will first try to walk near to the target then start to attack the unit. Melee units use pathfinding to tried to collide with the target, which triggers a melee attack.


# Sub-Roles

## Audio

**List your assets including their sources, and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**oDocument how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

We made a short trailer using Premiere. The background music comes from Japan anime “JoJo's Bizarre Adventure”. We tried to show the core gameplay in the trailer by arranging a short and simple story in the trailer. For the press kit, we create a flyer using Photoshop.


## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
