/*
				   File: type_SdtSDT_Managers_SDT_ManagersItem
			Description: SDT_Managers
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
	[XmlRoot(ElementName="SDT_ManagersItem")]
	[XmlType(TypeName="SDT_ManagersItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Managers_SDT_ManagersItem : GxUserType
	{
		public SdtSDT_Managers_SDT_ManagersItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergivenname = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerlastname = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerinitials = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Manageremail = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphone = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonecode = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonenumber = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergamguid = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage_gxi = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergender = "";

			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managersalutation = "";

		}

		public SdtSDT_Managers_SDT_ManagersItem(IGxContext context)
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
			AddObjectProperty("ManagerId", gxTpr_Managerid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("ManagerGivenName", gxTpr_Managergivenname, false);


			AddObjectProperty("ManagerLastName", gxTpr_Managerlastname, false);


			AddObjectProperty("ManagerInitials", gxTpr_Managerinitials, false);


			AddObjectProperty("ManagerEmail", gxTpr_Manageremail, false);


			AddObjectProperty("ManagerPhone", gxTpr_Managerphone, false);


			AddObjectProperty("ManagerPhoneCode", gxTpr_Managerphonecode, false);


			AddObjectProperty("ManagerPhoneNumber", gxTpr_Managerphonenumber, false);


			AddObjectProperty("ManagerGAMGUID", gxTpr_Managergamguid, false);


			AddObjectProperty("ManagerIsMainManager", gxTpr_Managerismainmanager, false);


			AddObjectProperty("ManagerImage", gxTpr_Managerimage, false);
			AddObjectProperty("ManagerImage_GXI", gxTpr_Managerimage_gxi, false);



			AddObjectProperty("ManagerGender", gxTpr_Managergender, false);


			AddObjectProperty("ManagerSalutation", gxTpr_Managersalutation, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ManagerId")]
		[XmlElement(ElementName="ManagerId")]
		public Guid gxTpr_Managerid
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerid; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerid = value;
				SetDirty("Managerid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Organisationid; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="ManagerGivenName")]
		[XmlElement(ElementName="ManagerGivenName")]
		public string gxTpr_Managergivenname
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergivenname; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergivenname = value;
				SetDirty("Managergivenname");
			}
		}




		[SoapElement(ElementName="ManagerLastName")]
		[XmlElement(ElementName="ManagerLastName")]
		public string gxTpr_Managerlastname
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerlastname; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerlastname = value;
				SetDirty("Managerlastname");
			}
		}




		[SoapElement(ElementName="ManagerInitials")]
		[XmlElement(ElementName="ManagerInitials")]
		public string gxTpr_Managerinitials
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerinitials; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerinitials = value;
				SetDirty("Managerinitials");
			}
		}




		[SoapElement(ElementName="ManagerEmail")]
		[XmlElement(ElementName="ManagerEmail")]
		public string gxTpr_Manageremail
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Manageremail; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Manageremail = value;
				SetDirty("Manageremail");
			}
		}




		[SoapElement(ElementName="ManagerPhone")]
		[XmlElement(ElementName="ManagerPhone")]
		public string gxTpr_Managerphone
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphone; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphone = value;
				SetDirty("Managerphone");
			}
		}




		[SoapElement(ElementName="ManagerPhoneCode")]
		[XmlElement(ElementName="ManagerPhoneCode")]
		public string gxTpr_Managerphonecode
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonecode; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonecode = value;
				SetDirty("Managerphonecode");
			}
		}




		[SoapElement(ElementName="ManagerPhoneNumber")]
		[XmlElement(ElementName="ManagerPhoneNumber")]
		public string gxTpr_Managerphonenumber
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonenumber; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonenumber = value;
				SetDirty("Managerphonenumber");
			}
		}




		[SoapElement(ElementName="ManagerGAMGUID")]
		[XmlElement(ElementName="ManagerGAMGUID")]
		public string gxTpr_Managergamguid
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergamguid; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergamguid = value;
				SetDirty("Managergamguid");
			}
		}




		[SoapElement(ElementName="ManagerIsMainManager")]
		[XmlElement(ElementName="ManagerIsMainManager")]
		public bool gxTpr_Managerismainmanager
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerismainmanager; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerismainmanager = value;
				SetDirty("Managerismainmanager");
			}
		}




		[SoapElement(ElementName="ManagerImage")]
		[XmlElement(ElementName="ManagerImage")]
		[GxUpload()]

		public string gxTpr_Managerimage
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage = value;
				SetDirty("Managerimage");
			}
		}


		[SoapElement(ElementName="ManagerImage_GXI" )]
		[XmlElement(ElementName="ManagerImage_GXI" )]
		public string gxTpr_Managerimage_gxi
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage_gxi ;
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage_gxi = value;
				SetDirty("Managerimage_gxi");
			}
		}

		[SoapElement(ElementName="ManagerGender")]
		[XmlElement(ElementName="ManagerGender")]
		public string gxTpr_Managergender
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergender; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergender = value;
				SetDirty("Managergender");
			}
		}




		[SoapElement(ElementName="ManagerSalutation")]
		[XmlElement(ElementName="ManagerSalutation")]
		public string gxTpr_Managersalutation
		{
			get {
				return gxTv_SdtSDT_Managers_SDT_ManagersItem_Managersalutation; 
			}
			set {
				gxTv_SdtSDT_Managers_SDT_ManagersItem_Managersalutation = value;
				SetDirty("Managersalutation");
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
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergivenname = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerlastname = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerinitials = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Manageremail = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphone = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonecode = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonenumber = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergamguid = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerismainmanager = false;
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage = "";gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage_gxi = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergender = "";
			gxTv_SdtSDT_Managers_SDT_ManagersItem_Managersalutation = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerid;
		 

		protected Guid gxTv_SdtSDT_Managers_SDT_ManagersItem_Organisationid;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergivenname;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerlastname;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerinitials;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Manageremail;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphone;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonecode;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerphonenumber;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergamguid;
		 

		protected bool gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerismainmanager;
		 
		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage_gxi;
		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managerimage;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managergender;
		 

		protected string gxTv_SdtSDT_Managers_SDT_ManagersItem_Managersalutation;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ManagersItem", Namespace="Comforta_version2")]
	public class SdtSDT_Managers_SDT_ManagersItem_RESTInterface : GxGenericCollectionItem<SdtSDT_Managers_SDT_ManagersItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Managers_SDT_ManagersItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Managers_SDT_ManagersItem_RESTInterface( SdtSDT_Managers_SDT_ManagersItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ManagerId", Order=0)]
		public Guid gxTpr_Managerid
		{
			get { 
				return sdt.gxTpr_Managerid;

			}
			set { 
				sdt.gxTpr_Managerid = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=1)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="ManagerGivenName", Order=2)]
		public  string gxTpr_Managergivenname
		{
			get { 
				return sdt.gxTpr_Managergivenname;

			}
			set { 
				 sdt.gxTpr_Managergivenname = value;
			}
		}

		[DataMember(Name="ManagerLastName", Order=3)]
		public  string gxTpr_Managerlastname
		{
			get { 
				return sdt.gxTpr_Managerlastname;

			}
			set { 
				 sdt.gxTpr_Managerlastname = value;
			}
		}

		[DataMember(Name="ManagerInitials", Order=4)]
		public  string gxTpr_Managerinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Managerinitials);

			}
			set { 
				 sdt.gxTpr_Managerinitials = value;
			}
		}

		[DataMember(Name="ManagerEmail", Order=5)]
		public  string gxTpr_Manageremail
		{
			get { 
				return sdt.gxTpr_Manageremail;

			}
			set { 
				 sdt.gxTpr_Manageremail = value;
			}
		}

		[DataMember(Name="ManagerPhone", Order=6)]
		public  string gxTpr_Managerphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Managerphone);

			}
			set { 
				 sdt.gxTpr_Managerphone = value;
			}
		}

		[DataMember(Name="ManagerPhoneCode", Order=7)]
		public  string gxTpr_Managerphonecode
		{
			get { 
				return sdt.gxTpr_Managerphonecode;

			}
			set { 
				 sdt.gxTpr_Managerphonecode = value;
			}
		}

		[DataMember(Name="ManagerPhoneNumber", Order=8)]
		public  string gxTpr_Managerphonenumber
		{
			get { 
				return sdt.gxTpr_Managerphonenumber;

			}
			set { 
				 sdt.gxTpr_Managerphonenumber = value;
			}
		}

		[DataMember(Name="ManagerGAMGUID", Order=9)]
		public  string gxTpr_Managergamguid
		{
			get { 
				return sdt.gxTpr_Managergamguid;

			}
			set { 
				 sdt.gxTpr_Managergamguid = value;
			}
		}

		[DataMember(Name="ManagerIsMainManager", Order=10)]
		public bool gxTpr_Managerismainmanager
		{
			get { 
				return sdt.gxTpr_Managerismainmanager;

			}
			set { 
				sdt.gxTpr_Managerismainmanager = value;
			}
		}

		[DataMember(Name="ManagerImage", Order=11)]
		[GxUpload()]
		public  string gxTpr_Managerimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Managerimage)) ? PathUtil.RelativePath( sdt.gxTpr_Managerimage) : StringUtil.RTrim( sdt.gxTpr_Managerimage_gxi));

			}
			set { 
				 sdt.gxTpr_Managerimage = value;
			}
		}

		[DataMember(Name="ManagerGender", Order=12)]
		public  string gxTpr_Managergender
		{
			get { 
				return sdt.gxTpr_Managergender;

			}
			set { 
				 sdt.gxTpr_Managergender = value;
			}
		}

		[DataMember(Name="ManagerSalutation", Order=13)]
		public  string gxTpr_Managersalutation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Managersalutation);

			}
			set { 
				 sdt.gxTpr_Managersalutation = value;
			}
		}


		#endregion

		public SdtSDT_Managers_SDT_ManagersItem sdt
		{
			get { 
				return (SdtSDT_Managers_SDT_ManagersItem)Sdt;
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
				sdt = new SdtSDT_Managers_SDT_ManagersItem() ;
			}
		}
	}
	#endregion
}