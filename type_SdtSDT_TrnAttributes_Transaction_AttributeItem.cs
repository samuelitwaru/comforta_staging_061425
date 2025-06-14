/*
				   File: type_SdtSDT_TrnAttributes_Transaction_AttributeItem
			Description: Attribute
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
	[XmlRoot(ElementName="SDT_TrnAttributes.Transaction.AttributeItem")]
	[XmlType(TypeName="SDT_TrnAttributes.Transaction.AttributeItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_TrnAttributes_Transaction_AttributeItem : GxUserType
	{
		public SdtSDT_TrnAttributes_Transaction_AttributeItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributename = "";

			gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributevalue = "";

		}

		public SdtSDT_TrnAttributes_Transaction_AttributeItem(IGxContext context)
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
			AddObjectProperty("AttributeName", gxTpr_Attributename, false);


			AddObjectProperty("AttributeValue", gxTpr_Attributevalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AttributeName")]
		[XmlElement(ElementName="AttributeName")]
		public string gxTpr_Attributename
		{
			get {
				return gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributename; 
			}
			set {
				gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributename = value;
				SetDirty("Attributename");
			}
		}




		[SoapElement(ElementName="AttributeValue")]
		[XmlElement(ElementName="AttributeValue")]
		public string gxTpr_Attributevalue
		{
			get {
				return gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributevalue; 
			}
			set {
				gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributevalue = value;
				SetDirty("Attributevalue");
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
			gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributename = "";
			gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributevalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributename;
		 

		protected string gxTv_SdtSDT_TrnAttributes_Transaction_AttributeItem_Attributevalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_TrnAttributes.Transaction.AttributeItem", Namespace="Comforta_version21")]
	public class SdtSDT_TrnAttributes_Transaction_AttributeItem_RESTInterface : GxGenericCollectionItem<SdtSDT_TrnAttributes_Transaction_AttributeItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_TrnAttributes_Transaction_AttributeItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_TrnAttributes_Transaction_AttributeItem_RESTInterface( SdtSDT_TrnAttributes_Transaction_AttributeItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AttributeName", Order=0)]
		public  string gxTpr_Attributename
		{
			get { 
				return sdt.gxTpr_Attributename;

			}
			set { 
				 sdt.gxTpr_Attributename = value;
			}
		}

		[DataMember(Name="AttributeValue", Order=1)]
		public  string gxTpr_Attributevalue
		{
			get { 
				return sdt.gxTpr_Attributevalue;

			}
			set { 
				 sdt.gxTpr_Attributevalue = value;
			}
		}


		#endregion

		public SdtSDT_TrnAttributes_Transaction_AttributeItem sdt
		{
			get { 
				return (SdtSDT_TrnAttributes_Transaction_AttributeItem)Sdt;
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
				sdt = new SdtSDT_TrnAttributes_Transaction_AttributeItem() ;
			}
		}
	}
	#endregion
}