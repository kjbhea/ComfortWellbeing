using Mentorsoft.Winform.Framework.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class INWARHDTO : MTSDTO
    {
		/// <summary>                          
		/// 입고일자
		/// </summary>                         
		private string _AplDate = string.Empty;
		public string AplDate
		{
			get { return _AplDate == null ? string.Empty : _AplDate; }
			set
			{
				if (_AplDate != value)
				{
					_AplDate = value;
					OnPropertyChanged("AplDate", value);
				}
			}
		}

		/// <summary>                          
		/// 영양제코드
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
		/// 입고량
		/// </summary>                         
		private long _IWarhCnt;
		public long IWarhCnt
		{
			get { return _IWarhCnt; }
			set
			{
				if (_IWarhCnt != value)
				{
					_IWarhCnt = value;
					OnPropertyChanged("IWarhCnt", value);
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
