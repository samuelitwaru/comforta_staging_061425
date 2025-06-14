/*
				   File: type_SdtUSDTNotificationMetadata
			Description: USDTNotificationMetadata
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
	[XmlRoot(ElementName="USDTNotificationMetadata")]
	[XmlType(TypeName="USDTNotificationMetadata" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtUSDTNotificationMetadata : GxUserType
	{
		public SdtUSDTNotificationMetadata( )
		{
			/* Constructor for serialization */
			gxTv_SdtUSDTNotificationMetadata_Sessionkey = "";

			gxTv_SdtUSDTNotificationMetadata_Sessionvalue = "";

		}

		public SdtUSDTNotificationMetadata(IGxContext context)
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
			AddObjectProperty("Timeout", gxTpr_Timeout, false);


			AddObjectProperty("SessionKey", gxTpr_Sessionkey, false);


			AddObjectProperty("SessionValue", gxTpr_Sessionvalue, false);

			if (gxTv_SdtUSDTNotificationMetadata_Custommetadata != null)
			{
				AddObjectProperty("CustomMetaData", gxTv_SdtUSDTNotificationMetadata_Custommetadata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Timeout")]
		[XmlElement(ElementName="Timeout")]
		public int gxTpr_Timeout
		{
			get {
				return gxTv_SdtUSDTNotificationMetadata_Timeout; 
			}
			set {
				gxTv_SdtUSDTNotificationMetadata_Timeout = value;
				SetDirty("Timeout");
			}
		}




		[SoapElement(ElementName="SessionKey")]
		[XmlElement(ElementName="SessionKey")]
		public string gxTpr_Sessionkey
		{
			get {
				return gxTv_SdtUSDTNotificationMetadata_Sessionkey; 
			}
			set {
				gxTv_SdtUSDTNotificationMetadata_Sessionkey = value;
				SetDirty("Sessionkey");
			}
		}




		[SoapElement(ElementName="SessionValue")]
		[XmlElement(ElementName="SessionValue")]
		public string gxTpr_Sessionvalue
		{
			get {
				return gxTv_SdtUSDTNotificationMetadata_Sessionvalue; 
			}
			set {
				gxTv_SdtUSDTNotificationMetadata_Sessionvalue = value;
				SetDirty("Sessionvalue");
			}
		}



		[SoapElement(ElementName="CustomMetaData")]
		[XmlElement(ElementName="CustomMetaData")]
		public GeneXus.Programs.SdtSDT_NotificationMetadata gxTpr_Custommetadata
		{
			get {
				if ( gxTv_SdtUSDTNotificationMetadata_Custommetadata == null )
				{
					gxTv_SdtUSDTNotificationMetadata_Custommetadata = new GeneXus.Programs.SdtSDT_NotificationMetadata(context);
				}
				return gxTv_SdtUSDTNotificationMetadata_Custommetadata; 
			}
			set {
				gxTv_SdtUSDTNotificationMetadata_Custommetadata = value;
				SetDirty("Custommetadata");
			}
		}
		public void gxTv_SdtUSDTNotificationMetadata_Custommetadata_SetNull()
		{
			gxTv_SdtUSDTNotificationMetadata_Custommetadata_N = true;
			gxTv_SdtUSDTNotificationMetadata_Custommetadata = null;
		}

		public bool gxTv_SdtUSDTNotificationMetadata_Custommetadata_IsNull()
		{
			return gxTv_SdtUSDTNotificationMetadata_Custommetadata == null;
		}
		public bool ShouldSerializegxTpr_Custommetadata_Json()
		{
			return gxTv_SdtUSDTNotificationMetadata_Custommetadata != null;

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
			gxTv_SdtUSDTNotificationMetadata_Sessionkey = "";
			gxTv_SdtUSDTNotificationMetadata_Sessionvalue = "";

			gxTv_SdtUSDTNotificationMetadata_Custommetadata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtUSDTNotificationMetadata_Timeout;
		 

		protected string gxTv_SdtUSDTNotificationMetadata_Sessionkey;
		 

		protected string gxTv_SdtUSDTNotificationMetadata_Sessionvalue;
		 

		protected GeneXus.Programs.SdtSDT_NotificationMetadata gxTv_SdtUSDTNotificationMetadata_Custommetadata = null;
		protected bool gxTv_SdtUSDTNotificationMetadata_Custommetadata_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"USDTNotificationMetadata", Namespace="Comforta_version21")]
	public class SdtUSDTNotificationMetadata_RESTInterface : GxGenericCollectionItem<SdtUSDTNotificationMetadata>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtUSDTNotificationMetadata_RESTInterface( ) : base()
		{	
		}

		public SdtUSDTNotificationMetadata_RESTInterface( SdtUSDTNotificationMetadata psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Timeout", Order=0)]
		public  string gxTpr_Timeout
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Timeout, 8, 0));

			}
			set { 
				sdt.gxTpr_Timeout = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SessionKey", Order=1)]
		public  string gxTpr_Sessionkey
		{
			get { 
				return sdt.gxTpr_Sessionkey;

			}
			set { 
				 sdt.gxTpr_Sessionkey = value;
			}
		}

		[DataMember(Name="SessionValue", Order=2)]
		public  string gxTpr_Sessionvalue
		{
			get { 
				return sdt.gxTpr_Sessionvalue;

			}
			set { 
				 sdt.gxTpr_Sessionvalue = value;
			}
		}

		[DataMember(Name="CustomMetaData", Order=3, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_NotificationMetadata_RESTInterface gxTpr_Custommetadata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Custommetadata_Json())
					return new GeneXus.Programs.SdtSDT_NotificationMetadata_RESTInterface(sdt.gxTpr_Custommetadata);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Custommetadata = value.sdt;
			}
		}


		#endregion

		public SdtUSDTNotificationMetadata sdt
		{
			get { 
				return (SdtUSDTNotificationMetadata)Sdt;
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
				sdt = new SdtUSDTNotificationMetadata() ;
			}
		}
	}
	#endregion
}