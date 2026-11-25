using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class PayModel : AARCPDTO
    {
		/// <summary>                          
		/// AccCd
		/// </summary>                         
		private string _AccCd = string.Empty;
		public string AccCd
		{
			get { return _AccCd == null ? string.Empty : _AccCd; }
			set
			{
				if (_AccCd != value)
				{
					_AccCd = value;
					OnPropertyChanged("AccCd", value);
				}
			}
		}

		/// <summary>                          
		/// PayAmt
		/// </summary>                         
		private long _PayAmt;
		public long PayAmt
		{
			get { return _PayAmt; }
			set
			{
				if (_PayAmt != value)
				{
					_PayAmt = value;
					OnPropertyChanged("PayAmt", value);
				}
			}
		}

	}
}
