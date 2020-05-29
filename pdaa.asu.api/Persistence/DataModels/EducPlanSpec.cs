using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    /// <summary>
    /// Навчальний план
    /// </summary>
    public class EducPlanSpec
    {
        #region system properties
        public bool sysIsChanged { get; set; }
        public bool sysIsLoaded { get; set; }

        private long _pk;
        public long PK
        {
            get => _pk;
            set
            {
                {
                    if (_pk != value)
                    {
                        _pk = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isDel;
        public bool IsDel
        {
            get => _isDel;
            set
            {
                {
                    if (_isDel != value)
                    {
                        _isDel = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        #endregion

        #region element


        private DateTime _year;
        public DateTime Year
        {
            get => _year;
            set
            {
                {
                    if (_year != value)
                    {
                        _year = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _fakultetFK;
        public long FakultetFK
        {
            get => _fakultetFK;
            set
            {
                {
                    if (_fakultetFK != value)
                    {
                        _fakultetFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _specFK;
        public long SpecFK
        {
            get => _specFK;
            set
            {
                {
                    if (_specFK != value)
                    {
                        _specFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _educVidFK;
        public int EducVidFK
        {
            get => _educVidFK;
            set
            {
                {
                    if (_educVidFK != value)
                    {
                        _educVidFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _kvalifFK;
        public int KvalifFK
        {
            get => _kvalifFK;
            set
            {
                {
                    if (_kvalifFK != value)
                    {
                        _kvalifFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _integratedNum;
        public int IntegratedNum
        {
            get => _integratedNum;
            set
            {
                {
                    if (_integratedNum != value)
                    {
                        _integratedNum = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _chkIntegrated;
        public bool chkIntegrated
        {
            get => _chkIntegrated;
            set
            {
                {
                    if (_chkIntegrated != value)
                    {
                        _chkIntegrated = value;
                        sysIsChanged = true;
                    }
                }
            }
        }




        private int _semesterEducB;
        public int SemesterEducB
        {
            get => _semesterEducB;
            set
            {
                {
                    if (_semesterEducB != value)
                    {
                        _semesterEducB = value;
                        sysIsChanged = true;
                    }
                }
            }
        }


        private int _semesterEducE;
        public int SemesterEducE
        {
            get => _semesterEducE;
            set
            {
                {
                    if (_semesterEducE != value)
                    {
                        _semesterEducE = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _kursOfYearCalcB;
        public int KursOfYearCalcB
        {
            get => _kursOfYearCalcB;
            set
            {
                {
                    if (_kursOfYearCalcB != value)
                    {
                        _kursOfYearCalcB = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _kursOfYearCalcE;
        public int KursOfYearCalcE
        {
            get => _kursOfYearCalcE;
            set
            {
                {
                    if (_kursOfYearCalcE != value)
                    {
                        _kursOfYearCalcE = value;
                        sysIsChanged = true;
                    }
                }
            }
        }
        //

        private int _kursNumStart;
        public int KursNumStart
        {
            get => _kursNumStart;
            set
            {
                {
                    if (_kursNumStart != value)
                    {
                        _kursNumStart = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        public int Kurs { get; set; }
        public int KursNow { get; set; }

        private bool _isDisciplinesDiffSelect_Spec;
        public bool IsDisciplinesDiffSelect_Spec
        {
            get => _isDisciplinesDiffSelect_Spec;
            set
            {
                {
                    if (_isDisciplinesDiffSelect_Spec != value)
                    {
                        _isDisciplinesDiffSelect_Spec = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isDisciplinesDiffSelect;
        public bool IsDisciplinesDiffSelect
        {
            get => _isDisciplinesDiffSelect;
            set
            {
                {
                    if (_isDisciplinesDiffSelect != value)
                    {
                        _isDisciplinesDiffSelect = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _educYearBegin;
        public int EducYearBegin
        {
            get => _educYearBegin;
            set
            {
                {
                    if (_educYearBegin != value)
                    {
                        _educYearBegin = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isStn;
        public bool IsStn
        {
            get => _isStn;
            set
            {
                {
                    if (_isStn != value)
                    {
                        _isStn = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        #endregion

        public EducPlanSpec()
        {
            //системные флаги 
            sysIsChanged = false;
            sysIsLoaded = false;

            //стандартные свойства
            _pk = 0;
            _isDel = false;

            //доп.свойства
            _year = DateTime.Parse("01/01/2018"); //*в навчальном плане привязка ветки (так эволюционно срыгнулось) через tblEducPlan_Spec_jrn.EducPlanYear - SMALLDATETIME 
            _educYearBegin = 0; //связь с калькуляционным годом - идет через WHEN MONTH(tblEducPlan_Spec_jrn.EducPlanYear) >= 9...
            _fakultetFK = 0;
            _kvalifFK = 0;
            _specFK = 0;
            _educVidFK = 0;
            _integratedNum = 0;
            _semesterEducB = 0;
            _semesterEducE = 0;
            _kursOfYearCalcB = 0;
            _kursOfYearCalcE = 0;
            _kursNumStart = 0;
            Kurs = 0;
            KursNow = 0;
            _isDisciplinesDiffSelect_Spec = false;
            _isDisciplinesDiffSelect = false;
            _isStn = false;
        }

    }
}
