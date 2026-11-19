using Mentorsoft.Winform.Framework.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class HerbMainModel : MTSModel
    {
        private PatientDto _Patient = new PatientDto();
		public PatientDto Patient
		{
			get { return _Patient; }
			set
			{
				if (_Patient != value)
				{
					_Patient.PropertyChangedAction = OnPropertyChanged;
					PropertyChange(_Patient, value);
					OnPropertyChanged("Patient");
				}
			}
		}

    }
}
