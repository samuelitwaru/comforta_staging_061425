/*
				   File: type_SdtSDT_MobileInfoPage
			Description: SDT_MobileInfoPage
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
	[XmlRoot(ElementName="SDT_MobileInfoPage")]
	[XmlType(TypeName="SDT_MobileInfoPage" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_MobileInfoPage : GxUserType
	{
		public SdtSDT_MobileInfoPage( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_MobileInfoPage_Pagename = "";

		}

		public SdtSDT_MobileInfoPage(IGxContext context)
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

			if (gxTv_SdtSDT_MobileInfoPage_Infocontent != null)
			{
				AddObjectProperty("InfoContent", gxTv_SdtSDT_MobileInfoPage_Infocontent, false);
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
				return gxTv_SdtSDT_MobileInfoPage_Pageid; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_Pagename; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="InfoContent" )]
		[XmlArray(ElementName="InfoContent"  )]
		[XmlArrayItemAttribute(ElementName="InfoContentItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_MobileInfoPage_InfoContentItem> gxTpr_Infocontent
		{
			get {
				if ( gxTv_SdtSDT_MobileInfoPage_Infocontent == null )
				{
					gxTv_SdtSDT_MobileInfoPage_Infocontent = new GXBaseCollection<SdtSDT_MobileInfoPage_InfoContentItem>( context, "SDT_MobileInfoPage.InfoContentItem", "");
				}
				return gxTv_SdtSDT_MobileInfoPage_Infocontent;
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_Infocontent_N = false;
				gxTv_SdtSDT_MobileInfoPage_Infocontent = value;
				SetDirty("Infocontent");
			}
		}

		public void gxTv_SdtSDT_MobileInfoPage_Infocontent_SetNull()
		{
			gxTv_SdtSDT_MobileInfoPage_Infocontent_N = true;
			gxTv_SdtSDT_MobileInfoPage_Infocontent = null;
		}

		public bool gxTv_SdtSDT_MobileInfoPage_Infocontent_IsNull()
		{
			return gxTv_SdtSDT_MobileInfoPage_Infocontent == null;
		}
		public bool ShouldSerializegxTpr_Infocontent_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_MobileInfoPage_Infocontent != null && gxTv_SdtSDT_MobileInfoPage_Infocontent.Count > 0;

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
			gxTv_SdtSDT_MobileInfoPage_Pagename = "";

			gxTv_SdtSDT_MobileInfoPage_Infocontent_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_MobileInfoPage_Pageid;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_Pagename;
		 
		protected bool gxTv_SdtSDT_MobileInfoPage_Infocontent_N;
		protected GXBaseCollection<SdtSDT_MobileInfoPage_InfoContentItem> gxTv_SdtSDT_MobileInfoPage_Infocontent = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_MobileInfoPage", Namespace="Comforta_version21")]
	public class SdtSDT_MobileInfoPage_RESTInterface : GxGenericCollectionItem<SdtSDT_MobileInfoPage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MobileInfoPage_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MobileInfoPage_RESTInterface( SdtSDT_MobileInfoPage psdt ) : base(psdt)
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

		[DataMember(Name="InfoContent", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_MobileInfoPage_InfoContentItem_RESTInterface> gxTpr_Infocontent
		{
			get {
				if (sdt.ShouldSerializegxTpr_Infocontent_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_MobileInfoPage_InfoContentItem_RESTInterface>(sdt.gxTpr_Infocontent);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Infocontent);
			}
		}


		#endregion

		public SdtSDT_MobileInfoPage sdt
		{
			get { 
				return (SdtSDT_MobileInfoPage)Sdt;
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
				sdt = new SdtSDT_MobileInfoPage() ;
			}
		}
	}
	#endregion
}