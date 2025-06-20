/*
				   File: type_SdtSDT_DiscussionTranslation
			Description: SDT_DiscussionTranslation
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
	[XmlRoot(ElementName="SDT_DiscussionTranslation")]
	[XmlType(TypeName="SDT_DiscussionTranslation" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_DiscussionTranslation : GxUserType
	{
		public SdtSDT_DiscussionTranslation( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationvalue = "";

		}

		public SdtSDT_DiscussionTranslation(IGxContext context)
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
			AddObjectProperty("DiscussionTranslationWWPDiscussionMessageId", gxTpr_Discussiontranslationwwpdiscussionmessageid, false);


			AddObjectProperty("DiscussionTranslationValue", gxTpr_Discussiontranslationvalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DiscussionTranslationWWPDiscussionMessageId")]
		[XmlElement(ElementName="DiscussionTranslationWWPDiscussionMessageId")]
		public int gxTpr_Discussiontranslationwwpdiscussionmessageid
		{
			get {
				return gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationwwpdiscussionmessageid; 
			}
			set {
				gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationwwpdiscussionmessageid = value;
				SetDirty("Discussiontranslationwwpdiscussionmessageid");
			}
		}




		[SoapElement(ElementName="DiscussionTranslationValue")]
		[XmlElement(ElementName="DiscussionTranslationValue")]
		public string gxTpr_Discussiontranslationvalue
		{
			get {
				return gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationvalue; 
			}
			set {
				gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationvalue = value;
				SetDirty("Discussiontranslationvalue");
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
			gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationvalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationwwpdiscussionmessageid;
		 

		protected string gxTv_SdtSDT_DiscussionTranslation_Discussiontranslationvalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DiscussionTranslation", Namespace="Comforta_version2")]
	public class SdtSDT_DiscussionTranslation_RESTInterface : GxGenericCollectionItem<SdtSDT_DiscussionTranslation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DiscussionTranslation_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DiscussionTranslation_RESTInterface( SdtSDT_DiscussionTranslation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DiscussionTranslationWWPDiscussionMessageId", Order=0)]
		public int gxTpr_Discussiontranslationwwpdiscussionmessageid
		{
			get { 
				return sdt.gxTpr_Discussiontranslationwwpdiscussionmessageid;

			}
			set { 
				sdt.gxTpr_Discussiontranslationwwpdiscussionmessageid = value;
			}
		}

		[DataMember(Name="DiscussionTranslationValue", Order=1)]
		public  string gxTpr_Discussiontranslationvalue
		{
			get { 
				return sdt.gxTpr_Discussiontranslationvalue;

			}
			set { 
				 sdt.gxTpr_Discussiontranslationvalue = value;
			}
		}


		#endregion

		public SdtSDT_DiscussionTranslation sdt
		{
			get { 
				return (SdtSDT_DiscussionTranslation)Sdt;
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
				sdt = new SdtSDT_DiscussionTranslation() ;
			}
		}
	}
	#endregion
}