using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    public class Prescription
    {        
        private string prescriptionID;
        private Appointment appointment;
        private Medicine medicine;
        private Staff staff;
        private Patient patient;
        private DateTime endDate;

        public string PrescriptionID
        {
            get
            {
                return prescriptionID;
            }

            set
            {
                prescriptionID = value;
            }
        }

        public Appointment Appointment
        {
            get
            {
                return appointment;
            }

            set
            {
                appointment = value;
            }
        }

        public Medicine Medicine
        {
            get
            {
                return medicine;
            }

            set
            {
                medicine = value;
            }
        }

        public Staff Staff
        {
            get
            {
                return staff;
            }

            set
            {
                staff = value;
            }
        }

        public Patient Patient
        {
            get
            {
                return patient;
            }

            set
            {
                patient = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }
    }

    
}
