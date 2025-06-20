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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   [XmlRoot(ElementName = "WWP_FormInstance.Element" )]
   [XmlType(TypeName =  "WWP_FormInstance.Element" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtWWP_FormInstance_Element : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtWWP_FormInstance_Element( )
      {
      }

      public SdtWWP_FormInstance_Element( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPFormElementId", typeof(short)}, new Object[]{"WWPFormInstanceElementId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Element");
         metadata.Set("BT", "WWP_FormInstanceElement");
         metadata.Set("PK", "[ \"WWPFormElementId\",\"WWPFormInstanceElementId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPFormInstanceId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpformelementid_Z");
         state.Add("gxTpr_Wwpforminstanceelementid_Z");
         state.Add("gxTpr_Wwpformelementreferenceid_Z");
         state.Add("gxTpr_Wwpformelementdatatype_Z");
         state.Add("gxTpr_Wwpformelementparentid_Z");
         state.Add("gxTpr_Wwpformelementparenttype_Z");
         state.Add("gxTpr_Wwpformelementtype_Z");
         state.Add("gxTpr_Wwpformelementcaption_Z");
         state.Add("gxTpr_Wwpforminstanceelemdate_Z_Nullable");
         state.Add("gxTpr_Wwpforminstanceelemdatetime_Z_Nullable");
         state.Add("gxTpr_Wwpforminstanceelemnumeric_Z");
         state.Add("gxTpr_Wwpforminstanceelemblobfilename_Z");
         state.Add("gxTpr_Wwpforminstanceelemblobfiletype_Z");
         state.Add("gxTpr_Wwpforminstanceelemboolean_Z");
         state.Add("gxTpr_Wwpformelementparentid_N");
         state.Add("gxTpr_Wwpforminstanceelemchar_N");
         state.Add("gxTpr_Wwpforminstanceelemdate_N");
         state.Add("gxTpr_Wwpforminstanceelemdatetime_N");
         state.Add("gxTpr_Wwpforminstanceelemnumeric_N");
         state.Add("gxTpr_Wwpforminstanceelemblob_N");
         state.Add("gxTpr_Wwpforminstanceelemboolean_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element sdt;
         sdt = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)(source);
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementid ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean ;
         gxTv_SdtWWP_FormInstance_Element_Mode = sdt.gxTv_SdtWWP_FormInstance_Element_Mode ;
         gxTv_SdtWWP_FormInstance_Element_Modified = sdt.gxTv_SdtWWP_FormInstance_Element_Modified ;
         gxTv_SdtWWP_FormInstance_Element_Initialized = sdt.gxTv_SdtWWP_FormInstance_Element_Initialized ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z ;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N ;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N ;
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
         AddObjectProperty("WWPFormElementId", gxTv_SdtWWP_FormInstance_Element_Wwpformelementid, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElementId", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementTitle", gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementReferenceId", gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementDataType", gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementParentId", gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementParentId_N", gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementParentType", gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementType", gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementMetadata", gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementCaption", gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemChar", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemChar_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WWPFormInstanceElemDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemDate_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime;
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
         AddObjectProperty("WWPFormInstanceElemDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemDateTime_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemNumeric", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric, 18, 5)), false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemNumeric_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemBlob", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemBlob_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemBlobFileName", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemBlobFileType", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemBoolean", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceElemBoolean_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_FormInstance_Element_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtWWP_FormInstance_Element_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_FormInstance_Element_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementId_Z", gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElementId_Z", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementReferenceId_Z", gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementDataType_Z", gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementParentId_Z", gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementParentType_Z", gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementType_Z", gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementCaption_Z", gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WWPFormInstanceElemDate_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z;
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
            AddObjectProperty("WWPFormInstanceElemDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemNumeric_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z, 18, 5)), false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemBlobFileName_Z", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemBlobFileType_Z", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemBoolean_Z", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementParentId_N", gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemChar_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemDate_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemDateTime_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemNumeric_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemBlob_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceElemBoolean_N", gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element sdt )
      {
         if ( sdt.IsDirty("WWPFormElementId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementid ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElementId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid ;
         }
         if ( sdt.IsDirty("WWPFormElementTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle ;
         }
         if ( sdt.IsDirty("WWPFormElementReferenceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid ;
         }
         if ( sdt.IsDirty("WWPFormElementDataType") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype ;
         }
         if ( sdt.IsDirty("WWPFormElementParentId") )
         {
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid ;
         }
         if ( sdt.IsDirty("WWPFormElementParentType") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype ;
         }
         if ( sdt.IsDirty("WWPFormElementType") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype ;
         }
         if ( sdt.IsDirty("WWPFormElementMetadata") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata ;
         }
         if ( sdt.IsDirty("WWPFormElementCaption") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemChar") )
         {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemDate") )
         {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemDateTime") )
         {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemNumeric") )
         {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemBlob") )
         {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemBlobFileName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemBlobFileType") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype ;
         }
         if ( sdt.IsDirty("WWPFormInstanceElemBoolean") )
         {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean = sdt.gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPFormElementId" )]
      [  XmlElement( ElementName = "WWPFormElementId"   )]
      public short gxTpr_Wwpformelementid
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementid = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementid");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstanceElementId" )]
      [  XmlElement( ElementName = "WWPFormInstanceElementId"   )]
      public short gxTpr_Wwpforminstanceelementid
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelementid");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementTitle" )]
      [  XmlElement( ElementName = "WWPFormElementTitle"   )]
      public string gxTpr_Wwpformelementtitle
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementtitle");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementReferenceId" )]
      [  XmlElement( ElementName = "WWPFormElementReferenceId"   )]
      public string gxTpr_Wwpformelementreferenceid
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementreferenceid");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementDataType" )]
      [  XmlElement( ElementName = "WWPFormElementDataType"   )]
      public short gxTpr_Wwpformelementdatatype
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementdatatype");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementParentId" )]
      [  XmlElement( ElementName = "WWPFormElementParentId"   )]
      public short gxTpr_Wwpformelementparentid
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementparentid");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N = 1;
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid = 0;
         SetDirty("Wwpformelementparentid");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentType" )]
      [  XmlElement( ElementName = "WWPFormElementParentType"   )]
      public short gxTpr_Wwpformelementparenttype
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementparenttype");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementType" )]
      [  XmlElement( ElementName = "WWPFormElementType"   )]
      public short gxTpr_Wwpformelementtype
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementtype");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementMetadata" )]
      [  XmlElement( ElementName = "WWPFormElementMetadata"   )]
      public string gxTpr_Wwpformelementmetadata
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementmetadata");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementCaption" )]
      [  XmlElement( ElementName = "WWPFormElementCaption"   )]
      public short gxTpr_Wwpformelementcaption
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementcaption");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstanceElemChar" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemChar"   )]
      public string gxTpr_Wwpforminstanceelemchar
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemchar");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N = 1;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar = "";
         SetDirty("Wwpforminstanceelemchar");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemDate" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemDate"  , IsNullable=true )]
      public string gxTpr_Wwpforminstanceelemdate_Nullable
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate).value ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate = DateTime.MinValue;
            else
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate = DateTime.Parse( value);
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpforminstanceelemdate
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemdate");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N = 1;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpforminstanceelemdate");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemDateTime" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemDateTime"  , IsNullable=true )]
      public string gxTpr_Wwpforminstanceelemdatetime_Nullable
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime).value ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime = DateTime.MinValue;
            else
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime = DateTime.Parse( value);
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpforminstanceelemdatetime
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemdatetime");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N = 1;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpforminstanceelemdatetime");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemNumeric" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemNumeric"   )]
      public decimal gxTpr_Wwpforminstanceelemnumeric
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemnumeric");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N = 1;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric = 0;
         SetDirty("Wwpforminstanceelemnumeric");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBlob" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBlob"   )]
      [GxUpload()]
      public byte[] gxTpr_Wwpforminstanceelemblob_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob) ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob=context.FileFromByteArray( value) ;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Wwpforminstanceelemblob
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemblob");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_SetBlob( string blob ,
                                                                                    string fileName ,
                                                                                    string fileType )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob = blob;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename = fileName;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype = fileType;
         return  ;
      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N = 1;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob = "";
         SetDirty("Wwpforminstanceelemblob");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBlobFileName" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBlobFileName"   )]
      public string gxTpr_Wwpforminstanceelemblobfilename
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemblobfilename");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBlobFileType" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBlobFileType"   )]
      public string gxTpr_Wwpforminstanceelemblobfiletype
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemblobfiletype");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBoolean" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBoolean"   )]
      public bool gxTpr_Wwpforminstanceelemboolean
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemboolean");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N = 1;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean = false;
         SetDirty("Wwpforminstanceelemboolean");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Mode_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Modified_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Initialized = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Initialized_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementId_Z" )]
      [  XmlElement( ElementName = "WWPFormElementId_Z"   )]
      public short gxTpr_Wwpformelementid_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementid_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z = 0;
         SetDirty("Wwpformelementid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElementId_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceElementId_Z"   )]
      public short gxTpr_Wwpforminstanceelementid_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelementid_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z = 0;
         SetDirty("Wwpforminstanceelementid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementReferenceId_Z" )]
      [  XmlElement( ElementName = "WWPFormElementReferenceId_Z"   )]
      public string gxTpr_Wwpformelementreferenceid_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementreferenceid_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z = "";
         SetDirty("Wwpformelementreferenceid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementDataType_Z" )]
      [  XmlElement( ElementName = "WWPFormElementDataType_Z"   )]
      public short gxTpr_Wwpformelementdatatype_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementdatatype_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z = 0;
         SetDirty("Wwpformelementdatatype_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentId_Z" )]
      [  XmlElement( ElementName = "WWPFormElementParentId_Z"   )]
      public short gxTpr_Wwpformelementparentid_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementparentid_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z = 0;
         SetDirty("Wwpformelementparentid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentType_Z" )]
      [  XmlElement( ElementName = "WWPFormElementParentType_Z"   )]
      public short gxTpr_Wwpformelementparenttype_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementparenttype_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z = 0;
         SetDirty("Wwpformelementparenttype_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementType_Z" )]
      [  XmlElement( ElementName = "WWPFormElementType_Z"   )]
      public short gxTpr_Wwpformelementtype_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementtype_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z = 0;
         SetDirty("Wwpformelementtype_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementCaption_Z" )]
      [  XmlElement( ElementName = "WWPFormElementCaption_Z"   )]
      public short gxTpr_Wwpformelementcaption_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementcaption_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z = 0;
         SetDirty("Wwpformelementcaption_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemDate_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpforminstanceelemdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z = DateTime.Parse( value);
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpforminstanceelemdate_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemdate_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpforminstanceelemdate_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemDateTime_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Wwpforminstanceelemdatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z = DateTime.Parse( value);
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpforminstanceelemdatetime_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemdatetime_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpforminstanceelemdatetime_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemNumeric_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemNumeric_Z"   )]
      public decimal gxTpr_Wwpforminstanceelemnumeric_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemnumeric_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z = 0;
         SetDirty("Wwpforminstanceelemnumeric_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBlobFileName_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBlobFileName_Z"   )]
      public string gxTpr_Wwpforminstanceelemblobfilename_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemblobfilename_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z = "";
         SetDirty("Wwpforminstanceelemblobfilename_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBlobFileType_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBlobFileType_Z"   )]
      public string gxTpr_Wwpforminstanceelemblobfiletype_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemblobfiletype_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z = "";
         SetDirty("Wwpforminstanceelemblobfiletype_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBoolean_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBoolean_Z"   )]
      public bool gxTpr_Wwpforminstanceelemboolean_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemboolean_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z = false;
         SetDirty("Wwpforminstanceelemboolean_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentId_N" )]
      [  XmlElement( ElementName = "WWPFormElementParentId_N"   )]
      public short gxTpr_Wwpformelementparentid_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpformelementparentid_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N = 0;
         SetDirty("Wwpformelementparentid_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemChar_N" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemChar_N"   )]
      public short gxTpr_Wwpforminstanceelemchar_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemchar_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N = 0;
         SetDirty("Wwpforminstanceelemchar_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemDate_N" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemDate_N"   )]
      public short gxTpr_Wwpforminstanceelemdate_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemdate_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N = 0;
         SetDirty("Wwpforminstanceelemdate_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemDateTime_N" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemDateTime_N"   )]
      public short gxTpr_Wwpforminstanceelemdatetime_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemdatetime_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N = 0;
         SetDirty("Wwpforminstanceelemdatetime_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemNumeric_N" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemNumeric_N"   )]
      public short gxTpr_Wwpforminstanceelemnumeric_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemnumeric_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N = 0;
         SetDirty("Wwpforminstanceelemnumeric_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBlob_N" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBlob_N"   )]
      public short gxTpr_Wwpforminstanceelemblob_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemblob_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N = 0;
         SetDirty("Wwpforminstanceelemblob_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceElemBoolean_N" )]
      [  XmlElement( ElementName = "WWPFormInstanceElemBoolean_N"   )]
      public short gxTpr_Wwpforminstanceelemboolean_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N = value;
            gxTv_SdtWWP_FormInstance_Element_Modified = 1;
            SetDirty("Wwpforminstanceelemboolean_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N = 0;
         SetDirty("Wwpforminstanceelemboolean_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N_IsNull( )
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
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate = DateTime.MinValue;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype = "";
         gxTv_SdtWWP_FormInstance_Element_Mode = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z = DateTime.MinValue;
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z = "";
         gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementid ;
      private short sdtIsNull ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption ;
      private short gxTv_SdtWWP_FormInstance_Element_Modified ;
      private short gxTv_SdtWWP_FormInstance_Element_Initialized ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementid_Z ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelementid_Z ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementdatatype_Z ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_Z ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementparenttype_Z ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementtype_Z ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementcaption_Z ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpformelementparentid_N ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar_N ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_N ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_N ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_N ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob_N ;
      private short gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_N ;
      private decimal gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric ;
      private decimal gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemnumeric_Z ;
      private string gxTv_SdtWWP_FormInstance_Element_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime ;
      private DateTime gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdatetime_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate ;
      private DateTime gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemdate_Z ;
      private bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean ;
      private bool gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemboolean_Z ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpformelementtitle ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpformelementmetadata ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemchar ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpformelementreferenceid_Z ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfilename_Z ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblobfiletype_Z ;
      private string gxTv_SdtWWP_FormInstance_Element_Wwpforminstanceelemblob ;
   }

   [DataContract(Name = @"WorkWithPlus\DynamicForms\WWP_FormInstance.Element", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtWWP_FormInstance_Element_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element>
   {
      public SdtWWP_FormInstance_Element_RESTInterface( ) : base()
      {
      }

      public SdtWWP_FormInstance_Element_RESTInterface( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPFormElementId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementid
      {
         get {
            return sdt.gxTpr_Wwpformelementid ;
         }

         set {
            sdt.gxTpr_Wwpformelementid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormInstanceElementId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpforminstanceelementid
      {
         get {
            return sdt.gxTpr_Wwpforminstanceelementid ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelementid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementTitle" , Order = 2 )]
      public string gxTpr_Wwpformelementtitle
      {
         get {
            return sdt.gxTpr_Wwpformelementtitle ;
         }

         set {
            sdt.gxTpr_Wwpformelementtitle = value;
         }

      }

      [DataMember( Name = "WWPFormElementReferenceId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Wwpformelementreferenceid
      {
         get {
            return sdt.gxTpr_Wwpformelementreferenceid ;
         }

         set {
            sdt.gxTpr_Wwpformelementreferenceid = value;
         }

      }

      [DataMember( Name = "WWPFormElementDataType" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementdatatype
      {
         get {
            return sdt.gxTpr_Wwpformelementdatatype ;
         }

         set {
            sdt.gxTpr_Wwpformelementdatatype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementParentId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementparentid
      {
         get {
            return sdt.gxTpr_Wwpformelementparentid ;
         }

         set {
            sdt.gxTpr_Wwpformelementparentid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementParentType" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementparenttype
      {
         get {
            return sdt.gxTpr_Wwpformelementparenttype ;
         }

         set {
            sdt.gxTpr_Wwpformelementparenttype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementType" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementtype
      {
         get {
            return sdt.gxTpr_Wwpformelementtype ;
         }

         set {
            sdt.gxTpr_Wwpformelementtype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementMetadata" , Order = 8 )]
      public string gxTpr_Wwpformelementmetadata
      {
         get {
            return sdt.gxTpr_Wwpformelementmetadata ;
         }

         set {
            sdt.gxTpr_Wwpformelementmetadata = value;
         }

      }

      [DataMember( Name = "WWPFormElementCaption" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementcaption
      {
         get {
            return sdt.gxTpr_Wwpformelementcaption ;
         }

         set {
            sdt.gxTpr_Wwpformelementcaption = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormInstanceElemChar" , Order = 10 )]
      public string gxTpr_Wwpforminstanceelemchar
      {
         get {
            return sdt.gxTpr_Wwpforminstanceelemchar ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemchar = value;
         }

      }

      [DataMember( Name = "WWPFormInstanceElemDate" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Wwpforminstanceelemdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Wwpforminstanceelemdate) ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "WWPFormInstanceElemDateTime" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Wwpforminstanceelemdatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpforminstanceelemdatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemdatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WWPFormInstanceElemNumeric" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Wwpforminstanceelemnumeric
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Wwpforminstanceelemnumeric, 18, 5)) ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemnumeric = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "WWPFormInstanceElemBlob" , Order = 14 )]
      [GxUpload()]
      public string gxTpr_Wwpforminstanceelemblob
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Wwpforminstanceelemblob) ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemblob = value;
         }

      }

      [DataMember( Name = "WWPFormInstanceElemBlobFileName" , Order = 15 )]
      public string gxTpr_Wwpforminstanceelemblobfilename
      {
         get {
            return sdt.gxTpr_Wwpforminstanceelemblobfilename ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemblobfilename = value;
         }

      }

      [DataMember( Name = "WWPFormInstanceElemBlobFileType" , Order = 16 )]
      public string gxTpr_Wwpforminstanceelemblobfiletype
      {
         get {
            return sdt.gxTpr_Wwpforminstanceelemblobfiletype ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemblobfiletype = value;
         }

      }

      [DataMember( Name = "WWPFormInstanceElemBoolean" , Order = 17 )]
      [GxSeudo()]
      public bool gxTpr_Wwpforminstanceelemboolean
      {
         get {
            return sdt.gxTpr_Wwpforminstanceelemboolean ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceelemboolean = value;
         }

      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element sdt
      {
         get {
            return (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)Sdt ;
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
            sdt = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element() ;
         }
      }

   }

   [DataContract(Name = @"WorkWithPlus\DynamicForms\WWP_FormInstance.Element", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtWWP_FormInstance_Element_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element>
   {
      public SdtWWP_FormInstance_Element_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_FormInstance_Element_RESTLInterface( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element sdt
      {
         get {
            return (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)Sdt ;
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
            sdt = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element() ;
         }
      }

   }

}
