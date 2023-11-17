

using Agro.DAL.Entities.Kassa;

namespace ReportExcelLib.Kassa;

public static class KassaLook
{
    public static string GetLook(DocCash docCash)
    {
        string doc = "";
        string gb = docCash.GeneralAccountant != null! ? docCash.GeneralAccountant.People.ToString() : String.Empty;
        string cashier= docCash.Cashier != null! ? docCash.Cashier.People.ToString() : String.Empty;
		string director = docCash.Director != null! ? docCash.Director.People.ToString() : String.Empty;
		string postDirector = docCash.Director != null! ? docCash.Director.Post.Name : String.Empty;
        string nds = docCash.AmountNds > 0 ? "НДС " + docCash.Nds!.Name +" - " + docCash.AmountNds : docCash.Nds!.Name;



        if (docCash.TypeDoc.Id == 31)
        {
            var summ = Math.Round(docCash.Amount,2).ToString().Split(",");
            var stringSumm = $"{summ[0]} руб. {summ[1]} коп.";
            string docStyle = @"
tr
	{mso-height-source:auto;}
col
	{mso-width-source:auto;}
br
	{mso-data-placement:same-cell;}
.style0
	{mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	white-space:nowrap;
	mso-rotate:0;
	mso-background-source:auto;
	mso-pattern:auto;
	color:windowtext;
	font-size:8.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	border:none;
	mso-protection:locked visible;
	mso-style-name:Обычный;
	mso-style-id:0;}
td
	{mso-style-parent:style0;
	padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:8.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:none;
	mso-background-source:auto;
	mso-pattern:auto;
	mso-protection:locked visible;
	white-space:nowrap;
	mso-rotate:0;}
.xl65
	{mso-style-parent:style0;
	text-align:left;}
.xl66
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center-across;
	vertical-align:top;}
.xl67
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center-across;}
.xl68
	{mso-style-parent:style0;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	white-space:normal;}
.xl69
	{mso-style-parent:style0;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl70
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:right;}
.xl71
	{mso-style-parent:style0;
	text-align:center;}
.xl72
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:left;}
.xl73
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:top;
	white-space:normal;}
.xl74
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	white-space:normal;
	mso-rotate:90;}
.xl75
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:1.0pt solid black;}
.xl76
	{mso-style-parent:style0;
	text-align:left;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;}
.xl77
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;}
.xl78
	{mso-style-parent:style0;
	mso-number-format:Standard;
	text-align:right;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;}
.xl79
	{mso-style-parent:style0;
	text-align:left;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:1.0pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;}
.xl80
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	mso-rotate:90;}
.xl81
	{mso-style-parent:style0;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:left;}
.xl82
	{mso-style-parent:style0;
	text-align:left;
	vertical-align:top;}
.xl83
	{mso-style-parent:style0;
	text-align:left;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;}
.xl84
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:top;}
.xl85
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:right;}
.xl86
	{mso-style-parent:style0;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl87
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:.5pt solid black;
	white-space:normal;}
.xl88
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:1.0pt solid black;
	border-left:.5pt solid black;
	white-space:normal;}
.xl89
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;
	white-space:normal;}
.xl90
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:right;
	vertical-align:top;}
.xl91
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:right;
	vertical-align:top;
	border-top:none;
	border-right:1.0pt solid black;
	border-bottom:none;
	border-left:none;}
.xl92
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:1.0pt solid black;
	white-space:normal;}
.xl93
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:1.0pt solid black;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl94
	{mso-style-parent:style0;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	white-space:normal;}
.xl95
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl96
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:1.0pt solid black;
	white-space:normal;}
.xl97
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:.5pt solid black;
	border-right:1.0pt solid black;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl98
	{mso-style-parent:style0;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;}
.xl99
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:1.0pt solid black;
	white-space:normal;}
.xl100
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:1.0pt solid black;
	border-bottom:none;
	border-left:none;
	white-space:normal;}
.xl101
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:none;
	border-bottom:1.0pt solid black;
	border-left:1.0pt solid black;
	white-space:normal;}
.xl102
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:1.0pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;
	white-space:normal;}
.xl103
	{mso-style-parent:style0;
	text-align:left;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl104
	{mso-style-parent:style0;
	text-align:left;
	white-space:normal;}
.xl105
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;}
.xl106
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:none;}
.xl107
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:1.0pt solid black;
	border-right:none;
	border-bottom:1.0pt solid black;
	border-left:1.0pt solid black;}
.xl108
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:1.0pt solid black;
	border-right:1.0pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;}
.xl109
	{mso-style-parent:style0;
	text-align:left;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:none;}
.xl110
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl111
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl112
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:.5pt solid black;
	white-space:normal;}
.xl113
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl114
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:.5pt solid black;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl115
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl116
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl117
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:.5pt solid black;
	white-space:normal;}
.xl118
	{mso-style-parent:style0;
	text-align:center;
	white-space:normal;}
.xl119
	{mso-style-parent:style0;
	text-align:center;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl120
	{mso-style-parent:style0;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:left;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;}
.xl121
	{mso-style-parent:style0;
	text-align:left;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:none;}
.xl122
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:top;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:none;
	white-space:normal;}
