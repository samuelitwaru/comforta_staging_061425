/*
				   File: type_SdtSDTLanguageResponseBody
			Description: SDTLanguageResponseBody
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
	[XmlRoot(ElementName="SDTLanguageResponseBody")]
	[XmlType(TypeName="SDTLanguageResponseBody" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDTLanguageResponseBody : GxUserType
	{
		public SdtSDTLanguageResponseBody( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTLanguageResponseBody_Err = "";

			gxTv_SdtSDTLanguageResponseBody_Result = "";

		}

		public SdtSDTLanguageResponseBody(IGxContext context)
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
			AddObjectProperty("err", gxTpr_Err, false);


			AddObjectProperty("result", gxTpr_Result, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="err")]
		[XmlElement(ElementName="err")]
		public string gxTpr_Err
		{
			get {
				return gxTv_SdtSDTLanguageResponseBody_Err; 
			}
			set {
				gxTv_SdtSDTLanguageResponseBody_Err = value;
				SetDirty("Err");
			}
		}




		[SoapElement(ElementName="result")]
		[XmlElement(ElementName="result")]
		public string gxTpr_Result
		{
			get {
				return gxTv_SdtSDTLanguageResponseBody_Result; 
			}
			set {
				gxTv_SdtSDTLanguageResponseBody_Result = value;
				SetDirty("Result");
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
			gxTv_SdtSDTLanguageResponseBody_Err = "";
			gxTv_SdtSDTLanguageResponseBody_Result = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTLanguageResponseBody_Err;
		 

		protected string gxTv_SdtSDTLanguageResponseBody_Result;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTLanguageResponseBody", Namespace="Comforta_version2")]
	public class SdtSDTLanguageResponseBody_RESTInterface : GxGenericCollectionItem<SdtSDTLanguageResponseBody>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTLanguageResponseBody_RESTInterface( ) : base()
		{	
		}

		public SdtSDTLanguageResponseBody_RESTInterface( SdtSDTLanguageResponseBody psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="err", Order=0)]
		public  string gxTpr_Err
		{
			get { 
				return sdt.gxTpr_Err;

			}
			set { 
				 sdt.gxTpr_Err = value;
			}
		}

		[DataMember(Name="result", Order=1)]
		public  string gxTpr_Result
		{
			get { 
				return sdt.gxTpr_Result;

			}
			set { 
				 sdt.gxTpr_Result = value;
			}
		}


		#endregion

		public SdtSDTLanguageResponseBody sdt
		{
			get { 
				return (SdtSDTLanguageResponseBody)Sdt;
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
				sdt = new SdtSDTLanguageResponseBody() ;
			}
		}
	}
	#endregion
}