# GitHub Copilot Instructions for Auto Tamer (Continued) Mod

## Mod Overview and Purpose

Auto Tamer (Continued) is an update and continuation of Halituis Amaricanous' original Auto Tamer mod. The primary purpose of this mod is to introduce an advanced Spacer machine that automatically keeps your colony's animals tame and trains them. This machine can be built by researching Ground Penetrating Scanner, Vitals Monitors, and Fabrication. The objective of the machine is to free up your colony's pawns from the time-consuming task of animal upkeep, allowing them to focus on more important tasks.

## Key Features and Systems

The Auto Tamer (Continued) mod has two main toggles:

1. **Auto Tame**: Keeps all tamed animals within the machine's radius tame for as long as it has power. This feature is beneficial if you have a large number of animals and want to reduce the amount of time spent on animal upkeep.
2. **Auto Train**: Selects a random animal to train up. The machine can pick an available slot for the animal to be trained in. It should be noted that the machine only trains one animal at a time.

## Coding Patterns and Conventions

The Auto Tamer (Continued) mod follows a structured coding pattern that adheres to the conventions of RimWorld modding:

- **Namespaces and Classes**: All C# files are organized into namespaces and classes. For example, the `AutoTameMod` class is defined in the `AutoTame` namespace.
- **XML Defs**: XML files contain definitions for game objects and their properties. For example, the `AutoTamer.xml` file defines the properties of the Auto Tamer machine.
- **Harmony Patching**: The mod uses the Harmony patching framework to modify the behavior of RimWorld's core code. Harmony patches are defined in the C# files.

## XML Integration

The Auto Tamer (Continued) mod integrates XML definitions to define the properties of the Auto Tamer machine. These XML files are located in the `Defs` folder of the mod. Here are the key XML files:

- **AutoTamer.xml**: Defines the properties of the Auto Tamer machine, including its graphic, size, and construction requirements.
- **About.xml**: Provides information about the mod, such as its name, author, and description.
- **TranslationTemplate.xml**: Contains translation templates for the mod.

## Harmony Patching

The Auto Tamer (Continued) mod uses Harmony patching to modify the behavior of RimWorld's core code. Here are the key Harmony patches defined in the mod:

- **Pawn_TrainingTracker_TrainingTrackerTickRare.cs**: Contains a transpiler patch that modifies the behavior of the `TrainingTrackerTickRare` method in the `Pawn_TrainingTracker` class.

## Suggestions for Copilot

When using GitHub Copilot with the Auto Tamer (Continued) mod, consider the following suggestions:

- **Familiarize yourself with the mod's codebase**: Before using Copilot, make sure you understand the mod's codebase, including the C# and XML files.
- **Use Copilot for code snippets**: Copilot can be a great tool for generating code snippets for new features or bug fixes. However, always review the generated code to ensure it fits the mod's coding conventions.
- **Use Copilot for XML defs**: Copilot can also generate XML definitions for new game objects. However, always review the generated XML to ensure it follows the mod's XML conventions.
- **Test thoroughly**: After using Copilot to generate code or XML, always test the mod thoroughly to ensure it works as intended.

## Conclusion

The Auto Tamer (Continued) mod is a useful tool for automating animal upkeep and training in RimWorld. By following the coding patterns and conventions used in the mod, and using GitHub Copilot to generate code snippets and XML defs, you can contribute to the continued development and success of the mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

