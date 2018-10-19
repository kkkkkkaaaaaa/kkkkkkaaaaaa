﻿namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    // http://msdn.microsoft.com/en-us/library/aa383745%28v=vs.85%29.aspx
    // https://docs.google.com/spreadsheet/ccc?key=0ArV2XEi4eBdpcEs1Q0VjZEc5R1lHZU83SzJkbUVjQmc#gid=0
    // http://msdn.microsoft.com/ja-jp/library/0t2cwe11.aspx#cpcondefaultmarshalingforvaluetypesanchor2
    // http://msdn.microsoft.com/ja-jp/library/windows/desktop/ms724340%28v=vs.85%29.aspx
    // http://msdn.microsoft.com/ja-jp/library/windows/desktop/ms724958%28v=vs.85%29.aspx
    // http://msdn.microsoft.com/en-us/library/cc953fe1.aspx
    // http://msdn.microsoft.com/en-us/library/2e6a4at9.aspx
    // http://msdn.microsoft.com/en-us/library/s3f49ktz.aspx
    // http://msdn.microsoft.com/en-us/library/aa383710
    // http://msdn.microsoft.com/ja-jp/library/0t2cwe11.aspx#cpcondefaultmarshalingforvaluetypesanchor2
    // http://msdn.microsoft.com/en-us/library/aa383745%28v=vs.85%29.aspx
    // 

    // http://msdn.microsoft.com/en-us/library/aa383751
    // http://msdn.microsoft.com/ja-jp/library/ac7ay120.aspx


    // http://msdn.microsoft.com/ja-jp/library/26thfadc%28v=vs.90%29.aspx
    // 
    // 
    // 「Win32 APIやDLL関数を呼び出すには？」
    // http://www.atmarkit.co.jp/fdotnet/dotnettips/024w32api/w32api.html
    // 
    // 「Win32 APIやDLL関数に構造体を渡すには？」
    // http://www.atmarkit.co.jp/fdotnet/dotnettips/026w32struct/w32struct.html
    // 
    // 「型」
    // http://wiki.sh4e.net/?%B7%BF
    // 
    // 「Win32APIを呼び出す」
    // http://www.orangemaker.sakura.ne.jp/labo/memo/CSharp-DotNet/win32Api.html
    // http://msdn.microsoft.com/ja-jp/library/ms172270%28v=vs.90%29.aspx
    // http://msdn.microsoft.com/ja-jp/library/e765dyyy%28v=vs.90%29.aspx
    public static class WinNT
    {
        /// <summary>
        /// #define MAKELANGID(p, s)    ((((WORD)(s)) &lt;&lt; 10) | (WORD)(p))
        /// </summary>
        /// <param name="p"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static uint MAKELANGID(uint p, uint s)
        {
            return ((s << 10) | (p));
        }

        /// <summary>
        /// PRIMARYLANGID(lgid)     ((WORD)(lgid) & 0x3ff)
        /// </summary>
        /// <param name="lgid"></param>
        /// <returns></returns>
        public static uint PRIMARYLANGID(uint lgid)
        {
            return (lgid & 0x3ff);
        }

        /// <summary>
        /// SUBLANGID(lgid)     ((WORD)(lgid) >> 10)
        /// </summary>
        /// <param name="lgid"></param>
        /// <returns></returns>
        public static uint SUBLANGID(uint lgid)
        {
            return (lgid >> 10);
        }


        //
        //  Language IDs.
        //
        //  Note that the named locale APIs (eg GetLocaleInfoEx) are preferred.
        //
        //  Not all locales have unique Language IDs
        //
        //  The following two combinations of primary language ID and
        //  sublanguage ID have special semantics:
        //
        //    Primary Language ID   Sublanguage ID      Result
        //    -------------------   ---------------     ------------------------
        //    LANG_NEUTRAL          SUBLANG_NEUTRAL     Language neutral
        //    LANG_NEUTRAL          SUBLANG_DEFAULT     User default language
        //    LANG_NEUTRAL          SUBLANG_SYS_DEFAULT System default language
        //    LANG_INVARIANT        SUBLANG_NEUTRAL     Invariant locale
        //
        //  It is recommended that applications test for locale names instead of
        //  Language IDs / LCIDs.

        //
        //  Primary language IDs.
        //
        //  WARNING: These aren't always unique.  Bosnian, Serbian & Croation for example.
        //
        //  It is recommended that applications test for locale names or actual LCIDs.
        //
        //  Note that the LANG, SUBLANG construction is not always consistent.
        //  The named locale APIs (eg GetLocaleInfoEx) are recommended.
        //
        public const uint LANG_NEUTRAL = 0x00;
        public const uint LANG_INVARIANT = 0x7f;

        public const uint LANG_AFRIKAANS = 0x36;
        public const uint LANG_ALBANIAN = 0x1c;
        public const uint LANG_ALSATIAN = 0x84;
        public const uint LANG_AMHARIC = 0x5e;
        public const uint LANG_ARABIC = 0x01;
        public const uint LANG_ARMENIAN = 0x2b;
        public const uint LANG_ASSAMESE = 0x4d;
        public const uint LANG_AZERI = 0x2c;
        public const uint LANG_BASHKIR = 0x6d;
        public const uint LANG_BASQUE = 0x2d;
        public const uint LANG_BELARUSIAN = 0x23;
        public const uint LANG_BENGALI = 0x45;
        public const uint LANG_BRETON = 0x7e;
        public const uint LANG_BOSNIAN = 0x1a; // Use with SUBLANG_BOSNIAN_* Sublanguage IDs
        public const uint LANG_BOSNIAN_NEUTRAL = 0x781a; // Use with the ConvertDefaultLocale function
        public const uint LANG_BULGARIAN = 0x02;
        public const uint LANG_CATALAN = 0x03;
        public const uint LANG_CHINESE = 0x04; // Use with SUBLANG_CHINESE_* Sublanguage IDs
        public const uint LANG_CHINESE_SIMPLIFIED = 0x04; // Use with the ConvertDefaultLocale function
        public const uint LANG_CHINESE_TRADITIONAL = 0x7c04; // Use with the ConvertDefaultLocale function
        public const uint LANG_CORSICAN = 0x83;
        public const uint LANG_CROATIAN = 0x1a;
        public const uint LANG_CZECH = 0x05;
        public const uint LANG_DANISH = 0x06;
        public const uint LANG_DARI = 0x8c;
        public const uint LANG_DIVEHI = 0x65;
        public const uint LANG_DUTCH = 0x13;
        public const uint LANG_ENGLISH = 0x09;
        public const uint LANG_ESTONIAN = 0x25;
        public const uint LANG_FAEROESE = 0x38;
        public const uint LANG_FARSI = 0x29; // Deprecated: use LANG_PERSIAN instead
        public const uint LANG_FILIPINO = 0x64;
        public const uint LANG_FINNISH = 0x0b;
        public const uint LANG_FRENCH = 0x0c;
        public const uint LANG_FRISIAN = 0x62;
        public const uint LANG_GALICIAN = 0x56;
        public const uint LANG_GEORGIAN = 0x37;
        public const uint LANG_GERMAN = 0x07;
        public const uint LANG_GREEK = 0x08;
        public const uint LANG_GREENLANDIC = 0x6f;
        public const uint LANG_GUJARATI = 0x47;
        public const uint LANG_HAUSA = 0x68;
        public const uint LANG_HEBREW = 0x0d;
        public const uint LANG_HINDI = 0x39;
        public const uint LANG_HUNGARIAN = 0x0e;
        public const uint LANG_ICELANDIC = 0x0f;
        public const uint LANG_IGBO = 0x70;
        public const uint LANG_INDONESIAN = 0x21;
        public const uint LANG_INUKTITUT = 0x5d;
        public const uint LANG_IRISH = 0x3c; // Use with the SUBLANG_IRISH_IRELAND Sublanguage ID
        public const uint LANG_ITALIAN = 0x10;
        public const uint LANG_JAPANESE = 0x11;
        public const uint LANG_KANNADA = 0x4b;
        public const uint LANG_KASHMIRI = 0x60;
        public const uint LANG_KAZAK = 0x3f;
        public const uint LANG_KHMER = 0x53;
        public const uint LANG_KICHE = 0x86;
        public const uint LANG_KINYARWANDA = 0x87;
        public const uint LANG_KONKANI = 0x57;
        public const uint LANG_KOREAN = 0x12;
        public const uint LANG_KYRGYZ = 0x40;
        public const uint LANG_LAO = 0x54;
        public const uint LANG_LATVIAN = 0x26;
        public const uint LANG_LITHUANIAN = 0x27;
        public const uint LANG_LOWER_SORBIAN = 0x2e;
        public const uint LANG_LUXEMBOURGISH = 0x6e;
        public const uint LANG_MACEDONIAN = 0x2f; // the Former Yugoslav Republic of Macedonia
        public const uint LANG_MALAY = 0x3e;
        public const uint LANG_MALAYALAM = 0x4c;
        public const uint LANG_MALTESE = 0x3a;
        public const uint LANG_MANIPURI = 0x58;
        public const uint LANG_MAORI = 0x81;
        public const uint LANG_MAPUDUNGUN = 0x7a;
        public const uint LANG_MARATHI = 0x4e;
        public const uint LANG_MOHAWK = 0x7c;
        public const uint LANG_MONGOLIAN = 0x50;
        public const uint LANG_NEPALI = 0x61;
        public const uint LANG_NORWEGIAN = 0x14;
        public const uint LANG_OCCITAN = 0x82;
        public const uint LANG_ORIYA = 0x48;
        public const uint LANG_PASHTO = 0x63;
        public const uint LANG_PERSIAN = 0x29;
        public const uint LANG_POLISH = 0x15;
        public const uint LANG_PORTUGUESE = 0x16;
        public const uint LANG_PUNJABI = 0x46;
        public const uint LANG_QUECHUA = 0x6b;
        public const uint LANG_ROMANIAN = 0x18;
        public const uint LANG_ROMANSH = 0x17;
        public const uint LANG_RUSSIAN = 0x19;
        public const uint LANG_SAMI = 0x3b;
        public const uint LANG_SANSKRIT = 0x4f;
        public const uint LANG_SCOTTISH_GAELIC = 0x91;
        public const uint LANG_SERBIAN = 0x1a; // Use with the SUBLANG_SERBIAN_* Sublanguage IDs
        public const uint LANG_SERBIAN_NEUTRAL = 0x7c1a; // Use with the ConvertDefaultLocale function
        public const uint LANG_SINDHI = 0x59;
        public const uint LANG_SINHALESE = 0x5b;
        public const uint LANG_SLOVAK = 0x1b;
        public const uint LANG_SLOVENIAN = 0x24;
        public const uint LANG_SOTHO = 0x6c;
        public const uint LANG_SPANISH = 0x0a;
        public const uint LANG_SWAHILI = 0x41;
        public const uint LANG_SWEDISH = 0x1d;
        public const uint LANG_SYRIAC = 0x5a;
        public const uint LANG_TAJIK = 0x28;
        public const uint LANG_TAMAZIGHT = 0x5f;
        public const uint LANG_TAMIL = 0x49;
        public const uint LANG_TATAR = 0x44;
        public const uint LANG_TELUGU = 0x4a;
        public const uint LANG_THAI = 0x1e;
        public const uint LANG_TIBETAN = 0x51;
        public const uint LANG_TIGRIGNA = 0x73;
        public const uint LANG_TSWANA = 0x32;
        public const uint LANG_TURKISH = 0x1f;
        public const uint LANG_TURKMEN = 0x42;
        public const uint LANG_UIGHUR = 0x80;
        public const uint LANG_UKRAINIAN = 0x22;
        public const uint LANG_UPPER_SORBIAN = 0x2e;
        public const uint LANG_URDU = 0x20;
        public const uint LANG_UZBEK = 0x43;
        public const uint LANG_VIETNAMESE = 0x2a;
        public const uint LANG_WELSH = 0x52;
        public const uint LANG_WOLOF = 0x88;
        public const uint LANG_XHOSA = 0x34;
        public const uint LANG_YAKUT = 0x85;
        public const uint LANG_YI = 0x78;
        public const uint LANG_YORUBA = 0x6a;
        public const uint LANG_ZULU = 0x35;

        //
        //  Sublanguage IDs.
        //
        //  The name immediately following SUBLANG_ dictates which primary
        //  language ID that sublanguage ID can be combined with to form a
        //  valid language ID.
        //
        //  Note that the LANG, SUBLANG construction is not always consistent.
        //  The named locale APIs (eg GetLocaleInfoEx) are recommended.
        //
        public const uint SUBLANG_NEUTRAL = 0x00; // language neutral
        public const uint SUBLANG_DEFAULT = 0x01; // user default
        /*
        #define SUBLANG_NEUTRAL                             0x00    // language neutral
        #define SUBLANG_DEFAULT                             0x01    // user default
        #define SUBLANG_SYS_DEFAULT                         0x02    // system default
        #define SUBLANG_CUSTOM_DEFAULT                      0x03    // default custom language/locale
        #define SUBLANG_CUSTOM_UNSPECIFIED                  0x04    // custom language/locale
        #define SUBLANG_UI_CUSTOM_DEFAULT                   0x05    // Default custom MUI language/locale


        #define SUBLANG_AFRIKAANS_SOUTH_AFRICA              0x01    // Afrikaans (South Africa) 0x0436 af-ZA
        #define SUBLANG_ALBANIAN_ALBANIA                    0x01    // Albanian (Albania) 0x041c sq-AL
        #define SUBLANG_ALSATIAN_FRANCE                     0x01    // Alsatian (France) 0x0484
        #define SUBLANG_AMHARIC_ETHIOPIA                    0x01    // Amharic (Ethiopia) 0x045e
        #define SUBLANG_ARABIC_SAUDI_ARABIA                 0x01    // Arabic (Saudi Arabia)
        #define SUBLANG_ARABIC_IRAQ                         0x02    // Arabic (Iraq)
        #define SUBLANG_ARABIC_EGYPT                        0x03    // Arabic (Egypt)
        #define SUBLANG_ARABIC_LIBYA                        0x04    // Arabic (Libya)
        #define SUBLANG_ARABIC_ALGERIA                      0x05    // Arabic (Algeria)
        #define SUBLANG_ARABIC_MOROCCO                      0x06    // Arabic (Morocco)
        #define SUBLANG_ARABIC_TUNISIA                      0x07    // Arabic (Tunisia)
        #define SUBLANG_ARABIC_OMAN                         0x08    // Arabic (Oman)
        #define SUBLANG_ARABIC_YEMEN                        0x09    // Arabic (Yemen)
        #define SUBLANG_ARABIC_SYRIA                        0x0a    // Arabic (Syria)
        #define SUBLANG_ARABIC_JORDAN                       0x0b    // Arabic (Jordan)
        #define SUBLANG_ARABIC_LEBANON                      0x0c    // Arabic (Lebanon)
        #define SUBLANG_ARABIC_KUWAIT                       0x0d    // Arabic (Kuwait)
        #define SUBLANG_ARABIC_UAE                          0x0e    // Arabic (U.A.E)
        #define SUBLANG_ARABIC_BAHRAIN                      0x0f    // Arabic (Bahrain)
        #define SUBLANG_ARABIC_QATAR                        0x10    // Arabic (Qatar)
        #define SUBLANG_ARMENIAN_ARMENIA                    0x01    // Armenian (Armenia) 0x042b hy-AM
        #define SUBLANG_ASSAMESE_INDIA                      0x01    // Assamese (India) 0x044d
        #define SUBLANG_AZERI_LATIN                         0x01    // Azeri (Latin)
        #define SUBLANG_AZERI_CYRILLIC                      0x02    // Azeri (Cyrillic)
        #define SUBLANG_BASHKIR_RUSSIA                      0x01    // Bashkir (Russia) 0x046d ba-RU
        #define SUBLANG_BASQUE_BASQUE                       0x01    // Basque (Basque) 0x042d eu-ES
        #define SUBLANG_BELARUSIAN_BELARUS                  0x01    // Belarusian (Belarus) 0x0423 be-BY
        #define SUBLANG_BENGALI_INDIA                       0x01    // Bengali (India)
        #define SUBLANG_BENGALI_BANGLADESH                  0x02    // Bengali (Bangladesh)
        #define SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_LATIN    0x05    // Bosnian (Bosnia and Herzegovina - Latin) 0x141a bs-BA-Latn
        #define SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_CYRILLIC 0x08    // Bosnian (Bosnia and Herzegovina - Cyrillic) 0x201a bs-BA-Cyrl
        #define SUBLANG_BRETON_FRANCE                       0x01    // Breton (France) 0x047e
        #define SUBLANG_BULGARIAN_BULGARIA                  0x01    // Bulgarian (Bulgaria) 0x0402
        #define SUBLANG_CATALAN_CATALAN                     0x01    // Catalan (Catalan) 0x0403
        #define SUBLANG_CHINESE_TRADITIONAL                 0x01    // Chinese (Taiwan) 0x0404 zh-TW
        #define SUBLANG_CHINESE_SIMPLIFIED                  0x02    // Chinese (PR China) 0x0804 zh-CN
        #define SUBLANG_CHINESE_HONGKONG                    0x03    // Chinese (Hong Kong S.A.R., P.R.C.) 0x0c04 zh-HK
        #define SUBLANG_CHINESE_SINGAPORE                   0x04    // Chinese (Singapore) 0x1004 zh-SG
        #define SUBLANG_CHINESE_MACAU                       0x05    // Chinese (Macau S.A.R.) 0x1404 zh-MO
        #define SUBLANG_CORSICAN_FRANCE                     0x01    // Corsican (France) 0x0483
        #define SUBLANG_CZECH_CZECH_REPUBLIC                0x01    // Czech (Czech Republic) 0x0405
        #define SUBLANG_CROATIAN_CROATIA                    0x01    // Croatian (Croatia)
        #define SUBLANG_CROATIAN_BOSNIA_HERZEGOVINA_LATIN   0x04    // Croatian (Bosnia and Herzegovina - Latin) 0x101a hr-BA
        #define SUBLANG_DANISH_DENMARK                      0x01    // Danish (Denmark) 0x0406
        #define SUBLANG_DARI_AFGHANISTAN                    0x01    // Dari (Afghanistan)
        #define SUBLANG_DIVEHI_MALDIVES                     0x01    // Divehi (Maldives) 0x0465 div-MV
        #define SUBLANG_DUTCH                               0x01    // Dutch
        #define SUBLANG_DUTCH_BELGIAN                       0x02    // Dutch (Belgian)
        #define SUBLANG_ENGLISH_US                          0x01    // English (USA)
        #define SUBLANG_ENGLISH_UK                          0x02    // English (UK)
        #define SUBLANG_ENGLISH_AUS                         0x03    // English (Australian)
        #define SUBLANG_ENGLISH_CAN                         0x04    // English (Canadian)
        #define SUBLANG_ENGLISH_NZ                          0x05    // English (New Zealand)
        #define SUBLANG_ENGLISH_EIRE                        0x06    // English (Irish)
        #define SUBLANG_ENGLISH_SOUTH_AFRICA                0x07    // English (South Africa)
        #define SUBLANG_ENGLISH_JAMAICA                     0x08    // English (Jamaica)
        #define SUBLANG_ENGLISH_CARIBBEAN                   0x09    // English (Caribbean)
        #define SUBLANG_ENGLISH_BELIZE                      0x0a    // English (Belize)
        #define SUBLANG_ENGLISH_TRINIDAD                    0x0b    // English (Trinidad)
        #define SUBLANG_ENGLISH_ZIMBABWE                    0x0c    // English (Zimbabwe)
        #define SUBLANG_ENGLISH_PHILIPPINES                 0x0d    // English (Philippines)
        #define SUBLANG_ENGLISH_INDIA                       0x10    // English (India)
        #define SUBLANG_ENGLISH_MALAYSIA                    0x11    // English (Malaysia)
        #define SUBLANG_ENGLISH_SINGAPORE                   0x12    // English (Singapore)
        #define SUBLANG_ESTONIAN_ESTONIA                    0x01    // Estonian (Estonia) 0x0425 et-EE
        #define SUBLANG_FAEROESE_FAROE_ISLANDS              0x01    // Faroese (Faroe Islands) 0x0438 fo-FO
        #define SUBLANG_FILIPINO_PHILIPPINES                0x01    // Filipino (Philippines) 0x0464 fil-PH
        #define SUBLANG_FINNISH_FINLAND                     0x01    // Finnish (Finland) 0x040b
        #define SUBLANG_FRENCH                              0x01    // French
        #define SUBLANG_FRENCH_BELGIAN                      0x02    // French (Belgian)
        #define SUBLANG_FRENCH_CANADIAN                     0x03    // French (Canadian)
        #define SUBLANG_FRENCH_SWISS                        0x04    // French (Swiss)
        #define SUBLANG_FRENCH_LUXEMBOURG                   0x05    // French (Luxembourg)
        #define SUBLANG_FRENCH_MONACO                       0x06    // French (Monaco)
        #define SUBLANG_FRISIAN_NETHERLANDS                 0x01    // Frisian (Netherlands) 0x0462 fy-NL
        #define SUBLANG_GALICIAN_GALICIAN                   0x01    // Galician (Galician) 0x0456 gl-ES
        #define SUBLANG_GEORGIAN_GEORGIA                    0x01    // Georgian (Georgia) 0x0437 ka-GE
        #define SUBLANG_GERMAN                              0x01    // German
        #define SUBLANG_GERMAN_SWISS                        0x02    // German (Swiss)
        #define SUBLANG_GERMAN_AUSTRIAN                     0x03    // German (Austrian)
        #define SUBLANG_GERMAN_LUXEMBOURG                   0x04    // German (Luxembourg)
        #define SUBLANG_GERMAN_LIECHTENSTEIN                0x05    // German (Liechtenstein)
        #define SUBLANG_GREEK_GREECE                        0x01    // Greek (Greece)
        #define SUBLANG_GREENLANDIC_GREENLAND               0x01    // Greenlandic (Greenland) 0x046f kl-GL
        #define SUBLANG_GUJARATI_INDIA                      0x01    // Gujarati (India (Gujarati Script)) 0x0447 gu-IN
        #define SUBLANG_HAUSA_NIGERIA_LATIN                 0x01    // Hausa (Latin, Nigeria) 0x0468 ha-NG-Latn
        #define SUBLANG_HEBREW_ISRAEL                       0x01    // Hebrew (Israel) 0x040d
        #define SUBLANG_HINDI_INDIA                         0x01    // Hindi (India) 0x0439 hi-IN
        #define SUBLANG_HUNGARIAN_HUNGARY                   0x01    // Hungarian (Hungary) 0x040e
        #define SUBLANG_ICELANDIC_ICELAND                   0x01    // Icelandic (Iceland) 0x040f
        #define SUBLANG_IGBO_NIGERIA                        0x01    // Igbo (Nigeria) 0x0470 ig-NG
        #define SUBLANG_INDONESIAN_INDONESIA                0x01    // Indonesian (Indonesia) 0x0421 id-ID
        #define SUBLANG_INUKTITUT_CANADA                    0x01    // Inuktitut (Syllabics) (Canada) 0x045d iu-CA-Cans
        #define SUBLANG_INUKTITUT_CANADA_LATIN              0x02    // Inuktitut (Canada - Latin)
        #define SUBLANG_IRISH_IRELAND                       0x02    // Irish (Ireland)
        #define SUBLANG_ITALIAN                             0x01    // Italian
        #define SUBLANG_ITALIAN_SWISS                       0x02    // Italian (Swiss)
        #define SUBLANG_JAPANESE_JAPAN                      0x01    // Japanese (Japan) 0x0411
        #define SUBLANG_KANNADA_INDIA                       0x01    // Kannada (India (Kannada Script)) 0x044b kn-IN
        #define SUBLANG_KASHMIRI_SASIA                      0x02    // Kashmiri (South Asia)
        #define SUBLANG_KASHMIRI_INDIA                      0x02    // For app compatibility only
        #define SUBLANG_KAZAK_KAZAKHSTAN                    0x01    // Kazakh (Kazakhstan) 0x043f kk-KZ
        #define SUBLANG_KHMER_CAMBODIA                      0x01    // Khmer (Cambodia) 0x0453 kh-KH
        #define SUBLANG_KICHE_GUATEMALA                     0x01    // K'iche (Guatemala)
        #define SUBLANG_KINYARWANDA_RWANDA                  0x01    // Kinyarwanda (Rwanda) 0x0487 rw-RW
        #define SUBLANG_KONKANI_INDIA                       0x01    // Konkani (India) 0x0457 kok-IN
        #define SUBLANG_KOREAN                              0x01    // Korean (Extended Wansung)
        #define SUBLANG_KYRGYZ_KYRGYZSTAN                   0x01    // Kyrgyz (Kyrgyzstan) 0x0440 ky-KG
        #define SUBLANG_LAO_LAO                             0x01    // Lao (Lao PDR) 0x0454 lo-LA
        #define SUBLANG_LATVIAN_LATVIA                      0x01    // Latvian (Latvia) 0x0426 lv-LV
        #define SUBLANG_LITHUANIAN                          0x01    // Lithuanian
        #define SUBLANG_LOWER_SORBIAN_GERMANY               0x02    // Lower Sorbian (Germany) 0x082e wee-DE
        #define SUBLANG_LUXEMBOURGISH_LUXEMBOURG            0x01    // Luxembourgish (Luxembourg) 0x046e lb-LU
        #define SUBLANG_MACEDONIAN_MACEDONIA                0x01    // Macedonian (Macedonia (FYROM)) 0x042f mk-MK
        #define SUBLANG_MALAY_MALAYSIA                      0x01    // Malay (Malaysia)
        #define SUBLANG_MALAY_BRUNEI_DARUSSALAM             0x02    // Malay (Brunei Darussalam)
        #define SUBLANG_MALAYALAM_INDIA                     0x01    // Malayalam (India (Malayalam Script) ) 0x044c ml-IN
        #define SUBLANG_MALTESE_MALTA                       0x01    // Maltese (Malta) 0x043a mt-MT
        #define SUBLANG_MAORI_NEW_ZEALAND                   0x01    // Maori (New Zealand) 0x0481 mi-NZ
        #define SUBLANG_MAPUDUNGUN_CHILE                    0x01    // Mapudungun (Chile) 0x047a arn-CL
        #define SUBLANG_MARATHI_INDIA                       0x01    // Marathi (India) 0x044e mr-IN
        #define SUBLANG_MOHAWK_MOHAWK                       0x01    // Mohawk (Mohawk) 0x047c moh-CA
        #define SUBLANG_MONGOLIAN_CYRILLIC_MONGOLIA         0x01    // Mongolian (Cyrillic, Mongolia)
        #define SUBLANG_MONGOLIAN_PRC                       0x02    // Mongolian (PRC)
        #define SUBLANG_NEPALI_INDIA                        0x02    // Nepali (India)
        #define SUBLANG_NEPALI_NEPAL                        0x01    // Nepali (Nepal) 0x0461 ne-NP
        #define SUBLANG_NORWEGIAN_BOKMAL                    0x01    // Norwegian (Bokmal)
        #define SUBLANG_NORWEGIAN_NYNORSK                   0x02    // Norwegian (Nynorsk)
        #define SUBLANG_OCCITAN_FRANCE                      0x01    // Occitan (France) 0x0482 oc-FR
        #define SUBLANG_ORIYA_INDIA                         0x01    // Oriya (India (Oriya Script)) 0x0448 or-IN
        #define SUBLANG_PASHTO_AFGHANISTAN                  0x01    // Pashto (Afghanistan)
        #define SUBLANG_PERSIAN_IRAN                        0x01    // Persian (Iran) 0x0429 fa-IR
        #define SUBLANG_POLISH_POLAND                       0x01    // Polish (Poland) 0x0415
        #define SUBLANG_PORTUGUESE                          0x02    // Portuguese
        #define SUBLANG_PORTUGUESE_BRAZILIAN                0x01    // Portuguese (Brazilian)
        #define SUBLANG_PUNJABI_INDIA                       0x01    // Punjabi (India (Gurmukhi Script)) 0x0446 pa-IN
        #define SUBLANG_QUECHUA_BOLIVIA                     0x01    // Quechua (Bolivia)
        #define SUBLANG_QUECHUA_ECUADOR                     0x02    // Quechua (Ecuador)
        #define SUBLANG_QUECHUA_PERU                        0x03    // Quechua (Peru)
        #define SUBLANG_ROMANIAN_ROMANIA                    0x01    // Romanian (Romania) 0x0418
        #define SUBLANG_ROMANSH_SWITZERLAND                 0x01    // Romansh (Switzerland) 0x0417 rm-CH
        #define SUBLANG_RUSSIAN_RUSSIA                      0x01    // Russian (Russia) 0x0419
        #define SUBLANG_SAMI_NORTHERN_NORWAY                0x01    // Northern Sami (Norway)
        #define SUBLANG_SAMI_NORTHERN_SWEDEN                0x02    // Northern Sami (Sweden)
        #define SUBLANG_SAMI_NORTHERN_FINLAND               0x03    // Northern Sami (Finland)
        #define SUBLANG_SAMI_LULE_NORWAY                    0x04    // Lule Sami (Norway)
        #define SUBLANG_SAMI_LULE_SWEDEN                    0x05    // Lule Sami (Sweden)
        #define SUBLANG_SAMI_SOUTHERN_NORWAY                0x06    // Southern Sami (Norway)
        #define SUBLANG_SAMI_SOUTHERN_SWEDEN                0x07    // Southern Sami (Sweden)
        #define SUBLANG_SAMI_SKOLT_FINLAND                  0x08    // Skolt Sami (Finland)
        #define SUBLANG_SAMI_INARI_FINLAND                  0x09    // Inari Sami (Finland)
        #define SUBLANG_SANSKRIT_INDIA                      0x01    // Sanskrit (India) 0x044f sa-IN
        #define SUBLANG_SCOTTISH_GAELIC                     0x01    // Scottish Gaelic (United Kingdom) 0x0491 gd-GB
        #define SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_LATIN    0x06    // Serbian (Bosnia and Herzegovina - Latin)
        #define SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_CYRILLIC 0x07    // Serbian (Bosnia and Herzegovina - Cyrillic)
        #define SUBLANG_SERBIAN_MONTENEGRO_LATIN            0x0b    // Serbian (Montenegro - Latn)
        #define SUBLANG_SERBIAN_MONTENEGRO_CYRILLIC         0x0c    // Serbian (Montenegro - Cyrillic)
        #define SUBLANG_SERBIAN_SERBIA_LATIN                0x09    // Serbian (Serbia - Latin)
        #define SUBLANG_SERBIAN_SERBIA_CYRILLIC             0x0a    // Serbian (Serbia - Cyrillic)
        #define SUBLANG_SERBIAN_CROATIA                     0x01    // Croatian (Croatia) 0x041a hr-HR
        #define SUBLANG_SERBIAN_LATIN                       0x02    // Serbian (Latin)
        #define SUBLANG_SERBIAN_CYRILLIC                    0x03    // Serbian (Cyrillic)
        #define SUBLANG_SINDHI_INDIA                        0x01    // Sindhi (India) reserved 0x0459
        #define SUBLANG_SINDHI_PAKISTAN                     0x02    // Sindhi (Pakistan) reserved 0x0859
        #define SUBLANG_SINDHI_AFGHANISTAN                  0x02    // For app compatibility only
        #define SUBLANG_SINHALESE_SRI_LANKA                 0x01    // Sinhalese (Sri Lanka)
        #define SUBLANG_SOTHO_NORTHERN_SOUTH_AFRICA         0x01    // Northern Sotho (South Africa)
        #define SUBLANG_SLOVAK_SLOVAKIA                     0x01    // Slovak (Slovakia) 0x041b sk-SK
        #define SUBLANG_SLOVENIAN_SLOVENIA                  0x01    // Slovenian (Slovenia) 0x0424 sl-SI
        #define SUBLANG_SPANISH                             0x01    // Spanish (Castilian)
        #define SUBLANG_SPANISH_MEXICAN                     0x02    // Spanish (Mexican)
        #define SUBLANG_SPANISH_MODERN                      0x03    // Spanish (Modern)
        #define SUBLANG_SPANISH_GUATEMALA                   0x04    // Spanish (Guatemala)
        #define SUBLANG_SPANISH_COSTA_RICA                  0x05    // Spanish (Costa Rica)
        #define SUBLANG_SPANISH_PANAMA                      0x06    // Spanish (Panama)
        #define SUBLANG_SPANISH_DOMINICAN_REPUBLIC          0x07    // Spanish (Dominican Republic)
        #define SUBLANG_SPANISH_VENEZUELA                   0x08    // Spanish (Venezuela)
        #define SUBLANG_SPANISH_COLOMBIA                    0x09    // Spanish (Colombia)
        #define SUBLANG_SPANISH_PERU                        0x0a    // Spanish (Peru)
        #define SUBLANG_SPANISH_ARGENTINA                   0x0b    // Spanish (Argentina)
        #define SUBLANG_SPANISH_ECUADOR                     0x0c    // Spanish (Ecuador)
        #define SUBLANG_SPANISH_CHILE                       0x0d    // Spanish (Chile)
        #define SUBLANG_SPANISH_URUGUAY                     0x0e    // Spanish (Uruguay)
        #define SUBLANG_SPANISH_PARAGUAY                    0x0f    // Spanish (Paraguay)
        #define SUBLANG_SPANISH_BOLIVIA                     0x10    // Spanish (Bolivia)
        #define SUBLANG_SPANISH_EL_SALVADOR                 0x11    // Spanish (El Salvador)
        #define SUBLANG_SPANISH_HONDURAS                    0x12    // Spanish (Honduras)
        #define SUBLANG_SPANISH_NICARAGUA                   0x13    // Spanish (Nicaragua)
        #define SUBLANG_SPANISH_PUERTO_RICO                 0x14    // Spanish (Puerto Rico)
        #define SUBLANG_SPANISH_US                          0x15    // Spanish (United States)
        #define SUBLANG_SWAHILI_KENYA                       0x01    // Swahili (Kenya) 0x0441 sw-KE
        #define SUBLANG_SWEDISH                             0x01    // Swedish
        #define SUBLANG_SWEDISH_FINLAND                     0x02    // Swedish (Finland)
        #define SUBLANG_SYRIAC_SYRIA                        0x01    // Syriac (Syria) 0x045a syr-SY
        #define SUBLANG_TAJIK_TAJIKISTAN                    0x01    // Tajik (Tajikistan) 0x0428 tg-TJ-Cyrl
        #define SUBLANG_TAMAZIGHT_ALGERIA_LATIN             0x02    // Tamazight (Latin, Algeria) 0x085f tmz-DZ-Latn
        #define SUBLANG_TAMIL_INDIA                         0x01    // Tamil (India)
        #define SUBLANG_TATAR_RUSSIA                        0x01    // Tatar (Russia) 0x0444 tt-RU
        #define SUBLANG_TELUGU_INDIA                        0x01    // Telugu (India (Telugu Script)) 0x044a te-IN
        #define SUBLANG_THAI_THAILAND                       0x01    // Thai (Thailand) 0x041e th-TH
        #define SUBLANG_TIBETAN_PRC                         0x01    // Tibetan (PRC)
        #define SUBLANG_TIGRIGNA_ERITREA                    0x02    // Tigrigna (Eritrea)
        #define SUBLANG_TSWANA_SOUTH_AFRICA                 0x01    // Setswana / Tswana (South Africa) 0x0432 tn-ZA
        #define SUBLANG_TURKISH_TURKEY                      0x01    // Turkish (Turkey) 0x041f tr-TR
        #define SUBLANG_TURKMEN_TURKMENISTAN                0x01    // Turkmen (Turkmenistan) 0x0442 tk-TM
        #define SUBLANG_UIGHUR_PRC                          0x01    // Uighur (PRC) 0x0480 ug-CN
        #define SUBLANG_UKRAINIAN_UKRAINE                   0x01    // Ukrainian (Ukraine) 0x0422 uk-UA
        #define SUBLANG_UPPER_SORBIAN_GERMANY               0x01    // Upper Sorbian (Germany) 0x042e wen-DE
        #define SUBLANG_URDU_PAKISTAN                       0x01    // Urdu (Pakistan)
        #define SUBLANG_URDU_INDIA                          0x02    // Urdu (India)
        #define SUBLANG_UZBEK_LATIN                         0x01    // Uzbek (Latin)
        #define SUBLANG_UZBEK_CYRILLIC                      0x02    // Uzbek (Cyrillic)
        #define SUBLANG_VIETNAMESE_VIETNAM                  0x01    // Vietnamese (Vietnam) 0x042a vi-VN
        #define SUBLANG_WELSH_UNITED_KINGDOM                0x01    // Welsh (United Kingdom) 0x0452 cy-GB
        #define SUBLANG_WOLOF_SENEGAL                       0x01    // Wolof (Senegal)
        #define SUBLANG_XHOSA_SOUTH_AFRICA                  0x01    // isiXhosa / Xhosa (South Africa) 0x0434 xh-ZA
        #define SUBLANG_YAKUT_RUSSIA                        0x01    // Yakut (Russia) 0x0485 sah-RU
        #define SUBLANG_YI_PRC                              0x01    // Yi (PRC)) 0x0478
        #define SUBLANG_YORUBA_NIGERIA                      0x01    // Yoruba (Nigeria) 046a yo-NG
        #define SUBLANG_ZULU_SOUTH_AFRICA                   0x01    // isiZulu / Zulu (South Africa) 0x0435 zu-ZA
        */

        public const ushort PROCESSOR_ARCHITECTURE_INTEL = 0;
        public const ushort PROCESSOR_ARCHITECTURE_MIPS = 1;
        public const ushort PROCESSOR_ARCHITECTURE_ALPHA = 2;
        public const ushort PROCESSOR_ARCHITECTURE_PPC = 3;
        public const ushort PROCESSOR_ARCHITECTURE_SHX = 4;
        public const ushort PROCESSOR_ARCHITECTURE_ARM = 5;
        public const ushort PROCESSOR_ARCHITECTURE_IA64 = 6;
        public const ushort PROCESSOR_ARCHITECTURE_ALPHA64 = 7;
        public const ushort PROCESSOR_ARCHITECTURE_MSIL = 8;
        public const ushort PROCESSOR_ARCHITECTURE_AMD64 = 9;
        public const ushort PROCESSOR_ARCHITECTURE_IA32_ON_WIN64 = 10;
        public const ushort PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF;

        public const uint PROCESSOR_INTEL_386 = 386;
        public const uint PROCESSOR_INTEL_486 = 486;
        public const uint PROCESSOR_INTEL_PENTIUM = 586;
        public const uint PROCESSOR_INTEL_IA64 = 2200;
        public const uint PROCESSOR_AMD_X8664 = 8664;
        public const uint PROCESSOR_MIPS_R4000 = 4000; // incl R4101 & R3910 for Windows CE
        public const uint PROCESSOR_ALPHA_21064 = 21064;
        public const uint PROCESSOR_PPC_601 = 601;
        public const uint PROCESSOR_PPC_603 = 603;
        public const uint PROCESSOR_PPC_604 = 604;
        public const uint PROCESSOR_PPC_620 = 620;
        public const uint PROCESSOR_HITACHI_SH3 = 10003; // Windows CE
        public const uint PROCESSOR_HITACHI_SH3E = 10004; // Windows CE
        public const uint PROCESSOR_HITACHI_SH4 = 10005; // Windows CE
        public const uint PROCESSOR_MOTOROLA_821 = 821; // Windows CE
        public const uint PROCESSOR_SHx_SH3 = 103; // Windows CE
        public const uint PROCESSOR_SHx_SH4 = 104; // Windows CE
        public const uint PROCESSOR_STRONGARM = 2577; // Windows CE - 0xA11
        public const uint PROCESSOR_ARM720 = 1824; // Windows CE - 0x720
        public const uint PROCESSOR_ARM820 = 2080; // Windows CE - 0x820
        public const uint PROCESSOR_ARM920 = 2336; // Windows CE - 0x920
        public const uint PROCESSOR_ARM_7TDMI = 70001; // Windows CE
        public const uint PROCESSOR_OPTIL = 0x494f; // MSIL

        public const uint FILE_ATTRIBUTE_READONLY = 0x00000001;
        public const uint FILE_ATTRIBUTE_HIDDEN = 0x00000002;
        public const uint FILE_ATTRIBUTE_SYSTEM = 0x00000004;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        public const uint FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
        public const uint FILE_ATTRIBUTE_DEVICE = 0x00000040;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        public const uint FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
        public const uint FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200;
        public const uint FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;
        public const uint FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
        public const uint FILE_ATTRIBUTE_OFFLINE = 0x00001000;
        public const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
        public const uint FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
        public const uint FILE_ATTRIBUTE_VIRTUAL = 0x00010000;

        public const int IS_TEXT_UNICODE_ASCII16 = 0x0001;
        public const int IS_TEXT_UNICODE_REVERSE_ASCII16 = 0x0010;
        public const int IS_TEXT_UNICODE_STATISTICS = 0x0002;
        public const int IS_TEXT_UNICODE_REVERSE_STATISTICS = 0x0020;
        public const int IS_TEXT_UNICODE_CONTROLS = 0x0004;
        public const int IS_TEXT_UNICODE_REVERSE_CONTROLS = 0x0040;
        public const int IS_TEXT_UNICODE_SIGNATURE = 0x0008;
        public const int IS_TEXT_UNICODE_REVERSE_SIGNATURE = 0x0080;
        public const int IS_TEXT_UNICODE_ILLEGAL_CHARS = 0x0100;
        public const int IS_TEXT_UNICODE_ODD_LENGTH = 0x0200;
        public const int IS_TEXT_UNICODE_DBCS_LEADBYTE = 0x0400;
        public const int IS_TEXT_UNICODE_NULL_BYTES = 0x1000;
        public const int IS_TEXT_UNICODE_UNICODE_MASK = 0x000F;
        public const int IS_TEXT_UNICODE_REVERSE_MASK = 0x00F0;
        public const int IS_TEXT_UNICODE_NOT_UNICODE_MASK = 0x0F00;
        public const int IS_TEXT_UNICODE_NOT_ASCII_MASK = 0xF000;
    }
}