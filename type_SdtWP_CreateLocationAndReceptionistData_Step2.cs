/*
				   File: type_SdtWP_CreateLocationAndReceptionistData_Step2
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
	[XmlRoot(ElementName="WP_CreateLocationAndReceptionistData.Step2")]
	[XmlType(TypeName="WP_CreateLocationAndReceptionistData.Step2" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateLocationAndReceptionistData_Step2 : GxUserType
	{
		public SdtWP_CreateLocationAndReceptionistData_Step2( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgender = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonenumber = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonecode = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistsalutation = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Filename = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistimagevar = "";

		}

		public SdtWP_CreateLocationAndReceptionistData_Step2(IGxContext context)
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
			AddObjectProperty("ReceptionistGender", gxTpr_Receptionistgender, false);


			AddObjectProperty("ReceptionistEmail", gxTpr_Receptionistemail, false);


			AddObjectProperty("ReceptionistPhone", gxTpr_Receptionistphone, false);


			AddObjectProperty("ReceptionistPhoneNumber", gxTpr_Receptionistphonenumber, false);


			AddObjectProperty("ReceptionistPhoneCode", gxTpr_Receptionistphonecode, false);


			AddObjectProperty("ReceptionistId", gxTpr_Receptionistid, false);


			AddObjectProperty("ReceptionistSalutation", gxTpr_Receptionistsalutation, false);


			AddObjectProperty("ReceptionistGivenName", gxTpr_Receptionistgivenname, false);


			AddObjectProperty("ReceptionistLastName", gxTpr_Receptionistlastname, false);


			AddObjectProperty("FileName", gxTpr_Filename, false);


			AddObjectProperty("ReceptionistImageVar", gxTpr_Receptionistimagevar, false);

			if (gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists != null)
			{
				AddObjectProperty("SDT_Receptionists", gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ReceptionistGender")]
		[XmlElement(ElementName="ReceptionistGender")]
		public string gxTpr_Receptionistgender
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgender; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgender = value;
				SetDirty("Receptionistgender");
			}
		}




		[SoapElement(ElementName="ReceptionistEmail")]
		[XmlElement(ElementName="ReceptionistEmail")]
		public string gxTpr_Receptionistemail
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail = value;
				SetDirty("Receptionistemail");
			}
		}




		[SoapElement(ElementName="ReceptionistPhone")]
		[XmlElement(ElementName="ReceptionistPhone")]
		public string gxTpr_Receptionistphone
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone = value;
				SetDirty("Receptionistphone");
			}
		}




		[SoapElement(ElementName="ReceptionistPhoneNumber")]
		[XmlElement(ElementName="ReceptionistPhoneNumber")]
		public string gxTpr_Receptionistphonenumber
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonenumber; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonenumber = value;
				SetDirty("Receptionistphonenumber");
			}
		}




		[SoapElement(ElementName="ReceptionistPhoneCode")]
		[XmlElement(ElementName="ReceptionistPhoneCode")]
		public string gxTpr_Receptionistphonecode
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonecode; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonecode = value;
				SetDirty("Receptionistphonecode");
			}
		}




		[SoapElement(ElementName="ReceptionistId")]
		[XmlElement(ElementName="ReceptionistId")]
		public Guid gxTpr_Receptionistid
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistid; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistid = value;
				SetDirty("Receptionistid");
			}
		}




		[SoapElement(ElementName="ReceptionistSalutation")]
		[XmlElement(ElementName="ReceptionistSalutation")]
		public string gxTpr_Receptionistsalutation
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistsalutation; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistsalutation = value;
				SetDirty("Receptionistsalutation");
			}
		}




		[SoapElement(ElementName="ReceptionistGivenName")]
		[XmlElement(ElementName="ReceptionistGivenName")]
		public string gxTpr_Receptionistgivenname
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname = value;
				SetDirty("Receptionistgivenname");
			}
		}




		[SoapElement(ElementName="ReceptionistLastName")]
		[XmlElement(ElementName="ReceptionistLastName")]
		public string gxTpr_Receptionistlastname
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname = value;
				SetDirty("Receptionistlastname");
			}
		}




		[SoapElement(ElementName="FileName")]
		[XmlElement(ElementName="FileName")]
		public string gxTpr_Filename
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Filename; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Filename = value;
				SetDirty("Filename");
			}
		}




		[SoapElement(ElementName="ReceptionistImageVar")]
		[XmlElement(ElementName="ReceptionistImageVar")]
		public string gxTpr_Receptionistimagevar
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistimagevar; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistimagevar = value;
				SetDirty("Receptionistimagevar");
			}
		}




		[SoapElement(ElementName="SDT_Receptionists" )]
		[XmlArray(ElementName="SDT_Receptionists"  )]
		[XmlArrayItemAttribute(ElementName="SDT_ReceptionistsItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionists_SDT_ReceptionistsItem> gxTpr_Sdt_receptionists_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists == null )
				{
					gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = new GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionists_SDT_ReceptionistsItem>( context, "SDT_Receptionists", "");
				}
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists;
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = false;
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionists_SDT_ReceptionistsItem> gxTpr_Sdt_receptionists
		{
			get {
				if ( gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists == null )
				{
					gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = new GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionists_SDT_ReceptionistsItem>( context, "SDT_Receptionists", "");
				}
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = false;
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists ;
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = false;
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = value;
				SetDirty("Sdt_receptionists");
			}
		}

		public void gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_SetNull()
		{
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = true;
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = null;
		}

		public bool gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_IsNull()
		{
			return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists == null;
		}
		public bool ShouldSerializegxTpr_Sdt_receptionists_GXBaseCollection_Json()
		{
			return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists != null && gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists.Count > 0;

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
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgender = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonenumber = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonecode = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistsalutation = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Filename = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistimagevar = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgender;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonenumber;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphonecode;
		 

		protected Guid gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistid;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistsalutation;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Filename;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistimagevar;
		 
		protected bool gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionists_SDT_ReceptionistsItem> gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateLocationAndReceptionistData.Step2", Namespace="Comforta_version2")]
	public class SdtWP_CreateLocationAndReceptionistData_Step2_RESTInterface : GxGenericCollectionItem<SdtWP_CreateLocationAndReceptionistData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateLocationAndReceptionistData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateLocationAndReceptionistData_Step2_RESTInterface( SdtWP_CreateLocationAndReceptionistData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ReceptionistGender", Order=0)]
		public  string gxTpr_Receptionistgender
		{
			get { 
				return sdt.gxTpr_Receptionistgender;

			}
			set { 
				 sdt.gxTpr_Receptionistgender = value;
			}
		}

		[DataMember(Name="ReceptionistEmail", Order=1)]
		public  string gxTpr_Receptionistemail
		{
			get { 
				return sdt.gxTpr_Receptionistemail;

			}
			set { 
				 sdt.gxTpr_Receptionistemail = value;
			}
		}

		[DataMember(Name="ReceptionistPhone", Order=2)]
		public  string gxTpr_Receptionistphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receptionistphone);

			}
			set { 
				 sdt.gxTpr_Receptionistphone = value;
			}
		}

		[DataMember(Name="ReceptionistPhoneNumber", Order=3)]
		public  string gxTpr_Receptionistphonenumber
		{
			get { 
				return sdt.gxTpr_Receptionistphonenumber;

			}
			set { 
				 sdt.gxTpr_Receptionistphonenumber = value;
			}
		}

		[DataMember(Name="ReceptionistPhoneCode", Order=4)]
		public  string gxTpr_Receptionistphonecode
		{
			get { 
				return sdt.gxTpr_Receptionistphonecode;

			}
			set { 
				 sdt.gxTpr_Receptionistphonecode = value;
			}
		}

		[DataMember(Name="ReceptionistId", Order=5)]
		public Guid gxTpr_Receptionistid
		{
			get { 
				return sdt.gxTpr_Receptionistid;

			}
			set { 
				sdt.gxTpr_Receptionistid = value;
			}
		}

		[DataMember(Name="ReceptionistSalutation", Order=6)]
		public  string gxTpr_Receptionistsalutation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receptionistsalutation);

			}
			set { 
				 sdt.gxTpr_Receptionistsalutation = value;
			}
		}

		[DataMember(Name="ReceptionistGivenName", Order=7)]
		public  string gxTpr_Receptionistgivenname
		{
			get { 
				return sdt.gxTpr_Receptionistgivenname;

			}
			set { 
				 sdt.gxTpr_Receptionistgivenname = value;
			}
		}

		[DataMember(Name="ReceptionistLastName", Order=8)]
		public  string gxTpr_Receptionistlastname
		{
			get { 
				return sdt.gxTpr_Receptionistlastname;

			}
			set { 
				 sdt.gxTpr_Receptionistlastname = value;
			}
		}

		[DataMember(Name="FileName", Order=9)]
		public  string gxTpr_Filename
		{
			get { 
				return sdt.gxTpr_Filename;

			}
			set { 
				 sdt.gxTpr_Filename = value;
			}
		}

		[DataMember(Name="ReceptionistImageVar", Order=10)]
		public  string gxTpr_Receptionistimagevar
		{
			get { 
				return sdt.gxTpr_Receptionistimagevar;

			}
			set { 
				 sdt.gxTpr_Receptionistimagevar = value;
			}
		}

		[DataMember(Name="SDT_Receptionists", Order=11, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Receptionists_SDT_ReceptionistsItem_RESTInterface> gxTpr_Sdt_receptionists
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_receptionists_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Receptionists_SDT_ReceptionistsItem_RESTInterface>(sdt.gxTpr_Sdt_receptionists);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Sdt_receptionists);
			}
		}


		#endregion

		public SdtWP_CreateLocationAndReceptionistData_Step2 sdt
		{
			get { 
				return (SdtWP_CreateLocationAndReceptionistData_Step2)Sdt;
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
				sdt = new SdtWP_CreateLocationAndReceptionistData_Step2() ;
			}
		}
	}
	#endregion
}