# 🧠 ParityAI™

> The world's most advanced, LLM-powered, multi-agent, tool-augmented **even/odd detector** — because `% 2` is for amateurs.

---

## 📌 Project Overview

**ParityAI™** is a satirical enterprise-grade system that will determine if a number is even or odd using:

* 🔧 Multiple Parity Detection Strategies
* 🧠 Large Language Models (LLMs) with Tool Use
* 🗳️ Multi-agent Consensus & Chain-of-Thought Reasoning
* 🏗️ Clean Architecture + MediatR + Hangfire
* 🧪 Prompt A/B Testing & Prompt Compliance Agents

All intended to be built using .NET 8 and the **Ardalis Clean Architecture Template**.

> ⚠️ **Note:** This project is in its initial planning stage. Nothing is implemented yet — but we have big dreams and bigger abstractions.

---

## 🧱 Architectural Overview (Planned)

```
User Input
    ↓
LLM Agent (GPT-4o mini)
    ↓
Tool Selection & Reasoning (ReAct style)
    ↓
Parity Tools (e.g., Modulo, Bitwise, MLClassifier)
    ↓
Decision Justification + Optional Escalation
    ↓
Result (Even/Odd + Reason)
```

---

## 🎯 Features (Planned)

### 🤖 LLM-Powered Reasoning

* GPT-4o mini will choose one or more parity strategies
* Simulated reasoning using Chain-of-Thought
* Tool invocation via OpenAI Function Calling API
* Cross-check results from multiple tools

### 🛠️ Strategy Tooling

* `ModuloParityTool`: `% 2`
* `BitwiseParityTool`: `n & 1`
* `MLParityTool`: Pretend ML classifier
* Injectable and loosely coupled services

### 🗳️ Multi-Agent Simulation

* `ParityOrchestratorAgent`: Core planner
* `ParityRefereeAgent`: Disagreement resolver
* `PromptComplianceAgent`: Ensures prompt standards
* `FallbackAgent`: Escalates decisions

### 📚 Prompt A/B Testing

* Store and version multiple prompt templates
* Analyze LLM response confidence
* Use Hangfire to orchestrate test batches

### 🧰 Clean Architecture

* Application, Domain, Infrastructure layers
* MediatR for CQRS-style orchestration
* Hangfire for job queue and async tasks

---

## 🧪 Sample LLM Prompt (Future Example)

```
Input: 17
Thought: I want to determine if 17 is even or odd.
Action: Use ModuloParityTool(17)
Observation: 17 % 2 = 1 → ODD
Thought: Let me validate using BitwiseParityTool(17)
Observation: 17 & 1 = 1 → ODD
Final Answer: 17 is ODD
Confidence: 100%
```

---

## 🔍 Observability & DevOps (Planned)

* 📈 Prometheus metrics
* 📜 Serilog + Seq logs
* 📋 OpenTelemetry tracing
* 🐳 Dockerized setup

---

## 🧪 Testing (Planned)

* ✅ Unit tests for all tools
* 🔁 Prompt regression tests
* 🧠 Mocked LLM response simulations
* 🔄 Agent decision chain replay engine

---

## 🚀 Setup Instructions (Planned)

Implementation has not started yet. Setup instructions will be added once components exist.

---

## 🧠 Roadmap

| Feature                    | Status        |
| -------------------------- | ------------- |
| Clean Architecture         | 🚧 Planned    |
| LLM Tool Use               | 🚧 Planned    |
| Multi-Agent Reasoning      | 🚧 Planned    |
| Prompt A/B Testing         | 🚧 Planned    |
| MediatR + DI               | 🚧 Planned    |
| Hangfire Job Queue         | 🚧 Planned    |
| Observability + Tracing    | 🚧 Planned    |
| Compliance Agent           | 🚧 Planned    |

---

## 📄 License

MIT — but you're morally obligated to overengineer responsibly.
