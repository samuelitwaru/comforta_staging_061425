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
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Trn_Media" )]
   [XmlType(TypeName =  "Trn_Media" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Media : GxSilentTrnSdt
   {
      public SdtTrn_Media( )
      {
      }

      public SdtTrn_Media( IGxContext context )
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

      public void Load( Guid AV413MediaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV413MediaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MediaId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Media");
         metadata.Set("BT", "Trn_Media");
         metadata.Set("PK", "[ \"MediaId\" ]");
         metadata.Set("PKAssigned", "[ \"MediaId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mediaimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Mediaid_Z");
         state.Add("gxTpr_Medianame_Z");
         state.Add("gxTpr_Mediasize_Z");
         state.Add("gxTpr_Mediatype_Z");
         state.Add("gxTpr_Mediadatetime_Z_Nullable");
         state.Add("gxTpr_Mediaurl_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Iscropped_Z");
         state.Add("gxTpr_Croppedoriginalmediaid_Z");
         state.Add("gxTpr_Mediaimage_gxi_Z");
         state.Add("gxTpr_Mediaimage_N");
         state.Add("gxTpr_Mediadatetime_N");
         state.Add("gxTpr_Croppedoriginalmediaid_N");
         state.Add("gxTpr_Mediaimage_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Media sdt;
         sdt = (SdtTrn_Media)(source);
         gxTv_SdtTrn_Media_Mediaid = sdt.gxTv_SdtTrn_Media_Mediaid ;
         gxTv_SdtTrn_Media_Medianame = sdt.gxTv_SdtTrn_Media_Medianame ;
         gxTv_SdtTrn_Media_Mediaimage = sdt.gxTv_SdtTrn_Media_Mediaimage ;
         gxTv_SdtTrn_Media_Mediaimage_gxi = sdt.gxTv_SdtTrn_Media_Mediaimage_gxi ;
         gxTv_SdtTrn_Media_Mediasize = sdt.gxTv_SdtTrn_Media_Mediasize ;
         gxTv_SdtTrn_Media_Mediatype = sdt.gxTv_SdtTrn_Media_Mediatype ;
         gxTv_SdtTrn_Media_Mediadatetime = sdt.gxTv_SdtTrn_Media_Mediadatetime ;
         gxTv_SdtTrn_Media_Mediaurl = sdt.gxTv_SdtTrn_Media_Mediaurl ;
         gxTv_SdtTrn_Media_Locationid = sdt.gxTv_SdtTrn_Media_Locationid ;
         gxTv_SdtTrn_Media_Iscropped = sdt.gxTv_SdtTrn_Media_Iscropped ;
         gxTv_SdtTrn_Media_Croppedoriginalmediaid = sdt.gxTv_SdtTrn_Media_Croppedoriginalmediaid ;
         gxTv_SdtTrn_Media_Mode = sdt.gxTv_SdtTrn_Media_Mode ;
         gxTv_SdtTrn_Media_Initialized = sdt.gxTv_SdtTrn_Media_Initialized ;
         gxTv_SdtTrn_Media_Mediaid_Z = sdt.gxTv_SdtTrn_Media_Mediaid_Z ;
         gxTv_SdtTrn_Media_Medianame_Z = sdt.gxTv_SdtTrn_Media_Medianame_Z ;
         gxTv_SdtTrn_Media_Mediasize_Z = sdt.gxTv_SdtTrn_Media_Mediasize_Z ;
         gxTv_SdtTrn_Media_Mediatype_Z = sdt.gxTv_SdtTrn_Media_Mediatype_Z ;
         gxTv_SdtTrn_Media_Mediadatetime_Z = sdt.gxTv_SdtTrn_Media_Mediadatetime_Z ;
         gxTv_SdtTrn_Media_Mediaurl_Z = sdt.gxTv_SdtTrn_Media_Mediaurl_Z ;
         gxTv_SdtTrn_Media_Locationid_Z = sdt.gxTv_SdtTrn_Media_Locationid_Z ;
         gxTv_SdtTrn_Media_Iscropped_Z = sdt.gxTv_SdtTrn_Media_Iscropped_Z ;
         gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z = sdt.gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z ;
         gxTv_SdtTrn_Media_Mediaimage_gxi_Z = sdt.gxTv_SdtTrn_Media_Mediaimage_gxi_Z ;
         gxTv_SdtTrn_Media_Mediaimage_N = sdt.gxTv_SdtTrn_Media_Mediaimage_N ;
         gxTv_SdtTrn_Media_Mediadatetime_N = sdt.gxTv_SdtTrn_Media_Mediadatetime_N ;
         gxTv_SdtTrn_Media_Croppedoriginalmediaid_N = sdt.gxTv_SdtTrn_Media_Croppedoriginalmediaid_N ;
         gxTv_SdtTrn_Media_Mediaimage_gxi_N = sdt.gxTv_SdtTrn_Media_Mediaimage_gxi_N ;
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
         AddObjectProperty("MediaId", gxTv_SdtTrn_Media_Mediaid, false, includeNonInitialized);
         AddObjectProperty("MediaName", gxTv_SdtTrn_Media_Medianame, false, includeNonInitialized);
         AddObjectProperty("MediaImage", gxTv_SdtTrn_Media_Mediaimage, false, includeNonInitialized);
         AddObjectProperty("MediaImage_N", gxTv_SdtTrn_Media_Mediaimage_N, false, includeNonInitialized);
         AddObjectProperty("MediaSize", gxTv_SdtTrn_Media_Mediasize, false, includeNonInitialized);
         AddObjectProperty("MediaType", gxTv_SdtTrn_Media_Mediatype, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_Media_Mediadatetime;
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
         AddObjectProperty("MediaDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MediaDateTime_N", gxTv_SdtTrn_Media_Mediadatetime_N, false, includeNonInitialized);
         AddObjectProperty("MediaUrl", gxTv_SdtTrn_Media_Mediaurl, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_Media_Locationid, false, includeNonInitialized);
         AddObjectProperty("IsCropped", gxTv_SdtTrn_Media_Iscropped, false, includeNonInitialized);
         AddObjectProperty("CroppedOriginalMediaId", gxTv_SdtTrn_Media_Croppedoriginalmediaid, false, includeNonInitialized);
         AddObjectProperty("CroppedOriginalMediaId_N", gxTv_SdtTrn_Media_Croppedoriginalmediaid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("MediaImage_GXI", gxTv_SdtTrn_Media_Mediaimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_Media_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Media_Initialized, false, includeNonInitialized);
            AddObjectProperty("MediaId_Z", gxTv_SdtTrn_Media_Mediaid_Z, false, includeNonInitialized);
            AddObjectProperty("MediaName_Z", gxTv_SdtTrn_Media_Medianame_Z, false, includeNonInitialized);
            AddObjectProperty("MediaSize_Z", gxTv_SdtTrn_Media_Mediasize_Z, false, includeNonInitialized);
            AddObjectProperty("MediaType_Z", gxTv_SdtTrn_Media_Mediatype_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_Media_Mediadatetime_Z;
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
            AddObjectProperty("MediaDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("MediaUrl_Z", gxTv_SdtTrn_Media_Mediaurl_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Media_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("IsCropped_Z", gxTv_SdtTrn_Media_Iscropped_Z, false, includeNonInitialized);
            AddObjectProperty("CroppedOriginalMediaId_Z", gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z, false, includeNonInitialized);
            AddObjectProperty("MediaImage_GXI_Z", gxTv_SdtTrn_Media_Mediaimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("MediaImage_N", gxTv_SdtTrn_Media_Mediaimage_N, false, includeNonInitialized);
            AddObjectProperty("MediaDateTime_N", gxTv_SdtTrn_Media_Mediadatetime_N, false, includeNonInitialized);
            AddObjectProperty("CroppedOriginalMediaId_N", gxTv_SdtTrn_Media_Croppedoriginalmediaid_N, false, includeNonInitialized);
            AddObjectProperty("MediaImage_GXI_N", gxTv_SdtTrn_Media_Mediaimage_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Media sdt )
      {
         if ( sdt.IsDirty("MediaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaid = sdt.gxTv_SdtTrn_Media_Mediaid ;
         }
         if ( sdt.IsDirty("MediaName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Medianame = sdt.gxTv_SdtTrn_Media_Medianame ;
         }
         if ( sdt.IsDirty("MediaImage") )
         {
            gxTv_SdtTrn_Media_Mediaimage_N = (short)(sdt.gxTv_SdtTrn_Media_Mediaimage_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaimage = sdt.gxTv_SdtTrn_Media_Mediaimage ;
         }
         if ( sdt.IsDirty("MediaImage") )
         {
            gxTv_SdtTrn_Media_Mediaimage_gxi_N = (short)(sdt.gxTv_SdtTrn_Media_Mediaimage_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaimage_gxi = sdt.gxTv_SdtTrn_Media_Mediaimage_gxi ;
         }
         if ( sdt.IsDirty("MediaSize") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediasize = sdt.gxTv_SdtTrn_Media_Mediasize ;
         }
         if ( sdt.IsDirty("MediaType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediatype = sdt.gxTv_SdtTrn_Media_Mediatype ;
         }
         if ( sdt.IsDirty("MediaDateTime") )
         {
            gxTv_SdtTrn_Media_Mediadatetime_N = (short)(sdt.gxTv_SdtTrn_Media_Mediadatetime_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediadatetime = sdt.gxTv_SdtTrn_Media_Mediadatetime ;
         }
         if ( sdt.IsDirty("MediaUrl") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaurl = sdt.gxTv_SdtTrn_Media_Mediaurl ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Locationid = sdt.gxTv_SdtTrn_Media_Locationid ;
         }
         if ( sdt.IsDirty("IsCropped") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Iscropped = sdt.gxTv_SdtTrn_Media_Iscropped ;
         }
         if ( sdt.IsDirty("CroppedOriginalMediaId") )
         {
            gxTv_SdtTrn_Media_Croppedoriginalmediaid_N = (short)(sdt.gxTv_SdtTrn_Media_Croppedoriginalmediaid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Croppedoriginalmediaid = sdt.gxTv_SdtTrn_Media_Croppedoriginalmediaid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MediaId" )]
      [  XmlElement( ElementName = "MediaId"   )]
      public Guid gxTpr_Mediaid
      {
         get {
            return gxTv_SdtTrn_Media_Mediaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Media_Mediaid != value )
            {
               gxTv_SdtTrn_Media_Mode = "INS";
               this.gxTv_SdtTrn_Media_Mediaid_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Medianame_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Mediasize_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Mediatype_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Mediadatetime_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Mediaurl_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Iscropped_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z_SetNull( );
               this.gxTv_SdtTrn_Media_Mediaimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Media_Mediaid = value;
            SetDirty("Mediaid");
         }

      }

      [  SoapElement( ElementName = "MediaName" )]
      [  XmlElement( ElementName = "MediaName"   )]
      public string gxTpr_Medianame
      {
         get {
            return gxTv_SdtTrn_Media_Medianame ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Medianame = value;
            SetDirty("Medianame");
         }

      }

      [  SoapElement( ElementName = "MediaImage" )]
      [  XmlElement( ElementName = "MediaImage"   )]
      [GxUpload()]
      public string gxTpr_Mediaimage
      {
         get {
            return gxTv_SdtTrn_Media_Mediaimage ;
         }

         set {
            gxTv_SdtTrn_Media_Mediaimage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaimage = value;
            SetDirty("Mediaimage");
         }

      }

      public void gxTv_SdtTrn_Media_Mediaimage_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediaimage_N = 1;
         gxTv_SdtTrn_Media_Mediaimage = "";
         SetDirty("Mediaimage");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediaimage_IsNull( )
      {
         return (gxTv_SdtTrn_Media_Mediaimage_N==1) ;
      }

      [  SoapElement( ElementName = "MediaImage_GXI" )]
      [  XmlElement( ElementName = "MediaImage_GXI"   )]
      public string gxTpr_Mediaimage_gxi
      {
         get {
            return gxTv_SdtTrn_Media_Mediaimage_gxi ;
         }

         set {
            gxTv_SdtTrn_Media_Mediaimage_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaimage_gxi = value;
            SetDirty("Mediaimage_gxi");
         }

      }

      public void gxTv_SdtTrn_Media_Mediaimage_gxi_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediaimage_gxi_N = 1;
         gxTv_SdtTrn_Media_Mediaimage_gxi = "";
         SetDirty("Mediaimage_gxi");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediaimage_gxi_IsNull( )
      {
         return (gxTv_SdtTrn_Media_Mediaimage_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "MediaSize" )]
      [  XmlElement( ElementName = "MediaSize"   )]
      public int gxTpr_Mediasize
      {
         get {
            return gxTv_SdtTrn_Media_Mediasize ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediasize = value;
            SetDirty("Mediasize");
         }

      }

      [  SoapElement( ElementName = "MediaType" )]
      [  XmlElement( ElementName = "MediaType"   )]
      public string gxTpr_Mediatype
      {
         get {
            return gxTv_SdtTrn_Media_Mediatype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediatype = value;
            SetDirty("Mediatype");
         }

      }

      [  SoapElement( ElementName = "MediaDateTime" )]
      [  XmlElement( ElementName = "MediaDateTime"  , IsNullable=true )]
      public string gxTpr_Mediadatetime_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Media_Mediadatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Media_Mediadatetime).value ;
         }

         set {
            gxTv_SdtTrn_Media_Mediadatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Media_Mediadatetime = DateTime.MinValue;
            else
               gxTv_SdtTrn_Media_Mediadatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Mediadatetime
      {
         get {
            return gxTv_SdtTrn_Media_Mediadatetime ;
         }

         set {
            gxTv_SdtTrn_Media_Mediadatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediadatetime = value;
            SetDirty("Mediadatetime");
         }

      }

      public void gxTv_SdtTrn_Media_Mediadatetime_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediadatetime_N = 1;
         gxTv_SdtTrn_Media_Mediadatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Mediadatetime");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediadatetime_IsNull( )
      {
         return (gxTv_SdtTrn_Media_Mediadatetime_N==1) ;
      }

      [  SoapElement( ElementName = "MediaUrl" )]
      [  XmlElement( ElementName = "MediaUrl"   )]
      public string gxTpr_Mediaurl
      {
         get {
            return gxTv_SdtTrn_Media_Mediaurl ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaurl = value;
            SetDirty("Mediaurl");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Media_Locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "IsCropped" )]
      [  XmlElement( ElementName = "IsCropped"   )]
      public bool gxTpr_Iscropped
      {
         get {
            return gxTv_SdtTrn_Media_Iscropped ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Iscropped = value;
            SetDirty("Iscropped");
         }

      }

      [  SoapElement( ElementName = "CroppedOriginalMediaId" )]
      [  XmlElement( ElementName = "CroppedOriginalMediaId"   )]
      public Guid gxTpr_Croppedoriginalmediaid
      {
         get {
            return gxTv_SdtTrn_Media_Croppedoriginalmediaid ;
         }

         set {
            gxTv_SdtTrn_Media_Croppedoriginalmediaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Croppedoriginalmediaid = value;
            SetDirty("Croppedoriginalmediaid");
         }

      }

      public void gxTv_SdtTrn_Media_Croppedoriginalmediaid_SetNull( )
      {
         gxTv_SdtTrn_Media_Croppedoriginalmediaid_N = 1;
         gxTv_SdtTrn_Media_Croppedoriginalmediaid = Guid.Empty;
         SetDirty("Croppedoriginalmediaid");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Croppedoriginalmediaid_IsNull( )
      {
         return (gxTv_SdtTrn_Media_Croppedoriginalmediaid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Media_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Media_Mode_SetNull( )
      {
         gxTv_SdtTrn_Media_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Media_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Media_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Media_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaId_Z" )]
      [  XmlElement( ElementName = "MediaId_Z"   )]
      public Guid gxTpr_Mediaid_Z
      {
         get {
            return gxTv_SdtTrn_Media_Mediaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaid_Z = value;
            SetDirty("Mediaid_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Mediaid_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediaid_Z = Guid.Empty;
         SetDirty("Mediaid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaName_Z" )]
      [  XmlElement( ElementName = "MediaName_Z"   )]
      public string gxTpr_Medianame_Z
      {
         get {
            return gxTv_SdtTrn_Media_Medianame_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Medianame_Z = value;
            SetDirty("Medianame_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Medianame_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Medianame_Z = "";
         SetDirty("Medianame_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Medianame_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaSize_Z" )]
      [  XmlElement( ElementName = "MediaSize_Z"   )]
      public int gxTpr_Mediasize_Z
      {
         get {
            return gxTv_SdtTrn_Media_Mediasize_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediasize_Z = value;
            SetDirty("Mediasize_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Mediasize_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediasize_Z = 0;
         SetDirty("Mediasize_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediasize_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaType_Z" )]
      [  XmlElement( ElementName = "MediaType_Z"   )]
      public string gxTpr_Mediatype_Z
      {
         get {
            return gxTv_SdtTrn_Media_Mediatype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediatype_Z = value;
            SetDirty("Mediatype_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Mediatype_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediatype_Z = "";
         SetDirty("Mediatype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediatype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaDateTime_Z" )]
      [  XmlElement( ElementName = "MediaDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Mediadatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Media_Mediadatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Media_Mediadatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Media_Mediadatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Media_Mediadatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Mediadatetime_Z
      {
         get {
            return gxTv_SdtTrn_Media_Mediadatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediadatetime_Z = value;
            SetDirty("Mediadatetime_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Mediadatetime_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediadatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Mediadatetime_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediadatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaUrl_Z" )]
      [  XmlElement( ElementName = "MediaUrl_Z"   )]
      public string gxTpr_Mediaurl_Z
      {
         get {
            return gxTv_SdtTrn_Media_Mediaurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaurl_Z = value;
            SetDirty("Mediaurl_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Mediaurl_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediaurl_Z = "";
         SetDirty("Mediaurl_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediaurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Media_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IsCropped_Z" )]
      [  XmlElement( ElementName = "IsCropped_Z"   )]
      public bool gxTpr_Iscropped_Z
      {
         get {
            return gxTv_SdtTrn_Media_Iscropped_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Iscropped_Z = value;
            SetDirty("Iscropped_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Iscropped_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Iscropped_Z = false;
         SetDirty("Iscropped_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Iscropped_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CroppedOriginalMediaId_Z" )]
      [  XmlElement( ElementName = "CroppedOriginalMediaId_Z"   )]
      public Guid gxTpr_Croppedoriginalmediaid_Z
      {
         get {
            return gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z = value;
            SetDirty("Croppedoriginalmediaid_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z = Guid.Empty;
         SetDirty("Croppedoriginalmediaid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaImage_GXI_Z" )]
      [  XmlElement( ElementName = "MediaImage_GXI_Z"   )]
      public string gxTpr_Mediaimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_Media_Mediaimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaimage_gxi_Z = value;
            SetDirty("Mediaimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_Media_Mediaimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediaimage_gxi_Z = "";
         SetDirty("Mediaimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediaimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaImage_N" )]
      [  XmlElement( ElementName = "MediaImage_N"   )]
      public short gxTpr_Mediaimage_N
      {
         get {
            return gxTv_SdtTrn_Media_Mediaimage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaimage_N = value;
            SetDirty("Mediaimage_N");
         }

      }

      public void gxTv_SdtTrn_Media_Mediaimage_N_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediaimage_N = 0;
         SetDirty("Mediaimage_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediaimage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaDateTime_N" )]
      [  XmlElement( ElementName = "MediaDateTime_N"   )]
      public short gxTpr_Mediadatetime_N
      {
         get {
            return gxTv_SdtTrn_Media_Mediadatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediadatetime_N = value;
            SetDirty("Mediadatetime_N");
         }

      }

      public void gxTv_SdtTrn_Media_Mediadatetime_N_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediadatetime_N = 0;
         SetDirty("Mediadatetime_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediadatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CroppedOriginalMediaId_N" )]
      [  XmlElement( ElementName = "CroppedOriginalMediaId_N"   )]
      public short gxTpr_Croppedoriginalmediaid_N
      {
         get {
            return gxTv_SdtTrn_Media_Croppedoriginalmediaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Croppedoriginalmediaid_N = value;
            SetDirty("Croppedoriginalmediaid_N");
         }

      }

      public void gxTv_SdtTrn_Media_Croppedoriginalmediaid_N_SetNull( )
      {
         gxTv_SdtTrn_Media_Croppedoriginalmediaid_N = 0;
         SetDirty("Croppedoriginalmediaid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Croppedoriginalmediaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaImage_GXI_N" )]
      [  XmlElement( ElementName = "MediaImage_GXI_N"   )]
      public short gxTpr_Mediaimage_gxi_N
      {
         get {
            return gxTv_SdtTrn_Media_Mediaimage_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Media_Mediaimage_gxi_N = value;
            SetDirty("Mediaimage_gxi_N");
         }

      }

      public void gxTv_SdtTrn_Media_Mediaimage_gxi_N_SetNull( )
      {
         gxTv_SdtTrn_Media_Mediaimage_gxi_N = 0;
         SetDirty("Mediaimage_gxi_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Media_Mediaimage_gxi_N_IsNull( )
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
         gxTv_SdtTrn_Media_Mediaid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Media_Medianame = "";
         gxTv_SdtTrn_Media_Mediaimage = "";
         gxTv_SdtTrn_Media_Mediaimage_gxi = "";
         gxTv_SdtTrn_Media_Mediatype = "";
         gxTv_SdtTrn_Media_Mediadatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Media_Mediaurl = "";
         gxTv_SdtTrn_Media_Locationid = Guid.Empty;
         gxTv_SdtTrn_Media_Croppedoriginalmediaid = Guid.Empty;
         gxTv_SdtTrn_Media_Mode = "";
         gxTv_SdtTrn_Media_Mediaid_Z = Guid.Empty;
         gxTv_SdtTrn_Media_Medianame_Z = "";
         gxTv_SdtTrn_Media_Mediatype_Z = "";
         gxTv_SdtTrn_Media_Mediadatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Media_Mediaurl_Z = "";
         gxTv_SdtTrn_Media_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z = Guid.Empty;
         gxTv_SdtTrn_Media_Mediaimage_gxi_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_media", "GeneXus.Programs.trn_media_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Media_Initialized ;
      private short gxTv_SdtTrn_Media_Mediaimage_N ;
      private short gxTv_SdtTrn_Media_Mediadatetime_N ;
      private short gxTv_SdtTrn_Media_Croppedoriginalmediaid_N ;
      private short gxTv_SdtTrn_Media_Mediaimage_gxi_N ;
      private int gxTv_SdtTrn_Media_Mediasize ;
      private int gxTv_SdtTrn_Media_Mediasize_Z ;
      private string gxTv_SdtTrn_Media_Mediatype ;
      private string gxTv_SdtTrn_Media_Mode ;
      private string gxTv_SdtTrn_Media_Mediatype_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_Media_Mediadatetime ;
      private DateTime gxTv_SdtTrn_Media_Mediadatetime_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTrn_Media_Iscropped ;
      private bool gxTv_SdtTrn_Media_Iscropped_Z ;
      private string gxTv_SdtTrn_Media_Medianame ;
      private string gxTv_SdtTrn_Media_Mediaimage_gxi ;
      private string gxTv_SdtTrn_Media_Mediaurl ;
      private string gxTv_SdtTrn_Media_Medianame_Z ;
      private string gxTv_SdtTrn_Media_Mediaurl_Z ;
      private string gxTv_SdtTrn_Media_Mediaimage_gxi_Z ;
      private string gxTv_SdtTrn_Media_Mediaimage ;
      private Guid gxTv_SdtTrn_Media_Mediaid ;
      private Guid gxTv_SdtTrn_Media_Locationid ;
      private Guid gxTv_SdtTrn_Media_Croppedoriginalmediaid ;
      private Guid gxTv_SdtTrn_Media_Mediaid_Z ;
      private Guid gxTv_SdtTrn_Media_Locationid_Z ;
      private Guid gxTv_SdtTrn_Media_Croppedoriginalmediaid_Z ;
   }

   [DataContract(Name = @"Trn_Media", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Media_RESTInterface : GxGenericCollectionItem<SdtTrn_Media>
   {
      public SdtTrn_Media_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Media_RESTInterface( SdtTrn_Media psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MediaId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Mediaid
      {
         get {
            return sdt.gxTpr_Mediaid ;
         }

         set {
            sdt.gxTpr_Mediaid = value;
         }

      }

      [DataMember( Name = "MediaName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Medianame
      {
         get {
            return sdt.gxTpr_Medianame ;
         }

         set {
            sdt.gxTpr_Medianame = value;
         }

      }

      [DataMember( Name = "MediaImage" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Mediaimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Mediaimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Mediaimage) : StringUtil.RTrim( sdt.gxTpr_Mediaimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Mediaimage = value;
         }

      }

      [DataMember( Name = "MediaSize" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Mediasize
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mediasize), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Mediasize = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MediaType" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Mediatype
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Mediatype) ;
         }

         set {
            sdt.gxTpr_Mediatype = value;
         }

      }

      [DataMember( Name = "MediaDateTime" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Mediadatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Mediadatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Mediadatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "MediaUrl" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Mediaurl
      {
         get {
            return sdt.gxTpr_Mediaurl ;
         }

         set {
            sdt.gxTpr_Mediaurl = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 7 )]
      [GxSeudo()]
      public Guid gxTpr_Locationid
      {
         get {
            return sdt.gxTpr_Locationid ;
         }

         set {
            sdt.gxTpr_Locationid = value;
         }

      }

      [DataMember( Name = "IsCropped" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Iscropped
      {
         get {
            return sdt.gxTpr_Iscropped ;
         }

         set {
            sdt.gxTpr_Iscropped = value;
         }

      }

      [DataMember( Name = "CroppedOriginalMediaId" , Order = 9 )]
      [GxSeudo()]
      public Guid gxTpr_Croppedoriginalmediaid
      {
         get {
            return sdt.gxTpr_Croppedoriginalmediaid ;
         }

         set {
            sdt.gxTpr_Croppedoriginalmediaid = value;
         }

      }

      public SdtTrn_Media sdt
      {
         get {
            return (SdtTrn_Media)Sdt ;
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
            sdt = new SdtTrn_Media() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"Trn_Media", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Media_RESTLInterface : GxGenericCollectionItem<SdtTrn_Media>
   {
      public SdtTrn_Media_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Media_RESTLInterface( SdtTrn_Media psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MediaName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Medianame
      {
         get {
            return sdt.gxTpr_Medianame ;
         }

         set {
            sdt.gxTpr_Medianame = value;
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

      public SdtTrn_Media sdt
      {
         get {
            return (SdtTrn_Media)Sdt ;
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
            sdt = new SdtTrn_Media() ;
         }
      }

   }

}
