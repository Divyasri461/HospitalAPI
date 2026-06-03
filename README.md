**Hospital Management System**
Project Overview
This project is a RESTful backend API built using ASP.NET Core Web API, ADO.NET, and SQL Server to manage hospital operations such as patient registration, doctor profiles, and appointment booking.
The system ensures data integrity, validation, and structured operations using stored procedures and layered architecture.

**Tech Stack**
Backend: C# (.NET Core Web API)
Database: Microsoft SQL Server
Data Access: ADO.NET
API Testing: Postman
Version Control: Git & GitHub


**Features**
**🔹 Patient Management**

Register new patients with:

Patient Code (Unique)
Full Name
Date of Birth
Gender
Phone Number (Unique)
Email (Optional, Unique)


Update patient details
Soft delete (Deactivate patient)
Retrieve all active patients with calculated age


🔹 Doctor Management

**Store doctor details:**

Doctor Code (Unique)
Name
Specialization
Phone Number
Consultation Fee
Availability Status


Search doctors by:

Specialization
Availability




🔹 Appointment Management

Book appointment between patient and doctor
Prevent booking if doctor is unavailable
Appointment statuses:

Scheduled
Completed
Cancelled


Cancel scheduled appointments with timestamp
Retrieve:

Upcoming appointments
Doctor-specific appointments




🔹 Reporting

View appointment details:

Patient Name
Doctor Name
Specialization
Date
Status
Fee


Total appointments per doctor (>2 only)
Revenue grouped by specialization
Identify same patient-doctor same-day bookings
Filter appointments for next 7 days


⚙️ Technical Implementation
🔹 Database

All operations handled via Stored Procedures
Transactions used for appointment booking
Referential integrity enforced using Foreign Keys
Indexes added for:

Doctor
Appointment Date


Soft delete implemented for patients


🔹 API Design

RESTful endpoints
Proper HTTP status codes:

201 → Created
204 → No Content
400 → Bad Request
404 → Not Found
409 → Conflict
500 → Server Error




🔹 Application Architecture
Controller → Service Layer → Repository Layer → Database


Controllers: Handle HTTP requests
Services: Business logic
Repositories: Data access (ADO.NET)
DTOs: Data transfer between layers


🔹 Dependency Injection

All services injected via interfaces (IPatientService, IDoctorService, etc.)


🔹 Logging

Global request logging middleware:

HTTP Method
Request Path
Response Time




🔹 Exception Handling

Global exception handling middleware
Structured error responses
No internal details exposed to client


🧠 Domain Logic

Age calculation in domain model
Appointment validation:

No past dates
Valid statuses only


Custom exceptions for domain errors


📂 Project Structure
HospitalAPI/
│
├── Controllers/
├── Services/
├── Repositories/
├── Models/
├── DTOs/
├── Interfaces/
├── Middleware/
├── Data/
├── appsettings.json
└── Program.cs


🔌 Setup Instructions
✅ Prerequisites

.NET SDK
SQL Server
Visual Studio


✅ Steps to Run

Clone repository:

Shellgit clone https://github.com/your-username/HospitalAPI.gitShow more lines


Open project in Visual Studio


Update connection string in:


appsettings.json


Run SQL script:


Create database
Create tables
Create stored procedures


Run the project:

Shelldotnet runShow more lines

Test using Postman


📬 API Testing

Postman collection included
Covers all endpoints:

Patient
Doctor
Appointment
Reports




📄 Deliverables

✅ Fully working API
✅ Source code (GitHub)
✅ SQL scripts
✅ Postman collection
✅ Documentation (this file)


📌 Assumptions

Patient and doctor codes are unique
Appointment cannot be created in the past
Soft delete is used for patients
Stored procedures handle all DB operations


🚀 Future Improvements

Add authentication (JWT)
Add frontend UI
Email/SMS notifications
Pagination for large data


👩‍💻 Author
Divyasri Erla
Software Engineer - Trainee