.xl123
	{mso-style-parent:style0;
	text-align:left;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;}
.xl124
	{mso-style-parent:style0;
	text-align:left;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;
	white-space:normal;}
.xl125
	{mso-style-parent:style0;
	text-align:left;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	white-space:normal;}
.xl126
	{mso-style-parent:style0;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:left;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;}
.xl127
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;}
.xl128
	{mso-style-parent:style0;
	text-align:center;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;}
.xl129
	{mso-style-parent:style0;
	text-align:left;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:none;
	white-space:normal;}
.xl130
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:top;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:none;}
"; 
            doc = $@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 5.0 Transitional//EN"">
<HTML>
<HEAD>
<META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; CHARSET=utf-8"">
<TITLE></TITLE>
<STYLE TYPE=""text/css"">
{docStyle}
</STYLE>
</HEAD>
<body link=blue vlink=purple>

<table border=0 cellpadding=0 cellspacing=0 width=714 style='border-collapse:
 collapse;table-layout:fixed;width:535pt'>
 <col class=xl65 width=6 style='mso-width-source:userset;mso-width-alt:292;
 width:5pt'>
 <col class=xl65 width=72 style='mso-width-source:userset;mso-width-alt:3291;
 width:54pt'>
 <col class=xl65 width=40 style='mso-width-source:userset;mso-width-alt:1828;
 width:30pt'>
 <col class=xl65 width=64 style='mso-width-source:userset;mso-width-alt:2925;
 width:48pt'>
 <col class=xl65 width=57 style='mso-width-source:userset;mso-width-alt:2596;
 width:43pt'>
 <col class=xl65 width=55 style='mso-width-source:userset;mso-width-alt:2523;
 width:41pt'>
 <col class=xl65 width=81 style='mso-width-source:userset;mso-width-alt:3693;
 width:61pt'>
 <col class=xl65 width=51 style='mso-width-source:userset;mso-width-alt:2340;
 width:38pt'>
 <col class=xl65 width=30 style='mso-width-source:userset;mso-width-alt:1353;
 width:22pt'>
 <col class=xl65 width=6 style='mso-width-source:userset;mso-width-alt:256;
 width:4pt'>
 <col class=xl65 width=12 style='mso-width-source:userset;mso-width-alt:548;
 width:9pt'>
 <col class=xl65 width=59 style='mso-width-source:userset;mso-width-alt:2706;
 width:44pt'>
 <col class=xl65 width=28 style='mso-width-source:userset;mso-width-alt:1280;
 width:21pt'>
 <col class=xl65 width=11 style='mso-width-source:userset;mso-width-alt:512;
 width:8pt'>
 <col class=xl65 width=68 style='mso-width-source:userset;mso-width-alt:3108;
 width:51pt'>
 <col class=xl65 width=17 style='mso-width-source:userset;mso-width-alt:768;
 width:13pt'>
 <col class=xl65 width=36 style='mso-width-source:userset;mso-width-alt:1645;
 width:27pt'>
 <col class=xl65 width=21 style='mso-width-source:userset;mso-width-alt:950;
 width:16pt'>
 <tr height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl65 width=6 style='height:10.95pt;width:5pt'></td>
  <td class=xl65 width=72 style='width:54pt'></td>
  <td class=xl65 width=40 style='width:30pt'></td>
  <td class=xl65 width=64 style='width:48pt'></td>
  <td class=xl65 width=57 style='width:43pt'></td>
  <td class=xl65 width=55 style='width:41pt'></td>
  <td colspan=3 class=xl85 width=162 style='width:121pt'>Унифицированная форма
  КО-1</td>
  <td class=xl65 width=6 style='width:4pt'></td>
  <td width=12 style='width:9pt' align=left valign=top><span
  style='mso-ignore:vglayout2'>
  <table cellpadding=0 cellspacing=0>
   <tr>
    <td height=14 class=xl65 width=12 style='height:10.95pt;width:9pt'></td>
   </tr>
  </table>
  </span></td>
  <td class=xl65 width=59 style='width:44pt'></td>
  <td class=xl65 width=28 style='width:21pt'></td>
  <td class=xl65 width=11 style='width:8pt'></td>
  <td class=xl65 width=68 style='width:51pt'></td>
  <td class=xl65 width=17 style='width:13pt'></td>
  <td class=xl65 width=36 style='width:27pt'></td>
  <td class=xl65 width=21 style='width:16pt'><span
  style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl65 style='height:10.95pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=5 class=xl85>Утверждена постановлением Госкомстата России от
  18.08.98 № 88</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=6 class=xl86 width=219 style='width:164pt'>{docCash.Organization.AbbreviatedName}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl65 style='height:7.95pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=6 class=xl66 align=center style='mso-ignore:colspan'>организация</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=17 style='mso-height-source:userset;height:13.05pt'>
  <td height=17 class=xl65 style='height:13.05pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=2 class=xl88 width=81 style='border-right:.5pt solid black;
  width:60pt'>Коды</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=6 class=xl67 align=center style='mso-ignore:colspan'>КВИТАНЦИЯ</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=28 style='mso-height-source:userset;height:21.0pt'>
  <td height=28 class=xl65 style='height:21.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=2 class=xl90 style='border-right:1.0pt solid black'>Форма по ОКУД</td>
  <td colspan=2 class=xl92 width=81 style='border-right:1.0pt solid black;
  border-left:none;width:60pt'>310001</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=4 class=xl94 width=166 style='width:124pt'>к приходному кассовому
  ордеру<span style='mso-spacerun:yes'> </span></td>
  <td class=xl68 width=17 style='width:13pt'>№</td>
  <td colspan=1 class=xl69 width=36 style='width:27pt'>{docCash.Number}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=17 style='mso-height-source:userset;height:13.05pt'>
  <td height=17 class=xl65 style='height:13.05pt'></td>
  <td colspan=5 class=xl95 width=288 style='width:216pt'>{docCash.Organization.AbbreviatedName}</td>
  <td class=xl70>по ОКПО</td>
  <td colspan=2 class=xl96 width=81 style='border-right:1.0pt solid black;
  width:60pt'>{docCash.Organization.Okpo}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl71>от</td>
  <td colspan=5 class=xl98>{docCash.Date.ToLongDateString()}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl65 style='height:7.95pt'></td>
  <td colspan=5 class=xl66 align=center style='mso-ignore:colspan'>организация</td>
  <td class=xl72><span style='mso-spacerun:yes'> </span></td>
  <td colspan=2 rowspan=2 class=xl99 width=81 style='border-right:1.0pt solid black;
  border-bottom:1.0pt solid black;width:60pt'>&nbsp;</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
 </tr>
 <tr class=xl65 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl65 style='height:12.0pt'></td>
  <td colspan=5 class=xl103 width=288 style='width:216pt'>{docCash.Division}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65>Принято от</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl65 style='height:7.95pt'></td>
  <td colspan=5 class=xl66 align=center style='mso-ignore:colspan'>подразделение</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=7 rowspan=3 class=xl104 width=120 style='border-bottom:.5pt solid black;
  width:120pt'>{docCash.From}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=4 style='mso-height-source:userset;height:3.0pt'>
  <td height=4 class=xl65 style='height:3.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=28 style='mso-height-source:userset;height:21.0pt'>
  <td height=28 class=xl65 style='height:21.0pt'></td>
  <td colspan=4 class=xl105 style='border-right:.5pt solid black'>ПРИХОДНЫЙ
  КАССОВЫЙ ОРДЕР</td>
  <td colspan=2 class=xl88 width=136 style='border-right:.5pt solid black;
  border-left:none;width:102pt'>Номер документа</td>
  <td colspan=2 class=xl88 width=81 style='border-right:.5pt solid black;
  border-left:none;width:60pt'>Дата составления</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl65 style='height:12.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=2 class=xl107 style='border-right:1.0pt solid black'>{docCash.Number}</td>
  <td colspan=2 class=xl107 style='border-right:1.0pt solid black;border-left:
  none'>{docCash.Date.ToShortDateString()}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td rowspan=2 class=xl109 style='border-top:none'>Основание</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=8 style='mso-height-source:userset;height:6.0pt'>
  <td height=8 class=xl65 style='height:6.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl73 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl73 width=6 style='height:12.0pt;width:5pt'></td>
  <td rowspan=4 class=xl110 width=72 style='border-bottom:1.0pt solid black;
  width:54pt'>Дебет</td>
  <td colspan=4 class=xl87 width=216 style='border-right:.5pt solid black;
  border-left:none;width:162pt'>Кредит</td>
  <td rowspan=4 class=xl110 width=81 style='border-bottom:1.0pt solid black;
  width:61pt'>Сумма, руб.коп.</td>
  <td rowspan=4 class=xl115 width=51 style='border-bottom:1.0pt solid black;
  width:38pt'>Код целевого назначения</td>
  <td rowspan=4 class=xl110 width=30 style='border-bottom:1.0pt solid black;
  width:22pt'>&nbsp;</td>
  <td class=xl74 width=6 style='width:4pt'></td>
  <td class=xl73 width=12 style='width:9pt'></td>
  <td colspan=6 rowspan=3 class=xl118 width=219 style='border-bottom:.5pt solid black;
  width:164pt'>{docCash.Footing}</td>
  <td class=xl73 width=21 style='width:16pt'><span
  style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl73 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl73 width=6 style='height:12.0pt;width:5pt'></td>
  <td rowspan=3 class=xl110 width=40 style='border-bottom:1.0pt solid black;
  border-top:none;width:30pt'>&nbsp;</td>
  <td rowspan=3 class=xl115 width=64 style='border-bottom:1.0pt solid black;
  border-top:none;width:48pt'>код струк-<br>
    турного подраз-<br>
    деления</td>
  <td rowspan=3 class=xl115 width=57 style='border-bottom:1.0pt solid black;
  border-top:none;width:43pt'>корреспон-<br>
    дирующий счет,<br>
    субсчет</td>
  <td rowspan=3 class=xl115 width=55 style='border-bottom:1.0pt solid black;
  border-top:none;width:41pt'>код аналити- ческого учета</td>
  <td class=xl73 width=6 style='width:4pt'></td>
  <td class=xl73 width=12 style='width:9pt'></td>
  <td class=xl73 width=21 style='width:16pt'><span
  style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl73 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl73 width=6 style='height:12.0pt;width:5pt'></td>
  <td class=xl73 width=6 style='width:4pt'></td>
  <td class=xl73 width=12 style='width:9pt'></td>
  <td class=xl73 width=21 style='width:16pt'><span
  style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl73 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl73 width=6 style='height:12.0pt;width:5pt'></td>
  <td class=xl73 width=6 style='width:4pt'></td>
  <td class=xl73 width=12 style='width:9pt'></td>
  <td class=xl73 width=59 style='width:44pt'></td>
  <td class=xl73 width=28 style='width:21pt'></td>
  <td class=xl73 width=11 style='width:8pt'></td>
  <td class=xl73 width=68 style='width:51pt'></td>
  <td class=xl73 width=17 style='width:13pt'></td>
  <td class=xl73 width=36 style='width:27pt'></td>
  <td class=xl73 width=21 style='width:16pt'><span
  style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=28 style='mso-height-source:userset;height:21.0pt'>
  <td height=28 class=xl65 style='height:21.0pt'></td>
  <td class=xl75 style='border-top:none'>{docCash.Debit.Code}</td>
  <td class=xl76 style='border-top:none'>&nbsp;</td>
  <td class=xl77 style='border-top:none'>&nbsp;</td>
  <td class=xl77 style='border-top:none'>{docCash.Credit.Code}</td>
  <td class=xl77 style='border-top:none'>&nbsp;</td>
  <td class=xl78 style='border-top:none'>{Math.Round(docCash.Amount, 2)}</td>
  <td class=xl77 style='border-top:none'>&nbsp;</td>
  <td class=xl79 style='border-top:none'>&nbsp;</td>
  <td class=xl80></td>
  <td class=xl65></td>
  <td class=xl65>Сумма</td>
  <td colspan=5 class=xl120>{stringSumm}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=12 style='mso-height-source:userset;height:9.0pt'>
  <td height=12 class=xl65 style='height:9.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=5 class=xl66 align=center style='mso-ignore:colspan'>цифрами</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=9 style='mso-height-source:userset;height:6.6pt'>
  <td height=9 class=xl65 style='height:6.6pt'></td>
  <td rowspan=3 class=xl65>Принято от:</td>
  <td colspan=7 rowspan=3 class=xl65 style='border-bottom:.5pt solid black'>{docCash.From}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=6 rowspan=2 class=xl104 width=219 style='border-bottom:.5pt solid black;
  width:164pt'>{Helpers.AmountInWords.CurrencyToTxt((double)docCash.Amount, true)}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=13 style='mso-height-source:userset;height:9.6pt'>
  <td height=13 class=xl65 style='height:9.6pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
 </tr>
 <tr class=xl65 height=13 style='mso-height-source:userset;height:9.6pt'>
  <td height=13 class=xl65 style='height:9.6pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=6 class=xl122 width=219 style='width:164pt'>(прописью)</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl65 style='height:10.95pt'></td>
  <td rowspan=2 class=xl65>Основание:</td>
  <td colspan=7 rowspan=2 class=xl123 style='border-bottom:.5pt solid black'>{docCash.Footing}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65 colspan=2 style='mso-ignore:colspan'>В том числе</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=14 style='mso-height-source:userset;height:10.2pt'>
  <td height=14 class=xl65 style='height:10.2pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=6 rowspan=2 class=xl104 width=219 style='border-bottom:.5pt solid black;
  width:164pt'>{nds}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=11 style='mso-height-source:userset;height:8.4pt'>
  <td height=11 class=xl65 style='height:8.4pt'></td>
  <td rowspan=2 class=xl65>Сумма:</td>
  <td colspan=7 rowspan=2 class=xl124 width=378 style='border-bottom:.5pt solid black;
  width:283pt'>{Helpers.AmountInWords.CurrencyToTxt((double)docCash.Amount, true)}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl65 style='height:12.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=5 class=xl126>{docCash.Date.ToLongDateString()}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl65 style='height:7.95pt'></td>
  <td class=xl65></td>
  <td colspan=7 class=xl127>(прописью)</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl65 style='height:10.95pt'></td>
  <td class=xl82>В том числе:</td>
  <td colspan=7 class=xl121>{nds}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl81 colspan=2 style='mso-ignore:colspan'>М.П. (штампа)</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=6 style='mso-height-source:userset;height:4.8pt'>
  <td height=6 class=xl65 style='height:4.8pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl65 style='height:10.95pt'></td>
  <td class=xl65>Приложение:</td>
  <td colspan=7 rowspan=2 class=xl71 style='border-bottom:.5pt solid black'>{docCash.ApplicationDoc}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl81 colspan=4 style='mso-ignore:colspan'>Главный бухгалтер</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=11 style='mso-height-source:userset;height:8.4pt'>
  <td height=11 class=xl65 style='height:8.4pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl65 style='height:10.95pt'></td>
  <td class=xl81 colspan=2 style='mso-ignore:colspan'>Главный бухгалтер</td>
  <td class=xl83><span style='mso-spacerun:yes'> </span></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td colspan=4 class=xl129 width=217 style='width:162pt'>{gb}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl83>&nbsp;</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td colspan=4 class=xl103 width=132 style='width:99pt'>{gb}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl65 style='height:7.95pt'></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td class=xl84>подпись</td>
  <td class=xl84><span style='mso-spacerun:yes'> </span></td>
  <td colspan=3 class=xl130>расшифровка подписи</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl84>подпись</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td colspan=4 class=xl66 align=center style='mso-ignore:colspan'>расшифровка
  подписи</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=13 style='mso-height-source:userset;height:10.05pt'>
  <td height=13 class=xl65 style='height:10.05pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl81>Кассир</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=18 style='mso-height-source:userset;height:13.2pt'>
  <td height=18 class=xl65 style='height:13.2pt'></td>
  <td class=xl81 colspan=2 style='mso-ignore:colspan'>Получил кассир</td>
  <td class=xl83><span style='mso-spacerun:yes'> </span></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td colspan=4 class=xl104 width=217 style='width:162pt'>{cashier}</td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl83>&nbsp;</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td colspan=4 class=xl103 width=132 style='width:99pt'>{cashier}</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl65 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl65 style='height:7.95pt'></td>
  <td class=xl65></td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td class=xl84>подпись</td>
  <td class=xl84><span style='mso-spacerun:yes'> </span></td>
  <td colspan=3 class=xl130>расшифровка подписи</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl84>подпись</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
  <td colspan=4 class=xl66 align=center style='mso-ignore:colspan'>расшифровка
  подписи</td>
  <td class=xl65><span style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr height=15 style='mso-height-source:userset;height:11.4pt'>
  <td height=15 class=xl65 style='height:11.4pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
 </tr>
 <tr height=15 style='mso-height-source:userset;height:11.4pt'>
  <td height=15 class=xl65 style='height:11.4pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
 </tr>
 <tr height=15 style='mso-height-source:userset;height:11.4pt'>
  <td height=15 class=xl65 style='height:11.4pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
 </tr>

