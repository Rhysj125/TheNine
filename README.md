# The Nine
A first person shooter rougelike game developed using Unity Game Engine

# Map Generation
The map is generated using a 2 dimensional array to represent the area as a grid.<br>
The centre of the grid is used as the "Seed" for the map. The map starts from this centre point and generates outwards.<br>
Every adjacent cell is checked against a random number generation. If that cell passes the random number check, a tile will be spawned in that location, connected to the previously checked cell. Any unchecked adjacent cells are then added to a queue to be checked. If the cell failed the random number check, it will spawn a walled tile and the tiles adjacent to that are not added to the queue.
