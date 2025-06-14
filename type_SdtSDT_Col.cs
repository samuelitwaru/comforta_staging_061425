/*
				   File: type_SdtSDT_Col
			Description: SDT_Col
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
	[XmlRoot(ElementName="SDT_Col")]
	[XmlType(TypeName="SDT_Col" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_Col : GxUserType
	{
		public SdtSDT_Col( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_Col(IGxContext context)
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
			if (gxTv_SdtSDT_Col_Tile != null)
			{
				AddObjectProperty("Tile", gxTv_SdtSDT_Col_Tile, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Tile")]
		[XmlElement(ElementName="Tile")]
		public GeneXus.Programs.SdtSDT_Tile gxTpr_Tile
		{
			get {
				if ( gxTv_SdtSDT_Col_Tile == null )
				{
					gxTv_SdtSDT_Col_Tile = new GeneXus.Programs.SdtSDT_Tile(context);
				}
				return gxTv_SdtSDT_Col_Tile; 
			}
			set {
				gxTv_SdtSDT_Col_Tile = value;
				SetDirty("Tile");
			}
		}
		public void gxTv_SdtSDT_Col_Tile_SetNull()
		{
			gxTv_SdtSDT_Col_Tile_N = true;
			gxTv_SdtSDT_Col_Tile = null;
		}

		public bool gxTv_SdtSDT_Col_Tile_IsNull()
		{
			return gxTv_SdtSDT_Col_Tile == null;
		}
		public bool ShouldSerializegxTpr_Tile_Json()
		{
			return gxTv_SdtSDT_Col_Tile != null;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Tile_Json()||  
				false);
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
			gxTv_SdtSDT_Col_Tile_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected GeneXus.Programs.SdtSDT_Tile gxTv_SdtSDT_Col_Tile = null;
		protected bool gxTv_SdtSDT_Col_Tile_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Col", Namespace="Comforta_version21")]
	public class SdtSDT_Col_RESTInterface : GxGenericCollectionItem<SdtSDT_Col>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Col_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Col_RESTInterface( SdtSDT_Col psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Tile", Order=0, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_Tile_RESTInterface gxTpr_Tile
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Tile_Json())
					return new GeneXus.Programs.SdtSDT_Tile_RESTInterface(sdt.gxTpr_Tile);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Tile = value.sdt;
			}
		}


		#endregion

		public SdtSDT_Col sdt
		{
			get { 
				return (SdtSDT_Col)Sdt;
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
				sdt = new SdtSDT_Col() ;
			}
		}
	}
	#endregion
}