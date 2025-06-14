/*
				   File: type_SdtSDT_ErrorResponse
			Description: SDT_ErrorResponse
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
	[XmlRoot(ElementName="SDT_ErrorResponse")]
	[XmlType(TypeName="SDT_ErrorResponse" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_ErrorResponse : GxUserType
	{
		public SdtSDT_ErrorResponse( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ErrorResponse_Code = "";

			gxTv_SdtSDT_ErrorResponse_Message = "";

		}

		public SdtSDT_ErrorResponse(IGxContext context)
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
			AddObjectProperty("code", gxTpr_Code, false);


			AddObjectProperty("message", gxTpr_Message, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="code")]
		[XmlElement(ElementName="code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtSDT_ErrorResponse_Code; 
			}
			set {
				gxTv_SdtSDT_ErrorResponse_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="message")]
		[XmlElement(ElementName="message")]
		public string gxTpr_Message
		{
			get {
				return gxTv_SdtSDT_ErrorResponse_Message; 
			}
			set {
				gxTv_SdtSDT_ErrorResponse_Message = value;
				SetDirty("Message");
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
			gxTv_SdtSDT_ErrorResponse_Code = "";
			gxTv_SdtSDT_ErrorResponse_Message = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ErrorResponse_Code;
		 

		protected string gxTv_SdtSDT_ErrorResponse_Message;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ErrorResponse", Namespace="Comforta_version21")]
	public class SdtSDT_ErrorResponse_RESTInterface : GxGenericCollectionItem<SdtSDT_ErrorResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ErrorResponse_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ErrorResponse_RESTInterface( SdtSDT_ErrorResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return sdt.gxTpr_Code;

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="message", Order=1)]
		public  string gxTpr_Message
		{
			get { 
				return sdt.gxTpr_Message;

			}
			set { 
				 sdt.gxTpr_Message = value;
			}
		}


		#endregion

		public SdtSDT_ErrorResponse sdt
		{
			get { 
				return (SdtSDT_ErrorResponse)Sdt;
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
				sdt = new SdtSDT_ErrorResponse() ;
			}
		}
	}
	#endregion
}