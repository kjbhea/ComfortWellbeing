using Mentorsoft.Winform.Framework.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class PatientDto : MTSDTO
    {
        /// <summary>                          
		/// PtNo
		/// </summary>                         
		private string _PtNo = string.Empty;
		public string PtNo
		{
			get { return _PtNo == null ? string.Empty : _PtNo; }
			set
			{
				if (_PtNo != value)
				{
					_PtNo = value;
					OnPropertyChanged("PtNo", value);
				}
			}
		}

		/// <summary>                          
		/// PtKorNm
		/// </summary>                         
		private string _PtKorNm = string.Empty;
		public string PtKorNm
		{
			get { return _PtKorNm == null ? string.Empty : _PtKorNm; }
			set
			{
				if (_PtKorNm != value)
				{
					_PtKorNm = value;
					OnPropertyChanged("PtKorNm", value);
				}
			}
		}

		/// <summary>                          
		/// TEL
		/// </summary>                         
		private string _TEL = string.Empty;
		public string TEL
		{
			get { return _TEL == null ? string.Empty : _TEL; }
			set
			{
				if (_TEL != value)
				{
					_TEL = value;
					OnPropertyChanged("TEL", value);
				}
			}
		}

		/// <summary>                          
		/// ADDR
		/// </summary>                         
		private string _ADDR = string.Empty;
		public string ADDR
		{
			get { return _ADDR == null ? string.Empty : _ADDR; }
			set
			{
				if (_ADDR != value)
				{
					_ADDR = value;
					OnPropertyChanged("ADDR", value);
				}
			}
		}

		/// <summary>                          
		/// ADDRDTL
		/// </summary>                         
		private string _ADDRDTL = string.Empty;
		public string ADDRDTL
		{
			get { return _ADDRDTL == null ? string.Empty : _ADDRDTL; }
			set
			{
				if (_ADDRDTL != value)
				{
					_ADDRDTL = value;
					OnPropertyChanged("ADDRDTL", value);
				}
			}
		}
    }
}
