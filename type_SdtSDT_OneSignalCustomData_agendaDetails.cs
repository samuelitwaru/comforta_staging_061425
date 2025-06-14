/*
				   File: type_SdtSDT_OneSignalCustomData_agendaDetails
			Description: agendaDetails
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
	[XmlRoot(ElementName="SDT_OneSignalCustomData.agendaDetails")]
	[XmlType(TypeName="SDT_OneSignalCustomData.agendaDetails" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomData_agendaDetails : GxUserType
	{
		public SdtSDT_OneSignalCustomData_agendaDetails( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_OneSignalCustomData_agendaDetails(IGxContext context)
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
			AddObjectProperty("agendaEventId", gxTpr_Agendaeventid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="agendaEventId")]
		[XmlElement(ElementName="agendaEventId")]
		public Guid gxTpr_Agendaeventid
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_agendaDetails_Agendaeventid; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_agendaDetails_Agendaeventid = value;
				SetDirty("Agendaeventid");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_OneSignalCustomData_agendaDetails_Agendaeventid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomData.agendaDetails", Namespace="Comforta_version21")]
	public class SdtSDT_OneSignalCustomData_agendaDetails_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomData_agendaDetails>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomData_agendaDetails_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomData_agendaDetails_RESTInterface( SdtSDT_OneSignalCustomData_agendaDetails psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="agendaEventId", Order=0)]
		public Guid gxTpr_Agendaeventid
		{
			get { 
				return sdt.gxTpr_Agendaeventid;

			}
			set { 
				sdt.gxTpr_Agendaeventid = value;
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomData_agendaDetails sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomData_agendaDetails)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomData_agendaDetails() ;
			}
		}
	}
	#endregion
}