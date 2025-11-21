# Relay Owl

**Relay-Owl** is a lightweight hotel inter-department ticketing system that allows staff to quickly report issues (tickets) to the relevant department.  
Think of it as a **magical workflow system** inspired by hotel operations and Harry Potter’s owl post for task delivery.

---

## Features

- **Ticket Creation**: Staff can create tickets with title, description, location, and priority.  
- **Department Routing**: Tickets are automatically routed to the correct department.  
- **Ticket Status Tracking**: Department staff can update status: `New → In Progress → Completed`.  
- **Comments**: Staff and department personnel can leave simple comments.  
- **Role-Based Access**: Staff and department staff have different views.  
- **Locations & Departments**: Predefined locations and departments for easy assignment.  

---

## Tech Stack
- Backend: **.NET Core WebAPI**  
- Database: **PostgreSQL**  
- Frontend: **React.js**  

---
## Setup Instructions (Development)
### 1. Clone the repo
```bash
git clone https://github.com/natsudotmv/relay-owl.git
cd relay-owl
```
### 2. Backend Setup
- Ensure .NET 8 SDK is installed
- Install dependencies and build solution
```bash
cd relayowl-back-end/src
dotnet restore
dotnet build
```
- Configure PostgreSQL connection in RelayOwl.Api/appsettings.Development.json
- Apply EF migrations:
```bash
dotnet ef database update --project RelayOwl.Infrastructure --startup-project RelayOwl.Api
```
- Run API
```bash
dotnet run --project RelayOwl.Api
```
### 3. Frontend Setup
- Ensure Node.js 20+ is installed
```bash
cd front-end/relayowl-react-app
npm install
npm run dev
```
- The app will run at http://localhost:5173 (Vite default)

### 4. Seed Data
- Use scripts/seed-defaults.sh to create initial departments, locations, and users.

---

## Usage
- Login with seeded staff accounts
- Create a ticket and assign a department
- Department staff can view tickets, update status, and add comments
- Monitor tickets in real-time on the dashboard