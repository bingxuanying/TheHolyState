# Game Basic Information #

## Summary ##

The holy state is an RTS game. In the game, you need to gather resources, build more units, and defeat your enemies. It is hard to defeat your enemies at the start of the game, so you need to carefully calculate the resources and the time you need to build your strongest army and destroy all of the resources your enemies. There are two races you can choose: Goblin and Ghosts. The Goblins can use resources to build single strong element allies. The ghosts can auto-build relatively weak soldiers, but for free. The ghosts also have slime allies, which can jump into the water and pollute it. In polluted water, one slime can be split into two slimes.

## Gameplay explanation ##

The Holy State is an RTS strategy video game. The game focuses on battle between Goblin and Ghost. The map is very big and is divided into three areas – desert in the middle, plain as second circle, and forest as periphery. There are two boss palaces on the desert. Once one side kill the boss, its army and units will be buffed. 

If the player plays on Goblin side, he/she requires to use Goblins to gather resources, woods and water, to produce more units. The player can use the building, Knight Status, to create more Goblins; or he/she can use pool, fire camp, rock, or Ceramic Bottles along with the Priest Status to create Water Spirit, Fire Spirit, Earth Spirit, or Wind Spirit. Goblin side produces unit slowly, but these units are relatively stronger than ghost side unit. Goblin is considered as melee, is able to gather resources, and is able to purify the polluted water. Element spirits are all rangers. Fire spirit moves very fast and deals moderate damage. Water Spirit has moderate speed but has fast attacking speed. Earth Spirit have large amount of HP but moves very slow and deals minor damage. Wind Spirit deal large amount of damage but is very weak.

If the player plays on Ghost side, he/she does not need to actually gather the resource. Once the player click the slime and have it jumps into the clear water, the water will be polluted and now the player can use the polluted water to create more slimes by simply have his/her slimes jump into the polluted water; having one slime jump into polluted water will automatically create two after several seconds. Also, the player can use the skeleton soldier to lay down the plants and build graves. The grave will automatically produce one of skeleton family members, including skeleton warrior, skeleton wizard, and skeleton soldier. Whenever a Goblin dies, there is chance for Ghost side to produce a ghost from grave instantaneously. The Ghost does long-range attack. So does the skeleton wizard. Slime is the unit that can produce large amount in a short time, but it is relatively weak and deal small amount of damage.

The player will earn victory when he/she kills all the enemy and destroys all enemy buildings. 

# Main Roles #

## User Interface

By pressing the tab key, the player can view current resource status in number and the number his/her units the player has. Also, there is a mini-map at the down-right corner for the player to check his position and know if there are enemy coming to him/her.

Clicking the correspondent buildings will enable the feature of producing units.


## Movement/Physics

*Pathfinding* - In this project, we put a lot of efforts into moving and physics. Since players only use the mouse to set the destination of the allies, we need a pathfinding algorithm to help allies find the right way to destination. First, we tried A* Algorithm; the algorithm works excellent. However, we could not find an easy way to generate a map for the algorithm. In the worst situation, we may even need to redraw the whole map. Luckily, we found a [repo](https://github.com/h8man/NavMeshPlus), which helps Unity’s NavMesh to work in a 2D environment. With some adjustments, we got an excellent pathfinding system. 

*Physics* - For the physics part, we put walls, water, and ground into separate tilemaps, which allowed us to build a collider for different tiles. The box collider worked great on the characters and buildings. 


## Animation and Visuals

All units have their walking, idle, attacking, and death animations. A unit walking on different direction will trigger different animations. There is also animation on clicking buttons; at the starting menu, when the mouse is on the “Start” label, the label will be enlarged.

Most of the animation, map tiles and units prefab comes from unity store.

The cover art are generated from https://www.pixilart.com/draw.

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

N/A

## Gameplay Testing

N/A

## Narrative Design

The background of the game is that one day there is a holy state suddenly appear at the middle of the Pacific Ocean. And there are two sides of creatures there trying to conquest the state. 
I have originally tried to design a game map with three layers. Each layer will have its entrances around and otherwise separated by walls. The Boss Palaces will be put at the middle of the map.

For the game mechanics, we want the unit to find its own shortest path when we select units and right click on other places on map. Therefore, we implement the algorithm, which are scripts in assets/NavMeshComponent folder.
As for the Arms System, we decided to have two different groups of soldier or unit. One is named Radiance and is consisted of Goblins and Element Spirits; the other one is named Die and is consisted of slime, skeleton army, and ghosts. Each side has both ranger and melee units.
In order to make the game more fun, each side will have different resource gathering systems and unit producing systems. I have explained this part at the Gamplay section. To implement them, there is a script allow the goblin to destroy the plant, or in another word, gather the wood; and there is another script to allow the Dire side automatically generate units.
We have also implemented AI system to allow the user fight against computer. However, the AI is pretty dumb. We ultimately want to make it a person-versus-person game, but that would take too much time. Since there are only two of us in this group, we don’t really have time to get that part down.

## Press Kit and Trailer

We made a short trailer using Premiere. The background music comes from Japan anime “JoJo's Bizarre Adventure”. We tried to show the core gameplay in the trailer by arranging a short and simple story in the trailer. For the press kit, we create a flyer using Photoshop.


## Game Feel

N/A
