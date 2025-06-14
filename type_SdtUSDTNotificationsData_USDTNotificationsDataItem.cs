/*
				   File: type_SdtUSDTNotificationsData_USDTNotificationsDataItem
			Description: USDTNotificationsData
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
	[XmlRoot(ElementName="USDTNotificationsDataItem")]
	[XmlType(TypeName="USDTNotificationsDataItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtUSDTNotificationsData_USDTNotificationsDataItem : GxUserType
	{
		public SdtUSDTNotificationsData_USDTNotificationsDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationiconclass = "";

			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationtitle = "";

			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdescription = "";

			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationlink = "";

			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationmetadata = "";

		}

		public SdtUSDTNotificationsData_USDTNotificationsDataItem(IGxContext context)
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
			AddObjectProperty("NotificationId", gxTpr_Notificationid, false);


			AddObjectProperty("NotificationIconClass", gxTpr_Notificationiconclass, false);


			AddObjectProperty("NotificationTitle", gxTpr_Notificationtitle, false);


			AddObjectProperty("NotificationDescription", gxTpr_Notificationdescription, false);


			datetime_STZ = gxTpr_Notificationdatetime;
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
			AddObjectProperty("NotificationDatetime", sDateCnv, false);



			AddObjectProperty("NotificationLink", gxTpr_Notificationlink, false);


			AddObjectProperty("NotificationDefinitionId", gxTpr_Notificationdefinitionid, false);


			AddObjectProperty("NotificationIsRead", gxTpr_Notificationisread, false);


			AddObjectProperty("NotificationMetadata", gxTpr_Notificationmetadata, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NotificationId")]
		[XmlElement(ElementName="NotificationId")]
		public int gxTpr_Notificationid
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationid; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationid = value;
				SetDirty("Notificationid");
			}
		}




		[SoapElement(ElementName="NotificationIconClass")]
		[XmlElement(ElementName="NotificationIconClass")]
		public string gxTpr_Notificationiconclass
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationiconclass; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationiconclass = value;
				SetDirty("Notificationiconclass");
			}
		}




		[SoapElement(ElementName="NotificationTitle")]
		[XmlElement(ElementName="NotificationTitle")]
		public string gxTpr_Notificationtitle
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationtitle; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationtitle = value;
				SetDirty("Notificationtitle");
			}
		}




		[SoapElement(ElementName="NotificationDescription")]
		[XmlElement(ElementName="NotificationDescription")]
		public string gxTpr_Notificationdescription
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdescription; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdescription = value;
				SetDirty("Notificationdescription");
			}
		}



		[SoapElement(ElementName="NotificationDatetime")]
		[XmlElement(ElementName="NotificationDatetime" , IsNullable=true)]
		public string gxTpr_Notificationdatetime_Nullable
		{
			get {
				if ( gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime).value ;
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Notificationdatetime
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime = value;
				SetDirty("Notificationdatetime");
			}
		}



		[SoapElement(ElementName="NotificationLink")]
		[XmlElement(ElementName="NotificationLink")]
		public string gxTpr_Notificationlink
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationlink; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationlink = value;
				SetDirty("Notificationlink");
			}
		}




		[SoapElement(ElementName="NotificationDefinitionId")]
		[XmlElement(ElementName="NotificationDefinitionId")]
		public long gxTpr_Notificationdefinitionid
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdefinitionid; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdefinitionid = value;
				SetDirty("Notificationdefinitionid");
			}
		}




		[SoapElement(ElementName="NotificationIsRead")]
		[XmlElement(ElementName="NotificationIsRead")]
		public bool gxTpr_Notificationisread
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationisread; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationisread = value;
				SetDirty("Notificationisread");
			}
		}




		[SoapElement(ElementName="NotificationMetadata")]
		[XmlElement(ElementName="NotificationMetadata")]
		public string gxTpr_Notificationmetadata
		{
			get {
				return gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationmetadata; 
			}
			set {
				gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationmetadata = value;
				SetDirty("Notificationmetadata");
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
			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationiconclass = "";
			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationtitle = "";
			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdescription = "";
			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationlink = "";


			gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationmetadata = "";
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

		protected int gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationid;
		 

		protected string gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationiconclass;
		 

		protected string gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationtitle;
		 

		protected string gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdescription;
		 

		protected DateTime gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdatetime;
		 

		protected string gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationlink;
		 

		protected long gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationdefinitionid;
		 

		protected bool gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationisread;
		 

		protected string gxTv_SdtUSDTNotificationsData_USDTNotificationsDataItem_Notificationmetadata;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"USDTNotificationsDataItem", Namespace="Comforta_version21")]
	public class SdtUSDTNotificationsData_USDTNotificationsDataItem_RESTInterface : GxGenericCollectionItem<SdtUSDTNotificationsData_USDTNotificationsDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtUSDTNotificationsData_USDTNotificationsDataItem_RESTInterface( ) : base()
		{	
		}

		public SdtUSDTNotificationsData_USDTNotificationsDataItem_RESTInterface( SdtUSDTNotificationsData_USDTNotificationsDataItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NotificationId", Order=0)]
		public int gxTpr_Notificationid
		{
			get { 
				return sdt.gxTpr_Notificationid;

			}
			set { 
				sdt.gxTpr_Notificationid = value;
			}
		}

		[DataMember(Name="NotificationIconClass", Order=1)]
		public  string gxTpr_Notificationiconclass
		{
			get { 
				return sdt.gxTpr_Notificationiconclass;

			}
			set { 
				 sdt.gxTpr_Notificationiconclass = value;
			}
		}

		[DataMember(Name="NotificationTitle", Order=2)]
		public  string gxTpr_Notificationtitle
		{
			get { 
				return sdt.gxTpr_Notificationtitle;

			}
			set { 
				 sdt.gxTpr_Notificationtitle = value;
			}
		}

		[DataMember(Name="NotificationDescription", Order=3)]
		public  string gxTpr_Notificationdescription
		{
			get { 
				return sdt.gxTpr_Notificationdescription;

			}
			set { 
				 sdt.gxTpr_Notificationdescription = value;
			}
		}

		[DataMember(Name="NotificationDatetime", Order=4)]
		public  string gxTpr_Notificationdatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Notificationdatetime,context);

			}
			set { 
				sdt.gxTpr_Notificationdatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="NotificationLink", Order=5)]
		public  string gxTpr_Notificationlink
		{
			get { 
				return sdt.gxTpr_Notificationlink;

			}
			set { 
				 sdt.gxTpr_Notificationlink = value;
			}
		}

		[DataMember(Name="NotificationDefinitionId", Order=6)]
		public  string gxTpr_Notificationdefinitionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Notificationdefinitionid, 10, 0));

			}
			set { 
				sdt.gxTpr_Notificationdefinitionid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NotificationIsRead", Order=7)]
		public bool gxTpr_Notificationisread
		{
			get { 
				return sdt.gxTpr_Notificationisread;

			}
			set { 
				sdt.gxTpr_Notificationisread = value;
			}
		}

		[DataMember(Name="NotificationMetadata", Order=8)]
		public  string gxTpr_Notificationmetadata
		{
			get { 
				return sdt.gxTpr_Notificationmetadata;

			}
			set { 
				 sdt.gxTpr_Notificationmetadata = value;
			}
		}


		#endregion

		public SdtUSDTNotificationsData_USDTNotificationsDataItem sdt
		{
			get { 
				return (SdtUSDTNotificationsData_USDTNotificationsDataItem)Sdt;
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
				sdt = new SdtUSDTNotificationsData_USDTNotificationsDataItem() ;
			}
		}
	}
	#endregion
}