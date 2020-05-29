namespace pdaa.asu.api.Persistence.DataModels
{
    /// <summary>
    /// Підрозділ (кафедра)
    /// </summary>
    public class Kafedra
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

        private string _nameShort;
        public string NameShort
        {
            get => _nameShort;
            set
            {
                {
                    if (_nameShort != value)
                    {
                        _nameShort = value;
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

        private string _nameShortEng;
        public string NameShortEng
        {
            get => _nameShortEng;
            set
            {
                {
                    if (_nameShortEng != value)
                    {
                        _nameShortEng = value;
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

        private bool _isNoUs;
        public bool IsNoUs
        {
            get => _isNoUs;
            set
            {
                {
                    if (_isNoUs != value)
                    {
                        _isNoUs = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _prefixForOrder;
        public string PrefixForOrder
        {
            get => _prefixForOrder;
            set
            {
                {
                    if (_prefixForOrder != value)
                    {
                        _prefixForOrder = value;
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


        #endregion

        public Kafedra()
        {
            //системные флаги 
            sysIsChanged = false;
            sysIsLoaded = false;

            //стандартные свойства
            _pk = 0;
            _isDel = false;

            //доп.свойства
            _name = "";
            _nameShort = "";
            _nameEng = "";
            _nameShortEng = "";
            _isEduc = false;
            _isNoUs = false;
            _prefixForOrder = "";
            _nameDavalnyi = "";
            _prim = "";
            _fakultetFK = 0;
        }

    }
}
