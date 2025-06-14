/*
				   File: type_SdtSDT_DebugResults
			Description: SDT_DebugResults
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
	[XmlRoot(ElementName="SDT_DebugResults")]
	[XmlType(TypeName="SDT_DebugResults" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_DebugResults : GxUserType
	{
		public SdtSDT_DebugResults( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_DebugResults(IGxContext context)
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
			if (gxTv_SdtSDT_DebugResults_Summary != null)
			{
				AddObjectProperty("Summary", gxTv_SdtSDT_DebugResults_Summary, false);
			}
			if (gxTv_SdtSDT_DebugResults_Pages != null)
			{
				AddObjectProperty("Pages", gxTv_SdtSDT_DebugResults_Pages, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Summary" )]
		[XmlElement(ElementName="Summary" )]
		public SdtSDT_DebugResults_Summary gxTpr_Summary
		{
			get {
				if ( gxTv_SdtSDT_DebugResults_Summary == null )
				{
					gxTv_SdtSDT_DebugResults_Summary = new SdtSDT_DebugResults_Summary(context);
				}
				gxTv_SdtSDT_DebugResults_Summary_N = false;
				return gxTv_SdtSDT_DebugResults_Summary;
			}
			set {
				gxTv_SdtSDT_DebugResults_Summary_N = false;
				gxTv_SdtSDT_DebugResults_Summary = value;
				SetDirty("Summary");
			}

		}

		public void gxTv_SdtSDT_DebugResults_Summary_SetNull()
		{
			gxTv_SdtSDT_DebugResults_Summary_N = true;
			gxTv_SdtSDT_DebugResults_Summary = null;
		}

		public bool gxTv_SdtSDT_DebugResults_Summary_IsNull()
		{
			return gxTv_SdtSDT_DebugResults_Summary == null;
		}
		public bool ShouldSerializegxTpr_Summary_Json()
		{
				return (gxTv_SdtSDT_DebugResults_Summary != null && gxTv_SdtSDT_DebugResults_Summary.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="Pages" )]
		[XmlArray(ElementName="Pages"  )]
		[XmlArrayItemAttribute(ElementName="PagesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_DebugResults_PagesItem> gxTpr_Pages
		{
			get {
				if ( gxTv_SdtSDT_DebugResults_Pages == null )
				{
					gxTv_SdtSDT_DebugResults_Pages = new GXBaseCollection<SdtSDT_DebugResults_PagesItem>( context, "SDT_DebugResults.PagesItem", "");
				}
				return gxTv_SdtSDT_DebugResults_Pages;
			}
			set {
				gxTv_SdtSDT_DebugResults_Pages_N = false;
				gxTv_SdtSDT_DebugResults_Pages = value;
				SetDirty("Pages");
			}
		}

		public void gxTv_SdtSDT_DebugResults_Pages_SetNull()
		{
			gxTv_SdtSDT_DebugResults_Pages_N = true;
			gxTv_SdtSDT_DebugResults_Pages = null;
		}

		public bool gxTv_SdtSDT_DebugResults_Pages_IsNull()
		{
			return gxTv_SdtSDT_DebugResults_Pages == null;
		}
		public bool ShouldSerializegxTpr_Pages_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_DebugResults_Pages != null && gxTv_SdtSDT_DebugResults_Pages.Count > 0;

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
			gxTv_SdtSDT_DebugResults_Summary_N = true;


			gxTv_SdtSDT_DebugResults_Pages_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_DebugResults_Summary_N;
		protected SdtSDT_DebugResults_Summary gxTv_SdtSDT_DebugResults_Summary = null; 

		protected bool gxTv_SdtSDT_DebugResults_Pages_N;
		protected GXBaseCollection<SdtSDT_DebugResults_PagesItem> gxTv_SdtSDT_DebugResults_Pages = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DebugResults", Namespace="Comforta_version21")]
	public class SdtSDT_DebugResults_RESTInterface : GxGenericCollectionItem<SdtSDT_DebugResults>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DebugResults_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DebugResults_RESTInterface( SdtSDT_DebugResults psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Summary", Order=0, EmitDefaultValue=false)]
		public SdtSDT_DebugResults_Summary_RESTInterface gxTpr_Summary
		{
			get {
				if (sdt.ShouldSerializegxTpr_Summary_Json())
					return new SdtSDT_DebugResults_Summary_RESTInterface(sdt.gxTpr_Summary);
				else
					return null;

			}

			set {
				sdt.gxTpr_Summary = value.sdt;
			}

		}

		[DataMember(Name="Pages", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_DebugResults_PagesItem_RESTInterface> gxTpr_Pages
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pages_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_DebugResults_PagesItem_RESTInterface>(sdt.gxTpr_Pages);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Pages);
			}
		}


		#endregion

		public SdtSDT_DebugResults sdt
		{
			get { 
				return (SdtSDT_DebugResults)Sdt;
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
				sdt = new SdtSDT_DebugResults() ;
			}
		}
	}
	#endregion
}