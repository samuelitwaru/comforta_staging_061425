/*
				   File: type_SdtSDT_AgendaLocation
			Description: SDT_AgendaLocation
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
	[XmlRoot(ElementName="SDT_AgendaLocation")]
	[XmlType(TypeName="SDT_AgendaLocation" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_AgendaLocation : GxUserType
	{
		public SdtSDT_AgendaLocation( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_AgendaLocation_Agendacalendartitle = "";

			gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_AgendaLocation_Agendacalendartype = "";

			gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurringtype = "";

		}

		public SdtSDT_AgendaLocation(IGxContext context)
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
			AddObjectProperty("AgendaCalendarId", gxTpr_Agendacalendarid, false);


			AddObjectProperty("AgendaCalendarTitle", gxTpr_Agendacalendartitle, false);


			datetime_STZ = gxTpr_Agendacalendarstartdate;
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
			AddObjectProperty("AgendaCalendarStartDate", sDateCnv, false);



			datetime_STZ = gxTpr_Agendacalendarenddate;
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
			AddObjectProperty("AgendaCalendarEndDate", sDateCnv, false);



			AddObjectProperty("AgendaCalendarAllDay", gxTpr_Agendacalendarallday, false);


			AddObjectProperty("AgendaCalendarType", gxTpr_Agendacalendartype, false);


			AddObjectProperty("AgendaCalendarRecurring", gxTpr_Agendacalendarrecurring, false);


			AddObjectProperty("AgendaCalendarRecurringType", gxTpr_Agendacalendarrecurringtype, false);


			AddObjectProperty("AgendaCalendarAddRSVP", gxTpr_Agendacalendaraddrsvp, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AgendaCalendarId")]
		[XmlElement(ElementName="AgendaCalendarId")]
		public Guid gxTpr_Agendacalendarid
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendarid; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarid = value;
				SetDirty("Agendacalendarid");
			}
		}




		[SoapElement(ElementName="AgendaCalendarTitle")]
		[XmlElement(ElementName="AgendaCalendarTitle")]
		public string gxTpr_Agendacalendartitle
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendartitle; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendartitle = value;
				SetDirty("Agendacalendartitle");
			}
		}



		[SoapElement(ElementName="AgendaCalendarStartDate")]
		[XmlElement(ElementName="AgendaCalendarStartDate" , IsNullable=true)]
		public string gxTpr_Agendacalendarstartdate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate).value ;
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Agendacalendarstartdate
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate = value;
				SetDirty("Agendacalendarstartdate");
			}
		}


		[SoapElement(ElementName="AgendaCalendarEndDate")]
		[XmlElement(ElementName="AgendaCalendarEndDate" , IsNullable=true)]
		public string gxTpr_Agendacalendarenddate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate).value ;
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Agendacalendarenddate
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate = value;
				SetDirty("Agendacalendarenddate");
			}
		}



		[SoapElement(ElementName="AgendaCalendarAllDay")]
		[XmlElement(ElementName="AgendaCalendarAllDay")]
		public bool gxTpr_Agendacalendarallday
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendarallday; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarallday = value;
				SetDirty("Agendacalendarallday");
			}
		}




		[SoapElement(ElementName="AgendaCalendarType")]
		[XmlElement(ElementName="AgendaCalendarType")]
		public string gxTpr_Agendacalendartype
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendartype; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendartype = value;
				SetDirty("Agendacalendartype");
			}
		}




		[SoapElement(ElementName="AgendaCalendarRecurring")]
		[XmlElement(ElementName="AgendaCalendarRecurring")]
		public bool gxTpr_Agendacalendarrecurring
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurring; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurring = value;
				SetDirty("Agendacalendarrecurring");
			}
		}




		[SoapElement(ElementName="AgendaCalendarRecurringType")]
		[XmlElement(ElementName="AgendaCalendarRecurringType")]
		public string gxTpr_Agendacalendarrecurringtype
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurringtype; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurringtype = value;
				SetDirty("Agendacalendarrecurringtype");
			}
		}




		[SoapElement(ElementName="AgendaCalendarAddRSVP")]
		[XmlElement(ElementName="AgendaCalendarAddRSVP")]
		public bool gxTpr_Agendacalendaraddrsvp
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Agendacalendaraddrsvp; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Agendacalendaraddrsvp = value;
				SetDirty("Agendacalendaraddrsvp");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Locationid; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_AgendaLocation_Organisationid; 
			}
			set {
				gxTv_SdtSDT_AgendaLocation_Organisationid = value;
				SetDirty("Organisationid");
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
			gxTv_SdtSDT_AgendaLocation_Agendacalendartitle = "";
			gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_AgendaLocation_Agendacalendartype = "";

			gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurringtype = "";



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

		protected Guid gxTv_SdtSDT_AgendaLocation_Agendacalendarid;
		 

		protected string gxTv_SdtSDT_AgendaLocation_Agendacalendartitle;
		 

		protected DateTime gxTv_SdtSDT_AgendaLocation_Agendacalendarstartdate;
		 

		protected DateTime gxTv_SdtSDT_AgendaLocation_Agendacalendarenddate;
		 

		protected bool gxTv_SdtSDT_AgendaLocation_Agendacalendarallday;
		 

		protected string gxTv_SdtSDT_AgendaLocation_Agendacalendartype;
		 

		protected bool gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurring;
		 

		protected string gxTv_SdtSDT_AgendaLocation_Agendacalendarrecurringtype;
		 

		protected bool gxTv_SdtSDT_AgendaLocation_Agendacalendaraddrsvp;
		 

		protected Guid gxTv_SdtSDT_AgendaLocation_Locationid;
		 

		protected Guid gxTv_SdtSDT_AgendaLocation_Organisationid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_AgendaLocation", Namespace="Comforta_version21")]
	public class SdtSDT_AgendaLocation_RESTInterface : GxGenericCollectionItem<SdtSDT_AgendaLocation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_AgendaLocation_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_AgendaLocation_RESTInterface( SdtSDT_AgendaLocation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AgendaCalendarId", Order=0)]
		public Guid gxTpr_Agendacalendarid
		{
			get { 
				return sdt.gxTpr_Agendacalendarid;

			}
			set { 
				sdt.gxTpr_Agendacalendarid = value;
			}
		}

		[DataMember(Name="AgendaCalendarTitle", Order=1)]
		public  string gxTpr_Agendacalendartitle
		{
			get { 
				return sdt.gxTpr_Agendacalendartitle;

			}
			set { 
				 sdt.gxTpr_Agendacalendartitle = value;
			}
		}

		[DataMember(Name="AgendaCalendarStartDate", Order=2)]
		public  string gxTpr_Agendacalendarstartdate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Agendacalendarstartdate,context);

			}
			set { 
				sdt.gxTpr_Agendacalendarstartdate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="AgendaCalendarEndDate", Order=3)]
		public  string gxTpr_Agendacalendarenddate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Agendacalendarenddate,context);

			}
			set { 
				sdt.gxTpr_Agendacalendarenddate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="AgendaCalendarAllDay", Order=4)]
		public bool gxTpr_Agendacalendarallday
		{
			get { 
				return sdt.gxTpr_Agendacalendarallday;

			}
			set { 
				sdt.gxTpr_Agendacalendarallday = value;
			}
		}

		[DataMember(Name="AgendaCalendarType", Order=5)]
		public  string gxTpr_Agendacalendartype
		{
			get { 
				return sdt.gxTpr_Agendacalendartype;

			}
			set { 
				 sdt.gxTpr_Agendacalendartype = value;
			}
		}

		[DataMember(Name="AgendaCalendarRecurring", Order=6)]
		public bool gxTpr_Agendacalendarrecurring
		{
			get { 
				return sdt.gxTpr_Agendacalendarrecurring;

			}
			set { 
				sdt.gxTpr_Agendacalendarrecurring = value;
			}
		}

		[DataMember(Name="AgendaCalendarRecurringType", Order=7)]
		public  string gxTpr_Agendacalendarrecurringtype
		{
			get { 
				return sdt.gxTpr_Agendacalendarrecurringtype;

			}
			set { 
				 sdt.gxTpr_Agendacalendarrecurringtype = value;
			}
		}

		[DataMember(Name="AgendaCalendarAddRSVP", Order=8)]
		public bool gxTpr_Agendacalendaraddrsvp
		{
			get { 
				return sdt.gxTpr_Agendacalendaraddrsvp;

			}
			set { 
				sdt.gxTpr_Agendacalendaraddrsvp = value;
			}
		}

		[DataMember(Name="LocationId", Order=9)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=10)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}


		#endregion

		public SdtSDT_AgendaLocation sdt
		{
			get { 
				return (SdtSDT_AgendaLocation)Sdt;
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
				sdt = new SdtSDT_AgendaLocation() ;
			}
		}
	}
	#endregion
}