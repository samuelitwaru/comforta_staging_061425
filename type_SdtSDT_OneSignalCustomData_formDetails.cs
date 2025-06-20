/*
				   File: type_SdtSDT_OneSignalCustomData_formDetails
			Description: formDetails
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
	[XmlRoot(ElementName="SDT_OneSignalCustomData.formDetails")]
	[XmlType(TypeName="SDT_OneSignalCustomData.formDetails" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomData_formDetails : GxUserType
	{
		public SdtSDT_OneSignalCustomData_formDetails( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalCustomData_formDetails_Formmode = "";

			gxTv_SdtSDT_OneSignalCustomData_formDetails_Formreferencename = "";

		}

		public SdtSDT_OneSignalCustomData_formDetails(IGxContext context)
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
			AddObjectProperty("formMode", gxTpr_Formmode, false);


			AddObjectProperty("formInstanceId", gxTpr_Forminstanceid, false);


			AddObjectProperty("formReferenceName", gxTpr_Formreferencename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="formMode")]
		[XmlElement(ElementName="formMode")]
		public string gxTpr_Formmode
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_formDetails_Formmode; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_formDetails_Formmode = value;
				SetDirty("Formmode");
			}
		}




		[SoapElement(ElementName="formInstanceId")]
		[XmlElement(ElementName="formInstanceId")]
		public short gxTpr_Forminstanceid
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_formDetails_Forminstanceid; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_formDetails_Forminstanceid = value;
				SetDirty("Forminstanceid");
			}
		}




		[SoapElement(ElementName="formReferenceName")]
		[XmlElement(ElementName="formReferenceName")]
		public string gxTpr_Formreferencename
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_formDetails_Formreferencename; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_formDetails_Formreferencename = value;
				SetDirty("Formreferencename");
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
			gxTv_SdtSDT_OneSignalCustomData_formDetails_Formmode = "";

			gxTv_SdtSDT_OneSignalCustomData_formDetails_Formreferencename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalCustomData_formDetails_Formmode;
		 

		protected short gxTv_SdtSDT_OneSignalCustomData_formDetails_Forminstanceid;
		 

		protected string gxTv_SdtSDT_OneSignalCustomData_formDetails_Formreferencename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomData.formDetails", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalCustomData_formDetails_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomData_formDetails>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomData_formDetails_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomData_formDetails_RESTInterface( SdtSDT_OneSignalCustomData_formDetails psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="formMode", Order=0)]
		public  string gxTpr_Formmode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Formmode);

			}
			set { 
				 sdt.gxTpr_Formmode = value;
			}
		}

		[DataMember(Name="formInstanceId", Order=1)]
		public short gxTpr_Forminstanceid
		{
			get { 
				return sdt.gxTpr_Forminstanceid;

			}
			set { 
				sdt.gxTpr_Forminstanceid = value;
			}
		}

		[DataMember(Name="formReferenceName", Order=2)]
		public  string gxTpr_Formreferencename
		{
			get { 
				return sdt.gxTpr_Formreferencename;

			}
			set { 
				 sdt.gxTpr_Formreferencename = value;
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomData_formDetails sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomData_formDetails)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomData_formDetails() ;
			}
		}
	}
	#endregion
}