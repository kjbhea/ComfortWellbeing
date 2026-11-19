using Mentorsoft.Winform.Framework.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class BHERBCDDTO : MTSDTO
    {
        /// <summary>                          
        /// HerbCd
        /// </summary>                         
        private string _HerbCd = string.Empty;
		public string HerbCd
		{
			get { return _HerbCd == null ? string.Empty : _HerbCd; }
			set
			{
				if (_HerbCd != value)
				{
					_HerbCd = value;
					OnPropertyChanged("HerbCd", value);
				}
			}
		}

        /// <summary>                          
        /// AplFrDate
        /// </summary>                         
        private string _AplFrDate = string.Empty;
		public string AplFrDate
		{
			get { return _AplFrDate == null ? string.Empty : _AplFrDate; }
			set
			{
				if (_AplFrDate != value)
				{
					_AplFrDate = value;
					OnPropertyChanged("AplFrDate", value);
				}
			}
		}

        /// <summary>                          
        /// AplToDate
        /// </summary>                         
        private string _AplToDate = string.Empty;
		public string AplToDate
		{
			get { return _AplToDate == null ? string.Empty : _AplToDate; }
			set
			{
				if (_AplToDate != value)
				{
					_AplToDate = value;
					OnPropertyChanged("AplToDate", value);
				}
			}
		}

        /// <summary>                          
        /// HerbNm
        /// </summary>                         
        private string _HerbNm = string.Empty;
		public string HerbNm
		{
			get { return _HerbNm == null ? string.Empty : _HerbNm; }
			set
			{
				if (_HerbNm != value)
				{
					_HerbNm = value;
					OnPropertyChanged("HerbNm", value);
				}
			}
		}

        /// <summary>                          
        /// Company
        /// </summary>                         
        private string _Company = string.Empty;
		public string Company
		{
			get { return _Company == null ? string.Empty : _Company; }
			set
			{
				if (_Company != value)
				{
					_Company = value;
					OnPropertyChanged("Company", value);
				}
			}
		}

        /// <summary>                          
        /// BasAmt
        /// </summary>                         
        private long _BasAmt;
		public long BasAmt
		{
			get { return _BasAmt; }
			set
			{
				if (_BasAmt != value)
				{
					_BasAmt = value;
					OnPropertyChanged("BasAmt", value);
				}
			}
		}

        /// <summary>                          
        /// TotalQty
        /// </summary>                         
        private long _TotalQty;
		public long TotalQty
		{
			get { return _TotalQty; }
			set
			{
				if (_TotalQty != value)
				{
					_TotalQty = value;
					OnPropertyChanged("TotalQty", value);
				}
			}
		}

        /// <summary>                          
        /// Qty
        /// </summary>                         
        private long _Qty;
		public long Qty
		{
			get { return _Qty; }
			set
			{
				if (_Qty != value)
				{
					_Qty = value;
					OnPropertyChanged("Qty", value);
				}
			}
		}

        /// <summary>                          
        /// Cnt
        /// </summary>                         
        private long _Cnt;
		public long Cnt
		{
			get { return _Cnt; }
			set
			{
				if (_Cnt != value)
				{
					_Cnt = value;
					OnPropertyChanged("Cnt", value);
				}
			}
		}

        /// <summary>                          
        /// Ingredient
        /// </summary>                         
        private string _Ingredient = string.Empty;
		public string Ingredient
		{
			get { return _Ingredient == null ? string.Empty : _Ingredient; }
			set
			{
				if (_Ingredient != value)
				{
					_Ingredient = value;
					OnPropertyChanged("Ingredient", value);
				}
			}
		}

        /// <summary>                          
        /// RegDate
        /// </summary>                         
        private string _RegDate = string.Empty;
        public string RegDate
        {
            get { return _RegDate == null ? string.Empty : _RegDate; }
            set
            {
                if (_RegDate != value)
                {
                    _RegDate = value;
                    OnPropertyChanged("RegDate", value);
                }
            }
        }

        /// <summary>                          
        /// RegTime
        /// </summary>                         
        private string _RegTime = string.Empty;
        public string RegTime
        {
            get { return _RegTime == null ? string.Empty : _RegTime; }
            set
            {
                if (_RegTime != value)
                {
                    _RegTime = value;
                    OnPropertyChanged("RegTime", value);
                }
            }
        }

        /// <summary>                          
        /// ModifyDate
        /// </summary>                         
        private string _ModifyDate = string.Empty;
        public string ModifyDate
        {
            get { return _ModifyDate == null ? string.Empty : _ModifyDate; }
            set
            {
                if (_ModifyDate != value)
                {
                    _ModifyDate = value;
                    OnPropertyChanged("ModifyDate", value);
                }
            }
        }

        /// <summary>                          
        /// ModifyTime
        /// </summary>                         
        private string _ModifyTime = string.Empty;
        public string ModifyTime
        {
            get { return _ModifyTime == null ? string.Empty : _ModifyTime; }
            set
            {
                if (_ModifyTime != value)
                {
                    _ModifyTime = value;
                    OnPropertyChanged("ModifyTime", value);
                }
            }
        }

    }
}
