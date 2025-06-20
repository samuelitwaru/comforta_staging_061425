/*
				   File: type_SdtSDT_OrganisationDefinitions_ReceptionistDefinition
			Description: ReceptionistDefinition
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
	[XmlRoot(ElementName="SDT_OrganisationDefinitions.ReceptionistDefinition")]
	[XmlType(TypeName="SDT_OrganisationDefinitions.ReceptionistDefinition" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_OrganisationDefinitions_ReceptionistDefinition : GxUserType
	{
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition(IGxContext context)
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
			if (gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English != null)
			{
				AddObjectProperty("english", gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English, false);
			}
			if (gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch != null)
			{
				AddObjectProperty("dutch", gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="english" )]
		[XmlElement(ElementName="english" )]
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition_english gxTpr_English
		{
			get {
				if ( gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English == null )
				{
					gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English = new SdtSDT_OrganisationDefinitions_ReceptionistDefinition_english(context);
				}
				gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English_N = false;
				return gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English;
			}
			set {
				gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English_N = false;
				gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English = value;
				SetDirty("English");
			}

		}

		public void gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English_SetNull()
		{
			gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English_N = true;
			gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English = null;
		}

		public bool gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English_IsNull()
		{
			return gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English == null;
		}
		public bool ShouldSerializegxTpr_English_Json()
		{
				return (gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English != null && gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="dutch" )]
		[XmlElement(ElementName="dutch" )]
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition_dutch gxTpr_Dutch
		{
			get {
				if ( gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch == null )
				{
					gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch = new SdtSDT_OrganisationDefinitions_ReceptionistDefinition_dutch(context);
				}
				gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch_N = false;
				return gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch;
			}
			set {
				gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch_N = false;
				gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch = value;
				SetDirty("Dutch");
			}

		}

		public void gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch_SetNull()
		{
			gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch_N = true;
			gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch = null;
		}

		public bool gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch_IsNull()
		{
			return gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch == null;
		}
		public bool ShouldSerializegxTpr_Dutch_Json()
		{
				return (gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch != null && gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_English_Json() ||
				ShouldSerializegxTpr_Dutch_Json() || 
				false);
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
			gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English_N = true;


			gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English_N;
		protected SdtSDT_OrganisationDefinitions_ReceptionistDefinition_english gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_English = null; 

		protected bool gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch_N;
		protected SdtSDT_OrganisationDefinitions_ReceptionistDefinition_dutch gxTv_SdtSDT_OrganisationDefinitions_ReceptionistDefinition_Dutch = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OrganisationDefinitions.ReceptionistDefinition", Namespace="Comforta_version2")]
	public class SdtSDT_OrganisationDefinitions_ReceptionistDefinition_RESTInterface : GxGenericCollectionItem<SdtSDT_OrganisationDefinitions_ReceptionistDefinition>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition_RESTInterface( SdtSDT_OrganisationDefinitions_ReceptionistDefinition psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="english", Order=0, EmitDefaultValue=false)]
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition_english_RESTInterface gxTpr_English
		{
			get {
				if (sdt.ShouldSerializegxTpr_English_Json())
					return new SdtSDT_OrganisationDefinitions_ReceptionistDefinition_english_RESTInterface(sdt.gxTpr_English);
				else
					return null;

			}

			set {
				sdt.gxTpr_English = value.sdt;
			}

		}

		[DataMember(Name="dutch", Order=1, EmitDefaultValue=false)]
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition_dutch_RESTInterface gxTpr_Dutch
		{
			get {
				if (sdt.ShouldSerializegxTpr_Dutch_Json())
					return new SdtSDT_OrganisationDefinitions_ReceptionistDefinition_dutch_RESTInterface(sdt.gxTpr_Dutch);
				else
					return null;

			}

			set {
				sdt.gxTpr_Dutch = value.sdt;
			}

		}


		#endregion

		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition sdt
		{
			get { 
				return (SdtSDT_OrganisationDefinitions_ReceptionistDefinition)Sdt;
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
				sdt = new SdtSDT_OrganisationDefinitions_ReceptionistDefinition() ;
			}
		}
	}
	#endregion
}