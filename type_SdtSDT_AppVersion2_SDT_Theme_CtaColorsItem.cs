/*
				   File: type_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem
			Description: CtaColors
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
	[XmlRoot(ElementName="SDT_AppVersion2.SDT_Theme.CtaColorsItem")]
	[XmlType(TypeName="SDT_AppVersion2.SDT_Theme.CtaColorsItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem : GxUserType
	{
		public SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorname = "";

			gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorcode = "";

		}

		public SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem(IGxContext context)
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
			AddObjectProperty("CtaColorId", gxTpr_Ctacolorid, false);


			AddObjectProperty("CtaColorName", gxTpr_Ctacolorname, false);


			AddObjectProperty("CtaColorCode", gxTpr_Ctacolorcode, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CtaColorId")]
		[XmlElement(ElementName="CtaColorId")]
		public Guid gxTpr_Ctacolorid
		{
			get {
				return gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorid; 
			}
			set {
				gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorid = value;
				SetDirty("Ctacolorid");
			}
		}




		[SoapElement(ElementName="CtaColorName")]
		[XmlElement(ElementName="CtaColorName")]
		public string gxTpr_Ctacolorname
		{
			get {
				return gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorname; 
			}
			set {
				gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorname = value;
				SetDirty("Ctacolorname");
			}
		}




		[SoapElement(ElementName="CtaColorCode")]
		[XmlElement(ElementName="CtaColorCode")]
		public string gxTpr_Ctacolorcode
		{
			get {
				return gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorcode; 
			}
			set {
				gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorcode = value;
				SetDirty("Ctacolorcode");
			}
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
			gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorname = "";
			gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorcode = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorid;
		 

		protected string gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorname;
		 

		protected string gxTv_SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_Ctacolorcode;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_AppVersion2.SDT_Theme.CtaColorsItem", Namespace="Comforta_version2")]
	public class SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem_RESTInterface( SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CtaColorId", Order=0)]
		public Guid gxTpr_Ctacolorid
		{
			get { 
				return sdt.gxTpr_Ctacolorid;

			}
			set { 
				sdt.gxTpr_Ctacolorid = value;
			}
		}

		[DataMember(Name="CtaColorName", Order=1)]
		public  string gxTpr_Ctacolorname
		{
			get { 
				return sdt.gxTpr_Ctacolorname;

			}
			set { 
				 sdt.gxTpr_Ctacolorname = value;
			}
		}

		[DataMember(Name="CtaColorCode", Order=2)]
		public  string gxTpr_Ctacolorcode
		{
			get { 
				return sdt.gxTpr_Ctacolorcode;

			}
			set { 
				 sdt.gxTpr_Ctacolorcode = value;
			}
		}


		#endregion

		public SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem sdt
		{
			get { 
				return (SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem)Sdt;
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
				sdt = new SdtSDT_AppVersion2_SDT_Theme_CtaColorsItem() ;
			}
		}
	}
	#endregion
}