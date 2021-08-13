# WebProject

A website for doctor consultations and appointments.  :calendar:

:dart:  My project for the ASP.NET Core course at SoftUni. (August 2021) 

### URL: https://medexproject.azurewebsites.net/

## :information_source: How It Works

- Guest visitors: 
  - browse all available doctors;
  - apply as a doctor or register as a patient;
  - read doctor profiles.
- Logged Users:
  - same as guest;
  - can apply as a doctor or register as a patient.
- Doctor (user role):
  - confirms/declines patients' appointments; 
  - edits their profile.
- Patient (user role):
  - can cancel appointments;
  - makes appointments with doctors;
  - makes online consultations with doctors;
  - rates doctors after appointments;
  - edits their profile.
- Admin:
  - creates/deletes towns and specializations; 
  - can review client feedback;
  - can validate applied doctors.

## :hammer_and_pick: Built With

- ASP.NET Core 5
- Entity Framework (EF) Core 5
- Microsoft SQL Server Express
- ASP.NET Identity System
- MVC Areas with Multiple Layouts
- View Components
- Repository Pattern
- Auto Мapping
- Dependency Injection
- Sorting, Filtering, and Paging with EF Core
- Data Validation, both Client-side and Server-side
- Data Validation in the Models and Input View Models
- Custom Validation Attributes
- Responsive Design
- Bootstrap
- XUnit
- SignalR
- jQuery

## :gear: Application Configurations

### 1. The Connection string 
is in `appsettings.json`. If you don't use SQLEXPRESS, you should replace `Server=.\\SQLEXPRESS;` with `Server=.;`

### 2. Database Migrations 
would be applied when you run the application, since the `ASPNETCORE-ENVIRONMENT` is set to `Development`. If you change it, you should apply the migrations yourself.

### 3. Seeding sample data
would happen once you run the application, including Test Accounts:
  - User: user@user.com / password: 12345678
  - Patient: patient@patient.com / password: 12345678
  - Doctor: doctor@doctor.com / password: 12345678
  - Admin: admin@admin.com / password: 12345678
 
 
## :camera: Screenshots

### All doctors
<img src="https://github.com/kostadinM29/WebProject/blob/main/images/all-doctors.png"/>

### Doctor appointments
<img src="https://github.com/kostadinM29/WebProject/blob/main/images/doctor-appointments.png"/>

### Doctor profile
<img src="https://github.com/kostadinM29/WebProject/blob/main/images/doctor-profile.png"/>

### Patient appointments
<img src="https://github.com/kostadinM29/WebProject/blob/main/images/patient-appointments.png"/>

### Admin panel for verifying doctors
<img src="https://github.com/kostadinM29/WebProject/blob/main/images/applied-doctors.png"/>