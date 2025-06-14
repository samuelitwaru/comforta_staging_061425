/*
				   File: type_SdtSDT_InfoTile_SDT_InfoTileItem_Action
			Description: Action
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
	[XmlRoot(ElementName="SDT_InfoTile.SDT_InfoTileItem.Action")]
	[XmlType(TypeName="SDT_InfoTile.SDT_InfoTileItem.Action" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_InfoTile_SDT_InfoTileItem_Action : GxUserType
	{
		public SdtSDT_InfoTile_SDT_InfoTileItem_Action( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecttype = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objectid = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecturl = "";

		}

		public SdtSDT_InfoTile_SDT_InfoTileItem_Action(IGxContext context)
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
			AddObjectProperty("ObjectType", gxTpr_Objecttype, false);


			AddObjectProperty("ObjectId", gxTpr_Objectid, false);


			AddObjectProperty("ObjectUrl", gxTpr_Objecturl, false);


			AddObjectProperty("FormId", gxTpr_Formid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ObjectType")]
		[XmlElement(ElementName="ObjectType")]
		public string gxTpr_Objecttype
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecttype; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecttype = value;
				SetDirty("Objecttype");
			}
		}




		[SoapElement(ElementName="ObjectId")]
		[XmlElement(ElementName="ObjectId")]
		public string gxTpr_Objectid
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objectid; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objectid = value;
				SetDirty("Objectid");
			}
		}




		[SoapElement(ElementName="ObjectUrl")]
		[XmlElement(ElementName="ObjectUrl")]
		public string gxTpr_Objecturl
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecturl; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecturl = value;
				SetDirty("Objecturl");
			}
		}




		[SoapElement(ElementName="FormId")]
		[XmlElement(ElementName="FormId")]
		public short gxTpr_Formid
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Formid; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Formid = value;
				SetDirty("Formid");
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
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecttype = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objectid = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecturl = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecttype;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objectid;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Objecturl;
		 

		protected short gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_Formid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_InfoTile.SDT_InfoTileItem.Action", Namespace="Comforta_version21")]
	public class SdtSDT_InfoTile_SDT_InfoTileItem_Action_RESTInterface : GxGenericCollectionItem<SdtSDT_InfoTile_SDT_InfoTileItem_Action>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_InfoTile_SDT_InfoTileItem_Action_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_InfoTile_SDT_InfoTileItem_Action_RESTInterface( SdtSDT_InfoTile_SDT_InfoTileItem_Action psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ObjectType", Order=0)]
		public  string gxTpr_Objecttype
		{
			get { 
				return sdt.gxTpr_Objecttype;

			}
			set { 
				 sdt.gxTpr_Objecttype = value;
			}
		}

		[DataMember(Name="ObjectId", Order=1)]
		public  string gxTpr_Objectid
		{
			get { 
				return sdt.gxTpr_Objectid;

			}
			set { 
				 sdt.gxTpr_Objectid = value;
			}
		}

		[DataMember(Name="ObjectUrl", Order=2)]
		public  string gxTpr_Objecturl
		{
			get { 
				return sdt.gxTpr_Objecturl;

			}
			set { 
				 sdt.gxTpr_Objecturl = value;
			}
		}

		[DataMember(Name="FormId", Order=3)]
		public short gxTpr_Formid
		{
			get { 
				return sdt.gxTpr_Formid;

			}
			set { 
				sdt.gxTpr_Formid = value;
			}
		}


		#endregion

		public SdtSDT_InfoTile_SDT_InfoTileItem_Action sdt
		{
			get { 
				return (SdtSDT_InfoTile_SDT_InfoTileItem_Action)Sdt;
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
				sdt = new SdtSDT_InfoTile_SDT_InfoTileItem_Action() ;
			}
		}
	}
	#endregion
}