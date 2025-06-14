/*
				   File: type_SdtSDT_InfoContent_InfoContentItem
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
	[XmlRoot(ElementName="SDT_InfoContent.InfoContentItem")]
	[XmlType(TypeName="SDT_InfoContent.InfoContentItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_InfoContent_InfoContentItem : GxUserType
	{
		public SdtSDT_InfoContent_InfoContentItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_InfoContent_InfoContentItem_Infoid = "";

			gxTv_SdtSDT_InfoContent_InfoContentItem_Infotype = "";

			gxTv_SdtSDT_InfoContent_InfoContentItem_Infovalue = "";

		}

		public SdtSDT_InfoContent_InfoContentItem(IGxContext context)
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

			if (gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles != null)
			{
				AddObjectProperty("Tiles", gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles, false);
			}
			if (gxTv_SdtSDT_InfoContent_InfoContentItem_Images != null)
			{
				AddObjectProperty("Images", gxTv_SdtSDT_InfoContent_InfoContentItem_Images, false);
			}
			if (gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes != null)
			{
				AddObjectProperty("CtaAttributes", gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes, false);
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
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Infoid; 
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Infoid = value;
				SetDirty("Infoid");
			}
		}




		[SoapElement(ElementName="InfoType")]
		[XmlElement(ElementName="InfoType")]
		public string gxTpr_Infotype
		{
			get {
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Infotype; 
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Infotype = value;
				SetDirty("Infotype");
			}
		}




		[SoapElement(ElementName="InfoValue")]
		[XmlElement(ElementName="InfoValue")]
		public string gxTpr_Infovalue
		{
			get {
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Infovalue; 
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Infovalue = value;
				SetDirty("Infovalue");
			}
		}




		[SoapElement(ElementName="Tiles" )]
		[XmlArray(ElementName="Tiles"  )]
		[XmlArrayItemAttribute(ElementName="SDT_InfoTileItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem> gxTpr_Tiles_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles == null )
				{
					gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles = new GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem>( context, "SDT_InfoTile", "");
				}
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles;
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_N = false;
				gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem> gxTpr_Tiles
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles == null )
				{
					gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles = new GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem>( context, "SDT_InfoTile", "");
				}
				gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_N = false;
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles ;
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_N = false;
				gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles = value;
				SetDirty("Tiles");
			}
		}

		public void gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_SetNull()
		{
			gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_N = true;
			gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles = null;
		}

		public bool gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_IsNull()
		{
			return gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles == null;
		}
		public bool ShouldSerializegxTpr_Tiles_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles != null && gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles.Count > 0;

		}


		[SoapElement(ElementName="Images" )]
		[XmlArray(ElementName="Images"  )]
		[XmlArrayItemAttribute(ElementName="SDT_InfoImageItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_InfoImage_SDT_InfoImageItem> gxTpr_Images_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_InfoContentItem_Images == null )
				{
					gxTv_SdtSDT_InfoContent_InfoContentItem_Images = new GXBaseCollection<GeneXus.Programs.SdtSDT_InfoImage_SDT_InfoImageItem>( context, "SDT_InfoImage", "");
				}
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Images;
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Images_N = false;
				gxTv_SdtSDT_InfoContent_InfoContentItem_Images = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_InfoImage_SDT_InfoImageItem> gxTpr_Images
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_InfoContentItem_Images == null )
				{
					gxTv_SdtSDT_InfoContent_InfoContentItem_Images = new GXBaseCollection<GeneXus.Programs.SdtSDT_InfoImage_SDT_InfoImageItem>( context, "SDT_InfoImage", "");
				}
				gxTv_SdtSDT_InfoContent_InfoContentItem_Images_N = false;
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Images ;
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Images_N = false;
				gxTv_SdtSDT_InfoContent_InfoContentItem_Images = value;
				SetDirty("Images");
			}
		}

		public void gxTv_SdtSDT_InfoContent_InfoContentItem_Images_SetNull()
		{
			gxTv_SdtSDT_InfoContent_InfoContentItem_Images_N = true;
			gxTv_SdtSDT_InfoContent_InfoContentItem_Images = null;
		}

		public bool gxTv_SdtSDT_InfoContent_InfoContentItem_Images_IsNull()
		{
			return gxTv_SdtSDT_InfoContent_InfoContentItem_Images == null;
		}
		public bool ShouldSerializegxTpr_Images_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_InfoContent_InfoContentItem_Images != null && gxTv_SdtSDT_InfoContent_InfoContentItem_Images.Count > 0;

		}

		[SoapElement(ElementName="CtaAttributes" )]
		[XmlElement(ElementName="CtaAttributes" )]
		public SdtSDT_InfoContent_InfoContentItem_CtaAttributes gxTpr_Ctaattributes
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes == null )
				{
					gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes = new SdtSDT_InfoContent_InfoContentItem_CtaAttributes(context);
				}
				gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes_N = false;
				return gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes;
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes_N = false;
				gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes = value;
				SetDirty("Ctaattributes");
			}

		}

		public void gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes_SetNull()
		{
			gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes_N = true;
			gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes = null;
		}

		public bool gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes_IsNull()
		{
			return gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes == null;
		}
		public bool ShouldSerializegxTpr_Ctaattributes_Json()
		{
				return (gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes != null && gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_InfoContent_InfoContentItem_Infoid = "";
			gxTv_SdtSDT_InfoContent_InfoContentItem_Infotype = "";
			gxTv_SdtSDT_InfoContent_InfoContentItem_Infovalue = "";

			gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_N = true;


			gxTv_SdtSDT_InfoContent_InfoContentItem_Images_N = true;


			gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_InfoContent_InfoContentItem_Infoid;
		 

		protected string gxTv_SdtSDT_InfoContent_InfoContentItem_Infotype;
		 

		protected string gxTv_SdtSDT_InfoContent_InfoContentItem_Infovalue;
		 
		protected bool gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem> gxTv_SdtSDT_InfoContent_InfoContentItem_Tiles = null;  
		protected bool gxTv_SdtSDT_InfoContent_InfoContentItem_Images_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_InfoImage_SDT_InfoImageItem> gxTv_SdtSDT_InfoContent_InfoContentItem_Images = null;  
		protected bool gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes_N;
		protected SdtSDT_InfoContent_InfoContentItem_CtaAttributes gxTv_SdtSDT_InfoContent_InfoContentItem_Ctaattributes = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_InfoContent.InfoContentItem", Namespace="Comforta_version21")]
	public class SdtSDT_InfoContent_InfoContentItem_RESTInterface : GxGenericCollectionItem<SdtSDT_InfoContent_InfoContentItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_InfoContent_InfoContentItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_InfoContent_InfoContentItem_RESTInterface( SdtSDT_InfoContent_InfoContentItem psdt ) : base(psdt)
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
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem_RESTInterface> gxTpr_Tiles
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Tiles_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem_RESTInterface>(sdt.gxTpr_Tiles);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Tiles);
			}
		}

		[DataMember(Name="Images", Order=4, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_InfoImage_SDT_InfoImageItem_RESTInterface> gxTpr_Images
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Images_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_InfoImage_SDT_InfoImageItem_RESTInterface>(sdt.gxTpr_Images);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Images);
			}
		}

		[DataMember(Name="CtaAttributes", Order=5, EmitDefaultValue=false)]
		public SdtSDT_InfoContent_InfoContentItem_CtaAttributes_RESTInterface gxTpr_Ctaattributes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Ctaattributes_Json())
					return new SdtSDT_InfoContent_InfoContentItem_CtaAttributes_RESTInterface(sdt.gxTpr_Ctaattributes);
				else
					return null;

			}

			set {
				sdt.gxTpr_Ctaattributes = value.sdt;
			}

		}


		#endregion

		public SdtSDT_InfoContent_InfoContentItem sdt
		{
			get { 
				return (SdtSDT_InfoContent_InfoContentItem)Sdt;
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
				sdt = new SdtSDT_InfoContent_InfoContentItem() ;
			}
		}
	}
	#endregion
}