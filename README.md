# **Clinic App**

A Clinic Management Application built with .NET and C#. The app provides a web interface for managing patients and their assigned doctors. It is built using Visual Studio, utilizes NuGet packages such as Microsoft SQL Server, and runs locally on your machine.

## **Features**

- Add, edit, view, and delete patient records
- Assign doctors to patients
- Simple web UI for management

## **Tech Stack**

- **Backend:** .NET, C#
- **Database:** Microsoft SQL Server (via NuGet package)
- **Frontend:** HTML, CSS, JavaScript
- **IDE:** Visual Studio

## **Getting Started**

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Simranjeet-12828/Simranjeet_Kaur_ClinicApp.git
   ```

2. **Open in Visual Studio.**

3. **Restore NuGet packages.**
   Visual Studio should automatically restore all required packages.

4. **Configure the database connection:**  
   Update your connection string in `appsettings.json` if needed.

5. **Run the application:**  
   Press `F5` or click `Start` in Visual Studio. The app will launch and open up on `localhost`.

## **Usage**

- The main interface allows you to:
  - View all patients
  - Add new patients
  - Edit patient details
  - Delete patients

## **Notes**

- **Appointments:** This version of the app does not currently manage appointments. It focuses on patient and doctor management.
- **Localhost:** The app runs locally; make sure your SQL Server is running and accessible.

## **License**

This project is open source and available under the [MIT License](LICENSE).
