Best Practices
- This project is supposed to show an example of certain best practices

Reduction Of Main Project Bloat
- To do this, simply make a new project, import whatever packages you need.
- Then place the prefabs and anything you need into a scene.
- Once thats all inside the scene, then just Right click the scene, and "Export Unity Package"
- Then close this project, and open the main project, and double click the UnityPackage you just created to import only the bits you need

Level Layers
- Incredibly simple way to reduce merge conflicts within a level. Basically you have one main level, where noone touches
- Sublevel A is added to the main level, but only member 1 of the team is allowed to work in that level, they would work on adding geometry as an example
- Sublevel B is added to the main level, but only member 2 of the team is allowed to work in that level, they would work on adding dynamic objects such as enemies etc.
The reason we use these, is that the Sublevel A and B will compose the full level withing the main level. This will mean 2 people can contribute to the final level
	simply by working in their scenes and not causing merge conflicts by working on the same scene.