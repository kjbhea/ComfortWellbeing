using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing.model
{
    public class OrderModel : AAORDDTO
    {
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
