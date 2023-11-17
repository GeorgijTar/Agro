// http://notesatprograming.blogspot.ru/2011/10/public-enum-textcase-nominative.html

namespace Helpers;

public enum TextCase { Nominative/*Кто? Что?*/, Genitive/*Кого? Чего?*/, Dative/*Кому? Чему?*/, Accusative/*Кого? Что?*/, Instrumental/*Кем? Чем?*/, Prepositional/*О ком? О чём?*/ };

public static class AmountInWords
{
    static Dictionary<TextCase, string[]> _monthNames = new Dictionary<TextCase, string[]>
    {
        { TextCase.Nominative, new []{"", "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь"} },
        { TextCase.Genitive, new []{"", "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря"} }
    };
    

    static string _zero = "ноль";
    static string _firstMale = "один";
    static string _firstFemale = "одна";
    static string _firstFemaleAccusative = "одну";
    static string _firstMaleGenetive = "одно";
    static string _secondMale = "два";
    static string _secondFemale = "две";
    static string _secondMaleGenetive = "двух";
    static string _secondFemaleGenetive = "двух";

    static string[] _from3Till19 = 
    {
        "", "три", "четыре", "пять", "шесть",
        "семь", "восемь", "девять", "десять", "одиннадцать",
        "двенадцать", "тринадцать", "четырнадцать", "пятнадцать",
        "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
    };
    static string[] _from3Till19Genetive = 
    {
        "", "трех", "четырех", "пяти", "шести",
        "семи", "восеми", "девяти", "десяти", "одиннадцати",
        "двенадцати", "тринадцати", "четырнадцати", "пятнадцати",
        "шестнадцати", "семнадцати", "восемнадцати", "девятнадцати"
    };
    static string[] _tens =
    {
        "", "двадцать", "тридцать", "сорок", "пятьдесят",
        "шестьдесят", "семьдесят", "восемьдесят", "девяносто"
    };
    static string[] _tensGenetive =
    {
        "", "двадцати", "тридцати", "сорока", "пятидесяти",
        "шестидесяти", "семидесяти", "восьмидесяти", "девяноста"
    };
    static string[] _hundreds =
    {
        "", "сто", "двести", "триста", "четыреста",
        "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
    };
    static string[] _hundredsGenetive =
    {
        "", "ста", "двухсот", "трехсот", "четырехсот",
        "пятисот", "шестисот", "семисот", "восемисот", "девятисот"
    };
    static string[] _thousands =
    {
        "", "тысяча", "тысячи", "тысяч"
    };
    static string[] _thousandsAccusative =
    {
        "", "тысячу", "тысячи", "тысяч"
    };
    static string[] _millions =
    {
        "", "миллион", "миллиона", "миллионов"
    };
    static string[] _billions =
    {
        "", "миллиард", "миллиарда", "миллиардов"
    };
    static string[] _trillions =
    {
        "", "трилион", "трилиона", "триллионов"
    };
    static string[] _rubles =
    {
        "", "рубль", "рубля", "рублей"
    };
    static string[] _copecks =
    {
        "", "копейка", "копейки", "копеек"
    };

    /// <summary>
    /// «07» января 2004 [+ _year(:года)]
    /// </summary>
    /// <param name="date"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public static string DateToTextLong(DateTime date, string year)
    {
        return String.Format("«{0}» {1} {2}",
                                date.Day.ToString("D2"),
                                MonthName(date.Month, TextCase.Genitive),
                                date.Year.ToString()) + ((year.Length != 0) ? " " : "") + year;
    }

    /// <summary>
    /// «07» января 2004
    /// </summary>
    /// <param name="_date"></param>
    /// <returns></returns>
    public static string DateToTextLong(DateTime date)
    {
        return String.Format("«{0}» {1} {2}",
                                date.Day.ToString("D2"),
                                MonthName(date.Month, TextCase.Genitive),
                                date.Year.ToString());
    }
    /// <summary>
    /// II квартал 2004
    /// </summary>
    /// <param name="_date"></param>
    /// <returns></returns>
    public static string DateToTextQuarter(DateTime date)
    {
        return NumeralsRoman(DateQuarter(date)) + " квартал " + date.Year.ToString();
    }
    /// <summary>
    /// 07.01.2004
    /// </summary>
    /// <param name="_date"></param>
    /// <returns></returns>
    public static string DateToTextSimple(DateTime date)
    {
        return String.Format("{0:dd.MM.yyyy}", date);
    }
    public static int DateQuarter(DateTime date)
    {
        return (date.Month - 1) / 3 + 1;
    }

