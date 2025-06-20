/*
				   File: type_SdtSDT_ContentPage
			Description: SDT_ContentPage
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
	[XmlRoot(ElementName="SDT_ContentPage")]
	[XmlType(TypeName="SDT_ContentPage" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPage : GxUserType
	{
		public SdtSDT_ContentPage( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_ContentPage(IGxContext context)
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
			if (gxTv_SdtSDT_ContentPage_Content != null)
			{
				AddObjectProperty("Content", gxTv_SdtSDT_ContentPage_Content, false);
			}
			if (gxTv_SdtSDT_ContentPage_Cta != null)
			{
				AddObjectProperty("Cta", gxTv_SdtSDT_ContentPage_Cta, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Content" )]
		[XmlArray(ElementName="Content"  )]
		[XmlArrayItemAttribute(ElementName="ContentItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_ContentPage_ContentItem> gxTpr_Content
		{
			get {
				if ( gxTv_SdtSDT_ContentPage_Content == null )
				{
					gxTv_SdtSDT_ContentPage_Content = new GXBaseCollection<SdtSDT_ContentPage_ContentItem>( context, "SDT_ContentPage.ContentItem", "");
				}
				return gxTv_SdtSDT_ContentPage_Content;
			}
			set {
				gxTv_SdtSDT_ContentPage_Content_N = false;
				gxTv_SdtSDT_ContentPage_Content = value;
				SetDirty("Content");
			}
		}

		public void gxTv_SdtSDT_ContentPage_Content_SetNull()
		{
			gxTv_SdtSDT_ContentPage_Content_N = true;
			gxTv_SdtSDT_ContentPage_Content = null;
		}

		public bool gxTv_SdtSDT_ContentPage_Content_IsNull()
		{
			return gxTv_SdtSDT_ContentPage_Content == null;
		}
		public bool ShouldSerializegxTpr_Content_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_ContentPage_Content != null && gxTv_SdtSDT_ContentPage_Content.Count > 0;

		}



		[SoapElement(ElementName="Cta" )]
		[XmlArray(ElementName="Cta"  )]
		[XmlArrayItemAttribute(ElementName="CtaItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_ContentPage_CtaItem> gxTpr_Cta
		{
			get {
				if ( gxTv_SdtSDT_ContentPage_Cta == null )
				{
					gxTv_SdtSDT_ContentPage_Cta = new GXBaseCollection<SdtSDT_ContentPage_CtaItem>( context, "SDT_ContentPage.CtaItem", "");
				}
				return gxTv_SdtSDT_ContentPage_Cta;
			}
			set {
				gxTv_SdtSDT_ContentPage_Cta_N = false;
				gxTv_SdtSDT_ContentPage_Cta = value;
				SetDirty("Cta");
			}
		}

		public void gxTv_SdtSDT_ContentPage_Cta_SetNull()
		{
			gxTv_SdtSDT_ContentPage_Cta_N = true;
			gxTv_SdtSDT_ContentPage_Cta = null;
		}

		public bool gxTv_SdtSDT_ContentPage_Cta_IsNull()
		{
			return gxTv_SdtSDT_ContentPage_Cta == null;
		}
		public bool ShouldSerializegxTpr_Cta_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_ContentPage_Cta != null && gxTv_SdtSDT_ContentPage_Cta.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Content_GxSimpleCollection_Json() ||
				ShouldSerializegxTpr_Cta_GxSimpleCollection_Json() || 
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
			gxTv_SdtSDT_ContentPage_Content_N = true;


			gxTv_SdtSDT_ContentPage_Cta_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_ContentPage_Content_N;
		protected GXBaseCollection<SdtSDT_ContentPage_ContentItem> gxTv_SdtSDT_ContentPage_Content = null; 

		protected bool gxTv_SdtSDT_ContentPage_Cta_N;
		protected GXBaseCollection<SdtSDT_ContentPage_CtaItem> gxTv_SdtSDT_ContentPage_Cta = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ContentPage", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPage_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPage_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPage_RESTInterface( SdtSDT_ContentPage psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Content", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_ContentPage_ContentItem_RESTInterface> gxTpr_Content
		{
			get {
				if (sdt.ShouldSerializegxTpr_Content_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_ContentPage_ContentItem_RESTInterface>(sdt.gxTpr_Content);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Content);
			}
		}

		[DataMember(Name="Cta", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_ContentPage_CtaItem_RESTInterface> gxTpr_Cta
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cta_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_ContentPage_CtaItem_RESTInterface>(sdt.gxTpr_Cta);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Cta);
			}
		}


		#endregion

		public SdtSDT_ContentPage sdt
		{
			get { 
				return (SdtSDT_ContentPage)Sdt;
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
				sdt = new SdtSDT_ContentPage() ;
			}
		}
	}
	#endregion
}