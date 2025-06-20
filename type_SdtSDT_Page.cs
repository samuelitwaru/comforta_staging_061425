/*
				   File: type_SdtSDT_Page
			Description: SDT_Page
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
	[XmlRoot(ElementName="SDT_Page")]
	[XmlType(TypeName="SDT_Page" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Page : GxUserType
	{
		public SdtSDT_Page( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Page_Pagename = "";

			gxTv_SdtSDT_Page_Pagegjsjson = "";

			gxTv_SdtSDT_Page_Pagegjshtml = "";

			gxTv_SdtSDT_Page_Pagejsoncontent = "";

		}

		public SdtSDT_Page(IGxContext context)
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
			AddObjectProperty("PageId", gxTpr_Pageid, false);


			AddObjectProperty("PageName", gxTpr_Pagename, false);

			if (gxTv_SdtSDT_Page_Theme != null)
			{
				AddObjectProperty("Theme", gxTv_SdtSDT_Page_Theme, false);
			}

			AddObjectProperty("PageIsPublished", gxTpr_Pageispublished, false);


			AddObjectProperty("PageIsContentPage", gxTpr_Pageiscontentpage, false);


			AddObjectProperty("PageIsPredefined", gxTpr_Pageispredefined, false);


			AddObjectProperty("PageGJSJson", gxTpr_Pagegjsjson, false);


			AddObjectProperty("PageGJSHtml", gxTpr_Pagegjshtml, false);


			AddObjectProperty("PageJsonContent", gxTpr_Pagejsoncontent, false);


			AddObjectProperty("PageIsDynamicForm", gxTpr_Pageisdynamicform, false);


			AddObjectProperty("PageIsWebLinkPage", gxTpr_Pageisweblinkpage, false);


			AddObjectProperty("WWPFormId", gxTpr_Wwpformid, false);

			if (gxTv_SdtSDT_Page_Pagechildren != null)
			{
				AddObjectProperty("PageChildren", gxTv_SdtSDT_Page_Pagechildren, false);
			}

			AddObjectProperty("LocationId", gxTpr_Locationid, false);

			if (gxTv_SdtSDT_Page_Row != null)
			{
				AddObjectProperty("Row", gxTv_SdtSDT_Page_Row, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PageId")]
		[XmlElement(ElementName="PageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_Page_Pageid; 
			}
			set {
				gxTv_SdtSDT_Page_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_Page_Pagename; 
			}
			set {
				gxTv_SdtSDT_Page_Pagename = value;
				SetDirty("Pagename");
			}
		}



		[SoapElement(ElementName="Theme")]
		[XmlElement(ElementName="Theme")]
		public GeneXus.Programs.SdtSDT_Theme gxTpr_Theme
		{
			get {
				if ( gxTv_SdtSDT_Page_Theme == null )
				{
					gxTv_SdtSDT_Page_Theme = new GeneXus.Programs.SdtSDT_Theme(context);
				}
				return gxTv_SdtSDT_Page_Theme; 
			}
			set {
				gxTv_SdtSDT_Page_Theme = value;
				SetDirty("Theme");
			}
		}
		public void gxTv_SdtSDT_Page_Theme_SetNull()
		{
			gxTv_SdtSDT_Page_Theme_N = true;
			gxTv_SdtSDT_Page_Theme = null;
		}

		public bool gxTv_SdtSDT_Page_Theme_IsNull()
		{
			return gxTv_SdtSDT_Page_Theme == null;
		}
		public bool ShouldSerializegxTpr_Theme_Json()
		{
			return gxTv_SdtSDT_Page_Theme != null;

		}


		[SoapElement(ElementName="PageIsPublished")]
		[XmlElement(ElementName="PageIsPublished")]
		public bool gxTpr_Pageispublished
		{
			get {
				return gxTv_SdtSDT_Page_Pageispublished; 
			}
			set {
				gxTv_SdtSDT_Page_Pageispublished = value;
				SetDirty("Pageispublished");
			}
		}




		[SoapElement(ElementName="PageIsContentPage")]
		[XmlElement(ElementName="PageIsContentPage")]
		public bool gxTpr_Pageiscontentpage
		{
			get {
				return gxTv_SdtSDT_Page_Pageiscontentpage; 
			}
			set {
				gxTv_SdtSDT_Page_Pageiscontentpage = value;
				SetDirty("Pageiscontentpage");
			}
		}




		[SoapElement(ElementName="PageIsPredefined")]
		[XmlElement(ElementName="PageIsPredefined")]
		public bool gxTpr_Pageispredefined
		{
			get {
				return gxTv_SdtSDT_Page_Pageispredefined; 
			}
			set {
				gxTv_SdtSDT_Page_Pageispredefined = value;
				SetDirty("Pageispredefined");
			}
		}




		[SoapElement(ElementName="PageGJSJson")]
		[XmlElement(ElementName="PageGJSJson")]
		public string gxTpr_Pagegjsjson
		{
			get {
				return gxTv_SdtSDT_Page_Pagegjsjson; 
			}
			set {
				gxTv_SdtSDT_Page_Pagegjsjson = value;
				SetDirty("Pagegjsjson");
			}
		}




		[SoapElement(ElementName="PageGJSHtml")]
		[XmlElement(ElementName="PageGJSHtml")]
		public string gxTpr_Pagegjshtml
		{
			get {
				return gxTv_SdtSDT_Page_Pagegjshtml; 
			}
			set {
				gxTv_SdtSDT_Page_Pagegjshtml = value;
				SetDirty("Pagegjshtml");
			}
		}




		[SoapElement(ElementName="PageJsonContent")]
		[XmlElement(ElementName="PageJsonContent")]
		public string gxTpr_Pagejsoncontent
		{
			get {
				return gxTv_SdtSDT_Page_Pagejsoncontent; 
			}
			set {
				gxTv_SdtSDT_Page_Pagejsoncontent = value;
				SetDirty("Pagejsoncontent");
			}
		}




		[SoapElement(ElementName="PageIsDynamicForm")]
		[XmlElement(ElementName="PageIsDynamicForm")]
		public bool gxTpr_Pageisdynamicform
		{
			get {
				return gxTv_SdtSDT_Page_Pageisdynamicform; 
			}
			set {
				gxTv_SdtSDT_Page_Pageisdynamicform = value;
				SetDirty("Pageisdynamicform");
			}
		}




		[SoapElement(ElementName="PageIsWebLinkPage")]
		[XmlElement(ElementName="PageIsWebLinkPage")]
		public bool gxTpr_Pageisweblinkpage
		{
			get {
				return gxTv_SdtSDT_Page_Pageisweblinkpage; 
			}
			set {
				gxTv_SdtSDT_Page_Pageisweblinkpage = value;
				SetDirty("Pageisweblinkpage");
			}
		}




		[SoapElement(ElementName="WWPFormId")]
		[XmlElement(ElementName="WWPFormId")]
		public short gxTpr_Wwpformid
		{
			get {
				return gxTv_SdtSDT_Page_Wwpformid; 
			}
			set {
				gxTv_SdtSDT_Page_Wwpformid = value;
				SetDirty("Wwpformid");
			}
		}




		[SoapElement(ElementName="PageChildren" )]
		[XmlArray(ElementName="PageChildren"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_PageChildren> gxTpr_Pagechildren_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_Page_Pagechildren == null )
				{
					gxTv_SdtSDT_Page_Pagechildren = new GXBaseCollection<GeneXus.Programs.SdtSDT_PageChildren>( context, "SDT_PageChildren", "");
				}
				return gxTv_SdtSDT_Page_Pagechildren;
			}
			set {
				gxTv_SdtSDT_Page_Pagechildren_N = false;
				gxTv_SdtSDT_Page_Pagechildren = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_PageChildren> gxTpr_Pagechildren
		{
			get {
				if ( gxTv_SdtSDT_Page_Pagechildren == null )
				{
					gxTv_SdtSDT_Page_Pagechildren = new GXBaseCollection<GeneXus.Programs.SdtSDT_PageChildren>( context, "SDT_PageChildren", "");
				}
				gxTv_SdtSDT_Page_Pagechildren_N = false;
				return gxTv_SdtSDT_Page_Pagechildren ;
			}
			set {
				gxTv_SdtSDT_Page_Pagechildren_N = false;
				gxTv_SdtSDT_Page_Pagechildren = value;
				SetDirty("Pagechildren");
			}
		}

		public void gxTv_SdtSDT_Page_Pagechildren_SetNull()
		{
			gxTv_SdtSDT_Page_Pagechildren_N = true;
			gxTv_SdtSDT_Page_Pagechildren = null;
		}

		public bool gxTv_SdtSDT_Page_Pagechildren_IsNull()
		{
			return gxTv_SdtSDT_Page_Pagechildren == null;
		}
		public bool ShouldSerializegxTpr_Pagechildren_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_Page_Pagechildren != null && gxTv_SdtSDT_Page_Pagechildren.Count > 0;

		}


		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_Page_Locationid; 
			}
			set {
				gxTv_SdtSDT_Page_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="Row" )]
		[XmlArray(ElementName="Row"  )]
		[XmlArrayItemAttribute(ElementName="RowItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTpr_Row_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_Page_Row == null )
				{
					gxTv_SdtSDT_Page_Row = new GXBaseCollection<GeneXus.Programs.SdtSDT_Row>( context, "SDT_Row", "");
				}
				return gxTv_SdtSDT_Page_Row;
			}
			set {
				gxTv_SdtSDT_Page_Row_N = false;
				gxTv_SdtSDT_Page_Row = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTpr_Row
		{
			get {
				if ( gxTv_SdtSDT_Page_Row == null )
				{
					gxTv_SdtSDT_Page_Row = new GXBaseCollection<GeneXus.Programs.SdtSDT_Row>( context, "SDT_Row", "");
				}
				gxTv_SdtSDT_Page_Row_N = false;
				return gxTv_SdtSDT_Page_Row ;
			}
			set {
				gxTv_SdtSDT_Page_Row_N = false;
				gxTv_SdtSDT_Page_Row = value;
				SetDirty("Row");
			}
		}

		public void gxTv_SdtSDT_Page_Row_SetNull()
		{
			gxTv_SdtSDT_Page_Row_N = true;
			gxTv_SdtSDT_Page_Row = null;
		}

		public bool gxTv_SdtSDT_Page_Row_IsNull()
		{
			return gxTv_SdtSDT_Page_Row == null;
		}
		public bool ShouldSerializegxTpr_Row_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_Page_Row != null && gxTv_SdtSDT_Page_Row.Count > 0;

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
			gxTv_SdtSDT_Page_Pagename = "";

			gxTv_SdtSDT_Page_Theme_N = true;

			gxTv_SdtSDT_Page_Pageispublished = false;
			gxTv_SdtSDT_Page_Pageiscontentpage = false;
			gxTv_SdtSDT_Page_Pageispredefined = false;
			gxTv_SdtSDT_Page_Pagegjsjson = "";
			gxTv_SdtSDT_Page_Pagegjshtml = "";
			gxTv_SdtSDT_Page_Pagejsoncontent = "";
			gxTv_SdtSDT_Page_Pageisdynamicform = false;



			gxTv_SdtSDT_Page_Pagechildren_N = true;



			gxTv_SdtSDT_Page_Row_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Page_Pageid;
		 

		protected string gxTv_SdtSDT_Page_Pagename;
		 

		protected GeneXus.Programs.SdtSDT_Theme gxTv_SdtSDT_Page_Theme = null;
		protected bool gxTv_SdtSDT_Page_Theme_N;
		 

		protected bool gxTv_SdtSDT_Page_Pageispublished;
		 

		protected bool gxTv_SdtSDT_Page_Pageiscontentpage;
		 

		protected bool gxTv_SdtSDT_Page_Pageispredefined;
		 

		protected string gxTv_SdtSDT_Page_Pagegjsjson;
		 

		protected string gxTv_SdtSDT_Page_Pagegjshtml;
		 

		protected string gxTv_SdtSDT_Page_Pagejsoncontent;
		 

		protected bool gxTv_SdtSDT_Page_Pageisdynamicform;
		 

		protected bool gxTv_SdtSDT_Page_Pageisweblinkpage;
		 

		protected short gxTv_SdtSDT_Page_Wwpformid;
		 
		protected bool gxTv_SdtSDT_Page_Pagechildren_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_PageChildren> gxTv_SdtSDT_Page_Pagechildren = null;  

		protected Guid gxTv_SdtSDT_Page_Locationid;
		 
		protected bool gxTv_SdtSDT_Page_Row_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTv_SdtSDT_Page_Row = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Page", Namespace="Comforta_version2")]
	public class SdtSDT_Page_RESTInterface : GxGenericCollectionItem<SdtSDT_Page>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Page_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Page_RESTInterface( SdtSDT_Page psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PageId", Order=0)]
		public Guid gxTpr_Pageid
		{
			get { 
				return sdt.gxTpr_Pageid;

			}
			set { 
				sdt.gxTpr_Pageid = value;
			}
		}

		[DataMember(Name="PageName", Order=1)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}

		[DataMember(Name="Theme", Order=2, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_Theme_RESTInterface gxTpr_Theme
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Theme_Json())
					return new GeneXus.Programs.SdtSDT_Theme_RESTInterface(sdt.gxTpr_Theme);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Theme = value.sdt;
			}
		}

		[DataMember(Name="PageIsPublished", Order=3)]
		public bool gxTpr_Pageispublished
		{
			get { 
				return sdt.gxTpr_Pageispublished;

			}
			set { 
				sdt.gxTpr_Pageispublished = value;
			}
		}

		[DataMember(Name="PageIsContentPage", Order=4)]
		public bool gxTpr_Pageiscontentpage
		{
			get { 
				return sdt.gxTpr_Pageiscontentpage;

			}
			set { 
				sdt.gxTpr_Pageiscontentpage = value;
			}
		}

		[DataMember(Name="PageIsPredefined", Order=5)]
		public bool gxTpr_Pageispredefined
		{
			get { 
				return sdt.gxTpr_Pageispredefined;

			}
			set { 
				sdt.gxTpr_Pageispredefined = value;
			}
		}

		[DataMember(Name="PageGJSJson", Order=6)]
		public  string gxTpr_Pagegjsjson
		{
			get { 
				return sdt.gxTpr_Pagegjsjson;

			}
			set { 
				 sdt.gxTpr_Pagegjsjson = value;
			}
		}

		[DataMember(Name="PageGJSHtml", Order=7)]
		public  string gxTpr_Pagegjshtml
		{
			get { 
				return sdt.gxTpr_Pagegjshtml;

			}
			set { 
				 sdt.gxTpr_Pagegjshtml = value;
			}
		}

		[DataMember(Name="PageJsonContent", Order=8)]
		public  string gxTpr_Pagejsoncontent
		{
			get { 
				return sdt.gxTpr_Pagejsoncontent;

			}
			set { 
				 sdt.gxTpr_Pagejsoncontent = value;
			}
		}

		[DataMember(Name="PageIsDynamicForm", Order=9)]
		public bool gxTpr_Pageisdynamicform
		{
			get { 
				return sdt.gxTpr_Pageisdynamicform;

			}
			set { 
				sdt.gxTpr_Pageisdynamicform = value;
			}
		}

		[DataMember(Name="PageIsWebLinkPage", Order=10)]
		public bool gxTpr_Pageisweblinkpage
		{
			get { 
				return sdt.gxTpr_Pageisweblinkpage;

			}
			set { 
				sdt.gxTpr_Pageisweblinkpage = value;
			}
		}

		[DataMember(Name="WWPFormId", Order=11)]
		public short gxTpr_Wwpformid
		{
			get { 
				return sdt.gxTpr_Wwpformid;

			}
			set { 
				sdt.gxTpr_Wwpformid = value;
			}
		}

		[DataMember(Name="PageChildren", Order=12, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_PageChildren_RESTInterface> gxTpr_Pagechildren
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Pagechildren_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_PageChildren_RESTInterface>(sdt.gxTpr_Pagechildren);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Pagechildren);
			}
		}

		[DataMember(Name="LocationId", Order=13)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="Row", Order=14, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Row_RESTInterface> gxTpr_Row
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Row_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Row_RESTInterface>(sdt.gxTpr_Row);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Row);
			}
		}


		#endregion

		public SdtSDT_Page sdt
		{
			get { 
				return (SdtSDT_Page)Sdt;
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
				sdt = new SdtSDT_Page() ;
			}
		}
	}
	#endregion
}