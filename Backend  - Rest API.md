# Backend  - Rest API

- Uses SQLite database for its data source. 
- Has API endpoint to access following things -
    * ICU Configuration.
    * Patient Admission and Discharge.
    * Alert Monitoring.
- **ICU Configuration** has endpoints for following services : 
    * Get all ICUs (Layout and no. of Beds).
    * Get individual ICUs (Layout and no. of Beds).
    * Add ICU (Layout and no. of Beds).
    * Update ICU (Layout and no. of Beds).
    * Delete ICU.
    * Get all Layouts.
    * Add Beds to Layout.
- **ICU Occupancy Controller** has endpoints for following services :
    * Get individual or all Patients.
    * Get available beds in specific or all ICUs.
    * Add new Patient.
    * Remove Patient.
    * Get Patient Info.
- **Patient Monitoring Controller** has endpoints for following services : 
    * Get All Alerts from selected ICU.
    * Disable and undo disable alerts.
    * Remove Alerts of Discharged Patient.
- API lisens at https://localhost:5001/ and http://localhost:5000/, one port at a time.


#### Installation
- Install the .exe file.
- The API server application should have 'AlertToCare.db' database file in the same repository as the .exe. Paste the db file into directory if not present.
- Application runs on its own after that. 
