using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class SetCdModel : BHERBCDDTO
    {
		/// <summary>                          
		/// StockCnt
		/// </summary>                         
		private long _StockCnt;
		public long StockCnt
		{
			get { return _StockCnt; }
			set
			{
				if (_StockCnt != value)
				{
					_StockCnt = value;
					OnPropertyChanged("StockCnt", value);
				}
			}
		}

	}
}
