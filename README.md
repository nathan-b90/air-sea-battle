Air sea battle – v0.1
Nathan Barrett 
2020

Unity 2019.1.8

_______________


Controls:
Up - aim 30 degrees
Down - aim 90 degrees
Space - fire missile
Return – pause/resume game

_______________


• The StartGame scene must be open to play, it initialises the game before being unloaded.

• Inspiration for the aesthetic of the game was taken from the Atari, Commodore 64 and old arcade games.

• The camera effect and mixing of the audio was designed to emulate this kind of low-fi, retro system. It’s also why I added a short loading screen between scenes. 

• All scripts are arranged into appropriate sub-folders/namespaces.

• There are two types of base classes which implement a singleton pattern: managers and utilities. Utilities grant the option of being persistent / scene agnostic.

• Game, Menu & UI managers belong to their own scenes. Game & UI are loaded additively and layered to prevent working on one big scene with ALL game stuff. 

• Config is fetched on start, makes repeated connection attempts up to a timeout value.

• GameScene enum prevents confusing build indexes when loading scenes. 

• Settings are implemented as scriptable objects, editable in the inspector to make customisation easy.

• PlaneSettings can be used to tweak plane quantity before pressing play, but speed can be adjusted in real time during gameplay (which I believe is what the spec called for).

• The game implements pooling for the missiles and explosion particle effect to prevent instantiation during gameplay.

• Pool is a type of Utility (so has singleton instance) and is generic – required pools inherit from it so is very versatile.

• GameManager handles the main game loop, timer and fires main event actions.

• UI manager listens for game events, updating score, time and pause/game over UI.
 
• Mover is a base class granting movement to an object in a certain direction at a certain speed - this is the base for the missile prefab and the plane spawner.

• PlayerInput handles all game input. Other scripts listen to input events to fire missiles or change sprites.

• Planes are created at the start of the game as children of the spawner, spaced to fit in an optimal space on screen.

• Planes are shuffled each wave to provide interesting configurations of enemies.

• The AudioController is where sounds are configured for use in game.

• A music source plays tracks, sounds are played using their own music source component to allow dynamic sound and overlapping.

_______________

Third party stuff

• All additional audio - Freesound.org

• Used Audacity for a bit of sound editing

• Fonts ‘Commodore Pixelized v1.2’ and ‘8-bit-pusab’ - DaFont

• Used pixelart.com to make flag assets

• Camera effect shader from ShaderToy (shadertoy.com/view/Ms23DR) 

_______________

Estimated hours total: 40-45
