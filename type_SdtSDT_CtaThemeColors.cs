/*
				   File: type_SdtSDT_CtaThemeColors
			Description: SDT_CtaThemeColors
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
	[XmlRoot(ElementName="SDT_CtaThemeColors")]
	[XmlType(TypeName="SDT_CtaThemeColors" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_CtaThemeColors : GxUserType
	{
		public SdtSDT_CtaThemeColors( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_CtaThemeColors_Ctacolor1 = "";

			gxTv_SdtSDT_CtaThemeColors_Ctacolor2 = "";

			gxTv_SdtSDT_CtaThemeColors_Ctacolor3 = "";

			gxTv_SdtSDT_CtaThemeColors_Ctacolor4 = "";

			gxTv_SdtSDT_CtaThemeColors_Ctacolor5 = "";

			gxTv_SdtSDT_CtaThemeColors_Ctacolor6 = "";

		}

		public SdtSDT_CtaThemeColors(IGxContext context)
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
			AddObjectProperty("ctaColor1", gxTpr_Ctacolor1, false);


			AddObjectProperty("ctaColor2", gxTpr_Ctacolor2, false);


			AddObjectProperty("ctaColor3", gxTpr_Ctacolor3, false);


			AddObjectProperty("ctaColor4", gxTpr_Ctacolor4, false);


			AddObjectProperty("ctaColor5", gxTpr_Ctacolor5, false);


			AddObjectProperty("ctaColor6", gxTpr_Ctacolor6, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ctaColor1")]
		[XmlElement(ElementName="ctaColor1")]
		public string gxTpr_Ctacolor1
		{
			get {
				return gxTv_SdtSDT_CtaThemeColors_Ctacolor1; 
			}
			set {
				gxTv_SdtSDT_CtaThemeColors_Ctacolor1 = value;
				SetDirty("Ctacolor1");
			}
		}




		[SoapElement(ElementName="ctaColor2")]
		[XmlElement(ElementName="ctaColor2")]
		public string gxTpr_Ctacolor2
		{
			get {
				return gxTv_SdtSDT_CtaThemeColors_Ctacolor2; 
			}
			set {
				gxTv_SdtSDT_CtaThemeColors_Ctacolor2 = value;
				SetDirty("Ctacolor2");
			}
		}




		[SoapElement(ElementName="ctaColor3")]
		[XmlElement(ElementName="ctaColor3")]
		public string gxTpr_Ctacolor3
		{
			get {
				return gxTv_SdtSDT_CtaThemeColors_Ctacolor3; 
			}
			set {
				gxTv_SdtSDT_CtaThemeColors_Ctacolor3 = value;
				SetDirty("Ctacolor3");
			}
		}




		[SoapElement(ElementName="ctaColor4")]
		[XmlElement(ElementName="ctaColor4")]
		public string gxTpr_Ctacolor4
		{
			get {
				return gxTv_SdtSDT_CtaThemeColors_Ctacolor4; 
			}
			set {
				gxTv_SdtSDT_CtaThemeColors_Ctacolor4 = value;
				SetDirty("Ctacolor4");
			}
		}




		[SoapElement(ElementName="ctaColor5")]
		[XmlElement(ElementName="ctaColor5")]
		public string gxTpr_Ctacolor5
		{
			get {
				return gxTv_SdtSDT_CtaThemeColors_Ctacolor5; 
			}
			set {
				gxTv_SdtSDT_CtaThemeColors_Ctacolor5 = value;
				SetDirty("Ctacolor5");
			}
		}




		[SoapElement(ElementName="ctaColor6")]
		[XmlElement(ElementName="ctaColor6")]
		public string gxTpr_Ctacolor6
		{
			get {
				return gxTv_SdtSDT_CtaThemeColors_Ctacolor6; 
			}
			set {
				gxTv_SdtSDT_CtaThemeColors_Ctacolor6 = value;
				SetDirty("Ctacolor6");
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
			gxTv_SdtSDT_CtaThemeColors_Ctacolor1 = "";
			gxTv_SdtSDT_CtaThemeColors_Ctacolor2 = "";
			gxTv_SdtSDT_CtaThemeColors_Ctacolor3 = "";
			gxTv_SdtSDT_CtaThemeColors_Ctacolor4 = "";
			gxTv_SdtSDT_CtaThemeColors_Ctacolor5 = "";
			gxTv_SdtSDT_CtaThemeColors_Ctacolor6 = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_CtaThemeColors_Ctacolor1;
		 

		protected string gxTv_SdtSDT_CtaThemeColors_Ctacolor2;
		 

		protected string gxTv_SdtSDT_CtaThemeColors_Ctacolor3;
		 

		protected string gxTv_SdtSDT_CtaThemeColors_Ctacolor4;
		 

		protected string gxTv_SdtSDT_CtaThemeColors_Ctacolor5;
		 

		protected string gxTv_SdtSDT_CtaThemeColors_Ctacolor6;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_CtaThemeColors", Namespace="Comforta_version2")]
	public class SdtSDT_CtaThemeColors_RESTInterface : GxGenericCollectionItem<SdtSDT_CtaThemeColors>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_CtaThemeColors_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_CtaThemeColors_RESTInterface( SdtSDT_CtaThemeColors psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ctaColor1", Order=0)]
		public  string gxTpr_Ctacolor1
		{
			get { 
				return sdt.gxTpr_Ctacolor1;

			}
			set { 
				 sdt.gxTpr_Ctacolor1 = value;
			}
		}

		[DataMember(Name="ctaColor2", Order=1)]
		public  string gxTpr_Ctacolor2
		{
			get { 
				return sdt.gxTpr_Ctacolor2;

			}
			set { 
				 sdt.gxTpr_Ctacolor2 = value;
			}
		}

		[DataMember(Name="ctaColor3", Order=2)]
		public  string gxTpr_Ctacolor3
		{
			get { 
				return sdt.gxTpr_Ctacolor3;

			}
			set { 
				 sdt.gxTpr_Ctacolor3 = value;
			}
		}

		[DataMember(Name="ctaColor4", Order=3)]
		public  string gxTpr_Ctacolor4
		{
			get { 
				return sdt.gxTpr_Ctacolor4;

			}
			set { 
				 sdt.gxTpr_Ctacolor4 = value;
			}
		}

		[DataMember(Name="ctaColor5", Order=4)]
		public  string gxTpr_Ctacolor5
		{
			get { 
				return sdt.gxTpr_Ctacolor5;

			}
			set { 
				 sdt.gxTpr_Ctacolor5 = value;
			}
		}

		[DataMember(Name="ctaColor6", Order=5)]
		public  string gxTpr_Ctacolor6
		{
			get { 
				return sdt.gxTpr_Ctacolor6;

			}
			set { 
				 sdt.gxTpr_Ctacolor6 = value;
			}
		}


		#endregion

		public SdtSDT_CtaThemeColors sdt
		{
			get { 
				return (SdtSDT_CtaThemeColors)Sdt;
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
				sdt = new SdtSDT_CtaThemeColors() ;
			}
		}
	}
	#endregion
}