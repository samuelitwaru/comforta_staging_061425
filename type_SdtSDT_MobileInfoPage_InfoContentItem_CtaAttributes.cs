/*
				   File: type_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes
			Description: CtaAttributes
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
	[XmlRoot(ElementName="SDT_MobileInfoPage.InfoContentItem.CtaAttributes")]
	[XmlType(TypeName="SDT_MobileInfoPage.InfoContentItem.CtaAttributes" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes : GxUserType
	{
		public SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaid = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctatype = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctalabel = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaaction = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctacolor = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabgcolor = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttontype = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonimgurl = "";

			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonicon = "";

		}

		public SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes(IGxContext context)
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


			AddObjectProperty("CtaButtonIcon", gxTpr_Ctabuttonicon, false);


			AddObjectProperty("CtaSupplierIsConnected", gxTpr_Ctasupplierisconnected, false);


			AddObjectProperty("CtaConnectedSupplierId", gxTpr_Ctaconnectedsupplierid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CtaId")]
		[XmlElement(ElementName="CtaId")]
		public string gxTpr_Ctaid
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaid; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaid = value;
				SetDirty("Ctaid");
			}
		}




		[SoapElement(ElementName="CtaType")]
		[XmlElement(ElementName="CtaType")]
		public string gxTpr_Ctatype
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctatype; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctatype = value;
				SetDirty("Ctatype");
			}
		}




		[SoapElement(ElementName="CtaLabel")]
		[XmlElement(ElementName="CtaLabel")]
		public string gxTpr_Ctalabel
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctalabel; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctalabel = value;
				SetDirty("Ctalabel");
			}
		}




		[SoapElement(ElementName="CtaAction")]
		[XmlElement(ElementName="CtaAction")]
		public string gxTpr_Ctaaction
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaaction; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaaction = value;
				SetDirty("Ctaaction");
			}
		}




		[SoapElement(ElementName="CtaColor")]
		[XmlElement(ElementName="CtaColor")]
		public string gxTpr_Ctacolor
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctacolor; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctacolor = value;
				SetDirty("Ctacolor");
			}
		}




		[SoapElement(ElementName="CtaBGColor")]
		[XmlElement(ElementName="CtaBGColor")]
		public string gxTpr_Ctabgcolor
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabgcolor; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabgcolor = value;
				SetDirty("Ctabgcolor");
			}
		}




		[SoapElement(ElementName="CtaButtonType")]
		[XmlElement(ElementName="CtaButtonType")]
		public string gxTpr_Ctabuttontype
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttontype; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttontype = value;
				SetDirty("Ctabuttontype");
			}
		}




		[SoapElement(ElementName="CtaButtonImgUrl")]
		[XmlElement(ElementName="CtaButtonImgUrl")]
		public string gxTpr_Ctabuttonimgurl
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonimgurl; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonimgurl = value;
				SetDirty("Ctabuttonimgurl");
			}
		}




		[SoapElement(ElementName="CtaButtonIcon")]
		[XmlElement(ElementName="CtaButtonIcon")]
		public string gxTpr_Ctabuttonicon
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonicon; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonicon = value;
				SetDirty("Ctabuttonicon");
			}
		}




		[SoapElement(ElementName="CtaSupplierIsConnected")]
		[XmlElement(ElementName="CtaSupplierIsConnected")]
		public bool gxTpr_Ctasupplierisconnected
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctasupplierisconnected; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctasupplierisconnected = value;
				SetDirty("Ctasupplierisconnected");
			}
		}




		[SoapElement(ElementName="CtaConnectedSupplierId")]
		[XmlElement(ElementName="CtaConnectedSupplierId")]
		public Guid gxTpr_Ctaconnectedsupplierid
		{
			get {
				return gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaconnectedsupplierid; 
			}
			set {
				gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaconnectedsupplierid = value;
				SetDirty("Ctaconnectedsupplierid");
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
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaid = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctatype = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctalabel = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaaction = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctacolor = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabgcolor = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttontype = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonimgurl = "";
			gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonicon = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaid;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctatype;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctalabel;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaaction;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctacolor;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabgcolor;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttontype;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonimgurl;
		 

		protected string gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctabuttonicon;
		 

		protected bool gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctasupplierisconnected;
		 

		protected Guid gxTv_SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_Ctaconnectedsupplierid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_MobileInfoPage.InfoContentItem.CtaAttributes", Namespace="Comforta_version21")]
	public class SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_RESTInterface : GxGenericCollectionItem<SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes_RESTInterface( SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes psdt ) : base(psdt)
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

		[DataMember(Name="CtaButtonIcon", Order=8)]
		public  string gxTpr_Ctabuttonicon
		{
			get { 
				return sdt.gxTpr_Ctabuttonicon;

			}
			set { 
				 sdt.gxTpr_Ctabuttonicon = value;
			}
		}

		[DataMember(Name="CtaSupplierIsConnected", Order=9)]
		public bool gxTpr_Ctasupplierisconnected
		{
			get { 
				return sdt.gxTpr_Ctasupplierisconnected;

			}
			set { 
				sdt.gxTpr_Ctasupplierisconnected = value;
			}
		}

		[DataMember(Name="CtaConnectedSupplierId", Order=10)]
		public Guid gxTpr_Ctaconnectedsupplierid
		{
			get { 
				return sdt.gxTpr_Ctaconnectedsupplierid;

			}
			set { 
				sdt.gxTpr_Ctaconnectedsupplierid = value;
			}
		}


		#endregion

		public SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes sdt
		{
			get { 
				return (SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes)Sdt;
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
				sdt = new SdtSDT_MobileInfoPage_InfoContentItem_CtaAttributes() ;
			}
		}
	}
	#endregion
}