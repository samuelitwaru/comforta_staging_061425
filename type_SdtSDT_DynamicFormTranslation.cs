/*
				   File: type_SdtSDT_DynamicFormTranslation
			Description: SDT_DynamicFormTranslation
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
	[XmlRoot(ElementName="SDT_DynamicFormTranslation")]
	[XmlType(TypeName="SDT_DynamicFormTranslation" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_DynamicFormTranslation : GxUserType
	{
		public SdtSDT_DynamicFormTranslation( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationtrnname = "";

			gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationattributename = "";

			gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationvalue = "";

		}

		public SdtSDT_DynamicFormTranslation(IGxContext context)
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
			AddObjectProperty("DynamicFormTranslationWWpFormId", gxTpr_Dynamicformtranslationwwpformid, false);


			AddObjectProperty("DynamicFormTranslationWWPFormVersionNumber", gxTpr_Dynamicformtranslationwwpformversionnumber, false);


			AddObjectProperty("DynamicFormTranslationWWPFormElementId", gxTpr_Dynamicformtranslationwwpformelementid, false);


			AddObjectProperty("DynamicFormTranslationTrnName", gxTpr_Dynamicformtranslationtrnname, false);


			AddObjectProperty("DynamicFormTranslationAttributeName", gxTpr_Dynamicformtranslationattributename, false);


			AddObjectProperty("DynamicFormTranslationValue", gxTpr_Dynamicformtranslationvalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DynamicFormTranslationWWpFormId")]
		[XmlElement(ElementName="DynamicFormTranslationWWpFormId")]
		public int gxTpr_Dynamicformtranslationwwpformid
		{
			get {
				return gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformid; 
			}
			set {
				gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformid = value;
				SetDirty("Dynamicformtranslationwwpformid");
			}
		}




		[SoapElement(ElementName="DynamicFormTranslationWWPFormVersionNumber")]
		[XmlElement(ElementName="DynamicFormTranslationWWPFormVersionNumber")]
		public int gxTpr_Dynamicformtranslationwwpformversionnumber
		{
			get {
				return gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformversionnumber; 
			}
			set {
				gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformversionnumber = value;
				SetDirty("Dynamicformtranslationwwpformversionnumber");
			}
		}




		[SoapElement(ElementName="DynamicFormTranslationWWPFormElementId")]
		[XmlElement(ElementName="DynamicFormTranslationWWPFormElementId")]
		public int gxTpr_Dynamicformtranslationwwpformelementid
		{
			get {
				return gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformelementid; 
			}
			set {
				gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformelementid = value;
				SetDirty("Dynamicformtranslationwwpformelementid");
			}
		}




		[SoapElement(ElementName="DynamicFormTranslationTrnName")]
		[XmlElement(ElementName="DynamicFormTranslationTrnName")]
		public string gxTpr_Dynamicformtranslationtrnname
		{
			get {
				return gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationtrnname; 
			}
			set {
				gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationtrnname = value;
				SetDirty("Dynamicformtranslationtrnname");
			}
		}




		[SoapElement(ElementName="DynamicFormTranslationAttributeName")]
		[XmlElement(ElementName="DynamicFormTranslationAttributeName")]
		public string gxTpr_Dynamicformtranslationattributename
		{
			get {
				return gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationattributename; 
			}
			set {
				gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationattributename = value;
				SetDirty("Dynamicformtranslationattributename");
			}
		}




		[SoapElement(ElementName="DynamicFormTranslationValue")]
		[XmlElement(ElementName="DynamicFormTranslationValue")]
		public string gxTpr_Dynamicformtranslationvalue
		{
			get {
				return gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationvalue; 
			}
			set {
				gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationvalue = value;
				SetDirty("Dynamicformtranslationvalue");
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
			gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationtrnname = "";
			gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationattributename = "";
			gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationvalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformid;
		 

		protected int gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformversionnumber;
		 

		protected int gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationwwpformelementid;
		 

		protected string gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationtrnname;
		 

		protected string gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationattributename;
		 

		protected string gxTv_SdtSDT_DynamicFormTranslation_Dynamicformtranslationvalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DynamicFormTranslation", Namespace="Comforta_version21")]
	public class SdtSDT_DynamicFormTranslation_RESTInterface : GxGenericCollectionItem<SdtSDT_DynamicFormTranslation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DynamicFormTranslation_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DynamicFormTranslation_RESTInterface( SdtSDT_DynamicFormTranslation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DynamicFormTranslationWWpFormId", Order=0)]
		public int gxTpr_Dynamicformtranslationwwpformid
		{
			get { 
				return sdt.gxTpr_Dynamicformtranslationwwpformid;

			}
			set { 
				sdt.gxTpr_Dynamicformtranslationwwpformid = value;
			}
		}

		[DataMember(Name="DynamicFormTranslationWWPFormVersionNumber", Order=1)]
		public int gxTpr_Dynamicformtranslationwwpformversionnumber
		{
			get { 
				return sdt.gxTpr_Dynamicformtranslationwwpformversionnumber;

			}
			set { 
				sdt.gxTpr_Dynamicformtranslationwwpformversionnumber = value;
			}
		}

		[DataMember(Name="DynamicFormTranslationWWPFormElementId", Order=2)]
		public int gxTpr_Dynamicformtranslationwwpformelementid
		{
			get { 
				return sdt.gxTpr_Dynamicformtranslationwwpformelementid;

			}
			set { 
				sdt.gxTpr_Dynamicformtranslationwwpformelementid = value;
			}
		}

		[DataMember(Name="DynamicFormTranslationTrnName", Order=3)]
		public  string gxTpr_Dynamicformtranslationtrnname
		{
			get { 
				return sdt.gxTpr_Dynamicformtranslationtrnname;

			}
			set { 
				 sdt.gxTpr_Dynamicformtranslationtrnname = value;
			}
		}

		[DataMember(Name="DynamicFormTranslationAttributeName", Order=4)]
		public  string gxTpr_Dynamicformtranslationattributename
		{
			get { 
				return sdt.gxTpr_Dynamicformtranslationattributename;

			}
			set { 
				 sdt.gxTpr_Dynamicformtranslationattributename = value;
			}
		}

		[DataMember(Name="DynamicFormTranslationValue", Order=5)]
		public  string gxTpr_Dynamicformtranslationvalue
		{
			get { 
				return sdt.gxTpr_Dynamicformtranslationvalue;

			}
			set { 
				 sdt.gxTpr_Dynamicformtranslationvalue = value;
			}
		}


		#endregion

		public SdtSDT_DynamicFormTranslation sdt
		{
			get { 
				return (SdtSDT_DynamicFormTranslation)Sdt;
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
				sdt = new SdtSDT_DynamicFormTranslation() ;
			}
		}
	}
	#endregion
}