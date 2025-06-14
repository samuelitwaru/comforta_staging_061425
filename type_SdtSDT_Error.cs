/*
				   File: type_SdtSDT_Error
			Description: SDT_Error
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
	[XmlRoot(ElementName="SDT_Error")]
	[XmlType(TypeName="SDT_Error" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_Error : GxUserType
	{
		public SdtSDT_Error( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Error_Status = "";

			gxTv_SdtSDT_Error_Message = "";

		}

		public SdtSDT_Error(IGxContext context)
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
			AddObjectProperty("Status", gxTpr_Status, false);


			AddObjectProperty("Message", gxTpr_Message, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Status")]
		[XmlElement(ElementName="Status")]
		public string gxTpr_Status
		{
			get {
				return gxTv_SdtSDT_Error_Status; 
			}
			set {
				gxTv_SdtSDT_Error_Status = value;
				SetDirty("Status");
			}
		}




		[SoapElement(ElementName="Message")]
		[XmlElement(ElementName="Message")]
		public string gxTpr_Message
		{
			get {
				return gxTv_SdtSDT_Error_Message; 
			}
			set {
				gxTv_SdtSDT_Error_Message = value;
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
			gxTv_SdtSDT_Error_Status = "";
			gxTv_SdtSDT_Error_Message = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_Error_Status;
		 

		protected string gxTv_SdtSDT_Error_Message;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Error", Namespace="Comforta_version21")]
	public class SdtSDT_Error_RESTInterface : GxGenericCollectionItem<SdtSDT_Error>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Error_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Error_RESTInterface( SdtSDT_Error psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Status", Order=0)]
		public  string gxTpr_Status
		{
			get { 
				return sdt.gxTpr_Status;

			}
			set { 
				 sdt.gxTpr_Status = value;
			}
		}

		[DataMember(Name="Message", Order=1)]
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

		public SdtSDT_Error sdt
		{
			get { 
				return (SdtSDT_Error)Sdt;
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
				sdt = new SdtSDT_Error() ;
			}
		}
	}
	#endregion
}