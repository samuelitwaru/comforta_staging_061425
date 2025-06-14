/*
				   File: type_SdtSDT_Receptionists_SDT_ReceptionistsItem
			Description: SDT_Receptionists
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
	[XmlRoot(ElementName="SDT_ReceptionistsItem")]
	[XmlType(TypeName="SDT_ReceptionistsItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_Receptionists_SDT_ReceptionistsItem : GxUserType
	{
		public SdtSDT_Receptionists_SDT_ReceptionistsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationname = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgivenname = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistlastname = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistemail = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphone = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonecode = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonenumber = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptioniststatus = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgamguid = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage_gxi = "";
		}

		public SdtSDT_Receptionists_SDT_ReceptionistsItem(IGxContext context)
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
			AddObjectProperty("ReceptionistId", gxTpr_Receptionistid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("LocationName", gxTpr_Locationname, false);


			AddObjectProperty("ReceptionistGivenName", gxTpr_Receptionistgivenname, false);


			AddObjectProperty("ReceptionistLastName", gxTpr_Receptionistlastname, false);


			AddObjectProperty("ReceptionistEmail", gxTpr_Receptionistemail, false);


			AddObjectProperty("ReceptionistPhone", gxTpr_Receptionistphone, false);


			AddObjectProperty("ReceptionistPhoneCode", gxTpr_Receptionistphonecode, false);


			AddObjectProperty("ReceptionistPhoneNumber", gxTpr_Receptionistphonenumber, false);


			AddObjectProperty("ReceptionistStatus", gxTpr_Receptioniststatus, false);


			AddObjectProperty("ReceptionistIsActive", gxTpr_Receptionistisactive, false);


			AddObjectProperty("ReceptionistGAMGUID", gxTpr_Receptionistgamguid, false);


			AddObjectProperty("ReceptionistImage", gxTpr_Receptionistimage, false);
			AddObjectProperty("ReceptionistImage_GXI", gxTpr_Receptionistimage_gxi, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ReceptionistId")]
		[XmlElement(ElementName="ReceptionistId")]
		public Guid gxTpr_Receptionistid
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistid; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistid = value;
				SetDirty("Receptionistid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Organisationid; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationid; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="LocationName")]
		[XmlElement(ElementName="LocationName")]
		public string gxTpr_Locationname
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationname; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationname = value;
				SetDirty("Locationname");
			}
		}




		[SoapElement(ElementName="ReceptionistGivenName")]
		[XmlElement(ElementName="ReceptionistGivenName")]
		public string gxTpr_Receptionistgivenname
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgivenname; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgivenname = value;
				SetDirty("Receptionistgivenname");
			}
		}




		[SoapElement(ElementName="ReceptionistLastName")]
		[XmlElement(ElementName="ReceptionistLastName")]
		public string gxTpr_Receptionistlastname
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistlastname; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistlastname = value;
				SetDirty("Receptionistlastname");
			}
		}




		[SoapElement(ElementName="ReceptionistEmail")]
		[XmlElement(ElementName="ReceptionistEmail")]
		public string gxTpr_Receptionistemail
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistemail; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistemail = value;
				SetDirty("Receptionistemail");
			}
		}




		[SoapElement(ElementName="ReceptionistPhone")]
		[XmlElement(ElementName="ReceptionistPhone")]
		public string gxTpr_Receptionistphone
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphone; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphone = value;
				SetDirty("Receptionistphone");
			}
		}




		[SoapElement(ElementName="ReceptionistPhoneCode")]
		[XmlElement(ElementName="ReceptionistPhoneCode")]
		public string gxTpr_Receptionistphonecode
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonecode; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonecode = value;
				SetDirty("Receptionistphonecode");
			}
		}




		[SoapElement(ElementName="ReceptionistPhoneNumber")]
		[XmlElement(ElementName="ReceptionistPhoneNumber")]
		public string gxTpr_Receptionistphonenumber
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonenumber; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonenumber = value;
				SetDirty("Receptionistphonenumber");
			}
		}




		[SoapElement(ElementName="ReceptionistStatus")]
		[XmlElement(ElementName="ReceptionistStatus")]
		public string gxTpr_Receptioniststatus
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptioniststatus; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptioniststatus = value;
				SetDirty("Receptioniststatus");
			}
		}




		[SoapElement(ElementName="ReceptionistIsActive")]
		[XmlElement(ElementName="ReceptionistIsActive")]
		public bool gxTpr_Receptionistisactive
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistisactive; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistisactive = value;
				SetDirty("Receptionistisactive");
			}
		}




		[SoapElement(ElementName="ReceptionistGAMGUID")]
		[XmlElement(ElementName="ReceptionistGAMGUID")]
		public string gxTpr_Receptionistgamguid
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgamguid; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgamguid = value;
				SetDirty("Receptionistgamguid");
			}
		}




		[SoapElement(ElementName="ReceptionistImage")]
		[XmlElement(ElementName="ReceptionistImage")]
		[GxUpload()]

		public string gxTpr_Receptionistimage
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage; 
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage = value;
				SetDirty("Receptionistimage");
			}
		}


		[SoapElement(ElementName="ReceptionistImage_GXI" )]
		[XmlElement(ElementName="ReceptionistImage_GXI" )]
		public string gxTpr_Receptionistimage_gxi
		{
			get {
				return gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage_gxi ;
			}
			set {
				gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage_gxi = value;
				SetDirty("Receptionistimage_gxi");
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
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationname = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgivenname = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistlastname = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistemail = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphone = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonecode = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonenumber = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptioniststatus = "";

			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgamguid = "";
			gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage = "";gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage_gxi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistid;
		 

		protected Guid gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Organisationid;
		 

		protected Guid gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationid;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Locationname;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgivenname;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistlastname;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistemail;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphone;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonecode;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistphonenumber;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptioniststatus;
		 

		protected bool gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistisactive;
		 

		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistgamguid;
		 
		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage_gxi;
		protected string gxTv_SdtSDT_Receptionists_SDT_ReceptionistsItem_Receptionistimage;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ReceptionistsItem", Namespace="Comforta_version21")]
	public class SdtSDT_Receptionists_SDT_ReceptionistsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_Receptionists_SDT_ReceptionistsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Receptionists_SDT_ReceptionistsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Receptionists_SDT_ReceptionistsItem_RESTInterface( SdtSDT_Receptionists_SDT_ReceptionistsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ReceptionistId", Order=0)]
		public Guid gxTpr_Receptionistid
		{
			get { 
				return sdt.gxTpr_Receptionistid;

			}
			set { 
				sdt.gxTpr_Receptionistid = value;
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

		[DataMember(Name="LocationId", Order=2)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="LocationName", Order=3)]
		public  string gxTpr_Locationname
		{
			get { 
				return sdt.gxTpr_Locationname;

			}
			set { 
				 sdt.gxTpr_Locationname = value;
			}
		}

		[DataMember(Name="ReceptionistGivenName", Order=4)]
		public  string gxTpr_Receptionistgivenname
		{
			get { 
				return sdt.gxTpr_Receptionistgivenname;

			}
			set { 
				 sdt.gxTpr_Receptionistgivenname = value;
			}
		}

		[DataMember(Name="ReceptionistLastName", Order=5)]
		public  string gxTpr_Receptionistlastname
		{
			get { 
				return sdt.gxTpr_Receptionistlastname;

			}
			set { 
				 sdt.gxTpr_Receptionistlastname = value;
			}
		}

		[DataMember(Name="ReceptionistEmail", Order=6)]
		public  string gxTpr_Receptionistemail
		{
			get { 
				return sdt.gxTpr_Receptionistemail;

			}
			set { 
				 sdt.gxTpr_Receptionistemail = value;
			}
		}

		[DataMember(Name="ReceptionistPhone", Order=7)]
		public  string gxTpr_Receptionistphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receptionistphone);

			}
			set { 
				 sdt.gxTpr_Receptionistphone = value;
			}
		}

		[DataMember(Name="ReceptionistPhoneCode", Order=8)]
		public  string gxTpr_Receptionistphonecode
		{
			get { 
				return sdt.gxTpr_Receptionistphonecode;

			}
			set { 
				 sdt.gxTpr_Receptionistphonecode = value;
			}
		}

		[DataMember(Name="ReceptionistPhoneNumber", Order=9)]
		public  string gxTpr_Receptionistphonenumber
		{
			get { 
				return sdt.gxTpr_Receptionistphonenumber;

			}
			set { 
				 sdt.gxTpr_Receptionistphonenumber = value;
			}
		}

		[DataMember(Name="ReceptionistStatus", Order=10)]
		public  string gxTpr_Receptioniststatus
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receptioniststatus);

			}
			set { 
				 sdt.gxTpr_Receptioniststatus = value;
			}
		}

		[DataMember(Name="ReceptionistIsActive", Order=11)]
		public bool gxTpr_Receptionistisactive
		{
			get { 
				return sdt.gxTpr_Receptionistisactive;

			}
			set { 
				sdt.gxTpr_Receptionistisactive = value;
			}
		}

		[DataMember(Name="ReceptionistGAMGUID", Order=12)]
		public  string gxTpr_Receptionistgamguid
		{
			get { 
				return sdt.gxTpr_Receptionistgamguid;

			}
			set { 
				 sdt.gxTpr_Receptionistgamguid = value;
			}
		}

		[DataMember(Name="ReceptionistImage", Order=13)]
		[GxUpload()]
		public  string gxTpr_Receptionistimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Receptionistimage)) ? PathUtil.RelativePath( sdt.gxTpr_Receptionistimage) : StringUtil.RTrim( sdt.gxTpr_Receptionistimage_gxi));

			}
			set { 
				 sdt.gxTpr_Receptionistimage = value;
			}
		}


		#endregion

		public SdtSDT_Receptionists_SDT_ReceptionistsItem sdt
		{
			get { 
				return (SdtSDT_Receptionists_SDT_ReceptionistsItem)Sdt;
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
				sdt = new SdtSDT_Receptionists_SDT_ReceptionistsItem() ;
			}
		}
	}
	#endregion
}