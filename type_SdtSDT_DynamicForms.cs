/*
				   File: type_SdtSDT_DynamicForms
			Description: SDT_DynamicForms
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
	[XmlRoot(ElementName="SDT_DynamicForms")]
	[XmlType(TypeName="SDT_DynamicForms" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_DynamicForms : GxUserType
	{
		public SdtSDT_DynamicForms( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DynamicForms_Pagename = "";

			gxTv_SdtSDT_DynamicForms_Referencename = "";

			gxTv_SdtSDT_DynamicForms_Formurl = "";

			gxTv_SdtSDT_DynamicForms_Supplierid = "";

		}

		public SdtSDT_DynamicForms(IGxContext context)
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
			AddObjectProperty("FormId", gxTpr_Formid, false);


			AddObjectProperty("PageName", gxTpr_Pagename, false);


			AddObjectProperty("ReferenceName", gxTpr_Referencename, false);


			AddObjectProperty("FormUrl", gxTpr_Formurl, false);


			AddObjectProperty("SupplierId", gxTpr_Supplierid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FormId")]
		[XmlElement(ElementName="FormId")]
		public short gxTpr_Formid
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Formid; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Formid = value;
				SetDirty("Formid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Pagename; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="ReferenceName")]
		[XmlElement(ElementName="ReferenceName")]
		public string gxTpr_Referencename
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Referencename; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Referencename = value;
				SetDirty("Referencename");
			}
		}




		[SoapElement(ElementName="FormUrl")]
		[XmlElement(ElementName="FormUrl")]
		public string gxTpr_Formurl
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Formurl; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Formurl = value;
				SetDirty("Formurl");
			}
		}




		[SoapElement(ElementName="SupplierId")]
		[XmlElement(ElementName="SupplierId")]
		public string gxTpr_Supplierid
		{
			get {
				return gxTv_SdtSDT_DynamicForms_Supplierid; 
			}
			set {
				gxTv_SdtSDT_DynamicForms_Supplierid = value;
				SetDirty("Supplierid");
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
			gxTv_SdtSDT_DynamicForms_Pagename = "";
			gxTv_SdtSDT_DynamicForms_Referencename = "";
			gxTv_SdtSDT_DynamicForms_Formurl = "";
			gxTv_SdtSDT_DynamicForms_Supplierid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDT_DynamicForms_Formid;
		 

		protected string gxTv_SdtSDT_DynamicForms_Pagename;
		 

		protected string gxTv_SdtSDT_DynamicForms_Referencename;
		 

		protected string gxTv_SdtSDT_DynamicForms_Formurl;
		 

		protected string gxTv_SdtSDT_DynamicForms_Supplierid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DynamicForms", Namespace="Comforta_version21")]
	public class SdtSDT_DynamicForms_RESTInterface : GxGenericCollectionItem<SdtSDT_DynamicForms>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DynamicForms_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DynamicForms_RESTInterface( SdtSDT_DynamicForms psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FormId", Order=0)]
		public short gxTpr_Formid
		{
			get { 
				return sdt.gxTpr_Formid;

			}
			set { 
				sdt.gxTpr_Formid = value;
			}
		}

		[DataMember(Name="PageName", Order=1)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}

		[DataMember(Name="ReferenceName", Order=2)]
		public  string gxTpr_Referencename
		{
			get { 
				return sdt.gxTpr_Referencename;

			}
			set { 
				 sdt.gxTpr_Referencename = value;
			}
		}

		[DataMember(Name="FormUrl", Order=3)]
		public  string gxTpr_Formurl
		{
			get { 
				return sdt.gxTpr_Formurl;

			}
			set { 
				 sdt.gxTpr_Formurl = value;
			}
		}

		[DataMember(Name="SupplierId", Order=4)]
		public  string gxTpr_Supplierid
		{
			get { 
				return sdt.gxTpr_Supplierid;

			}
			set { 
				 sdt.gxTpr_Supplierid = value;
			}
		}


		#endregion

		public SdtSDT_DynamicForms sdt
		{
			get { 
				return (SdtSDT_DynamicForms)Sdt;
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
				sdt = new SdtSDT_DynamicForms() ;
			}
		}
	}
	#endregion
}