/*
				   File: type_SdtSDT_MenuPage_RowsItem
			Description: Rows
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
	[XmlRoot(ElementName="SDT_MenuPage.RowsItem")]
	[XmlType(TypeName="SDT_MenuPage.RowsItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_MenuPage_RowsItem : GxUserType
	{
		public SdtSDT_MenuPage_RowsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_MenuPage_RowsItem_Id = "";

		}

		public SdtSDT_MenuPage_RowsItem(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);

			if (gxTv_SdtSDT_MenuPage_RowsItem_Tiles != null)
			{
				AddObjectProperty("Tiles", gxTv_SdtSDT_MenuPage_RowsItem_Tiles, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_Id; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Tiles" )]
		[XmlArray(ElementName="Tiles"  )]
		[XmlArrayItemAttribute(ElementName="TilesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_MenuPage_RowsItem_TilesItem> gxTpr_Tiles
		{
			get {
				if ( gxTv_SdtSDT_MenuPage_RowsItem_Tiles == null )
				{
					gxTv_SdtSDT_MenuPage_RowsItem_Tiles = new GXBaseCollection<SdtSDT_MenuPage_RowsItem_TilesItem>( context, "SDT_MenuPage.RowsItem.TilesItem", "");
				}
				return gxTv_SdtSDT_MenuPage_RowsItem_Tiles;
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_Tiles_N = false;
				gxTv_SdtSDT_MenuPage_RowsItem_Tiles = value;
				SetDirty("Tiles");
			}
		}

		public void gxTv_SdtSDT_MenuPage_RowsItem_Tiles_SetNull()
		{
			gxTv_SdtSDT_MenuPage_RowsItem_Tiles_N = true;
			gxTv_SdtSDT_MenuPage_RowsItem_Tiles = null;
		}

		public bool gxTv_SdtSDT_MenuPage_RowsItem_Tiles_IsNull()
		{
			return gxTv_SdtSDT_MenuPage_RowsItem_Tiles == null;
		}
		public bool ShouldSerializegxTpr_Tiles_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_MenuPage_RowsItem_Tiles != null && gxTv_SdtSDT_MenuPage_RowsItem_Tiles.Count > 0;

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
			gxTv_SdtSDT_MenuPage_RowsItem_Id = "";

			gxTv_SdtSDT_MenuPage_RowsItem_Tiles_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_MenuPage_RowsItem_Id;
		 
		protected bool gxTv_SdtSDT_MenuPage_RowsItem_Tiles_N;
		protected GXBaseCollection<SdtSDT_MenuPage_RowsItem_TilesItem> gxTv_SdtSDT_MenuPage_RowsItem_Tiles = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_MenuPage.RowsItem", Namespace="Comforta_version2")]
	public class SdtSDT_MenuPage_RowsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_MenuPage_RowsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MenuPage_RowsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MenuPage_RowsItem_RESTInterface( SdtSDT_MenuPage_RowsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Tiles", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_MenuPage_RowsItem_TilesItem_RESTInterface> gxTpr_Tiles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Tiles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_MenuPage_RowsItem_TilesItem_RESTInterface>(sdt.gxTpr_Tiles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Tiles);
			}
		}


		#endregion

		public SdtSDT_MenuPage_RowsItem sdt
		{
			get { 
				return (SdtSDT_MenuPage_RowsItem)Sdt;
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
				sdt = new SdtSDT_MenuPage_RowsItem() ;
			}
		}
	}
	#endregion
}