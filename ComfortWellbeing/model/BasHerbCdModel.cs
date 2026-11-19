using Mentorsoft.Winform.Framework.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class BasHerbCdModel : MTSModel
    {

        private BHERBCDMODEL _BHerbCd = new BHERBCDMODEL();
        public BHERBCDMODEL BHerbCd
        {
            get { return _BHerbCd; }
            set
            {
                if (_BHerbCd != value)
                {
                    _BHerbCd.PropertyChangedAction = OnPropertyChanged;
                    PropertyChange(_BHerbCd, value);
                    OnPropertyChanged("BHerbCd");
                }
            }
        }

        private MTSCollection<BHERBCDMODEL> _BHerbList = new MTSCollection<BHERBCDMODEL>();
        public MTSCollection<BHERBCDMODEL> BHerbList
        {
            get { return _BHerbList; }
            set
            {
                if (_BHerbList != value)
                {
                    PropertyChange(_BHerbList, value);
                    OnPropertyChanged("BHerbList");
                }
            }
        }

        private MTSCollection<COMBODTO> _AplDateList = new MTSCollection<COMBODTO>();
        public MTSCollection<COMBODTO> AplDateList
        {
            get { return _AplDateList; }
            set
            {
                if (_AplDateList != value)
                {
                    PropertyChange(_AplDateList, value);
                    OnPropertyChanged("AplDateList");
                }
            }
        }

    }

    public class BHERBCDMODEL : BHERBCDDTO
    {
        /// <summary>                          
        /// AplDate
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
    }

    public class COMBODTO : MTSDTO 
    {
        /// <summary>                          
        /// DISPLAYMEMBER
        /// </summary>                         
        private string _DISPLAYMEMBER = string.Empty;
        public string DISPLAYMEMBER
        {
            get { return _DISPLAYMEMBER == null ? string.Empty : _DISPLAYMEMBER; }
            set
            {
                if (_DISPLAYMEMBER != value)
                {
                    _DISPLAYMEMBER = value;
                    OnPropertyChanged("DISPLAYMEMBER", value);
                }
            }
        }

        /// <summary>                          
        /// VALUEMEMBER
        /// </summary>                         
        private string _VALUEMEMBER = string.Empty;
        public string VALUEMEMBER
        {
            get { return _VALUEMEMBER == null ? string.Empty : _VALUEMEMBER; }
            set
            {
                if (_VALUEMEMBER != value)
                {
                    _VALUEMEMBER = value;
                    OnPropertyChanged("VALUEMEMBER", value);
                }
            }
        }

    }
}
