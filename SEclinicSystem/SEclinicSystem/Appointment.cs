using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class Appointment
    {
        private DateTime dateTime;
        private string patientName;
        private string gpName;

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }

            set
            {
                dateTime = value;
            }
        }

        public string PatientName
        {
            get
            {
                return patientName;
            }

            set
            {
                patientName = value;
            }
        }

        public string GpName
        {
            get
            {
                return gpName;
            }

            set
            {
                gpName = value;
            }
        }

        private bool book()
        {
            return true;
        }

        private bool change()
        {
            return true;
        }

        private void check()
        {

        }

        private void cancel()
        {

        }
    }
}
