/*
				   File: type_SdtSDT_PageUrl
			Description: SDT_PageUrl
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
	[XmlRoot(ElementName="SDT_PageUrl")]
	[XmlType(TypeName="SDT_PageUrl" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_PageUrl : GxUserType
	{
		public SdtSDT_PageUrl( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PageUrl_Page = "";

		}

		public SdtSDT_PageUrl(IGxContext context)
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
			AddObjectProperty("Page", gxTpr_Page, false);


			AddObjectProperty("PageId", gxTpr_Pageid, false);

			if (gxTv_SdtSDT_PageUrl_Urls != null)
			{
				AddObjectProperty("Urls", gxTv_SdtSDT_PageUrl_Urls, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Page")]
		[XmlElement(ElementName="Page")]
		public string gxTpr_Page
		{
			get {
				return gxTv_SdtSDT_PageUrl_Page; 
			}
			set {
				gxTv_SdtSDT_PageUrl_Page = value;
				SetDirty("Page");
			}
		}




		[SoapElement(ElementName="PageId")]
		[XmlElement(ElementName="PageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_PageUrl_Pageid; 
			}
			set {
				gxTv_SdtSDT_PageUrl_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="Urls" )]
		[XmlArray(ElementName="Urls"  )]
		[XmlArrayItemAttribute(ElementName="UrlsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_PageUrl_UrlsItem> gxTpr_Urls
		{
			get {
				if ( gxTv_SdtSDT_PageUrl_Urls == null )
				{
					gxTv_SdtSDT_PageUrl_Urls = new GXBaseCollection<SdtSDT_PageUrl_UrlsItem>( context, "SDT_PageUrl.UrlsItem", "");
				}
				return gxTv_SdtSDT_PageUrl_Urls;
			}
			set {
				gxTv_SdtSDT_PageUrl_Urls_N = false;
				gxTv_SdtSDT_PageUrl_Urls = value;
				SetDirty("Urls");
			}
		}

		public void gxTv_SdtSDT_PageUrl_Urls_SetNull()
		{
			gxTv_SdtSDT_PageUrl_Urls_N = true;
			gxTv_SdtSDT_PageUrl_Urls = null;
		}

		public bool gxTv_SdtSDT_PageUrl_Urls_IsNull()
		{
			return gxTv_SdtSDT_PageUrl_Urls == null;
		}
		public bool ShouldSerializegxTpr_Urls_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_PageUrl_Urls != null && gxTv_SdtSDT_PageUrl_Urls.Count > 0;

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
			gxTv_SdtSDT_PageUrl_Page = "";


			gxTv_SdtSDT_PageUrl_Urls_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_PageUrl_Page;
		 

		protected Guid gxTv_SdtSDT_PageUrl_Pageid;
		 
		protected bool gxTv_SdtSDT_PageUrl_Urls_N;
		protected GXBaseCollection<SdtSDT_PageUrl_UrlsItem> gxTv_SdtSDT_PageUrl_Urls = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_PageUrl", Namespace="Comforta_version2")]
	public class SdtSDT_PageUrl_RESTInterface : GxGenericCollectionItem<SdtSDT_PageUrl>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PageUrl_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PageUrl_RESTInterface( SdtSDT_PageUrl psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Page", Order=0)]
		public  string gxTpr_Page
		{
			get { 
				return sdt.gxTpr_Page;

			}
			set { 
				 sdt.gxTpr_Page = value;
			}
		}

		[DataMember(Name="PageId", Order=1)]
		public Guid gxTpr_Pageid
		{
			get { 
				return sdt.gxTpr_Pageid;

			}
			set { 
				sdt.gxTpr_Pageid = value;
			}
		}

		[DataMember(Name="Urls", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_PageUrl_UrlsItem_RESTInterface> gxTpr_Urls
		{
			get {
				if (sdt.ShouldSerializegxTpr_Urls_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_PageUrl_UrlsItem_RESTInterface>(sdt.gxTpr_Urls);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Urls);
			}
		}


		#endregion

		public SdtSDT_PageUrl sdt
		{
			get { 
				return (SdtSDT_PageUrl)Sdt;
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
				sdt = new SdtSDT_PageUrl() ;
			}
		}
	}
	#endregion
}