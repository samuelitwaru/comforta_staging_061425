/*
				   File: type_SdtSDT_AppVersion2
			Description: SDT_AppVersion2
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
	[XmlRoot(ElementName="SDT_AppVersion2")]
	[XmlType(TypeName="SDT_AppVersion2" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_AppVersion2 : GxUserType
	{
		public SdtSDT_AppVersion2( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_AppVersion2_Appversionname = "";

		}

		public SdtSDT_AppVersion2(IGxContext context)
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
			AddObjectProperty("AppVersionId", gxTpr_Appversionid, false);


			AddObjectProperty("AppVersionName", gxTpr_Appversionname, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("IsActive", gxTpr_Isactive, false);

			if (gxTv_SdtSDT_AppVersion2_Sdt_theme != null)
			{
				AddObjectProperty("SDT_Theme", gxTv_SdtSDT_AppVersion2_Sdt_theme, false);
			}
			if (gxTv_SdtSDT_AppVersion2_Pages != null)
			{
				AddObjectProperty("Pages", gxTv_SdtSDT_AppVersion2_Pages, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AppVersionId")]
		[XmlElement(ElementName="AppVersionId")]
		public Guid gxTpr_Appversionid
		{
			get {
				return gxTv_SdtSDT_AppVersion2_Appversionid; 
			}
			set {
				gxTv_SdtSDT_AppVersion2_Appversionid = value;
				SetDirty("Appversionid");
			}
		}




		[SoapElement(ElementName="AppVersionName")]
		[XmlElement(ElementName="AppVersionName")]
		public string gxTpr_Appversionname
		{
			get {
				return gxTv_SdtSDT_AppVersion2_Appversionname; 
			}
			set {
				gxTv_SdtSDT_AppVersion2_Appversionname = value;
				SetDirty("Appversionname");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_AppVersion2_Locationid; 
			}
			set {
				gxTv_SdtSDT_AppVersion2_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="IsActive")]
		[XmlElement(ElementName="IsActive")]
		public bool gxTpr_Isactive
		{
			get {
				return gxTv_SdtSDT_AppVersion2_Isactive; 
			}
			set {
				gxTv_SdtSDT_AppVersion2_Isactive = value;
				SetDirty("Isactive");
			}
		}



		[SoapElement(ElementName="SDT_Theme" )]
		[XmlElement(ElementName="SDT_Theme" )]
		public SdtSDT_AppVersion2_SDT_Theme gxTpr_Sdt_theme
		{
			get {
				if ( gxTv_SdtSDT_AppVersion2_Sdt_theme == null )
				{
					gxTv_SdtSDT_AppVersion2_Sdt_theme = new SdtSDT_AppVersion2_SDT_Theme(context);
				}
				gxTv_SdtSDT_AppVersion2_Sdt_theme_N = false;
				return gxTv_SdtSDT_AppVersion2_Sdt_theme;
			}
			set {
				gxTv_SdtSDT_AppVersion2_Sdt_theme_N = false;
				gxTv_SdtSDT_AppVersion2_Sdt_theme = value;
				SetDirty("Sdt_theme");
			}

		}

		public void gxTv_SdtSDT_AppVersion2_Sdt_theme_SetNull()
		{
			gxTv_SdtSDT_AppVersion2_Sdt_theme_N = true;
			gxTv_SdtSDT_AppVersion2_Sdt_theme = null;
		}

		public bool gxTv_SdtSDT_AppVersion2_Sdt_theme_IsNull()
		{
			return gxTv_SdtSDT_AppVersion2_Sdt_theme == null;
		}
		public bool ShouldSerializegxTpr_Sdt_theme_Json()
		{
				return (gxTv_SdtSDT_AppVersion2_Sdt_theme != null && gxTv_SdtSDT_AppVersion2_Sdt_theme.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="Pages" )]
		[XmlArray(ElementName="Pages"  )]
		[XmlArrayItemAttribute(ElementName="PagesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_AppVersion2_PagesItem> gxTpr_Pages
		{
			get {
				if ( gxTv_SdtSDT_AppVersion2_Pages == null )
				{
					gxTv_SdtSDT_AppVersion2_Pages = new GXBaseCollection<SdtSDT_AppVersion2_PagesItem>( context, "SDT_AppVersion2.PagesItem", "");
				}
				return gxTv_SdtSDT_AppVersion2_Pages;
			}
			set {
				gxTv_SdtSDT_AppVersion2_Pages_N = false;
				gxTv_SdtSDT_AppVersion2_Pages = value;
				SetDirty("Pages");
			}
		}

		public void gxTv_SdtSDT_AppVersion2_Pages_SetNull()
		{
			gxTv_SdtSDT_AppVersion2_Pages_N = true;
			gxTv_SdtSDT_AppVersion2_Pages = null;
		}

		public bool gxTv_SdtSDT_AppVersion2_Pages_IsNull()
		{
			return gxTv_SdtSDT_AppVersion2_Pages == null;
		}
		public bool ShouldSerializegxTpr_Pages_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_AppVersion2_Pages != null && gxTv_SdtSDT_AppVersion2_Pages.Count > 0;

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
			gxTv_SdtSDT_AppVersion2_Appversionname = "";



			gxTv_SdtSDT_AppVersion2_Sdt_theme_N = true;


			gxTv_SdtSDT_AppVersion2_Pages_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_AppVersion2_Appversionid;
		 

		protected string gxTv_SdtSDT_AppVersion2_Appversionname;
		 

		protected Guid gxTv_SdtSDT_AppVersion2_Locationid;
		 

		protected bool gxTv_SdtSDT_AppVersion2_Isactive;
		 
		protected bool gxTv_SdtSDT_AppVersion2_Sdt_theme_N;
		protected SdtSDT_AppVersion2_SDT_Theme gxTv_SdtSDT_AppVersion2_Sdt_theme = null; 

		protected bool gxTv_SdtSDT_AppVersion2_Pages_N;
		protected GXBaseCollection<SdtSDT_AppVersion2_PagesItem> gxTv_SdtSDT_AppVersion2_Pages = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_AppVersion2", Namespace="Comforta_version21")]
	public class SdtSDT_AppVersion2_RESTInterface : GxGenericCollectionItem<SdtSDT_AppVersion2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_AppVersion2_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_AppVersion2_RESTInterface( SdtSDT_AppVersion2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AppVersionId", Order=0)]
		public Guid gxTpr_Appversionid
		{
			get { 
				return sdt.gxTpr_Appversionid;

			}
			set { 
				sdt.gxTpr_Appversionid = value;
			}
		}

		[DataMember(Name="AppVersionName", Order=1)]
		public  string gxTpr_Appversionname
		{
			get { 
				return sdt.gxTpr_Appversionname;

			}
			set { 
				 sdt.gxTpr_Appversionname = value;
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

		[DataMember(Name="IsActive", Order=3)]
		public bool gxTpr_Isactive
		{
			get { 
				return sdt.gxTpr_Isactive;

			}
			set { 
				sdt.gxTpr_Isactive = value;
			}
		}

		[DataMember(Name="SDT_Theme", Order=4, EmitDefaultValue=false)]
		public SdtSDT_AppVersion2_SDT_Theme_RESTInterface gxTpr_Sdt_theme
		{
			get {
				if (sdt.ShouldSerializegxTpr_Sdt_theme_Json())
					return new SdtSDT_AppVersion2_SDT_Theme_RESTInterface(sdt.gxTpr_Sdt_theme);
				else
					return null;

			}

			set {
				sdt.gxTpr_Sdt_theme = value.sdt;
			}

		}

		[DataMember(Name="Pages", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_AppVersion2_PagesItem_RESTInterface> gxTpr_Pages
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pages_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_AppVersion2_PagesItem_RESTInterface>(sdt.gxTpr_Pages);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Pages);
			}
		}


		#endregion

		public SdtSDT_AppVersion2 sdt
		{
			get { 
				return (SdtSDT_AppVersion2)Sdt;
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
				sdt = new SdtSDT_AppVersion2() ;
			}
		}
	}
	#endregion
}