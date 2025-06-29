/*
				   File: type_SdtSDT_OrganisationDefinitions_ResidentDefinition_english
			Description: english
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
	[XmlRoot(ElementName="SDT_OrganisationDefinitions.ResidentDefinition.english")]
	[XmlType(TypeName="SDT_OrganisationDefinitions.ResidentDefinition.english" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OrganisationDefinitions_ResidentDefinition_english : GxUserType
	{
		public SdtSDT_OrganisationDefinitions_ResidentDefinition_english( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Singular = "";

			gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Plural = "";

		}

		public SdtSDT_OrganisationDefinitions_ResidentDefinition_english(IGxContext context)
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
			AddObjectProperty("singular", gxTpr_Singular, false);


			AddObjectProperty("plural", gxTpr_Plural, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="singular")]
		[XmlElement(ElementName="singular")]
		public string gxTpr_Singular
		{
			get {
				return gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Singular; 
			}
			set {
				gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Singular = value;
				SetDirty("Singular");
			}
		}




		[SoapElement(ElementName="plural")]
		[XmlElement(ElementName="plural")]
		public string gxTpr_Plural
		{
			get {
				return gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Plural; 
			}
			set {
				gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Plural = value;
				SetDirty("Plural");
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
			gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Singular = "";
			gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Plural = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Singular;
		 

		protected string gxTv_SdtSDT_OrganisationDefinitions_ResidentDefinition_english_Plural;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OrganisationDefinitions.ResidentDefinition.english", Namespace="Comforta_version2")]
	public class SdtSDT_OrganisationDefinitions_ResidentDefinition_english_RESTInterface : GxGenericCollectionItem<SdtSDT_OrganisationDefinitions_ResidentDefinition_english>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OrganisationDefinitions_ResidentDefinition_english_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OrganisationDefinitions_ResidentDefinition_english_RESTInterface( SdtSDT_OrganisationDefinitions_ResidentDefinition_english psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="singular", Order=0)]
		public  string gxTpr_Singular
		{
			get { 
				return sdt.gxTpr_Singular;

			}
			set { 
				 sdt.gxTpr_Singular = value;
			}
		}

		[DataMember(Name="plural", Order=1)]
		public  string gxTpr_Plural
		{
			get { 
				return sdt.gxTpr_Plural;

			}
			set { 
				 sdt.gxTpr_Plural = value;
			}
		}


		#endregion

		public SdtSDT_OrganisationDefinitions_ResidentDefinition_english sdt
		{
			get { 
				return (SdtSDT_OrganisationDefinitions_ResidentDefinition_english)Sdt;
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
				sdt = new SdtSDT_OrganisationDefinitions_ResidentDefinition_english() ;
			}
		}
	}
	#endregion
}