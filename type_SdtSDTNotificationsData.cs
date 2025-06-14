/*
				   File: type_SdtSDTNotificationsData
			Description: SDTNotificationsData
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
	[XmlRoot(ElementName="SDTNotificationsData")]
	[XmlType(TypeName="SDTNotificationsData" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDTNotificationsData : GxUserType
	{
		public SdtSDTNotificationsData( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTNotificationsData_Notificationiconclass = "";

			gxTv_SdtSDTNotificationsData_Notificationdescription = "";

			gxTv_SdtSDTNotificationsData_Notificationdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTNotificationsData_Notificationlink = "";

			gxTv_SdtSDTNotificationsData_Notificationtitle = "";

		}

		public SdtSDTNotificationsData(IGxContext context)
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


			AddObjectProperty("NotificationTitle", gxTpr_Notificationtitle, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NotificationId")]
		[XmlElement(ElementName="NotificationId")]
		public Guid gxTpr_Notificationid
		{
			get {
				return gxTv_SdtSDTNotificationsData_Notificationid; 
			}
			set {
				gxTv_SdtSDTNotificationsData_Notificationid = value;
				SetDirty("Notificationid");
			}
		}




		[SoapElement(ElementName="NotificationIconClass")]
		[XmlElement(ElementName="NotificationIconClass")]
		public string gxTpr_Notificationiconclass
		{
			get {
				return gxTv_SdtSDTNotificationsData_Notificationiconclass; 
			}
			set {
				gxTv_SdtSDTNotificationsData_Notificationiconclass = value;
				SetDirty("Notificationiconclass");
			}
		}




		[SoapElement(ElementName="NotificationDescription")]
		[XmlElement(ElementName="NotificationDescription")]
		public string gxTpr_Notificationdescription
		{
			get {
				return gxTv_SdtSDTNotificationsData_Notificationdescription; 
			}
			set {
				gxTv_SdtSDTNotificationsData_Notificationdescription = value;
				SetDirty("Notificationdescription");
			}
		}



		[SoapElement(ElementName="NotificationDatetime")]
		[XmlElement(ElementName="NotificationDatetime" , IsNullable=true)]
		public string gxTpr_Notificationdatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDTNotificationsData_Notificationdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNotificationsData_Notificationdatetime).value ;
			}
			set {
				gxTv_SdtSDTNotificationsData_Notificationdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Notificationdatetime
		{
			get {
				return gxTv_SdtSDTNotificationsData_Notificationdatetime; 
			}
			set {
				gxTv_SdtSDTNotificationsData_Notificationdatetime = value;
				SetDirty("Notificationdatetime");
			}
		}



		[SoapElement(ElementName="NotificationLink")]
		[XmlElement(ElementName="NotificationLink")]
		public string gxTpr_Notificationlink
		{
			get {
				return gxTv_SdtSDTNotificationsData_Notificationlink; 
			}
			set {
				gxTv_SdtSDTNotificationsData_Notificationlink = value;
				SetDirty("Notificationlink");
			}
		}




		[SoapElement(ElementName="NotificationTitle")]
		[XmlElement(ElementName="NotificationTitle")]
		public string gxTpr_Notificationtitle
		{
			get {
				return gxTv_SdtSDTNotificationsData_Notificationtitle; 
			}
			set {
				gxTv_SdtSDTNotificationsData_Notificationtitle = value;
				SetDirty("Notificationtitle");
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
			gxTv_SdtSDTNotificationsData_Notificationiconclass = "";
			gxTv_SdtSDTNotificationsData_Notificationdescription = "";
			gxTv_SdtSDTNotificationsData_Notificationdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTNotificationsData_Notificationlink = "";
			gxTv_SdtSDTNotificationsData_Notificationtitle = "";
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

		protected Guid gxTv_SdtSDTNotificationsData_Notificationid;
		 

		protected string gxTv_SdtSDTNotificationsData_Notificationiconclass;
		 

		protected string gxTv_SdtSDTNotificationsData_Notificationdescription;
		 

		protected DateTime gxTv_SdtSDTNotificationsData_Notificationdatetime;
		 

		protected string gxTv_SdtSDTNotificationsData_Notificationlink;
		 

		protected string gxTv_SdtSDTNotificationsData_Notificationtitle;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTNotificationsData", Namespace="Comforta_version21")]
	public class SdtSDTNotificationsData_RESTInterface : GxGenericCollectionItem<SdtSDTNotificationsData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTNotificationsData_RESTInterface( ) : base()
		{	
		}

		public SdtSDTNotificationsData_RESTInterface( SdtSDTNotificationsData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NotificationId", Order=0)]
		public Guid gxTpr_Notificationid
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

		[DataMember(Name="NotificationDescription", Order=2)]
		public  string gxTpr_Notificationdescription
		{
			get { 
				return sdt.gxTpr_Notificationdescription;

			}
			set { 
				 sdt.gxTpr_Notificationdescription = value;
			}
		}

		[DataMember(Name="NotificationDatetime", Order=3)]
		public  string gxTpr_Notificationdatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Notificationdatetime,context);

			}
			set { 
				sdt.gxTpr_Notificationdatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="NotificationLink", Order=4)]
		public  string gxTpr_Notificationlink
		{
			get { 
				return sdt.gxTpr_Notificationlink;

			}
			set { 
				 sdt.gxTpr_Notificationlink = value;
			}
		}

		[DataMember(Name="NotificationTitle", Order=5)]
		public  string gxTpr_Notificationtitle
		{
			get { 
				return sdt.gxTpr_Notificationtitle;

			}
			set { 
				 sdt.gxTpr_Notificationtitle = value;
			}
		}


		#endregion

		public SdtSDTNotificationsData sdt
		{
			get { 
				return (SdtSDTNotificationsData)Sdt;
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
				sdt = new SdtSDTNotificationsData() ;
			}
		}
	}
	#endregion
}