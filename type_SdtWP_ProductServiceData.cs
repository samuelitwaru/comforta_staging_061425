/*
				   File: type_SdtWP_ProductServiceData
			Description: WP_ProductServiceData
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
	[XmlRoot(ElementName="WP_ProductServiceData")]
	[XmlType(TypeName="WP_ProductServiceData" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtWP_ProductServiceData : GxUserType
	{
		public SdtWP_ProductServiceData( )
		{
			/* Constructor for serialization */
		}

		public SdtWP_ProductServiceData(IGxContext context)
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
			if (gxTv_SdtWP_ProductServiceData_Step1 != null)
			{
				AddObjectProperty("Step1", gxTv_SdtWP_ProductServiceData_Step1, false);
			}
			if (gxTv_SdtWP_ProductServiceData_Step2 != null)
			{
				AddObjectProperty("Step2", gxTv_SdtWP_ProductServiceData_Step2, false);
			}
			if (gxTv_SdtWP_ProductServiceData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWP_ProductServiceData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Step1" )]
		[XmlElement(ElementName="Step1" )]
		public SdtWP_ProductServiceData_Step1 gxTpr_Step1
		{
			get {
				if ( gxTv_SdtWP_ProductServiceData_Step1 == null )
				{
					gxTv_SdtWP_ProductServiceData_Step1 = new SdtWP_ProductServiceData_Step1(context);
				}
				gxTv_SdtWP_ProductServiceData_Step1_N = false;
				return gxTv_SdtWP_ProductServiceData_Step1;
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_N = false;
				gxTv_SdtWP_ProductServiceData_Step1 = value;
				SetDirty("Step1");
			}

		}

		public void gxTv_SdtWP_ProductServiceData_Step1_SetNull()
		{
			gxTv_SdtWP_ProductServiceData_Step1_N = true;
			gxTv_SdtWP_ProductServiceData_Step1 = null;
		}

		public bool gxTv_SdtWP_ProductServiceData_Step1_IsNull()
		{
			return gxTv_SdtWP_ProductServiceData_Step1 == null;
		}
		public bool ShouldSerializegxTpr_Step1_Json()
		{
				return (gxTv_SdtWP_ProductServiceData_Step1 != null && gxTv_SdtWP_ProductServiceData_Step1.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Step2" )]
		[XmlElement(ElementName="Step2" )]
		public SdtWP_ProductServiceData_Step2 gxTpr_Step2
		{
			get {
				if ( gxTv_SdtWP_ProductServiceData_Step2 == null )
				{
					gxTv_SdtWP_ProductServiceData_Step2 = new SdtWP_ProductServiceData_Step2(context);
				}
				gxTv_SdtWP_ProductServiceData_Step2_N = false;
				return gxTv_SdtWP_ProductServiceData_Step2;
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_N = false;
				gxTv_SdtWP_ProductServiceData_Step2 = value;
				SetDirty("Step2");
			}

		}

		public void gxTv_SdtWP_ProductServiceData_Step2_SetNull()
		{
			gxTv_SdtWP_ProductServiceData_Step2_N = true;
			gxTv_SdtWP_ProductServiceData_Step2 = null;
		}

		public bool gxTv_SdtWP_ProductServiceData_Step2_IsNull()
		{
			return gxTv_SdtWP_ProductServiceData_Step2 == null;
		}
		public bool ShouldSerializegxTpr_Step2_Json()
		{
				return (gxTv_SdtWP_ProductServiceData_Step2 != null && gxTv_SdtWP_ProductServiceData_Step2.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWP_ProductServiceData_Auxiliardata == null )
				{
					gxTv_SdtWP_ProductServiceData_Auxiliardata = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWP_ProductServiceData_Auxiliardata;
			}
			set {
				gxTv_SdtWP_ProductServiceData_Auxiliardata_N = false;
				gxTv_SdtWP_ProductServiceData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWP_ProductServiceData_Auxiliardata == null )
				{
					gxTv_SdtWP_ProductServiceData_Auxiliardata = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWP_ProductServiceData_Auxiliardata_N = false;
				return gxTv_SdtWP_ProductServiceData_Auxiliardata ;
			}
			set {
				gxTv_SdtWP_ProductServiceData_Auxiliardata_N = false;
				gxTv_SdtWP_ProductServiceData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWP_ProductServiceData_Auxiliardata_SetNull()
		{
			gxTv_SdtWP_ProductServiceData_Auxiliardata_N = true;
			gxTv_SdtWP_ProductServiceData_Auxiliardata = null;
		}

		public bool gxTv_SdtWP_ProductServiceData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWP_ProductServiceData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWP_ProductServiceData_Auxiliardata != null && gxTv_SdtWP_ProductServiceData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Step1_Json() ||
				ShouldSerializegxTpr_Step2_Json() ||
				 ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()||  
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
			gxTv_SdtWP_ProductServiceData_Step1_N = true;


			gxTv_SdtWP_ProductServiceData_Step2_N = true;


			gxTv_SdtWP_ProductServiceData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWP_ProductServiceData_Step1_N;
		protected SdtWP_ProductServiceData_Step1 gxTv_SdtWP_ProductServiceData_Step1 = null; 

		protected bool gxTv_SdtWP_ProductServiceData_Step2_N;
		protected SdtWP_ProductServiceData_Step2 gxTv_SdtWP_ProductServiceData_Step2 = null; 

		protected bool gxTv_SdtWP_ProductServiceData_Auxiliardata_N;
		protected GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWP_ProductServiceData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_ProductServiceData", Namespace="Comforta_version21")]
	public class SdtWP_ProductServiceData_RESTInterface : GxGenericCollectionItem<SdtWP_ProductServiceData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_ProductServiceData_RESTInterface( ) : base()
		{	
		}

		public SdtWP_ProductServiceData_RESTInterface( SdtWP_ProductServiceData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Step1", Order=0, EmitDefaultValue=false)]
		public SdtWP_ProductServiceData_Step1_RESTInterface gxTpr_Step1
		{
			get {
				if (sdt.ShouldSerializegxTpr_Step1_Json())
					return new SdtWP_ProductServiceData_Step1_RESTInterface(sdt.gxTpr_Step1);
				else
					return null;

			}

			set {
				sdt.gxTpr_Step1 = value.sdt;
			}

		}

		[DataMember(Name="Step2", Order=1, EmitDefaultValue=false)]
		public SdtWP_ProductServiceData_Step2_RESTInterface gxTpr_Step2
		{
			get {
				if (sdt.ShouldSerializegxTpr_Step2_Json())
					return new SdtWP_ProductServiceData_Step2_RESTInterface(sdt.gxTpr_Step2);
				else
					return null;

			}

			set {
				sdt.gxTpr_Step2 = value.sdt;
			}

		}

		[DataMember(Name="AuxiliarData", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface> gxTpr_Auxiliardata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json())
					return new GxGenericCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface>(sdt.gxTpr_Auxiliardata);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Auxiliardata);
			}
		}


		#endregion

		public SdtWP_ProductServiceData sdt
		{
			get { 
				return (SdtWP_ProductServiceData)Sdt;
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
				sdt = new SdtWP_ProductServiceData() ;
			}
		}
	}
	#endregion
}