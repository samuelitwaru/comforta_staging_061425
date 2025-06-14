/*
				   File: type_SdtSDT_DebugResult_PagesItem
			Description: Pages
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
	[XmlRoot(ElementName="SDT_DebugResult.PagesItem")]
	[XmlType(TypeName="SDT_DebugResult.PagesItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_DebugResult_PagesItem : GxUserType
	{
		public SdtSDT_DebugResult_PagesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DebugResult_PagesItem_Page = "";

		}

		public SdtSDT_DebugResult_PagesItem(IGxContext context)
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

			if (gxTv_SdtSDT_DebugResult_PagesItem_Urllist != null)
			{
				AddObjectProperty("UrlList", gxTv_SdtSDT_DebugResult_PagesItem_Urllist, false);
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
				return gxTv_SdtSDT_DebugResult_PagesItem_Page; 
			}
			set {
				gxTv_SdtSDT_DebugResult_PagesItem_Page = value;
				SetDirty("Page");
			}
		}




		[SoapElement(ElementName="UrlList" )]
		[XmlArray(ElementName="UrlList"  )]
		[XmlArrayItemAttribute(ElementName="UrlListItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_DebugResult_PagesItem_UrlListItem> gxTpr_Urllist
		{
			get {
				if ( gxTv_SdtSDT_DebugResult_PagesItem_Urllist == null )
				{
					gxTv_SdtSDT_DebugResult_PagesItem_Urllist = new GXBaseCollection<SdtSDT_DebugResult_PagesItem_UrlListItem>( context, "SDT_DebugResult.PagesItem.UrlListItem", "");
				}
				return gxTv_SdtSDT_DebugResult_PagesItem_Urllist;
			}
			set {
				gxTv_SdtSDT_DebugResult_PagesItem_Urllist_N = false;
				gxTv_SdtSDT_DebugResult_PagesItem_Urllist = value;
				SetDirty("Urllist");
			}
		}

		public void gxTv_SdtSDT_DebugResult_PagesItem_Urllist_SetNull()
		{
			gxTv_SdtSDT_DebugResult_PagesItem_Urllist_N = true;
			gxTv_SdtSDT_DebugResult_PagesItem_Urllist = null;
		}

		public bool gxTv_SdtSDT_DebugResult_PagesItem_Urllist_IsNull()
		{
			return gxTv_SdtSDT_DebugResult_PagesItem_Urllist == null;
		}
		public bool ShouldSerializegxTpr_Urllist_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_DebugResult_PagesItem_Urllist != null && gxTv_SdtSDT_DebugResult_PagesItem_Urllist.Count > 0;

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
			gxTv_SdtSDT_DebugResult_PagesItem_Page = "";

			gxTv_SdtSDT_DebugResult_PagesItem_Urllist_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_DebugResult_PagesItem_Page;
		 
		protected bool gxTv_SdtSDT_DebugResult_PagesItem_Urllist_N;
		protected GXBaseCollection<SdtSDT_DebugResult_PagesItem_UrlListItem> gxTv_SdtSDT_DebugResult_PagesItem_Urllist = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_DebugResult.PagesItem", Namespace="Comforta_version21")]
	public class SdtSDT_DebugResult_PagesItem_RESTInterface : GxGenericCollectionItem<SdtSDT_DebugResult_PagesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DebugResult_PagesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DebugResult_PagesItem_RESTInterface( SdtSDT_DebugResult_PagesItem psdt ) : base(psdt)
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

		[DataMember(Name="UrlList", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_DebugResult_PagesItem_UrlListItem_RESTInterface> gxTpr_Urllist
		{
			get {
				if (sdt.ShouldSerializegxTpr_Urllist_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_DebugResult_PagesItem_UrlListItem_RESTInterface>(sdt.gxTpr_Urllist);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Urllist);
			}
		}


		#endregion

		public SdtSDT_DebugResult_PagesItem sdt
		{
			get { 
				return (SdtSDT_DebugResult_PagesItem)Sdt;
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
				sdt = new SdtSDT_DebugResult_PagesItem() ;
			}
		}
	}
	#endregion
}