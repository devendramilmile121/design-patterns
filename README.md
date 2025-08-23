# 🏥 Design Patterns in C# – Healthcare Scenarios

This repository demonstrates **Design Patterns in C#** using real-world **healthcare scenarios**.  
It is organized into the three main categories of design patterns: **Creational**, **Structural**, and **Behavioral**.

Each pattern includes:  
- 📖 **Definition** (short and crisp)  
- 💡 **Healthcare Example Scenario**  
- 🔗 **Link to Example (coming soon)**  

---

## 📌 Table of Contents

- [Creational Patterns](#creational-patterns)  
  - [Singleton](#singleton)  
  - [Factory Method](#factory-method)  
  - [Abstract Factory](#abstract-factory)  
  - [Builder](#builder)  
- [Structural Patterns](#structural-patterns)  
  - [Adapter](#adapter)  
  - [Decorator](#decorator)  
  - [Facade](#facade)  
  - [Proxy](#proxy)  
- [Behavioral Patterns](#behavioral-patterns)  
  - [Observer](#observer)  
  - [Strategy](#strategy)  
  - [Command](#command)  
  - [Chain of Responsibility](#chain-of-responsibility)  

---

## Creational Patterns

### 🔹 Singleton
**Definition:** Ensures a class has only one instance and provides a global point of access to it.  
**Healthcare Example:** A **Hospital Configuration Manager** that provides global access to system settings (e.g., bed capacity, visiting hours).  
🔗 Example: [Singleton Example](examples/creational/singleton)

---

### 🔹 Factory Method
**Definition:** Defines an interface for creating an object but lets subclasses decide which class to instantiate.  
**Healthcare Example:** A **Medical Report Factory** that creates different types of reports (Blood Test, X-Ray, MRI).  
🔗 Example: [Factory Method Example](examples/creational/factory-method)

---

### 🔹 Abstract Factory
**Definition:** Provides an interface for creating families of related or dependent objects without specifying their concrete classes.  
**Healthcare Example:** A **Medical Staff Factory** that creates related objects: Doctor + Nurse team for **Cardiology**, another for **Orthopedics**.  
🔗 Example: [Abstract Factory Example](examples/creational/abstract-factory)

---

### 🔹 Builder
**Definition:** Separates the construction of a complex object from its representation.  
**Healthcare Example:** A **Patient Admission Builder** that step-by-step builds a full admission record (patient details, insurance, assigned doctor, room).  
🔗 Example: [Builder Example](examples/creational/builder)

---

## Structural Patterns

### 🔹 Adapter
**Definition:** Allows incompatible interfaces to work together.  
**Healthcare Example:** An **Adapter** between a hospital’s **Electronic Medical Records (EMR)** system and an **external laboratory system**.  
🔗 Example: [Adapter Example](examples/structural/adapter)

---

### 🔹 Decorator
**Definition:** Dynamically adds new responsibilities to an object.  
**Healthcare Example:** Adding **insurance validation** or **priority handling** dynamically to a **Patient Billing Process**.  
🔗 Example: [Decorator Example](examples/structural/decorator)

---

### 🔹 Facade
**Definition:** Provides a simplified interface to a complex subsystem.  
**Healthcare Example:** A **Hospital Management Facade** that provides one simple API (`AdmitPatient`) but internally calls admission, billing, room allocation, and doctor assignment.  
🔗 Example: [Facade Example](examples/structural/facade)

---

### 🔹 Proxy
**Definition:** Provides a surrogate or placeholder for another object to control access.  
**Healthcare Example:** A **Medical Record Proxy** that ensures only **authorized doctors/nurses** can access sensitive patient data.  
🔗 Example: [Proxy Example](examples/structural/proxy)

---

## Behavioral Patterns

### 🔹 Observer
**Definition:** Defines a one-to-many dependency between objects so that when one object changes state, all dependents are notified automatically.  
**Healthcare Example:** When a **Doctor updates treatment**, notify **Pharmacy**, **Nursing Station**, and **Billing**.  
🔗 Example: [Observer Example](examples/behavioral/observer)

---

### 🔹 Strategy
**Definition:** Defines a family of algorithms, encapsulates each one, and makes them interchangeable.  
**Healthcare Example:** Different **Billing Strategies** (Cash Payment, Insurance, Government Scheme) applied dynamically for a patient.  
🔗 Example: [Strategy Example](examples/behavioral/strategy)

---

### 🔹 Command
**Definition:** Encapsulates a request as an object, allowing parameterization of clients with different requests, queuing or logging, and support for undoable operations.  
**Healthcare Example:** **Prescribe Medicine** / **Schedule Surgery** commands with **Undo/Redo** support on patient records.  
🔗 Example: [Command Example](examples/behavioral/command)

---

### 🔹 Chain of Responsibility
**Definition:** Passes a request along a chain of handlers until one handles it, reducing coupling between sender and receiver.  
**Healthcare Example:** A **Patient Discharge Request** flows through **Doctor → Billing → Pharmacy → Reception** until all approvals are complete.  
🔗 Example: [Chain of Responsibility Example](examples/behavioral/chain-of-responsibility)

---

## 🚀 Goal of This Repository
- Make **Design Patterns easy to understand** with **real hospital workflows**.  
- Provide **clean C# examples** for interview prep & practical learning.  
- Serve as a **go-to resource** for developers who want to learn patterns in a **real-world context**.  
