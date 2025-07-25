/*
				   File: type_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem
			Description: SDT_LanguageOptions
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
	[XmlRoot(ElementName="SDT_LanguageOptionsItem")]
	[XmlType(TypeName="SDT_LanguageOptionsItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_LanguageOptions_SDT_LanguageOptionsItem : GxUserType
	{
		public SdtSDT_LanguageOptions_SDT_LanguageOptionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Value = "";

			gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Label = "";

		}

		public SdtSDT_LanguageOptions_SDT_LanguageOptionsItem(IGxContext context)
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
			AddObjectProperty("value", gxTpr_Value, false);


			AddObjectProperty("label", gxTpr_Label, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="value")]
		[XmlElement(ElementName="value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Value; 
			}
			set {
				gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="label")]
		[XmlElement(ElementName="label")]
		public string gxTpr_Label
		{
			get {
				return gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Label; 
			}
			set {
				gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Label = value;
				SetDirty("Label");
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
			gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Value = "";
			gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Label = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Value;
		 

		protected string gxTv_SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_Label;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_LanguageOptionsItem", Namespace="Comforta_version2")]
	public class SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_LanguageOptions_SDT_LanguageOptionsItem_RESTInterface( SdtSDT_LanguageOptions_SDT_LanguageOptionsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="value", Order=0)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="label", Order=1)]
		public  string gxTpr_Label
		{
			get { 
				return sdt.gxTpr_Label;

			}
			set { 
				 sdt.gxTpr_Label = value;
			}
		}


		#endregion

		public SdtSDT_LanguageOptions_SDT_LanguageOptionsItem sdt
		{
			get { 
				return (SdtSDT_LanguageOptions_SDT_LanguageOptionsItem)Sdt;
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
				sdt = new SdtSDT_LanguageOptions_SDT_LanguageOptionsItem() ;
			}
		}
	}
	#endregion
}