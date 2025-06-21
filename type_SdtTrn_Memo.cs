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
   [XmlRoot(ElementName = "Trn_Memo" )]
   [XmlType(TypeName =  "Trn_Memo" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Memo : GxSilentTrnSdt
   {
      public SdtTrn_Memo( )
      {
      }

      public SdtTrn_Memo( IGxContext context )
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

      public void Load( Guid AV549MemoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV549MemoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MemoId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Memo");
         metadata.Set("BT", "Trn_Memo");
         metadata.Set("PK", "[ \"MemoId\" ]");
         metadata.Set("PKAssigned", "[ \"MemoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ResidentId\",\"LocationId\",\"OrganisationId\" ],\"FKMap\":[ \"SG_LocationId-LocationId\",\"SG_OrganisationId-OrganisationId\" ] } ]");
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
         state.Add("gxTpr_Memoid_Z");
         state.Add("gxTpr_Memotitle_Z");
         state.Add("gxTpr_Memodescription_Z");
         state.Add("gxTpr_Memodocument_Z");
         state.Add("gxTpr_Memostartdatetime_Z_Nullable");
         state.Add("gxTpr_Memoenddatetime_Z_Nullable");
         state.Add("gxTpr_Memoduration_Z");
         state.Add("gxTpr_Memoremovedate_Z_Nullable");
         state.Add("gxTpr_Residentid_Z");
         state.Add("gxTpr_Residentsalutation_Z");
         state.Add("gxTpr_Residentgivenname_Z");
         state.Add("gxTpr_Residentlastname_Z");
         state.Add("gxTpr_Residentguid_Z");
         state.Add("gxTpr_Memobgcolorcode_Z");
         state.Add("gxTpr_Memoform_Z");
         state.Add("gxTpr_Sg_organisationid_Z");
         state.Add("gxTpr_Sg_locationid_Z");
         state.Add("gxTpr_Memotype_Z");
         state.Add("gxTpr_Memoname_Z");
         state.Add("gxTpr_Memoleftoffset_Z");
         state.Add("gxTpr_Memotopoffset_Z");
         state.Add("gxTpr_Memotitleangle_Z");
         state.Add("gxTpr_Memotitlescale_Z");
         state.Add("gxTpr_Memotextfontname_Z");
         state.Add("gxTpr_Memotextalignment_Z");
         state.Add("gxTpr_Memoisbold_Z");
         state.Add("gxTpr_Memoisitalic_Z");
         state.Add("gxTpr_Memoiscapitalized_Z");
         state.Add("gxTpr_Memotextcolor_Z");
         state.Add("gxTpr_Memocreatedat_Z_Nullable");
         state.Add("gxTpr_Memoimage_N");
         state.Add("gxTpr_Memodocument_N");
         state.Add("gxTpr_Memostartdatetime_N");
         state.Add("gxTpr_Memoenddatetime_N");
         state.Add("gxTpr_Memoduration_N");
         state.Add("gxTpr_Memoremovedate_N");
         state.Add("gxTpr_Memobgcolorcode_N");
         state.Add("gxTpr_Memocreatedat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Memo sdt;
         sdt = (SdtTrn_Memo)(source);
         gxTv_SdtTrn_Memo_Memoid = sdt.gxTv_SdtTrn_Memo_Memoid ;
         gxTv_SdtTrn_Memo_Memotitle = sdt.gxTv_SdtTrn_Memo_Memotitle ;
         gxTv_SdtTrn_Memo_Memodescription = sdt.gxTv_SdtTrn_Memo_Memodescription ;
         gxTv_SdtTrn_Memo_Memoimage = sdt.gxTv_SdtTrn_Memo_Memoimage ;
         gxTv_SdtTrn_Memo_Memodocument = sdt.gxTv_SdtTrn_Memo_Memodocument ;
         gxTv_SdtTrn_Memo_Memostartdatetime = sdt.gxTv_SdtTrn_Memo_Memostartdatetime ;
         gxTv_SdtTrn_Memo_Memoenddatetime = sdt.gxTv_SdtTrn_Memo_Memoenddatetime ;
         gxTv_SdtTrn_Memo_Memoduration = sdt.gxTv_SdtTrn_Memo_Memoduration ;
         gxTv_SdtTrn_Memo_Memoremovedate = sdt.gxTv_SdtTrn_Memo_Memoremovedate ;
         gxTv_SdtTrn_Memo_Residentid = sdt.gxTv_SdtTrn_Memo_Residentid ;
         gxTv_SdtTrn_Memo_Residentsalutation = sdt.gxTv_SdtTrn_Memo_Residentsalutation ;
         gxTv_SdtTrn_Memo_Residentgivenname = sdt.gxTv_SdtTrn_Memo_Residentgivenname ;
         gxTv_SdtTrn_Memo_Residentlastname = sdt.gxTv_SdtTrn_Memo_Residentlastname ;
         gxTv_SdtTrn_Memo_Residentguid = sdt.gxTv_SdtTrn_Memo_Residentguid ;
         gxTv_SdtTrn_Memo_Memobgcolorcode = sdt.gxTv_SdtTrn_Memo_Memobgcolorcode ;
         gxTv_SdtTrn_Memo_Memoform = sdt.gxTv_SdtTrn_Memo_Memoform ;
         gxTv_SdtTrn_Memo_Sg_organisationid = sdt.gxTv_SdtTrn_Memo_Sg_organisationid ;
         gxTv_SdtTrn_Memo_Sg_locationid = sdt.gxTv_SdtTrn_Memo_Sg_locationid ;
         gxTv_SdtTrn_Memo_Memotype = sdt.gxTv_SdtTrn_Memo_Memotype ;
         gxTv_SdtTrn_Memo_Memoname = sdt.gxTv_SdtTrn_Memo_Memoname ;
         gxTv_SdtTrn_Memo_Memoleftoffset = sdt.gxTv_SdtTrn_Memo_Memoleftoffset ;
         gxTv_SdtTrn_Memo_Memotopoffset = sdt.gxTv_SdtTrn_Memo_Memotopoffset ;
         gxTv_SdtTrn_Memo_Memotitleangle = sdt.gxTv_SdtTrn_Memo_Memotitleangle ;
         gxTv_SdtTrn_Memo_Memotitlescale = sdt.gxTv_SdtTrn_Memo_Memotitlescale ;
         gxTv_SdtTrn_Memo_Memotextfontname = sdt.gxTv_SdtTrn_Memo_Memotextfontname ;
         gxTv_SdtTrn_Memo_Memotextalignment = sdt.gxTv_SdtTrn_Memo_Memotextalignment ;
         gxTv_SdtTrn_Memo_Memoisbold = sdt.gxTv_SdtTrn_Memo_Memoisbold ;
         gxTv_SdtTrn_Memo_Memoisitalic = sdt.gxTv_SdtTrn_Memo_Memoisitalic ;
         gxTv_SdtTrn_Memo_Memoiscapitalized = sdt.gxTv_SdtTrn_Memo_Memoiscapitalized ;
         gxTv_SdtTrn_Memo_Memotextcolor = sdt.gxTv_SdtTrn_Memo_Memotextcolor ;
         gxTv_SdtTrn_Memo_Memocreatedat = sdt.gxTv_SdtTrn_Memo_Memocreatedat ;
         gxTv_SdtTrn_Memo_Mode = sdt.gxTv_SdtTrn_Memo_Mode ;
         gxTv_SdtTrn_Memo_Initialized = sdt.gxTv_SdtTrn_Memo_Initialized ;
         gxTv_SdtTrn_Memo_Memoid_Z = sdt.gxTv_SdtTrn_Memo_Memoid_Z ;
         gxTv_SdtTrn_Memo_Memotitle_Z = sdt.gxTv_SdtTrn_Memo_Memotitle_Z ;
         gxTv_SdtTrn_Memo_Memodescription_Z = sdt.gxTv_SdtTrn_Memo_Memodescription_Z ;
         gxTv_SdtTrn_Memo_Memodocument_Z = sdt.gxTv_SdtTrn_Memo_Memodocument_Z ;
         gxTv_SdtTrn_Memo_Memostartdatetime_Z = sdt.gxTv_SdtTrn_Memo_Memostartdatetime_Z ;
         gxTv_SdtTrn_Memo_Memoenddatetime_Z = sdt.gxTv_SdtTrn_Memo_Memoenddatetime_Z ;
         gxTv_SdtTrn_Memo_Memoduration_Z = sdt.gxTv_SdtTrn_Memo_Memoduration_Z ;
         gxTv_SdtTrn_Memo_Memoremovedate_Z = sdt.gxTv_SdtTrn_Memo_Memoremovedate_Z ;
         gxTv_SdtTrn_Memo_Residentid_Z = sdt.gxTv_SdtTrn_Memo_Residentid_Z ;
         gxTv_SdtTrn_Memo_Residentsalutation_Z = sdt.gxTv_SdtTrn_Memo_Residentsalutation_Z ;
         gxTv_SdtTrn_Memo_Residentgivenname_Z = sdt.gxTv_SdtTrn_Memo_Residentgivenname_Z ;
         gxTv_SdtTrn_Memo_Residentlastname_Z = sdt.gxTv_SdtTrn_Memo_Residentlastname_Z ;
         gxTv_SdtTrn_Memo_Residentguid_Z = sdt.gxTv_SdtTrn_Memo_Residentguid_Z ;
         gxTv_SdtTrn_Memo_Memobgcolorcode_Z = sdt.gxTv_SdtTrn_Memo_Memobgcolorcode_Z ;
         gxTv_SdtTrn_Memo_Memoform_Z = sdt.gxTv_SdtTrn_Memo_Memoform_Z ;
         gxTv_SdtTrn_Memo_Sg_organisationid_Z = sdt.gxTv_SdtTrn_Memo_Sg_organisationid_Z ;
         gxTv_SdtTrn_Memo_Sg_locationid_Z = sdt.gxTv_SdtTrn_Memo_Sg_locationid_Z ;
         gxTv_SdtTrn_Memo_Memotype_Z = sdt.gxTv_SdtTrn_Memo_Memotype_Z ;
         gxTv_SdtTrn_Memo_Memoname_Z = sdt.gxTv_SdtTrn_Memo_Memoname_Z ;
         gxTv_SdtTrn_Memo_Memoleftoffset_Z = sdt.gxTv_SdtTrn_Memo_Memoleftoffset_Z ;
         gxTv_SdtTrn_Memo_Memotopoffset_Z = sdt.gxTv_SdtTrn_Memo_Memotopoffset_Z ;
         gxTv_SdtTrn_Memo_Memotitleangle_Z = sdt.gxTv_SdtTrn_Memo_Memotitleangle_Z ;
         gxTv_SdtTrn_Memo_Memotitlescale_Z = sdt.gxTv_SdtTrn_Memo_Memotitlescale_Z ;
         gxTv_SdtTrn_Memo_Memotextfontname_Z = sdt.gxTv_SdtTrn_Memo_Memotextfontname_Z ;
         gxTv_SdtTrn_Memo_Memotextalignment_Z = sdt.gxTv_SdtTrn_Memo_Memotextalignment_Z ;
         gxTv_SdtTrn_Memo_Memoisbold_Z = sdt.gxTv_SdtTrn_Memo_Memoisbold_Z ;
         gxTv_SdtTrn_Memo_Memoisitalic_Z = sdt.gxTv_SdtTrn_Memo_Memoisitalic_Z ;
         gxTv_SdtTrn_Memo_Memoiscapitalized_Z = sdt.gxTv_SdtTrn_Memo_Memoiscapitalized_Z ;
         gxTv_SdtTrn_Memo_Memotextcolor_Z = sdt.gxTv_SdtTrn_Memo_Memotextcolor_Z ;
         gxTv_SdtTrn_Memo_Memocreatedat_Z = sdt.gxTv_SdtTrn_Memo_Memocreatedat_Z ;
         gxTv_SdtTrn_Memo_Memoimage_N = sdt.gxTv_SdtTrn_Memo_Memoimage_N ;
         gxTv_SdtTrn_Memo_Memodocument_N = sdt.gxTv_SdtTrn_Memo_Memodocument_N ;
         gxTv_SdtTrn_Memo_Memostartdatetime_N = sdt.gxTv_SdtTrn_Memo_Memostartdatetime_N ;
         gxTv_SdtTrn_Memo_Memoenddatetime_N = sdt.gxTv_SdtTrn_Memo_Memoenddatetime_N ;
         gxTv_SdtTrn_Memo_Memoduration_N = sdt.gxTv_SdtTrn_Memo_Memoduration_N ;
         gxTv_SdtTrn_Memo_Memoremovedate_N = sdt.gxTv_SdtTrn_Memo_Memoremovedate_N ;
         gxTv_SdtTrn_Memo_Memobgcolorcode_N = sdt.gxTv_SdtTrn_Memo_Memobgcolorcode_N ;
         gxTv_SdtTrn_Memo_Memocreatedat_N = sdt.gxTv_SdtTrn_Memo_Memocreatedat_N ;
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
         AddObjectProperty("MemoId", gxTv_SdtTrn_Memo_Memoid, false, includeNonInitialized);
         AddObjectProperty("MemoTitle", gxTv_SdtTrn_Memo_Memotitle, false, includeNonInitialized);
         AddObjectProperty("MemoDescription", gxTv_SdtTrn_Memo_Memodescription, false, includeNonInitialized);
         AddObjectProperty("MemoImage", gxTv_SdtTrn_Memo_Memoimage, false, includeNonInitialized);
         AddObjectProperty("MemoImage_N", gxTv_SdtTrn_Memo_Memoimage_N, false, includeNonInitialized);
         AddObjectProperty("MemoDocument", gxTv_SdtTrn_Memo_Memodocument, false, includeNonInitialized);
         AddObjectProperty("MemoDocument_N", gxTv_SdtTrn_Memo_Memodocument_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_Memo_Memostartdatetime;
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
         AddObjectProperty("MemoStartDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MemoStartDateTime_N", gxTv_SdtTrn_Memo_Memostartdatetime_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_Memo_Memoenddatetime;
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
         AddObjectProperty("MemoEndDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MemoEndDateTime_N", gxTv_SdtTrn_Memo_Memoenddatetime_N, false, includeNonInitialized);
         AddObjectProperty("MemoDuration", gxTv_SdtTrn_Memo_Memoduration, false, includeNonInitialized);
         AddObjectProperty("MemoDuration_N", gxTv_SdtTrn_Memo_Memoduration_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrn_Memo_Memoremovedate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrn_Memo_Memoremovedate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrn_Memo_Memoremovedate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("MemoRemoveDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MemoRemoveDate_N", gxTv_SdtTrn_Memo_Memoremovedate_N, false, includeNonInitialized);
         AddObjectProperty("ResidentId", gxTv_SdtTrn_Memo_Residentid, false, includeNonInitialized);
         AddObjectProperty("ResidentSalutation", gxTv_SdtTrn_Memo_Residentsalutation, false, includeNonInitialized);
         AddObjectProperty("ResidentGivenName", gxTv_SdtTrn_Memo_Residentgivenname, false, includeNonInitialized);
         AddObjectProperty("ResidentLastName", gxTv_SdtTrn_Memo_Residentlastname, false, includeNonInitialized);
         AddObjectProperty("ResidentGUID", gxTv_SdtTrn_Memo_Residentguid, false, includeNonInitialized);
         AddObjectProperty("MemoBgColorCode", gxTv_SdtTrn_Memo_Memobgcolorcode, false, includeNonInitialized);
         AddObjectProperty("MemoBgColorCode_N", gxTv_SdtTrn_Memo_Memobgcolorcode_N, false, includeNonInitialized);
         AddObjectProperty("MemoForm", gxTv_SdtTrn_Memo_Memoform, false, includeNonInitialized);
         AddObjectProperty("SG_OrganisationId", gxTv_SdtTrn_Memo_Sg_organisationid, false, includeNonInitialized);
         AddObjectProperty("SG_LocationId", gxTv_SdtTrn_Memo_Sg_locationid, false, includeNonInitialized);
         AddObjectProperty("MemoType", gxTv_SdtTrn_Memo_Memotype, false, includeNonInitialized);
         AddObjectProperty("MemoName", gxTv_SdtTrn_Memo_Memoname, false, includeNonInitialized);
         AddObjectProperty("MemoLeftOffset", gxTv_SdtTrn_Memo_Memoleftoffset, false, includeNonInitialized);
         AddObjectProperty("MemoTopOffset", gxTv_SdtTrn_Memo_Memotopoffset, false, includeNonInitialized);
         AddObjectProperty("MemoTitleAngle", gxTv_SdtTrn_Memo_Memotitleangle, false, includeNonInitialized);
         AddObjectProperty("MemoTitleScale", gxTv_SdtTrn_Memo_Memotitlescale, false, includeNonInitialized);
         AddObjectProperty("MemoTextFontName", gxTv_SdtTrn_Memo_Memotextfontname, false, includeNonInitialized);
         AddObjectProperty("MemoTextAlignment", gxTv_SdtTrn_Memo_Memotextalignment, false, includeNonInitialized);
         AddObjectProperty("MemoIsBold", gxTv_SdtTrn_Memo_Memoisbold, false, includeNonInitialized);
         AddObjectProperty("MemoIsItalic", gxTv_SdtTrn_Memo_Memoisitalic, false, includeNonInitialized);
         AddObjectProperty("MemoIsCapitalized", gxTv_SdtTrn_Memo_Memoiscapitalized, false, includeNonInitialized);
         AddObjectProperty("MemoTextColor", gxTv_SdtTrn_Memo_Memotextcolor, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_Memo_Memocreatedat;
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
         AddObjectProperty("MemoCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MemoCreatedAt_N", gxTv_SdtTrn_Memo_Memocreatedat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Memo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Memo_Initialized, false, includeNonInitialized);
            AddObjectProperty("MemoId_Z", gxTv_SdtTrn_Memo_Memoid_Z, false, includeNonInitialized);
            AddObjectProperty("MemoTitle_Z", gxTv_SdtTrn_Memo_Memotitle_Z, false, includeNonInitialized);
            AddObjectProperty("MemoDescription_Z", gxTv_SdtTrn_Memo_Memodescription_Z, false, includeNonInitialized);
            AddObjectProperty("MemoDocument_Z", gxTv_SdtTrn_Memo_Memodocument_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_Memo_Memostartdatetime_Z;
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
            AddObjectProperty("MemoStartDateTime_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_Memo_Memoenddatetime_Z;
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
            AddObjectProperty("MemoEndDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("MemoDuration_Z", gxTv_SdtTrn_Memo_Memoduration_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrn_Memo_Memoremovedate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrn_Memo_Memoremovedate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrn_Memo_Memoremovedate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("MemoRemoveDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ResidentId_Z", gxTv_SdtTrn_Memo_Residentid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentSalutation_Z", gxTv_SdtTrn_Memo_Residentsalutation_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGivenName_Z", gxTv_SdtTrn_Memo_Residentgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentLastName_Z", gxTv_SdtTrn_Memo_Residentlastname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGUID_Z", gxTv_SdtTrn_Memo_Residentguid_Z, false, includeNonInitialized);
            AddObjectProperty("MemoBgColorCode_Z", gxTv_SdtTrn_Memo_Memobgcolorcode_Z, false, includeNonInitialized);
            AddObjectProperty("MemoForm_Z", gxTv_SdtTrn_Memo_Memoform_Z, false, includeNonInitialized);
            AddObjectProperty("SG_OrganisationId_Z", gxTv_SdtTrn_Memo_Sg_organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_LocationId_Z", gxTv_SdtTrn_Memo_Sg_locationid_Z, false, includeNonInitialized);
            AddObjectProperty("MemoType_Z", gxTv_SdtTrn_Memo_Memotype_Z, false, includeNonInitialized);
            AddObjectProperty("MemoName_Z", gxTv_SdtTrn_Memo_Memoname_Z, false, includeNonInitialized);
            AddObjectProperty("MemoLeftOffset_Z", gxTv_SdtTrn_Memo_Memoleftoffset_Z, false, includeNonInitialized);
            AddObjectProperty("MemoTopOffset_Z", gxTv_SdtTrn_Memo_Memotopoffset_Z, false, includeNonInitialized);
            AddObjectProperty("MemoTitleAngle_Z", gxTv_SdtTrn_Memo_Memotitleangle_Z, false, includeNonInitialized);
            AddObjectProperty("MemoTitleScale_Z", gxTv_SdtTrn_Memo_Memotitlescale_Z, false, includeNonInitialized);
            AddObjectProperty("MemoTextFontName_Z", gxTv_SdtTrn_Memo_Memotextfontname_Z, false, includeNonInitialized);
            AddObjectProperty("MemoTextAlignment_Z", gxTv_SdtTrn_Memo_Memotextalignment_Z, false, includeNonInitialized);
            AddObjectProperty("MemoIsBold_Z", gxTv_SdtTrn_Memo_Memoisbold_Z, false, includeNonInitialized);
            AddObjectProperty("MemoIsItalic_Z", gxTv_SdtTrn_Memo_Memoisitalic_Z, false, includeNonInitialized);
            AddObjectProperty("MemoIsCapitalized_Z", gxTv_SdtTrn_Memo_Memoiscapitalized_Z, false, includeNonInitialized);
            AddObjectProperty("MemoTextColor_Z", gxTv_SdtTrn_Memo_Memotextcolor_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_Memo_Memocreatedat_Z;
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
            AddObjectProperty("MemoCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("MemoImage_N", gxTv_SdtTrn_Memo_Memoimage_N, false, includeNonInitialized);
            AddObjectProperty("MemoDocument_N", gxTv_SdtTrn_Memo_Memodocument_N, false, includeNonInitialized);
            AddObjectProperty("MemoStartDateTime_N", gxTv_SdtTrn_Memo_Memostartdatetime_N, false, includeNonInitialized);
            AddObjectProperty("MemoEndDateTime_N", gxTv_SdtTrn_Memo_Memoenddatetime_N, false, includeNonInitialized);
            AddObjectProperty("MemoDuration_N", gxTv_SdtTrn_Memo_Memoduration_N, false, includeNonInitialized);
            AddObjectProperty("MemoRemoveDate_N", gxTv_SdtTrn_Memo_Memoremovedate_N, false, includeNonInitialized);
            AddObjectProperty("MemoBgColorCode_N", gxTv_SdtTrn_Memo_Memobgcolorcode_N, false, includeNonInitialized);
            AddObjectProperty("MemoCreatedAt_N", gxTv_SdtTrn_Memo_Memocreatedat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Memo sdt )
      {
         if ( sdt.IsDirty("MemoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoid = sdt.gxTv_SdtTrn_Memo_Memoid ;
         }
         if ( sdt.IsDirty("MemoTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitle = sdt.gxTv_SdtTrn_Memo_Memotitle ;
         }
         if ( sdt.IsDirty("MemoDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memodescription = sdt.gxTv_SdtTrn_Memo_Memodescription ;
         }
         if ( sdt.IsDirty("MemoImage") )
         {
            gxTv_SdtTrn_Memo_Memoimage_N = (short)(sdt.gxTv_SdtTrn_Memo_Memoimage_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoimage = sdt.gxTv_SdtTrn_Memo_Memoimage ;
         }
         if ( sdt.IsDirty("MemoDocument") )
         {
            gxTv_SdtTrn_Memo_Memodocument_N = (short)(sdt.gxTv_SdtTrn_Memo_Memodocument_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memodocument = sdt.gxTv_SdtTrn_Memo_Memodocument ;
         }
         if ( sdt.IsDirty("MemoStartDateTime") )
         {
            gxTv_SdtTrn_Memo_Memostartdatetime_N = (short)(sdt.gxTv_SdtTrn_Memo_Memostartdatetime_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memostartdatetime = sdt.gxTv_SdtTrn_Memo_Memostartdatetime ;
         }
         if ( sdt.IsDirty("MemoEndDateTime") )
         {
            gxTv_SdtTrn_Memo_Memoenddatetime_N = (short)(sdt.gxTv_SdtTrn_Memo_Memoenddatetime_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoenddatetime = sdt.gxTv_SdtTrn_Memo_Memoenddatetime ;
         }
         if ( sdt.IsDirty("MemoDuration") )
         {
            gxTv_SdtTrn_Memo_Memoduration_N = (short)(sdt.gxTv_SdtTrn_Memo_Memoduration_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoduration = sdt.gxTv_SdtTrn_Memo_Memoduration ;
         }
         if ( sdt.IsDirty("MemoRemoveDate") )
         {
            gxTv_SdtTrn_Memo_Memoremovedate_N = (short)(sdt.gxTv_SdtTrn_Memo_Memoremovedate_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoremovedate = sdt.gxTv_SdtTrn_Memo_Memoremovedate ;
         }
         if ( sdt.IsDirty("ResidentId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentid = sdt.gxTv_SdtTrn_Memo_Residentid ;
         }
         if ( sdt.IsDirty("ResidentSalutation") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentsalutation = sdt.gxTv_SdtTrn_Memo_Residentsalutation ;
         }
         if ( sdt.IsDirty("ResidentGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentgivenname = sdt.gxTv_SdtTrn_Memo_Residentgivenname ;
         }
         if ( sdt.IsDirty("ResidentLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentlastname = sdt.gxTv_SdtTrn_Memo_Residentlastname ;
         }
         if ( sdt.IsDirty("ResidentGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentguid = sdt.gxTv_SdtTrn_Memo_Residentguid ;
         }
         if ( sdt.IsDirty("MemoBgColorCode") )
         {
            gxTv_SdtTrn_Memo_Memobgcolorcode_N = (short)(sdt.gxTv_SdtTrn_Memo_Memobgcolorcode_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memobgcolorcode = sdt.gxTv_SdtTrn_Memo_Memobgcolorcode ;
         }
         if ( sdt.IsDirty("MemoForm") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoform = sdt.gxTv_SdtTrn_Memo_Memoform ;
         }
         if ( sdt.IsDirty("SG_OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Sg_organisationid = sdt.gxTv_SdtTrn_Memo_Sg_organisationid ;
         }
         if ( sdt.IsDirty("SG_LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Sg_locationid = sdt.gxTv_SdtTrn_Memo_Sg_locationid ;
         }
         if ( sdt.IsDirty("MemoType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotype = sdt.gxTv_SdtTrn_Memo_Memotype ;
         }
         if ( sdt.IsDirty("MemoName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoname = sdt.gxTv_SdtTrn_Memo_Memoname ;
         }
         if ( sdt.IsDirty("MemoLeftOffset") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoleftoffset = sdt.gxTv_SdtTrn_Memo_Memoleftoffset ;
         }
         if ( sdt.IsDirty("MemoTopOffset") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotopoffset = sdt.gxTv_SdtTrn_Memo_Memotopoffset ;
         }
         if ( sdt.IsDirty("MemoTitleAngle") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitleangle = sdt.gxTv_SdtTrn_Memo_Memotitleangle ;
         }
         if ( sdt.IsDirty("MemoTitleScale") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitlescale = sdt.gxTv_SdtTrn_Memo_Memotitlescale ;
         }
         if ( sdt.IsDirty("MemoTextFontName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextfontname = sdt.gxTv_SdtTrn_Memo_Memotextfontname ;
         }
         if ( sdt.IsDirty("MemoTextAlignment") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextalignment = sdt.gxTv_SdtTrn_Memo_Memotextalignment ;
         }
         if ( sdt.IsDirty("MemoIsBold") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoisbold = sdt.gxTv_SdtTrn_Memo_Memoisbold ;
         }
         if ( sdt.IsDirty("MemoIsItalic") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoisitalic = sdt.gxTv_SdtTrn_Memo_Memoisitalic ;
         }
         if ( sdt.IsDirty("MemoIsCapitalized") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoiscapitalized = sdt.gxTv_SdtTrn_Memo_Memoiscapitalized ;
         }
         if ( sdt.IsDirty("MemoTextColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextcolor = sdt.gxTv_SdtTrn_Memo_Memotextcolor ;
         }
         if ( sdt.IsDirty("MemoCreatedAt") )
         {
            gxTv_SdtTrn_Memo_Memocreatedat_N = (short)(sdt.gxTv_SdtTrn_Memo_Memocreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memocreatedat = sdt.gxTv_SdtTrn_Memo_Memocreatedat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MemoId" )]
      [  XmlElement( ElementName = "MemoId"   )]
      public Guid gxTpr_Memoid
      {
         get {
            return gxTv_SdtTrn_Memo_Memoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Memo_Memoid != value )
            {
               gxTv_SdtTrn_Memo_Mode = "INS";
               this.gxTv_SdtTrn_Memo_Memoid_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotitle_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memodescription_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memodocument_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memostartdatetime_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoenddatetime_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoduration_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoremovedate_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Residentid_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Residentsalutation_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Residentgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Residentlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Residentguid_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memobgcolorcode_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoform_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Sg_organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Sg_locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotype_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoname_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoleftoffset_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotopoffset_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotitleangle_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotitlescale_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotextfontname_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotextalignment_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoisbold_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoisitalic_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memoiscapitalized_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memotextcolor_Z_SetNull( );
               this.gxTv_SdtTrn_Memo_Memocreatedat_Z_SetNull( );
            }
            gxTv_SdtTrn_Memo_Memoid = value;
            SetDirty("Memoid");
         }

      }

      [  SoapElement( ElementName = "MemoTitle" )]
      [  XmlElement( ElementName = "MemoTitle"   )]
      public string gxTpr_Memotitle
      {
         get {
            return gxTv_SdtTrn_Memo_Memotitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitle = value;
            SetDirty("Memotitle");
         }

      }

      [  SoapElement( ElementName = "MemoDescription" )]
      [  XmlElement( ElementName = "MemoDescription"   )]
      public string gxTpr_Memodescription
      {
         get {
            return gxTv_SdtTrn_Memo_Memodescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memodescription = value;
            SetDirty("Memodescription");
         }

      }

      [  SoapElement( ElementName = "MemoImage" )]
      [  XmlElement( ElementName = "MemoImage"   )]
      public string gxTpr_Memoimage
      {
         get {
            return gxTv_SdtTrn_Memo_Memoimage ;
         }

         set {
            gxTv_SdtTrn_Memo_Memoimage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoimage = value;
            SetDirty("Memoimage");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoimage_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoimage_N = 1;
         gxTv_SdtTrn_Memo_Memoimage = "";
         SetDirty("Memoimage");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoimage_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memoimage_N==1) ;
      }

      [  SoapElement( ElementName = "MemoDocument" )]
      [  XmlElement( ElementName = "MemoDocument"   )]
      public string gxTpr_Memodocument
      {
         get {
            return gxTv_SdtTrn_Memo_Memodocument ;
         }

         set {
            gxTv_SdtTrn_Memo_Memodocument_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memodocument = value;
            SetDirty("Memodocument");
         }

      }

      public void gxTv_SdtTrn_Memo_Memodocument_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memodocument_N = 1;
         gxTv_SdtTrn_Memo_Memodocument = "";
         SetDirty("Memodocument");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memodocument_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memodocument_N==1) ;
      }

      [  SoapElement( ElementName = "MemoStartDateTime" )]
      [  XmlElement( ElementName = "MemoStartDateTime"  , IsNullable=true )]
      public string gxTpr_Memostartdatetime_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memostartdatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Memo_Memostartdatetime).value ;
         }

         set {
            gxTv_SdtTrn_Memo_Memostartdatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Memo_Memostartdatetime = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memostartdatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memostartdatetime
      {
         get {
            return gxTv_SdtTrn_Memo_Memostartdatetime ;
         }

         set {
            gxTv_SdtTrn_Memo_Memostartdatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memostartdatetime = value;
            SetDirty("Memostartdatetime");
         }

      }

      public void gxTv_SdtTrn_Memo_Memostartdatetime_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memostartdatetime_N = 1;
         gxTv_SdtTrn_Memo_Memostartdatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Memostartdatetime");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memostartdatetime_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memostartdatetime_N==1) ;
      }

      [  SoapElement( ElementName = "MemoEndDateTime" )]
      [  XmlElement( ElementName = "MemoEndDateTime"  , IsNullable=true )]
      public string gxTpr_Memoenddatetime_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memoenddatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Memo_Memoenddatetime).value ;
         }

         set {
            gxTv_SdtTrn_Memo_Memoenddatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Memo_Memoenddatetime = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memoenddatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memoenddatetime
      {
         get {
            return gxTv_SdtTrn_Memo_Memoenddatetime ;
         }

         set {
            gxTv_SdtTrn_Memo_Memoenddatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoenddatetime = value;
            SetDirty("Memoenddatetime");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoenddatetime_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoenddatetime_N = 1;
         gxTv_SdtTrn_Memo_Memoenddatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Memoenddatetime");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoenddatetime_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memoenddatetime_N==1) ;
      }

      [  SoapElement( ElementName = "MemoDuration" )]
      [  XmlElement( ElementName = "MemoDuration"   )]
      public decimal gxTpr_Memoduration
      {
         get {
            return gxTv_SdtTrn_Memo_Memoduration ;
         }

         set {
            gxTv_SdtTrn_Memo_Memoduration_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoduration = value;
            SetDirty("Memoduration");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoduration_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoduration_N = 1;
         gxTv_SdtTrn_Memo_Memoduration = 0;
         SetDirty("Memoduration");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoduration_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memoduration_N==1) ;
      }

      [  SoapElement( ElementName = "MemoRemoveDate" )]
      [  XmlElement( ElementName = "MemoRemoveDate"  , IsNullable=true )]
      public string gxTpr_Memoremovedate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memoremovedate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrn_Memo_Memoremovedate).value ;
         }

         set {
            gxTv_SdtTrn_Memo_Memoremovedate_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrn_Memo_Memoremovedate = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memoremovedate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memoremovedate
      {
         get {
            return gxTv_SdtTrn_Memo_Memoremovedate ;
         }

         set {
            gxTv_SdtTrn_Memo_Memoremovedate_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoremovedate = value;
            SetDirty("Memoremovedate");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoremovedate_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoremovedate_N = 1;
         gxTv_SdtTrn_Memo_Memoremovedate = (DateTime)(DateTime.MinValue);
         SetDirty("Memoremovedate");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoremovedate_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memoremovedate_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentId" )]
      [  XmlElement( ElementName = "ResidentId"   )]
      public Guid gxTpr_Residentid
      {
         get {
            return gxTv_SdtTrn_Memo_Residentid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentid = value;
            SetDirty("Residentid");
         }

      }

      [  SoapElement( ElementName = "ResidentSalutation" )]
      [  XmlElement( ElementName = "ResidentSalutation"   )]
      public string gxTpr_Residentsalutation
      {
         get {
            return gxTv_SdtTrn_Memo_Residentsalutation ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentsalutation = value;
            SetDirty("Residentsalutation");
         }

      }

      [  SoapElement( ElementName = "ResidentGivenName" )]
      [  XmlElement( ElementName = "ResidentGivenName"   )]
      public string gxTpr_Residentgivenname
      {
         get {
            return gxTv_SdtTrn_Memo_Residentgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentgivenname = value;
            SetDirty("Residentgivenname");
         }

      }

      [  SoapElement( ElementName = "ResidentLastName" )]
      [  XmlElement( ElementName = "ResidentLastName"   )]
      public string gxTpr_Residentlastname
      {
         get {
            return gxTv_SdtTrn_Memo_Residentlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentlastname = value;
            SetDirty("Residentlastname");
         }

      }

      [  SoapElement( ElementName = "ResidentGUID" )]
      [  XmlElement( ElementName = "ResidentGUID"   )]
      public string gxTpr_Residentguid
      {
         get {
            return gxTv_SdtTrn_Memo_Residentguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentguid = value;
            SetDirty("Residentguid");
         }

      }

      [  SoapElement( ElementName = "MemoBgColorCode" )]
      [  XmlElement( ElementName = "MemoBgColorCode"   )]
      public string gxTpr_Memobgcolorcode
      {
         get {
            return gxTv_SdtTrn_Memo_Memobgcolorcode ;
         }

         set {
            gxTv_SdtTrn_Memo_Memobgcolorcode_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memobgcolorcode = value;
            SetDirty("Memobgcolorcode");
         }

      }

      public void gxTv_SdtTrn_Memo_Memobgcolorcode_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memobgcolorcode_N = 1;
         gxTv_SdtTrn_Memo_Memobgcolorcode = "";
         SetDirty("Memobgcolorcode");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memobgcolorcode_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memobgcolorcode_N==1) ;
      }

      [  SoapElement( ElementName = "MemoForm" )]
      [  XmlElement( ElementName = "MemoForm"   )]
      public string gxTpr_Memoform
      {
         get {
            return gxTv_SdtTrn_Memo_Memoform ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoform = value;
            SetDirty("Memoform");
         }

      }

      [  SoapElement( ElementName = "SG_OrganisationId" )]
      [  XmlElement( ElementName = "SG_OrganisationId"   )]
      public Guid gxTpr_Sg_organisationid
      {
         get {
            return gxTv_SdtTrn_Memo_Sg_organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Sg_organisationid = value;
            SetDirty("Sg_organisationid");
         }

      }

      [  SoapElement( ElementName = "SG_LocationId" )]
      [  XmlElement( ElementName = "SG_LocationId"   )]
      public Guid gxTpr_Sg_locationid
      {
         get {
            return gxTv_SdtTrn_Memo_Sg_locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Sg_locationid = value;
            SetDirty("Sg_locationid");
         }

      }

      [  SoapElement( ElementName = "MemoType" )]
      [  XmlElement( ElementName = "MemoType"   )]
      public string gxTpr_Memotype
      {
         get {
            return gxTv_SdtTrn_Memo_Memotype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotype = value;
            SetDirty("Memotype");
         }

      }

      [  SoapElement( ElementName = "MemoName" )]
      [  XmlElement( ElementName = "MemoName"   )]
      public string gxTpr_Memoname
      {
         get {
            return gxTv_SdtTrn_Memo_Memoname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoname = value;
            SetDirty("Memoname");
         }

      }

      [  SoapElement( ElementName = "MemoLeftOffset" )]
      [  XmlElement( ElementName = "MemoLeftOffset"   )]
      public decimal gxTpr_Memoleftoffset
      {
         get {
            return gxTv_SdtTrn_Memo_Memoleftoffset ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoleftoffset = value;
            SetDirty("Memoleftoffset");
         }

      }

      [  SoapElement( ElementName = "MemoTopOffset" )]
      [  XmlElement( ElementName = "MemoTopOffset"   )]
      public decimal gxTpr_Memotopoffset
      {
         get {
            return gxTv_SdtTrn_Memo_Memotopoffset ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotopoffset = value;
            SetDirty("Memotopoffset");
         }

      }

      [  SoapElement( ElementName = "MemoTitleAngle" )]
      [  XmlElement( ElementName = "MemoTitleAngle"   )]
      public decimal gxTpr_Memotitleangle
      {
         get {
            return gxTv_SdtTrn_Memo_Memotitleangle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitleangle = value;
            SetDirty("Memotitleangle");
         }

      }

      [  SoapElement( ElementName = "MemoTitleScale" )]
      [  XmlElement( ElementName = "MemoTitleScale"   )]
      public decimal gxTpr_Memotitlescale
      {
         get {
            return gxTv_SdtTrn_Memo_Memotitlescale ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitlescale = value;
            SetDirty("Memotitlescale");
         }

      }

      [  SoapElement( ElementName = "MemoTextFontName" )]
      [  XmlElement( ElementName = "MemoTextFontName"   )]
      public string gxTpr_Memotextfontname
      {
         get {
            return gxTv_SdtTrn_Memo_Memotextfontname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextfontname = value;
            SetDirty("Memotextfontname");
         }

      }

      [  SoapElement( ElementName = "MemoTextAlignment" )]
      [  XmlElement( ElementName = "MemoTextAlignment"   )]
      public string gxTpr_Memotextalignment
      {
         get {
            return gxTv_SdtTrn_Memo_Memotextalignment ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextalignment = value;
            SetDirty("Memotextalignment");
         }

      }

      [  SoapElement( ElementName = "MemoIsBold" )]
      [  XmlElement( ElementName = "MemoIsBold"   )]
      public bool gxTpr_Memoisbold
      {
         get {
            return gxTv_SdtTrn_Memo_Memoisbold ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoisbold = value;
            SetDirty("Memoisbold");
         }

      }

      [  SoapElement( ElementName = "MemoIsItalic" )]
      [  XmlElement( ElementName = "MemoIsItalic"   )]
      public bool gxTpr_Memoisitalic
      {
         get {
            return gxTv_SdtTrn_Memo_Memoisitalic ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoisitalic = value;
            SetDirty("Memoisitalic");
         }

      }

      [  SoapElement( ElementName = "MemoIsCapitalized" )]
      [  XmlElement( ElementName = "MemoIsCapitalized"   )]
      public bool gxTpr_Memoiscapitalized
      {
         get {
            return gxTv_SdtTrn_Memo_Memoiscapitalized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoiscapitalized = value;
            SetDirty("Memoiscapitalized");
         }

      }

      [  SoapElement( ElementName = "MemoTextColor" )]
      [  XmlElement( ElementName = "MemoTextColor"   )]
      public string gxTpr_Memotextcolor
      {
         get {
            return gxTv_SdtTrn_Memo_Memotextcolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextcolor = value;
            SetDirty("Memotextcolor");
         }

      }

      [  SoapElement( ElementName = "MemoCreatedAt" )]
      [  XmlElement( ElementName = "MemoCreatedAt"  , IsNullable=true )]
      public string gxTpr_Memocreatedat_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memocreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Memo_Memocreatedat).value ;
         }

         set {
            gxTv_SdtTrn_Memo_Memocreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Memo_Memocreatedat = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memocreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memocreatedat
      {
         get {
            return gxTv_SdtTrn_Memo_Memocreatedat ;
         }

         set {
            gxTv_SdtTrn_Memo_Memocreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memocreatedat = value;
            SetDirty("Memocreatedat");
         }

      }

      public void gxTv_SdtTrn_Memo_Memocreatedat_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memocreatedat_N = 1;
         gxTv_SdtTrn_Memo_Memocreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Memocreatedat");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memocreatedat_IsNull( )
      {
         return (gxTv_SdtTrn_Memo_Memocreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Memo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Memo_Mode_SetNull( )
      {
         gxTv_SdtTrn_Memo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Memo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Memo_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Memo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoId_Z" )]
      [  XmlElement( ElementName = "MemoId_Z"   )]
      public Guid gxTpr_Memoid_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoid_Z = value;
            SetDirty("Memoid_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoid_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoid_Z = Guid.Empty;
         SetDirty("Memoid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoTitle_Z" )]
      [  XmlElement( ElementName = "MemoTitle_Z"   )]
      public string gxTpr_Memotitle_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitle_Z = value;
            SetDirty("Memotitle_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotitle_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotitle_Z = "";
         SetDirty("Memotitle_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoDescription_Z" )]
      [  XmlElement( ElementName = "MemoDescription_Z"   )]
      public string gxTpr_Memodescription_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memodescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memodescription_Z = value;
            SetDirty("Memodescription_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memodescription_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memodescription_Z = "";
         SetDirty("Memodescription_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memodescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoDocument_Z" )]
      [  XmlElement( ElementName = "MemoDocument_Z"   )]
      public string gxTpr_Memodocument_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memodocument_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memodocument_Z = value;
            SetDirty("Memodocument_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memodocument_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memodocument_Z = "";
         SetDirty("Memodocument_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memodocument_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoStartDateTime_Z" )]
      [  XmlElement( ElementName = "MemoStartDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Memostartdatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memostartdatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Memo_Memostartdatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Memo_Memostartdatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memostartdatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memostartdatetime_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memostartdatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memostartdatetime_Z = value;
            SetDirty("Memostartdatetime_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memostartdatetime_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memostartdatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Memostartdatetime_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memostartdatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoEndDateTime_Z" )]
      [  XmlElement( ElementName = "MemoEndDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Memoenddatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memoenddatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Memo_Memoenddatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Memo_Memoenddatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memoenddatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memoenddatetime_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoenddatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoenddatetime_Z = value;
            SetDirty("Memoenddatetime_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoenddatetime_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoenddatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Memoenddatetime_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoenddatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoDuration_Z" )]
      [  XmlElement( ElementName = "MemoDuration_Z"   )]
      public decimal gxTpr_Memoduration_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoduration_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoduration_Z = value;
            SetDirty("Memoduration_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoduration_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoduration_Z = 0;
         SetDirty("Memoduration_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoduration_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoRemoveDate_Z" )]
      [  XmlElement( ElementName = "MemoRemoveDate_Z"  , IsNullable=true )]
      public string gxTpr_Memoremovedate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memoremovedate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrn_Memo_Memoremovedate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrn_Memo_Memoremovedate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memoremovedate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memoremovedate_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoremovedate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoremovedate_Z = value;
            SetDirty("Memoremovedate_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoremovedate_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoremovedate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Memoremovedate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoremovedate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentId_Z" )]
      [  XmlElement( ElementName = "ResidentId_Z"   )]
      public Guid gxTpr_Residentid_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Residentid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentid_Z = value;
            SetDirty("Residentid_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Residentid_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Residentid_Z = Guid.Empty;
         SetDirty("Residentid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Residentid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentSalutation_Z" )]
      [  XmlElement( ElementName = "ResidentSalutation_Z"   )]
      public string gxTpr_Residentsalutation_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Residentsalutation_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentsalutation_Z = value;
            SetDirty("Residentsalutation_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Residentsalutation_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Residentsalutation_Z = "";
         SetDirty("Residentsalutation_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Residentsalutation_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGivenName_Z" )]
      [  XmlElement( ElementName = "ResidentGivenName_Z"   )]
      public string gxTpr_Residentgivenname_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Residentgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentgivenname_Z = value;
            SetDirty("Residentgivenname_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Residentgivenname_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Residentgivenname_Z = "";
         SetDirty("Residentgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Residentgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentLastName_Z" )]
      [  XmlElement( ElementName = "ResidentLastName_Z"   )]
      public string gxTpr_Residentlastname_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Residentlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentlastname_Z = value;
            SetDirty("Residentlastname_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Residentlastname_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Residentlastname_Z = "";
         SetDirty("Residentlastname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Residentlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGUID_Z" )]
      [  XmlElement( ElementName = "ResidentGUID_Z"   )]
      public string gxTpr_Residentguid_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Residentguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Residentguid_Z = value;
            SetDirty("Residentguid_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Residentguid_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Residentguid_Z = "";
         SetDirty("Residentguid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Residentguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoBgColorCode_Z" )]
      [  XmlElement( ElementName = "MemoBgColorCode_Z"   )]
      public string gxTpr_Memobgcolorcode_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memobgcolorcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memobgcolorcode_Z = value;
            SetDirty("Memobgcolorcode_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memobgcolorcode_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memobgcolorcode_Z = "";
         SetDirty("Memobgcolorcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memobgcolorcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoForm_Z" )]
      [  XmlElement( ElementName = "MemoForm_Z"   )]
      public string gxTpr_Memoform_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoform_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoform_Z = value;
            SetDirty("Memoform_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoform_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoform_Z = "";
         SetDirty("Memoform_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoform_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_OrganisationId_Z" )]
      [  XmlElement( ElementName = "SG_OrganisationId_Z"   )]
      public Guid gxTpr_Sg_organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Sg_organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Sg_organisationid_Z = value;
            SetDirty("Sg_organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Sg_organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Sg_organisationid_Z = Guid.Empty;
         SetDirty("Sg_organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Sg_organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_LocationId_Z" )]
      [  XmlElement( ElementName = "SG_LocationId_Z"   )]
      public Guid gxTpr_Sg_locationid_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Sg_locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Sg_locationid_Z = value;
            SetDirty("Sg_locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Sg_locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Sg_locationid_Z = Guid.Empty;
         SetDirty("Sg_locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Sg_locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoType_Z" )]
      [  XmlElement( ElementName = "MemoType_Z"   )]
      public string gxTpr_Memotype_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotype_Z = value;
            SetDirty("Memotype_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotype_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotype_Z = "";
         SetDirty("Memotype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoName_Z" )]
      [  XmlElement( ElementName = "MemoName_Z"   )]
      public string gxTpr_Memoname_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoname_Z = value;
            SetDirty("Memoname_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoname_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoname_Z = "";
         SetDirty("Memoname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoLeftOffset_Z" )]
      [  XmlElement( ElementName = "MemoLeftOffset_Z"   )]
      public decimal gxTpr_Memoleftoffset_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoleftoffset_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoleftoffset_Z = value;
            SetDirty("Memoleftoffset_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoleftoffset_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoleftoffset_Z = 0;
         SetDirty("Memoleftoffset_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoleftoffset_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoTopOffset_Z" )]
      [  XmlElement( ElementName = "MemoTopOffset_Z"   )]
      public decimal gxTpr_Memotopoffset_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotopoffset_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotopoffset_Z = value;
            SetDirty("Memotopoffset_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotopoffset_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotopoffset_Z = 0;
         SetDirty("Memotopoffset_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotopoffset_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoTitleAngle_Z" )]
      [  XmlElement( ElementName = "MemoTitleAngle_Z"   )]
      public decimal gxTpr_Memotitleangle_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotitleangle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitleangle_Z = value;
            SetDirty("Memotitleangle_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotitleangle_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotitleangle_Z = 0;
         SetDirty("Memotitleangle_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotitleangle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoTitleScale_Z" )]
      [  XmlElement( ElementName = "MemoTitleScale_Z"   )]
      public decimal gxTpr_Memotitlescale_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotitlescale_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotitlescale_Z = value;
            SetDirty("Memotitlescale_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotitlescale_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotitlescale_Z = 0;
         SetDirty("Memotitlescale_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotitlescale_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoTextFontName_Z" )]
      [  XmlElement( ElementName = "MemoTextFontName_Z"   )]
      public string gxTpr_Memotextfontname_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotextfontname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextfontname_Z = value;
            SetDirty("Memotextfontname_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotextfontname_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotextfontname_Z = "";
         SetDirty("Memotextfontname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotextfontname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoTextAlignment_Z" )]
      [  XmlElement( ElementName = "MemoTextAlignment_Z"   )]
      public string gxTpr_Memotextalignment_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotextalignment_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextalignment_Z = value;
            SetDirty("Memotextalignment_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotextalignment_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotextalignment_Z = "";
         SetDirty("Memotextalignment_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotextalignment_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoIsBold_Z" )]
      [  XmlElement( ElementName = "MemoIsBold_Z"   )]
      public bool gxTpr_Memoisbold_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoisbold_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoisbold_Z = value;
            SetDirty("Memoisbold_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoisbold_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoisbold_Z = false;
         SetDirty("Memoisbold_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoisbold_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoIsItalic_Z" )]
      [  XmlElement( ElementName = "MemoIsItalic_Z"   )]
      public bool gxTpr_Memoisitalic_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoisitalic_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoisitalic_Z = value;
            SetDirty("Memoisitalic_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoisitalic_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoisitalic_Z = false;
         SetDirty("Memoisitalic_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoisitalic_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoIsCapitalized_Z" )]
      [  XmlElement( ElementName = "MemoIsCapitalized_Z"   )]
      public bool gxTpr_Memoiscapitalized_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memoiscapitalized_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoiscapitalized_Z = value;
            SetDirty("Memoiscapitalized_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoiscapitalized_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoiscapitalized_Z = false;
         SetDirty("Memoiscapitalized_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoiscapitalized_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoTextColor_Z" )]
      [  XmlElement( ElementName = "MemoTextColor_Z"   )]
      public string gxTpr_Memotextcolor_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memotextcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memotextcolor_Z = value;
            SetDirty("Memotextcolor_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memotextcolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memotextcolor_Z = "";
         SetDirty("Memotextcolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memotextcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoCreatedAt_Z" )]
      [  XmlElement( ElementName = "MemoCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Memocreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Memo_Memocreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Memo_Memocreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Memo_Memocreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Memo_Memocreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Memocreatedat_Z
      {
         get {
            return gxTv_SdtTrn_Memo_Memocreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memocreatedat_Z = value;
            SetDirty("Memocreatedat_Z");
         }

      }

      public void gxTv_SdtTrn_Memo_Memocreatedat_Z_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memocreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Memocreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memocreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoImage_N" )]
      [  XmlElement( ElementName = "MemoImage_N"   )]
      public short gxTpr_Memoimage_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memoimage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoimage_N = value;
            SetDirty("Memoimage_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoimage_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoimage_N = 0;
         SetDirty("Memoimage_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoimage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoDocument_N" )]
      [  XmlElement( ElementName = "MemoDocument_N"   )]
      public short gxTpr_Memodocument_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memodocument_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memodocument_N = value;
            SetDirty("Memodocument_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memodocument_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memodocument_N = 0;
         SetDirty("Memodocument_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memodocument_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoStartDateTime_N" )]
      [  XmlElement( ElementName = "MemoStartDateTime_N"   )]
      public short gxTpr_Memostartdatetime_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memostartdatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memostartdatetime_N = value;
            SetDirty("Memostartdatetime_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memostartdatetime_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memostartdatetime_N = 0;
         SetDirty("Memostartdatetime_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memostartdatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoEndDateTime_N" )]
      [  XmlElement( ElementName = "MemoEndDateTime_N"   )]
      public short gxTpr_Memoenddatetime_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memoenddatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoenddatetime_N = value;
            SetDirty("Memoenddatetime_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoenddatetime_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoenddatetime_N = 0;
         SetDirty("Memoenddatetime_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoenddatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoDuration_N" )]
      [  XmlElement( ElementName = "MemoDuration_N"   )]
      public short gxTpr_Memoduration_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memoduration_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoduration_N = value;
            SetDirty("Memoduration_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoduration_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoduration_N = 0;
         SetDirty("Memoduration_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoduration_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoRemoveDate_N" )]
      [  XmlElement( ElementName = "MemoRemoveDate_N"   )]
      public short gxTpr_Memoremovedate_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memoremovedate_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memoremovedate_N = value;
            SetDirty("Memoremovedate_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memoremovedate_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memoremovedate_N = 0;
         SetDirty("Memoremovedate_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memoremovedate_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoBgColorCode_N" )]
      [  XmlElement( ElementName = "MemoBgColorCode_N"   )]
      public short gxTpr_Memobgcolorcode_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memobgcolorcode_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memobgcolorcode_N = value;
            SetDirty("Memobgcolorcode_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memobgcolorcode_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memobgcolorcode_N = 0;
         SetDirty("Memobgcolorcode_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memobgcolorcode_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoCreatedAt_N" )]
      [  XmlElement( ElementName = "MemoCreatedAt_N"   )]
      public short gxTpr_Memocreatedat_N
      {
         get {
            return gxTv_SdtTrn_Memo_Memocreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Memo_Memocreatedat_N = value;
            SetDirty("Memocreatedat_N");
         }

      }

      public void gxTv_SdtTrn_Memo_Memocreatedat_N_SetNull( )
      {
         gxTv_SdtTrn_Memo_Memocreatedat_N = 0;
         SetDirty("Memocreatedat_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Memo_Memocreatedat_N_IsNull( )
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
         gxTv_SdtTrn_Memo_Memoid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Memo_Memotitle = "";
         gxTv_SdtTrn_Memo_Memodescription = "";
         gxTv_SdtTrn_Memo_Memoimage = "";
         gxTv_SdtTrn_Memo_Memodocument = "";
         gxTv_SdtTrn_Memo_Memostartdatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Memo_Memoenddatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Memo_Memoremovedate = DateTime.MinValue;
         gxTv_SdtTrn_Memo_Residentid = Guid.Empty;
         gxTv_SdtTrn_Memo_Residentsalutation = "";
         gxTv_SdtTrn_Memo_Residentgivenname = "";
         gxTv_SdtTrn_Memo_Residentlastname = "";
         gxTv_SdtTrn_Memo_Residentguid = "";
         gxTv_SdtTrn_Memo_Memobgcolorcode = "";
         gxTv_SdtTrn_Memo_Memoform = "";
         gxTv_SdtTrn_Memo_Sg_organisationid = Guid.Empty;
         gxTv_SdtTrn_Memo_Sg_locationid = Guid.Empty;
         gxTv_SdtTrn_Memo_Memotype = "";
         gxTv_SdtTrn_Memo_Memoname = "";
         gxTv_SdtTrn_Memo_Memotextfontname = "";
         gxTv_SdtTrn_Memo_Memotextalignment = "";
         gxTv_SdtTrn_Memo_Memotextcolor = "";
         gxTv_SdtTrn_Memo_Memocreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Memo_Mode = "";
         gxTv_SdtTrn_Memo_Memoid_Z = Guid.Empty;
         gxTv_SdtTrn_Memo_Memotitle_Z = "";
         gxTv_SdtTrn_Memo_Memodescription_Z = "";
         gxTv_SdtTrn_Memo_Memodocument_Z = "";
         gxTv_SdtTrn_Memo_Memostartdatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Memo_Memoenddatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Memo_Memoremovedate_Z = DateTime.MinValue;
         gxTv_SdtTrn_Memo_Residentid_Z = Guid.Empty;
         gxTv_SdtTrn_Memo_Residentsalutation_Z = "";
         gxTv_SdtTrn_Memo_Residentgivenname_Z = "";
         gxTv_SdtTrn_Memo_Residentlastname_Z = "";
         gxTv_SdtTrn_Memo_Residentguid_Z = "";
         gxTv_SdtTrn_Memo_Memobgcolorcode_Z = "";
         gxTv_SdtTrn_Memo_Memoform_Z = "";
         gxTv_SdtTrn_Memo_Sg_organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Memo_Sg_locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Memo_Memotype_Z = "";
         gxTv_SdtTrn_Memo_Memoname_Z = "";
         gxTv_SdtTrn_Memo_Memotextfontname_Z = "";
         gxTv_SdtTrn_Memo_Memotextalignment_Z = "";
         gxTv_SdtTrn_Memo_Memotextcolor_Z = "";
         gxTv_SdtTrn_Memo_Memocreatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_memo", "GeneXus.Programs.trn_memo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Memo_Initialized ;
      private short gxTv_SdtTrn_Memo_Memoimage_N ;
      private short gxTv_SdtTrn_Memo_Memodocument_N ;
      private short gxTv_SdtTrn_Memo_Memostartdatetime_N ;
      private short gxTv_SdtTrn_Memo_Memoenddatetime_N ;
      private short gxTv_SdtTrn_Memo_Memoduration_N ;
      private short gxTv_SdtTrn_Memo_Memoremovedate_N ;
      private short gxTv_SdtTrn_Memo_Memobgcolorcode_N ;
      private short gxTv_SdtTrn_Memo_Memocreatedat_N ;
      private decimal gxTv_SdtTrn_Memo_Memoduration ;
      private decimal gxTv_SdtTrn_Memo_Memoleftoffset ;
      private decimal gxTv_SdtTrn_Memo_Memotopoffset ;
      private decimal gxTv_SdtTrn_Memo_Memotitleangle ;
      private decimal gxTv_SdtTrn_Memo_Memotitlescale ;
      private decimal gxTv_SdtTrn_Memo_Memoduration_Z ;
      private decimal gxTv_SdtTrn_Memo_Memoleftoffset_Z ;
      private decimal gxTv_SdtTrn_Memo_Memotopoffset_Z ;
      private decimal gxTv_SdtTrn_Memo_Memotitleangle_Z ;
      private decimal gxTv_SdtTrn_Memo_Memotitlescale_Z ;
      private string gxTv_SdtTrn_Memo_Residentsalutation ;
      private string gxTv_SdtTrn_Memo_Memoform ;
      private string gxTv_SdtTrn_Memo_Memotextalignment ;
      private string gxTv_SdtTrn_Memo_Mode ;
      private string gxTv_SdtTrn_Memo_Residentsalutation_Z ;
      private string gxTv_SdtTrn_Memo_Memoform_Z ;
      private string gxTv_SdtTrn_Memo_Memotextalignment_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_Memo_Memostartdatetime ;
      private DateTime gxTv_SdtTrn_Memo_Memoenddatetime ;
      private DateTime gxTv_SdtTrn_Memo_Memocreatedat ;
      private DateTime gxTv_SdtTrn_Memo_Memostartdatetime_Z ;
      private DateTime gxTv_SdtTrn_Memo_Memoenddatetime_Z ;
      private DateTime gxTv_SdtTrn_Memo_Memocreatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtTrn_Memo_Memoremovedate ;
      private DateTime gxTv_SdtTrn_Memo_Memoremovedate_Z ;
      private bool gxTv_SdtTrn_Memo_Memoisbold ;
      private bool gxTv_SdtTrn_Memo_Memoisitalic ;
      private bool gxTv_SdtTrn_Memo_Memoiscapitalized ;
      private bool gxTv_SdtTrn_Memo_Memoisbold_Z ;
      private bool gxTv_SdtTrn_Memo_Memoisitalic_Z ;
      private bool gxTv_SdtTrn_Memo_Memoiscapitalized_Z ;
      private string gxTv_SdtTrn_Memo_Memoimage ;
      private string gxTv_SdtTrn_Memo_Memotitle ;
      private string gxTv_SdtTrn_Memo_Memodescription ;
      private string gxTv_SdtTrn_Memo_Memodocument ;
      private string gxTv_SdtTrn_Memo_Residentgivenname ;
      private string gxTv_SdtTrn_Memo_Residentlastname ;
      private string gxTv_SdtTrn_Memo_Residentguid ;
      private string gxTv_SdtTrn_Memo_Memobgcolorcode ;
      private string gxTv_SdtTrn_Memo_Memotype ;
      private string gxTv_SdtTrn_Memo_Memoname ;
      private string gxTv_SdtTrn_Memo_Memotextfontname ;
      private string gxTv_SdtTrn_Memo_Memotextcolor ;
      private string gxTv_SdtTrn_Memo_Memotitle_Z ;
      private string gxTv_SdtTrn_Memo_Memodescription_Z ;
      private string gxTv_SdtTrn_Memo_Memodocument_Z ;
      private string gxTv_SdtTrn_Memo_Residentgivenname_Z ;
      private string gxTv_SdtTrn_Memo_Residentlastname_Z ;
      private string gxTv_SdtTrn_Memo_Residentguid_Z ;
      private string gxTv_SdtTrn_Memo_Memobgcolorcode_Z ;
      private string gxTv_SdtTrn_Memo_Memotype_Z ;
      private string gxTv_SdtTrn_Memo_Memoname_Z ;
      private string gxTv_SdtTrn_Memo_Memotextfontname_Z ;
      private string gxTv_SdtTrn_Memo_Memotextcolor_Z ;
      private Guid gxTv_SdtTrn_Memo_Memoid ;
      private Guid gxTv_SdtTrn_Memo_Residentid ;
      private Guid gxTv_SdtTrn_Memo_Sg_organisationid ;
      private Guid gxTv_SdtTrn_Memo_Sg_locationid ;
      private Guid gxTv_SdtTrn_Memo_Memoid_Z ;
      private Guid gxTv_SdtTrn_Memo_Residentid_Z ;
      private Guid gxTv_SdtTrn_Memo_Sg_organisationid_Z ;
      private Guid gxTv_SdtTrn_Memo_Sg_locationid_Z ;
   }

   [DataContract(Name = @"Trn_Memo", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Memo_RESTInterface : GxGenericCollectionItem<SdtTrn_Memo>
   {
      public SdtTrn_Memo_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Memo_RESTInterface( SdtTrn_Memo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MemoId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Memoid
      {
         get {
            return sdt.gxTpr_Memoid ;
         }

         set {
            sdt.gxTpr_Memoid = value;
         }

      }

      [DataMember( Name = "MemoTitle" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Memotitle
      {
         get {
            return sdt.gxTpr_Memotitle ;
         }

         set {
            sdt.gxTpr_Memotitle = value;
         }

      }

      [DataMember( Name = "MemoDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Memodescription
      {
         get {
            return sdt.gxTpr_Memodescription ;
         }

         set {
            sdt.gxTpr_Memodescription = value;
         }

      }

      [DataMember( Name = "MemoImage" , Order = 3 )]
      public string gxTpr_Memoimage
      {
         get {
            return sdt.gxTpr_Memoimage ;
         }

         set {
            sdt.gxTpr_Memoimage = value;
         }

      }

      [DataMember( Name = "MemoDocument" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Memodocument
      {
         get {
            return sdt.gxTpr_Memodocument ;
         }

         set {
            sdt.gxTpr_Memodocument = value;
         }

      }

      [DataMember( Name = "MemoStartDateTime" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Memostartdatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Memostartdatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Memostartdatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "MemoEndDateTime" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Memoenddatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Memoenddatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Memoenddatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "MemoDuration" , Order = 7 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Memoduration
      {
         get {
            return sdt.gxTpr_Memoduration ;
         }

         set {
            sdt.gxTpr_Memoduration = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MemoRemoveDate" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Memoremovedate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Memoremovedate) ;
         }

         set {
            sdt.gxTpr_Memoremovedate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ResidentId" , Order = 9 )]
      [GxSeudo()]
      public Guid gxTpr_Residentid
      {
         get {
            return sdt.gxTpr_Residentid ;
         }

         set {
            sdt.gxTpr_Residentid = value;
         }

      }

      [DataMember( Name = "ResidentSalutation" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Residentsalutation
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentsalutation) ;
         }

         set {
            sdt.gxTpr_Residentsalutation = value;
         }

      }

      [DataMember( Name = "ResidentGivenName" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Residentgivenname
      {
         get {
            return sdt.gxTpr_Residentgivenname ;
         }

         set {
            sdt.gxTpr_Residentgivenname = value;
         }

      }

      [DataMember( Name = "ResidentLastName" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Residentlastname
      {
         get {
            return sdt.gxTpr_Residentlastname ;
         }

         set {
            sdt.gxTpr_Residentlastname = value;
         }

      }

      [DataMember( Name = "ResidentGUID" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Residentguid
      {
         get {
            return sdt.gxTpr_Residentguid ;
         }

         set {
            sdt.gxTpr_Residentguid = value;
         }

      }

      [DataMember( Name = "MemoBgColorCode" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Memobgcolorcode
      {
         get {
            return sdt.gxTpr_Memobgcolorcode ;
         }

         set {
            sdt.gxTpr_Memobgcolorcode = value;
         }

      }

      [DataMember( Name = "MemoForm" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Memoform
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Memoform) ;
         }

         set {
            sdt.gxTpr_Memoform = value;
         }

      }

      [DataMember( Name = "SG_OrganisationId" , Order = 16 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_organisationid
      {
         get {
            return sdt.gxTpr_Sg_organisationid ;
         }

         set {
            sdt.gxTpr_Sg_organisationid = value;
         }

      }

      [DataMember( Name = "SG_LocationId" , Order = 17 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_locationid
      {
         get {
            return sdt.gxTpr_Sg_locationid ;
         }

         set {
            sdt.gxTpr_Sg_locationid = value;
         }

      }

      [DataMember( Name = "MemoType" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Memotype
      {
         get {
            return sdt.gxTpr_Memotype ;
         }

         set {
            sdt.gxTpr_Memotype = value;
         }

      }

      [DataMember( Name = "MemoName" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Memoname
      {
         get {
            return sdt.gxTpr_Memoname ;
         }

         set {
            sdt.gxTpr_Memoname = value;
         }

      }

      [DataMember( Name = "MemoLeftOffset" , Order = 20 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Memoleftoffset
      {
         get {
            return sdt.gxTpr_Memoleftoffset ;
         }

         set {
            sdt.gxTpr_Memoleftoffset = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MemoTopOffset" , Order = 21 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Memotopoffset
      {
         get {
            return sdt.gxTpr_Memotopoffset ;
         }

         set {
            sdt.gxTpr_Memotopoffset = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MemoTitleAngle" , Order = 22 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Memotitleangle
      {
         get {
            return sdt.gxTpr_Memotitleangle ;
         }

         set {
            sdt.gxTpr_Memotitleangle = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MemoTitleScale" , Order = 23 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Memotitlescale
      {
         get {
            return sdt.gxTpr_Memotitlescale ;
         }

         set {
            sdt.gxTpr_Memotitlescale = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MemoTextFontName" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Memotextfontname
      {
         get {
            return sdt.gxTpr_Memotextfontname ;
         }

         set {
            sdt.gxTpr_Memotextfontname = value;
         }

      }

      [DataMember( Name = "MemoTextAlignment" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Memotextalignment
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Memotextalignment) ;
         }

         set {
            sdt.gxTpr_Memotextalignment = value;
         }

      }

      [DataMember( Name = "MemoIsBold" , Order = 26 )]
      [GxSeudo()]
      public bool gxTpr_Memoisbold
      {
         get {
            return sdt.gxTpr_Memoisbold ;
         }

         set {
            sdt.gxTpr_Memoisbold = value;
         }

      }

      [DataMember( Name = "MemoIsItalic" , Order = 27 )]
      [GxSeudo()]
      public bool gxTpr_Memoisitalic
      {
         get {
            return sdt.gxTpr_Memoisitalic ;
         }

         set {
            sdt.gxTpr_Memoisitalic = value;
         }

      }

      [DataMember( Name = "MemoIsCapitalized" , Order = 28 )]
      [GxSeudo()]
      public bool gxTpr_Memoiscapitalized
      {
         get {
            return sdt.gxTpr_Memoiscapitalized ;
         }

         set {
            sdt.gxTpr_Memoiscapitalized = value;
         }

      }

      [DataMember( Name = "MemoTextColor" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Memotextcolor
      {
         get {
            return sdt.gxTpr_Memotextcolor ;
         }

         set {
            sdt.gxTpr_Memotextcolor = value;
         }

      }

      [DataMember( Name = "MemoCreatedAt" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Memocreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Memocreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Memocreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtTrn_Memo sdt
      {
         get {
            return (SdtTrn_Memo)Sdt ;
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
            sdt = new SdtTrn_Memo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 31 )]
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

   [DataContract(Name = @"Trn_Memo", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Memo_RESTLInterface : GxGenericCollectionItem<SdtTrn_Memo>
   {
      public SdtTrn_Memo_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Memo_RESTLInterface( SdtTrn_Memo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MemoTitle" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Memotitle
      {
         get {
            return sdt.gxTpr_Memotitle ;
         }

         set {
            sdt.gxTpr_Memotitle = value;
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

      public SdtTrn_Memo sdt
      {
         get {
            return (SdtTrn_Memo)Sdt ;
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
            sdt = new SdtTrn_Memo() ;
         }
      }

   }

}
