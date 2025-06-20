/*
				   File: type_SdtSDT_LinkPage
			Description: SDT_LinkPage
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
	[XmlRoot(ElementName="SDT_LinkPage")]
	[XmlType(TypeName="SDT_LinkPage" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_LinkPage : GxUserType
	{
		public SdtSDT_LinkPage( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_LinkPage_Url = "";

		}

		public SdtSDT_LinkPage(IGxContext context)
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
			AddObjectProperty("Url", gxTpr_Url, false);


			AddObjectProperty("WWPFormId", gxTpr_Wwpformid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Url")]
		[XmlElement(ElementName="Url")]
		public string gxTpr_Url
		{
			get {
				return gxTv_SdtSDT_LinkPage_Url; 
			}
			set {
				gxTv_SdtSDT_LinkPage_Url = value;
				SetDirty("Url");
			}
		}




		[SoapElement(ElementName="WWPFormId")]
		[XmlElement(ElementName="WWPFormId")]
		public short gxTpr_Wwpformid
		{
			get {
				return gxTv_SdtSDT_LinkPage_Wwpformid; 
			}
			set {
				gxTv_SdtSDT_LinkPage_Wwpformid = value;
				SetDirty("Wwpformid");
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
			gxTv_SdtSDT_LinkPage_Url = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_LinkPage_Url;
		 

		protected short gxTv_SdtSDT_LinkPage_Wwpformid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_LinkPage", Namespace="Comforta_version2")]
	public class SdtSDT_LinkPage_RESTInterface : GxGenericCollectionItem<SdtSDT_LinkPage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_LinkPage_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_LinkPage_RESTInterface( SdtSDT_LinkPage psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Url", Order=0)]
		public  string gxTpr_Url
		{
			get { 
				return sdt.gxTpr_Url;

			}
			set { 
				 sdt.gxTpr_Url = value;
			}
		}

		[DataMember(Name="WWPFormId", Order=1)]
		public short gxTpr_Wwpformid
		{
			get { 
				return sdt.gxTpr_Wwpformid;

			}
			set { 
				sdt.gxTpr_Wwpformid = value;
			}
		}


		#endregion

		public SdtSDT_LinkPage sdt
		{
			get { 
				return (SdtSDT_LinkPage)Sdt;
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
				sdt = new SdtSDT_LinkPage() ;
			}
		}
	}
	#endregion
}