/*
				   File: type_SdtSDT_LocationTheme
			Description: SDT_LocationTheme
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
	[XmlRoot(ElementName="SDT_LocationTheme")]
	[XmlType(TypeName="SDT_LocationTheme" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_LocationTheme : GxUserType
	{
		public SdtSDT_LocationTheme( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_LocationTheme_Themename = "";

			gxTv_SdtSDT_LocationTheme_Themefontfamily = "";

		}

		public SdtSDT_LocationTheme(IGxContext context)
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

			if (gxTv_SdtSDT_LocationTheme_Color != null)
			{
				AddObjectProperty("Color", gxTv_SdtSDT_LocationTheme_Color, false);
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
				return gxTv_SdtSDT_LocationTheme_Themeid; 
			}
			set {
				gxTv_SdtSDT_LocationTheme_Themeid = value;
				SetDirty("Themeid");
			}
		}




		[SoapElement(ElementName="ThemeName")]
		[XmlElement(ElementName="ThemeName")]
		public string gxTpr_Themename
		{
			get {
				return gxTv_SdtSDT_LocationTheme_Themename; 
			}
			set {
				gxTv_SdtSDT_LocationTheme_Themename = value;
				SetDirty("Themename");
			}
		}




		[SoapElement(ElementName="ThemeFontFamily")]
		[XmlElement(ElementName="ThemeFontFamily")]
		public string gxTpr_Themefontfamily
		{
			get {
				return gxTv_SdtSDT_LocationTheme_Themefontfamily; 
			}
			set {
				gxTv_SdtSDT_LocationTheme_Themefontfamily = value;
				SetDirty("Themefontfamily");
			}
		}




		[SoapElement(ElementName="ThemeFontSize")]
		[XmlElement(ElementName="ThemeFontSize")]
		public short gxTpr_Themefontsize
		{
			get {
				return gxTv_SdtSDT_LocationTheme_Themefontsize; 
			}
			set {
				gxTv_SdtSDT_LocationTheme_Themefontsize = value;
				SetDirty("Themefontsize");
			}
		}



		[SoapElement(ElementName="Color" )]
		[XmlElement(ElementName="Color" )]
		public SdtSDT_LocationTheme_Color gxTpr_Color
		{
			get {
				if ( gxTv_SdtSDT_LocationTheme_Color == null )
				{
					gxTv_SdtSDT_LocationTheme_Color = new SdtSDT_LocationTheme_Color(context);
				}
				gxTv_SdtSDT_LocationTheme_Color_N = false;
				return gxTv_SdtSDT_LocationTheme_Color;
			}
			set {
				gxTv_SdtSDT_LocationTheme_Color_N = false;
				gxTv_SdtSDT_LocationTheme_Color = value;
				SetDirty("Color");
			}

		}

		public void gxTv_SdtSDT_LocationTheme_Color_SetNull()
		{
			gxTv_SdtSDT_LocationTheme_Color_N = true;
			gxTv_SdtSDT_LocationTheme_Color = null;
		}

		public bool gxTv_SdtSDT_LocationTheme_Color_IsNull()
		{
			return gxTv_SdtSDT_LocationTheme_Color == null;
		}
		public bool ShouldSerializegxTpr_Color_Json()
		{
				return (gxTv_SdtSDT_LocationTheme_Color != null && gxTv_SdtSDT_LocationTheme_Color.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_LocationTheme_Themename = "";
			gxTv_SdtSDT_LocationTheme_Themefontfamily = "";


			gxTv_SdtSDT_LocationTheme_Color_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_LocationTheme_Themeid;
		 

		protected string gxTv_SdtSDT_LocationTheme_Themename;
		 

		protected string gxTv_SdtSDT_LocationTheme_Themefontfamily;
		 

		protected short gxTv_SdtSDT_LocationTheme_Themefontsize;
		 
		protected bool gxTv_SdtSDT_LocationTheme_Color_N;
		protected SdtSDT_LocationTheme_Color gxTv_SdtSDT_LocationTheme_Color = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_LocationTheme", Namespace="Comforta_version21")]
	public class SdtSDT_LocationTheme_RESTInterface : GxGenericCollectionItem<SdtSDT_LocationTheme>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_LocationTheme_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_LocationTheme_RESTInterface( SdtSDT_LocationTheme psdt ) : base(psdt)
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

		[DataMember(Name="Color", Order=4, EmitDefaultValue=false)]
		public SdtSDT_LocationTheme_Color_RESTInterface gxTpr_Color
		{
			get {
				if (sdt.ShouldSerializegxTpr_Color_Json())
					return new SdtSDT_LocationTheme_Color_RESTInterface(sdt.gxTpr_Color);
				else
					return null;

			}

			set {
				sdt.gxTpr_Color = value.sdt;
			}

		}


		#endregion

		public SdtSDT_LocationTheme sdt
		{
			get { 
				return (SdtSDT_LocationTheme)Sdt;
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
				sdt = new SdtSDT_LocationTheme() ;
			}
		}
	}
	#endregion
}