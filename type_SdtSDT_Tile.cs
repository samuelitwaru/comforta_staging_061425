/*
				   File: type_SdtSDT_Tile
			Description: SDT_Tile
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
	[XmlRoot(ElementName="SDT_Tile")]
	[XmlType(TypeName="SDT_Tile" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_Tile : GxUserType
	{
		public SdtSDT_Tile( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Tile_Tileid = "";

			gxTv_SdtSDT_Tile_Tilename = "";

			gxTv_SdtSDT_Tile_Tiletext = "";

			gxTv_SdtSDT_Tile_Tilecolor = "";

			gxTv_SdtSDT_Tile_Tilealignment = "";

			gxTv_SdtSDT_Tile_Tileicon = "";

			gxTv_SdtSDT_Tile_Tilebgcolor = "";

			gxTv_SdtSDT_Tile_Tilebgimageurl = "";

		}

		public SdtSDT_Tile(IGxContext context)
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
			AddObjectProperty("TileId", gxTpr_Tileid, false);


			AddObjectProperty("TileName", gxTpr_Tilename, false);


			AddObjectProperty("TileText", gxTpr_Tiletext, false);


			AddObjectProperty("TileColor", gxTpr_Tilecolor, false);


			AddObjectProperty("TileAlignment", gxTpr_Tilealignment, false);


			AddObjectProperty("TileIcon", gxTpr_Tileicon, false);


			AddObjectProperty("TileBGColor", gxTpr_Tilebgcolor, false);


			AddObjectProperty("TileBGImageUrl", gxTpr_Tilebgimageurl, false);


			AddObjectProperty("TileBGImageOpacity", gxTpr_Tilebgimageopacity, false);

			if (gxTv_SdtSDT_Tile_Tileaction != null)
			{
				AddObjectProperty("TileAction", gxTv_SdtSDT_Tile_Tileaction, false);
			}

			AddObjectProperty("TileSize", gxTpr_Tilesize, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TileId")]
		[XmlElement(ElementName="TileId")]
		public string gxTpr_Tileid
		{
			get {
				return gxTv_SdtSDT_Tile_Tileid; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileid = value;
				SetDirty("Tileid");
			}
		}




		[SoapElement(ElementName="TileName")]
		[XmlElement(ElementName="TileName")]
		public string gxTpr_Tilename
		{
			get {
				return gxTv_SdtSDT_Tile_Tilename; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilename = value;
				SetDirty("Tilename");
			}
		}




		[SoapElement(ElementName="TileText")]
		[XmlElement(ElementName="TileText")]
		public string gxTpr_Tiletext
		{
			get {
				return gxTv_SdtSDT_Tile_Tiletext; 
			}
			set {
				gxTv_SdtSDT_Tile_Tiletext = value;
				SetDirty("Tiletext");
			}
		}




		[SoapElement(ElementName="TileColor")]
		[XmlElement(ElementName="TileColor")]
		public string gxTpr_Tilecolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tilecolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilecolor = value;
				SetDirty("Tilecolor");
			}
		}




		[SoapElement(ElementName="TileAlignment")]
		[XmlElement(ElementName="TileAlignment")]
		public string gxTpr_Tilealignment
		{
			get {
				return gxTv_SdtSDT_Tile_Tilealignment; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilealignment = value;
				SetDirty("Tilealignment");
			}
		}




		[SoapElement(ElementName="TileIcon")]
		[XmlElement(ElementName="TileIcon")]
		public string gxTpr_Tileicon
		{
			get {
				return gxTv_SdtSDT_Tile_Tileicon; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileicon = value;
				SetDirty("Tileicon");
			}
		}




		[SoapElement(ElementName="TileBGColor")]
		[XmlElement(ElementName="TileBGColor")]
		public string gxTpr_Tilebgcolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgcolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgcolor = value;
				SetDirty("Tilebgcolor");
			}
		}




		[SoapElement(ElementName="TileBGImageUrl")]
		[XmlElement(ElementName="TileBGImageUrl")]
		public string gxTpr_Tilebgimageurl
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgimageurl; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgimageurl = value;
				SetDirty("Tilebgimageurl");
			}
		}




		[SoapElement(ElementName="TileBGImageOpacity")]
		[XmlElement(ElementName="TileBGImageOpacity")]
		public short gxTpr_Tilebgimageopacity
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgimageopacity; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgimageopacity = value;
				SetDirty("Tilebgimageopacity");
			}
		}



		[SoapElement(ElementName="TileAction")]
		[XmlElement(ElementName="TileAction")]
		public GeneXus.Programs.SdtSDT_TileAction gxTpr_Tileaction
		{
			get {
				if ( gxTv_SdtSDT_Tile_Tileaction == null )
				{
					gxTv_SdtSDT_Tile_Tileaction = new GeneXus.Programs.SdtSDT_TileAction(context);
				}
				return gxTv_SdtSDT_Tile_Tileaction; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileaction = value;
				SetDirty("Tileaction");
			}
		}
		public void gxTv_SdtSDT_Tile_Tileaction_SetNull()
		{
			gxTv_SdtSDT_Tile_Tileaction_N = true;
			gxTv_SdtSDT_Tile_Tileaction = null;
		}

		public bool gxTv_SdtSDT_Tile_Tileaction_IsNull()
		{
			return gxTv_SdtSDT_Tile_Tileaction == null;
		}
		public bool ShouldSerializegxTpr_Tileaction_Json()
		{
			return gxTv_SdtSDT_Tile_Tileaction != null;

		}

		[SoapElement(ElementName="TileSize")]
		[XmlElement(ElementName="TileSize")]
		public string gxTpr_Tilesize_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_Tile_Tilesize, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_Tile_Tilesize = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tilesize
		{
			get {
				return gxTv_SdtSDT_Tile_Tilesize; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilesize = value;
				SetDirty("Tilesize");
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
			gxTv_SdtSDT_Tile_Tileid = "";
			gxTv_SdtSDT_Tile_Tilename = "";
			gxTv_SdtSDT_Tile_Tiletext = "";
			gxTv_SdtSDT_Tile_Tilecolor = "";
			gxTv_SdtSDT_Tile_Tilealignment = "";
			gxTv_SdtSDT_Tile_Tileicon = "";
			gxTv_SdtSDT_Tile_Tilebgcolor = "";
			gxTv_SdtSDT_Tile_Tilebgimageurl = "";


			gxTv_SdtSDT_Tile_Tileaction_N = true;


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_Tile_Tileid;
		 

		protected string gxTv_SdtSDT_Tile_Tilename;
		 

		protected string gxTv_SdtSDT_Tile_Tiletext;
		 

		protected string gxTv_SdtSDT_Tile_Tilecolor;
		 

		protected string gxTv_SdtSDT_Tile_Tilealignment;
		 

		protected string gxTv_SdtSDT_Tile_Tileicon;
		 

		protected string gxTv_SdtSDT_Tile_Tilebgcolor;
		 

		protected string gxTv_SdtSDT_Tile_Tilebgimageurl;
		 

		protected short gxTv_SdtSDT_Tile_Tilebgimageopacity;
		 

		protected GeneXus.Programs.SdtSDT_TileAction gxTv_SdtSDT_Tile_Tileaction = null;
		protected bool gxTv_SdtSDT_Tile_Tileaction_N;
		 

		protected decimal gxTv_SdtSDT_Tile_Tilesize;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Tile", Namespace="Comforta_version21")]
	public class SdtSDT_Tile_RESTInterface : GxGenericCollectionItem<SdtSDT_Tile>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Tile_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Tile_RESTInterface( SdtSDT_Tile psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TileId", Order=0)]
		public  string gxTpr_Tileid
		{
			get { 
				return sdt.gxTpr_Tileid;

			}
			set { 
				 sdt.gxTpr_Tileid = value;
			}
		}

		[DataMember(Name="TileName", Order=1)]
		public  string gxTpr_Tilename
		{
			get { 
				return sdt.gxTpr_Tilename;

			}
			set { 
				 sdt.gxTpr_Tilename = value;
			}
		}

		[DataMember(Name="TileText", Order=2)]
		public  string gxTpr_Tiletext
		{
			get { 
				return sdt.gxTpr_Tiletext;

			}
			set { 
				 sdt.gxTpr_Tiletext = value;
			}
		}

		[DataMember(Name="TileColor", Order=3)]
		public  string gxTpr_Tilecolor
		{
			get { 
				return sdt.gxTpr_Tilecolor;

			}
			set { 
				 sdt.gxTpr_Tilecolor = value;
			}
		}

		[DataMember(Name="TileAlignment", Order=4)]
		public  string gxTpr_Tilealignment
		{
			get { 
				return sdt.gxTpr_Tilealignment;

			}
			set { 
				 sdt.gxTpr_Tilealignment = value;
			}
		}

		[DataMember(Name="TileIcon", Order=5)]
		public  string gxTpr_Tileicon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tileicon);

			}
			set { 
				 sdt.gxTpr_Tileicon = value;
			}
		}

		[DataMember(Name="TileBGColor", Order=6)]
		public  string gxTpr_Tilebgcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tilebgcolor);

			}
			set { 
				 sdt.gxTpr_Tilebgcolor = value;
			}
		}

		[DataMember(Name="TileBGImageUrl", Order=7)]
		public  string gxTpr_Tilebgimageurl
		{
			get { 
				return sdt.gxTpr_Tilebgimageurl;

			}
			set { 
				 sdt.gxTpr_Tilebgimageurl = value;
			}
		}

		[DataMember(Name="TileBGImageOpacity", Order=8)]
		public short gxTpr_Tilebgimageopacity
		{
			get { 
				return sdt.gxTpr_Tilebgimageopacity;

			}
			set { 
				sdt.gxTpr_Tilebgimageopacity = value;
			}
		}

		[DataMember(Name="TileAction", Order=9, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_TileAction_RESTInterface gxTpr_Tileaction
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Tileaction_Json())
					return new GeneXus.Programs.SdtSDT_TileAction_RESTInterface(sdt.gxTpr_Tileaction);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Tileaction = value.sdt;
			}
		}

		[DataMember(Name="TileSize", Order=10)]
		public decimal gxTpr_Tilesize
		{
			get { 
				return sdt.gxTpr_Tilesize;

			}
			set { 
				sdt.gxTpr_Tilesize = value;
			}
		}


		#endregion

		public SdtSDT_Tile sdt
		{
			get { 
				return (SdtSDT_Tile)Sdt;
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
				sdt = new SdtSDT_Tile() ;
			}
		}
	}
	#endregion
}