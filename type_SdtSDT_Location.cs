/*
				   File: type_SdtSDT_Location
			Description: SDT_Location
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
	[XmlRoot(ElementName="SDT_Location")]
	[XmlType(TypeName="SDT_Location" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Location : GxUserType
	{
		public SdtSDT_Location( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Location_Locationname = "";

			gxTv_SdtSDT_Location_Locationcountry = "";

			gxTv_SdtSDT_Location_Locationcity = "";

			gxTv_SdtSDT_Location_Locationzipcode = "";

			gxTv_SdtSDT_Location_Locationaddressline1 = "";

			gxTv_SdtSDT_Location_Locationaddressline2 = "";

			gxTv_SdtSDT_Location_Locationemail = "";

			gxTv_SdtSDT_Location_Locationphone = "";

			gxTv_SdtSDT_Location_Locationdescription = "";

		}

		public SdtSDT_Location(IGxContext context)
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
			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationName", gxTpr_Locationname, false);


			AddObjectProperty("LocationCountry", gxTpr_Locationcountry, false);


			AddObjectProperty("LocationCity", gxTpr_Locationcity, false);


			AddObjectProperty("LocationZipCode", gxTpr_Locationzipcode, false);


			AddObjectProperty("LocationAddressLine1", gxTpr_Locationaddressline1, false);


			AddObjectProperty("LocationAddressLine2", gxTpr_Locationaddressline2, false);


			AddObjectProperty("LocationEmail", gxTpr_Locationemail, false);


			AddObjectProperty("LocationPhone", gxTpr_Locationphone, false);


			AddObjectProperty("LocationDescription", gxTpr_Locationdescription, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_Location_Locationid; 
			}
			set {
				gxTv_SdtSDT_Location_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_Location_Organisationid; 
			}
			set {
				gxTv_SdtSDT_Location_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationName")]
		[XmlElement(ElementName="LocationName")]
		public string gxTpr_Locationname
		{
			get {
				return gxTv_SdtSDT_Location_Locationname; 
			}
			set {
				gxTv_SdtSDT_Location_Locationname = value;
				SetDirty("Locationname");
			}
		}




		[SoapElement(ElementName="LocationCountry")]
		[XmlElement(ElementName="LocationCountry")]
		public string gxTpr_Locationcountry
		{
			get {
				return gxTv_SdtSDT_Location_Locationcountry; 
			}
			set {
				gxTv_SdtSDT_Location_Locationcountry = value;
				SetDirty("Locationcountry");
			}
		}




		[SoapElement(ElementName="LocationCity")]
		[XmlElement(ElementName="LocationCity")]
		public string gxTpr_Locationcity
		{
			get {
				return gxTv_SdtSDT_Location_Locationcity; 
			}
			set {
				gxTv_SdtSDT_Location_Locationcity = value;
				SetDirty("Locationcity");
			}
		}




		[SoapElement(ElementName="LocationZipCode")]
		[XmlElement(ElementName="LocationZipCode")]
		public string gxTpr_Locationzipcode
		{
			get {
				return gxTv_SdtSDT_Location_Locationzipcode; 
			}
			set {
				gxTv_SdtSDT_Location_Locationzipcode = value;
				SetDirty("Locationzipcode");
			}
		}




		[SoapElement(ElementName="LocationAddressLine1")]
		[XmlElement(ElementName="LocationAddressLine1")]
		public string gxTpr_Locationaddressline1
		{
			get {
				return gxTv_SdtSDT_Location_Locationaddressline1; 
			}
			set {
				gxTv_SdtSDT_Location_Locationaddressline1 = value;
				SetDirty("Locationaddressline1");
			}
		}




		[SoapElement(ElementName="LocationAddressLine2")]
		[XmlElement(ElementName="LocationAddressLine2")]
		public string gxTpr_Locationaddressline2
		{
			get {
				return gxTv_SdtSDT_Location_Locationaddressline2; 
			}
			set {
				gxTv_SdtSDT_Location_Locationaddressline2 = value;
				SetDirty("Locationaddressline2");
			}
		}




		[SoapElement(ElementName="LocationEmail")]
		[XmlElement(ElementName="LocationEmail")]
		public string gxTpr_Locationemail
		{
			get {
				return gxTv_SdtSDT_Location_Locationemail; 
			}
			set {
				gxTv_SdtSDT_Location_Locationemail = value;
				SetDirty("Locationemail");
			}
		}




		[SoapElement(ElementName="LocationPhone")]
		[XmlElement(ElementName="LocationPhone")]
		public string gxTpr_Locationphone
		{
			get {
				return gxTv_SdtSDT_Location_Locationphone; 
			}
			set {
				gxTv_SdtSDT_Location_Locationphone = value;
				SetDirty("Locationphone");
			}
		}




		[SoapElement(ElementName="LocationDescription")]
		[XmlElement(ElementName="LocationDescription")]
		public string gxTpr_Locationdescription
		{
			get {
				return gxTv_SdtSDT_Location_Locationdescription; 
			}
			set {
				gxTv_SdtSDT_Location_Locationdescription = value;
				SetDirty("Locationdescription");
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
			gxTv_SdtSDT_Location_Locationname = "";
			gxTv_SdtSDT_Location_Locationcountry = context.GetMessage( "Netherlands", "");
			gxTv_SdtSDT_Location_Locationcity = "";
			gxTv_SdtSDT_Location_Locationzipcode = "";
			gxTv_SdtSDT_Location_Locationaddressline1 = "";
			gxTv_SdtSDT_Location_Locationaddressline2 = "";
			gxTv_SdtSDT_Location_Locationemail = "";
			gxTv_SdtSDT_Location_Locationphone = "";
			gxTv_SdtSDT_Location_Locationdescription = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Location_Locationid;
		 

		protected Guid gxTv_SdtSDT_Location_Organisationid;
		 

		protected string gxTv_SdtSDT_Location_Locationname;
		 

		protected string gxTv_SdtSDT_Location_Locationcountry;
		 

		protected string gxTv_SdtSDT_Location_Locationcity;
		 

		protected string gxTv_SdtSDT_Location_Locationzipcode;
		 

		protected string gxTv_SdtSDT_Location_Locationaddressline1;
		 

		protected string gxTv_SdtSDT_Location_Locationaddressline2;
		 

		protected string gxTv_SdtSDT_Location_Locationemail;
		 

		protected string gxTv_SdtSDT_Location_Locationphone;
		 

		protected string gxTv_SdtSDT_Location_Locationdescription;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Location", Namespace="Comforta_version2")]
	public class SdtSDT_Location_RESTInterface : GxGenericCollectionItem<SdtSDT_Location>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Location_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Location_RESTInterface( SdtSDT_Location psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationId", Order=0)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
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

		[DataMember(Name="LocationName", Order=2)]
		public  string gxTpr_Locationname
		{
			get { 
				return sdt.gxTpr_Locationname;

			}
			set { 
				 sdt.gxTpr_Locationname = value;
			}
		}

		[DataMember(Name="LocationCountry", Order=3)]
		public  string gxTpr_Locationcountry
		{
			get { 
				return sdt.gxTpr_Locationcountry;

			}
			set { 
				 sdt.gxTpr_Locationcountry = value;
			}
		}

		[DataMember(Name="LocationCity", Order=4)]
		public  string gxTpr_Locationcity
		{
			get { 
				return sdt.gxTpr_Locationcity;

			}
			set { 
				 sdt.gxTpr_Locationcity = value;
			}
		}

		[DataMember(Name="LocationZipCode", Order=5)]
		public  string gxTpr_Locationzipcode
		{
			get { 
				return sdt.gxTpr_Locationzipcode;

			}
			set { 
				 sdt.gxTpr_Locationzipcode = value;
			}
		}

		[DataMember(Name="LocationAddressLine1", Order=6)]
		public  string gxTpr_Locationaddressline1
		{
			get { 
				return sdt.gxTpr_Locationaddressline1;

			}
			set { 
				 sdt.gxTpr_Locationaddressline1 = value;
			}
		}

		[DataMember(Name="LocationAddressLine2", Order=7)]
		public  string gxTpr_Locationaddressline2
		{
			get { 
				return sdt.gxTpr_Locationaddressline2;

			}
			set { 
				 sdt.gxTpr_Locationaddressline2 = value;
			}
		}

		[DataMember(Name="LocationEmail", Order=8)]
		public  string gxTpr_Locationemail
		{
			get { 
				return sdt.gxTpr_Locationemail;

			}
			set { 
				 sdt.gxTpr_Locationemail = value;
			}
		}

		[DataMember(Name="LocationPhone", Order=9)]
		public  string gxTpr_Locationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Locationphone);

			}
			set { 
				 sdt.gxTpr_Locationphone = value;
			}
		}

		[DataMember(Name="LocationDescription", Order=10)]
		public  string gxTpr_Locationdescription
		{
			get { 
				return sdt.gxTpr_Locationdescription;

			}
			set { 
				 sdt.gxTpr_Locationdescription = value;
			}
		}


		#endregion

		public SdtSDT_Location sdt
		{
			get { 
				return (SdtSDT_Location)Sdt;
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
				sdt = new SdtSDT_Location() ;
			}
		}
	}
	#endregion
}