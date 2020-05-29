namespace pdaa.asu.api.Persistence.DataModels
{
    public class Group
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

        private int _num;
        public int Num
        {
            get => _num;
            set
            {
                {
                    if (_num != value)
                    {
                        _num = value;
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

        private long _kvalifFK;
        public long KvalifFK
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

        private long _kursFK;
        public long KursFK
        {
            get => _kursFK;
            set
            {
                {
                    if (_kursFK != value)
                    {
                        _kursFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _vidEducFK;
        public long VidEducFK
        {
            get => _vidEducFK;
            set
            {
                {
                    if (_vidEducFK != value)
                    {
                        _vidEducFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isIntegrated;
        public bool IsIntegrated
        {
            get => _isIntegrated;
            set
            {
                {
                    if (_isIntegrated != value)
                    {
                        _isIntegrated = value;
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

        private long _specDirectFK;
        public long SpecDirectFK
        {
            get => _specDirectFK;
            set
            {
                {
                    if (_specDirectFK != value)
                    {
                        _specDirectFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _specOldFK;
        public long SpecOldFK
        {
            get => _specOldFK;
            set
            {
                {
                    if (_specOldFK != value)
                    {
                        _specOldFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _uchPlanFK;
        public long UchPlanFK
        {
            get => _uchPlanFK;
            set
            {
                {
                    if (_uchPlanFK != value)
                    {
                        _uchPlanFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameAutoAll;
        public string NameAutoAll
        {
            get => _nameAutoAll;
            set
            {
                {
                    if (_nameAutoAll != value)
                    {
                        _nameAutoAll = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameAutoShort1;
        public string NameAutoShort1
        {
            get => _nameAutoShort1;
            set
            {
                {
                    if (_nameAutoShort1 != value)
                    {
                        _nameAutoShort1 = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameAutoShort2;
        public string NameAutoShort2
        {
            get => _nameAutoShort2;
            set
            {
                {
                    if (_nameAutoShort2 != value)
                    {
                        _nameAutoShort2 = value;
                        sysIsChanged = true;
                    }
                }
            }
        }


        #endregion

        public Group()
        {
            //системные флаги 
            sysIsChanged = false;
            sysIsLoaded = false;

            //стандартные свойства
            _pk = 0;
            _isDel = false;

            //доп.свойства
            _name = "";
            _num = 0;
            _specFK = 1;
            _kvalifFK = 1;
            _kursFK = 1;
            _vidEducFK = 1;
            _isIntegrated = false;
            _integratedNum = 0;
            _prim = "";
            _fakultetFK = 1;
            _specDirectFK = 1;
            _specOldFK = 0;
            _uchPlanFK = 0;
            _nameAutoAll = "";
            _nameAutoShort1 = "";
            _nameAutoShort2 = "";
        }

    }
}
