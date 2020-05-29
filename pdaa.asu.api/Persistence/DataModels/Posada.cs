namespace pdaa.asu.api.Persistence.DataModels
{
    /// <summary>
    /// Посада працівника 
    /// </summary>
    public class Posada
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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                {
                    if (_name != value)
                    {
                        _name = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameEng;
        public string NameEng
        {
            get => _nameEng;
            set
            {
                {
                    if (_nameEng != value)
                    {
                        _nameEng = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameRodovyi;
        public string NameRodovyi
        {
            get => _nameRodovyi;
            set
            {
                {
                    if (_nameRodovyi != value)
                    {
                        _nameRodovyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameDavalnyi;
        public string NameDavalnyi
        {
            get => _nameDavalnyi;
            set
            {
                {
                    if (_nameDavalnyi != value)
                    {
                        _nameDavalnyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameOrudnyi;
        public string NameOrudnyi
        {
            get => _nameOrudnyi;
            set
            {
                {
                    if (_nameOrudnyi != value)
                    {
                        _nameOrudnyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isEduc;
        public bool IsEduc
        {
            get => _isEduc;
            set
            {
                {
                    if (_isEduc != value)
                    {
                        _isEduc = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isTimesheet;
        public bool IsTimesheet
        {
            get => _isTimesheet;
            set
            {
                {
                    if (_isTimesheet != value)
                    {
                        _isTimesheet = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _prim;
        public string Prim
        {
            get => _prim;
            set
            {
                {
                    if (_prim != value)
                    {
                        _prim = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _vacationDays;
        public int VacationDays
        {
            get => _vacationDays;
            set
            {
                {
                    if (_vacationDays != value)
                    {
                        _vacationDays = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _vacationDaysWorkPart;
        public int VacationDaysWorkPart
        {
            get => _vacationDaysWorkPart;
            set
            {
                {
                    if (_vacationDaysWorkPart != value)
                    {
                        _vacationDaysWorkPart = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _vacationDaysSpecial;
        public int VacationDaysSpecial
        {
            get => _vacationDaysSpecial;
            set
            {
                {
                    if (_vacationDaysSpecial != value)
                    {
                        _vacationDaysSpecial = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isScientific;
        public bool IsScientific
        {
            get => _isScientific;
            set
            {
                {
                    if (_isScientific != value)
                    {
                        _isScientific = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isScientificPed;
        public bool IsScientificPed
        {
            get => _isScientificPed;
            set
            {
                {
                    if (_isScientificPed != value)
                    {
                        _isScientificPed = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isPed;
        public bool IsPed
        {
            get => _isPed;
            set
            {
                {
                    if (_isPed != value)
                    {
                        _isPed = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isLibrarians;
        public bool IsLibrarians
        {
            get => _isLibrarians;
            set
            {
                {
                    if (_isLibrarians != value)
                    {
                        _isLibrarians = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isMedical;
        public bool IsMedical
        {
            get => _isMedical;
            set
            {
                {
                    if (_isMedical != value)
                    {
                        _isMedical = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isNoCalc;
        public bool IsNoCalc
        {
            get => _isNoCalc;
            set
            {
                {
                    if (_isNoCalc != value)
                    {
                        _isNoCalc = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _classificationCode;
        public string ClassificationCode
        {
            get => _classificationCode;
            set
            {
                {
                    if (_classificationCode != value)
                    {
                        _classificationCode = value;
                        sysIsChanged = true;
                    }
                }
            }
        }
        #endregion

        public Posada()
        {
            //системные флаги 
            sysIsChanged = false;
            sysIsLoaded = false;

            //стандартные свойства
            _pk = 0;
            _isDel = false;

            //доп.свойства
            _name = "";
            _nameEng = "";
            _nameRodovyi = "";
            _nameDavalnyi = "";
            _nameOrudnyi = "";
            _isEduc = false;
            _isTimesheet = false;
            _prim = "";
            _vacationDays = 0;
            _vacationDaysWorkPart = 0;
            _vacationDaysSpecial = 0;
            _isScientific = false;
            _isScientificPed = false;
            _isPed = false;
            _isLibrarians = false;
            _isMedical = false;
            _isNoCalc = false;
            _classificationCode = "";
        }

    }
}
