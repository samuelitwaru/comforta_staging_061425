/*
				   File: type_SdtSDT_InfoContent_InfoContentItem_ColumnsItem
			Description: Columns
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
	[XmlRoot(ElementName="SDT_InfoContent.InfoContentItem.ColumnsItem")]
	[XmlType(TypeName="SDT_InfoContent.InfoContentItem.ColumnsItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_InfoContent_InfoContentItem_ColumnsItem : GxUserType
	{
		public SdtSDT_InfoContent_InfoContentItem_ColumnsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Colid = "";

		}

		public SdtSDT_InfoContent_InfoContentItem_ColumnsItem(IGxContext context)
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
			AddObjectProperty("ColId", gxTpr_Colid, false);

			if (gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles != null)
			{
				AddObjectProperty("Tiles", gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ColId")]
		[XmlElement(ElementName="ColId")]
		public string gxTpr_Colid
		{
			get {
				return gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Colid; 
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Colid = value;
				SetDirty("Colid");
			}
		}




		[SoapElement(ElementName="Tiles" )]
		[XmlArray(ElementName="Tiles"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem> gxTpr_Tiles_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles == null )
				{
					gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles = new GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem>( context, "SDT_InfoTile", "");
				}
				return gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles;
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_N = false;
				gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem> gxTpr_Tiles
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles == null )
				{
					gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles = new GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem>( context, "SDT_InfoTile", "");
				}
				gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_N = false;
				return gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles ;
			}
			set {
				gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_N = false;
				gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles = value;
				SetDirty("Tiles");
			}
		}

		public void gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_SetNull()
		{
			gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_N = true;
			gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles = null;
		}

		public bool gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_IsNull()
		{
			return gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles == null;
		}
		public bool ShouldSerializegxTpr_Tiles_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles != null && gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles.Count > 0;

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
			gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Colid = "";

			gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Colid;
		 
		protected bool gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_InfoTile_SDT_InfoTileItem> gxTv_SdtSDT_InfoContent_InfoContentItem_ColumnsItem_Tiles = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_InfoContent.InfoContentItem.ColumnsItem", Namespace="Comforta_version2")]
	public class SdtSDT_InfoContent_InfoContentItem_ColumnsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_InfoContent_InfoContentItem_ColumnsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_InfoContent_InfoContentItem_ColumnsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_InfoContent_InfoContentItem_ColumnsItem_RESTInterface( SdtSDT_InfoContent_InfoContentItem_ColumnsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ColId", Order=0)]
		public  string gxTpr_Colid
		{
			get { 
				return sdt.gxTpr_Colid;

			}
			set { 
				 sdt.gxTpr_Colid = value;
			}
		}

		[DataMember(Name="Tiles", Order=1, EmitDefaultValue=false)]
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


		#endregion

		public SdtSDT_InfoContent_InfoContentItem_ColumnsItem sdt
		{
			get { 
				return (SdtSDT_InfoContent_InfoContentItem_ColumnsItem)Sdt;
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
				sdt = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem() ;
			}
		}
	}
	#endregion
}