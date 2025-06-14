/*
				   File: type_SdtSDT_Resident
			Description: SDT_Resident
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
	[XmlRoot(ElementName="SDT_Resident")]
	[XmlType(TypeName="SDT_Resident" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_Resident : GxUserType
	{
		public SdtSDT_Resident( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Resident_Residentsalutation = "";

			gxTv_SdtSDT_Resident_Residentbsnnumber = "";

			gxTv_SdtSDT_Resident_Residentgivenname = "";

			gxTv_SdtSDT_Resident_Residentlastname = "";

			gxTv_SdtSDT_Resident_Residentinitials = "";

			gxTv_SdtSDT_Resident_Residentemail = "";

			gxTv_SdtSDT_Resident_Residentgender = "";

			gxTv_SdtSDT_Resident_Residentaddress = "";

			gxTv_SdtSDT_Resident_Residentphone = "";

			gxTv_SdtSDT_Resident_Residentguid = "";

			gxTv_SdtSDT_Resident_Residenttypename = "";

			gxTv_SdtSDT_Resident_Medicalindicationname = "";

			gxTv_SdtSDT_Resident_Residentimage = "";

			gxTv_SdtSDT_Resident_Residentlanguage = "";

		}

		public SdtSDT_Resident(IGxContext context)
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
			AddObjectProperty("ResidentId", gxTpr_Residentid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("ResidentSalutation", gxTpr_Residentsalutation, false);


			AddObjectProperty("ResidentBsnNumber", gxTpr_Residentbsnnumber, false);


			AddObjectProperty("ResidentGivenName", gxTpr_Residentgivenname, false);


			AddObjectProperty("ResidentLastName", gxTpr_Residentlastname, false);


			AddObjectProperty("ResidentInitials", gxTpr_Residentinitials, false);


			AddObjectProperty("ResidentEmail", gxTpr_Residentemail, false);


			AddObjectProperty("ResidentGender", gxTpr_Residentgender, false);


			AddObjectProperty("ResidentAddress", gxTpr_Residentaddress, false);


			AddObjectProperty("ResidentPhone", gxTpr_Residentphone, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Residentbirthdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Residentbirthdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Residentbirthdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ResidentBirthDate", sDateCnv, false);



			AddObjectProperty("ResidentGUID", gxTpr_Residentguid, false);


			AddObjectProperty("ResidentTypeId", gxTpr_Residenttypeid, false);


			AddObjectProperty("ResidentTypeName", gxTpr_Residenttypename, false);


			AddObjectProperty("MedicalIndicationId", gxTpr_Medicalindicationid, false);


			AddObjectProperty("MedicalIndicationName", gxTpr_Medicalindicationname, false);


			AddObjectProperty("ResidentImage", gxTpr_Residentimage, false);


			AddObjectProperty("ResidentLanguage", gxTpr_Residentlanguage, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public Guid gxTpr_Residentid
		{
			get {
				return gxTv_SdtSDT_Resident_Residentid; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_Resident_Locationid; 
			}
			set {
				gxTv_SdtSDT_Resident_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_Resident_Organisationid; 
			}
			set {
				gxTv_SdtSDT_Resident_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="ResidentSalutation")]
		[XmlElement(ElementName="ResidentSalutation")]
		public string gxTpr_Residentsalutation
		{
			get {
				return gxTv_SdtSDT_Resident_Residentsalutation; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentsalutation = value;
				SetDirty("Residentsalutation");
			}
		}




		[SoapElement(ElementName="ResidentBsnNumber")]
		[XmlElement(ElementName="ResidentBsnNumber")]
		public string gxTpr_Residentbsnnumber
		{
			get {
				return gxTv_SdtSDT_Resident_Residentbsnnumber; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentbsnnumber = value;
				SetDirty("Residentbsnnumber");
			}
		}




		[SoapElement(ElementName="ResidentGivenName")]
		[XmlElement(ElementName="ResidentGivenName")]
		public string gxTpr_Residentgivenname
		{
			get {
				return gxTv_SdtSDT_Resident_Residentgivenname; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentgivenname = value;
				SetDirty("Residentgivenname");
			}
		}




		[SoapElement(ElementName="ResidentLastName")]
		[XmlElement(ElementName="ResidentLastName")]
		public string gxTpr_Residentlastname
		{
			get {
				return gxTv_SdtSDT_Resident_Residentlastname; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentlastname = value;
				SetDirty("Residentlastname");
			}
		}




		[SoapElement(ElementName="ResidentInitials")]
		[XmlElement(ElementName="ResidentInitials")]
		public string gxTpr_Residentinitials
		{
			get {
				return gxTv_SdtSDT_Resident_Residentinitials; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentinitials = value;
				SetDirty("Residentinitials");
			}
		}




		[SoapElement(ElementName="ResidentEmail")]
		[XmlElement(ElementName="ResidentEmail")]
		public string gxTpr_Residentemail
		{
			get {
				return gxTv_SdtSDT_Resident_Residentemail; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentemail = value;
				SetDirty("Residentemail");
			}
		}




		[SoapElement(ElementName="ResidentGender")]
		[XmlElement(ElementName="ResidentGender")]
		public string gxTpr_Residentgender
		{
			get {
				return gxTv_SdtSDT_Resident_Residentgender; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentgender = value;
				SetDirty("Residentgender");
			}
		}




		[SoapElement(ElementName="ResidentAddress")]
		[XmlElement(ElementName="ResidentAddress")]
		public string gxTpr_Residentaddress
		{
			get {
				return gxTv_SdtSDT_Resident_Residentaddress; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentaddress = value;
				SetDirty("Residentaddress");
			}
		}




		[SoapElement(ElementName="ResidentPhone")]
		[XmlElement(ElementName="ResidentPhone")]
		public string gxTpr_Residentphone
		{
			get {
				return gxTv_SdtSDT_Resident_Residentphone; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentphone = value;
				SetDirty("Residentphone");
			}
		}



		[SoapElement(ElementName="ResidentBirthDate")]
		[XmlElement(ElementName="ResidentBirthDate" , IsNullable=true)]
		public string gxTpr_Residentbirthdate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_Resident_Residentbirthdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDT_Resident_Residentbirthdate).value ;
			}
			set {
				gxTv_SdtSDT_Resident_Residentbirthdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Residentbirthdate
		{
			get {
				return gxTv_SdtSDT_Resident_Residentbirthdate; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentbirthdate = value;
				SetDirty("Residentbirthdate");
			}
		}



		[SoapElement(ElementName="ResidentGUID")]
		[XmlElement(ElementName="ResidentGUID")]
		public string gxTpr_Residentguid
		{
			get {
				return gxTv_SdtSDT_Resident_Residentguid; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentguid = value;
				SetDirty("Residentguid");
			}
		}




		[SoapElement(ElementName="ResidentTypeId")]
		[XmlElement(ElementName="ResidentTypeId")]
		public Guid gxTpr_Residenttypeid
		{
			get {
				return gxTv_SdtSDT_Resident_Residenttypeid; 
			}
			set {
				gxTv_SdtSDT_Resident_Residenttypeid = value;
				SetDirty("Residenttypeid");
			}
		}




		[SoapElement(ElementName="ResidentTypeName")]
		[XmlElement(ElementName="ResidentTypeName")]
		public string gxTpr_Residenttypename
		{
			get {
				return gxTv_SdtSDT_Resident_Residenttypename; 
			}
			set {
				gxTv_SdtSDT_Resident_Residenttypename = value;
				SetDirty("Residenttypename");
			}
		}




		[SoapElement(ElementName="MedicalIndicationId")]
		[XmlElement(ElementName="MedicalIndicationId")]
		public Guid gxTpr_Medicalindicationid
		{
			get {
				return gxTv_SdtSDT_Resident_Medicalindicationid; 
			}
			set {
				gxTv_SdtSDT_Resident_Medicalindicationid = value;
				SetDirty("Medicalindicationid");
			}
		}




		[SoapElement(ElementName="MedicalIndicationName")]
		[XmlElement(ElementName="MedicalIndicationName")]
		public string gxTpr_Medicalindicationname
		{
			get {
				return gxTv_SdtSDT_Resident_Medicalindicationname; 
			}
			set {
				gxTv_SdtSDT_Resident_Medicalindicationname = value;
				SetDirty("Medicalindicationname");
			}
		}




		[SoapElement(ElementName="ResidentImage")]
		[XmlElement(ElementName="ResidentImage")]
		public string gxTpr_Residentimage
		{
			get {
				return gxTv_SdtSDT_Resident_Residentimage; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentimage = value;
				SetDirty("Residentimage");
			}
		}




		[SoapElement(ElementName="ResidentLanguage")]
		[XmlElement(ElementName="ResidentLanguage")]
		public string gxTpr_Residentlanguage
		{
			get {
				return gxTv_SdtSDT_Resident_Residentlanguage; 
			}
			set {
				gxTv_SdtSDT_Resident_Residentlanguage = value;
				SetDirty("Residentlanguage");
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
			gxTv_SdtSDT_Resident_Residentsalutation = "";
			gxTv_SdtSDT_Resident_Residentbsnnumber = "";
			gxTv_SdtSDT_Resident_Residentgivenname = "";
			gxTv_SdtSDT_Resident_Residentlastname = "";
			gxTv_SdtSDT_Resident_Residentinitials = "";
			gxTv_SdtSDT_Resident_Residentemail = "";
			gxTv_SdtSDT_Resident_Residentgender = "";
			gxTv_SdtSDT_Resident_Residentaddress = "";
			gxTv_SdtSDT_Resident_Residentphone = "";

			gxTv_SdtSDT_Resident_Residentguid = "";

			gxTv_SdtSDT_Resident_Residenttypename = "";

			gxTv_SdtSDT_Resident_Medicalindicationname = "";
			gxTv_SdtSDT_Resident_Residentimage = "";
			gxTv_SdtSDT_Resident_Residentlanguage = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected Guid gxTv_SdtSDT_Resident_Residentid;
		 

		protected Guid gxTv_SdtSDT_Resident_Locationid;
		 

		protected Guid gxTv_SdtSDT_Resident_Organisationid;
		 

		protected string gxTv_SdtSDT_Resident_Residentsalutation;
		 

		protected string gxTv_SdtSDT_Resident_Residentbsnnumber;
		 

		protected string gxTv_SdtSDT_Resident_Residentgivenname;
		 

		protected string gxTv_SdtSDT_Resident_Residentlastname;
		 

		protected string gxTv_SdtSDT_Resident_Residentinitials;
		 

		protected string gxTv_SdtSDT_Resident_Residentemail;
		 

		protected string gxTv_SdtSDT_Resident_Residentgender;
		 

		protected string gxTv_SdtSDT_Resident_Residentaddress;
		 

		protected string gxTv_SdtSDT_Resident_Residentphone;
		 

		protected DateTime gxTv_SdtSDT_Resident_Residentbirthdate;
		 

		protected string gxTv_SdtSDT_Resident_Residentguid;
		 

		protected Guid gxTv_SdtSDT_Resident_Residenttypeid;
		 

		protected string gxTv_SdtSDT_Resident_Residenttypename;
		 

		protected Guid gxTv_SdtSDT_Resident_Medicalindicationid;
		 

		protected string gxTv_SdtSDT_Resident_Medicalindicationname;
		 

		protected string gxTv_SdtSDT_Resident_Residentimage;
		 

		protected string gxTv_SdtSDT_Resident_Residentlanguage;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Resident", Namespace="Comforta_version21")]
	public class SdtSDT_Resident_RESTInterface : GxGenericCollectionItem<SdtSDT_Resident>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Resident_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Resident_RESTInterface( SdtSDT_Resident psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentId", Order=0)]
		public Guid gxTpr_Residentid
		{
			get { 
				return sdt.gxTpr_Residentid;

			}
			set { 
				sdt.gxTpr_Residentid = value;
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

		[DataMember(Name="ResidentSalutation", Order=3)]
		public  string gxTpr_Residentsalutation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentsalutation);

			}
			set { 
				 sdt.gxTpr_Residentsalutation = value;
			}
		}

		[DataMember(Name="ResidentBsnNumber", Order=4)]
		public  string gxTpr_Residentbsnnumber
		{
			get { 
				return sdt.gxTpr_Residentbsnnumber;

			}
			set { 
				 sdt.gxTpr_Residentbsnnumber = value;
			}
		}

		[DataMember(Name="ResidentGivenName", Order=5)]
		public  string gxTpr_Residentgivenname
		{
			get { 
				return sdt.gxTpr_Residentgivenname;

			}
			set { 
				 sdt.gxTpr_Residentgivenname = value;
			}
		}

		[DataMember(Name="ResidentLastName", Order=6)]
		public  string gxTpr_Residentlastname
		{
			get { 
				return sdt.gxTpr_Residentlastname;

			}
			set { 
				 sdt.gxTpr_Residentlastname = value;
			}
		}

		[DataMember(Name="ResidentInitials", Order=7)]
		public  string gxTpr_Residentinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinitials);

			}
			set { 
				 sdt.gxTpr_Residentinitials = value;
			}
		}

		[DataMember(Name="ResidentEmail", Order=8)]
		public  string gxTpr_Residentemail
		{
			get { 
				return sdt.gxTpr_Residentemail;

			}
			set { 
				 sdt.gxTpr_Residentemail = value;
			}
		}

		[DataMember(Name="ResidentGender", Order=9)]
		public  string gxTpr_Residentgender
		{
			get { 
				return sdt.gxTpr_Residentgender;

			}
			set { 
				 sdt.gxTpr_Residentgender = value;
			}
		}

		[DataMember(Name="ResidentAddress", Order=10)]
		public  string gxTpr_Residentaddress
		{
			get { 
				return sdt.gxTpr_Residentaddress;

			}
			set { 
				 sdt.gxTpr_Residentaddress = value;
			}
		}

		[DataMember(Name="ResidentPhone", Order=11)]
		public  string gxTpr_Residentphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentphone);

			}
			set { 
				 sdt.gxTpr_Residentphone = value;
			}
		}

		[DataMember(Name="ResidentBirthDate", Order=12)]
		public  string gxTpr_Residentbirthdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Residentbirthdate);

			}
			set { 
				sdt.gxTpr_Residentbirthdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ResidentGUID", Order=13)]
		public  string gxTpr_Residentguid
		{
			get { 
				return sdt.gxTpr_Residentguid;

			}
			set { 
				 sdt.gxTpr_Residentguid = value;
			}
		}

		[DataMember(Name="ResidentTypeId", Order=14)]
		public Guid gxTpr_Residenttypeid
		{
			get { 
				return sdt.gxTpr_Residenttypeid;

			}
			set { 
				sdt.gxTpr_Residenttypeid = value;
			}
		}

		[DataMember(Name="ResidentTypeName", Order=15)]
		public  string gxTpr_Residenttypename
		{
			get { 
				return sdt.gxTpr_Residenttypename;

			}
			set { 
				 sdt.gxTpr_Residenttypename = value;
			}
		}

		[DataMember(Name="MedicalIndicationId", Order=16)]
		public Guid gxTpr_Medicalindicationid
		{
			get { 
				return sdt.gxTpr_Medicalindicationid;

			}
			set { 
				sdt.gxTpr_Medicalindicationid = value;
			}
		}

		[DataMember(Name="MedicalIndicationName", Order=17)]
		public  string gxTpr_Medicalindicationname
		{
			get { 
				return sdt.gxTpr_Medicalindicationname;

			}
			set { 
				 sdt.gxTpr_Medicalindicationname = value;
			}
		}

		[DataMember(Name="ResidentImage", Order=18)]
		public  string gxTpr_Residentimage
		{
			get { 
				return sdt.gxTpr_Residentimage;

			}
			set { 
				 sdt.gxTpr_Residentimage = value;
			}
		}

		[DataMember(Name="ResidentLanguage", Order=19)]
		public  string gxTpr_Residentlanguage
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentlanguage);

			}
			set { 
				 sdt.gxTpr_Residentlanguage = value;
			}
		}


		#endregion

		public SdtSDT_Resident sdt
		{
			get { 
				return (SdtSDT_Resident)Sdt;
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
				sdt = new SdtSDT_Resident() ;
			}
		}
	}
	#endregion
}