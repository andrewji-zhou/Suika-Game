# Suika Game

Created March 2024, now migrating it to GitHub and polishing it up

A clone of the Suika (watermelon) merge game, built in Unity 2D.

Drop fruit into the container. When two of the same fruit touch, they merge into the next one up — Cherry → Grape → Strawberry → Orange → Apple → Peach → Pineapple → Melon → Watermelon.

## Controls

- **Mouse** – move the dropper
- **Space** – drop the fruit

## Run it

1. Install Unity **2021.3.24f1** (via Unity Hub).
2. Clone this repo and open the folder as a project in Unity Hub.
3. Open the scene in `Assets/Scenes` and press Play.

## Project layout

- `Assets/Input/FollowMouse.cs` – dropper movement, fruit spawning and merge spawning
- `Assets/Input/Fruitcon.cs` – per-fruit behavior (drop, collision/merge)
- `Assets/Fruits/` – fruit sprites and prefabs

## Status

Prototype. Known issues and planned work: score, game over, next-fruit preview.
