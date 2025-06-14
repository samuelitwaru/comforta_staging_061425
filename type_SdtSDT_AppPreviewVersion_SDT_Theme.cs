/*
				   File: type_SdtSDT_AppPreviewVersion_SDT_Theme
			Description: SDT_Theme
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
	[XmlRoot(ElementName="SDT_AppPreviewVersion.SDT_Theme")]
	[XmlType(TypeName="SDT_AppPreviewVersion.SDT_Theme" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_AppPreviewVersion_SDT_Theme : GxUserType
	{
		public SdtSDT_AppPreviewVersion_SDT_Theme( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themename = "";

			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontfamily = "";

		}

		public SdtSDT_AppPreviewVersion_SDT_Theme(IGxContext context)
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
			AddObjectProperty("ThemeId", gxTpr_Themeid, false);


			AddObjectProperty("ThemeName", gxTpr_Themename, false);


			AddObjectProperty("ThemeFontFamily", gxTpr_Themefontfamily, false);


			AddObjectProperty("ThemeFontSize", gxTpr_Themefontsize, false);

			if (gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons != null)
			{
				AddObjectProperty("Icons", gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons, false);
			}
			if (gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors != null)
			{
				AddObjectProperty("Colors", gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors, false);
			}
			if (gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors != null)
			{
				AddObjectProperty("CtaColors", gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ThemeId")]
		[XmlElement(ElementName="ThemeId")]
		public Guid gxTpr_Themeid
		{
			get {
				return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themeid; 
			}
			set {
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themeid = value;
				SetDirty("Themeid");
			}
		}




		[SoapElement(ElementName="ThemeName")]
		[XmlElement(ElementName="ThemeName")]
		public string gxTpr_Themename
		{
			get {
				return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themename; 
			}
			set {
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themename = value;
				SetDirty("Themename");
			}
		}




		[SoapElement(ElementName="ThemeFontFamily")]
		[XmlElement(ElementName="ThemeFontFamily")]
		public string gxTpr_Themefontfamily
		{
			get {
				return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontfamily; 
			}
			set {
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontfamily = value;
				SetDirty("Themefontfamily");
			}
		}




		[SoapElement(ElementName="ThemeFontSize")]
		[XmlElement(ElementName="ThemeFontSize")]
		public short gxTpr_Themefontsize
		{
			get {
				return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontsize; 
			}
			set {
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontsize = value;
				SetDirty("Themefontsize");
			}
		}




		[SoapElement(ElementName="Icons" )]
		[XmlArray(ElementName="Icons"  )]
		[XmlArrayItemAttribute(ElementName="IconsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_IconsItem> gxTpr_Icons
		{
			get {
				if ( gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons == null )
				{
					gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons = new GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_IconsItem>( context, "SDT_AppPreviewVersion.SDT_Theme.IconsItem", "");
				}
				return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons;
			}
			set {
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons_N = false;
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons = value;
				SetDirty("Icons");
			}
		}

		public void gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons_SetNull()
		{
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons_N = true;
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons = null;
		}

		public bool gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons_IsNull()
		{
			return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons == null;
		}
		public bool ShouldSerializegxTpr_Icons_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons != null && gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons.Count > 0;

		}



		[SoapElement(ElementName="Colors" )]
		[XmlArray(ElementName="Colors"  )]
		[XmlArrayItemAttribute(ElementName="ColorsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_ColorsItem> gxTpr_Colors
		{
			get {
				if ( gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors == null )
				{
					gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors = new GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_ColorsItem>( context, "SDT_AppPreviewVersion.SDT_Theme.ColorsItem", "");
				}
				return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors;
			}
			set {
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors_N = false;
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors = value;
				SetDirty("Colors");
			}
		}

		public void gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors_SetNull()
		{
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors_N = true;
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors = null;
		}

		public bool gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors_IsNull()
		{
			return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors == null;
		}
		public bool ShouldSerializegxTpr_Colors_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors != null && gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors.Count > 0;

		}



		[SoapElement(ElementName="CtaColors" )]
		[XmlArray(ElementName="CtaColors"  )]
		[XmlArrayItemAttribute(ElementName="CtaColorsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_CtaColorsItem> gxTpr_Ctacolors
		{
			get {
				if ( gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors == null )
				{
					gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors = new GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_CtaColorsItem>( context, "SDT_AppPreviewVersion.SDT_Theme.CtaColorsItem", "");
				}
				return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors;
			}
			set {
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors_N = false;
				gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors = value;
				SetDirty("Ctacolors");
			}
		}

		public void gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors_SetNull()
		{
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors_N = true;
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors = null;
		}

		public bool gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors_IsNull()
		{
			return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors == null;
		}
		public bool ShouldSerializegxTpr_Ctacolors_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors != null && gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors.Count > 0;

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
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themename = "";
			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontfamily = "";


			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons_N = true;


			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors_N = true;


			gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themeid;
		 

		protected string gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themename;
		 

		protected string gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontfamily;
		 

		protected short gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Themefontsize;
		 
		protected bool gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons_N;
		protected GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_IconsItem> gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Icons = null; 

		protected bool gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors_N;
		protected GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_ColorsItem> gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Colors = null; 

		protected bool gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors_N;
		protected GXBaseCollection<SdtSDT_AppPreviewVersion_SDT_Theme_CtaColorsItem> gxTv_SdtSDT_AppPreviewVersion_SDT_Theme_Ctacolors = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_AppPreviewVersion.SDT_Theme", Namespace="Comforta_version21")]
	public class SdtSDT_AppPreviewVersion_SDT_Theme_RESTInterface : GxGenericCollectionItem<SdtSDT_AppPreviewVersion_SDT_Theme>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_AppPreviewVersion_SDT_Theme_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_AppPreviewVersion_SDT_Theme_RESTInterface( SdtSDT_AppPreviewVersion_SDT_Theme psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ThemeId", Order=0)]
		public Guid gxTpr_Themeid
		{
			get { 
				return sdt.gxTpr_Themeid;

			}
			set { 
				sdt.gxTpr_Themeid = value;
			}
		}

		[DataMember(Name="ThemeName", Order=1)]
		public  string gxTpr_Themename
		{
			get { 
				return sdt.gxTpr_Themename;

			}
			set { 
				 sdt.gxTpr_Themename = value;
			}
		}

		[DataMember(Name="ThemeFontFamily", Order=2)]
		public  string gxTpr_Themefontfamily
		{
			get { 
				return sdt.gxTpr_Themefontfamily;

			}
			set { 
				 sdt.gxTpr_Themefontfamily = value;
			}
		}

		[DataMember(Name="ThemeFontSize", Order=3)]
		public short gxTpr_Themefontsize
		{
			get { 
				return sdt.gxTpr_Themefontsize;

			}
			set { 
				sdt.gxTpr_Themefontsize = value;
			}
		}

		[DataMember(Name="Icons", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_AppPreviewVersion_SDT_Theme_IconsItem_RESTInterface> gxTpr_Icons
		{
			get {
				if (sdt.ShouldSerializegxTpr_Icons_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_AppPreviewVersion_SDT_Theme_IconsItem_RESTInterface>(sdt.gxTpr_Icons);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Icons);
			}
		}

		[DataMember(Name="Colors", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_AppPreviewVersion_SDT_Theme_ColorsItem_RESTInterface> gxTpr_Colors
		{
			get {
				if (sdt.ShouldSerializegxTpr_Colors_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_AppPreviewVersion_SDT_Theme_ColorsItem_RESTInterface>(sdt.gxTpr_Colors);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Colors);
			}
		}

		[DataMember(Name="CtaColors", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_AppPreviewVersion_SDT_Theme_CtaColorsItem_RESTInterface> gxTpr_Ctacolors
		{
			get {
				if (sdt.ShouldSerializegxTpr_Ctacolors_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_AppPreviewVersion_SDT_Theme_CtaColorsItem_RESTInterface>(sdt.gxTpr_Ctacolors);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Ctacolors);
			}
		}


		#endregion

		public SdtSDT_AppPreviewVersion_SDT_Theme sdt
		{
			get { 
				return (SdtSDT_AppPreviewVersion_SDT_Theme)Sdt;
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
				sdt = new SdtSDT_AppPreviewVersion_SDT_Theme() ;
			}
		}
	}
	#endregion
}