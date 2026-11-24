using Mentorsoft.Winform.Framework.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class AAORDDTO : MTSDTO
    {
        /// <summary>                          
		/// 영수번호
		/// </summary>                         
		private long _RcpNo;
		public long RcpNo
		{
			get { return _RcpNo; }
			set
			{
				if (_RcpNo != value)
				{
					_RcpNo = value;
					OnPropertyChanged("RcpNo", value);
				}
			}
		}

		/// <summary>                          
		/// 영수일자
		/// </summary>                         
		private string _RcpDate = string.Empty;
		public string RcpDate
		{
			get { return _RcpDate == null ? string.Empty : _RcpDate; }
			set
			{
				if (_RcpDate != value)
				{
					_RcpDate = value;
					OnPropertyChanged("RcpDate", value);
				}
			}
		}

		/// <summary>                          
		/// 환자번호
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
		/// 처방일자
		/// </summary>                         
		private string _OrdDate = string.Empty;
		public string OrdDate
		{
			get { return _OrdDate == null ? string.Empty : _OrdDate; }
			set
			{
				if (_OrdDate != value)
				{
					_OrdDate = value;
					OnPropertyChanged("OrdDate", value);
				}
			}
		}

		/// <summary>                          
		/// 영양제 코드
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
		/// 단가
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
		/// 수량
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
		/// FREEYN
		/// </summary>                         
		private string _FREEYN = string.Empty;
		public string FREEYN
		{
			get { return _FREEYN == null ? string.Empty : _FREEYN; }
			set
			{
				if (_FREEYN != value)
				{
					_FREEYN = value;
					OnPropertyChanged("FREEYN", value);
				}
			}
		}


		/// <summary>                          
		/// 계산금액
		/// </summary>                         
		private long _CalcAmt;
		public long CalcAmt
		{
			get { return _CalcAmt; }
			set
			{
				if (_CalcAmt != value)
				{
					_CalcAmt = value;
					OnPropertyChanged("CalcAmt", value);
				}
			}
		}
		
		/// <summary>                          
		/// 상태
		/// </summary>                         
		private string _StsCls = string.Empty;
		public string StsCls
		{
			get { return _StsCls == null ? string.Empty : _StsCls; }
			set
			{
				if (_StsCls != value)
				{
					_StsCls = value;
					OnPropertyChanged("StsCls", value);
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
