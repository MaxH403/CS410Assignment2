# CS410Assignment2
Maxwell Hermens - Dot Product and Linear Interpolation
Wilfred Lim - Particle and Sound Effects

Dot Product is utilized in an updated version of the observer C# script. Before the raycast operations are done, the script will now calculate the dot product between the direction to the player and the enemies forward direction to see if the player is inside the enemies FOV.

Linear Interpolation is utilized in an updated version of the WaypointPatrol C# Script. Now the ghosts will slow down when they are within a certain distance of the one of their waypoint markers. The Mathf.Lerp functions is used to calculate the speed of the ghost, while it smoothly transitions from minSpeed to originalSpeed.

A colorful particle effect and cheer sounds start playing once player reaches the hallway towards the exit.The way they are triggered is by using a new empty game object with a box collider.
