/*
				   File: type_SdtSDT_OrganisationSetting
			Description: SDT_OrganisationSetting
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
	[XmlRoot(ElementName="SDT_OrganisationSetting")]
	[XmlType(TypeName="SDT_OrganisationSetting" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_OrganisationSetting : GxUserType
	{
		public SdtSDT_OrganisationSetting( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo_gxi = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon_gxi = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettingbasecolor = "";

			gxTv_SdtSDT_OrganisationSetting_Organisationsettingfontsize = "";

			gxTv_SdtSDT_OrganisationSetting_Organisationsettinglanguage = "";

		}

		public SdtSDT_OrganisationSetting(IGxContext context)
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
			AddObjectProperty("OrganisationSettingid", gxTpr_Organisationsettingid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("OrganisationSettingLogo", gxTpr_Organisationsettinglogo, false);
			AddObjectProperty("OrganisationSettingLogo_GXI", gxTpr_Organisationsettinglogo_gxi, false);



			AddObjectProperty("OrganisationSettingFavicon", gxTpr_Organisationsettingfavicon, false);
			AddObjectProperty("OrganisationSettingFavicon_GXI", gxTpr_Organisationsettingfavicon_gxi, false);



			AddObjectProperty("OrganisationSettingBaseColor", gxTpr_Organisationsettingbasecolor, false);


			AddObjectProperty("OrganisationSettingFontSize", gxTpr_Organisationsettingfontsize, false);


			AddObjectProperty("OrganisationSettingLanguage", gxTpr_Organisationsettinglanguage, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrganisationSettingid")]
		[XmlElement(ElementName="OrganisationSettingid")]
		public Guid gxTpr_Organisationsettingid
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettingid; 
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettingid = value;
				SetDirty("Organisationsettingid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationid; 
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="OrganisationSettingLogo")]
		[XmlElement(ElementName="OrganisationSettingLogo")]
		[GxUpload()]

		public string gxTpr_Organisationsettinglogo
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo; 
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo = value;
				SetDirty("Organisationsettinglogo");
			}
		}


		[SoapElement(ElementName="OrganisationSettingLogo_GXI" )]
		[XmlElement(ElementName="OrganisationSettingLogo_GXI" )]
		public string gxTpr_Organisationsettinglogo_gxi
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo_gxi ;
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo_gxi = value;
				SetDirty("Organisationsettinglogo_gxi");
			}
		}

		[SoapElement(ElementName="OrganisationSettingFavicon")]
		[XmlElement(ElementName="OrganisationSettingFavicon")]
		[GxUpload()]

		public string gxTpr_Organisationsettingfavicon
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon; 
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon = value;
				SetDirty("Organisationsettingfavicon");
			}
		}


		[SoapElement(ElementName="OrganisationSettingFavicon_GXI" )]
		[XmlElement(ElementName="OrganisationSettingFavicon_GXI" )]
		public string gxTpr_Organisationsettingfavicon_gxi
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon_gxi ;
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon_gxi = value;
				SetDirty("Organisationsettingfavicon_gxi");
			}
		}

		[SoapElement(ElementName="OrganisationSettingBaseColor")]
		[XmlElement(ElementName="OrganisationSettingBaseColor")]
		public string gxTpr_Organisationsettingbasecolor
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettingbasecolor; 
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettingbasecolor = value;
				SetDirty("Organisationsettingbasecolor");
			}
		}




		[SoapElement(ElementName="OrganisationSettingFontSize")]
		[XmlElement(ElementName="OrganisationSettingFontSize")]
		public string gxTpr_Organisationsettingfontsize
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettingfontsize; 
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettingfontsize = value;
				SetDirty("Organisationsettingfontsize");
			}
		}




		[SoapElement(ElementName="OrganisationSettingLanguage")]
		[XmlElement(ElementName="OrganisationSettingLanguage")]
		public string gxTpr_Organisationsettinglanguage
		{
			get {
				return gxTv_SdtSDT_OrganisationSetting_Organisationsettinglanguage; 
			}
			set {
				gxTv_SdtSDT_OrganisationSetting_Organisationsettinglanguage = value;
				SetDirty("Organisationsettinglanguage");
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
			gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo = "";gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo_gxi = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon = "";gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon_gxi = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettingbasecolor = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettingfontsize = "";
			gxTv_SdtSDT_OrganisationSetting_Organisationsettinglanguage = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_OrganisationSetting_Organisationsettingid;
		 

		protected Guid gxTv_SdtSDT_OrganisationSetting_Organisationid;
		 
		protected string gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo_gxi;
		protected string gxTv_SdtSDT_OrganisationSetting_Organisationsettinglogo;
		 
		protected string gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon_gxi;
		protected string gxTv_SdtSDT_OrganisationSetting_Organisationsettingfavicon;
		 

		protected string gxTv_SdtSDT_OrganisationSetting_Organisationsettingbasecolor;
		 

		protected string gxTv_SdtSDT_OrganisationSetting_Organisationsettingfontsize;
		 

		protected string gxTv_SdtSDT_OrganisationSetting_Organisationsettinglanguage;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OrganisationSetting", Namespace="Comforta_version21")]
	public class SdtSDT_OrganisationSetting_RESTInterface : GxGenericCollectionItem<SdtSDT_OrganisationSetting>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OrganisationSetting_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OrganisationSetting_RESTInterface( SdtSDT_OrganisationSetting psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrganisationSettingid", Order=0)]
		public Guid gxTpr_Organisationsettingid
		{
			get { 
				return sdt.gxTpr_Organisationsettingid;

			}
			set { 
				sdt.gxTpr_Organisationsettingid = value;
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

		[DataMember(Name="OrganisationSettingLogo", Order=2)]
		[GxUpload()]
		public  string gxTpr_Organisationsettinglogo
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo)) ? PathUtil.RelativePath( sdt.gxTpr_Organisationsettinglogo) : StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo_gxi));

			}
			set { 
				 sdt.gxTpr_Organisationsettinglogo = value;
			}
		}

		[DataMember(Name="OrganisationSettingFavicon", Order=3)]
		[GxUpload()]
		public  string gxTpr_Organisationsettingfavicon
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon)) ? PathUtil.RelativePath( sdt.gxTpr_Organisationsettingfavicon) : StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon_gxi));

			}
			set { 
				 sdt.gxTpr_Organisationsettingfavicon = value;
			}
		}

		[DataMember(Name="OrganisationSettingBaseColor", Order=4)]
		public  string gxTpr_Organisationsettingbasecolor
		{
			get { 
				return sdt.gxTpr_Organisationsettingbasecolor;

			}
			set { 
				 sdt.gxTpr_Organisationsettingbasecolor = value;
			}
		}

		[DataMember(Name="OrganisationSettingFontSize", Order=5)]
		public  string gxTpr_Organisationsettingfontsize
		{
			get { 
				return sdt.gxTpr_Organisationsettingfontsize;

			}
			set { 
				 sdt.gxTpr_Organisationsettingfontsize = value;
			}
		}

		[DataMember(Name="OrganisationSettingLanguage", Order=6)]
		public  string gxTpr_Organisationsettinglanguage
		{
			get { 
				return sdt.gxTpr_Organisationsettinglanguage;

			}
			set { 
				 sdt.gxTpr_Organisationsettinglanguage = value;
			}
		}


		#endregion

		public SdtSDT_OrganisationSetting sdt
		{
			get { 
				return (SdtSDT_OrganisationSetting)Sdt;
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
				sdt = new SdtSDT_OrganisationSetting() ;
			}
		}
	}
	#endregion
}