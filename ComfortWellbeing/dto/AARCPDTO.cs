using Mentorsoft.Winform.Framework.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class AARCPDTO : MTSDTO
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
		/// 감액
		/// </summary>                         
		private long _MinusAmt;
		public long MinusAmt
		{
			get { return _MinusAmt; }
			set
			{
				if (_MinusAmt != value)
				{
					_MinusAmt = value;
					OnPropertyChanged("MinusAmt", value);
				}
			}
		}

		/// <summary>                          
		/// CardAmt
		/// </summary>                         
		private long _CardAmt;
		public long CardAmt
		{
			get { return _CardAmt; }
			set
			{
				if (_CardAmt != value)
				{
					_CardAmt = value;
					OnPropertyChanged("CardAmt", value);
				}
			}
		}

		/// <summary>                          
		/// CashAmt
		/// </summary>                         
		private long _CashAmt;
		public long CashAmt
		{
			get { return _CashAmt; }
			set
			{
				if (_CashAmt != value)
				{
					_CashAmt = value;
					OnPropertyChanged("CashAmt", value);
				}
			}
		}

		/// <summary>                          
		/// OnLineAmt
		/// </summary>                         
		private long _OnLineAmt;
		public long OnLineAmt
		{
			get { return _OnLineAmt; }
			set
			{
				if (_OnLineAmt != value)
				{
					_OnLineAmt = value;
					OnPropertyChanged("OnLineAmt", value);
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
