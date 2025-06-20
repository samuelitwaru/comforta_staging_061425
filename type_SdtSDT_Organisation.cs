/*
				   File: type_SdtSDT_Organisation
			Description: SDT_Organisation
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
	[XmlRoot(ElementName="SDT_Organisation")]
	[XmlType(TypeName="SDT_Organisation" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Organisation : GxUserType
	{
		public SdtSDT_Organisation( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Organisation_Organisationname = "";

			gxTv_SdtSDT_Organisation_Organisationkvknumber = "";

			gxTv_SdtSDT_Organisation_Organisationemail = "";

			gxTv_SdtSDT_Organisation_Organisationphone = "";

			gxTv_SdtSDT_Organisation_Organisationvatnumber = "";

			gxTv_SdtSDT_Organisation_Organisationcountry = "";

			gxTv_SdtSDT_Organisation_Organisationcity = "";

			gxTv_SdtSDT_Organisation_Organisationzipcode = "";

			gxTv_SdtSDT_Organisation_Organisationaddressline1 = "";

			gxTv_SdtSDT_Organisation_Organisationaddressline2 = "";

			gxTv_SdtSDT_Organisation_Organisationtypename = "";

			gxTv_SdtSDT_Organisation_Organisationlogo = "";

		}

		public SdtSDT_Organisation(IGxContext context)
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
			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("OrganisationName", gxTpr_Organisationname, false);


			AddObjectProperty("OrganisationKvkNumber", gxTpr_Organisationkvknumber, false);


			AddObjectProperty("OrganisationEmail", gxTpr_Organisationemail, false);


			AddObjectProperty("OrganisationPhone", gxTpr_Organisationphone, false);


			AddObjectProperty("OrganisationVATNumber", gxTpr_Organisationvatnumber, false);


			AddObjectProperty("OrganisationCountry", gxTpr_Organisationcountry, false);


			AddObjectProperty("OrganisationCity", gxTpr_Organisationcity, false);


			AddObjectProperty("OrganisationZipCode", gxTpr_Organisationzipcode, false);


			AddObjectProperty("OrganisationAddressLine1", gxTpr_Organisationaddressline1, false);


			AddObjectProperty("OrganisationAddressLine2", gxTpr_Organisationaddressline2, false);


			AddObjectProperty("OrganisationTypeId", gxTpr_Organisationtypeid, false);


			AddObjectProperty("OrganisationTypeName", gxTpr_Organisationtypename, false);


			AddObjectProperty("OrganisationLogo", gxTpr_Organisationlogo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationid; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="OrganisationName")]
		[XmlElement(ElementName="OrganisationName")]
		public string gxTpr_Organisationname
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationname; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationname = value;
				SetDirty("Organisationname");
			}
		}




		[SoapElement(ElementName="OrganisationKvkNumber")]
		[XmlElement(ElementName="OrganisationKvkNumber")]
		public string gxTpr_Organisationkvknumber
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationkvknumber; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationkvknumber = value;
				SetDirty("Organisationkvknumber");
			}
		}




		[SoapElement(ElementName="OrganisationEmail")]
		[XmlElement(ElementName="OrganisationEmail")]
		public string gxTpr_Organisationemail
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationemail; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationemail = value;
				SetDirty("Organisationemail");
			}
		}




		[SoapElement(ElementName="OrganisationPhone")]
		[XmlElement(ElementName="OrganisationPhone")]
		public string gxTpr_Organisationphone
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationphone; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationphone = value;
				SetDirty("Organisationphone");
			}
		}




		[SoapElement(ElementName="OrganisationVATNumber")]
		[XmlElement(ElementName="OrganisationVATNumber")]
		public string gxTpr_Organisationvatnumber
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationvatnumber; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationvatnumber = value;
				SetDirty("Organisationvatnumber");
			}
		}




		[SoapElement(ElementName="OrganisationCountry")]
		[XmlElement(ElementName="OrganisationCountry")]
		public string gxTpr_Organisationcountry
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationcountry; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationcountry = value;
				SetDirty("Organisationcountry");
			}
		}




		[SoapElement(ElementName="OrganisationCity")]
		[XmlElement(ElementName="OrganisationCity")]
		public string gxTpr_Organisationcity
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationcity; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationcity = value;
				SetDirty("Organisationcity");
			}
		}




		[SoapElement(ElementName="OrganisationZipCode")]
		[XmlElement(ElementName="OrganisationZipCode")]
		public string gxTpr_Organisationzipcode
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationzipcode; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationzipcode = value;
				SetDirty("Organisationzipcode");
			}
		}




		[SoapElement(ElementName="OrganisationAddressLine1")]
		[XmlElement(ElementName="OrganisationAddressLine1")]
		public string gxTpr_Organisationaddressline1
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationaddressline1; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationaddressline1 = value;
				SetDirty("Organisationaddressline1");
			}
		}




		[SoapElement(ElementName="OrganisationAddressLine2")]
		[XmlElement(ElementName="OrganisationAddressLine2")]
		public string gxTpr_Organisationaddressline2
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationaddressline2; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationaddressline2 = value;
				SetDirty("Organisationaddressline2");
			}
		}




		[SoapElement(ElementName="OrganisationTypeId")]
		[XmlElement(ElementName="OrganisationTypeId")]
		public Guid gxTpr_Organisationtypeid
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationtypeid; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationtypeid = value;
				SetDirty("Organisationtypeid");
			}
		}




		[SoapElement(ElementName="OrganisationTypeName")]
		[XmlElement(ElementName="OrganisationTypeName")]
		public string gxTpr_Organisationtypename
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationtypename; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationtypename = value;
				SetDirty("Organisationtypename");
			}
		}




		[SoapElement(ElementName="OrganisationLogo")]
		[XmlElement(ElementName="OrganisationLogo")]
		public string gxTpr_Organisationlogo
		{
			get {
				return gxTv_SdtSDT_Organisation_Organisationlogo; 
			}
			set {
				gxTv_SdtSDT_Organisation_Organisationlogo = value;
				SetDirty("Organisationlogo");
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
			gxTv_SdtSDT_Organisation_Organisationname = "";
			gxTv_SdtSDT_Organisation_Organisationkvknumber = "";
			gxTv_SdtSDT_Organisation_Organisationemail = "";
			gxTv_SdtSDT_Organisation_Organisationphone = "";
			gxTv_SdtSDT_Organisation_Organisationvatnumber = "";
			gxTv_SdtSDT_Organisation_Organisationcountry = "";
			gxTv_SdtSDT_Organisation_Organisationcity = "";
			gxTv_SdtSDT_Organisation_Organisationzipcode = "";
			gxTv_SdtSDT_Organisation_Organisationaddressline1 = "";
			gxTv_SdtSDT_Organisation_Organisationaddressline2 = "";

			gxTv_SdtSDT_Organisation_Organisationtypename = "";
			gxTv_SdtSDT_Organisation_Organisationlogo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Organisation_Organisationid;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationname;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationkvknumber;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationemail;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationphone;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationvatnumber;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationcountry;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationcity;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationzipcode;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationaddressline1;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationaddressline2;
		 

		protected Guid gxTv_SdtSDT_Organisation_Organisationtypeid;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationtypename;
		 

		protected string gxTv_SdtSDT_Organisation_Organisationlogo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Organisation", Namespace="Comforta_version2")]
	public class SdtSDT_Organisation_RESTInterface : GxGenericCollectionItem<SdtSDT_Organisation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Organisation_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Organisation_RESTInterface( SdtSDT_Organisation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrganisationId", Order=0)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="OrganisationName", Order=1)]
		public  string gxTpr_Organisationname
		{
			get { 
				return sdt.gxTpr_Organisationname;

			}
			set { 
				 sdt.gxTpr_Organisationname = value;
			}
		}

		[DataMember(Name="OrganisationKvkNumber", Order=2)]
		public  string gxTpr_Organisationkvknumber
		{
			get { 
				return sdt.gxTpr_Organisationkvknumber;

			}
			set { 
				 sdt.gxTpr_Organisationkvknumber = value;
			}
		}

		[DataMember(Name="OrganisationEmail", Order=3)]
		public  string gxTpr_Organisationemail
		{
			get { 
				return sdt.gxTpr_Organisationemail;

			}
			set { 
				 sdt.gxTpr_Organisationemail = value;
			}
		}

		[DataMember(Name="OrganisationPhone", Order=4)]
		public  string gxTpr_Organisationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Organisationphone);

			}
			set { 
				 sdt.gxTpr_Organisationphone = value;
			}
		}

		[DataMember(Name="OrganisationVATNumber", Order=5)]
		public  string gxTpr_Organisationvatnumber
		{
			get { 
				return sdt.gxTpr_Organisationvatnumber;

			}
			set { 
				 sdt.gxTpr_Organisationvatnumber = value;
			}
		}

		[DataMember(Name="OrganisationCountry", Order=6)]
		public  string gxTpr_Organisationcountry
		{
			get { 
				return sdt.gxTpr_Organisationcountry;

			}
			set { 
				 sdt.gxTpr_Organisationcountry = value;
			}
		}

		[DataMember(Name="OrganisationCity", Order=7)]
		public  string gxTpr_Organisationcity
		{
			get { 
				return sdt.gxTpr_Organisationcity;

			}
			set { 
				 sdt.gxTpr_Organisationcity = value;
			}
		}

		[DataMember(Name="OrganisationZipCode", Order=8)]
		public  string gxTpr_Organisationzipcode
		{
			get { 
				return sdt.gxTpr_Organisationzipcode;

			}
			set { 
				 sdt.gxTpr_Organisationzipcode = value;
			}
		}

		[DataMember(Name="OrganisationAddressLine1", Order=9)]
		public  string gxTpr_Organisationaddressline1
		{
			get { 
				return sdt.gxTpr_Organisationaddressline1;

			}
			set { 
				 sdt.gxTpr_Organisationaddressline1 = value;
			}
		}

		[DataMember(Name="OrganisationAddressLine2", Order=10)]
		public  string gxTpr_Organisationaddressline2
		{
			get { 
				return sdt.gxTpr_Organisationaddressline2;

			}
			set { 
				 sdt.gxTpr_Organisationaddressline2 = value;
			}
		}

		[DataMember(Name="OrganisationTypeId", Order=11)]
		public Guid gxTpr_Organisationtypeid
		{
			get { 
				return sdt.gxTpr_Organisationtypeid;

			}
			set { 
				sdt.gxTpr_Organisationtypeid = value;
			}
		}

		[DataMember(Name="OrganisationTypeName", Order=12)]
		public  string gxTpr_Organisationtypename
		{
			get { 
				return sdt.gxTpr_Organisationtypename;

			}
			set { 
				 sdt.gxTpr_Organisationtypename = value;
			}
		}

		[DataMember(Name="OrganisationLogo", Order=13)]
		public  string gxTpr_Organisationlogo
		{
			get { 
				return sdt.gxTpr_Organisationlogo;

			}
			set { 
				 sdt.gxTpr_Organisationlogo = value;
			}
		}


		#endregion

		public SdtSDT_Organisation sdt
		{
			get { 
				return (SdtSDT_Organisation)Sdt;
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
				sdt = new SdtSDT_Organisation() ;
			}
		}
	}
	#endregion
}