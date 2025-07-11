/*
				   File: type_SdtSDT_DynamicTranslation
			Description: SDT_DynamicTranslation
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
	[XmlRoot(ElementName="SDT_DynamicTranslation")]
	[XmlType(TypeName="SDT_DynamicTranslation" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_DynamicTranslation : GxUserType
	{
		public SdtSDT_DynamicTranslation( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationattributename = "";

			gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationenglish = "";

			gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationdutch = "";

		}

		public SdtSDT_DynamicTranslation(IGxContext context)
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
			AddObjectProperty("SDT_DynamicTranslationPrimaryKey", gxTpr_Sdt_dynamictranslationprimarykey, false);


			AddObjectProperty("SDT_DynamicTranslationAttributeName", gxTpr_Sdt_dynamictranslationattributename, false);


			AddObjectProperty("SDT_DynamicTranslationEnglish", gxTpr_Sdt_dynamictranslationenglish, false);


			AddObjectProperty("SDT_DynamicTranslationDutch", gxTpr_Sdt_dynamictranslationdutch, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SDT_DynamicTranslationPrimaryKey")]
		[XmlElement(ElementName="SDT_DynamicTranslationPrimaryKey")]
		public Guid gxTpr_Sdt_dynamictranslationprimarykey
		{
			get {
				return gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationprimarykey; 
			}
			set {
				gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationprimarykey = value;
				SetDirty("Sdt_dynamictranslationprimarykey");
			}
		}




		[SoapElement(ElementName="SDT_DynamicTranslationAttributeName")]
		[XmlElement(ElementName="SDT_DynamicTranslationAttributeName")]
		public string gxTpr_Sdt_dynamictranslationattributename
		{
			get {
				return gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationattributename; 
			}
			set {
				gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationattributename = value;
				SetDirty("Sdt_dynamictranslationattributename");
			}
		}




		[SoapElement(ElementName="SDT_DynamicTranslationEnglish")]
		[XmlElement(ElementName="SDT_DynamicTranslationEnglish")]
		public string gxTpr_Sdt_dynamictranslationenglish
		{
			get {
				return gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationenglish; 
			}
			set {
				gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationenglish = value;
				SetDirty("Sdt_dynamictranslationenglish");
			}
		}




		[SoapElement(ElementName="SDT_DynamicTranslationDutch")]
		[XmlElement(ElementName="SDT_DynamicTranslationDutch")]
		public string gxTpr_Sdt_dynamictranslationdutch
		{
			get {
				return gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationdutch; 
			}
			set {
				gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationdutch = value;
				SetDirty("Sdt_dynamictranslationdutch");
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
			gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationattributename = "";
			gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationenglish = "";
			gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationdutch = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationprimarykey;
		 

		protected string gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationattributename;
		 

		protected string gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationenglish;
		 

		protected string gxTv_SdtSDT_DynamicTranslation_Sdt_dynamictranslationdutch;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DynamicTranslation", Namespace="Comforta_version2")]
	public class SdtSDT_DynamicTranslation_RESTInterface : GxGenericCollectionItem<SdtSDT_DynamicTranslation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DynamicTranslation_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DynamicTranslation_RESTInterface( SdtSDT_DynamicTranslation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SDT_DynamicTranslationPrimaryKey", Order=0)]
		public Guid gxTpr_Sdt_dynamictranslationprimarykey
		{
			get { 
				return sdt.gxTpr_Sdt_dynamictranslationprimarykey;

			}
			set { 
				sdt.gxTpr_Sdt_dynamictranslationprimarykey = value;
			}
		}

		[DataMember(Name="SDT_DynamicTranslationAttributeName", Order=1)]
		public  string gxTpr_Sdt_dynamictranslationattributename
		{
			get { 
				return sdt.gxTpr_Sdt_dynamictranslationattributename;

			}
			set { 
				 sdt.gxTpr_Sdt_dynamictranslationattributename = value;
			}
		}

		[DataMember(Name="SDT_DynamicTranslationEnglish", Order=2)]
		public  string gxTpr_Sdt_dynamictranslationenglish
		{
			get { 
				return sdt.gxTpr_Sdt_dynamictranslationenglish;

			}
			set { 
				 sdt.gxTpr_Sdt_dynamictranslationenglish = value;
			}
		}

		[DataMember(Name="SDT_DynamicTranslationDutch", Order=3)]
		public  string gxTpr_Sdt_dynamictranslationdutch
		{
			get { 
				return sdt.gxTpr_Sdt_dynamictranslationdutch;

			}
			set { 
				 sdt.gxTpr_Sdt_dynamictranslationdutch = value;
			}
		}


		#endregion

		public SdtSDT_DynamicTranslation sdt
		{
			get { 
				return (SdtSDT_DynamicTranslation)Sdt;
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
				sdt = new SdtSDT_DynamicTranslation() ;
			}
		}
	}
	#endregion
}