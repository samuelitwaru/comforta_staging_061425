/*
				   File: type_SdtSDT_AvatarUpload
			Description: SDT_AvatarUpload
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
	[XmlRoot(ElementName="SDT_AvatarUpload")]
	[XmlType(TypeName="SDT_AvatarUpload" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_AvatarUpload : GxUserType
	{
		public SdtSDT_AvatarUpload( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_AvatarUpload_Base64image = "";

		}

		public SdtSDT_AvatarUpload(IGxContext context)
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
			AddObjectProperty("Base64Image", gxTpr_Base64image, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Base64Image")]
		[XmlElement(ElementName="Base64Image")]
		public string gxTpr_Base64image
		{
			get {
				return gxTv_SdtSDT_AvatarUpload_Base64image; 
			}
			set {
				gxTv_SdtSDT_AvatarUpload_Base64image = value;
				SetDirty("Base64image");
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
			gxTv_SdtSDT_AvatarUpload_Base64image = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_AvatarUpload_Base64image;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_AvatarUpload", Namespace="Comforta_version21")]
	public class SdtSDT_AvatarUpload_RESTInterface : GxGenericCollectionItem<SdtSDT_AvatarUpload>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_AvatarUpload_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_AvatarUpload_RESTInterface( SdtSDT_AvatarUpload psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Base64Image", Order=0)]
		public  string gxTpr_Base64image
		{
			get { 
				return sdt.gxTpr_Base64image;

			}
			set { 
				 sdt.gxTpr_Base64image = value;
			}
		}


		#endregion

		public SdtSDT_AvatarUpload sdt
		{
			get { 
				return (SdtSDT_AvatarUpload)Sdt;
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
				sdt = new SdtSDT_AvatarUpload() ;
			}
		}
	}
	#endregion
}