# No Utility Networks

**No Utility Networks** is a Cities: Skylines mod that removes the requirement for water pipes and power lines while preserving the game's original utility simulation.

Instead of building extensive utility networks, buildings receive virtual access to water, sewage and electricity. The game's production, storage, budgets and service mechanics remain fully functional, allowing players to focus on city design without sacrificing gameplay balance.

For players who own the **Snowfall** expansion, the mod also offers optional temperature-dependent utility simulation, increasing water and electricity demand during hot weather for a more realistic city simulation.

---

## Features

- Removes the need for water pipes
- Removes the need for power lines
- Preserves the vanilla water, sewage and electricity simulation
- Water production and power generation continue to operate normally
- Utility budgets continue to affect service capacity
- Optional temperature-dependent water consumption (Snowfall)
- Optional temperature-dependent electricity demand (Snowfall)
- Individual settings can be configured in the Options menu
- Compatible with existing save games

---

## How It Works

No Utility Networks uses **Harmony** to patch the game's utility availability checks.

Instead of requiring physical water pipes or power lines, buildings receive virtual utility connections while the original utility managers continue to handle production, storage and distribution.

This approach keeps the vanilla simulation intact while eliminating the need to manually build utility networks across the map.

The mod does **not** generate free resources or replace the game's simulation. Instead, it removes only the network dependency and allows the original game systems to continue operating as intended.

---

## Temperature Simulation

When the **Snowfall** expansion is installed, the mod can optionally adjust utility demand based on the current outdoor temperature.

Current features include:

- Increased water consumption during hot weather
- Increased electricity demand during hot weather
- Individual options to enable or disable each simulation
- Automatic fallback to vanilla behaviour when Snowfall is not available

---

## Technical Details

- Built for **Cities: Skylines (1)**
- Written in **C#**
- Uses **Harmony** for runtime patching
- Preserves the game's original utility managers
- Lightweight implementation
- Compatible with existing save games
- Designed for maximum compatibility with other mods

---

## Inspiration

This project was inspired by the community mods:

- **Remove Need for Pipes**  (Creator: Overhatted)
- **Remove Need for Power Lines**  (Creator: Overhatted)

No Utility Networks combines both concepts into a single maintained project while modernizing the implementation and introducing new features such as configurable temperature-dependent utility simulation, an integrated options menu and ongoing compatibility updates.

---

## License

This project is licensed under the **MIT License**.
