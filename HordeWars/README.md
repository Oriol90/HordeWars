# HordeWars Project Documentation

## Overview
HordeWars is a game project that features units that can move, attack, and interact with enemies. Each unit has a health bar that visually represents its current health status.

## File Structure
The project contains the following key files and directories:

- **Assets/**
  - **Scripts/**
    - **Units/**
      - `Unit.cs`: This file defines the `Unit` class, which represents a unit in the game. It includes properties such as `speed`, `attackRange`, `attackCooldown`, `damage`, `detectionRadius`, `maxHealth`, and `healthBarPrefab`. The class contains methods for initializing the unit, updating its state, moving towards an enemy, attacking, taking damage, and finding the closest enemy. It also manages the unit's health bar.
  - **Prefabs/**
    - `HealthBarPrefab.prefab`: This prefab represents the health bar that will be displayed for each unit in the game.

- **ProjectSettings/**: This directory contains project configuration settings.

- **Packages/**: This directory contains the packages used in the project.

## Features
- Units can detect and move towards enemies within a specified detection radius.
- Each unit has a health bar that updates based on the unit's current health.
- Units can attack enemies when they are within range.
- The project includes a simple health management system for units.

## Getting Started
To run the project, open it in a compatible game engine and ensure all necessary packages are installed. You can modify unit properties in the `Unit.cs` file to customize gameplay.

## Future Improvements
- Implement additional unit types with unique abilities.
- Enhance the enemy AI for more challenging gameplay.
- Add visual and audio effects for attacks and damage.

## License
This project is licensed under the MIT License.