/*
				   File: type_SdtSDT_ContentPageV1
			Description: SDT_ContentPageV1
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
	[XmlRoot(ElementName="SDT_ContentPageV1")]
	[XmlType(TypeName="SDT_ContentPageV1" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPageV1 : GxUserType
	{
		public SdtSDT_ContentPageV1( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ContentPageV1_Pagename = "";

		}

		public SdtSDT_ContentPageV1(IGxContext context)
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

			if (gxTv_SdtSDT_ContentPageV1_Content != null)
			{
				AddObjectProperty("Content", gxTv_SdtSDT_ContentPageV1_Content, false);
			}
			if (gxTv_SdtSDT_ContentPageV1_Cta != null)
			{
				AddObjectProperty("Cta", gxTv_SdtSDT_ContentPageV1_Cta, false);
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
				return gxTv_SdtSDT_ContentPageV1_Pageid; 
			}
			set {
				gxTv_SdtSDT_ContentPageV1_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_ContentPageV1_Pagename; 
			}
			set {
				gxTv_SdtSDT_ContentPageV1_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="Content" )]
		[XmlArray(ElementName="Content"  )]
		[XmlArrayItemAttribute(ElementName="ContentItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_ContentPageV1_ContentItem> gxTpr_Content
		{
			get {
				if ( gxTv_SdtSDT_ContentPageV1_Content == null )
				{
					gxTv_SdtSDT_ContentPageV1_Content = new GXBaseCollection<SdtSDT_ContentPageV1_ContentItem>( context, "SDT_ContentPageV1.ContentItem", "");
				}
				return gxTv_SdtSDT_ContentPageV1_Content;
			}
			set {
				gxTv_SdtSDT_ContentPageV1_Content_N = false;
				gxTv_SdtSDT_ContentPageV1_Content = value;
				SetDirty("Content");
			}
		}

		public void gxTv_SdtSDT_ContentPageV1_Content_SetNull()
		{
			gxTv_SdtSDT_ContentPageV1_Content_N = true;
			gxTv_SdtSDT_ContentPageV1_Content = null;
		}

		public bool gxTv_SdtSDT_ContentPageV1_Content_IsNull()
		{
			return gxTv_SdtSDT_ContentPageV1_Content == null;
		}
		public bool ShouldSerializegxTpr_Content_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_ContentPageV1_Content != null && gxTv_SdtSDT_ContentPageV1_Content.Count > 0;

		}



		[SoapElement(ElementName="Cta" )]
		[XmlArray(ElementName="Cta"  )]
		[XmlArrayItemAttribute(ElementName="CtaItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_ContentPageV1_CtaItem> gxTpr_Cta
		{
			get {
				if ( gxTv_SdtSDT_ContentPageV1_Cta == null )
				{
					gxTv_SdtSDT_ContentPageV1_Cta = new GXBaseCollection<SdtSDT_ContentPageV1_CtaItem>( context, "SDT_ContentPageV1.CtaItem", "");
				}
				return gxTv_SdtSDT_ContentPageV1_Cta;
			}
			set {
				gxTv_SdtSDT_ContentPageV1_Cta_N = false;
				gxTv_SdtSDT_ContentPageV1_Cta = value;
				SetDirty("Cta");
			}
		}

		public void gxTv_SdtSDT_ContentPageV1_Cta_SetNull()
		{
			gxTv_SdtSDT_ContentPageV1_Cta_N = true;
			gxTv_SdtSDT_ContentPageV1_Cta = null;
		}

		public bool gxTv_SdtSDT_ContentPageV1_Cta_IsNull()
		{
			return gxTv_SdtSDT_ContentPageV1_Cta == null;
		}
		public bool ShouldSerializegxTpr_Cta_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_ContentPageV1_Cta != null && gxTv_SdtSDT_ContentPageV1_Cta.Count > 0;

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
			gxTv_SdtSDT_ContentPageV1_Pagename = "";

			gxTv_SdtSDT_ContentPageV1_Content_N = true;


			gxTv_SdtSDT_ContentPageV1_Cta_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_ContentPageV1_Pageid;
		 

		protected string gxTv_SdtSDT_ContentPageV1_Pagename;
		 
		protected bool gxTv_SdtSDT_ContentPageV1_Content_N;
		protected GXBaseCollection<SdtSDT_ContentPageV1_ContentItem> gxTv_SdtSDT_ContentPageV1_Content = null; 

		protected bool gxTv_SdtSDT_ContentPageV1_Cta_N;
		protected GXBaseCollection<SdtSDT_ContentPageV1_CtaItem> gxTv_SdtSDT_ContentPageV1_Cta = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ContentPageV1", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPageV1_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPageV1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPageV1_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPageV1_RESTInterface( SdtSDT_ContentPageV1 psdt ) : base(psdt)
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

		[DataMember(Name="Content", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_ContentPageV1_ContentItem_RESTInterface> gxTpr_Content
		{
			get {
				if (sdt.ShouldSerializegxTpr_Content_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_ContentPageV1_ContentItem_RESTInterface>(sdt.gxTpr_Content);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Content);
			}
		}

		[DataMember(Name="Cta", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_ContentPageV1_CtaItem_RESTInterface> gxTpr_Cta
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cta_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_ContentPageV1_CtaItem_RESTInterface>(sdt.gxTpr_Cta);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Cta);
			}
		}


		#endregion

		public SdtSDT_ContentPageV1 sdt
		{
			get { 
				return (SdtSDT_ContentPageV1)Sdt;
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
				sdt = new SdtSDT_ContentPageV1() ;
			}
		}
	}
	#endregion
}