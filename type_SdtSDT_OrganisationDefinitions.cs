/*
				   File: type_SdtSDT_OrganisationDefinitions
			Description: SDT_OrganisationDefinitions
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
	[XmlRoot(ElementName="SDT_OrganisationDefinitions")]
	[XmlType(TypeName="SDT_OrganisationDefinitions" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_OrganisationDefinitions : GxUserType
	{
		public SdtSDT_OrganisationDefinitions( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_OrganisationDefinitions(IGxContext context)
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
			if (gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition != null)
			{
				AddObjectProperty("ReceptionistDefinition", gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition, false);
			}
			if (gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition != null)
			{
				AddObjectProperty("ResidentDefinition", gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ReceptionistDefinition" )]
		[XmlElement(ElementName="ReceptionistDefinition" )]
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition gxTpr_Receptionistdefinition
		{
			get {
				if ( gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition == null )
				{
					gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition = new SdtSDT_OrganisationDefinitions_ReceptionistDefinition(context);
				}
				gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition_N = false;
				return gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition;
			}
			set {
				gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition_N = false;
				gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition = value;
				SetDirty("Receptionistdefinition");
			}

		}

		public void gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition_SetNull()
		{
			gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition_N = true;
			gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition = null;
		}

		public bool gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition_IsNull()
		{
			return gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition == null;
		}
		public bool ShouldSerializegxTpr_Receptionistdefinition_Json()
		{
				return (gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition != null && gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="ResidentDefinition" )]
		[XmlElement(ElementName="ResidentDefinition" )]
		public SdtSDT_OrganisationDefinitions_ResidentDefinition gxTpr_Residentdefinition
		{
			get {
				if ( gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition == null )
				{
					gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition = new SdtSDT_OrganisationDefinitions_ResidentDefinition(context);
				}
				gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition_N = false;
				return gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition;
			}
			set {
				gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition_N = false;
				gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition = value;
				SetDirty("Residentdefinition");
			}

		}

		public void gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition_SetNull()
		{
			gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition_N = true;
			gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition = null;
		}

		public bool gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition_IsNull()
		{
			return gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition == null;
		}
		public bool ShouldSerializegxTpr_Residentdefinition_Json()
		{
				return (gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition != null && gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Receptionistdefinition_Json() ||
				ShouldSerializegxTpr_Residentdefinition_Json() || 
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
			gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition_N = true;


			gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition_N;
		protected SdtSDT_OrganisationDefinitions_ReceptionistDefinition gxTv_SdtSDT_OrganisationDefinitions_Receptionistdefinition = null; 

		protected bool gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition_N;
		protected SdtSDT_OrganisationDefinitions_ResidentDefinition gxTv_SdtSDT_OrganisationDefinitions_Residentdefinition = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OrganisationDefinitions", Namespace="Comforta_version21")]
	public class SdtSDT_OrganisationDefinitions_RESTInterface : GxGenericCollectionItem<SdtSDT_OrganisationDefinitions>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OrganisationDefinitions_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OrganisationDefinitions_RESTInterface( SdtSDT_OrganisationDefinitions psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ReceptionistDefinition", Order=0, EmitDefaultValue=false)]
		public SdtSDT_OrganisationDefinitions_ReceptionistDefinition_RESTInterface gxTpr_Receptionistdefinition
		{
			get {
				if (sdt.ShouldSerializegxTpr_Receptionistdefinition_Json())
					return new SdtSDT_OrganisationDefinitions_ReceptionistDefinition_RESTInterface(sdt.gxTpr_Receptionistdefinition);
				else
					return null;

			}

			set {
				sdt.gxTpr_Receptionistdefinition = value.sdt;
			}

		}

		[DataMember(Name="ResidentDefinition", Order=1, EmitDefaultValue=false)]
		public SdtSDT_OrganisationDefinitions_ResidentDefinition_RESTInterface gxTpr_Residentdefinition
		{
			get {
				if (sdt.ShouldSerializegxTpr_Residentdefinition_Json())
					return new SdtSDT_OrganisationDefinitions_ResidentDefinition_RESTInterface(sdt.gxTpr_Residentdefinition);
				else
					return null;

			}

			set {
				sdt.gxTpr_Residentdefinition = value.sdt;
			}

		}


		#endregion

		public SdtSDT_OrganisationDefinitions sdt
		{
			get { 
				return (SdtSDT_OrganisationDefinitions)Sdt;
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
				sdt = new SdtSDT_OrganisationDefinitions() ;
			}
		}
	}
	#endregion
}