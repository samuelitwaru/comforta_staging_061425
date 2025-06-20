/*
				   File: type_SdtSDT_Memo
			Description: SDT_Memo
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDT_Memo")]
	[XmlType(TypeName="SDT_Memo" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Memo : GxUserType
	{
		public SdtSDT_Memo( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Memo_Memotitle = "";

			gxTv_SdtSDT_Memo_Memodescription = "";

			gxTv_SdtSDT_Memo_Memoimage = "";

			gxTv_SdtSDT_Memo_Memodocument = "";

			gxTv_SdtSDT_Memo_Memostartdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_Memo_Memoenddatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_Memo_Residentsalutation = "";

			gxTv_SdtSDT_Memo_Residentgivenname = "";

			gxTv_SdtSDT_Memo_Residentlastname = "";

			gxTv_SdtSDT_Memo_Residentguid = "";

			gxTv_SdtSDT_Memo_Memobgcolorcode = "";

			gxTv_SdtSDT_Memo_Memoform = "";

			gxTv_SdtSDT_Memo_Createdby = "";

			gxTv_SdtSDT_Memo_Memotype = "";

			gxTv_SdtSDT_Memo_Memoname = "";

			gxTv_SdtSDT_Memo_Memotextfontname = "";

			gxTv_SdtSDT_Memo_Memotextalignment = "";

			gxTv_SdtSDT_Memo_Memotextcolor = "";

		}

		public SdtSDT_Memo(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("MemoId", gxTpr_Memoid, false);


			AddObjectProperty("MemoTitle", gxTpr_Memotitle, false);


			AddObjectProperty("MemoDescription", gxTpr_Memodescription, false);


			AddObjectProperty("MemoImage", gxTpr_Memoimage, false);


			AddObjectProperty("MemoDocument", gxTpr_Memodocument, false);


			datetime_STZ = gxTpr_Memostartdatetime;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MemoStartDateTime", sDateCnv, false);



			datetime_STZ = gxTpr_Memoenddatetime;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MemoEndDateTime", sDateCnv, false);



			AddObjectProperty("MemoDuration", gxTpr_Memoduration, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Memoremovedate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Memoremovedate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Memoremovedate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MemoRemoveDate", sDateCnv, false);



			AddObjectProperty("ResidentId", gxTpr_Residentid, false);


			AddObjectProperty("ResidentSalutation", gxTpr_Residentsalutation, false);


			AddObjectProperty("ResidentGivenName", gxTpr_Residentgivenname, false);


			AddObjectProperty("ResidentLastName", gxTpr_Residentlastname, false);


			AddObjectProperty("ResidentGUID", gxTpr_Residentguid, false);


			AddObjectProperty("MemoBgColorCode", gxTpr_Memobgcolorcode, false);


			AddObjectProperty("MemoForm", gxTpr_Memoform, false);


			AddObjectProperty("CreatedBy", gxTpr_Createdby, false);


			AddObjectProperty("MemoType", gxTpr_Memotype, false);


			AddObjectProperty("MemoName", gxTpr_Memoname, false);


			AddObjectProperty("MemoLeftOffset", gxTpr_Memoleftoffset, false);


			AddObjectProperty("MemoTopOffset", gxTpr_Memotopoffset, false);


			AddObjectProperty("MemoTitleAngle", gxTpr_Memotitleangle, false);


			AddObjectProperty("MemoTitleScale", gxTpr_Memotitlescale, false);


			AddObjectProperty("MemoTextFontName", gxTpr_Memotextfontname, false);


			AddObjectProperty("MemoTextAlignment", gxTpr_Memotextalignment, false);


			AddObjectProperty("MemoIsBold", gxTpr_Memoisbold, false);


			AddObjectProperty("MemoIsItalic", gxTpr_Memoisitalic, false);


			AddObjectProperty("MemoIsCapitalized", gxTpr_Memoiscapitalized, false);


			AddObjectProperty("MemoTextColor", gxTpr_Memotextcolor, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MemoId")]
		[XmlElement(ElementName="MemoId")]
		public Guid gxTpr_Memoid
		{
			get {
				return gxTv_SdtSDT_Memo_Memoid; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoid = value;
				SetDirty("Memoid");
			}
		}




		[SoapElement(ElementName="MemoTitle")]
		[XmlElement(ElementName="MemoTitle")]
		public string gxTpr_Memotitle
		{
			get {
				return gxTv_SdtSDT_Memo_Memotitle; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotitle = value;
				SetDirty("Memotitle");
			}
		}




		[SoapElement(ElementName="MemoDescription")]
		[XmlElement(ElementName="MemoDescription")]
		public string gxTpr_Memodescription
		{
			get {
				return gxTv_SdtSDT_Memo_Memodescription; 
			}
			set {
				gxTv_SdtSDT_Memo_Memodescription = value;
				SetDirty("Memodescription");
			}
		}




		[SoapElement(ElementName="MemoImage")]
		[XmlElement(ElementName="MemoImage")]
		public string gxTpr_Memoimage
		{
			get {
				return gxTv_SdtSDT_Memo_Memoimage; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoimage = value;
				SetDirty("Memoimage");
			}
		}




		[SoapElement(ElementName="MemoDocument")]
		[XmlElement(ElementName="MemoDocument")]
		public string gxTpr_Memodocument
		{
			get {
				return gxTv_SdtSDT_Memo_Memodocument; 
			}
			set {
				gxTv_SdtSDT_Memo_Memodocument = value;
				SetDirty("Memodocument");
			}
		}



		[SoapElement(ElementName="MemoStartDateTime")]
		[XmlElement(ElementName="MemoStartDateTime" , IsNullable=true)]
		public string gxTpr_Memostartdatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDT_Memo_Memostartdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_Memo_Memostartdatetime).value ;
			}
			set {
				gxTv_SdtSDT_Memo_Memostartdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Memostartdatetime
		{
			get {
				return gxTv_SdtSDT_Memo_Memostartdatetime; 
			}
			set {
				gxTv_SdtSDT_Memo_Memostartdatetime = value;
				SetDirty("Memostartdatetime");
			}
		}


		[SoapElement(ElementName="MemoEndDateTime")]
		[XmlElement(ElementName="MemoEndDateTime" , IsNullable=true)]
		public string gxTpr_Memoenddatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDT_Memo_Memoenddatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_Memo_Memoenddatetime).value ;
			}
			set {
				gxTv_SdtSDT_Memo_Memoenddatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Memoenddatetime
		{
			get {
				return gxTv_SdtSDT_Memo_Memoenddatetime; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoenddatetime = value;
				SetDirty("Memoenddatetime");
			}
		}


		[SoapElement(ElementName="MemoDuration")]
		[XmlElement(ElementName="MemoDuration")]
		public string gxTpr_Memoduration_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_Memo_Memoduration, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_Memo_Memoduration = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Memoduration
		{
			get {
				return gxTv_SdtSDT_Memo_Memoduration; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoduration = value;
				SetDirty("Memoduration");
			}
		}



		[SoapElement(ElementName="MemoRemoveDate")]
		[XmlElement(ElementName="MemoRemoveDate" , IsNullable=true)]
		public string gxTpr_Memoremovedate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_Memo_Memoremovedate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDT_Memo_Memoremovedate).value ;
			}
			set {
				gxTv_SdtSDT_Memo_Memoremovedate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Memoremovedate
		{
			get {
				return gxTv_SdtSDT_Memo_Memoremovedate; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoremovedate = value;
				SetDirty("Memoremovedate");
			}
		}



		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public Guid gxTpr_Residentid
		{
			get {
				return gxTv_SdtSDT_Memo_Residentid; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="ResidentSalutation")]
		[XmlElement(ElementName="ResidentSalutation")]
		public string gxTpr_Residentsalutation
		{
			get {
				return gxTv_SdtSDT_Memo_Residentsalutation; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentsalutation = value;
				SetDirty("Residentsalutation");
			}
		}




		[SoapElement(ElementName="ResidentGivenName")]
		[XmlElement(ElementName="ResidentGivenName")]
		public string gxTpr_Residentgivenname
		{
			get {
				return gxTv_SdtSDT_Memo_Residentgivenname; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentgivenname = value;
				SetDirty("Residentgivenname");
			}
		}




		[SoapElement(ElementName="ResidentLastName")]
		[XmlElement(ElementName="ResidentLastName")]
		public string gxTpr_Residentlastname
		{
			get {
				return gxTv_SdtSDT_Memo_Residentlastname; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentlastname = value;
				SetDirty("Residentlastname");
			}
		}




		[SoapElement(ElementName="ResidentGUID")]
		[XmlElement(ElementName="ResidentGUID")]
		public string gxTpr_Residentguid
		{
			get {
				return gxTv_SdtSDT_Memo_Residentguid; 
			}
			set {
				gxTv_SdtSDT_Memo_Residentguid = value;
				SetDirty("Residentguid");
			}
		}




		[SoapElement(ElementName="MemoBgColorCode")]
		[XmlElement(ElementName="MemoBgColorCode")]
		public string gxTpr_Memobgcolorcode
		{
			get {
				return gxTv_SdtSDT_Memo_Memobgcolorcode; 
			}
			set {
				gxTv_SdtSDT_Memo_Memobgcolorcode = value;
				SetDirty("Memobgcolorcode");
			}
		}




		[SoapElement(ElementName="MemoForm")]
		[XmlElement(ElementName="MemoForm")]
		public string gxTpr_Memoform
		{
			get {
				return gxTv_SdtSDT_Memo_Memoform; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoform = value;
				SetDirty("Memoform");
			}
		}




		[SoapElement(ElementName="CreatedBy")]
		[XmlElement(ElementName="CreatedBy")]
		public string gxTpr_Createdby
		{
			get {
				return gxTv_SdtSDT_Memo_Createdby; 
			}
			set {
				gxTv_SdtSDT_Memo_Createdby = value;
				SetDirty("Createdby");
			}
		}




		[SoapElement(ElementName="MemoType")]
		[XmlElement(ElementName="MemoType")]
		public string gxTpr_Memotype
		{
			get {
				return gxTv_SdtSDT_Memo_Memotype; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotype = value;
				SetDirty("Memotype");
			}
		}




		[SoapElement(ElementName="MemoName")]
		[XmlElement(ElementName="MemoName")]
		public string gxTpr_Memoname
		{
			get {
				return gxTv_SdtSDT_Memo_Memoname; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoname = value;
				SetDirty("Memoname");
			}
		}



		[SoapElement(ElementName="MemoLeftOffset")]
		[XmlElement(ElementName="MemoLeftOffset")]
		public string gxTpr_Memoleftoffset_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_Memo_Memoleftoffset, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_Memo_Memoleftoffset = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Memoleftoffset
		{
			get {
				return gxTv_SdtSDT_Memo_Memoleftoffset; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoleftoffset = value;
				SetDirty("Memoleftoffset");
			}
		}



		[SoapElement(ElementName="MemoTopOffset")]
		[XmlElement(ElementName="MemoTopOffset")]
		public string gxTpr_Memotopoffset_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_Memo_Memotopoffset, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_Memo_Memotopoffset = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Memotopoffset
		{
			get {
				return gxTv_SdtSDT_Memo_Memotopoffset; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotopoffset = value;
				SetDirty("Memotopoffset");
			}
		}



		[SoapElement(ElementName="MemoTitleAngle")]
		[XmlElement(ElementName="MemoTitleAngle")]
		public string gxTpr_Memotitleangle_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_Memo_Memotitleangle, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_Memo_Memotitleangle = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Memotitleangle
		{
			get {
				return gxTv_SdtSDT_Memo_Memotitleangle; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotitleangle = value;
				SetDirty("Memotitleangle");
			}
		}



		[SoapElement(ElementName="MemoTitleScale")]
		[XmlElement(ElementName="MemoTitleScale")]
		public string gxTpr_Memotitlescale_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_Memo_Memotitlescale, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_Memo_Memotitlescale = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Memotitlescale
		{
			get {
				return gxTv_SdtSDT_Memo_Memotitlescale; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotitlescale = value;
				SetDirty("Memotitlescale");
			}
		}




		[SoapElement(ElementName="MemoTextFontName")]
		[XmlElement(ElementName="MemoTextFontName")]
		public string gxTpr_Memotextfontname
		{
			get {
				return gxTv_SdtSDT_Memo_Memotextfontname; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotextfontname = value;
				SetDirty("Memotextfontname");
			}
		}




		[SoapElement(ElementName="MemoTextAlignment")]
		[XmlElement(ElementName="MemoTextAlignment")]
		public string gxTpr_Memotextalignment
		{
			get {
				return gxTv_SdtSDT_Memo_Memotextalignment; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotextalignment = value;
				SetDirty("Memotextalignment");
			}
		}




		[SoapElement(ElementName="MemoIsBold")]
		[XmlElement(ElementName="MemoIsBold")]
		public bool gxTpr_Memoisbold
		{
			get {
				return gxTv_SdtSDT_Memo_Memoisbold; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoisbold = value;
				SetDirty("Memoisbold");
			}
		}




		[SoapElement(ElementName="MemoIsItalic")]
		[XmlElement(ElementName="MemoIsItalic")]
		public bool gxTpr_Memoisitalic
		{
			get {
				return gxTv_SdtSDT_Memo_Memoisitalic; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoisitalic = value;
				SetDirty("Memoisitalic");
			}
		}




		[SoapElement(ElementName="MemoIsCapitalized")]
		[XmlElement(ElementName="MemoIsCapitalized")]
		public bool gxTpr_Memoiscapitalized
		{
			get {
				return gxTv_SdtSDT_Memo_Memoiscapitalized; 
			}
			set {
				gxTv_SdtSDT_Memo_Memoiscapitalized = value;
				SetDirty("Memoiscapitalized");
			}
		}




		[SoapElement(ElementName="MemoTextColor")]
		[XmlElement(ElementName="MemoTextColor")]
		public string gxTpr_Memotextcolor
		{
			get {
				return gxTv_SdtSDT_Memo_Memotextcolor; 
			}
			set {
				gxTv_SdtSDT_Memo_Memotextcolor = value;
				SetDirty("Memotextcolor");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDT_Memo_Memotitle = "";
			gxTv_SdtSDT_Memo_Memodescription = "";
			gxTv_SdtSDT_Memo_Memoimage = "";
			gxTv_SdtSDT_Memo_Memodocument = "";
			gxTv_SdtSDT_Memo_Memostartdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDT_Memo_Memoenddatetime = (DateTime)(DateTime.MinValue);



			gxTv_SdtSDT_Memo_Residentsalutation = "";
			gxTv_SdtSDT_Memo_Residentgivenname = "";
			gxTv_SdtSDT_Memo_Residentlastname = "";
			gxTv_SdtSDT_Memo_Residentguid = "";
			gxTv_SdtSDT_Memo_Memobgcolorcode = "";
			gxTv_SdtSDT_Memo_Memoform = "";
			gxTv_SdtSDT_Memo_Createdby = "";
			gxTv_SdtSDT_Memo_Memotype = "";
			gxTv_SdtSDT_Memo_Memoname = "";




			gxTv_SdtSDT_Memo_Memotextfontname = "";
			gxTv_SdtSDT_Memo_Memotextalignment = "";



			gxTv_SdtSDT_Memo_Memotextcolor = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected Guid gxTv_SdtSDT_Memo_Memoid;
		 

		protected string gxTv_SdtSDT_Memo_Memotitle;
		 

		protected string gxTv_SdtSDT_Memo_Memodescription;
		 

		protected string gxTv_SdtSDT_Memo_Memoimage;
		 

		protected string gxTv_SdtSDT_Memo_Memodocument;
		 

		protected DateTime gxTv_SdtSDT_Memo_Memostartdatetime;
		 

		protected DateTime gxTv_SdtSDT_Memo_Memoenddatetime;
		 

		protected decimal gxTv_SdtSDT_Memo_Memoduration;
		 

		protected DateTime gxTv_SdtSDT_Memo_Memoremovedate;
		 

		protected Guid gxTv_SdtSDT_Memo_Residentid;
		 

		protected string gxTv_SdtSDT_Memo_Residentsalutation;
		 

		protected string gxTv_SdtSDT_Memo_Residentgivenname;
		 

		protected string gxTv_SdtSDT_Memo_Residentlastname;
		 

		protected string gxTv_SdtSDT_Memo_Residentguid;
		 

		protected string gxTv_SdtSDT_Memo_Memobgcolorcode;
		 

		protected string gxTv_SdtSDT_Memo_Memoform;
		 

		protected string gxTv_SdtSDT_Memo_Createdby;
		 

		protected string gxTv_SdtSDT_Memo_Memotype;
		 

		protected string gxTv_SdtSDT_Memo_Memoname;
		 

		protected decimal gxTv_SdtSDT_Memo_Memoleftoffset;
		 

		protected decimal gxTv_SdtSDT_Memo_Memotopoffset;
		 

		protected decimal gxTv_SdtSDT_Memo_Memotitleangle;
		 

		protected decimal gxTv_SdtSDT_Memo_Memotitlescale;
		 

		protected string gxTv_SdtSDT_Memo_Memotextfontname;
		 

		protected string gxTv_SdtSDT_Memo_Memotextalignment;
		 

		protected bool gxTv_SdtSDT_Memo_Memoisbold;
		 

		protected bool gxTv_SdtSDT_Memo_Memoisitalic;
		 

		protected bool gxTv_SdtSDT_Memo_Memoiscapitalized;
		 

		protected string gxTv_SdtSDT_Memo_Memotextcolor;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Memo", Namespace="Comforta_version2")]
	public class SdtSDT_Memo_RESTInterface : GxGenericCollectionItem<SdtSDT_Memo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Memo_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Memo_RESTInterface( SdtSDT_Memo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MemoId", Order=0)]
		public Guid gxTpr_Memoid
		{
			get { 
				return sdt.gxTpr_Memoid;

			}
			set { 
				sdt.gxTpr_Memoid = value;
			}
		}

		[DataMember(Name="MemoTitle", Order=1)]
		public  string gxTpr_Memotitle
		{
			get { 
				return sdt.gxTpr_Memotitle;

			}
			set { 
				 sdt.gxTpr_Memotitle = value;
			}
		}

		[DataMember(Name="MemoDescription", Order=2)]
		public  string gxTpr_Memodescription
		{
			get { 
				return sdt.gxTpr_Memodescription;

			}
			set { 
				 sdt.gxTpr_Memodescription = value;
			}
		}

		[DataMember(Name="MemoImage", Order=3)]
		public  string gxTpr_Memoimage
		{
			get { 
				return sdt.gxTpr_Memoimage;

			}
			set { 
				 sdt.gxTpr_Memoimage = value;
			}
		}

		[DataMember(Name="MemoDocument", Order=4)]
		public  string gxTpr_Memodocument
		{
			get { 
				return sdt.gxTpr_Memodocument;

			}
			set { 
				 sdt.gxTpr_Memodocument = value;
			}
		}

		[DataMember(Name="MemoStartDateTime", Order=5)]
		public  string gxTpr_Memostartdatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Memostartdatetime,context);

			}
			set { 
				sdt.gxTpr_Memostartdatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="MemoEndDateTime", Order=6)]
		public  string gxTpr_Memoenddatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Memoenddatetime,context);

			}
			set { 
				sdt.gxTpr_Memoenddatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="MemoDuration", Order=7)]
		public decimal gxTpr_Memoduration
		{
			get { 
				return sdt.gxTpr_Memoduration;

			}
			set { 
				sdt.gxTpr_Memoduration = value;
			}
		}

		[DataMember(Name="MemoRemoveDate", Order=8)]
		public  string gxTpr_Memoremovedate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Memoremovedate);

			}
			set { 
				sdt.gxTpr_Memoremovedate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ResidentId", Order=9)]
		public Guid gxTpr_Residentid
		{
			get { 
				return sdt.gxTpr_Residentid;

			}
			set { 
				sdt.gxTpr_Residentid = value;
			}
		}

		[DataMember(Name="ResidentSalutation", Order=10)]
		public  string gxTpr_Residentsalutation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentsalutation);

			}
			set { 
				 sdt.gxTpr_Residentsalutation = value;
			}
		}

		[DataMember(Name="ResidentGivenName", Order=11)]
		public  string gxTpr_Residentgivenname
		{
			get { 
				return sdt.gxTpr_Residentgivenname;

			}
			set { 
				 sdt.gxTpr_Residentgivenname = value;
			}
		}

		[DataMember(Name="ResidentLastName", Order=12)]
		public  string gxTpr_Residentlastname
		{
			get { 
				return sdt.gxTpr_Residentlastname;

			}
			set { 
				 sdt.gxTpr_Residentlastname = value;
			}
		}

		[DataMember(Name="ResidentGUID", Order=13)]
		public  string gxTpr_Residentguid
		{
			get { 
				return sdt.gxTpr_Residentguid;

			}
			set { 
				 sdt.gxTpr_Residentguid = value;
			}
		}

		[DataMember(Name="MemoBgColorCode", Order=14)]
		public  string gxTpr_Memobgcolorcode
		{
			get { 
				return sdt.gxTpr_Memobgcolorcode;

			}
			set { 
				 sdt.gxTpr_Memobgcolorcode = value;
			}
		}

		[DataMember(Name="MemoForm", Order=15)]
		public  string gxTpr_Memoform
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Memoform);

			}
			set { 
				 sdt.gxTpr_Memoform = value;
			}
		}

		[DataMember(Name="CreatedBy", Order=16)]
		public  string gxTpr_Createdby
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Createdby);

			}
			set { 
				 sdt.gxTpr_Createdby = value;
			}
		}

		[DataMember(Name="MemoType", Order=17)]
		public  string gxTpr_Memotype
		{
			get { 
				return sdt.gxTpr_Memotype;

			}
			set { 
				 sdt.gxTpr_Memotype = value;
			}
		}

		[DataMember(Name="MemoName", Order=18)]
		public  string gxTpr_Memoname
		{
			get { 
				return sdt.gxTpr_Memoname;

			}
			set { 
				 sdt.gxTpr_Memoname = value;
			}
		}

		[DataMember(Name="MemoLeftOffset", Order=19)]
		public decimal gxTpr_Memoleftoffset
		{
			get { 
				return sdt.gxTpr_Memoleftoffset;

			}
			set { 
				sdt.gxTpr_Memoleftoffset = value;
			}
		}

		[DataMember(Name="MemoTopOffset", Order=20)]
		public decimal gxTpr_Memotopoffset
		{
			get { 
				return sdt.gxTpr_Memotopoffset;

			}
			set { 
				sdt.gxTpr_Memotopoffset = value;
			}
		}

		[DataMember(Name="MemoTitleAngle", Order=21)]
		public decimal gxTpr_Memotitleangle
		{
			get { 
				return sdt.gxTpr_Memotitleangle;

			}
			set { 
				sdt.gxTpr_Memotitleangle = value;
			}
		}

		[DataMember(Name="MemoTitleScale", Order=22)]
		public decimal gxTpr_Memotitlescale
		{
			get { 
				return sdt.gxTpr_Memotitlescale;

			}
			set { 
				sdt.gxTpr_Memotitlescale = value;
			}
		}

		[DataMember(Name="MemoTextFontName", Order=23)]
		public  string gxTpr_Memotextfontname
		{
			get { 
				return sdt.gxTpr_Memotextfontname;

			}
			set { 
				 sdt.gxTpr_Memotextfontname = value;
			}
		}

		[DataMember(Name="MemoTextAlignment", Order=24)]
		public  string gxTpr_Memotextalignment
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Memotextalignment);

			}
			set { 
				 sdt.gxTpr_Memotextalignment = value;
			}
		}

		[DataMember(Name="MemoIsBold", Order=25)]
		public bool gxTpr_Memoisbold
		{
			get { 
				return sdt.gxTpr_Memoisbold;

			}
			set { 
				sdt.gxTpr_Memoisbold = value;
			}
		}

		[DataMember(Name="MemoIsItalic", Order=26)]
		public bool gxTpr_Memoisitalic
		{
			get { 
				return sdt.gxTpr_Memoisitalic;

			}
			set { 
				sdt.gxTpr_Memoisitalic = value;
			}
		}

		[DataMember(Name="MemoIsCapitalized", Order=27)]
		public bool gxTpr_Memoiscapitalized
		{
			get { 
				return sdt.gxTpr_Memoiscapitalized;

			}
			set { 
				sdt.gxTpr_Memoiscapitalized = value;
			}
		}

		[DataMember(Name="MemoTextColor", Order=28)]
		public  string gxTpr_Memotextcolor
		{
			get { 
				return sdt.gxTpr_Memotextcolor;

			}
			set { 
				 sdt.gxTpr_Memotextcolor = value;
			}
		}


		#endregion

		public SdtSDT_Memo sdt
		{
			get { 
				return (SdtSDT_Memo)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDT_Memo() ;
			}
		}
	}
	#endregion
}