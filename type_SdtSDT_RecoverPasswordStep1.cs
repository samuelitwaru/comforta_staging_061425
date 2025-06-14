/*
				   File: type_SdtSDT_RecoverPasswordStep1
			Description: SDT_RecoverPasswordStep1
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
	[XmlRoot(ElementName="SDT_RecoverPasswordStep1")]
	[XmlType(TypeName="SDT_RecoverPasswordStep1" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_RecoverPasswordStep1 : GxUserType
	{
		public SdtSDT_RecoverPasswordStep1( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_RecoverPasswordStep1_Success_message = "";

		}

		public SdtSDT_RecoverPasswordStep1(IGxContext context)
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
			AddObjectProperty("success_message", gxTpr_Success_message, false);

			if (gxTv_SdtSDT_RecoverPasswordStep1_Error != null)
			{
				AddObjectProperty("error", gxTv_SdtSDT_RecoverPasswordStep1_Error, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="success_message")]
		[XmlElement(ElementName="success_message")]
		public string gxTpr_Success_message
		{
			get {
				return gxTv_SdtSDT_RecoverPasswordStep1_Success_message; 
			}
			set {
				gxTv_SdtSDT_RecoverPasswordStep1_Success_message = value;
				SetDirty("Success_message");
			}
		}



		[SoapElement(ElementName="error")]
		[XmlElement(ElementName="error")]
		public GeneXus.Programs.SdtSDT_ErrorResponse gxTpr_Error
		{
			get {
				if ( gxTv_SdtSDT_RecoverPasswordStep1_Error == null )
				{
					gxTv_SdtSDT_RecoverPasswordStep1_Error = new GeneXus.Programs.SdtSDT_ErrorResponse(context);
				}
				return gxTv_SdtSDT_RecoverPasswordStep1_Error; 
			}
			set {
				gxTv_SdtSDT_RecoverPasswordStep1_Error = value;
				SetDirty("Error");
			}
		}
		public void gxTv_SdtSDT_RecoverPasswordStep1_Error_SetNull()
		{
			gxTv_SdtSDT_RecoverPasswordStep1_Error_N = true;
			gxTv_SdtSDT_RecoverPasswordStep1_Error = null;
		}

		public bool gxTv_SdtSDT_RecoverPasswordStep1_Error_IsNull()
		{
			return gxTv_SdtSDT_RecoverPasswordStep1_Error == null;
		}
		public bool ShouldSerializegxTpr_Error_Json()
		{
			return gxTv_SdtSDT_RecoverPasswordStep1_Error != null;

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
			gxTv_SdtSDT_RecoverPasswordStep1_Success_message = "";

			gxTv_SdtSDT_RecoverPasswordStep1_Error_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_RecoverPasswordStep1_Success_message;
		 

		protected GeneXus.Programs.SdtSDT_ErrorResponse gxTv_SdtSDT_RecoverPasswordStep1_Error = null;
		protected bool gxTv_SdtSDT_RecoverPasswordStep1_Error_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_RecoverPasswordStep1", Namespace="Comforta_version21")]
	public class SdtSDT_RecoverPasswordStep1_RESTInterface : GxGenericCollectionItem<SdtSDT_RecoverPasswordStep1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_RecoverPasswordStep1_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_RecoverPasswordStep1_RESTInterface( SdtSDT_RecoverPasswordStep1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="success_message", Order=0)]
		public  string gxTpr_Success_message
		{
			get { 
				return sdt.gxTpr_Success_message;

			}
			set { 
				 sdt.gxTpr_Success_message = value;
			}
		}

		[DataMember(Name="error", Order=1, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_ErrorResponse_RESTInterface gxTpr_Error
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Error_Json())
					return new GeneXus.Programs.SdtSDT_ErrorResponse_RESTInterface(sdt.gxTpr_Error);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Error = value.sdt;
			}
		}


		#endregion

		public SdtSDT_RecoverPasswordStep1 sdt
		{
			get { 
				return (SdtSDT_RecoverPasswordStep1)Sdt;
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
				sdt = new SdtSDT_RecoverPasswordStep1() ;
			}
		}
	}
	#endregion
}