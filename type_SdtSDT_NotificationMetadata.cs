/*
				   File: type_SdtSDT_NotificationMetadata
			Description: SDT_NotificationMetadata
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
	[XmlRoot(ElementName="SDT_NotificationMetadata")]
	[XmlType(TypeName="SDT_NotificationMetadata" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_NotificationMetadata : GxUserType
	{
		public SdtSDT_NotificationMetadata( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NotificationMetadata_Parentnotificationid = "";

			gxTv_SdtSDT_NotificationMetadata_Formreferencename = "";

			gxTv_SdtSDT_NotificationMetadata_Notificationorigin = "";

			gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp = (DateTime)(DateTime.MinValue);

		}

		public SdtSDT_NotificationMetadata(IGxContext context)
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
			AddObjectProperty("isParentNotification", gxTpr_Isparentnotification, false);


			AddObjectProperty("ParentNotificationId", gxTpr_Parentnotificationid, false);


			AddObjectProperty("FormReferenceName", gxTpr_Formreferencename, false);


			AddObjectProperty("NotificationOrigin", gxTpr_Notificationorigin, false);


			datetime_STZ = gxTpr_Notificationtriggeredtimestamp;
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
			AddObjectProperty("NotificationTriggeredTimestamp", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="isParentNotification")]
		[XmlElement(ElementName="isParentNotification")]
		public bool gxTpr_Isparentnotification
		{
			get {
				return gxTv_SdtSDT_NotificationMetadata_Isparentnotification; 
			}
			set {
				gxTv_SdtSDT_NotificationMetadata_Isparentnotification = value;
				SetDirty("Isparentnotification");
			}
		}




		[SoapElement(ElementName="ParentNotificationId")]
		[XmlElement(ElementName="ParentNotificationId")]
		public string gxTpr_Parentnotificationid
		{
			get {
				return gxTv_SdtSDT_NotificationMetadata_Parentnotificationid; 
			}
			set {
				gxTv_SdtSDT_NotificationMetadata_Parentnotificationid = value;
				SetDirty("Parentnotificationid");
			}
		}




		[SoapElement(ElementName="FormReferenceName")]
		[XmlElement(ElementName="FormReferenceName")]
		public string gxTpr_Formreferencename
		{
			get {
				return gxTv_SdtSDT_NotificationMetadata_Formreferencename; 
			}
			set {
				gxTv_SdtSDT_NotificationMetadata_Formreferencename = value;
				SetDirty("Formreferencename");
			}
		}




		[SoapElement(ElementName="NotificationOrigin")]
		[XmlElement(ElementName="NotificationOrigin")]
		public string gxTpr_Notificationorigin
		{
			get {
				return gxTv_SdtSDT_NotificationMetadata_Notificationorigin; 
			}
			set {
				gxTv_SdtSDT_NotificationMetadata_Notificationorigin = value;
				SetDirty("Notificationorigin");
			}
		}



		[SoapElement(ElementName="NotificationTriggeredTimestamp")]
		[XmlElement(ElementName="NotificationTriggeredTimestamp" , IsNullable=true)]
		public string gxTpr_Notificationtriggeredtimestamp_Nullable
		{
			get {
				if ( gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp).value ;
			}
			set {
				gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Notificationtriggeredtimestamp
		{
			get {
				return gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp; 
			}
			set {
				gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp = value;
				SetDirty("Notificationtriggeredtimestamp");
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
			gxTv_SdtSDT_NotificationMetadata_Parentnotificationid = "";
			gxTv_SdtSDT_NotificationMetadata_Formreferencename = "";
			gxTv_SdtSDT_NotificationMetadata_Notificationorigin = "";
			gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp = (DateTime)(DateTime.MinValue);
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

		protected bool gxTv_SdtSDT_NotificationMetadata_Isparentnotification;
		 

		protected string gxTv_SdtSDT_NotificationMetadata_Parentnotificationid;
		 

		protected string gxTv_SdtSDT_NotificationMetadata_Formreferencename;
		 

		protected string gxTv_SdtSDT_NotificationMetadata_Notificationorigin;
		 

		protected DateTime gxTv_SdtSDT_NotificationMetadata_Notificationtriggeredtimestamp;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_NotificationMetadata", Namespace="Comforta_version21")]
	public class SdtSDT_NotificationMetadata_RESTInterface : GxGenericCollectionItem<SdtSDT_NotificationMetadata>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NotificationMetadata_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NotificationMetadata_RESTInterface( SdtSDT_NotificationMetadata psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="isParentNotification", Order=0)]
		public bool gxTpr_Isparentnotification
		{
			get { 
				return sdt.gxTpr_Isparentnotification;

			}
			set { 
				sdt.gxTpr_Isparentnotification = value;
			}
		}

		[DataMember(Name="ParentNotificationId", Order=1)]
		public  string gxTpr_Parentnotificationid
		{
			get { 
				return sdt.gxTpr_Parentnotificationid;

			}
			set { 
				 sdt.gxTpr_Parentnotificationid = value;
			}
		}

		[DataMember(Name="FormReferenceName", Order=2)]
		public  string gxTpr_Formreferencename
		{
			get { 
				return sdt.gxTpr_Formreferencename;

			}
			set { 
				 sdt.gxTpr_Formreferencename = value;
			}
		}

		[DataMember(Name="NotificationOrigin", Order=3)]
		public  string gxTpr_Notificationorigin
		{
			get { 
				return sdt.gxTpr_Notificationorigin;

			}
			set { 
				 sdt.gxTpr_Notificationorigin = value;
			}
		}

		[DataMember(Name="NotificationTriggeredTimestamp", Order=4)]
		public  string gxTpr_Notificationtriggeredtimestamp
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Notificationtriggeredtimestamp,context);

			}
			set { 
				sdt.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.CToT2(value,context);
			}
		}


		#endregion

		public SdtSDT_NotificationMetadata sdt
		{
			get { 
				return (SdtSDT_NotificationMetadata)Sdt;
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
				sdt = new SdtSDT_NotificationMetadata() ;
			}
		}
	}
	#endregion
}