</table>

</body>
";
        }
        else if (docCash.TypeDoc.Id == 32)
        {
			string docStyle = @"tr
	{mso-height-source:auto;}
col
	{mso-width-source:auto;}
br
	{mso-data-placement:same-cell;}
.style0
	{mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	white-space:nowrap;
	mso-rotate:0;
	mso-background-source:auto;
	mso-pattern:auto;
	color:windowtext;
	font-size:8.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	border:none;
	mso-protection:locked visible;
	mso-style-name:Обычный;
	mso-style-id:0;}
td
	{mso-style-parent:style0;
	padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:windowtext;
	font-size:8.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:none;
	mso-background-source:auto;
	mso-pattern:auto;
	mso-protection:locked visible;
	white-space:nowrap;
	mso-rotate:0;}
.xl65
	{mso-style-parent:style0;
	text-align:left;}
.xl66
	{mso-style-parent:style0;
	text-align:right;
	white-space:normal;}
.xl67
	{mso-style-parent:style0;
	text-align:center;
	border:.5pt solid black;}
.xl68
	{mso-style-parent:style0;
	text-align:left;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;
	white-space:normal;}
.xl69
	{mso-style-parent:style0;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:right;}
.xl70
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:1.0pt solid black;
	border-right:1.0pt solid black;
	border-bottom:.5pt solid black;
	border-left:1.0pt solid black;}
