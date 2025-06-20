/*
				   File: type_SdtSDT_OneSignalRegistration
			Description: SDT_OneSignalRegistration
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
	[XmlRoot(ElementName="SDT_OneSignalRegistration")]
	[XmlType(TypeName="SDT_OneSignalRegistration" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalRegistration : GxUserType
	{
		public SdtSDT_OneSignalRegistration( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalRegistration_Devicetoken = "";

			gxTv_SdtSDT_OneSignalRegistration_Deviceid = "";

			gxTv_SdtSDT_OneSignalRegistration_Notificationplatform = "";

			gxTv_SdtSDT_OneSignalRegistration_Notificationplatformid = "";

		}

		public SdtSDT_OneSignalRegistration(IGxContext context)
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
			AddObjectProperty("DeviceToken", gxTpr_Devicetoken, false);


			AddObjectProperty("DeviceId", gxTpr_Deviceid, false);


			AddObjectProperty("DeviceType", gxTpr_Devicetype, false);


			AddObjectProperty("NotificationPlatform", gxTpr_Notificationplatform, false);


			AddObjectProperty("NotificationPlatformId", gxTpr_Notificationplatformid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DeviceToken")]
		[XmlElement(ElementName="DeviceToken")]
		public string gxTpr_Devicetoken
		{
			get {
				return gxTv_SdtSDT_OneSignalRegistration_Devicetoken; 
			}
			set {
				gxTv_SdtSDT_OneSignalRegistration_Devicetoken = value;
				SetDirty("Devicetoken");
			}
		}




		[SoapElement(ElementName="DeviceId")]
		[XmlElement(ElementName="DeviceId")]
		public string gxTpr_Deviceid
		{
			get {
				return gxTv_SdtSDT_OneSignalRegistration_Deviceid; 
			}
			set {
				gxTv_SdtSDT_OneSignalRegistration_Deviceid = value;
				SetDirty("Deviceid");
			}
		}



		[SoapElement(ElementName="DeviceType")]
		[XmlElement(ElementName="DeviceType")]
		public string gxTpr_Devicetype_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_OneSignalRegistration_Devicetype, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_OneSignalRegistration_Devicetype = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Devicetype
		{
			get {
				return gxTv_SdtSDT_OneSignalRegistration_Devicetype; 
			}
			set {
				gxTv_SdtSDT_OneSignalRegistration_Devicetype = value;
				SetDirty("Devicetype");
			}
		}




		[SoapElement(ElementName="NotificationPlatform")]
		[XmlElement(ElementName="NotificationPlatform")]
		public string gxTpr_Notificationplatform
		{
			get {
				return gxTv_SdtSDT_OneSignalRegistration_Notificationplatform; 
			}
			set {
				gxTv_SdtSDT_OneSignalRegistration_Notificationplatform = value;
				SetDirty("Notificationplatform");
			}
		}




		[SoapElement(ElementName="NotificationPlatformId")]
		[XmlElement(ElementName="NotificationPlatformId")]
		public string gxTpr_Notificationplatformid
		{
			get {
				return gxTv_SdtSDT_OneSignalRegistration_Notificationplatformid; 
			}
			set {
				gxTv_SdtSDT_OneSignalRegistration_Notificationplatformid = value;
				SetDirty("Notificationplatformid");
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
			gxTv_SdtSDT_OneSignalRegistration_Devicetoken = "";
			gxTv_SdtSDT_OneSignalRegistration_Deviceid = "";

			gxTv_SdtSDT_OneSignalRegistration_Notificationplatform = "";
			gxTv_SdtSDT_OneSignalRegistration_Notificationplatformid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalRegistration_Devicetoken;
		 

		protected string gxTv_SdtSDT_OneSignalRegistration_Deviceid;
		 

		protected decimal gxTv_SdtSDT_OneSignalRegistration_Devicetype;
		 

		protected string gxTv_SdtSDT_OneSignalRegistration_Notificationplatform;
		 

		protected string gxTv_SdtSDT_OneSignalRegistration_Notificationplatformid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalRegistration", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalRegistration_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalRegistration>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalRegistration_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalRegistration_RESTInterface( SdtSDT_OneSignalRegistration psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DeviceToken", Order=0)]
		public  string gxTpr_Devicetoken
		{
			get { 
				return sdt.gxTpr_Devicetoken;

			}
			set { 
				 sdt.gxTpr_Devicetoken = value;
			}
		}

		[DataMember(Name="DeviceId", Order=1)]
		public  string gxTpr_Deviceid
		{
			get { 
				return sdt.gxTpr_Deviceid;

			}
			set { 
				 sdt.gxTpr_Deviceid = value;
			}
		}

		[DataMember(Name="DeviceType", Order=2)]
		public  string gxTpr_Devicetype
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Devicetype, 10, 5));

			}
			set { 
				sdt.gxTpr_Devicetype =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NotificationPlatform", Order=3)]
		public  string gxTpr_Notificationplatform
		{
			get { 
				return sdt.gxTpr_Notificationplatform;

			}
			set { 
				 sdt.gxTpr_Notificationplatform = value;
			}
		}

		[DataMember(Name="NotificationPlatformId", Order=4)]
		public  string gxTpr_Notificationplatformid
		{
			get { 
				return sdt.gxTpr_Notificationplatformid;

			}
			set { 
				 sdt.gxTpr_Notificationplatformid = value;
			}
		}


		#endregion

		public SdtSDT_OneSignalRegistration sdt
		{
			get { 
				return (SdtSDT_OneSignalRegistration)Sdt;
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
				sdt = new SdtSDT_OneSignalRegistration() ;
			}
		}
	}
	#endregion
}