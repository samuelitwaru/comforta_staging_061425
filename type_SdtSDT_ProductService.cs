/*
				   File: type_SdtSDT_ProductService
			Description: SDT_ProductService
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
	[XmlRoot(ElementName="SDT_ProductService")]
	[XmlType(TypeName="SDT_ProductService" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ProductService : GxUserType
	{
		public SdtSDT_ProductService( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ProductService_Productservicename = "";

			gxTv_SdtSDT_ProductService_Productservicetilename = "";

			gxTv_SdtSDT_ProductService_Productservicedescription = "";

			gxTv_SdtSDT_ProductService_Productserviceclass = "";

			gxTv_SdtSDT_ProductService_Productserviceimage = "";
			gxTv_SdtSDT_ProductService_Productserviceimage_gxi = "";
			gxTv_SdtSDT_ProductService_Productservicegroup = "";

			gxTv_SdtSDT_ProductService_Suppliergencompanyname = "";

			gxTv_SdtSDT_ProductService_Supplieragbname = "";

		}

		public SdtSDT_ProductService(IGxContext context)
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
			AddObjectProperty("ProductServiceId", gxTpr_Productserviceid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("ProductServiceName", gxTpr_Productservicename, false);


			AddObjectProperty("ProductServiceTileName", gxTpr_Productservicetilename, false);


			AddObjectProperty("ProductServiceDescription", gxTpr_Productservicedescription, false);


			AddObjectProperty("ProductServiceClass", gxTpr_Productserviceclass, false);


			AddObjectProperty("ProductServiceImage", gxTpr_Productserviceimage, false);
			AddObjectProperty("ProductServiceImage_GXI", gxTpr_Productserviceimage_gxi, false);



			AddObjectProperty("ProductServiceGroup", gxTpr_Productservicegroup, false);


			AddObjectProperty("SupplierGenId", gxTpr_Suppliergenid, false);


			AddObjectProperty("SupplierGenCompanyName", gxTpr_Suppliergencompanyname, false);


			AddObjectProperty("SupplierAgbId", gxTpr_Supplieragbid, false);


			AddObjectProperty("SupplierAgbName", gxTpr_Supplieragbname, false);

			if (gxTv_SdtSDT_ProductService_Calltoactions != null)
			{
				AddObjectProperty("CallToActions", gxTv_SdtSDT_ProductService_Calltoactions, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductServiceId")]
		[XmlElement(ElementName="ProductServiceId")]
		public Guid gxTpr_Productserviceid
		{
			get {
				return gxTv_SdtSDT_ProductService_Productserviceid; 
			}
			set {
				gxTv_SdtSDT_ProductService_Productserviceid = value;
				SetDirty("Productserviceid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_ProductService_Locationid; 
			}
			set {
				gxTv_SdtSDT_ProductService_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_ProductService_Organisationid; 
			}
			set {
				gxTv_SdtSDT_ProductService_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="ProductServiceName")]
		[XmlElement(ElementName="ProductServiceName")]
		public string gxTpr_Productservicename
		{
			get {
				return gxTv_SdtSDT_ProductService_Productservicename; 
			}
			set {
				gxTv_SdtSDT_ProductService_Productservicename = value;
				SetDirty("Productservicename");
			}
		}




		[SoapElement(ElementName="ProductServiceTileName")]
		[XmlElement(ElementName="ProductServiceTileName")]
		public string gxTpr_Productservicetilename
		{
			get {
				return gxTv_SdtSDT_ProductService_Productservicetilename; 
			}
			set {
				gxTv_SdtSDT_ProductService_Productservicetilename = value;
				SetDirty("Productservicetilename");
			}
		}




		[SoapElement(ElementName="ProductServiceDescription")]
		[XmlElement(ElementName="ProductServiceDescription")]
		public string gxTpr_Productservicedescription
		{
			get {
				return gxTv_SdtSDT_ProductService_Productservicedescription; 
			}
			set {
				gxTv_SdtSDT_ProductService_Productservicedescription = value;
				SetDirty("Productservicedescription");
			}
		}




		[SoapElement(ElementName="ProductServiceClass")]
		[XmlElement(ElementName="ProductServiceClass")]
		public string gxTpr_Productserviceclass
		{
			get {
				return gxTv_SdtSDT_ProductService_Productserviceclass; 
			}
			set {
				gxTv_SdtSDT_ProductService_Productserviceclass = value;
				SetDirty("Productserviceclass");
			}
		}




		[SoapElement(ElementName="ProductServiceImage")]
		[XmlElement(ElementName="ProductServiceImage")]
		[GxUpload()]

		public string gxTpr_Productserviceimage
		{
			get {
				return gxTv_SdtSDT_ProductService_Productserviceimage; 
			}
			set {
				gxTv_SdtSDT_ProductService_Productserviceimage = value;
				SetDirty("Productserviceimage");
			}
		}


		[SoapElement(ElementName="ProductServiceImage_GXI" )]
		[XmlElement(ElementName="ProductServiceImage_GXI" )]
		public string gxTpr_Productserviceimage_gxi
		{
			get {
				return gxTv_SdtSDT_ProductService_Productserviceimage_gxi ;
			}
			set {
				gxTv_SdtSDT_ProductService_Productserviceimage_gxi = value;
				SetDirty("Productserviceimage_gxi");
			}
		}

		[SoapElement(ElementName="ProductServiceGroup")]
		[XmlElement(ElementName="ProductServiceGroup")]
		public string gxTpr_Productservicegroup
		{
			get {
				return gxTv_SdtSDT_ProductService_Productservicegroup; 
			}
			set {
				gxTv_SdtSDT_ProductService_Productservicegroup = value;
				SetDirty("Productservicegroup");
			}
		}




		[SoapElement(ElementName="SupplierGenId")]
		[XmlElement(ElementName="SupplierGenId")]
		public Guid gxTpr_Suppliergenid
		{
			get {
				return gxTv_SdtSDT_ProductService_Suppliergenid; 
			}
			set {
				gxTv_SdtSDT_ProductService_Suppliergenid = value;
				SetDirty("Suppliergenid");
			}
		}




		[SoapElement(ElementName="SupplierGenCompanyName")]
		[XmlElement(ElementName="SupplierGenCompanyName")]
		public string gxTpr_Suppliergencompanyname
		{
			get {
				return gxTv_SdtSDT_ProductService_Suppliergencompanyname; 
			}
			set {
				gxTv_SdtSDT_ProductService_Suppliergencompanyname = value;
				SetDirty("Suppliergencompanyname");
			}
		}




		[SoapElement(ElementName="SupplierAgbId")]
		[XmlElement(ElementName="SupplierAgbId")]
		public Guid gxTpr_Supplieragbid
		{
			get {
				return gxTv_SdtSDT_ProductService_Supplieragbid; 
			}
			set {
				gxTv_SdtSDT_ProductService_Supplieragbid = value;
				SetDirty("Supplieragbid");
			}
		}




		[SoapElement(ElementName="SupplierAgbName")]
		[XmlElement(ElementName="SupplierAgbName")]
		public string gxTpr_Supplieragbname
		{
			get {
				return gxTv_SdtSDT_ProductService_Supplieragbname; 
			}
			set {
				gxTv_SdtSDT_ProductService_Supplieragbname = value;
				SetDirty("Supplieragbname");
			}
		}




		[SoapElement(ElementName="CallToActions" )]
		[XmlArray(ElementName="CallToActions"  )]
		[XmlArrayItemAttribute(ElementName="SDT_CallToActionItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem> gxTpr_Calltoactions_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_ProductService_Calltoactions == null )
				{
					gxTv_SdtSDT_ProductService_Calltoactions = new GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToAction", "");
				}
				return gxTv_SdtSDT_ProductService_Calltoactions;
			}
			set {
				gxTv_SdtSDT_ProductService_Calltoactions_N = false;
				gxTv_SdtSDT_ProductService_Calltoactions = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem> gxTpr_Calltoactions
		{
			get {
				if ( gxTv_SdtSDT_ProductService_Calltoactions == null )
				{
					gxTv_SdtSDT_ProductService_Calltoactions = new GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToAction", "");
				}
				gxTv_SdtSDT_ProductService_Calltoactions_N = false;
				return gxTv_SdtSDT_ProductService_Calltoactions ;
			}
			set {
				gxTv_SdtSDT_ProductService_Calltoactions_N = false;
				gxTv_SdtSDT_ProductService_Calltoactions = value;
				SetDirty("Calltoactions");
			}
		}

		public void gxTv_SdtSDT_ProductService_Calltoactions_SetNull()
		{
			gxTv_SdtSDT_ProductService_Calltoactions_N = true;
			gxTv_SdtSDT_ProductService_Calltoactions = null;
		}

		public bool gxTv_SdtSDT_ProductService_Calltoactions_IsNull()
		{
			return gxTv_SdtSDT_ProductService_Calltoactions == null;
		}
		public bool ShouldSerializegxTpr_Calltoactions_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_ProductService_Calltoactions != null && gxTv_SdtSDT_ProductService_Calltoactions.Count > 0;

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
			gxTv_SdtSDT_ProductService_Productservicename = "";
			gxTv_SdtSDT_ProductService_Productservicetilename = "";
			gxTv_SdtSDT_ProductService_Productservicedescription = "";
			gxTv_SdtSDT_ProductService_Productserviceclass = "";
			gxTv_SdtSDT_ProductService_Productserviceimage = "";gxTv_SdtSDT_ProductService_Productserviceimage_gxi = "";
			gxTv_SdtSDT_ProductService_Productservicegroup = "";

			gxTv_SdtSDT_ProductService_Suppliergencompanyname = "";

			gxTv_SdtSDT_ProductService_Supplieragbname = "";

			gxTv_SdtSDT_ProductService_Calltoactions_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_ProductService_Productserviceid;
		 

		protected Guid gxTv_SdtSDT_ProductService_Locationid;
		 

		protected Guid gxTv_SdtSDT_ProductService_Organisationid;
		 

		protected string gxTv_SdtSDT_ProductService_Productservicename;
		 

		protected string gxTv_SdtSDT_ProductService_Productservicetilename;
		 

		protected string gxTv_SdtSDT_ProductService_Productservicedescription;
		 

		protected string gxTv_SdtSDT_ProductService_Productserviceclass;
		 
		protected string gxTv_SdtSDT_ProductService_Productserviceimage_gxi;
		protected string gxTv_SdtSDT_ProductService_Productserviceimage;
		 

		protected string gxTv_SdtSDT_ProductService_Productservicegroup;
		 

		protected Guid gxTv_SdtSDT_ProductService_Suppliergenid;
		 

		protected string gxTv_SdtSDT_ProductService_Suppliergencompanyname;
		 

		protected Guid gxTv_SdtSDT_ProductService_Supplieragbid;
		 

		protected string gxTv_SdtSDT_ProductService_Supplieragbname;
		 
		protected bool gxTv_SdtSDT_ProductService_Calltoactions_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem> gxTv_SdtSDT_ProductService_Calltoactions = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ProductService", Namespace="Comforta_version2")]
	public class SdtSDT_ProductService_RESTInterface : GxGenericCollectionItem<SdtSDT_ProductService>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ProductService_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ProductService_RESTInterface( SdtSDT_ProductService psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductServiceId", Order=0)]
		public Guid gxTpr_Productserviceid
		{
			get { 
				return sdt.gxTpr_Productserviceid;

			}
			set { 
				sdt.gxTpr_Productserviceid = value;
			}
		}

		[DataMember(Name="LocationId", Order=1)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=2)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="ProductServiceName", Order=3)]
		public  string gxTpr_Productservicename
		{
			get { 
				return sdt.gxTpr_Productservicename;

			}
			set { 
				 sdt.gxTpr_Productservicename = value;
			}
		}

		[DataMember(Name="ProductServiceTileName", Order=4)]
		public  string gxTpr_Productservicetilename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Productservicetilename);

			}
			set { 
				 sdt.gxTpr_Productservicetilename = value;
			}
		}

		[DataMember(Name="ProductServiceDescription", Order=5)]
		public  string gxTpr_Productservicedescription
		{
			get { 
				return sdt.gxTpr_Productservicedescription;

			}
			set { 
				 sdt.gxTpr_Productservicedescription = value;
			}
		}

		[DataMember(Name="ProductServiceClass", Order=6)]
		public  string gxTpr_Productserviceclass
		{
			get { 
				return sdt.gxTpr_Productserviceclass;

			}
			set { 
				 sdt.gxTpr_Productserviceclass = value;
			}
		}

		[DataMember(Name="ProductServiceImage", Order=7)]
		[GxUpload()]
		public  string gxTpr_Productserviceimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productserviceimage)) ? PathUtil.RelativePath( sdt.gxTpr_Productserviceimage) : StringUtil.RTrim( sdt.gxTpr_Productserviceimage_gxi));

			}
			set { 
				 sdt.gxTpr_Productserviceimage = value;
			}
		}

		[DataMember(Name="ProductServiceGroup", Order=8)]
		public  string gxTpr_Productservicegroup
		{
			get { 
				return sdt.gxTpr_Productservicegroup;

			}
			set { 
				 sdt.gxTpr_Productservicegroup = value;
			}
		}

		[DataMember(Name="SupplierGenId", Order=9)]
		public Guid gxTpr_Suppliergenid
		{
			get { 
				return sdt.gxTpr_Suppliergenid;

			}
			set { 
				sdt.gxTpr_Suppliergenid = value;
			}
		}

		[DataMember(Name="SupplierGenCompanyName", Order=10)]
		public  string gxTpr_Suppliergencompanyname
		{
			get { 
				return sdt.gxTpr_Suppliergencompanyname;

			}
			set { 
				 sdt.gxTpr_Suppliergencompanyname = value;
			}
		}

		[DataMember(Name="SupplierAgbId", Order=11)]
		public Guid gxTpr_Supplieragbid
		{
			get { 
				return sdt.gxTpr_Supplieragbid;

			}
			set { 
				sdt.gxTpr_Supplieragbid = value;
			}
		}

		[DataMember(Name="SupplierAgbName", Order=12)]
		public  string gxTpr_Supplieragbname
		{
			get { 
				return sdt.gxTpr_Supplieragbname;

			}
			set { 
				 sdt.gxTpr_Supplieragbname = value;
			}
		}

		[DataMember(Name="CallToActions", Order=13, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem_RESTInterface> gxTpr_Calltoactions
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Calltoactions_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem_RESTInterface>(sdt.gxTpr_Calltoactions);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Calltoactions);
			}
		}


		#endregion

		public SdtSDT_ProductService sdt
		{
			get { 
				return (SdtSDT_ProductService)Sdt;
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
				sdt = new SdtSDT_ProductService() ;
			}
		}
	}
	#endregion
}