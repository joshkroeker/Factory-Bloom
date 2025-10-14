# 🌱 Factory Bloom – Unity Systems Engineering Demo

**Developer:** Joshua Kroeker  
**Engine:** Unity 6.2 
**Genre:** Top-Down Automation Sandbox  
**Art Style:** Pixel Art  
**Duration:** 1-Month Solo Project  

---

## 🎮 Overview
**Factory Bloom** is a one-month solo Unity project built to demonstrate gameplay **systems engineering** and **modular design**.  
The player automates an organic ecosystem—building machines that plant, harvest, and distribute resources in a self-sustaining loop.  

The project emphasizes **data-driven gameplay architecture**, **emergent system interactions**, and **clean, maintainable code**—all cornerstones of strong gameplay engineering.

---

## ⚙️ Technical Focus
At the core of *Factory Bloom* lies a fully modular automation framework composed of:

| System | Description |
|--------|--------------|
| **Machine Framework** | Base abstract class (`MachineBase`) powering specialized machines like *Seeder*, *Harvester*, *Conveyor*, and *Generator*. |
| **Network System** | Handles resource and energy propagation between connected machines using ports and signal graphs. |
| **Automation Controller** | Global tick-based update loop that synchronizes deterministic simulation across all systems. |
| **World Grid** | Logical tilemap storing resource nodes, machine placements, and environment data. |
| **Editor Tools** | Custom ScriptableObject utilities for defining machine types and visualizing resource flow. |

---

## 🧠 Engineering Highlights
- **🧩 Data-Driven Architecture** – Machines, resources, and terrain types defined through ScriptableObjects for flexible tuning.  
- **🔌 Event-Based Networks** – Real-time resource propagation with visual debugging using Unity Gizmos.  
- **⏱️ Deterministic Simulation** – Central tick controller ensures predictable, step-based updates.  
- **🚀 Scalable Foundations** – Architecture supports procedural generation, drone AI, and tech-tree expansion as modular add-ons.  

---

## 🗺️ System Architecture
The following diagrams summarize the technical structure and runtime data flow:

### 📘 [Download the Full Technical Systems Brief (PDF)](sandbox:/mnt/data/factory_bloom_technical_brief.pdf)

**System Architecture Diagram**
![Systems Architecture](sandbox:/mnt/data/factory_bloom_systems_architecture.png)

**Internal Tick Data Flow**
![Tick Data Flow](sandbox:/mnt/data/factory_bloom_tick_flow.png)

---

## 🧩 Project Goals
- Demonstrate gameplay engineering and systems composition.  
- Showcase maintainable Unity C# architecture for portfolio/recruiter review.  
- Highlight modular design suitable for both technical interviews and production workflows.  

---

## 📂 Repository Structure (Suggested)
