/*
				   File: type_SdtSDT_TrnAttributes_Transaction
			Description: Transaction
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
	[XmlRoot(ElementName="SDT_TrnAttributes.Transaction")]
	[XmlType(TypeName="SDT_TrnAttributes.Transaction" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_TrnAttributes_Transaction : GxUserType
	{
		public SdtSDT_TrnAttributes_Transaction( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_TrnAttributes_Transaction_Pagetypeapp = "";

		}

		public SdtSDT_TrnAttributes_Transaction(IGxContext context)
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
			AddObjectProperty("PrimaryKeyId", gxTpr_Primarykeyid, false);


			AddObjectProperty("PageTypeApp", gxTpr_Pagetypeapp, false);

			if (gxTv_SdtSDT_TrnAttributes_Transaction_Attribute != null)
			{
				AddObjectProperty("Attribute", gxTv_SdtSDT_TrnAttributes_Transaction_Attribute, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PrimaryKeyId")]
		[XmlElement(ElementName="PrimaryKeyId")]
		public Guid gxTpr_Primarykeyid
		{
			get {
				return gxTv_SdtSDT_TrnAttributes_Transaction_Primarykeyid; 
			}
			set {
				gxTv_SdtSDT_TrnAttributes_Transaction_Primarykeyid = value;
				SetDirty("Primarykeyid");
			}
		}




		[SoapElement(ElementName="PageTypeApp")]
		[XmlElement(ElementName="PageTypeApp")]
		public string gxTpr_Pagetypeapp
		{
			get {
				return gxTv_SdtSDT_TrnAttributes_Transaction_Pagetypeapp; 
			}
			set {
				gxTv_SdtSDT_TrnAttributes_Transaction_Pagetypeapp = value;
				SetDirty("Pagetypeapp");
			}
		}




		[SoapElement(ElementName="Attribute" )]
		[XmlArray(ElementName="Attribute"  )]
		[XmlArrayItemAttribute(ElementName="AttributeItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_TrnAttributes_Transaction_AttributeItem> gxTpr_Attribute
		{
			get {
				if ( gxTv_SdtSDT_TrnAttributes_Transaction_Attribute == null )
				{
					gxTv_SdtSDT_TrnAttributes_Transaction_Attribute = new GXBaseCollection<SdtSDT_TrnAttributes_Transaction_AttributeItem>( context, "SDT_TrnAttributes.Transaction.AttributeItem", "");
				}
				return gxTv_SdtSDT_TrnAttributes_Transaction_Attribute;
			}
			set {
				gxTv_SdtSDT_TrnAttributes_Transaction_Attribute_N = false;
				gxTv_SdtSDT_TrnAttributes_Transaction_Attribute = value;
				SetDirty("Attribute");
			}
		}

		public void gxTv_SdtSDT_TrnAttributes_Transaction_Attribute_SetNull()
		{
			gxTv_SdtSDT_TrnAttributes_Transaction_Attribute_N = true;
			gxTv_SdtSDT_TrnAttributes_Transaction_Attribute = null;
		}

		public bool gxTv_SdtSDT_TrnAttributes_Transaction_Attribute_IsNull()
		{
			return gxTv_SdtSDT_TrnAttributes_Transaction_Attribute == null;
		}
		public bool ShouldSerializegxTpr_Attribute_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_TrnAttributes_Transaction_Attribute != null && gxTv_SdtSDT_TrnAttributes_Transaction_Attribute.Count > 0;

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
			gxTv_SdtSDT_TrnAttributes_Transaction_Pagetypeapp = "";

			gxTv_SdtSDT_TrnAttributes_Transaction_Attribute_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_TrnAttributes_Transaction_Primarykeyid;
		 

		protected string gxTv_SdtSDT_TrnAttributes_Transaction_Pagetypeapp;
		 
		protected bool gxTv_SdtSDT_TrnAttributes_Transaction_Attribute_N;
		protected GXBaseCollection<SdtSDT_TrnAttributes_Transaction_AttributeItem> gxTv_SdtSDT_TrnAttributes_Transaction_Attribute = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_TrnAttributes.Transaction", Namespace="Comforta_version21")]
	public class SdtSDT_TrnAttributes_Transaction_RESTInterface : GxGenericCollectionItem<SdtSDT_TrnAttributes_Transaction>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_TrnAttributes_Transaction_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_TrnAttributes_Transaction_RESTInterface( SdtSDT_TrnAttributes_Transaction psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PrimaryKeyId", Order=0)]
		public Guid gxTpr_Primarykeyid
		{
			get { 
				return sdt.gxTpr_Primarykeyid;

			}
			set { 
				sdt.gxTpr_Primarykeyid = value;
			}
		}

		[DataMember(Name="PageTypeApp", Order=1)]
		public  string gxTpr_Pagetypeapp
		{
			get { 
				return sdt.gxTpr_Pagetypeapp;

			}
			set { 
				 sdt.gxTpr_Pagetypeapp = value;
			}
		}

		[DataMember(Name="Attribute", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_TrnAttributes_Transaction_AttributeItem_RESTInterface> gxTpr_Attribute
		{
			get {
				if (sdt.ShouldSerializegxTpr_Attribute_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_TrnAttributes_Transaction_AttributeItem_RESTInterface>(sdt.gxTpr_Attribute);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Attribute);
			}
		}


		#endregion

		public SdtSDT_TrnAttributes_Transaction sdt
		{
			get { 
				return (SdtSDT_TrnAttributes_Transaction)Sdt;
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
				sdt = new SdtSDT_TrnAttributes_Transaction() ;
			}
		}
	}
	#endregion
}