.xl71
	{mso-style-parent:style0;
	text-align:left;
	border-top:none;
	border-right:1.0pt solid black;
	border-bottom:1.0pt solid black;
	border-left:1.0pt solid black;}
.xl72
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:top;
	white-space:normal;}
.xl73
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border:.5pt solid black;
	white-space:normal;}
.xl74
	{mso-style-parent:style0;
	text-align:left;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:none;
	border-bottom:1.0pt solid black;
	border-left:1.0pt solid black;
	white-space:normal;}
.xl75
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:.5pt solid black;
	border-bottom:1.0pt solid black;
	border-left:.5pt solid black;
	white-space:normal;}
.xl76
	{mso-style-parent:style0;
	text-align:left;
	border-top:1.0pt solid black;
	border-right:1.0pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;
	white-space:normal;}
.xl77
	{mso-style-parent:style0;
	text-align:left;
	white-space:normal;}
.xl78
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:top;
	white-space:normal;}
.xl79
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:left;
	white-space:normal;}
.xl80
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:top;}
.xl81
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:.5pt solid black;
	border-right:1.0pt solid black;
	border-bottom:none;
	border-left:1.0pt solid black;
	white-space:normal;}
.xl82
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	border-top:none;
	border-right:1.0pt solid black;
	border-bottom:.5pt solid black;
	border-left:1.0pt solid black;
	white-space:normal;}
