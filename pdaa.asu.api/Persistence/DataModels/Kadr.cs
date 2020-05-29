using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    /// <summary>
    /// Особа (працівник, студент)
    /// </summary>
    public class Kadr
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

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                {
                    if (_surname != value)
                    {
                        _surname = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

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

        private string _otch;
        public string Otch
        {
            get => _otch;
            set
            {
                {
                    if (_otch != value)
                    {
                        _otch = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        public string NameFull => $"{_surname} {_name} {_otch}";
        public string NameShort => $"{_surname} {(_name.Length > 0 ? $"{_name.Substring(0, 1).ToUpper()}." : "")} {(_otch.Length > 0 ? $"{_otch.Substring(0, 1).ToUpper()}." : "")}";

        private string _surnameEng;
        public string SurnameEng
        {
            get => _surnameEng;
            set
            {
                {
                    if (_surnameEng != value)
                    {
                        _surnameEng = value;
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

        private string _zkpo;

        public string Zkpo
        {
            get => _zkpo;
            set
            {
                {
                    if (_zkpo != value)
                    {
                        _zkpo = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long _edbo;

        public long Edbo
        {
            get => _edbo;
            set
            {
                {
                    if (_edbo != value)
                    {
                        _edbo = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private DateTime? _birthday;
        public DateTime? Birthday
        {
            get => _birthday;
            set
            {
                {
                    if (_birthday != value)
                    {
                        _birthday = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private const decimal DaysInAYear = 365.242M;

        public int Age => _birthday == null
            ? 0
            : (int)Math.Floor((decimal)((DateTime.Today - (DateTime)_birthday).TotalDays) / DaysInAYear);

        private long _birthPlaceCountryFK;

        public long BirthPlaceCountryFK
        {
            get => _birthPlaceCountryFK;
            set
            {
                {
                    if (_birthPlaceCountryFK != value)
                    {
                        _birthPlaceCountryFK = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _birthPlace;

        public string BirthPlace
        {
            get => _birthPlace;
            set
            {
                {
                    if (_birthPlace != value)
                    {
                        _birthPlace = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _sex;

        public string Sex
        {
            get => _sex;
            set
            {
                {
                    if (_sex != value)
                    {
                        _sex = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        public string SexFull
        {
            get
            {
                switch (_sex)
                {
                    case "ч":
                        return "Чоловіча";
                    //break;
                    case "ж":
                        return "Жіноча";
                    //break;
                    default:
                        return "Невизначено";
                        //break;
                }
            }
        }

        private string _nationality;

        public string Nationality
        {
            get => _nationality;
            set
            {
                {
                    if (_nationality != value)
                    {
                        _nationality = value;
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

        private int _pedStagStart;

        public int PedStagStart
        {
            get => _pedStagStart;
            set
            {
                {
                    if (_pedStagStart != value)
                    {
                        _pedStagStart = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int? _dateN_PDAA;

        public int? DateN_PDAA
        {
            get => _dateN_PDAA;
            set
            {
                {
                    if (_dateN_PDAA != value)
                    {
                        _dateN_PDAA = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long? _dataN;

        public long? DataN
        {
            get => _dataN;
            set
            {
                {
                    if (_dataN != value)
                    {
                        _dataN = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _us_psw;

        private string Us_psw
        {
            get => _us_psw;
            set
            {
                {
                    if (_us_psw != value)
                    {
                        _us_psw = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private long? _idKadrFOF;

        public long? KadrFofFK
        {
            get => _idKadrFOF;
            set
            {
                {
                    if (_idKadrFOF != value)
                    {
                        _idKadrFOF = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceScientificPedY;

        public int InBalanceScientificPedY
        {
            get => _inBalanceScientificPedY;
            set
            {
                {
                    if (_inBalanceScientificPedY != value)
                    {
                        _inBalanceScientificPedY = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceScientificPedM;

        public int InBalanceScientificPedM
        {
            get => _inBalanceScientificPedM;
            set
            {
                {
                    if (_inBalanceScientificPedM != value)
                    {
                        _inBalanceScientificPedM = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceScientificPedD;

        public int InBalanceScientificPedD
        {
            get => _inBalanceScientificPedD;
            set
            {
                {
                    if (_inBalanceScientificPedD != value)
                    {
                        _inBalanceScientificPedD = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceEducY;

        public int InBalanceEducY
        {
            get => _inBalanceEducY;
            set
            {
                {
                    if (_inBalanceEducY != value)
                    {
                        _inBalanceEducY = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceEducM;

        public int InBalanceEducM
        {
            get => _inBalanceEducM;
            set
            {
                {
                    if (_inBalanceEducM != value)
                    {
                        _inBalanceEducM = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceEducD;

        public int InBalanceEducD
        {
            get => _inBalanceEducD;
            set
            {
                {
                    if (_inBalanceEducD != value)
                    {
                        _inBalanceEducD = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceScientificY;

        public int InBalanceScientificY
        {
            get => _inBalanceScientificY;
            set
            {
                {
                    if (_inBalanceScientificY != value)
                    {
                        _inBalanceScientificY = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceScientificM;

        public int InBalanceScientificM
        {
            get => _inBalanceScientificM;
            set
            {
                {
                    if (_inBalanceScientificM != value)
                    {
                        _inBalanceScientificM = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceScientificD;

        public int InBalanceScientificD
        {
            get => _inBalanceScientificD;
            set
            {
                {
                    if (_inBalanceScientificD != value)
                    {
                        _inBalanceScientificD = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceLibrariansY;

        public int InBalanceLibrariansY
        {
            get => _inBalanceLibrariansY;
            set
            {
                {
                    if (_inBalanceLibrariansY != value)
                    {
                        _inBalanceLibrariansY = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceLibrariansM;

        public int InBalanceLibrariansM
        {
            get => _inBalanceLibrariansM;
            set
            {
                {
                    if (_inBalanceLibrariansM != value)
                    {
                        _inBalanceLibrariansM = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceLibrariansD;

        public int InBalanceLibrariansD
        {
            get => _inBalanceLibrariansD;
            set
            {
                {
                    if (_inBalanceLibrariansD != value)
                    {
                        _inBalanceLibrariansD = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceMedicalY;

        public int InBalanceMedicalY
        {
            get => _inBalanceMedicalY;
            set
            {
                {
                    if (_inBalanceMedicalY != value)
                    {
                        _inBalanceMedicalY = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceMedicalM;

        public int InBalanceMedicalM
        {
            get => _inBalanceMedicalM;
            set
            {
                {
                    if (_inBalanceMedicalM != value)
                    {
                        _inBalanceMedicalM = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceMedicalD;

        public int InBalanceMedicalD
        {
            get => _inBalanceMedicalD;
            set
            {
                {
                    if (_inBalanceMedicalD != value)
                    {
                        _inBalanceMedicalD = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceAllY;

        public int InBalanceAllY
        {
            get => _inBalanceAllY;
            set
            {
                {
                    if (_inBalanceAllY != value)
                    {
                        _inBalanceAllY = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceAllM;

        public int InBalanceAllM
        {
            get => _inBalanceAllM;
            set
            {
                {
                    if (_inBalanceAllM != value)
                    {
                        _inBalanceAllM = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _inBalanceAllD;

        public int InBalanceAllD
        {
            get => _inBalanceAllD;
            set
            {
                {
                    if (_inBalanceAllD != value)
                    {
                        _inBalanceAllD = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private double _inBalanceVacationD;

        public double InBalanceVacationD
        {
            get => _inBalanceVacationD;
            set
            {
                {
                    if (_inBalanceVacationD != value)
                    {
                        _inBalanceVacationD = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _psw_md5;

        public string Psw_md5
        {
            get => _psw_md5;
            set
            {
                {
                    if (_psw_md5 != value)
                    {
                        _psw_md5 = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _surnameRodovyi;

        public string SurnameRodovyi
        {
            get => _surnameRodovyi;
            set
            {
                {
                    if (_surnameRodovyi != value)
                    {
                        _surnameRodovyi = value;
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

        private string _otchRodovyi;

        public string OtchRodovyi
        {
            get => _otchRodovyi;
            set
            {
                {
                    if (_otchRodovyi != value)
                    {
                        _otchRodovyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _surnameDavalnyi;

        public string SurnameDavalnyi
        {
            get => _surnameDavalnyi;
            set
            {
                {
                    if (_surnameDavalnyi != value)
                    {
                        _surnameDavalnyi = value;
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

        private string _otchDavalnyi;

        public string OtchDavalnyi
        {
            get => _otchDavalnyi;
            set
            {
                {
                    if (_otchDavalnyi != value)
                    {
                        _otchDavalnyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _surnameOrudnyi;

        public string SurnameOrudnyi
        {
            get => _surnameOrudnyi;
            set
            {
                {
                    if (_surnameOrudnyi != value)
                    {
                        _surnameOrudnyi = value;
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

        private string _otchOrudnyi;

        public string OtchOrudnyi
        {
            get => _otchOrudnyi;
            set
            {
                {
                    if (_otchOrudnyi != value)
                    {
                        _otchOrudnyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _surnameZnahidnyi;

        public string SurnameZnahidnyi
        {
            get => _surnameZnahidnyi;
            set
            {
                {
                    if (_surnameZnahidnyi != value)
                    {
                        _surnameZnahidnyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _nameZnahidnyi;

        public string NameZnahidnyi
        {
            get => _nameZnahidnyi;
            set
            {
                {
                    if (_nameZnahidnyi != value)
                    {
                        _nameZnahidnyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private string _otchZnahidnyi;

        public string OtchZnahidnyi
        {
            get => _otchZnahidnyi;
            set
            {
                {
                    if (_otchZnahidnyi != value)
                    {
                        _otchZnahidnyi = value;
                        sysIsChanged = true;
                    }
                }
            }
        }

        private int _telegramID;

        public int TelegramID
        {
            get => _telegramID;
            set
            {
                {
                    if (_telegramID != value)
                    {
                        _telegramID = value;
                        sysIsChanged = true;
                    }
                }
            }
        }


        private string _googleEmailLogin;

        public string GoogleEmailLogin
        {
            get => _googleEmailLogin;
            set
            {
                {
                    if (_googleEmailLogin != value)
                    {
                        _googleEmailLogin = value;
                        sysIsChanged = true;
                    }
                }
            }
        }


        #endregion

        public Kadr()
        {
            //системные флаги 
            sysIsChanged = false;
            sysIsLoaded = false;

            //стандартные свойства
            _pk = 0;
            _isDel = false;

            //доп.свойства
            _surname = "";
            _name = "";
            _otch = "";

            _surnameEng = "";
            _nameEng = "";
            _zkpo = ""; //ІНН
            _edbo = 0;
            _birthday = DateTime.Parse("1/1/1900");
            _birthPlaceCountryFK = 1;
            _birthPlace = "";
            _sex = "";
            _nationality = "";
            _prim = "";
            _pedStagStart = 0; //int
            _dateN_PDAA = null; //int
            _dataN = null; //long
            _us_psw = "";
            _idKadrFOF = null; //long
            _inBalanceScientificPedY = 0;
            _inBalanceScientificPedM = 0;
            _inBalanceScientificPedD = 0;
            _inBalanceEducY = 0;
            _inBalanceEducM = 0;
            _inBalanceEducD = 0;
            _inBalanceScientificY = 0;
            _inBalanceScientificM = 0;
            _inBalanceScientificD = 0;
            _inBalanceLibrariansY = 0;
            _inBalanceLibrariansM = 0;
            _inBalanceLibrariansD = 0;
            _inBalanceMedicalY = 0;
            _inBalanceMedicalM = 0;
            _inBalanceMedicalD = 0;
            _inBalanceAllY = 0; //загальний стаж до ПДАА, кількість років
            _inBalanceAllM = 0; //загальний стаж до ПДАА, кількість місяців
            _inBalanceAllD = 0; //загальний стаж до ПДАА, кількість днів
            _inBalanceVacationD = 0; //float
            _psw_md5 = "";

            _surnameRodovyi = "";
            _nameRodovyi = "";
            _otchRodovyi = "";
            _surnameDavalnyi = "";
            _nameDavalnyi = "";
            _otchDavalnyi = "";
            _surnameOrudnyi = "";
            _nameOrudnyi = "";
            _otchOrudnyi = "";
            _surnameZnahidnyi = "";
            _nameZnahidnyi = "";
            _otchZnahidnyi = "";

            _telegramID = 0;
            _googleEmailLogin = "";
        }

    }
}
