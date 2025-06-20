/*
				   File: type_SdtSDT_ContentPage_CtaItem
			Description: Cta
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
	[XmlRoot(ElementName="SDT_ContentPage.CtaItem")]
	[XmlType(TypeName="SDT_ContentPage.CtaItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPage_CtaItem : GxUserType
	{
		public SdtSDT_ContentPage_CtaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ContentPage_CtaItem_Ctaid = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctatype = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctacolor = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttontype = "";

			gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttonimgurl = "";

		}

		public SdtSDT_ContentPage_CtaItem(IGxContext context)
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
			AddObjectProperty("CtaId", gxTpr_Ctaid, false);


			AddObjectProperty("CtaType", gxTpr_Ctatype, false);


			AddObjectProperty("CtaLabel", gxTpr_Ctalabel, false);


			AddObjectProperty("CtaAction", gxTpr_Ctaaction, false);


			AddObjectProperty("CtaColor", gxTpr_Ctacolor, false);


			AddObjectProperty("CtaBGColor", gxTpr_Ctabgcolor, false);


			AddObjectProperty("CtaButtonType", gxTpr_Ctabuttontype, false);


			AddObjectProperty("CtaButtonImgUrl", gxTpr_Ctabuttonimgurl, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CtaId")]
		[XmlElement(ElementName="CtaId")]
		public string gxTpr_Ctaid
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctaid; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctaid = value;
				SetDirty("Ctaid");
			}
		}




		[SoapElement(ElementName="CtaType")]
		[XmlElement(ElementName="CtaType")]
		public string gxTpr_Ctatype
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctatype; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctatype = value;
				SetDirty("Ctatype");
			}
		}




		[SoapElement(ElementName="CtaLabel")]
		[XmlElement(ElementName="CtaLabel")]
		public string gxTpr_Ctalabel
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel = value;
				SetDirty("Ctalabel");
			}
		}




		[SoapElement(ElementName="CtaAction")]
		[XmlElement(ElementName="CtaAction")]
		public string gxTpr_Ctaaction
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction = value;
				SetDirty("Ctaaction");
			}
		}




		[SoapElement(ElementName="CtaColor")]
		[XmlElement(ElementName="CtaColor")]
		public string gxTpr_Ctacolor
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctacolor; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctacolor = value;
				SetDirty("Ctacolor");
			}
		}




		[SoapElement(ElementName="CtaBGColor")]
		[XmlElement(ElementName="CtaBGColor")]
		public string gxTpr_Ctabgcolor
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor = value;
				SetDirty("Ctabgcolor");
			}
		}




		[SoapElement(ElementName="CtaButtonType")]
		[XmlElement(ElementName="CtaButtonType")]
		public string gxTpr_Ctabuttontype
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttontype; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttontype = value;
				SetDirty("Ctabuttontype");
			}
		}




		[SoapElement(ElementName="CtaButtonImgUrl")]
		[XmlElement(ElementName="CtaButtonImgUrl")]
		public string gxTpr_Ctabuttonimgurl
		{
			get {
				return gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttonimgurl; 
			}
			set {
				gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttonimgurl = value;
				SetDirty("Ctabuttonimgurl");
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
			gxTv_SdtSDT_ContentPage_CtaItem_Ctaid = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctatype = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctacolor = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttontype = "";
			gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttonimgurl = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctaid;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctatype;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctalabel;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctaaction;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctacolor;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctabgcolor;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttontype;
		 

		protected string gxTv_SdtSDT_ContentPage_CtaItem_Ctabuttonimgurl;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ContentPage.CtaItem", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPage_CtaItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPage_CtaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPage_CtaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPage_CtaItem_RESTInterface( SdtSDT_ContentPage_CtaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CtaId", Order=0)]
		public  string gxTpr_Ctaid
		{
			get { 
				return sdt.gxTpr_Ctaid;

			}
			set { 
				 sdt.gxTpr_Ctaid = value;
			}
		}

		[DataMember(Name="CtaType", Order=1)]
		public  string gxTpr_Ctatype
		{
			get { 
				return sdt.gxTpr_Ctatype;

			}
			set { 
				 sdt.gxTpr_Ctatype = value;
			}
		}

		[DataMember(Name="CtaLabel", Order=2)]
		public  string gxTpr_Ctalabel
		{
			get { 
				return sdt.gxTpr_Ctalabel;

			}
			set { 
				 sdt.gxTpr_Ctalabel = value;
			}
		}

		[DataMember(Name="CtaAction", Order=3)]
		public  string gxTpr_Ctaaction
		{
			get { 
				return sdt.gxTpr_Ctaaction;

			}
			set { 
				 sdt.gxTpr_Ctaaction = value;
			}
		}

		[DataMember(Name="CtaColor", Order=4)]
		public  string gxTpr_Ctacolor
		{
			get { 
				return sdt.gxTpr_Ctacolor;

			}
			set { 
				 sdt.gxTpr_Ctacolor = value;
			}
		}

		[DataMember(Name="CtaBGColor", Order=5)]
		public  string gxTpr_Ctabgcolor
		{
			get { 
				return sdt.gxTpr_Ctabgcolor;

			}
			set { 
				 sdt.gxTpr_Ctabgcolor = value;
			}
		}

		[DataMember(Name="CtaButtonType", Order=6)]
		public  string gxTpr_Ctabuttontype
		{
			get { 
				return sdt.gxTpr_Ctabuttontype;

			}
			set { 
				 sdt.gxTpr_Ctabuttontype = value;
			}
		}

		[DataMember(Name="CtaButtonImgUrl", Order=7)]
		public  string gxTpr_Ctabuttonimgurl
		{
			get { 
				return sdt.gxTpr_Ctabuttonimgurl;

			}
			set { 
				 sdt.gxTpr_Ctabuttonimgurl = value;
			}
		}


		#endregion

		public SdtSDT_ContentPage_CtaItem sdt
		{
			get { 
				return (SdtSDT_ContentPage_CtaItem)Sdt;
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
				sdt = new SdtSDT_ContentPage_CtaItem() ;
			}
		}
	}
	#endregion
}