.xl83
	{mso-style-parent:style0;
	text-align:left;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid black;
	border-left:none;}
.xl84
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid black;}
.xl85
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border:.5pt solid black;}
.xl86
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-weight:700;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:right;
	vertical-align:middle;}
.xl87
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border:1.0pt solid black;}
.xl88
	{mso-style-parent:style0;
	font-size:9.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:middle;
	border-top:1.0pt solid black;
	border-right:1.0pt solid black;
	border-bottom:1.0pt solid black;
	border-left:none;}
.xl89
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl90
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:.5pt solid black;
	border-bottom:.5pt solid black;
	border-left:.5pt solid black;
	white-space:normal;}
.xl91
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl92
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl93
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:middle;
	white-space:normal;}
.xl94
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:top;
	border-top:.5pt solid black;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:.5pt solid black;
	white-space:normal;}
.xl95
	{mso-style-parent:style0;
	text-align:center;
	vertical-align:top;
	border-top:none;
	border-right:.5pt solid black;
	border-bottom:.5pt solid black;
	border-left:.5pt solid black;
	white-space:normal;}
.xl96
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:center;
	vertical-align:top;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:none;
	white-space:normal;}
.xl97
	{mso-style-parent:style0;
	font-size:6.0pt;
	font-family:Arial, sans-serif;
	mso-font-charset:204;
	text-align:right;
	white-space:normal;}