    static bool IsPluralGenitive(int digits)
    {
        if (digits >= 5 || digits == 0)
            return true;

        return false;
    }
    static bool IsSingularGenitive(int digits)
    {
        if (digits >= 2 && digits <= 4)
            return true;

        return false;
    }
    static int LastDigit(long amount)
    {
        long _amount = amount;

        if (amount >= 100)
            amount = amount % 100;

        if (amount >= 20)
            amount = amount % 10;

        return (int)amount;
    }
    /// <summary>
    /// Десять тысяч рублей 67 копеек
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="firstCapital"></param>
    /// <returns></returns>
    public static string CurrencyToTxt(double amount, bool firstCapital)
    {
        //Десять тысяч рублей 67 копеек
        long rublesAmount = (long)Math.Floor(amount);
        long copecksAmount = ((long)Math.Round(amount * 100)) % 100;
        int lastRublesDigit = LastDigit(rublesAmount);
        int lastCopecksDigit = LastDigit(copecksAmount);

        string s = NumeralsToTxt(rublesAmount, TextCase.Nominative, true, firstCapital) + " ";

        if (IsPluralGenitive(lastRublesDigit))
        {
            s += _rubles[3] + " ";
        }
        else if (IsSingularGenitive(lastRublesDigit))
        {
            s += _rubles[2] + " ";
        }
        else
        {
            s += _rubles[1] + " ";
        }

        s += String.Format("{0:00} ", copecksAmount);

        if (IsPluralGenitive(lastCopecksDigit))
        {
            s += _copecks[3] + " ";
        }
        else if (IsSingularGenitive(lastCopecksDigit))
        {
            s += _copecks[2] + " ";
        }
        else
        {
            s += _copecks[1] + " ";
        }

        return s.Trim();
    }
    /// <summary>
    /// 10 000 (Десять тысяч) рублей 67 копеек
    /// </summary>
    /// <param name="_amount"></param>
    /// <param name="_firstCapital"></param>
    /// <returns></returns>
    public static string CurrencyToTxtFull(double amount, bool firstCapital)
    {
        //10 000 (Десять тысяч) рублей 67 копеек
        long rublesAmount = (long)Math.Floor(amount);
        long copecksAmount = ((long)Math.Round(amount * 100)) % 100;
        int lastRublesDigit = LastDigit(rublesAmount);
        int lastCopecksDigit = LastDigit(copecksAmount);

        string s = String.Format("{0:N0} ({1}) ", rublesAmount, NumeralsToTxt(rublesAmount, TextCase.Nominative, true, firstCapital));

        if (IsPluralGenitive(lastRublesDigit))
        {
            s += _rubles[3] + " ";
        }
        else if (IsSingularGenitive(lastRublesDigit))
        {
            s += _rubles[2] + " ";
        }
        else
        {
            s += _rubles[1] + " ";
        }

        s += String.Format("{0:00} ", copecksAmount);

        if (IsPluralGenitive(lastCopecksDigit))
        {
            s += _copecks[3] + " ";
        }
        else if (IsSingularGenitive(lastCopecksDigit))
        {
            s += _copecks[2] + " ";
        }
        else
        {
            s += _copecks[1] + " ";
        }

        return s.Trim();
    }
    /// <summary>
    /// 10 000 рублей 67 копеек  
    /// </summary>
    /// <param name="_amount"></param>
    /// <param name="_firstCapital"></param>
    /// <returns></returns>
    public static string CurrencyToTxtShort(double amount, bool firstCapital)
    {
        //10 000 рублей 67 копеек        
        long rublesAmount = (long)Math.Floor(amount);
        long copecksAmount = ((long)Math.Round(amount * 100)) % 100;
        int lastRublesDigit = LastDigit(rublesAmount);
        int lastCopecksDigit = LastDigit(copecksAmount);

        string s = String.Format("{0:N0} ", rublesAmount);

        if (IsPluralGenitive(lastRublesDigit))
        {
            s += _rubles[3] + " ";
        }
        else if (IsSingularGenitive(lastRublesDigit))
        {
            s += _rubles[2] + " ";
        }
        else
        {
            s += _rubles[1] + " ";
        }

        s += String.Format("{0:00} ", copecksAmount);

        if (IsPluralGenitive(lastCopecksDigit))
        {
            s += _copecks[3] + " ";
        }
        else if (IsSingularGenitive(lastCopecksDigit))
        {
            s += _copecks[2] + " ";
        }
        else
        {
            s += _copecks[1] + " ";
        }

        return s.Trim();
    }
    static string MakeText(int digits, string[] hundreds, string[] tens, string[] from3Till19, string second, string first, string[] power)
    {
        string s = "";
        int _digits = digits;

        if (digits >= 100)
        {
            s += hundreds[digits / 100] + " ";
            digits = digits % 100;
        }
        if (digits >= 20)
        {
            s += tens[digits / 10 - 1] + " ";
            digits = digits % 10;
        }

        if (digits >= 3)
        {
            s += from3Till19[digits - 2] + " ";
        }
        else if (digits == 2)
        {
            s += second + " ";
        }
        else if (digits == 1)
        {
            s += first + " ";
        }

        if (_digits != 0 && power.Length > 0)
        {
            digits = LastDigit(_digits);

            if (IsPluralGenitive(digits))
            {
                s += power[3] + " ";
            }
            else if (IsSingularGenitive(digits))
            {
                s += power[2] + " ";
            }
            else
            {
                s += power[1] + " ";
            }
        }

        return s;
    }
    
