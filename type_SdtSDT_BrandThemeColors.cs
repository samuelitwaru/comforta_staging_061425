/*
				   File: type_SdtSDT_BrandThemeColors
			Description: SDT_BrandThemeColors
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
	[XmlRoot(ElementName="SDT_BrandThemeColors")]
	[XmlType(TypeName="SDT_BrandThemeColors" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_BrandThemeColors : GxUserType
	{
		public SdtSDT_BrandThemeColors( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_BrandThemeColors_Accentcolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Backgroundcolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Bordercolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Buttonbgcolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Buttontextcolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Cardbgcolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Cardtextcolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Primarycolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Secondarycolorvalue = "";

			gxTv_SdtSDT_BrandThemeColors_Textcolorvalue = "";

		}

		public SdtSDT_BrandThemeColors(IGxContext context)
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
			AddObjectProperty("accentColorValue", gxTpr_Accentcolorvalue, false);


			AddObjectProperty("backgroundColorValue", gxTpr_Backgroundcolorvalue, false);


			AddObjectProperty("borderColorValue", gxTpr_Bordercolorvalue, false);


			AddObjectProperty("buttonBGColorValue", gxTpr_Buttonbgcolorvalue, false);


			AddObjectProperty("buttonTextColorValue", gxTpr_Buttontextcolorvalue, false);


			AddObjectProperty("cardBgColorValue", gxTpr_Cardbgcolorvalue, false);


			AddObjectProperty("cardTextColorValue", gxTpr_Cardtextcolorvalue, false);


			AddObjectProperty("primaryColorValue", gxTpr_Primarycolorvalue, false);


			AddObjectProperty("secondaryColorValue", gxTpr_Secondarycolorvalue, false);


			AddObjectProperty("textColorValue", gxTpr_Textcolorvalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="accentColorValue")]
		[XmlElement(ElementName="accentColorValue")]
		public string gxTpr_Accentcolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Accentcolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Accentcolorvalue = value;
				SetDirty("Accentcolorvalue");
			}
		}




		[SoapElement(ElementName="backgroundColorValue")]
		[XmlElement(ElementName="backgroundColorValue")]
		public string gxTpr_Backgroundcolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Backgroundcolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Backgroundcolorvalue = value;
				SetDirty("Backgroundcolorvalue");
			}
		}




		[SoapElement(ElementName="borderColorValue")]
		[XmlElement(ElementName="borderColorValue")]
		public string gxTpr_Bordercolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Bordercolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Bordercolorvalue = value;
				SetDirty("Bordercolorvalue");
			}
		}




		[SoapElement(ElementName="buttonBGColorValue")]
		[XmlElement(ElementName="buttonBGColorValue")]
		public string gxTpr_Buttonbgcolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Buttonbgcolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Buttonbgcolorvalue = value;
				SetDirty("Buttonbgcolorvalue");
			}
		}




		[SoapElement(ElementName="buttonTextColorValue")]
		[XmlElement(ElementName="buttonTextColorValue")]
		public string gxTpr_Buttontextcolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Buttontextcolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Buttontextcolorvalue = value;
				SetDirty("Buttontextcolorvalue");
			}
		}




		[SoapElement(ElementName="cardBgColorValue")]
		[XmlElement(ElementName="cardBgColorValue")]
		public string gxTpr_Cardbgcolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Cardbgcolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Cardbgcolorvalue = value;
				SetDirty("Cardbgcolorvalue");
			}
		}




		[SoapElement(ElementName="cardTextColorValue")]
		[XmlElement(ElementName="cardTextColorValue")]
		public string gxTpr_Cardtextcolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Cardtextcolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Cardtextcolorvalue = value;
				SetDirty("Cardtextcolorvalue");
			}
		}




		[SoapElement(ElementName="primaryColorValue")]
		[XmlElement(ElementName="primaryColorValue")]
		public string gxTpr_Primarycolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Primarycolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Primarycolorvalue = value;
				SetDirty("Primarycolorvalue");
			}
		}




		[SoapElement(ElementName="secondaryColorValue")]
		[XmlElement(ElementName="secondaryColorValue")]
		public string gxTpr_Secondarycolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Secondarycolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Secondarycolorvalue = value;
				SetDirty("Secondarycolorvalue");
			}
		}




		[SoapElement(ElementName="textColorValue")]
		[XmlElement(ElementName="textColorValue")]
		public string gxTpr_Textcolorvalue
		{
			get {
				return gxTv_SdtSDT_BrandThemeColors_Textcolorvalue; 
			}
			set {
				gxTv_SdtSDT_BrandThemeColors_Textcolorvalue = value;
				SetDirty("Textcolorvalue");
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
			gxTv_SdtSDT_BrandThemeColors_Accentcolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Backgroundcolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Bordercolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Buttonbgcolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Buttontextcolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Cardbgcolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Cardtextcolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Primarycolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Secondarycolorvalue = "";
			gxTv_SdtSDT_BrandThemeColors_Textcolorvalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_BrandThemeColors_Accentcolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Backgroundcolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Bordercolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Buttonbgcolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Buttontextcolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Cardbgcolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Cardtextcolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Primarycolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Secondarycolorvalue;
		 

		protected string gxTv_SdtSDT_BrandThemeColors_Textcolorvalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_BrandThemeColors", Namespace="Comforta_version2")]
	public class SdtSDT_BrandThemeColors_RESTInterface : GxGenericCollectionItem<SdtSDT_BrandThemeColors>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_BrandThemeColors_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_BrandThemeColors_RESTInterface( SdtSDT_BrandThemeColors psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="accentColorValue", Order=0)]
		public  string gxTpr_Accentcolorvalue
		{
			get { 
				return sdt.gxTpr_Accentcolorvalue;

			}
			set { 
				 sdt.gxTpr_Accentcolorvalue = value;
			}
		}

		[DataMember(Name="backgroundColorValue", Order=1)]
		public  string gxTpr_Backgroundcolorvalue
		{
			get { 
				return sdt.gxTpr_Backgroundcolorvalue;

			}
			set { 
				 sdt.gxTpr_Backgroundcolorvalue = value;
			}
		}

		[DataMember(Name="borderColorValue", Order=2)]
		public  string gxTpr_Bordercolorvalue
		{
			get { 
				return sdt.gxTpr_Bordercolorvalue;

			}
			set { 
				 sdt.gxTpr_Bordercolorvalue = value;
			}
		}

		[DataMember(Name="buttonBGColorValue", Order=3)]
		public  string gxTpr_Buttonbgcolorvalue
		{
			get { 
				return sdt.gxTpr_Buttonbgcolorvalue;

			}
			set { 
				 sdt.gxTpr_Buttonbgcolorvalue = value;
			}
		}

		[DataMember(Name="buttonTextColorValue", Order=4)]
		public  string gxTpr_Buttontextcolorvalue
		{
			get { 
				return sdt.gxTpr_Buttontextcolorvalue;

			}
			set { 
				 sdt.gxTpr_Buttontextcolorvalue = value;
			}
		}

		[DataMember(Name="cardBgColorValue", Order=5)]
		public  string gxTpr_Cardbgcolorvalue
		{
			get { 
				return sdt.gxTpr_Cardbgcolorvalue;

			}
			set { 
				 sdt.gxTpr_Cardbgcolorvalue = value;
			}
		}

		[DataMember(Name="cardTextColorValue", Order=6)]
		public  string gxTpr_Cardtextcolorvalue
		{
			get { 
				return sdt.gxTpr_Cardtextcolorvalue;

			}
			set { 
				 sdt.gxTpr_Cardtextcolorvalue = value;
			}
		}

		[DataMember(Name="primaryColorValue", Order=7)]
		public  string gxTpr_Primarycolorvalue
		{
			get { 
				return sdt.gxTpr_Primarycolorvalue;

			}
			set { 
				 sdt.gxTpr_Primarycolorvalue = value;
			}
		}

		[DataMember(Name="secondaryColorValue", Order=8)]
		public  string gxTpr_Secondarycolorvalue
		{
			get { 
				return sdt.gxTpr_Secondarycolorvalue;

			}
			set { 
				 sdt.gxTpr_Secondarycolorvalue = value;
			}
		}

		[DataMember(Name="textColorValue", Order=9)]
		public  string gxTpr_Textcolorvalue
		{
			get { 
				return sdt.gxTpr_Textcolorvalue;

			}
			set { 
				 sdt.gxTpr_Textcolorvalue = value;
			}
		}


		#endregion

		public SdtSDT_BrandThemeColors sdt
		{
			get { 
				return (SdtSDT_BrandThemeColors)Sdt;
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
				sdt = new SdtSDT_BrandThemeColors() ;
			}
		}
	}
	#endregion
}