";
            doc = @$"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 5.0 Transitional//EN"">
<HTML>
<HEAD>
<META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; CHARSET=utf-8"">
<TITLE></TITLE>
<STYLE TYPE=""text/css"">
{docStyle}
</STYLE>
</HEAD>
<body link=blue vlink=purple>
<table border=0 cellpadding=0 cellspacing=0 width=677 style='border-collapse:
 collapse;table-layout:fixed;width:510pt'>
 <col class=xl65 width=6 style='mso-width-source:userset;mso-width-alt:292;
 width:5pt'>
 <col class=xl65 width=74 style='mso-width-source:userset;mso-width-alt:3364;
 width:55pt'>
 <col class=xl65 width=80 style='mso-width-source:userset;mso-width-alt:3657;
 width:60pt'>
 <col class=xl65 width=98 style='mso-width-source:userset;mso-width-alt:4498;
 width:74pt'>
 <col class=xl65 width=81 style='mso-width-source:userset;mso-width-alt:3693;
 width:61pt'>
 <col class=xl65 width=49 style='mso-width-source:userset;mso-width-alt:2230;
 width:37pt'>
 <col class=xl65 width=90 style='mso-width-source:userset;mso-width-alt:4132;
 width:68pt'>
 <col class=xl65 width=38 style='mso-width-source:userset;mso-width-alt:1755;
 width:29pt'>
 <col class=xl65 width=86 style='mso-width-source:userset;mso-width-alt:3949;
 width:65pt'>
 <col class=xl65 width=75 style='mso-width-source:userset;mso-width-alt:3437;
 width:56pt'>
 <tr class=xl65 height=21 style='mso-height-source:userset;height:15.6pt'>
  <td height=21 class=xl65 width=6 style='height:15.6pt;width:5pt'></td>
  <td class=xl65 width=74 style='width:55pt'></td>
  <td class=xl65 width=80 style='width:60pt'></td>
  <td class=xl65 width=98 style='width:74pt'></td>
  <td class=xl65 width=81 style='width:61pt'></td>
  <td colspan=5 class=xl97 width=338 style='width:255pt'>Унифицированная форма
  № КО-2<br>
    Утверждена постановлением Госкомстата России от 18.08.98 № 88</td>
 </tr>
 <tr height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl65 style='height:10.95pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl67>коды</td>
 </tr>
 <tr class=xl65 height=21 style='mso-height-source:userset;height:15.6pt'>
  <td height=21 class=xl65 style='height:15.6pt'></td>
  <td colspan=7 class=xl68 width=510 style='width:384pt'>{docCash.Organization.AbbreviatedName}</td>
  <td class=xl69>Форма по ОКУД</td>
  <td class=xl70>0310002</td>
 </tr>
 <tr class=xl65 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl65 style='height:7.95pt'></td>
  <td colspan=7 class=xl80>организация</td>
  <td rowspan=2 class=xl69>по ОКПО</td>
  <td rowspan=2 class=xl81 width=75 style='border-bottom:.5pt solid black;
  border-top:none;width:56pt'>{docCash.Organization.Okpo}</td>
 </tr>
 <tr class=xl65 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl65 style='height:12.0pt'></td>
  <td colspan=7 class=xl83>{docCash.Division}</td>
 </tr>
 <tr class=xl65 height=14 style='mso-height-source:userset;height:10.8pt'>
  <td height=14 class=xl65 style='height:10.8pt'></td>
  <td colspan=7 class=xl80>структурное подразделение</td>
  <td class=xl65></td>
  <td class=xl71>&nbsp;</td>
 </tr>
 <tr class=xl65 height=8 style='mso-height-source:userset;height:6.0pt'>
  <td height=8 class=xl65 style='height:6.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
 </tr>
 <tr class=xl65 height=21 style='mso-height-source:userset;height:15.6pt'>
  <td height=21 class=xl65 style='height:15.6pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td colspan=2 class=xl84>Номер документа</td>
  <td colspan=2 class=xl85>Дата составления</td>
 </tr>
 <tr class=xl65 height=28 style='mso-height-source:userset;height:21.0pt'>
  <td height=28 class=xl65 style='height:21.0pt'></td>
  <td colspan=5 class=xl86>РАСХОДНЫЙ КАССОВЫЙ ОРДЕР</td>
  <td colspan=2 class=xl87>{docCash.Number}</td>
  <td colspan=2 class=xl88>{docCash.Date.ToShortDateString()}</td>
 </tr>
 <tr class=xl65 height=8 style='mso-height-source:userset;height:6.0pt'>
  <td height=8 class=xl65 style='height:6.0pt'></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
  <td class=xl65></td>
 </tr>
 <tr class=xl72 height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl72 width=6 style='height:10.95pt;width:5pt'></td>
  <td colspan=4 class=xl73 width=333 style='width:250pt'>Дебет</td>
  <td rowspan=2 class=xl89 width=49 style='border-bottom:.5pt solid black;
  width:37pt'>Кредит</td>
  <td colspan=2 rowspan=2 class=xl91 width=128 style='width:97pt'>Сумма,<br>
    руб.коп.</td>
  <td rowspan=2 class=xl89 width=86 style='border-bottom:.5pt solid black;
  width:65pt'>Код целевого назначения</td>
  <td rowspan=2 class=xl94 width=75 style='border-bottom:.5pt solid black;
  width:56pt'>&nbsp;</td>
 </tr>
 <tr class=xl72 height=40 style='mso-height-source:userset;height:30.0pt'>
  <td height=40 class=xl72 width=6 style='height:30.0pt;width:5pt'></td>
  <td class=xl73 width=74 style='border-top:none;width:55pt'>&nbsp;</td>
  <td class=xl73 width=80 style='border-top:none;border-left:none;width:60pt'>код
  структурного подразделения</td>
  <td class=xl73 width=98 style='border-top:none;border-left:none;width:74pt'>корреспондирую-<br>
    щий счет, субсчет</td>
  <td class=xl73 width=81 style='border-top:none;border-left:none;width:61pt'>код
  аналити- ческого учета</td>
 </tr>
 <tr class=xl65 height=28 style='mso-height-source:userset;height:21.0pt'>
  <td height=28 class=xl65 style='height:21.0pt'></td>
  <td class=xl74 width=74 style='width:55pt'>&nbsp;</td>
  <td class=xl75 width=80 style='width:60pt'>&nbsp;</td>
  <td class=xl75 width=98 style='border-left:none;width:74pt'>{docCash.Debit.Code}</td>
  <td class=xl75 width=81 style='border-left:none;width:61pt'>&nbsp;</td>
  <td class=xl75 width=49 style='border-left:none;width:37pt'>{docCash.Credit.Code}</td>
  <td colspan=2 class=xl75 width=128 style='border-left:none;width:97pt'>{Math.Round(docCash.Amount, 2)}</td>
  <td class=xl75 width=86 style='border-left:none;width:65pt'>&nbsp;</td>
  <td class=xl76 width=75 style='width:56pt'>&nbsp;</td>
 </tr>
 <tr class=xl77 height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl77 width=6 style='height:15.0pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'>Выдать</td>
  <td colspan=8 class=xl68 width=597 style='width:450pt'>{docCash.From}</td>
 </tr>
 <tr class=xl77 height=10 style='mso-height-source:userset;height:7.8pt'>
  <td height=10 class=xl77 width=6 style='height:7.8pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'></td>
  <td colspan=8 class=xl78 width=597 style='width:450pt'>фамилия, имя, отчество</td>
 </tr>
 <tr class=xl77 height=19 style='mso-height-source:userset;height:14.4pt'>
  <td height=19 class=xl77 width=6 style='height:14.4pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'>Основание</td>
  <td colspan=8 class=xl68 width=597 style='width:450pt'>{docCash.Footing}</td>
 </tr>
 <tr class=xl77 height=29 style='mso-height-source:userset;height:21.6pt'>
  <td height=29 class=xl77 width=6 style='height:21.6pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'>Сумма</td>
  <td colspan=8 class=xl68 width=597 style='width:450pt'>{Helpers.AmountInWords.CurrencyToTxt((double)docCash.Amount, true)}</td>
 </tr>
 <tr class=xl79 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl79 width=6 style='height:7.95pt;width:5pt'></td>
  <td class=xl79 width=74 style='width:55pt'></td>
  <td colspan=8 class=xl78 width=597 style='width:450pt'>прописью</td>
 </tr>
 <tr class=xl77 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl77 width=6 style='height:12.0pt;width:5pt'></td>
  <td colspan=9 class=xl68 width=671 style='width:505pt'>&nbsp;</td>
 </tr>
 <tr class=xl77 height=16 style='mso-height-source:userset;height:12.0pt'>
  <td height=16 class=xl77 width=6 style='height:12.0pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'>Приложение</td>
  <td colspan=8 class=xl68 width=597 style='width:450pt'>{docCash.ApplicationDoc}</td>
 </tr>
 <tr class=xl77 height=21 style='mso-height-source:userset;height:15.6pt'>
  <td height=21 class=xl77 width=6 style='height:15.6pt;width:5pt'></td>
  <td colspan=2 class=xl77 width=154 style='width:115pt'>Руководитель
  организации</td>
  <td colspan=2 class=xl68 width=179 style='width:135pt'>{postDirector}</td>
  <td class=xl77 width=49 style='width:37pt'></td>
  <td class=xl68 width=90 style='width:68pt'>&nbsp;</td>
  <td class=xl77 width=38 style='width:29pt'></td>
  <td colspan=2 class=xl68 width=161 style='width:121pt'>{director}</td>
 </tr>
 <tr class=xl79 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl79 width=6 style='height:7.95pt;width:5pt'></td>
  <td class=xl79 width=74 style='width:55pt'></td>
  <td class=xl79 width=80 style='width:60pt'></td>
  <td colspan=2 class=xl78 width=179 style='width:135pt'>должность</td>
  <td class=xl79 width=49 style='width:37pt'></td>
  <td class=xl78 width=90 style='width:68pt'>подпись</td>
  <td class=xl79 width=38 style='width:29pt'></td>
  <td colspan=2 class=xl78 width=161 style='width:121pt'>расшифровка подписи</td>
 </tr>
 <tr class=xl77 height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl77 width=6 style='height:10.95pt;width:5pt'></td>
  <td colspan=2 class=xl77 width=154 style='width:115pt'>Главный бухгалтер</td>
  <td class=xl68 width=98 style='width:74pt'>&nbsp;</td>
  <td class=xl68 width=81 style='width:61pt'>&nbsp;</td>
  <td class=xl77 width=49 style='width:37pt'></td>
  <td colspan=4 class=xl77 width=289 style='width:218pt'>{gb}</td>
 </tr>
 <tr class=xl79 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl79 width=6 style='height:7.95pt;width:5pt'></td>
  <td class=xl79 width=74 style='width:55pt'></td>
  <td class=xl79 width=80 style='width:60pt'></td>
  <td colspan=2 class=xl78 width=179 style='width:135pt'>подпись</td>
  <td class=xl79 width=49 style='width:37pt'></td>
  <td colspan=2 class=xl96 width=128 style='width:97pt'>расшифровка подписи</td>
  <td class=xl79 width=86 style='width:65pt'></td>
  <td class=xl79 width=75 style='width:56pt'></td>
 </tr>
 <tr class=xl77 height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl77 width=6 style='height:10.95pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'>Получил</td>
  <td colspan=8 class=xl68 width=597 style='width:450pt'>{Helpers.AmountInWords.CurrencyToTxt((double)docCash.Amount, true)}</td>
 </tr>
 <tr class=xl79 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl79 width=6 style='height:7.95pt;width:5pt'></td>
  <td class=xl79 width=74 style='width:55pt'></td>
  <td colspan=8 class=xl78 width=597 style='width:450pt'>сумма прописью</td>
 </tr>
 <tr class=xl77 height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl77 width=6 style='height:15.0pt;width:5pt'></td>
  <td colspan=2 class=xl68 width=154 style='width:115pt'>28 ноября 2022 г.</td>
  <td class=xl77 width=98 style='width:74pt'></td>
  <td class=xl77 width=81 style='width:61pt'></td>
  <td class=xl77 width=49 style='width:37pt'></td>
  <td class=xl66 width=90 style='width:68pt'>Подпись</td>
  <td class=xl68 width=38 style='width:29pt'>&nbsp;</td>
  <td class=xl68 width=86 style='width:65pt'>&nbsp;</td>
  <td class=xl77 width=75 style='width:56pt'></td>
 </tr>
 <tr class=xl77 height=24 style='mso-height-source:userset;height:18.0pt'>
  <td height=24 class=xl77 width=6 style='height:18.0pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'>По</td>
  <td colspan=8 class=xl68 width=597 style='width:450pt'>{docCash.FoundationDoc}<span
  style='mso-spacerun:yes'> </span></td>
 </tr>
 <tr class=xl79 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl79 width=6 style='height:7.95pt;width:5pt'></td>
  <td class=xl79 width=74 style='width:55pt'></td>
  <td colspan=8 class=xl96 width=597 style='width:450pt'>наименование, номер,
  дата и место выдачи документа,удостоверяющего личность получателя</td>
 </tr>
 <tr class=xl79 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl79 width=6 style='height:7.95pt;width:5pt'></td>
  <td colspan=9 class=xl78 width=671 style='width:505pt'></td>
 </tr>
 <tr class=xl77 height=14 style='mso-height-source:userset;height:10.95pt'>
  <td height=14 class=xl77 width=6 style='height:10.95pt;width:5pt'></td>
  <td class=xl77 width=74 style='width:55pt'>Выдал кассир</td>
  <td colspan=2 class=xl68 width=178 style='width:134pt'>&nbsp;</td>
  <td class=xl77 width=81 style='width:61pt'></td>
  <td colspan=5 class=xl77 width=338 style='width:255pt'>{cashier}</td>
 </tr>
 <tr class=xl79 height=10 style='mso-height-source:userset;height:7.95pt'>
  <td height=10 class=xl79 width=6 style='height:7.95pt;width:5pt'></td>
  <td class=xl79 width=74 style='width:55pt'></td>
  <td colspan=2 class=xl78 width=178 style='width:134pt'>подпись</td>
  <td class=xl79 width=81 style='width:61pt'></td>
  <td colspan=2 class=xl96 width=139 style='width:105pt'>расшифровка подписи</td>
  <td class=xl79 width=38 style='width:29pt'></td>
  <td class=xl79 width=86 style='width:65pt'></td>
  <td class=xl79 width=75 style='width:56pt'></td>
 </tr>
</table>
</body>
</html>
";

        }
        return doc;
    }

}
