/*
				   File: type_SdtSDT_ResidentNotification
			Description: SDT_ResidentNotification
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
	[XmlRoot(ElementName="SDT_ResidentNotification")]
	[XmlType(TypeName="SDT_ResidentNotification" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_ResidentNotification : GxUserType
	{
		public SdtSDT_ResidentNotification( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ResidentNotification_Notificationtitle = "";

			gxTv_SdtSDT_ResidentNotification_Notificationdescription = "";

			gxTv_SdtSDT_ResidentNotification_Notificationdate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_ResidentNotification_Notificationtopic = "";

		}

		public SdtSDT_ResidentNotification(IGxContext context)
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


			AddObjectProperty("NotificationTitle", gxTpr_Notificationtitle, false);


			AddObjectProperty("NotificationDescription", gxTpr_Notificationdescription, false);


			datetime_STZ = gxTpr_Notificationdate;
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
			AddObjectProperty("NotificationDate", sDateCnv, false);



			AddObjectProperty("NotificationTopic", gxTpr_Notificationtopic, false);

			if (gxTv_SdtSDT_ResidentNotification_Notificationmetadata != null)
			{
				AddObjectProperty("NotificationMetadata", gxTv_SdtSDT_ResidentNotification_Notificationmetadata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NotificationId")]
		[XmlElement(ElementName="NotificationId")]
		public Guid gxTpr_Notificationid
		{
			get {
				return gxTv_SdtSDT_ResidentNotification_Notificationid; 
			}
			set {
				gxTv_SdtSDT_ResidentNotification_Notificationid = value;
				SetDirty("Notificationid");
			}
		}




		[SoapElement(ElementName="NotificationTitle")]
		[XmlElement(ElementName="NotificationTitle")]
		public string gxTpr_Notificationtitle
		{
			get {
				return gxTv_SdtSDT_ResidentNotification_Notificationtitle; 
			}
			set {
				gxTv_SdtSDT_ResidentNotification_Notificationtitle = value;
				SetDirty("Notificationtitle");
			}
		}




		[SoapElement(ElementName="NotificationDescription")]
		[XmlElement(ElementName="NotificationDescription")]
		public string gxTpr_Notificationdescription
		{
			get {
				return gxTv_SdtSDT_ResidentNotification_Notificationdescription; 
			}
			set {
				gxTv_SdtSDT_ResidentNotification_Notificationdescription = value;
				SetDirty("Notificationdescription");
			}
		}



		[SoapElement(ElementName="NotificationDate")]
		[XmlElement(ElementName="NotificationDate" , IsNullable=true)]
		public string gxTpr_Notificationdate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_ResidentNotification_Notificationdate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_ResidentNotification_Notificationdate).value ;
			}
			set {
				gxTv_SdtSDT_ResidentNotification_Notificationdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Notificationdate
		{
			get {
				return gxTv_SdtSDT_ResidentNotification_Notificationdate; 
			}
			set {
				gxTv_SdtSDT_ResidentNotification_Notificationdate = value;
				SetDirty("Notificationdate");
			}
		}



		[SoapElement(ElementName="NotificationTopic")]
		[XmlElement(ElementName="NotificationTopic")]
		public string gxTpr_Notificationtopic
		{
			get {
				return gxTv_SdtSDT_ResidentNotification_Notificationtopic; 
			}
			set {
				gxTv_SdtSDT_ResidentNotification_Notificationtopic = value;
				SetDirty("Notificationtopic");
			}
		}



		[SoapElement(ElementName="NotificationMetadata")]
		[XmlElement(ElementName="NotificationMetadata")]
		public GeneXus.Programs.SdtSDT_OneSignalCustomData gxTpr_Notificationmetadata
		{
			get {
				if ( gxTv_SdtSDT_ResidentNotification_Notificationmetadata == null )
				{
					gxTv_SdtSDT_ResidentNotification_Notificationmetadata = new GeneXus.Programs.SdtSDT_OneSignalCustomData(context);
				}
				return gxTv_SdtSDT_ResidentNotification_Notificationmetadata; 
			}
			set {
				gxTv_SdtSDT_ResidentNotification_Notificationmetadata = value;
				SetDirty("Notificationmetadata");
			}
		}
		public void gxTv_SdtSDT_ResidentNotification_Notificationmetadata_SetNull()
		{
			gxTv_SdtSDT_ResidentNotification_Notificationmetadata_N = true;
			gxTv_SdtSDT_ResidentNotification_Notificationmetadata = null;
		}

		public bool gxTv_SdtSDT_ResidentNotification_Notificationmetadata_IsNull()
		{
			return gxTv_SdtSDT_ResidentNotification_Notificationmetadata == null;
		}
		public bool ShouldSerializegxTpr_Notificationmetadata_Json()
		{
			return gxTv_SdtSDT_ResidentNotification_Notificationmetadata != null;

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
			gxTv_SdtSDT_ResidentNotification_Notificationtitle = "";
			gxTv_SdtSDT_ResidentNotification_Notificationdescription = "";
			gxTv_SdtSDT_ResidentNotification_Notificationdate = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDT_ResidentNotification_Notificationtopic = "";

			gxTv_SdtSDT_ResidentNotification_Notificationmetadata_N = true;

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

		protected Guid gxTv_SdtSDT_ResidentNotification_Notificationid;
		 

		protected string gxTv_SdtSDT_ResidentNotification_Notificationtitle;
		 

		protected string gxTv_SdtSDT_ResidentNotification_Notificationdescription;
		 

		protected DateTime gxTv_SdtSDT_ResidentNotification_Notificationdate;
		 

		protected string gxTv_SdtSDT_ResidentNotification_Notificationtopic;
		 

		protected GeneXus.Programs.SdtSDT_OneSignalCustomData gxTv_SdtSDT_ResidentNotification_Notificationmetadata = null;
		protected bool gxTv_SdtSDT_ResidentNotification_Notificationmetadata_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ResidentNotification", Namespace="Comforta_version21")]
	public class SdtSDT_ResidentNotification_RESTInterface : GxGenericCollectionItem<SdtSDT_ResidentNotification>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ResidentNotification_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ResidentNotification_RESTInterface( SdtSDT_ResidentNotification psdt ) : base(psdt)
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

		[DataMember(Name="NotificationTitle", Order=1)]
		public  string gxTpr_Notificationtitle
		{
			get { 
				return sdt.gxTpr_Notificationtitle;

			}
			set { 
				 sdt.gxTpr_Notificationtitle = value;
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

		[DataMember(Name="NotificationDate", Order=3)]
		public  string gxTpr_Notificationdate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Notificationdate,context);

			}
			set { 
				sdt.gxTpr_Notificationdate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="NotificationTopic", Order=4)]
		public  string gxTpr_Notificationtopic
		{
			get { 
				return sdt.gxTpr_Notificationtopic;

			}
			set { 
				 sdt.gxTpr_Notificationtopic = value;
			}
		}

		[DataMember(Name="NotificationMetadata", Order=5, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_OneSignalCustomData_RESTInterface gxTpr_Notificationmetadata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Notificationmetadata_Json())
					return new GeneXus.Programs.SdtSDT_OneSignalCustomData_RESTInterface(sdt.gxTpr_Notificationmetadata);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Notificationmetadata = value.sdt;
			}
		}


		#endregion

		public SdtSDT_ResidentNotification sdt
		{
			get { 
				return (SdtSDT_ResidentNotification)Sdt;
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
				sdt = new SdtSDT_ResidentNotification() ;
			}
		}
	}
	#endregion
}