/*
				   File: type_SdtSDT_PublishPage
			Description: SDT_PublishPage
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
	[XmlRoot(ElementName="SDT_PublishPage")]
	[XmlType(TypeName="SDT_PublishPage" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_PublishPage : GxUserType
	{
		public SdtSDT_PublishPage( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PublishPage_Pagename = "";

			gxTv_SdtSDT_PublishPage_Pagegjsjson = "";

			gxTv_SdtSDT_PublishPage_Pagegjshtml = "";

			gxTv_SdtSDT_PublishPage_Pagejsoncontent = "";

		}

		public SdtSDT_PublishPage(IGxContext context)
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


			AddObjectProperty("PageIsPublished", gxTpr_Pageispublished, false);


			AddObjectProperty("PageIsContentPage", gxTpr_Pageiscontentpage, false);


			AddObjectProperty("PageIsPredefined", gxTpr_Pageispredefined, false);


			AddObjectProperty("PageGJSJson", gxTpr_Pagegjsjson, false);


			AddObjectProperty("PageGJSHtml", gxTpr_Pagegjshtml, false);


			AddObjectProperty("PageJsonContent", gxTpr_Pagejsoncontent, false);

			if (gxTv_SdtSDT_PublishPage_Sdt_page != null)
			{
				AddObjectProperty("SDT_Page", gxTv_SdtSDT_PublishPage_Sdt_page, false);
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
				return gxTv_SdtSDT_PublishPage_Pageid; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_PublishPage_Pagename; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="PageIsPublished")]
		[XmlElement(ElementName="PageIsPublished")]
		public bool gxTpr_Pageispublished
		{
			get {
				return gxTv_SdtSDT_PublishPage_Pageispublished; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pageispublished = value;
				SetDirty("Pageispublished");
			}
		}




		[SoapElement(ElementName="PageIsContentPage")]
		[XmlElement(ElementName="PageIsContentPage")]
		public bool gxTpr_Pageiscontentpage
		{
			get {
				return gxTv_SdtSDT_PublishPage_Pageiscontentpage; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pageiscontentpage = value;
				SetDirty("Pageiscontentpage");
			}
		}




		[SoapElement(ElementName="PageIsPredefined")]
		[XmlElement(ElementName="PageIsPredefined")]
		public bool gxTpr_Pageispredefined
		{
			get {
				return gxTv_SdtSDT_PublishPage_Pageispredefined; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pageispredefined = value;
				SetDirty("Pageispredefined");
			}
		}




		[SoapElement(ElementName="PageGJSJson")]
		[XmlElement(ElementName="PageGJSJson")]
		public string gxTpr_Pagegjsjson
		{
			get {
				return gxTv_SdtSDT_PublishPage_Pagegjsjson; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pagegjsjson = value;
				SetDirty("Pagegjsjson");
			}
		}




		[SoapElement(ElementName="PageGJSHtml")]
		[XmlElement(ElementName="PageGJSHtml")]
		public string gxTpr_Pagegjshtml
		{
			get {
				return gxTv_SdtSDT_PublishPage_Pagegjshtml; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pagegjshtml = value;
				SetDirty("Pagegjshtml");
			}
		}




		[SoapElement(ElementName="PageJsonContent")]
		[XmlElement(ElementName="PageJsonContent")]
		public string gxTpr_Pagejsoncontent
		{
			get {
				return gxTv_SdtSDT_PublishPage_Pagejsoncontent; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Pagejsoncontent = value;
				SetDirty("Pagejsoncontent");
			}
		}



		[SoapElement(ElementName="SDT_Page")]
		[XmlElement(ElementName="SDT_Page")]
		public GeneXus.Programs.SdtSDT_Page gxTpr_Sdt_page
		{
			get {
				if ( gxTv_SdtSDT_PublishPage_Sdt_page == null )
				{
					gxTv_SdtSDT_PublishPage_Sdt_page = new GeneXus.Programs.SdtSDT_Page(context);
				}
				return gxTv_SdtSDT_PublishPage_Sdt_page; 
			}
			set {
				gxTv_SdtSDT_PublishPage_Sdt_page = value;
				SetDirty("Sdt_page");
			}
		}
		public void gxTv_SdtSDT_PublishPage_Sdt_page_SetNull()
		{
			gxTv_SdtSDT_PublishPage_Sdt_page_N = true;
			gxTv_SdtSDT_PublishPage_Sdt_page = null;
		}

		public bool gxTv_SdtSDT_PublishPage_Sdt_page_IsNull()
		{
			return gxTv_SdtSDT_PublishPage_Sdt_page == null;
		}
		public bool ShouldSerializegxTpr_Sdt_page_Json()
		{
			return gxTv_SdtSDT_PublishPage_Sdt_page != null;

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
			gxTv_SdtSDT_PublishPage_Pagename = "";
			gxTv_SdtSDT_PublishPage_Pageispublished = false;
			gxTv_SdtSDT_PublishPage_Pageiscontentpage = false;
			gxTv_SdtSDT_PublishPage_Pageispredefined = false;
			gxTv_SdtSDT_PublishPage_Pagegjsjson = "";
			gxTv_SdtSDT_PublishPage_Pagegjshtml = "";
			gxTv_SdtSDT_PublishPage_Pagejsoncontent = "";

			gxTv_SdtSDT_PublishPage_Sdt_page_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_PublishPage_Pageid;
		 

		protected string gxTv_SdtSDT_PublishPage_Pagename;
		 

		protected bool gxTv_SdtSDT_PublishPage_Pageispublished;
		 

		protected bool gxTv_SdtSDT_PublishPage_Pageiscontentpage;
		 

		protected bool gxTv_SdtSDT_PublishPage_Pageispredefined;
		 

		protected string gxTv_SdtSDT_PublishPage_Pagegjsjson;
		 

		protected string gxTv_SdtSDT_PublishPage_Pagegjshtml;
		 

		protected string gxTv_SdtSDT_PublishPage_Pagejsoncontent;
		 

		protected GeneXus.Programs.SdtSDT_Page gxTv_SdtSDT_PublishPage_Sdt_page = null;
		protected bool gxTv_SdtSDT_PublishPage_Sdt_page_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_PublishPage", Namespace="Comforta_version21")]
	public class SdtSDT_PublishPage_RESTInterface : GxGenericCollectionItem<SdtSDT_PublishPage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PublishPage_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PublishPage_RESTInterface( SdtSDT_PublishPage psdt ) : base(psdt)
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

		[DataMember(Name="PageIsPublished", Order=2)]
		public bool gxTpr_Pageispublished
		{
			get { 
				return sdt.gxTpr_Pageispublished;

			}
			set { 
				sdt.gxTpr_Pageispublished = value;
			}
		}

		[DataMember(Name="PageIsContentPage", Order=3)]
		public bool gxTpr_Pageiscontentpage
		{
			get { 
				return sdt.gxTpr_Pageiscontentpage;

			}
			set { 
				sdt.gxTpr_Pageiscontentpage = value;
			}
		}

		[DataMember(Name="PageIsPredefined", Order=4)]
		public bool gxTpr_Pageispredefined
		{
			get { 
				return sdt.gxTpr_Pageispredefined;

			}
			set { 
				sdt.gxTpr_Pageispredefined = value;
			}
		}

		[DataMember(Name="PageGJSJson", Order=5)]
		public  string gxTpr_Pagegjsjson
		{
			get { 
				return sdt.gxTpr_Pagegjsjson;

			}
			set { 
				 sdt.gxTpr_Pagegjsjson = value;
			}
		}

		[DataMember(Name="PageGJSHtml", Order=6)]
		public  string gxTpr_Pagegjshtml
		{
			get { 
				return sdt.gxTpr_Pagegjshtml;

			}
			set { 
				 sdt.gxTpr_Pagegjshtml = value;
			}
		}

		[DataMember(Name="PageJsonContent", Order=7)]
		public  string gxTpr_Pagejsoncontent
		{
			get { 
				return sdt.gxTpr_Pagejsoncontent;

			}
			set { 
				 sdt.gxTpr_Pagejsoncontent = value;
			}
		}

		[DataMember(Name="SDT_Page", Order=8, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_Page_RESTInterface gxTpr_Sdt_page
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_page_Json())
					return new GeneXus.Programs.SdtSDT_Page_RESTInterface(sdt.gxTpr_Sdt_page);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Sdt_page = value.sdt;
			}
		}


		#endregion

		public SdtSDT_PublishPage sdt
		{
			get { 
				return (SdtSDT_PublishPage)Sdt;
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
				sdt = new SdtSDT_PublishPage() ;
			}
		}
	}
	#endregion
}