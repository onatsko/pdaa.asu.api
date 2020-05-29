using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    /// <summary>
    /// Посадове переміщення
    /// </summary>
    public class Moving
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

        private long _kadrFK;
        public long KadrFK
        {
            get => _kadrFK;
            set
            {
                {
                    if (_kadrFK != value)
                    {
                        _kadrFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _posadaFK;
        public long PosadaFK
        {
            get => _posadaFK;
            set
            {
                {
                    if (_posadaFK != value)
                    {
                        _posadaFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isPoohBah;
        public bool IsPoohBah
        {
            get => _isPoohBah;
            set
            {
                {
                    if (_isPoohBah != value)
                    {
                        _isPoohBah = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isExt;
        public bool IsExt
        {
            get => _isExt;
            set
            {
                {
                    if (_isExt != value)
                    {
                        _isExt = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isMaterially;
        public bool IsMaterially
        {
            get => _isMaterially;
            set
            {
                {
                    if (_isMaterially != value)
                    {
                        _isMaterially = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private DateTime _dateBegin;
        public DateTime DateBegin
        {
            get => _dateBegin;
            set
            {
                {
                    if (_dateBegin != value)
                    {
                        _dateBegin = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private DateTime _dateEnd;
        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                {
                    if (_dateEnd != value)
                    {
                        _dateEnd = value;
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

        private long _divisionFK;
        public long DivisionFK
        {
            get => _divisionFK;
            set
            {
                {
                    if (_divisionFK != value)
                    {
                        _divisionFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _studVidOplFK;
        public long StudVidOplFK
        {
            get => _studVidOplFK;
            set
            {
                {
                    if (_studVidOplFK != value)
                    {
                        _studVidOplFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _oldOrderNFK;
        public long OldOrderNFK
        {
            get => _oldOrderNFK;
            set
            {
                {
                    if (_oldOrderNFK != value)
                    {
                        _oldOrderNFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _oldOrderKFK;
        public long OldOrderKFK
        {
            get => _oldOrderKFK;
            set
            {
                {
                    if (_oldOrderKFK != value)
                    {
                        _oldOrderKFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private decimal _tarifRozryad;
        public decimal TarifRozryad
        {
            get => _tarifRozryad;
            set
            {
                {
                    if (_tarifRozryad != value)
                    {
                        _tarifRozryad = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private decimal _tarifKt;
        public decimal TarifKt
        {
            get => _tarifKt;
            set
            {
                {
                    if (_tarifKt != value)
                    {
                        _tarifKt = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private decimal _oklad;
        public decimal Oklad
        {
            get => _oklad;
            set
            {
                {
                    if (_oklad != value)
                    {
                        _oklad = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private decimal _stavka;
        public decimal Stavka
        {
            get => _stavka;
            set
            {
                {
                    if (_stavka != value)
                    {
                        _stavka = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _prim;//todo удалить здесь и на сервере бд
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

        private string _lastUserEdit;//todo удалить здесь и на сервере бд (есть отдельная таблица для логирования)
        public string LastUserEdit
        {
            get => _lastUserEdit;
            set
            {
                {
                    if (_lastUserEdit != value)
                    {
                        _lastUserEdit = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _authorFK;//todo IdKadr_us - удалить здесь и в бд (мувинги создаются только через приказы, автор приказа - автор записи)
        public long AuthorFK
        {
            get => _authorFK;
            set
            {
                {
                    if (_authorFK != value)
                    {
                        _authorFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _educPlanSpecFK;
        public long EducPlanSpecFK
        {
            get => _educPlanSpecFK;
            set
            {
                {
                    if (_educPlanSpecFK != value)
                    {
                        _educPlanSpecFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isAcademOtpusk;
        public bool IsAcademOtpusk
        {
            get => _isAcademOtpusk;
            set
            {
                {
                    if (_isAcademOtpusk != value)
                    {
                        _isAcademOtpusk = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _reasonsDismFK;
        public long ReasonsDismFK
        {
            get => _reasonsDismFK;
            set
            {
                {
                    if (_reasonsDismFK != value)
                    {
                        _reasonsDismFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _salaryFundFK;
        public long SalaryFundFK
        {
            get => _salaryFundFK;
            set
            {
                {
                    if (_salaryFundFK != value)
                    {
                        _salaryFundFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isNoShtat;
        public bool IsNoShtat
        {
            get => _isNoShtat;
            set
            {
                {
                    if (_isNoShtat != value)
                    {
                        _isNoShtat = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _contractTypeFK;
        public long ContractTypeFK
        {
            get => _contractTypeFK;
            set
            {
                {
                    if (_contractTypeFK != value)
                    {
                        _contractTypeFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _docOrderBeginFK;
        public long DocOrderBeginFK
        {
            get => _docOrderBeginFK;
            set
            {
                {
                    if (_docOrderBeginFK != value)
                    {
                        _docOrderBeginFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }
        private long _docOrderEndFK;
        public long DocOrderEndFK
        {
            get => _docOrderEndFK;
            set
            {
                {
                    if (_docOrderEndFK != value)
                    {
                        _docOrderEndFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private bool _isPartTime;
        public bool IsPartTime
        {
            get => _isPartTime;
            set
            {
                {
                    if (_isPartTime != value)
                    {
                        _isPartTime = value;
                        sysIsChanged = true;
                    }
                }
            }
        }



        #endregion

        public Moving()
        {
            //системные флаги 
            sysIsChanged = false;
            sysIsLoaded = false;

            //стандартные свойства
            _pk = 0;
            _isDel = false;

            //доп.свойства
            _kadrFK = 0;
            _posadaFK = 0;
            _isPoohBah = false;
            _isExt = false;
            _isMaterially = false;
            _dateBegin = DateTime.Parse("01/01/1900");
            _dateEnd = DateTime.Parse("01/01/1900");
            _isNoCalc = false;
            _divisionFK = 0;
            _studVidOplFK = 1;//в бд по-умолчанию 1
            _oldOrderNFK = 0;
            _oldOrderKFK = 0;
            _tarifRozryad = 0;
            _tarifKt = 0;
            _oklad = 0;
            _stavka = 0;
            _prim = "";
            _lastUserEdit = "";
            _authorFK = 0;
            _educPlanSpecFK = 0;
            _isAcademOtpusk = false;
            _reasonsDismFK = 0;
            _salaryFundFK = 1;//в бд по-умолчанию 1
            _isNoShtat = false;
            _contractTypeFK = 1;//в бд по-умолчанию 1
            _docOrderBeginFK = 0;
            _docOrderEndFK = 0;
            _isPartTime = false;
        }

    }
}
