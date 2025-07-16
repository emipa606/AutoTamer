# Copilot Instructions for RimWorld Modding Project: AutoTame

## Mod Overview and Purpose

The "AutoTame" mod for RimWorld is designed to automate the taming and training of animals. Developed in C#, the mod streamlines an otherwise manual aspect of gameplay, allowing players to focus on other strategic elements. By integrating seamlessly with existing game mechanics, this mod enhances the player's experience by providing a more efficient way to manage animal husbandry.

## Key Features and Systems

- **Automated Taming:** Animals can be set to automatically tame themselves when certain conditions are met, removing the need for constant player intervention.
- **Training Management:** Once tame, animals continue to train towards various tasks automatically, optimizing your colony's workforce.
- **Dynamic Graphics:** The mod includes functionality to dynamically change animal graphics, reflecting their trained or tame status in-game.
- **Gameplay Integrity:** The design carefully ensures that the automation does not disrupt the balance of the game, maintaining a fair challenge.

## Coding Patterns and Conventions

- **Class Naming:** Follow a clear and consistent pattern for class naming. For example, `AutoTameMod` for mod initialization, `AutoTameSettings` for settings management, etc.
- **Method Naming:** Use verbs for method names to clearly indicate functionality, such as `SetGraphic`, `TryChangeGraphic`, and `PreventsUntaming`.
- **Access Modifiers:** Use `internal` for mod-specific classes and `public` for classes that need broader accessibility. Methods should match the intended scope of use.
- **Consistent Indentation and Bracing:** Stick to a C# standard of four spaces for indentation and use braces `{}` for every block, even if it contains a single statement.

## XML Integration

The mod's XML files should maintain compatibility with RimWorld's def system. Define XML files for custom comp properties (`CompProperties_AutoTameTrain`) that attach to in-game elements. It’s critical to ensure that XML files align with RimWorld's schema to avoid runtime errors.

## Harmony Patching

- **Usage:** The mod uses Harmony library to patch existing game methods, allowing for the seamless integration of new features without modifying vanilla game files.
- **Patch Classes:** The `TrainingTrackerTickRare_Patch` is a practical example, targeting infrequent training ticks to hook into the taming process.
- **Best Practices:** Use Harmony’s annotation system (`[HarmonyPatch]`) to specify target methods cleanly and efficiently. Always implement robust exception handling around patches to maintain game stability.

## Suggestions for Copilot

1. **Class and Method Prediction:** Use Copilot to generate repetitive patterns, such as boilerplate code for new mods, preserving the class and method naming conventions.
2. **XML Definition Templates:** Employ Copilot to assist in writing repetitive XML structures or discovering common mistakes in def XML files by suggesting improvements.
3. **Refactor Suggestions:** Identify and optimize loops or conditionals within methods like `TryChangeGraphic` to enhance code efficiency.
4. **Patch Targeting:** Help with writing Harmony patches by suggesting methods that can be overridden or augmented, especially those not immediately obvious.
5. **Exception Handling:** Ensure all patched methods include Copilot-recommended exception handling for better debugging and game stability.

By following these outlined practices and leveraging GitHub Copilot effectively, team members can maintain a high standard of code quality and mod performance akin to professional game development standards.
