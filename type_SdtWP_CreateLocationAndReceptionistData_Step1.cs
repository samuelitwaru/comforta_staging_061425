/*
				   File: type_SdtWP_CreateLocationAndReceptionistData_Step1
			Description: Step1
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
	[XmlRoot(ElementName="WP_CreateLocationAndReceptionistData.Step1")]
	[XmlType(TypeName="WP_CreateLocationAndReceptionistData.Step1" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtWP_CreateLocationAndReceptionistData_Step1 : GxUserType
	{
		public SdtWP_CreateLocationAndReceptionistData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1 = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2 = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationimagevar = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Filename = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonenumber = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonecode = "";

		}

		public SdtWP_CreateLocationAndReceptionistData_Step1(IGxContext context)
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
			AddObjectProperty("LocationAddressLine1", gxTpr_Locationaddressline1, false);


			AddObjectProperty("LocationAddressLine2", gxTpr_Locationaddressline2, false);


			AddObjectProperty("LocationZipCode", gxTpr_Locationzipcode, false);


			AddObjectProperty("LocationCity", gxTpr_Locationcity, false);


			AddObjectProperty("LocationCountry", gxTpr_Locationcountry, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("LocationName", gxTpr_Locationname, false);


			AddObjectProperty("LocationImageVar", gxTpr_Locationimagevar, false);


			AddObjectProperty("LocationEmail", gxTpr_Locationemail, false);


			AddObjectProperty("LocationPhone", gxTpr_Locationphone, false);


			AddObjectProperty("LocationDescription", gxTpr_Locationdescription, false);


			AddObjectProperty("FileName", gxTpr_Filename, false);


			AddObjectProperty("LocationPhoneNumber", gxTpr_Locationphonenumber, false);


			AddObjectProperty("LocationPhoneCode", gxTpr_Locationphonecode, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LocationAddressLine1")]
		[XmlElement(ElementName="LocationAddressLine1")]
		public string gxTpr_Locationaddressline1
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1 = value;
				SetDirty("Locationaddressline1");
			}
		}




		[SoapElement(ElementName="LocationAddressLine2")]
		[XmlElement(ElementName="LocationAddressLine2")]
		public string gxTpr_Locationaddressline2
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2 = value;
				SetDirty("Locationaddressline2");
			}
		}




		[SoapElement(ElementName="LocationZipCode")]
		[XmlElement(ElementName="LocationZipCode")]
		public string gxTpr_Locationzipcode
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode = value;
				SetDirty("Locationzipcode");
			}
		}




		[SoapElement(ElementName="LocationCity")]
		[XmlElement(ElementName="LocationCity")]
		public string gxTpr_Locationcity
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity = value;
				SetDirty("Locationcity");
			}
		}




		[SoapElement(ElementName="LocationCountry")]
		[XmlElement(ElementName="LocationCountry")]
		public string gxTpr_Locationcountry
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry = value;
				SetDirty("Locationcountry");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationid; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="LocationName")]
		[XmlElement(ElementName="LocationName")]
		public string gxTpr_Locationname
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname = value;
				SetDirty("Locationname");
			}
		}




		[SoapElement(ElementName="LocationImageVar")]
		[XmlElement(ElementName="LocationImageVar")]
		public string gxTpr_Locationimagevar
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationimagevar; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationimagevar = value;
				SetDirty("Locationimagevar");
			}
		}




		[SoapElement(ElementName="LocationEmail")]
		[XmlElement(ElementName="LocationEmail")]
		public string gxTpr_Locationemail
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail = value;
				SetDirty("Locationemail");
			}
		}




		[SoapElement(ElementName="LocationPhone")]
		[XmlElement(ElementName="LocationPhone")]
		public string gxTpr_Locationphone
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone = value;
				SetDirty("Locationphone");
			}
		}




		[SoapElement(ElementName="LocationDescription")]
		[XmlElement(ElementName="LocationDescription")]
		public string gxTpr_Locationdescription
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription = value;
				SetDirty("Locationdescription");
			}
		}




		[SoapElement(ElementName="FileName")]
		[XmlElement(ElementName="FileName")]
		public string gxTpr_Filename
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Filename; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Filename = value;
				SetDirty("Filename");
			}
		}




		[SoapElement(ElementName="LocationPhoneNumber")]
		[XmlElement(ElementName="LocationPhoneNumber")]
		public string gxTpr_Locationphonenumber
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonenumber; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonenumber = value;
				SetDirty("Locationphonenumber");
			}
		}




		[SoapElement(ElementName="LocationPhoneCode")]
		[XmlElement(ElementName="LocationPhoneCode")]
		public string gxTpr_Locationphonecode
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonecode; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonecode = value;
				SetDirty("Locationphonecode");
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
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1 = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2 = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationimagevar = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Filename = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonenumber = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonecode = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry;
		 

		protected Guid gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationid;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationimagevar;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Filename;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonenumber;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphonecode;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateLocationAndReceptionistData.Step1", Namespace="Comforta_version21")]
	public class SdtWP_CreateLocationAndReceptionistData_Step1_RESTInterface : GxGenericCollectionItem<SdtWP_CreateLocationAndReceptionistData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateLocationAndReceptionistData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateLocationAndReceptionistData_Step1_RESTInterface( SdtWP_CreateLocationAndReceptionistData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationAddressLine1", Order=0)]
		public  string gxTpr_Locationaddressline1
		{
			get { 
				return sdt.gxTpr_Locationaddressline1;

			}
			set { 
				 sdt.gxTpr_Locationaddressline1 = value;
			}
		}

		[DataMember(Name="LocationAddressLine2", Order=1)]
		public  string gxTpr_Locationaddressline2
		{
			get { 
				return sdt.gxTpr_Locationaddressline2;

			}
			set { 
				 sdt.gxTpr_Locationaddressline2 = value;
			}
		}

		[DataMember(Name="LocationZipCode", Order=2)]
		public  string gxTpr_Locationzipcode
		{
			get { 
				return sdt.gxTpr_Locationzipcode;

			}
			set { 
				 sdt.gxTpr_Locationzipcode = value;
			}
		}

		[DataMember(Name="LocationCity", Order=3)]
		public  string gxTpr_Locationcity
		{
			get { 
				return sdt.gxTpr_Locationcity;

			}
			set { 
				 sdt.gxTpr_Locationcity = value;
			}
		}

		[DataMember(Name="LocationCountry", Order=4)]
		public  string gxTpr_Locationcountry
		{
			get { 
				return sdt.gxTpr_Locationcountry;

			}
			set { 
				 sdt.gxTpr_Locationcountry = value;
			}
		}

		[DataMember(Name="LocationId", Order=5)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="LocationName", Order=6)]
		public  string gxTpr_Locationname
		{
			get { 
				return sdt.gxTpr_Locationname;

			}
			set { 
				 sdt.gxTpr_Locationname = value;
			}
		}

		[DataMember(Name="LocationImageVar", Order=7)]
		public  string gxTpr_Locationimagevar
		{
			get { 
				return sdt.gxTpr_Locationimagevar;

			}
			set { 
				 sdt.gxTpr_Locationimagevar = value;
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

		[DataMember(Name="FileName", Order=11)]
		public  string gxTpr_Filename
		{
			get { 
				return sdt.gxTpr_Filename;

			}
			set { 
				 sdt.gxTpr_Filename = value;
			}
		}

		[DataMember(Name="LocationPhoneNumber", Order=12)]
		public  string gxTpr_Locationphonenumber
		{
			get { 
				return sdt.gxTpr_Locationphonenumber;

			}
			set { 
				 sdt.gxTpr_Locationphonenumber = value;
			}
		}

		[DataMember(Name="LocationPhoneCode", Order=13)]
		public  string gxTpr_Locationphonecode
		{
			get { 
				return sdt.gxTpr_Locationphonecode;

			}
			set { 
				 sdt.gxTpr_Locationphonecode = value;
			}
		}


		#endregion

		public SdtWP_CreateLocationAndReceptionistData_Step1 sdt
		{
			get { 
				return (SdtWP_CreateLocationAndReceptionistData_Step1)Sdt;
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
				sdt = new SdtWP_CreateLocationAndReceptionistData_Step1() ;
			}
		}
	}
	#endregion
}