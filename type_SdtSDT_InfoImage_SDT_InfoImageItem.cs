/*
				   File: type_SdtSDT_InfoImage_SDT_InfoImageItem
			Description: SDT_InfoImage
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
	[XmlRoot(ElementName="SDT_InfoImageItem")]
	[XmlType(TypeName="SDT_InfoImageItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_InfoImage_SDT_InfoImageItem : GxUserType
	{
		public SdtSDT_InfoImage_SDT_InfoImageItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimageid = "";

			gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimagevalue = "";

		}

		public SdtSDT_InfoImage_SDT_InfoImageItem(IGxContext context)
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
			AddObjectProperty("InfoImageId", gxTpr_Infoimageid, false);


			AddObjectProperty("InfoImageValue", gxTpr_Infoimagevalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="InfoImageId")]
		[XmlElement(ElementName="InfoImageId")]
		public string gxTpr_Infoimageid
		{
			get {
				return gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimageid; 
			}
			set {
				gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimageid = value;
				SetDirty("Infoimageid");
			}
		}




		[SoapElement(ElementName="InfoImageValue")]
		[XmlElement(ElementName="InfoImageValue")]
		public string gxTpr_Infoimagevalue
		{
			get {
				return gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimagevalue; 
			}
			set {
				gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimagevalue = value;
				SetDirty("Infoimagevalue");
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
			gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimageid = "";
			gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimagevalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimageid;
		 

		protected string gxTv_SdtSDT_InfoImage_SDT_InfoImageItem_Infoimagevalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_InfoImageItem", Namespace="Comforta_version21")]
	public class SdtSDT_InfoImage_SDT_InfoImageItem_RESTInterface : GxGenericCollectionItem<SdtSDT_InfoImage_SDT_InfoImageItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_InfoImage_SDT_InfoImageItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_InfoImage_SDT_InfoImageItem_RESTInterface( SdtSDT_InfoImage_SDT_InfoImageItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="InfoImageId", Order=0)]
		public  string gxTpr_Infoimageid
		{
			get { 
				return sdt.gxTpr_Infoimageid;

			}
			set { 
				 sdt.gxTpr_Infoimageid = value;
			}
		}

		[DataMember(Name="InfoImageValue", Order=1)]
		public  string gxTpr_Infoimagevalue
		{
			get { 
				return sdt.gxTpr_Infoimagevalue;

			}
			set { 
				 sdt.gxTpr_Infoimagevalue = value;
			}
		}


		#endregion

		public SdtSDT_InfoImage_SDT_InfoImageItem sdt
		{
			get { 
				return (SdtSDT_InfoImage_SDT_InfoImageItem)Sdt;
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
				sdt = new SdtSDT_InfoImage_SDT_InfoImageItem() ;
			}
		}
	}
	#endregion
}