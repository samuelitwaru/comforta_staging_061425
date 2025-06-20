/*
				   File: type_SdtSDT_ReceivedNotification
			Description: SDT_ReceivedNotification
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
	[XmlRoot(ElementName="SDT_ReceivedNotification")]
	[XmlType(TypeName="SDT_ReceivedNotification" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ReceivedNotification : GxUserType
	{
		public SdtSDT_ReceivedNotification( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionname = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationicon = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationtitle = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationshortdescription = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationlink = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedid = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedfullname = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationmetadata = "";

		}

		public SdtSDT_ReceivedNotification(IGxContext context)
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
			AddObjectProperty("WWPNotificationId", gxTpr_Wwpnotificationid, false);


			AddObjectProperty("WWPNotificationDefinitionId", gxTpr_Wwpnotificationdefinitionid, false);


			AddObjectProperty("WWPNotificationDefinitionName", gxTpr_Wwpnotificationdefinitionname, false);


			datetime_STZ = gxTpr_Wwpnotificationcreated;
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
			AddObjectProperty("WWPNotificationCreated", sDateCnv, false);



			AddObjectProperty("WWPNotificationIcon", gxTpr_Wwpnotificationicon, false);


			AddObjectProperty("WWPNotificationTitle", gxTpr_Wwpnotificationtitle, false);


			AddObjectProperty("WWPNotificationShortDescription", gxTpr_Wwpnotificationshortdescription, false);


			AddObjectProperty("WWPNotificationLink", gxTpr_Wwpnotificationlink, false);


			AddObjectProperty("WWPNotificationIsRead", gxTpr_Wwpnotificationisread, false);


			AddObjectProperty("WWPUserExtendedId", gxTpr_Wwpuserextendedid, false);


			AddObjectProperty("WWPUserExtendedFullName", gxTpr_Wwpuserextendedfullname, false);


			AddObjectProperty("WWPNotificationMetadata", gxTpr_Wwpnotificationmetadata, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="WWPNotificationId")]
		[XmlElement(ElementName="WWPNotificationId")]
		public long gxTpr_Wwpnotificationid
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationid; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationid = value;
				SetDirty("Wwpnotificationid");
			}
		}




		[SoapElement(ElementName="WWPNotificationDefinitionId")]
		[XmlElement(ElementName="WWPNotificationDefinitionId")]
		public long gxTpr_Wwpnotificationdefinitionid
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionid; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionid = value;
				SetDirty("Wwpnotificationdefinitionid");
			}
		}




		[SoapElement(ElementName="WWPNotificationDefinitionName")]
		[XmlElement(ElementName="WWPNotificationDefinitionName")]
		public string gxTpr_Wwpnotificationdefinitionname
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionname; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionname = value;
				SetDirty("Wwpnotificationdefinitionname");
			}
		}



		[SoapElement(ElementName="WWPNotificationCreated")]
		[XmlElement(ElementName="WWPNotificationCreated" , IsNullable=true)]
		public string gxTpr_Wwpnotificationcreated_Nullable
		{
			get {
				if ( gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated).value ;
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Wwpnotificationcreated
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated = value;
				SetDirty("Wwpnotificationcreated");
			}
		}



		[SoapElement(ElementName="WWPNotificationIcon")]
		[XmlElement(ElementName="WWPNotificationIcon")]
		public string gxTpr_Wwpnotificationicon
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationicon; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationicon = value;
				SetDirty("Wwpnotificationicon");
			}
		}




		[SoapElement(ElementName="WWPNotificationTitle")]
		[XmlElement(ElementName="WWPNotificationTitle")]
		public string gxTpr_Wwpnotificationtitle
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationtitle; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationtitle = value;
				SetDirty("Wwpnotificationtitle");
			}
		}




		[SoapElement(ElementName="WWPNotificationShortDescription")]
		[XmlElement(ElementName="WWPNotificationShortDescription")]
		public string gxTpr_Wwpnotificationshortdescription
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationshortdescription; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationshortdescription = value;
				SetDirty("Wwpnotificationshortdescription");
			}
		}




		[SoapElement(ElementName="WWPNotificationLink")]
		[XmlElement(ElementName="WWPNotificationLink")]
		public string gxTpr_Wwpnotificationlink
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationlink; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationlink = value;
				SetDirty("Wwpnotificationlink");
			}
		}




		[SoapElement(ElementName="WWPNotificationIsRead")]
		[XmlElement(ElementName="WWPNotificationIsRead")]
		public bool gxTpr_Wwpnotificationisread
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationisread; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationisread = value;
				SetDirty("Wwpnotificationisread");
			}
		}




		[SoapElement(ElementName="WWPUserExtendedId")]
		[XmlElement(ElementName="WWPUserExtendedId")]
		public string gxTpr_Wwpuserextendedid
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedid; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedid = value;
				SetDirty("Wwpuserextendedid");
			}
		}




		[SoapElement(ElementName="WWPUserExtendedFullName")]
		[XmlElement(ElementName="WWPUserExtendedFullName")]
		public string gxTpr_Wwpuserextendedfullname
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedfullname; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedfullname = value;
				SetDirty("Wwpuserextendedfullname");
			}
		}




		[SoapElement(ElementName="WWPNotificationMetadata")]
		[XmlElement(ElementName="WWPNotificationMetadata")]
		public string gxTpr_Wwpnotificationmetadata
		{
			get {
				return gxTv_SdtSDT_ReceivedNotification_Wwpnotificationmetadata; 
			}
			set {
				gxTv_SdtSDT_ReceivedNotification_Wwpnotificationmetadata = value;
				SetDirty("Wwpnotificationmetadata");
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
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionname = "";
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationicon = "";
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationtitle = "";
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationshortdescription = "";
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationlink = "";

			gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedid = "";
			gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedfullname = "";
			gxTv_SdtSDT_ReceivedNotification_Wwpnotificationmetadata = "";
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

		protected long gxTv_SdtSDT_ReceivedNotification_Wwpnotificationid;
		 

		protected long gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionid;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpnotificationdefinitionname;
		 

		protected DateTime gxTv_SdtSDT_ReceivedNotification_Wwpnotificationcreated;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpnotificationicon;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpnotificationtitle;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpnotificationshortdescription;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpnotificationlink;
		 

		protected bool gxTv_SdtSDT_ReceivedNotification_Wwpnotificationisread;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedid;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpuserextendedfullname;
		 

		protected string gxTv_SdtSDT_ReceivedNotification_Wwpnotificationmetadata;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ReceivedNotification", Namespace="Comforta_version2")]
	public class SdtSDT_ReceivedNotification_RESTInterface : GxGenericCollectionItem<SdtSDT_ReceivedNotification>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ReceivedNotification_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ReceivedNotification_RESTInterface( SdtSDT_ReceivedNotification psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="WWPNotificationId", Order=0)]
		public  string gxTpr_Wwpnotificationid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Wwpnotificationid, 10, 0));

			}
			set { 
				sdt.gxTpr_Wwpnotificationid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="WWPNotificationDefinitionId", Order=1)]
		public  string gxTpr_Wwpnotificationdefinitionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Wwpnotificationdefinitionid, 10, 0));

			}
			set { 
				sdt.gxTpr_Wwpnotificationdefinitionid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="WWPNotificationDefinitionName", Order=2)]
		public  string gxTpr_Wwpnotificationdefinitionname
		{
			get { 
				return sdt.gxTpr_Wwpnotificationdefinitionname;

			}
			set { 
				 sdt.gxTpr_Wwpnotificationdefinitionname = value;
			}
		}

		[DataMember(Name="WWPNotificationCreated", Order=3)]
		public  string gxTpr_Wwpnotificationcreated
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Wwpnotificationcreated,context);

			}
			set { 
				sdt.gxTpr_Wwpnotificationcreated = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="WWPNotificationIcon", Order=4)]
		public  string gxTpr_Wwpnotificationicon
		{
			get { 
				return sdt.gxTpr_Wwpnotificationicon;

			}
			set { 
				 sdt.gxTpr_Wwpnotificationicon = value;
			}
		}

		[DataMember(Name="WWPNotificationTitle", Order=5)]
		public  string gxTpr_Wwpnotificationtitle
		{
			get { 
				return sdt.gxTpr_Wwpnotificationtitle;

			}
			set { 
				 sdt.gxTpr_Wwpnotificationtitle = value;
			}
		}

		[DataMember(Name="WWPNotificationShortDescription", Order=6)]
		public  string gxTpr_Wwpnotificationshortdescription
		{
			get { 
				return sdt.gxTpr_Wwpnotificationshortdescription;

			}
			set { 
				 sdt.gxTpr_Wwpnotificationshortdescription = value;
			}
		}

		[DataMember(Name="WWPNotificationLink", Order=7)]
		public  string gxTpr_Wwpnotificationlink
		{
			get { 
				return sdt.gxTpr_Wwpnotificationlink;

			}
			set { 
				 sdt.gxTpr_Wwpnotificationlink = value;
			}
		}

		[DataMember(Name="WWPNotificationIsRead", Order=8)]
		public bool gxTpr_Wwpnotificationisread
		{
			get { 
				return sdt.gxTpr_Wwpnotificationisread;

			}
			set { 
				sdt.gxTpr_Wwpnotificationisread = value;
			}
		}

		[DataMember(Name="WWPUserExtendedId", Order=9)]
		public  string gxTpr_Wwpuserextendedid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedid);

			}
			set { 
				 sdt.gxTpr_Wwpuserextendedid = value;
			}
		}

		[DataMember(Name="WWPUserExtendedFullName", Order=10)]
		public  string gxTpr_Wwpuserextendedfullname
		{
			get { 
				return sdt.gxTpr_Wwpuserextendedfullname;

			}
			set { 
				 sdt.gxTpr_Wwpuserextendedfullname = value;
			}
		}

		[DataMember(Name="WWPNotificationMetadata", Order=11)]
		public  string gxTpr_Wwpnotificationmetadata
		{
			get { 
				return sdt.gxTpr_Wwpnotificationmetadata;

			}
			set { 
				 sdt.gxTpr_Wwpnotificationmetadata = value;
			}
		}


		#endregion

		public SdtSDT_ReceivedNotification sdt
		{
			get { 
				return (SdtSDT_ReceivedNotification)Sdt;
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
				sdt = new SdtSDT_ReceivedNotification() ;
			}
		}
	}
	#endregion
}