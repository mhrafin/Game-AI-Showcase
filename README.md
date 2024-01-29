# Game-AI-Showcase

This project aims to create a platform where students and researchers can explore various Artificial Intelligence techniques used in games within simple environments. Some of the most commonly used AI techniques in gaming include the A* Algorithm, Autonomous Agents, and Crowd Simulation.

## A* Algorithm

The A* (A-Star) algorithm, invented by computer scientists Nils Nilsson, Peter Hart, and Bertram Raphael in 1968, was developed for a navigation system for the Shakey robot research project at Stanford. Initially, they worked on two algorithms, A1 and A2, eventually finding A2 to be more optimal and renaming it A*. This algorithm is widely used in AI for games, particularly for planning actions and determining the best path through an environment.

The essence of the A* algorithm is its intuitive nature, resembling human thought processes in pathfinding. It involves considering multiple paths and selecting the one that appears most efficient based on certain criteria. The algorithm uses three key values: G (the movement cost from the starting point to a given square), H (the estimated cost to move from that square to the final destination), and F (the sum of G and H). The algorithm aims to find the path with the lowest F value at each step, leading to the goal.

The process involves maintaining two lists: an open list of squares to be examined and a closed list of squares already examined. The A* algorithm avoids looking too far ahead, focusing only on the distances travelled and the estimated distance remaining. This efficiency makes it a popular choice in game development for pathfinding and navigation tasks.

## Autonomous Agents

Autonomously moving agents in games are AI-driven characters or entities that can act and make decisions without direct input from the player or a game designer. These agents are programmed to have a degree of independence, allowing them to interact with the game environment and other entities in a way that mimics real-world behaviour or logic.

Autonomously moving agents make decisions based on the game state, and their objectives, and sometimes learn from past experiences. They might choose to attack, flee, follow, explore, or perform any number of actions based on their programming and the situation.

Autonomously moving agents interact with both the game environment and the players.

## Crowd Simulation

In this section, the focus is on simulating crowd behaviour, which is distinct from individual behaviour. In crowds, properties like motion, collision, direction, and speed propagate from one person to another, giving the group its own identity. Simulating every individual in a crowd can be labour-intensive, so simpler methods using vector mathematics are often employed.

Different methods for simulating crowds include treating people as particles in a fluid and using real-world data. Crowds move in a quasi-organized fashion rather than chaotically, forming self-organizing systems with flow lines in the direction of movement. However, when crowd density exceeds six people per square meter, turbulence can occur.

One popular and simple method for simulating crowds is Reynolds' flocking algorithm, used in motion pictures to simulate animal herds and armies. This algorithm is based on three rules:
1. Turn towards the average heading of the group.
2. Move towards the average centre of the group.
3. Avoid close proximity to others.

## Future Scope

- **Advanced AI Implementations:** Future versions of the project could include more complex and advanced AI algorithms. This expansion would cater not only to beginners but also to intermediate and advanced learners.

- **Interactive AI Experiments:** Introducing features that allow users to interact with and modify AI parameters could significantly enhance the educational value of the project. This would enable users to experiment with AI behaviours and understand their impacts firsthand.

- **Optimization for Higher Performance:** Future work could focus on optimizing the code and algorithms for better performance, allowing for more complex simulations and a larger number of agents in the crowd system.

- **Cross-Platform Compatibility:** Making the project accessible on various platforms, including mobile devices, would increase its reach and usability.

- **Incorporating Educational Content:** Adding in-depth educational materials, such as tutorials, use case examples, and theoretical backgrounds of AI algorithms, would make the project a more comprehensive learning tool.

- **Real-Game Scenarios:** Integrating real-world game scenarios or partnering with game developers could provide practical examples of AI applications, bridging the gap between theory and practice.

- **Research Collaboration:** Collaborating with academic institutions or research groups could lead to the project being used as a research tool, contributing to the field of AI in gaming.
