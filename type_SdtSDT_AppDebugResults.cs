/*
				   File: type_SdtSDT_AppDebugResults
			Description: SDT_AppDebugResults
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
	[XmlRoot(ElementName="SDT_AppDebugResults")]
	[XmlType(TypeName="SDT_AppDebugResults" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_AppDebugResults : GxUserType
	{
		public SdtSDT_AppDebugResults( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_AppDebugResults(IGxContext context)
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
			if (gxTv_SdtSDT_AppDebugResults_Summary != null)
			{
				AddObjectProperty("Summary", gxTv_SdtSDT_AppDebugResults_Summary, false);
			}
			if (gxTv_SdtSDT_AppDebugResults_Pages != null)
			{
				AddObjectProperty("Pages", gxTv_SdtSDT_AppDebugResults_Pages, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Summary" )]
		[XmlElement(ElementName="Summary" )]
		public SdtSDT_AppDebugResults_Summary gxTpr_Summary
		{
			get {
				if ( gxTv_SdtSDT_AppDebugResults_Summary == null )
				{
					gxTv_SdtSDT_AppDebugResults_Summary = new SdtSDT_AppDebugResults_Summary(context);
				}
				gxTv_SdtSDT_AppDebugResults_Summary_N = false;
				return gxTv_SdtSDT_AppDebugResults_Summary;
			}
			set {
				gxTv_SdtSDT_AppDebugResults_Summary_N = false;
				gxTv_SdtSDT_AppDebugResults_Summary = value;
				SetDirty("Summary");
			}

		}

		public void gxTv_SdtSDT_AppDebugResults_Summary_SetNull()
		{
			gxTv_SdtSDT_AppDebugResults_Summary_N = true;
			gxTv_SdtSDT_AppDebugResults_Summary = null;
		}

		public bool gxTv_SdtSDT_AppDebugResults_Summary_IsNull()
		{
			return gxTv_SdtSDT_AppDebugResults_Summary == null;
		}
		public bool ShouldSerializegxTpr_Summary_Json()
		{
				return (gxTv_SdtSDT_AppDebugResults_Summary != null && gxTv_SdtSDT_AppDebugResults_Summary.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="Pages" )]
		[XmlArray(ElementName="Pages"  )]
		[XmlArrayItemAttribute(ElementName="PagesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_AppDebugResults_PagesItem> gxTpr_Pages
		{
			get {
				if ( gxTv_SdtSDT_AppDebugResults_Pages == null )
				{
					gxTv_SdtSDT_AppDebugResults_Pages = new GXBaseCollection<SdtSDT_AppDebugResults_PagesItem>( context, "SDT_AppDebugResults.PagesItem", "");
				}
				return gxTv_SdtSDT_AppDebugResults_Pages;
			}
			set {
				gxTv_SdtSDT_AppDebugResults_Pages_N = false;
				gxTv_SdtSDT_AppDebugResults_Pages = value;
				SetDirty("Pages");
			}
		}

		public void gxTv_SdtSDT_AppDebugResults_Pages_SetNull()
		{
			gxTv_SdtSDT_AppDebugResults_Pages_N = true;
			gxTv_SdtSDT_AppDebugResults_Pages = null;
		}

		public bool gxTv_SdtSDT_AppDebugResults_Pages_IsNull()
		{
			return gxTv_SdtSDT_AppDebugResults_Pages == null;
		}
		public bool ShouldSerializegxTpr_Pages_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_AppDebugResults_Pages != null && gxTv_SdtSDT_AppDebugResults_Pages.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Summary_Json() ||
				ShouldSerializegxTpr_Pages_GxSimpleCollection_Json() || 
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
			gxTv_SdtSDT_AppDebugResults_Summary_N = true;


			gxTv_SdtSDT_AppDebugResults_Pages_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_AppDebugResults_Summary_N;
		protected SdtSDT_AppDebugResults_Summary gxTv_SdtSDT_AppDebugResults_Summary = null; 

		protected bool gxTv_SdtSDT_AppDebugResults_Pages_N;
		protected GXBaseCollection<SdtSDT_AppDebugResults_PagesItem> gxTv_SdtSDT_AppDebugResults_Pages = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_AppDebugResults", Namespace="Comforta_version2")]
	public class SdtSDT_AppDebugResults_RESTInterface : GxGenericCollectionItem<SdtSDT_AppDebugResults>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_AppDebugResults_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_AppDebugResults_RESTInterface( SdtSDT_AppDebugResults psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Summary", Order=0, EmitDefaultValue=false)]
		public SdtSDT_AppDebugResults_Summary_RESTInterface gxTpr_Summary
		{
			get {
				if (sdt.ShouldSerializegxTpr_Summary_Json())
					return new SdtSDT_AppDebugResults_Summary_RESTInterface(sdt.gxTpr_Summary);
				else
					return null;

			}

			set {
				sdt.gxTpr_Summary = value.sdt;
			}

		}

		[DataMember(Name="Pages", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_AppDebugResults_PagesItem_RESTInterface> gxTpr_Pages
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pages_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_AppDebugResults_PagesItem_RESTInterface>(sdt.gxTpr_Pages);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Pages);
			}
		}


		#endregion

		public SdtSDT_AppDebugResults sdt
		{
			get { 
				return (SdtSDT_AppDebugResults)Sdt;
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
				sdt = new SdtSDT_AppDebugResults() ;
			}
		}
	}
	#endregion
}