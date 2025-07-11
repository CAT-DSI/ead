using EAD.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EAD.Data.Enums
{
    public enum Country
    {
        [CountryCode()]
        [Display(Name = "Unknown")]
        Unknown = 0,

        [CountryCode("AF", "AFG")]
        [Display(Name = "Afganistane")]
        Afganistane = 4,

        [CountryCode("AL", "ALB")]
        [Display(Name = "Albania")]
        Albania = 8,

        [CountryCode("AQ", "ATA")]
        [Display(Name = "Antarctica")]
        Antarctica = 10,

        [CountryCode("DZ", "DZA")]
        [Display(Name = "Algeria")]
        Algeria = 12,

        [CountryCode("AS", "ASM")]
        [Display(Name = "AmericanSamoa")]
        AmericanSamoa = 16,

        /// <summary>
        /// Andora
        /// </summary>
        [CountryCode("AD", "AND")]
        [Display(Name = "Andorra")]
        Andorra = 20,

        /// <summary>
        /// Andora
        /// </summary>
        [CountryCode("AO", "AGO")]
        [Display(Name = "Angola")]
        Angola = 24,

        /// <summary>
        /// Antigua i Barbuda
        /// </summary>
        [CountryCode("AG", "ATG")]
        [Display(Name = "AntiguaAndBarbuda")]
        AntiguaAndBarbuda = 28,

        /// <summary>
        /// Azerbejdżan
        /// </summary>
        [CountryCode("AZ", "AZE")]
        [Display(Name = "Azerbaijan")]
        Azerbaijan = 31,

        /// <summary>
        /// Argentyna
        /// </summary>
        [CountryCode("AR", "ARG")]
        [Display(Name = "Argentina")]
        Argentina = 32,

        /// <summary>
        /// Australia
        /// </summary>
        [CountryCode("AU", "AUS")]
        [Display(Name = "Australia")]
        Australia = 36,

        /// <summary>
        /// Austria
        /// </summary>
        [CountryCode("AT", "AUT")]
        [Display(Name = "Austria")]
        Austria = 40,

        /// <summary>
        /// Bahamy
        /// </summary>
        [CountryCode("BS", "BHS")]
        [Display(Name = "Bahamas")]
        Bahamas = 44,

        /// <summary>
        /// Bahrajn
        /// </summary>
        [CountryCode("BH", "BHR")]
        [Display(Name = "Bahrain")]
        Bahrain = 48,

        /// <summary>
        /// Bangladesz
        /// </summary>
        [CountryCode("BD", "BGD")]
        [Display(Name = "Bangladesh")]
        Bangladesh = 50,

        /// <summary>
        /// Armenia
        /// </summary>
        [CountryCode("AM", "ARM")]
        [Display(Name = "Armenia")]
        Armenia = 51,

        /// <summary>
        /// Barbados
        /// </summary>
        [CountryCode("BB", "BRB")]
        [Display(Name = "Barbados")]
        Barbados = 52,

        /// <summary>
        /// Belgia
        /// </summary>
        [CountryCode("BE", "BEL")]
        [Display(Name = "Belgium")]
        Belgium = 56,

        /// <summary>
        /// Bermudy
        /// </summary>
        [CountryCode("BM", "BMU")]
        [Display(Name = "Bermuda")]
        Bermuda = 60,

        /// <summary>
        /// Bhutan
        /// </summary>
        [CountryCode("BT", "BTN")]
        [Display(Name = "Bhutan")]
        Bhutan = 64,

        /// <summary>
        /// Boliwia
        /// </summary>
        [CountryCode("BO", "BOL")]
        [Display(Name = "Bolivia")]
        Bolivia = 68,

        /// <summary>
        /// Bośnia i Hercegowina
        /// </summary>
        [CountryCode("BA", "BIH")]
        [Display(Name = "BosniaAndHerzegovina")]
        BosniaAndHerzegovina = 70,

        /// <summary>
        /// Botswana
        /// </summary>
        [CountryCode("BW", "BWA")]
        [Display(Name = "Botswana")]
        Botswana = 72,

        /// <summary>
        /// Wyspa Bouveta
        /// </summary>
        [CountryCode("BV", "BVT")]
        [Display(Name = "BouvetIsland")]
        BouvetIsland = 74,

        /// <summary>
        /// Brazylia
        /// </summary>
        [CountryCode("BR", "BRA")]
        [Display(Name = "Brazil")]
        Brazil = 76,

        /// <summary>
        /// Belize
        /// </summary>
        [CountryCode("BZ", "BLZ")]
        [Display(Name = "Belize")]
        Belize = 84,

        /// <summary>
        /// Brytyjskie Terytorium Oceanu Indyjskiego
        /// </summary>
        [CountryCode("IO", "IOT")]
        [Display(Name = "BritishIndianOceanTerritory")]
        BritishIndianOceanTerritory = 86,

        /// <summary>
        /// Wyspy Salomona
        /// </summary>
        [CountryCode("SB", "SLB")]
        [Display(Name = "SolomonIslands")]
        SolomonIslands = 90,

        /// <summary>
        /// Brytyjskie Wyspy Dziewicze
        /// </summary>
        [CountryCode("VG", "VGB")]
        [Display(Name = "BritishVirginIslands")]
        BritishVirginIslands = 92,

        /// <summary>
        /// Brunei
        /// </summary>
        [CountryCode("BN", "BRN")]
        [Display(Name = "BruneiDarussalam")]
        BruneiDarussalam = 96,

        /// <summary>
        /// Bułgaria
        /// </summary>
        [CountryCode("BG", "BGR")]
        [Display(Name = "Bulgaria")]
        Bulgaria = 100,

        /// <summary>
        /// Mjanma
        /// </summary>
        [CountryCode("MM", "MMR")]
        [Display(Name = "Myanmar")]
        Myanmar = 104,

        /// <summary>
        /// Burundi
        /// </summary>
        [CountryCode("BI", "BDI")]
        [Display(Name = "Burundi")]
        Burundi = 108,

        /// <summary>
        /// Białoruś
        /// </summary>
        [CountryCode("BY", "BLR")]
        [Display(Name = "Belarus")]
        Belarus = 112,

        /// <summary>
        /// Kambodża
        /// </summary>
        [CountryCode("KH", "KHM")]
        [Display(Name = "Cambodia")]
        Cambodia = 116,

        /// <summary>
        /// Kamerun
        /// </summary>
        [CountryCode("CM", "CMR")]
        [Display(Name = "Cameroon")]
        Cameroon = 120,

        /// <summary>
        /// Kanada
        /// </summary>
        [CountryCode("CA", "CAN")]
        [Display(Name = "Canada")]
        Canada = 124,

        /// <summary>
        /// Republika Zielonego Przylądka
        /// </summary>
        [CountryCode("CV", "CPV")]
        [Display(Name = "CapeVerde")]
        CapeVerde = 132,

        /// <summary>
        /// Kajmany
        /// </summary>
        [CountryCode("KY", "CYM")]
        [Display(Name = "CaymanIslands")]
        CaymanIslands = 136,

        /// <summary>
        /// Republika Środkowoafrykańska
        /// </summary>
        [CountryCode("CF", "CAF")]
        [Display(Name = "CentralAfricanRepublic")]
        CentralAfricanRepublic = 140,

        /// <summary>
        /// Sri Lanka
        /// </summary>
        [CountryCode("LK", "LKA")]
        [Display(Name = "SriLanka")]
        SriLanka = 144,

        /// <summary>
        /// Czad
        /// </summary>
        [CountryCode("TD", "TCD")]
        [Display(Name = "Chad")]
        Chad = 148,

        /// <summary>
        /// Chile
        /// </summary>
        [CountryCode("CL", "CHL")]
        [Display(Name = "Chile")]
        Chile = 152,

        /// <summary>
        /// Chiny
        /// </summary>
        [CountryCode("CN", "CHN")]
        [Display(Name = "China")]
        China = 156,

        /// <summary>
        /// Tajwan
        /// </summary>
        [CountryCode("TW", "TWN")]
        [Display(Name = "Taiwan")]
        Taiwan = 158,

        /// <summary>
        /// Wyspa Bożego Narodzenia
        /// </summary>
        [CountryCode("CX", "CXR")]
        [Display(Name = "ChristmasIsland")]
        ChristmasIsland = 162,

        /// <summary>
        /// Wyspy Kokosowe
        /// </summary>
        [CountryCode("CC", "CCK")]
        [Display(Name = "CocosIslands")]
        CocosIslands = 166,

        /// <summary>
        /// Kolumbia
        /// </summary>
        [CountryCode("CO", "COL")]
        [Display(Name = "Colombia")]
        Colombia = 170,

        /// <summary>
        /// Komory
        /// </summary>
        [CountryCode("KM", "COM")]
        [Display(Name = "")]
        Comoros = 174,

        /// <summary>
        /// Majotta
        /// </summary>
        [CountryCode("YT", "MYT")]
        [Display(Name = "Mayotte")]
        Mayotte = 175,

        /// <summary>
        /// Kongo
        /// </summary>
        [CountryCode("CG", "COG")]
        [Display(Name = "Congo")]
        Congo = 178,

        /// <summary>
        /// Demokratyczna Republika Konga
        /// </summary>
        [CountryCode("CD", "COD")]
        [Display(Name = "DemocraticRepublicOfCongo")]
        DemocraticRepublicOfCongo = 180,

        /// <summary>
        /// Wyspy Cooka
        /// </summary>
        [CountryCode("CK", "COK")]
        [Display(Name = "CookIslands")]
        CookIslands = 184,

        /// <summary>
        /// Kostaryka
        /// </summary>
        [CountryCode("CR", "CRI")]
        [Display(Name = "CostaRica")]
        CostaRica = 188,

        /// <summary>
        /// Chorwacja
        /// </summary>
        [CountryCode("HR", "HRV")]
        [Display(Name = "Croatia")]
        Croatia = 191,

        /// <summary>
        /// Kuba
        /// </summary>
        [CountryCode("CU", "CUB")]
        [Display(Name = "Cuba")]
        Cuba = 192,

        /// <summary>
        /// Cypr
        /// </summary>
        [CountryCode("CY", "CYP")]
        [Display(Name = "Cyprus")]
        Cyprus = 196,

        /// <summary>
        /// Czechy
        /// </summary>
        [CountryCode("CZ", "CZE")]
        [Display(Name = "Czechia")]
        Czechia = 203,

        /// <summary>
        /// Benin
        /// </summary>
        [CountryCode("BJ", "BEN")]
        [Display(Name = "Benin")]
        Benin = 204,

        /// <summary>
        /// Dania
        /// </summary>
        [CountryCode("DK", "DNK")]
        [Display(Name = "Denmark")]
        Denmark = 208,

        /// <summary>
        /// Dominika
        /// </summary>
        [CountryCode("DM", "DMA")]
        [Display(Name = "Dominica")]
        Dominica = 212,

        /// <summary>
        /// Dominikana
        /// </summary>
        [CountryCode("DO", "DOM")]
        [Display(Name = "DominicanRepublic")]
        DominicanRepublic = 214,

        /// <summary>
        /// Ekwador
        /// </summary>
        [CountryCode("EC", "ECU")]
        [Display(Name = "Ecuador")]
        Ecuador = 218,

        /// <summary>
        /// Salwador
        /// </summary>
        [CountryCode("SV", "SLV")]
        [Display(Name = "ElSalvador")]
        ElSalvador = 222,

        /// <summary>
        /// Gwinea Równikowa
        /// </summary>
        [CountryCode("GQ", "GNQ")]
        [Display(Name = "EquatorialGuinea")]
        EquatorialGuinea = 226,

        /// <summary>
        /// Etiopia
        /// </summary>
        [CountryCode("ET", "ETH")]
        [Display(Name = "Ethiopia")]
        Ethiopia = 231,

        /// <summary>
        /// Erytrea
        /// </summary>
        [CountryCode("ER", "ERI")]
        [Display(Name = "Eritrea")]
        Eritrea = 232,

        /// <summary>
        /// Estonia
        /// </summary>
        [CountryCode("EE", "EST")]
        [Display(Name = "Estonia")]
        Estonia = 233,

        /// <summary>
        /// Wyspy Owcze
        /// </summary>
        [CountryCode("FO", "FRO")]
        [Display(Name = "FaroeIslands")]
        FaroeIslands = 234,

        /// <summary>
        /// Falklandy
        /// </summary>
        [CountryCode("FK", "FLK")]
        [Display(Name = "FalklandIslands")]
        FalklandIslands = 238,

        /// <summary>
        /// Georgia Południowa i Sandwich Południowy
        /// </summary>
        [CountryCode("GS", "SGS")]
        [Display(Name = "SouthGeorgiaAndSandwichIslands")]
        SouthGeorgiaAndSandwichIslands = 239,

        /// <summary>
        /// Fidżi
        /// </summary>
        [CountryCode("FJ", "FJI")]
        [Display(Name = "Fiji")]
        Fiji = 242,

        /// <summary>
        /// Finlandia
        /// </summary>
        [CountryCode("FI", "FIN")]
        [Display(Name = "Finland")]
        Finland = 246,

        /// <summary>
        /// Wyspy Alandzkie
        /// </summary>
        [CountryCode("AX", "ALA")]
        [Display(Name = "AlandIslands")]
        AlandIslands = 248,

        /// <summary>
        /// Francja
        /// </summary>
        [CountryCode("FR", "FRA")]
        [Display(Name = "France")]
        France = 250,

        /// <summary>
        /// Gujana Francuska
        /// </summary>
        [CountryCode("GF", "GUF")]
        [Display(Name = "FrenchGuiana")]
        FrenchGuiana = 254,

        /// <summary>
        /// Polinezja Francuska
        /// </summary>
        [CountryCode("PF", "PYF")]
        [Display(Name = "FrenchPolynesia")]
        FrenchPolynesia = 258,

        /// <summary>
        /// Francuskie Terytoria Południowe i Antarktyczne
        /// </summary>
        [CountryCode("TF", "ATF")]
        [Display(Name = "FrenchSouthernTerritories")]
        FrenchSouthernTerritories = 260,

        /// <summary>
        /// Dżibuti
        /// </summary>
        [CountryCode("DJ", "DJI")]
        [Display(Name = "Djibouti")]
        Djibouti = 262,

        /// <summary>
        /// Gabon
        /// </summary>
        [CountryCode("GA", "GAB")]
        [Display(Name = "Gabon")]
        Gabon = 266,

        /// <summary>
        /// Gruzja
        /// </summary>
        [CountryCode("GE", "GEO")]
        [Display(Name = "Georgia")]
        Georgia = 268,

        /// <summary>
        /// Gambia
        /// </summary>
        [CountryCode("GM", "GMB")]
        [Display(Name = "Gambia")]
        Gambia = 270,

        /// <summary>
        /// Palestyna
        /// </summary>
        [CountryCode("PS", "PSE")]
        [Display(Name = "Palestine")]
        Palestine = 275,

        /// <summary>
        /// Niemcy
        /// </summary>
        [CountryCode("DE", "DEU")]
        [Display(Name = "Germany")]
        Germany = 276,

        /// <summary>
        /// Ghana
        /// </summary>
        [CountryCode("GH", "GHA")]
        [Display(Name = "Ghana")]
        Ghana = 288,

        /// <summary>
        /// Gibraltar
        /// </summary>
        [CountryCode("GI", "GIB")]
        [Display(Name = "Gibraltar")]
        Gibraltar = 292,

        /// <summary>
        /// Kiribati
        /// </summary>
        [CountryCode("KI", "KIR")]
        [Display(Name = "Kiribati")]
        Kiribati = 296,

        /// <summary>
        /// Grecja
        /// </summary>
        [CountryCode("GR", "GRC")]
        [Display(Name = "Greece")]
        Greece = 300,

        /// <summary>
        /// Grenlandia
        /// </summary>
        [CountryCode("GL", "GRL")]
        [Display(Name = "Greenland")]
        Greenland = 304,

        /// <summary>
        /// Grenada
        /// </summary>
        [CountryCode("GD", "GRD")]
        [Display(Name = "Grenada")]
        Grenada = 308,

        /// <summary>
        /// Gwadelupa
        /// </summary>
        [CountryCode("GP", "GLP")]
        [Display(Name = "Guadeloupe")]
        Guadeloupe = 312,

        /// <summary>
        /// Guam
        /// </summary>
        [CountryCode("GU", "GUM")]
        [Display(Name = "Guam")]
        Guam = 316,

        /// <summary>
        /// Gwatemala
        /// </summary>
        [CountryCode("GT", "GTM")]
        [Display(Name = "Guatemala")]
        Guatemala = 320,

        /// <summary>
        /// Gwinea
        /// </summary>
        [CountryCode("GN", "GIN")]
        [Display(Name = "Guinea")]
        Guinea = 324,

        /// <summary>
        /// Gujana
        /// </summary>
        [CountryCode("GY", "GUY")]
        [Display(Name = "Guyana")]
        Guyana = 328,

        /// <summary>
        /// Haiti
        /// </summary>
        [CountryCode("HT", "HTI")]
        [Display(Name = "Haiti")]
        Haiti = 332,

        /// <summary>
        /// Wyspy Heard i McDonalda
        /// </summary>
        [CountryCode("HM", "HMD")]
        [Display(Name = "HeardAndMcDonaldIslands")]
        HeardAndMcDonaldIslands = 334,

        /// <summary>
        /// Watykan
        /// </summary>
        [CountryCode("VA", "VAT")]
        [Display(Name = "Vatican")]
        Vatican = 336,

        /// <summary>
        /// Honduras
        /// </summary>
        [CountryCode("HN", "HND")]
        [Display(Name = "Honduras")]
        Honduras = 340,

        /// <summary>
        /// Hongkong
        /// </summary>
        [CountryCode("HK", "HKG")]
        [Display(Name = "HongKong")]
        HongKong = 344,

        /// <summary>
        /// Węgry
        /// </summary>
        [CountryCode("HU", "HUN")]
        [Display(Name = "Hungary")]
        Hungary = 348,

        /// <summary>
        /// Islandia
        /// </summary>
        [CountryCode("IS", "ISL")]
        [Display(Name = "Iceland")]
        Iceland = 352,

        /// <summary>
        /// Indie
        /// </summary>
        [CountryCode("IN", "IND")]
        [Display(Name = "India")]
        India = 356,

        /// <summary>
        /// Indonezja
        /// </summary>
        [CountryCode("ID", "IDN")]
        [Display(Name = "Indonesia")]
        Indonesia = 360,

        /// <summary>
        /// Iran
        /// </summary>
        [CountryCode("IR", "IRN")]
        [Display(Name = "Iran")]
        Iran = 364,

        /// <summary>
        /// Irak
        /// </summary>
        [CountryCode("IQ", "IRQ")]
        [Display(Name = "Iraq")]
        Iraq = 368,

        /// <summary>
        /// Irlandia
        /// </summary>
        [CountryCode("IE", "IRL")]
        [Display(Name = "Ireland")]
        Ireland = 372,

        /// <summary>
        /// Izrael
        /// </summary>
        [CountryCode("IL", "ISR")]
        [Display(Name = "Israel")]
        Israel = 376,

        /// <summary>
        /// Włochy
        /// </summary>
        [CountryCode("IT", "ITA")]
        [Display(Name = "Italy")]
        Italy = 380,

        /// <summary>
        /// Wybrzeże Kości Słoniowej
        /// </summary>
        [CountryCode("CI", "CIV")]
        [Display(Name = "CoteDIvoire")]
        CoteDIvoire = 384,

        /// <summary>
        /// Jamajka
        /// </summary>
        [CountryCode("JM", "JAM")]
        [Display(Name = "Jamaica")]
        Jamaica = 388,

        /// <summary>
        /// Japonia
        /// </summary>
        [CountryCode("JP", "JPN")]
        [Display(Name = "Japan")]
        Japan = 392,

        /// <summary>
        /// Kazachstan
        /// </summary>
        [CountryCode("KZ", "KAZ")]
        [Display(Name = "Kazakhstan")]
        Kazakhstan = 398,

        /// <summary>
        /// Jordania
        /// </summary>
        [CountryCode("JO", "JOR")]
        [Display(Name = "Jordan")]
        Jordan = 400,

        /// <summary>
        /// Kenia
        /// </summary>
        [CountryCode("KE", "KEN")]
        [Display(Name = "Kenya")]
        Kenya = 404,

        /// <summary>
        /// Korea Północna
        /// </summary>
        [CountryCode("KP", "PRK")]
        [Display(Name = "NorthKorea")]
        NorthKorea = 408,

        /// <summary>
        /// Korea Południowa
        /// </summary>
        [CountryCode("KR", "KOR")]
        [Display(Name = "SouthKorea")]
        SouthKorea = 410,

        /// <summary>
        /// Kuwejt
        /// </summary>
        [CountryCode("KW", "KWT")]
        [Display(Name = "Kuwait")]
        Kuwait = 414,

        /// <summary>
        /// Kirgistan
        /// </summary>
        [CountryCode("KG", "KGZ")]
        [Display(Name = "Kyrgyzstan")]
        Kyrgyzstan = 417,

        /// <summary>
        /// Laos
        /// </summary>
        [CountryCode("LA", "LAO")]
        [Display(Name = "Laos")]
        Laos = 418,

        /// <summary>
        /// Liban
        /// </summary>
        [CountryCode("LB", "LBN")]
        [Display(Name = "Lebanon")]
        Lebanon = 422,

        /// <summary>
        /// Lesotho
        /// </summary>
        [CountryCode("LS", "LSO")]
        [Display(Name = "Lesotho")]
        Lesotho = 426,

        /// <summary>
        /// Łotwa
        /// </summary>
        [CountryCode("LV", "LVA")]
        [Display(Name = "Latvia")]
        Latvia = 428,

        /// <summary>
        /// Liberia
        /// </summary>
        [CountryCode("LR", "LBR")]
        [Display(Name = "Liberia")]
        Liberia = 430,

        /// <summary>
        /// Libia
        /// </summary>
        [CountryCode("LY", "LBY")]
        [Display(Name = "Libya")]
        Libya = 434,

        /// <summary>
        /// Liechtenstein
        /// </summary>
        [CountryCode("LI", "LIE")]
        [Display(Name = "Liechtenstein")]
        Liechtenstein = 438,

        /// <summary>
        /// Litwa
        /// </summary>
        [CountryCode("LT", "LTU")]
        [Display(Name = "Lithuania")]
        Lithuania = 440,

        /// <summary>
        /// Luksemburg
        /// </summary>
        [CountryCode("LU", "LUX")]
        [Display(Name = "Luxembourg")]
        Luxembourg = 442,

        /// <summary>
        /// Makau
        /// </summary>
        [CountryCode("MO", "MAC")]
        [Display(Name = "Macao")]
        Macao = 446,

        /// <summary>
        /// Madagaskar
        /// </summary>
        [CountryCode("MG", "MDG")]
        [Display(Name = "Madagascar")]
        Madagascar = 450,

        /// <summary>
        /// Malawi
        /// </summary>
        [CountryCode("MW", "MWI")]
        [Display(Name = "Malawi")]
        Malawi = 454,

        /// <summary>
        /// Malezja
        /// </summary>
        [CountryCode("MY", "MYS")]
        [Display(Name = "Malaysia")]
        Malaysia = 458,

        /// <summary>
        /// Malediwy
        /// </summary>
        [CountryCode("MV", "MDV")]
        [Display(Name = "Maldives")]
        Maldives = 462,

        /// <summary>
        /// Mali
        /// </summary>
        [CountryCode("ML", "MLI")]
        [Display(Name = "Mali")]
        Mali = 466,

        /// <summary>
        /// Malta
        /// </summary>
        [CountryCode("MT", "MLT")]
        [Display(Name = "Malta")]
        Malta = 470,

        /// <summary>
        /// Martynika
        /// </summary>
        [CountryCode("MQ", "MTQ")]
        [Display(Name = "Martinique")]
        Martinique = 474,

        /// <summary>
        /// Mauretania
        /// </summary>
        [CountryCode("MR", "MRT")]
        [Display(Name = "Mauritania")]
        Mauritania = 478,

        /// <summary>
        /// Mauritius
        /// </summary>
        [CountryCode("MU", "MUS")]
        [Display(Name = "Mauritius")]
        Mauritius = 480,

        /// <summary>
        /// Meksyk
        /// </summary>
        [CountryCode("MX", "MEX")]
        [Display(Name = "Mexico")]
        Mexico = 484,

        /// <summary>
        /// Monako
        /// </summary>
        [CountryCode("MC", "MCO")]
        [Display(Name = "Monaco")]
        Monaco = 492,

        /// <summary>
        /// Mongolia
        /// </summary>
        [CountryCode("MN", "MNG")]
        [Display(Name = "Mongolia")]
        Mongolia = 496,

        /// <summary>
        /// Mołdawia
        /// </summary>
        [CountryCode("MD", "MDA")]
        [Display(Name = "Moldova")]
        Moldova = 498,

        /// <summary>
        /// Czarnogóra
        /// </summary>
        [CountryCode("ME", "MNE")]
        [Display(Name = "Montenegro")]
        Montenegro = 499,

        /// <summary>
        /// Montserrat
        /// </summary>
        [CountryCode("MS", "MSR")]
        [Display(Name = "Montserrat")]
        Montserrat = 500,

        /// <summary>
        /// Maroko
        /// </summary>
        [CountryCode("MA", "MAR")]
        [Display(Name = "Morocco")]
        Morocco = 504,

        /// <summary>
        /// Mozambik
        /// </summary>
        [CountryCode("MZ", "MOZ")]
        [Display(Name = "Mozambique")]
        Mozambique = 508,

        /// <summary>
        /// Oman
        /// </summary>
        [CountryCode("OM", "OMN")]
        [Display(Name = "Oman")]
        Oman = 512,

        /// <summary>
        /// Namibia
        /// </summary>
        [CountryCode("NA", "NAM")]
        [Display(Name = "Namibia")]
        Namibia = 516,

        /// <summary>
        /// Nauru
        /// </summary>
        [CountryCode("NR", "NRU")]
        [Display(Name = "Nauru")]
        Nauru = 520,

        /// <summary>
        /// Nepal
        /// </summary>
        [CountryCode("NP", "NPL")]
        [Display(Name = "Nepal")]
        Nepal = 524,

        /// <summary>
        /// Holandia
        /// </summary>
        [CountryCode("NL", "NLD")]
        [Display(Name = "Netherlands")]
        Netherlands = 528,

        /// <summary>
        /// Curaçao
        /// </summary>
        [CountryCode("CW", "CUW")]
        [Display(Name = "Curaçao")]
        Curaçao = 531,

        /// <summary>
        /// Aruba
        /// </summary>
        [CountryCode("AW", "ABW")]
        [Display(Name = "Aruba")]
        Aruba = 533,

        /// <summary>
        /// Sint Maarten
        /// </summary>
        [CountryCode("SX", "SXM")]
        [Display(Name = "SintMaarten")]
        SintMaarten = 534,

        /// <summary>
        /// Bonaire, Sint Eustatius i Saba
        /// </summary>
        [CountryCode("BQ", "BES")]
        [Display(Name = "Bonaire")]
        Bonaire = 535,

        /// <summary>
        /// Nowa Kaledonia
        /// </summary>
        [CountryCode("NC", "NCL")]
        [Display(Name = "NewCaledonia")]
        NewCaledonia = 540,

        /// <summary>
        /// Vanuatu
        /// </summary>
        [CountryCode("VU", "VUT")]
        [Display(Name = "Vanuatu")]
        Vanuatu = 548,

        /// <summary>
        /// Nowa Zelandia
        /// </summary>
        [CountryCode("NZ", "NZL")]
        [Display(Name = "NewZealand")]
        NewZealand = 554,

        /// <summary>
        /// Nikaragua
        /// </summary>
        [CountryCode("NI", "NIC")]
        [Display(Name = "Nicaragua")]
        Nicaragua = 558,

        /// <summary>
        /// Niger
        /// </summary>
        [CountryCode("NE", "NER")]
        [Display(Name = "Niger")]
        Niger = 562,

        /// <summary>
        /// Nigeria
        /// </summary>
        [CountryCode("NG", "NGA")]
        [Display(Name = "Nigeria")]
        Nigeria = 566,

        /// <summary>
        /// Niue
        /// </summary>
        [CountryCode("NU", "NIU")]
        [Display(Name = "Niue")]
        Niue = 570,

        /// <summary>
        /// Norfolk
        /// </summary>
        [CountryCode("NF", "NFK")]
        [Display(Name = "NorfolkIsland")]
        NorfolkIsland = 574,

        /// <summary>
        /// Norwegia
        /// </summary>
        [CountryCode("NO", "NOR")]
        [Display(Name = "Norway")]
        Norway = 578,

        /// <summary>
        /// Mariany Północne
        /// </summary>
        [CountryCode("MP", "MNP")]
        [Display(Name = "NorthernMarianaIslands")]
        NorthernMarianaIslands = 580,

        /// <summary>
        /// Dalekie Wyspy Mniejsze Stanów Zjednoczonych
        /// </summary>
        [CountryCode("UM", "UMI")]
        [Display(Name = "UnitedStatesMinorOutlyingIslands")]
        UnitedStatesMinorOutlyingIslands = 581,

        /// <summary>
        /// Mikronezja
        /// </summary>
        [CountryCode("FM", "FSM")]
        [Display(Name = "Micronesia")]
        Micronesia = 583,

        /// <summary>
        /// Wyspy Marshalla
        /// </summary>
        [CountryCode("MH", "MHL")]
        [Display(Name = "MarshallIslands")]
        MarshallIslands = 584,

        /// <summary>
        /// Palau
        /// </summary>
        [CountryCode("PW", "PLW")]
        [Display(Name = "Palau")]
        Palau = 585,

        /// <summary>
        /// Pakistan
        /// </summary>
        [CountryCode("PK", "PAK")]
        [Display(Name = "Pakistan")]
        Pakistan = 586,

        /// <summary>
        /// Panama
        /// </summary>
        [CountryCode("PA", "PAN")]
        [Display(Name = "Panama")]
        Panama = 591,

        /// <summary>
        /// Papua-Nowa Gwinea
        /// </summary>
        [CountryCode("PG", "PNG")]
        [Display(Name = "PapuaNewGuinea")]
        PapuaNewGuinea = 598,

        /// <summary>
        /// Paragwaj
        /// </summary>
        [CountryCode("PY", "PRY")]
        [Display(Name = "Paraguay")]
        Paraguay = 600,

        /// <summary>
        /// Peru
        /// </summary>
        [CountryCode("PE", "PER")]
        [Display(Name = "Peru")]
        Peru = 604,

        /// <summary>
        /// Filipiny
        /// </summary>
        [CountryCode("PH", "PHL")]
        [Display(Name = "Philippines")]
        Philippines = 608,

        /// <summary>
        /// Pitcairn
        /// </summary>
        [CountryCode("PN", "PCN")]
        [Display(Name = "Pitcairn")]
        Pitcairn = 612,

        /// <summary>
        /// Polska
        /// </summary>
        [CountryCode("PL", "POL")]
        [Display(Name = "Poland")]
        Poland = 616,

        /// <summary>
        /// Portugalia
        /// </summary>
        [CountryCode("PT", "PRT")]
        [Display(Name = "Portugal")]
        Portugal = 620,

        /// <summary>
        /// Gwinea Bissau
        /// </summary>
        [CountryCode("GW", "GNB")]
        [Display(Name = "GuineaBissau")]
        GuineaBissau = 624,

        /// <summary>
        /// Timor Wschodni
        /// </summary>
        [CountryCode("TL", "TLS")]
        [Display(Name = "TimorLeste")]
        TimorLeste = 626,

        /// <summary>
        /// Portoryko
        /// </summary>
        [CountryCode("PR", "PRI")]
        [Display(Name = "PuertoRico")]
        PuertoRico = 630,

        /// <summary>
        /// Katar
        /// </summary>
        [CountryCode("QA", "QAT")]
        [Display(Name = "Qatar")]
        Qatar = 634,

        /// <summary>
        /// Reunion
        /// </summary>
        [CountryCode("RE", "REU")]
        [Display(Name = "Reunion")]
        Reunion = 638,

        /// <summary>
        /// Rumunia
        /// </summary>
        [CountryCode("RO", "ROU")]
        [Display(Name = "Romania")]
        Romania = 642,

        /// <summary>
        /// Rosja
        /// </summary>
        [CountryCode("RU", "RUS")]
        [Display(Name = "Russia")]
        Russia = 643,

        /// <summary>
        /// Rwanda
        /// </summary>
        [CountryCode("RW", "RWA")]
        [Display(Name = "Rwanda")]
        Rwanda = 646,

        /// <summary>
        /// Saint-Barthélemy
        /// </summary>
        [CountryCode("BL", "BLM")]
        [Display(Name = "SaintBarthelemy")]
        SaintBarthelemy = 652,

        /// <summary>
        /// Wyspa Świętej Heleny, Wyspa Wniebowstąpienia i Tristan da Cunha
        /// </summary>
        [CountryCode("SH", "SHN")]
        [Display(Name = "SaintHelena")]
        SaintHelena = 654,

        /// <summary>
        /// Saint Kitts i Nevis
        /// </summary>
        [CountryCode("KN", "KNA")]
        [Display(Name = "SaintKitts")]
        SaintKitts = 659,

        /// <summary>
        /// Anguilla
        /// </summary>
        [CountryCode("AI", "AIA")]
        [Display(Name = "Anguilla")]
        Anguilla = 660,

        /// <summary>
        /// Saint Lucia
        /// </summary>
        [CountryCode("LC", "LCA")]
        [Display(Name = "SaintLucia")]
        SaintLucia = 662,

        /// <summary>
        /// Saint-Martin
        /// </summary>
        [CountryCode("MF", "MAF")]
        [Display(Name = "SaintMartin")]
        SaintMartin = 663,

        /// <summary>
        /// Saint-Pierre i Miquelon
        /// </summary>
        [CountryCode("PM", "SPM")]
        [Display(Name = "SaintPierreAndMiquelon")]
        SaintPierreAndMiquelon = 666,

        /// <summary>
        /// Saint Vincent i Grenadyny
        /// </summary>
        [CountryCode("VC", "VCT")]
        [Display(Name = "SaintVincentAndGrenadines")]
        SaintVincentAndGrenadines = 670,

        /// <summary>
        /// San Marino
        /// </summary>
        [CountryCode("SM", "SMR")]
        [Display(Name = "SanMarino")]
        SanMarino = 674,

        /// <summary>
        /// Wyspy Świętego Tomasza i Książęca
        /// </summary>
        [CountryCode("ST", "STP")]
        [Display(Name = "SaoTomeAndPrincipe")]
        SaoTomeAndPrincipe = 678,

        /// <summary>
        /// Arabia Saudyjska
        /// </summary>
        [CountryCode("SA", "SAU")]
        [Display(Name = "SaudiArabia")]
        SaudiArabia = 682,

        /// <summary>
        /// Senegal
        /// </summary>
        [CountryCode("SN", "SEN")]
        [Display(Name = "Senegal")]
        Senegal = 686,

        /// <summary>
        /// Serbia
        /// </summary>
        [CountryCode("RS", "SRB")]
        [Display(Name = "Serbia")]
        Serbia = 688,

        /// <summary>
        /// Seszele
        /// </summary>
        [CountryCode("SC", "SYC")]
        [Display(Name = "Seychelles")]
        Seychelles = 690,

        [CountryCode("SL", "SLE")]
        [Display(Name = "SierraLeone")]
        SierraLeone = 694,

        [CountryCode("SG", "SGP")]
        [Display(Name = "Singapore")]
        Singapore = 702,

        [CountryCode("SK", "SVK")]
        [Display(Name = "Slovakia")]
        Slovakia = 703,

        [CountryCode("VN", "VNM")]
        [Display(Name = "Vietnam")]
        Vietnam = 704,

        [CountryCode("SI", "SVN")]
        [Display(Name = "Slovenia")]
        Slovenia = 705,

        [CountryCode("SO", "SOM")]
        [Display(Name = "Somalia")]
        Somalia = 706,

        [CountryCode("ZA", "ZAF")]
        [Display(Name = "SouthAfrica")]
        SouthAfrica = 710,

        [CountryCode("ZW", "ZWE")]
        [Display(Name = "Zimbabwe")]
        Zimbabwe = 716,

        [CountryCode("ES", "ESP")]
        [Display(Name = "Spain")]
        Spain = 724,

        [CountryCode("SS", "SSD")]
        [Display(Name = "SouthSudan")]
        SouthSudan = 728,

        [CountryCode("SD", "SDN")]
        [Display(Name = "Sudan")]
        Sudan = 729,

        [CountryCode("EH", "ESH")]
        [Display(Name = "WesternSahar")]
        WesternSahara = 732,

        [CountryCode("SR", "SUR")]
        [Display(Name = "Suriname")]
        Suriname = 740,

        [CountryCode("SJM", "SJ")]
        [Display(Name = "SvalbardAndJanMayen")]
        SvalbardAndJanMayen = 744,

        [CountryCode("SZ", "SWZ")]
        [Display(Name = "Swaziland")]
        Swaziland = 748,

        [CountryCode("SE", "SWE")]
        [Display(Name = "Sweden")]
        Sweden = 752,

        [CountryCode("CH", "CHE")]
        [Display(Name = "Switzerland")]
        Switzerland = 756,

        [CountryCode("SY", "SYR")]
        [Display(Name = "SyrianArabRepublic")]
        SyrianArabRepublic = 760,

        [CountryCode("TJ", "TJK")]
        [Display(Name = "Tajikistan")]
        Tajikistan = 762,

        [CountryCode("TH", "THA")]
        [Display(Name = "Thailand")]
        Thailand = 764,

        [CountryCode("TG", "TGO")]
        [Display(Name = "Togo")]
        Togo = 768,

        [CountryCode("TK", "TKL")]
        [Display(Name = "Tokelau")]
        Tokelau = 772,

        [CountryCode("TO", "TON")]
        [Display(Name = "Tonga")]
        Tonga = 776,

        [CountryCode("TT", "TTO")]
        [Display(Name = "TrinidadAndTobago")]
        TrinidadAndTobago = 780,

        [CountryCode("AE", "ARE")]
        [Display(Name = "UnitedArabEmirates")]
        UnitedArabEmirates = 784,

        [CountryCode("TN", "TUN")]
        [Display(Name = "Tunisia")]
        Tunisia = 788,

        [CountryCode("TR", "TUR")]
        [Display(Name = "Turkey")]
        Turkey = 792,

        [CountryCode("TM", "TKM")]
        [Display(Name = "Turkmenistan")]
        Turkmenistan = 795,

        [CountryCode("TC", "TCA")]
        [Display(Name = "TurksAndCaicosIslands")]
        TurksAndCaicosIslands = 796,

        [CountryCode("TV", "TUV")]
        [Display(Name = "Tuvalu")]
        Tuvalu = 798,

        [CountryCode("UG", "UGA")]
        [Display(Name = "Uganda")]
        Uganda = 800,

        [CountryCode("UA", "UKR")]
        [Display(Name = "Ukraine")]
        Ukraine = 804,

        [CountryCode("MK", "MKD")]
        [Display(Name = "Macedonia")]
        Macedonia = 807,

        [CountryCode("EG", "EGY")]
        [Display(Name = "Egypt")]
        Egypt = 818,

        [CountryCode("GB", "GBR")]
        [Display(Name = "UnitedKingdom")]
        UnitedKingdom = 826,

        [CountryCode("GG", "GGY")]
        [Display(Name = "Guernsey")]
        Guernsey = 831,

        [CountryCode("JE", "JEY")]
        [Display(Name = "Jersey")]
        Jersey = 832,

        [CountryCode("IM", "IMN")]
        [Display(Name = "IsleOfMan")]
        IsleOfMan = 833,

        [CountryCode("TZ", "TZA")]
        [Display(Name = "Tanzania")]
        Tanzania = 834,

        [CountryCode("US", "USA")]
        [Display(Name = "UnitedStates")]
        UnitedStates = 840,

        [CountryCode("VI", "VIR")]
        [Display(Name = "VirginIslands")]
        VirginIslands = 850,

        [CountryCode("BF", "BFA")]
        [Display(Name = "BurkinaFaso")]
        BurkinaFaso = 854,

        [CountryCode("UY", "URY")]
        [Display(Name = "Uruguay")]
        Uruguay = 858,

        [CountryCode("UZ", "UZB")]
        [Display(Name = "Uzbekistan")]
        Uzbekistan = 860,

        [CountryCode("VE", "VEN")]
        [Display(Name = "Venezuela")]
        Venezuela = 862,

        [CountryCode("WF", "WLF")]
        [Display(Name = "WallisAndFutuna")]
        WallisAndFutuna = 876,

        [CountryCode("WS", "WSM")]
        [Display(Name = "Samoa")]
        Samoa = 882,

        [CountryCode("YE", "YEM")]
        [Display(Name = "Yemen")]
        Yemen = 887,

        [CountryCode("ZM", "ZMB")]
        [Display(Name = "Zambia")]
        Zambia = 894
    }
}