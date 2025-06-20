/*
				   File: type_SdtSDT_PageStructure
			Description: SDT_PageStructure
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
	[XmlRoot(ElementName="SDT_PageStructure")]
	[XmlType(TypeName="SDT_PageStructure" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_PageStructure : GxUserType
	{
		public SdtSDT_PageStructure( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PageStructure_Name = "";

		}

		public SdtSDT_PageStructure(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Name", gxTpr_Name, false);

			if (gxTv_SdtSDT_PageStructure_Children != null)
			{
				AddObjectProperty("Children", gxTv_SdtSDT_PageStructure_Children, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public Guid gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_PageStructure_Id; 
			}
			set {
				gxTv_SdtSDT_PageStructure_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDT_PageStructure_Name; 
			}
			set {
				gxTv_SdtSDT_PageStructure_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Children" )]
		[XmlArray(ElementName="Children"  )]
		[XmlArrayItemAttribute(ElementName="ChildrenItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_PageStructure_ChildrenItem> gxTpr_Children
		{
			get {
				if ( gxTv_SdtSDT_PageStructure_Children == null )
				{
					gxTv_SdtSDT_PageStructure_Children = new GXBaseCollection<SdtSDT_PageStructure_ChildrenItem>( context, "SDT_PageStructure.ChildrenItem", "");
				}
				return gxTv_SdtSDT_PageStructure_Children;
			}
			set {
				gxTv_SdtSDT_PageStructure_Children_N = false;
				gxTv_SdtSDT_PageStructure_Children = value;
				SetDirty("Children");
			}
		}

		public void gxTv_SdtSDT_PageStructure_Children_SetNull()
		{
			gxTv_SdtSDT_PageStructure_Children_N = true;
			gxTv_SdtSDT_PageStructure_Children = null;
		}

		public bool gxTv_SdtSDT_PageStructure_Children_IsNull()
		{
			return gxTv_SdtSDT_PageStructure_Children == null;
		}
		public bool ShouldSerializegxTpr_Children_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_PageStructure_Children != null && gxTv_SdtSDT_PageStructure_Children.Count > 0;

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
			gxTv_SdtSDT_PageStructure_Name = "";

			gxTv_SdtSDT_PageStructure_Children_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_PageStructure_Id;
		 

		protected string gxTv_SdtSDT_PageStructure_Name;
		 
		protected bool gxTv_SdtSDT_PageStructure_Children_N;
		protected GXBaseCollection<SdtSDT_PageStructure_ChildrenItem> gxTv_SdtSDT_PageStructure_Children = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_PageStructure", Namespace="Comforta_version2")]
	public class SdtSDT_PageStructure_RESTInterface : GxGenericCollectionItem<SdtSDT_PageStructure>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PageStructure_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PageStructure_RESTInterface( SdtSDT_PageStructure psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public Guid gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Children", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_PageStructure_ChildrenItem_RESTInterface> gxTpr_Children
		{
			get {
				if (sdt.ShouldSerializegxTpr_Children_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_PageStructure_ChildrenItem_RESTInterface>(sdt.gxTpr_Children);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Children);
			}
		}


		#endregion

		public SdtSDT_PageStructure sdt
		{
			get { 
				return (SdtSDT_PageStructure)Sdt;
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
				sdt = new SdtSDT_PageStructure() ;
			}
		}
	}
	#endregion
}