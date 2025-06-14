using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   [XmlRoot(ElementName = "WWP_DiscussionMessageMention" )]
   [XmlType(TypeName =  "WWP_DiscussionMessageMention" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtWWP_DiscussionMessageMention : GxSilentTrnSdt
   {
      public SdtWWP_DiscussionMessageMention( )
      {
      }

      public SdtWWP_DiscussionMessageMention( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( long AV200WWPDiscussionMessageId ,
                        string AV201WWPDiscussionMentionUserId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV200WWPDiscussionMessageId,(string)AV201WWPDiscussionMentionUserId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPDiscussionMessageId", typeof(long)}, new Object[]{"WWPDiscussionMentionUserId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention");
         metadata.Set("BT", "WWP_DiscussionMessageMention");
         metadata.Set("PK", "[ \"WWPDiscussionMessageId\",\"WWPDiscussionMentionUserId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPDiscussionMentionUserId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPDiscussionMessageId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"WWPUserExtendedId\" ],\"FKMap\":[ \"WWPDiscussionMentionUserId-WWPUserExtendedId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpdiscussionmessageid_Z");
         state.Add("gxTpr_Wwpdiscussionmessagedate_Z_Nullable");
         state.Add("gxTpr_Wwpdiscussionmentionuserid_Z");
         state.Add("gxTpr_Wwpdiscussionmentionusername_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention)(source);
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid ;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate ;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid ;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername ;
         gxTv_SdtWWP_DiscussionMessageMention_Mode = sdt.gxTv_SdtWWP_DiscussionMessageMention_Mode ;
         gxTv_SdtWWP_DiscussionMessageMention_Initialized = sdt.gxTv_SdtWWP_DiscussionMessageMention_Initialized ;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z ;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z ;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z ;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("WWPDiscussionMessageId", gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WWPDiscussionMessageDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPDiscussionMentionUserId", gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid, false, includeNonInitialized);
         AddObjectProperty("WWPDiscussionMentionUserName", gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_DiscussionMessageMention_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_DiscussionMessageMention_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMessageId_Z", gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WWPDiscussionMessageDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMentionUserId_Z", gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPDiscussionMentionUserName_Z", gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention sdt )
      {
         if ( sdt.IsDirty("WWPDiscussionMessageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid ;
         }
         if ( sdt.IsDirty("WWPDiscussionMessageDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate ;
         }
         if ( sdt.IsDirty("WWPDiscussionMentionUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid ;
         }
         if ( sdt.IsDirty("WWPDiscussionMentionUserName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername = sdt.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageId" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageId"   )]
      public long gxTpr_Wwpdiscussionmessageid
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid != value )
            {
               gxTv_SdtWWP_DiscussionMessageMention_Mode = "INS";
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z_SetNull( );
            }
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid = value;
            SetDirty("Wwpdiscussionmessageid");
         }

      }

      [  SoapElement( ElementName = "WWPDiscussionMessageDate" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageDate"  , IsNullable=true )]
      public string gxTpr_Wwpdiscussionmessagedate_Nullable
      {
         get {
            if ( gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate = DateTime.MinValue;
            else
               gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpdiscussionmessagedate
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate = value;
            SetDirty("Wwpdiscussionmessagedate");
         }

      }

      [  SoapElement( ElementName = "WWPDiscussionMentionUserId" )]
      [  XmlElement( ElementName = "WWPDiscussionMentionUserId"   )]
      public string gxTpr_Wwpdiscussionmentionuserid
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid, value) != 0 )
            {
               gxTv_SdtWWP_DiscussionMessageMention_Mode = "INS";
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z_SetNull( );
               this.gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z_SetNull( );
            }
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid = value;
            SetDirty("Wwpdiscussionmentionuserid");
         }

      }

      [  SoapElement( ElementName = "WWPDiscussionMentionUserName" )]
      [  XmlElement( ElementName = "WWPDiscussionMentionUserName"   )]
      public string gxTpr_Wwpdiscussionmentionusername
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername = value;
            SetDirty("Wwpdiscussionmentionusername");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessageMention_Mode_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessageMention_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessageMention_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessageMention_Initialized_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessageMention_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessageMention_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageId_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageId_Z"   )]
      public long gxTpr_Wwpdiscussionmessageid_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z = value;
            SetDirty("Wwpdiscussionmessageid_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z = 0;
         SetDirty("Wwpdiscussionmessageid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMessageDate_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMessageDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpdiscussionmessagedate_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpdiscussionmessagedate_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z = value;
            SetDirty("Wwpdiscussionmessagedate_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpdiscussionmessagedate_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMentionUserId_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMentionUserId_Z"   )]
      public string gxTpr_Wwpdiscussionmentionuserid_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z = value;
            SetDirty("Wwpdiscussionmentionuserid_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z = "";
         SetDirty("Wwpdiscussionmentionuserid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPDiscussionMentionUserName_Z" )]
      [  XmlElement( ElementName = "WWPDiscussionMentionUserName_Z"   )]
      public string gxTpr_Wwpdiscussionmentionusername_Z
      {
         get {
            return gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z = value;
            SetDirty("Wwpdiscussionmentionusername_Z");
         }

      }

      public void gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z_SetNull( )
      {
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z = "";
         SetDirty("Wwpdiscussionmentionusername_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid = "";
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername = "";
         gxTv_SdtWWP_DiscussionMessageMention_Mode = "";
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z = "";
         gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.discussions.wwp_discussionmessagemention", "GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtWWP_DiscussionMessageMention_Initialized ;
      private long gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid ;
      private long gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessageid_Z ;
      private string gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid ;
      private string gxTv_SdtWWP_DiscussionMessageMention_Mode ;
      private string gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionuserid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate ;
      private DateTime gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmessagedate_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername ;
      private string gxTv_SdtWWP_DiscussionMessageMention_Wwpdiscussionmentionusername_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\Discussions\WWP_DiscussionMessageMention", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_DiscussionMessageMention_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention>
   {
      public SdtWWP_DiscussionMessageMention_RESTInterface( ) : base()
      {
      }

      public SdtWWP_DiscussionMessageMention_RESTInterface( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPDiscussionMessageId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessageid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Wwpdiscussionmessageid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessageid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "WWPDiscussionMessageDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmessagedate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpdiscussionmessagedate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmessagedate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WWPDiscussionMentionUserId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmentionuserid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpdiscussionmentionuserid) ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmentionuserid = value;
         }

      }

      [DataMember( Name = "WWPDiscussionMentionUserName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmentionusername
      {
         get {
            return sdt.gxTpr_Wwpdiscussionmentionusername ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmentionusername = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"WWPBaseObjects\Discussions\WWP_DiscussionMessageMention", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_DiscussionMessageMention_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention>
   {
      public SdtWWP_DiscussionMessageMention_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_DiscussionMessageMention_RESTLInterface( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPDiscussionMentionUserName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpdiscussionmentionusername
      {
         get {
            return sdt.gxTpr_Wwpdiscussionmentionusername ;
         }

         set {
            sdt.gxTpr_Wwpdiscussionmentionusername = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention() ;
         }
      }

   }

}
