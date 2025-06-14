/*
				   File: type_SdtWP_CreateOrganisationAndManagerData_Step2
			Description: Step2
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
	[XmlRoot(ElementName="WP_CreateOrganisationAndManagerData.Step2")]
	[XmlType(TypeName="WP_CreateOrganisationAndManagerData.Step2" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtWP_CreateOrganisationAndManagerData_Step2 : GxUserType
	{
		public SdtWP_CreateOrganisationAndManagerData_Step2( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Manageremail = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerinitials = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphone = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonenumber = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonecode = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergamguid = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergivenname = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerlastname = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergender = "";

		}

		public SdtWP_CreateOrganisationAndManagerData_Step2(IGxContext context)
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
			AddObjectProperty("ManagerEmail", gxTpr_Manageremail, false);


			AddObjectProperty("ManagerInitials", gxTpr_Managerinitials, false);


			AddObjectProperty("ManagerPhone", gxTpr_Managerphone, false);


			AddObjectProperty("ManagerIsMainManager", gxTpr_Managerismainmanager, false);


			AddObjectProperty("ManagerPhoneNumber", gxTpr_Managerphonenumber, false);


			AddObjectProperty("ManagerPhoneCode", gxTpr_Managerphonecode, false);


			AddObjectProperty("ManagerId", gxTpr_Managerid, false);


			AddObjectProperty("ManagerGAMGUID", gxTpr_Managergamguid, false);


			AddObjectProperty("ManagerGivenName", gxTpr_Managergivenname, false);


			AddObjectProperty("ManagerLastName", gxTpr_Managerlastname, false);


			AddObjectProperty("ManagerGender", gxTpr_Managergender, false);

			if (gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers != null)
			{
				AddObjectProperty("SDT_Managers", gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ManagerEmail")]
		[XmlElement(ElementName="ManagerEmail")]
		public string gxTpr_Manageremail
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Manageremail; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Manageremail = value;
				SetDirty("Manageremail");
			}
		}




		[SoapElement(ElementName="ManagerInitials")]
		[XmlElement(ElementName="ManagerInitials")]
		public string gxTpr_Managerinitials
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerinitials; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerinitials = value;
				SetDirty("Managerinitials");
			}
		}




		[SoapElement(ElementName="ManagerPhone")]
		[XmlElement(ElementName="ManagerPhone")]
		public string gxTpr_Managerphone
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphone; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphone = value;
				SetDirty("Managerphone");
			}
		}




		[SoapElement(ElementName="ManagerIsMainManager")]
		[XmlElement(ElementName="ManagerIsMainManager")]
		public bool gxTpr_Managerismainmanager
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerismainmanager; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerismainmanager = value;
				SetDirty("Managerismainmanager");
			}
		}




		[SoapElement(ElementName="ManagerPhoneNumber")]
		[XmlElement(ElementName="ManagerPhoneNumber")]
		public string gxTpr_Managerphonenumber
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonenumber; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonenumber = value;
				SetDirty("Managerphonenumber");
			}
		}




		[SoapElement(ElementName="ManagerPhoneCode")]
		[XmlElement(ElementName="ManagerPhoneCode")]
		public string gxTpr_Managerphonecode
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonecode; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonecode = value;
				SetDirty("Managerphonecode");
			}
		}




		[SoapElement(ElementName="ManagerId")]
		[XmlElement(ElementName="ManagerId")]
		public Guid gxTpr_Managerid
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerid; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerid = value;
				SetDirty("Managerid");
			}
		}




		[SoapElement(ElementName="ManagerGAMGUID")]
		[XmlElement(ElementName="ManagerGAMGUID")]
		public string gxTpr_Managergamguid
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergamguid; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergamguid = value;
				SetDirty("Managergamguid");
			}
		}




		[SoapElement(ElementName="ManagerGivenName")]
		[XmlElement(ElementName="ManagerGivenName")]
		public string gxTpr_Managergivenname
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergivenname; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergivenname = value;
				SetDirty("Managergivenname");
			}
		}




		[SoapElement(ElementName="ManagerLastName")]
		[XmlElement(ElementName="ManagerLastName")]
		public string gxTpr_Managerlastname
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerlastname; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerlastname = value;
				SetDirty("Managerlastname");
			}
		}




		[SoapElement(ElementName="ManagerGender")]
		[XmlElement(ElementName="ManagerGender")]
		public string gxTpr_Managergender
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergender; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergender = value;
				SetDirty("Managergender");
			}
		}




		[SoapElement(ElementName="SDT_Managers" )]
		[XmlArray(ElementName="SDT_Managers"  )]
		[XmlArrayItemAttribute(ElementName="SDT_ManagersItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Managers_SDT_ManagersItem> gxTpr_Sdt_managers_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers == null )
				{
					gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers = new GXBaseCollection<GeneXus.Programs.SdtSDT_Managers_SDT_ManagersItem>( context, "SDT_Managers", "");
				}
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers;
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_N = false;
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Managers_SDT_ManagersItem> gxTpr_Sdt_managers
		{
			get {
				if ( gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers == null )
				{
					gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers = new GXBaseCollection<GeneXus.Programs.SdtSDT_Managers_SDT_ManagersItem>( context, "SDT_Managers", "");
				}
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_N = false;
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers ;
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_N = false;
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers = value;
				SetDirty("Sdt_managers");
			}
		}

		public void gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_SetNull()
		{
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_N = true;
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers = null;
		}

		public bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_IsNull()
		{
			return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers == null;
		}
		public bool ShouldSerializegxTpr_Sdt_managers_GXBaseCollection_Json()
		{
			return gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers != null && gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers.Count > 0;

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
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Manageremail = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerinitials = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphone = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerismainmanager = false;
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonenumber = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonecode = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergamguid = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergivenname = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerlastname = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergender = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Manageremail;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerinitials;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphone;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerismainmanager;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonenumber;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerphonecode;
		 

		protected Guid gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerid;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergamguid;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergivenname;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managerlastname;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Managergender;
		 
		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Managers_SDT_ManagersItem> gxTv_SdtWP_CreateOrganisationAndManagerData_Step2_Sdt_managers = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateOrganisationAndManagerData.Step2", Namespace="Comforta_version21")]
	public class SdtWP_CreateOrganisationAndManagerData_Step2_RESTInterface : GxGenericCollectionItem<SdtWP_CreateOrganisationAndManagerData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateOrganisationAndManagerData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateOrganisationAndManagerData_Step2_RESTInterface( SdtWP_CreateOrganisationAndManagerData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ManagerEmail", Order=0)]
		public  string gxTpr_Manageremail
		{
			get { 
				return sdt.gxTpr_Manageremail;

			}
			set { 
				 sdt.gxTpr_Manageremail = value;
			}
		}

		[DataMember(Name="ManagerInitials", Order=1)]
		public  string gxTpr_Managerinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Managerinitials);

			}
			set { 
				 sdt.gxTpr_Managerinitials = value;
			}
		}

		[DataMember(Name="ManagerPhone", Order=2)]
		public  string gxTpr_Managerphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Managerphone);

			}
			set { 
				 sdt.gxTpr_Managerphone = value;
			}
		}

		[DataMember(Name="ManagerIsMainManager", Order=3)]
		public bool gxTpr_Managerismainmanager
		{
			get { 
				return sdt.gxTpr_Managerismainmanager;

			}
			set { 
				sdt.gxTpr_Managerismainmanager = value;
			}
		}

		[DataMember(Name="ManagerPhoneNumber", Order=4)]
		public  string gxTpr_Managerphonenumber
		{
			get { 
				return sdt.gxTpr_Managerphonenumber;

			}
			set { 
				 sdt.gxTpr_Managerphonenumber = value;
			}
		}

		[DataMember(Name="ManagerPhoneCode", Order=5)]
		public  string gxTpr_Managerphonecode
		{
			get { 
				return sdt.gxTpr_Managerphonecode;

			}
			set { 
				 sdt.gxTpr_Managerphonecode = value;
			}
		}

		[DataMember(Name="ManagerId", Order=6)]
		public Guid gxTpr_Managerid
		{
			get { 
				return sdt.gxTpr_Managerid;

			}
			set { 
				sdt.gxTpr_Managerid = value;
			}
		}

		[DataMember(Name="ManagerGAMGUID", Order=7)]
		public  string gxTpr_Managergamguid
		{
			get { 
				return sdt.gxTpr_Managergamguid;

			}
			set { 
				 sdt.gxTpr_Managergamguid = value;
			}
		}

		[DataMember(Name="ManagerGivenName", Order=8)]
		public  string gxTpr_Managergivenname
		{
			get { 
				return sdt.gxTpr_Managergivenname;

			}
			set { 
				 sdt.gxTpr_Managergivenname = value;
			}
		}

		[DataMember(Name="ManagerLastName", Order=9)]
		public  string gxTpr_Managerlastname
		{
			get { 
				return sdt.gxTpr_Managerlastname;

			}
			set { 
				 sdt.gxTpr_Managerlastname = value;
			}
		}

		[DataMember(Name="ManagerGender", Order=10)]
		public  string gxTpr_Managergender
		{
			get { 
				return sdt.gxTpr_Managergender;

			}
			set { 
				 sdt.gxTpr_Managergender = value;
			}
		}

		[DataMember(Name="SDT_Managers", Order=11, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Managers_SDT_ManagersItem_RESTInterface> gxTpr_Sdt_managers
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_managers_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Managers_SDT_ManagersItem_RESTInterface>(sdt.gxTpr_Sdt_managers);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Sdt_managers);
			}
		}


		#endregion

		public SdtWP_CreateOrganisationAndManagerData_Step2 sdt
		{
			get { 
				return (SdtWP_CreateOrganisationAndManagerData_Step2)Sdt;
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
				sdt = new SdtWP_CreateOrganisationAndManagerData_Step2() ;
			}
		}
	}
	#endregion
}