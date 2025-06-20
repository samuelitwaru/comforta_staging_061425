/*
				   File: type_SdtSDT_OneSignalCustomBody
			Description: SDT_OneSignalCustomBody
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
	[XmlRoot(ElementName="SDT_OneSignalCustomBody")]
	[XmlType(TypeName="SDT_OneSignalCustomBody" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomBody : GxUserType
	{
		public SdtSDT_OneSignalCustomBody( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalCustomBody_App_id = "";

		}

		public SdtSDT_OneSignalCustomBody(IGxContext context)
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
			AddObjectProperty("app_id", gxTpr_App_id, false);

			if (gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids != null)
			{
				AddObjectProperty("include_player_ids", gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomBody_Headings != null)
			{
				AddObjectProperty("headings", gxTv_SdtSDT_OneSignalCustomBody_Headings, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomBody_Contents != null)
			{
				AddObjectProperty("contents", gxTv_SdtSDT_OneSignalCustomBody_Contents, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomBody_Data != null)
			{
				AddObjectProperty("data", gxTv_SdtSDT_OneSignalCustomBody_Data, false);
			}

			AddObjectProperty("content_available", gxTpr_Content_available, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="app_id")]
		[XmlElement(ElementName="app_id")]
		public string gxTpr_App_id
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomBody_App_id; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_App_id = value;
				SetDirty("App_id");
			}
		}




		[SoapElement(ElementName="include_player_ids" )]
		[XmlArray(ElementName="include_player_ids"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Include_player_ids_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids == null )
				{
					gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_N = false;
				gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Include_player_ids
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids == null )
				{
					gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids = new GxSimpleCollection<string>();
				}
				gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_N = false;
				return gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids ;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_N = false;
				gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids = value;
				SetDirty("Include_player_ids");
			}
		}

		public void gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_N = true;
			gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids == null;
		}
		public bool ShouldSerializegxTpr_Include_player_ids_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids != null && gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids.Count > 0;

		}

		[SoapElement(ElementName="headings" )]
		[XmlElement(ElementName="headings" )]
		public SdtSDT_OneSignalCustomBody_headings gxTpr_Headings
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomBody_Headings == null )
				{
					gxTv_SdtSDT_OneSignalCustomBody_Headings = new SdtSDT_OneSignalCustomBody_headings(context);
				}
				gxTv_SdtSDT_OneSignalCustomBody_Headings_N = false;
				return gxTv_SdtSDT_OneSignalCustomBody_Headings;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_Headings_N = false;
				gxTv_SdtSDT_OneSignalCustomBody_Headings = value;
				SetDirty("Headings");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomBody_Headings_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomBody_Headings_N = true;
			gxTv_SdtSDT_OneSignalCustomBody_Headings = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomBody_Headings_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_Headings == null;
		}
		public bool ShouldSerializegxTpr_Headings_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomBody_Headings != null && gxTv_SdtSDT_OneSignalCustomBody_Headings.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="contents" )]
		[XmlElement(ElementName="contents" )]
		public SdtSDT_OneSignalCustomBody_contents gxTpr_Contents
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomBody_Contents == null )
				{
					gxTv_SdtSDT_OneSignalCustomBody_Contents = new SdtSDT_OneSignalCustomBody_contents(context);
				}
				gxTv_SdtSDT_OneSignalCustomBody_Contents_N = false;
				return gxTv_SdtSDT_OneSignalCustomBody_Contents;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_Contents_N = false;
				gxTv_SdtSDT_OneSignalCustomBody_Contents = value;
				SetDirty("Contents");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomBody_Contents_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomBody_Contents_N = true;
			gxTv_SdtSDT_OneSignalCustomBody_Contents = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomBody_Contents_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_Contents == null;
		}
		public bool ShouldSerializegxTpr_Contents_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomBody_Contents != null && gxTv_SdtSDT_OneSignalCustomBody_Contents.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="data")]
		[XmlElement(ElementName="data")]
		public GeneXus.Programs.SdtSDT_OneSignalCustomData gxTpr_Data
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomBody_Data == null )
				{
					gxTv_SdtSDT_OneSignalCustomBody_Data = new GeneXus.Programs.SdtSDT_OneSignalCustomData(context);
				}
				return gxTv_SdtSDT_OneSignalCustomBody_Data; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_Data = value;
				SetDirty("Data");
			}
		}
		public void gxTv_SdtSDT_OneSignalCustomBody_Data_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomBody_Data_N = true;
			gxTv_SdtSDT_OneSignalCustomBody_Data = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomBody_Data_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_Data == null;
		}
		public bool ShouldSerializegxTpr_Data_Json()
		{
			return gxTv_SdtSDT_OneSignalCustomBody_Data != null;

		}


		[SoapElement(ElementName="content_available")]
		[XmlElement(ElementName="content_available")]
		public bool gxTpr_Content_available
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomBody_Content_available; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomBody_Content_available = value;
				SetDirty("Content_available");
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
			gxTv_SdtSDT_OneSignalCustomBody_App_id = "";

			gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_N = true;


			gxTv_SdtSDT_OneSignalCustomBody_Headings_N = true;


			gxTv_SdtSDT_OneSignalCustomBody_Contents_N = true;


			gxTv_SdtSDT_OneSignalCustomBody_Data_N = true;


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalCustomBody_App_id;
		 
		protected bool gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids_N;
		protected GxSimpleCollection<string> gxTv_SdtSDT_OneSignalCustomBody_Include_player_ids = null;  
		protected bool gxTv_SdtSDT_OneSignalCustomBody_Headings_N;
		protected SdtSDT_OneSignalCustomBody_headings gxTv_SdtSDT_OneSignalCustomBody_Headings = null; 

		protected bool gxTv_SdtSDT_OneSignalCustomBody_Contents_N;
		protected SdtSDT_OneSignalCustomBody_contents gxTv_SdtSDT_OneSignalCustomBody_Contents = null; 


		protected GeneXus.Programs.SdtSDT_OneSignalCustomData gxTv_SdtSDT_OneSignalCustomBody_Data = null;
		protected bool gxTv_SdtSDT_OneSignalCustomBody_Data_N;
		 

		protected bool gxTv_SdtSDT_OneSignalCustomBody_Content_available;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomBody", Namespace="Comforta_version2")]
	public class SdtSDT_OneSignalCustomBody_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomBody>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomBody_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomBody_RESTInterface( SdtSDT_OneSignalCustomBody psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="app_id", Order=0)]
		public  string gxTpr_App_id
		{
			get { 
				return sdt.gxTpr_App_id;

			}
			set { 
				 sdt.gxTpr_App_id = value;
			}
		}

		[DataMember(Name="include_player_ids", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Include_player_ids
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Include_player_ids_GxSimpleCollection_Json())
					return sdt.gxTpr_Include_player_ids;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Include_player_ids = value ;
			}
		}

		[DataMember(Name="headings", Order=2, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomBody_headings_RESTInterface gxTpr_Headings
		{
			get {
				if (sdt.ShouldSerializegxTpr_Headings_Json())
					return new SdtSDT_OneSignalCustomBody_headings_RESTInterface(sdt.gxTpr_Headings);
				else
					return null;

			}

			set {
				sdt.gxTpr_Headings = value.sdt;
			}

		}

		[DataMember(Name="contents", Order=3, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomBody_contents_RESTInterface gxTpr_Contents
		{
			get {
				if (sdt.ShouldSerializegxTpr_Contents_Json())
					return new SdtSDT_OneSignalCustomBody_contents_RESTInterface(sdt.gxTpr_Contents);
				else
					return null;

			}

			set {
				sdt.gxTpr_Contents = value.sdt;
			}

		}

		[DataMember(Name="data", Order=4, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_OneSignalCustomData_RESTInterface gxTpr_Data
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Data_Json())
					return new GeneXus.Programs.SdtSDT_OneSignalCustomData_RESTInterface(sdt.gxTpr_Data);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Data = value.sdt;
			}
		}

		[DataMember(Name="content_available", Order=5)]
		public bool gxTpr_Content_available
		{
			get { 
				return sdt.gxTpr_Content_available;

			}
			set { 
				sdt.gxTpr_Content_available = value;
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomBody sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomBody)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomBody() ;
			}
		}
	}
	#endregion
}