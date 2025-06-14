/*
				   File: type_SdtSDT_AppVersion
			Description: SDT_AppVersion
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
	[XmlRoot(ElementName="SDT_AppVersion")]
	[XmlType(TypeName="SDT_AppVersion" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_AppVersion : GxUserType
	{
		public SdtSDT_AppVersion( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_AppVersion_Appversionname = "";

		}

		public SdtSDT_AppVersion(IGxContext context)
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


			AddObjectProperty("ThemeId", gxTpr_Themeid, false);

			if (gxTv_SdtSDT_AppVersion_Pages != null)
			{
				AddObjectProperty("Pages", gxTv_SdtSDT_AppVersion_Pages, false);
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
				return gxTv_SdtSDT_AppVersion_Appversionid; 
			}
			set {
				gxTv_SdtSDT_AppVersion_Appversionid = value;
				SetDirty("Appversionid");
			}
		}




		[SoapElement(ElementName="AppVersionName")]
		[XmlElement(ElementName="AppVersionName")]
		public string gxTpr_Appversionname
		{
			get {
				return gxTv_SdtSDT_AppVersion_Appversionname; 
			}
			set {
				gxTv_SdtSDT_AppVersion_Appversionname = value;
				SetDirty("Appversionname");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_AppVersion_Locationid; 
			}
			set {
				gxTv_SdtSDT_AppVersion_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="IsActive")]
		[XmlElement(ElementName="IsActive")]
		public bool gxTpr_Isactive
		{
			get {
				return gxTv_SdtSDT_AppVersion_Isactive; 
			}
			set {
				gxTv_SdtSDT_AppVersion_Isactive = value;
				SetDirty("Isactive");
			}
		}




		[SoapElement(ElementName="ThemeId")]
		[XmlElement(ElementName="ThemeId")]
		public Guid gxTpr_Themeid
		{
			get {
				return gxTv_SdtSDT_AppVersion_Themeid; 
			}
			set {
				gxTv_SdtSDT_AppVersion_Themeid = value;
				SetDirty("Themeid");
			}
		}




		[SoapElement(ElementName="Pages" )]
		[XmlArray(ElementName="Pages"  )]
		[XmlArrayItemAttribute(ElementName="PagesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_AppVersion_PagesItem> gxTpr_Pages
		{
			get {
				if ( gxTv_SdtSDT_AppVersion_Pages == null )
				{
					gxTv_SdtSDT_AppVersion_Pages = new GXBaseCollection<SdtSDT_AppVersion_PagesItem>( context, "SDT_AppVersion.PagesItem", "");
				}
				return gxTv_SdtSDT_AppVersion_Pages;
			}
			set {
				gxTv_SdtSDT_AppVersion_Pages_N = false;
				gxTv_SdtSDT_AppVersion_Pages = value;
				SetDirty("Pages");
			}
		}

		public void gxTv_SdtSDT_AppVersion_Pages_SetNull()
		{
			gxTv_SdtSDT_AppVersion_Pages_N = true;
			gxTv_SdtSDT_AppVersion_Pages = null;
		}

		public bool gxTv_SdtSDT_AppVersion_Pages_IsNull()
		{
			return gxTv_SdtSDT_AppVersion_Pages == null;
		}
		public bool ShouldSerializegxTpr_Pages_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_AppVersion_Pages != null && gxTv_SdtSDT_AppVersion_Pages.Count > 0;

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
			gxTv_SdtSDT_AppVersion_Appversionname = "";




			gxTv_SdtSDT_AppVersion_Pages_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_AppVersion_Appversionid;
		 

		protected string gxTv_SdtSDT_AppVersion_Appversionname;
		 

		protected Guid gxTv_SdtSDT_AppVersion_Locationid;
		 

		protected bool gxTv_SdtSDT_AppVersion_Isactive;
		 

		protected Guid gxTv_SdtSDT_AppVersion_Themeid;
		 
		protected bool gxTv_SdtSDT_AppVersion_Pages_N;
		protected GXBaseCollection<SdtSDT_AppVersion_PagesItem> gxTv_SdtSDT_AppVersion_Pages = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_AppVersion", Namespace="Comforta_version21")]
	public class SdtSDT_AppVersion_RESTInterface : GxGenericCollectionItem<SdtSDT_AppVersion>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_AppVersion_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_AppVersion_RESTInterface( SdtSDT_AppVersion psdt ) : base(psdt)
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

		[DataMember(Name="ThemeId", Order=4)]
		public Guid gxTpr_Themeid
		{
			get { 
				return sdt.gxTpr_Themeid;

			}
			set { 
				sdt.gxTpr_Themeid = value;
			}
		}

		[DataMember(Name="Pages", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_AppVersion_PagesItem_RESTInterface> gxTpr_Pages
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pages_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_AppVersion_PagesItem_RESTInterface>(sdt.gxTpr_Pages);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Pages);
			}
		}


		#endregion

		public SdtSDT_AppVersion sdt
		{
			get { 
				return (SdtSDT_AppVersion)Sdt;
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
				sdt = new SdtSDT_AppVersion() ;
			}
		}
	}
	#endregion
}