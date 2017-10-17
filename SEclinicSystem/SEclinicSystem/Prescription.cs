using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class Prescription
    {
        private string id;
        private string name;
        private string details;
        private GeneralPractitioner prescriptedBy;
        private Patient prescriptedTo;

        private bool monthlyLimit()
        {
            return true;
        }
    }

    
}
