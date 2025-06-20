/*
				   File: type_SdtSDT_MobileInfoPage_InfoContentItem
			Description: InfoContent
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
	[XmlRoot(ElementName="SDT_MobileInfoPage.InfoContentItem")]
	[XmlType(TypeName="SDT_MobileInfoPage.InfoContentItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_MobileInfoPage_InfoContentItem : GxUserType
	{
		public SdtSDT_MobileInfoPage_InfoContentItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infoid = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infotype = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infovalue = "";

		}

		public SdtSDT_MobileInfoPage_InfoContentItem(IGxContext context)
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
			AddObjectProperty("InfoId", gxTpr_Infoid, false);


			AddObjectProperty("InfoType", gxTpr_Infotype, false);


			AddObjectProperty("InfoValue", gxTpr_Infovalue, false);

			if (gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles != null)
			{
				AddObjectProperty("Tiles", gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles, false);
			}
			if (gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images != null)
			{
				AddObjectProperty("Images", gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images, false);
			}
			if (gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes != null)
			{
				AddObjectProperty("CtaAttributes", gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="InfoId")]
		[XmlElement(ElementName="InfoId")]
		public string gxTpr_Infoid
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infoid; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infoid = value;
				SetDirty("Infoid");
			}
		}




		[SoapElement(ElementName="InfoType")]
		[XmlElement(ElementName="InfoType")]
		public string gxTpr_Infotype
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infotype; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infotype = value;
				SetDirty("Infotype");
			}
		}




		[SoapElement(ElementName="InfoValue")]
		[XmlElement(ElementName="InfoValue")]
		public string gxTpr_Infovalue
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infovalue; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infovalue = value;
				SetDirty("Infovalue");
			}
		}



		[SoapElement(ElementName="Tiles")]
		[XmlElement(ElementName="Tiles")]
		public GeneXus.Programs.SdtSDT_Tile gxTpr_Tiles
		{
			get {
				if ( gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles == null )
				{
					gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles = new GeneXus.Programs.SdtSDT_Tile(context);
				}
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles = value;
				SetDirty("Tiles");
			}
		}
		public void gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles_SetNull()
		{
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles_N = true;
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles = null;
		}

		public bool gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles_IsNull()
		{
			return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles == null;
		}
		public bool ShouldSerializegxTpr_Tiles_Json()
		{
			return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles != null;

		}


		[SoapElement(ElementName="Images" )]
		[XmlArray(ElementName="Images"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Images_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images == null )
				{
					gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images;
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_N = false;
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Images
		{
			get {
				if ( gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images == null )
				{
					gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images = new GxSimpleCollection<string>();
				}
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_N = false;
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images ;
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_N = false;
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images = value;
				SetDirty("Images");
			}
		}

		public void gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_SetNull()
		{
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_N = true;
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images = null;
		}

		public bool gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_IsNull()
		{
			return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images == null;
		}
		public bool ShouldSerializegxTpr_Images_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images != null && gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images.Count > 0;

		}

		[SoapElement(ElementName="CtaAttributes" )]
		[XmlElement(ElementName="CtaAttributes" )]
		public SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes gxTpr_Ctaattributes
		{
			get {
				if ( gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes == null )
				{
					gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes = new SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes(context);
				}
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes_N = false;
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes;
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes_N = false;
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes = value;
				SetDirty("Ctaattributes");
			}

		}

		public void gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes_SetNull()
		{
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes_N = true;
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes = null;
		}

		public bool gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes_IsNull()
		{
			return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes == null;
		}
		public bool ShouldSerializegxTpr_Ctaattributes_Json()
		{
				return (gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes != null && gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infoid = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infotype = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infovalue = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles_N = true;


			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_N = true;


			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infoid;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infotype;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Infovalue;
		 

		protected GeneXus.Programs.SdtSDT_Tile gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles = null;
		protected bool gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Tiles_N;
		 
		protected bool gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images_N;
		protected GxSimpleCollection<string> gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Images = null;  
		protected bool gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes_N;
		protected SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes gxTv_SdtSDT_MobileInfoPage_InfoContentItem_Ctaattributes = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_MobileInfoPage.InfoContentItem", Namespace="Comforta_version2")]
	public class SdtSDT_MobileInfoPage_InfoContentItem_RESTInterface : GxGenericCollectionItem<SdtSDT_MobileInfoPage_InfoContentItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MobileInfoPage_InfoContentItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MobileInfoPage_InfoContentItem_RESTInterface( SdtSDT_MobileInfoPage_InfoContentItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="InfoId", Order=0)]
		public  string gxTpr_Infoid
		{
			get { 
				return sdt.gxTpr_Infoid;

			}
			set { 
				 sdt.gxTpr_Infoid = value;
			}
		}

		[DataMember(Name="InfoType", Order=1)]
		public  string gxTpr_Infotype
		{
			get { 
				return sdt.gxTpr_Infotype;

			}
			set { 
				 sdt.gxTpr_Infotype = value;
			}
		}

		[DataMember(Name="InfoValue", Order=2)]
		public  string gxTpr_Infovalue
		{
			get { 
				return sdt.gxTpr_Infovalue;

			}
			set { 
				 sdt.gxTpr_Infovalue = value;
			}
		}

		[DataMember(Name="Tiles", Order=3, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_Tile_RESTInterface gxTpr_Tiles
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Tiles_Json())
					return new GeneXus.Programs.SdtSDT_Tile_RESTInterface(sdt.gxTpr_Tiles);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Tiles = value.sdt;
			}
		}

		[DataMember(Name="Images", Order=4, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Images
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Images_GxSimpleCollection_Json())
					return sdt.gxTpr_Images;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Images = value ;
			}
		}

		[DataMember(Name="CtaAttributes", Order=5, EmitDefaultValue=false)]
		public SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_RESTInterface gxTpr_Ctaattributes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Ctaattributes_Json())
					return new SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_RESTInterface(sdt.gxTpr_Ctaattributes);
				else
					return null;

			}

			set {
				sdt.gxTpr_Ctaattributes = value.sdt;
			}

		}


		#endregion

		public SdtSDT_MobileInfoPage_InfoContentItem sdt
		{
			get { 
				return (SdtSDT_MobileInfoPage_InfoContentItem)Sdt;
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
				sdt = new SdtSDT_MobileInfoPage_InfoContentItem() ;
			}
		}
	}
	#endregion
}