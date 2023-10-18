using OpenQA.Selenium;
using ABSAAutomation.Hooks;
using ABSAAutomation.ABSAAutomation.ObjectRepo;
using ABSAAutomation.Utilities;
using ABSAAutomation.ABSAAutomation.PageObjects;
using Microsoft.Graph;
using System;

namespace ABSAAutomation.HealthOneAPI.AppSpecific
{
    class Appointments 
    {
        APIHelper api;
        DataHelpers dat;
        TestBase gsh;
  
        public Appointments()
        {
 
            dat = new DataHelpers();
            api = new APIHelper();
            gsh = new TestBase();
         
        }

        public void AppointmentsUpdateJsonFile(WorkbookRange rowValues, int cid, string sFilePath)
        {
            string sPerson = gsh.GetCellValue(rowValues, "person", cid);
            string startTime = gsh.GetCellValue(rowValues, "startTime", cid);
            string endTime = gsh.GetCellValue(rowValues, "endTime", cid);
            if (sPerson.ToUpper().Contains("random"))
                sPerson = dat.GenerateName(12).ToUpper() + " AUTO";

            string sCaption = gsh.GetCellValue(rowValues, "person", cid);
            if (sCaption.ToUpper().Contains("random"))
                sCaption = sPerson;

            string sEmail = gsh.GetCellValue(rowValues, "email", cid);
            string sCellularNo = gsh.GetCellValue(rowValues, "cellularNo", cid);
            string sIsNewPatient = gsh.GetCellValue(rowValues, "isNewPatient", cid);
            string sOrigin = gsh.GetCellValue(rowValues, "origin", cid);
            String sfieldJSONArray = "appointments";
            string sExternalId = "9b4c12e2 - d592 - 4dc4 - 9cfe - ceebe50" + dat.GenerateName(2) + dat.RandomDigits(2) + dat.GenerateName(1);
         
         
            string sStartDate = DateTime.Now.ToString("yyyy-MM-dd").ToString() + startTime;
            string sEndDate = DateTime.Now.ToString("yyyy-MM-dd").ToString() + endTime;

            string [] dataToUpdatewith = { sPerson, sCaption, sEmail, sIsNewPatient, sOrigin, sCellularNo, sExternalId, sStartDate, sEndDate };
            String[] dataToUpdate = { "person", "caption", "email", "isNewPatient", "origin", "cellularNo", "externalId", "startDateTime", "endDateTime" };
            api.UpdateJSONArray(sfieldJSONArray, dataToUpdate, dataToUpdatewith, sFilePath);
            var sDate =  DateTime.UtcNow.ToString("s") + "Z";
            string sAssignMcr = gsh.GetCellValue(rowValues, "assignMcr", cid);
            string sCrudType = gsh.GetCellValue(rowValues, "crudType", cid);



            string[] dataToUpdatewith2 = {sDate,sAssignMcr,sCrudType};
            String[] dataToUpdate2 = {"requestUtcTime", "assignMcr", "crudType"};

            api.UpdateJSON(dataToUpdate2, dataToUpdatewith2, sFilePath);


        }



       
       
       
    }
}
