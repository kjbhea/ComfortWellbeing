using ComfortWellbeing.model;
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
		private SEARCHDTO _Param = new SEARCHDTO();
		public SEARCHDTO Param
		{
			get { return _Param; }
			set
			{
				if (_Param != value)
				{
					_Param.PropertyChangedAction = OnPropertyChanged;
					PropertyChange(_Param, value);
					OnPropertyChanged("Param");
				}
			}
		}

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



		private MTSCollection<AARCPDTO> _AARCPList = new MTSCollection<AARCPDTO>();
		public MTSCollection<AARCPDTO> AARCPList
		{
			get { return _AARCPList; }
			set
			{
				if (_AARCPList != value)
				{
					PropertyChange(_AARCPList, value);
					OnPropertyChanged("AARCPList");
				}
			}
		}

		private MTSCollection<OrderModel> _AAORDList = new MTSCollection<OrderModel>();
		public MTSCollection<OrderModel> AAORDList
		{
			get { return _AAORDList; }
			set
			{
				if (_AAORDList != value)
				{
					PropertyChange(_AAORDList, value);
					OnPropertyChanged("AAORDList");
				}
			}
		}


		private MTSCollection<SetCdModel> _SetCdList = new MTSCollection<SetCdModel>();
		public MTSCollection<SetCdModel> SetCdList
		{
			get { return _SetCdList; }
			set
			{
				if (_SetCdList != value)
				{
					PropertyChange(_SetCdList, value);
					OnPropertyChanged("SetCdList");
				}
			}
		}


		private MTSCollection<OrderModel> _OrderList = new MTSCollection<OrderModel>();
		public MTSCollection<OrderModel> OrderList
		{
			get { return _OrderList; }
			set
			{
				if (_OrderList != value)
				{
					PropertyChange(_OrderList, value);
					OnPropertyChanged("OrderList");
				}
			}
		}


		private PayModel _PayInfo = new PayModel();
		public PayModel PayInfo
		{
			get { return _PayInfo; }
			set
			{
				if (_PayInfo != value)
				{
					_PayInfo.PropertyChangedAction = OnPropertyChanged;
					PropertyChange(_PayInfo, value);
					OnPropertyChanged("PayInfo");
				}
			}
		}

	}

	public class SEARCHDTO : MTSDTO
	{
        /// <summary>                          
        /// OrderDate
        /// </summary>                         
        private string _OrderDate = string.Empty;
        public string OrderDate
        {
            get { return _OrderDate == null ? string.Empty : _OrderDate; }
            set
            {
                if (_OrderDate != value)
                {
                    _OrderDate = value;
                    OnPropertyChanged("OrderDate", value);
                }
            }
        }
    }	
}