    /// <summary>
    /// реализовано для падежей: именительный (nominative), родительный (Genitive),  винительный (accusative)
    /// </summary>
    /// <param name="_sourceNumber"></param>
    /// <param name="_case"></param>
    /// <param name="_isMale"></param>
    /// <param name="_firstCapital"></param>
    /// <returns></returns>
    public static string NumeralsToTxt(long sourceNumber, TextCase @case, bool isMale, bool firstCapital)
    {
        string s = "";
        long number = sourceNumber;
        int remainder;
        int power = 0;

        if ((number >= (long)Math.Pow(10, 15)) || number < 0)
        {
            return "";
        }

        while (number > 0)
        {
            remainder = (int)(number % 1000);
            number = number / 1000;

            switch (power)
            {
                case 12:
                    s = MakeText(remainder, _hundreds, _tens, _from3Till19, _secondMale, _firstMale, _trillions) + s;
                    break;
                case 9:
                    s = MakeText(remainder, _hundreds, _tens, _from3Till19, _secondMale, _firstMale, _billions) + s;
                    break;
                case 6:
                    s = MakeText(remainder, _hundreds, _tens, _from3Till19, _secondMale, _firstMale, _millions) + s;
                    break;
                case 3:
                    switch (@case)
                    {
                        case TextCase.Accusative:
                            s = MakeText(remainder, _hundreds, _tens, _from3Till19, _secondFemale, _firstFemaleAccusative, _thousandsAccusative) + s;
                            break;
                        default:
                            s = MakeText(remainder, _hundreds, _tens, _from3Till19, _secondFemale, _firstFemale, _thousands) + s;
                            break;
                    }
                    break;
                default:
                    string[] powerArray = { };
                    switch (@case)
                    {
                        case TextCase.Genitive:
                            s = MakeText(remainder, _hundredsGenetive, _tensGenetive, _from3Till19Genetive, isMale ? _secondMaleGenetive : _secondFemaleGenetive, isMale ? _firstMaleGenetive : _firstFemale, powerArray) + s;
                            break;
                        case TextCase.Accusative:
                            s = MakeText(remainder, _hundreds, _tens, _from3Till19, isMale ? _secondMale : _secondFemale, isMale ? _firstMale : _firstFemaleAccusative, powerArray) + s;
                            break;
                        default:
                            s = MakeText(remainder, _hundreds, _tens, _from3Till19, isMale ? _secondMale : _secondFemale, isMale ? _firstMale : _firstFemale, powerArray) + s;
                            break;
                    }
                    break;
            }

            power += 3;
        }

        if (sourceNumber == 0)
        {
            s = _zero + " ";
        }

        if (s != "" && firstCapital)
            s = s.Substring(0, 1).ToUpper() + s.Substring(1);

        return s.Trim();
    }
    public static string NumeralsDoubleToTxt(double sourceNumber, int @decimal, TextCase @case, bool firstCapital)
    {
        long decNum = (long)Math.Round(sourceNumber * Math.Pow(10, @decimal)) % (long)(Math.Pow(10, @decimal));

        string s = String.Format(" {0} целых {1} сотых", NumeralsToTxt((long)sourceNumber, @case, true, firstCapital),
                                              NumeralsToTxt((long)decNum, @case, true, false));
        return s.Trim();
    }
    /// <summary>
    /// название м-ца
    /// </summary>
    /// <param name="_month">с единицы</param>
    /// <param name="_case"></param>
    /// <returns></returns>
    public static string MonthName(int month, TextCase @case)
    {
        string s = "";

        if (month > 0 && month <= 12 && _monthNames.ContainsKey (@case))
        {
            return _monthNames[@case][month];
        }

        return s;
    }
    public static string NumeralsRoman(int number)
    {
        string s = "";

        switch (number)
        {
            case 1: s = "I"; break;
            case 2: s = "II"; break;
            case 3: s = "III"; break;
            case 4: s = "IV"; break;
        }

        return s;
    }
}