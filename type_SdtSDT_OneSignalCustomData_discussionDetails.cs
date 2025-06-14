/*
				   File: type_SdtSDT_OneSignalCustomData_discussionDetails
			Description: discussionDetails
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
	[XmlRoot(ElementName="SDT_OneSignalCustomData.discussionDetails")]
	[XmlType(TypeName="SDT_OneSignalCustomData.discussionDetails" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomData_discussionDetails : GxUserType
	{
		public SdtSDT_OneSignalCustomData_discussionDetails( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalCustomData_discussionDetails_Discussionid = "";

		}

		public SdtSDT_OneSignalCustomData_discussionDetails(IGxContext context)
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
			AddObjectProperty("discussionId", gxTpr_Discussionid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="discussionId")]
		[XmlElement(ElementName="discussionId")]
		public string gxTpr_Discussionid
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_discussionDetails_Discussionid; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_discussionDetails_Discussionid = value;
				SetDirty("Discussionid");
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
			gxTv_SdtSDT_OneSignalCustomData_discussionDetails_Discussionid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalCustomData_discussionDetails_Discussionid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomData.discussionDetails", Namespace="Comforta_version21")]
	public class SdtSDT_OneSignalCustomData_discussionDetails_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomData_discussionDetails>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomData_discussionDetails_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomData_discussionDetails_RESTInterface( SdtSDT_OneSignalCustomData_discussionDetails psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="discussionId", Order=0)]
		public  string gxTpr_Discussionid
		{
			get { 
				return sdt.gxTpr_Discussionid;

			}
			set { 
				 sdt.gxTpr_Discussionid = value;
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomData_discussionDetails sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomData_discussionDetails)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomData_discussionDetails() ;
			}
		}
	}
	#endregion
}