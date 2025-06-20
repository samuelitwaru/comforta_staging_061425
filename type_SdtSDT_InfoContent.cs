/*
				   File: type_SdtSDT_InfoContent
			Description: SDT_InfoContent
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
	[XmlRoot(ElementName="SDT_InfoContent")]
	[XmlType(TypeName="SDT_InfoContent" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_InfoContent : GxUserType
	{
		public SdtSDT_InfoContent( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_InfoContent(IGxContext context)
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
			if (gxTv_SdtSDT_InfoContent_Infocontent != null)
			{
				AddObjectProperty("InfoContent", gxTv_SdtSDT_InfoContent_Infocontent, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="InfoContent" )]
		[XmlArray(ElementName="InfoContent"  )]
		[XmlArrayItemAttribute(ElementName="InfoContentItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_InfoContent_InfoContentItem> gxTpr_Infocontent
		{
			get {
				if ( gxTv_SdtSDT_InfoContent_Infocontent == null )
				{
					gxTv_SdtSDT_InfoContent_Infocontent = new GXBaseCollection<SdtSDT_InfoContent_InfoContentItem>( context, "SDT_InfoContent.InfoContentItem", "");
				}
				return gxTv_SdtSDT_InfoContent_Infocontent;
			}
			set {
				gxTv_SdtSDT_InfoContent_Infocontent_N = false;
				gxTv_SdtSDT_InfoContent_Infocontent = value;
				SetDirty("Infocontent");
			}
		}

		public void gxTv_SdtSDT_InfoContent_Infocontent_SetNull()
		{
			gxTv_SdtSDT_InfoContent_Infocontent_N = true;
			gxTv_SdtSDT_InfoContent_Infocontent = null;
		}

		public bool gxTv_SdtSDT_InfoContent_Infocontent_IsNull()
		{
			return gxTv_SdtSDT_InfoContent_Infocontent == null;
		}
		public bool ShouldSerializegxTpr_Infocontent_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_InfoContent_Infocontent != null && gxTv_SdtSDT_InfoContent_Infocontent.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Infocontent_GxSimpleCollection_Json() || 
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
			gxTv_SdtSDT_InfoContent_Infocontent_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_InfoContent_Infocontent_N;
		protected GXBaseCollection<SdtSDT_InfoContent_InfoContentItem> gxTv_SdtSDT_InfoContent_Infocontent = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_InfoContent", Namespace="Comforta_version2")]
	public class SdtSDT_InfoContent_RESTInterface : GxGenericCollectionItem<SdtSDT_InfoContent>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_InfoContent_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_InfoContent_RESTInterface( SdtSDT_InfoContent psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="InfoContent", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_InfoContent_InfoContentItem_RESTInterface> gxTpr_Infocontent
		{
			get {
				if (sdt.ShouldSerializegxTpr_Infocontent_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_InfoContent_InfoContentItem_RESTInterface>(sdt.gxTpr_Infocontent);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Infocontent);
			}
		}


		#endregion

		public SdtSDT_InfoContent sdt
		{
			get { 
				return (SdtSDT_InfoContent)Sdt;
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
				sdt = new SdtSDT_InfoContent() ;
			}
		}
	}
	#endregion
}