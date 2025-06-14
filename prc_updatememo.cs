using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_updatememo : GXProcedure
   {
      public prc_updatememo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatememo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoId ,
                           string aP1_ResidentGUID ,
                           string aP2_MemoTitle ,
                           string aP3_MemoDescription ,
                           string aP4_MemoImage ,
                           string aP5_MemoDocument ,
                           DateTime aP6_MemoStartDateTime ,
                           DateTime aP7_MemoEndDateTime ,
                           decimal aP8_MemoDuration ,
                           DateTime aP9_MemoRemoveDate ,
                           string aP10_MemoBgColorCode ,
                           string aP11_MemoForm ,
                           string aP12_MemoType ,
                           string aP13_MemoName ,
                           decimal aP14_MemoLeftOffset ,
                           decimal aP15_MemoTopOffset ,
                           decimal aP16_MemoTitleAngle ,
                           decimal aP17_MemoTitleScale ,
                           string aP18_MemoTextFontName ,
                           string aP19_MemoTextAlignment ,
                           bool aP20_MemoIsBold ,
                           bool aP21_MemoIsItalic ,
                           bool aP22_MemoIsCapitalized ,
                           string aP23_MemoTextColor ,
                           out SdtSDT_Error aP24_Error )
      {
         this.AV17MemoId = aP0_MemoId;
         this.AV23ResidentGUID = aP1_ResidentGUID;
         this.AV21MemoTitle = aP2_MemoTitle;
         this.AV12MemoDescription = aP3_MemoDescription;
         this.AV18MemoImage = aP4_MemoImage;
         this.AV13MemoDocument = aP5_MemoDocument;
         this.AV20MemoStartDateTime = aP6_MemoStartDateTime;
         this.AV15MemoEndDateTime = aP7_MemoEndDateTime;
         this.AV14MemoDuration = aP8_MemoDuration;
         this.AV19MemoRemoveDate = aP9_MemoRemoveDate;
         this.AV10MemoBgColorCode = aP10_MemoBgColorCode;
         this.AV16MemoForm = aP11_MemoForm;
         this.AV27MemoType = aP12_MemoType;
         this.AV28MemoName = aP13_MemoName;
         this.AV29MemoLeftOffset = aP14_MemoLeftOffset;
         this.AV30MemoTopOffset = aP15_MemoTopOffset;
         this.AV31MemoTitleAngle = aP16_MemoTitleAngle;
         this.AV26MemoTitleScale = aP17_MemoTitleScale;
         this.AV32MemoTextFontName = aP18_MemoTextFontName;
         this.AV33MemoTextAlignment = aP19_MemoTextAlignment;
         this.AV34MemoIsBold = aP20_MemoIsBold;
         this.AV35MemoIsItalic = aP21_MemoIsItalic;
         this.AV36MemoIsCapitalized = aP22_MemoIsCapitalized;
         this.AV37MemoTextColor = aP23_MemoTextColor;
         this.AV8Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP24_Error=this.AV8Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_MemoId ,
                                      string aP1_ResidentGUID ,
                                      string aP2_MemoTitle ,
                                      string aP3_MemoDescription ,
                                      string aP4_MemoImage ,
                                      string aP5_MemoDocument ,
                                      DateTime aP6_MemoStartDateTime ,
                                      DateTime aP7_MemoEndDateTime ,
                                      decimal aP8_MemoDuration ,
                                      DateTime aP9_MemoRemoveDate ,
                                      string aP10_MemoBgColorCode ,
                                      string aP11_MemoForm ,
                                      string aP12_MemoType ,
                                      string aP13_MemoName ,
                                      decimal aP14_MemoLeftOffset ,
                                      decimal aP15_MemoTopOffset ,
                                      decimal aP16_MemoTitleAngle ,
                                      decimal aP17_MemoTitleScale ,
                                      string aP18_MemoTextFontName ,
                                      string aP19_MemoTextAlignment ,
                                      bool aP20_MemoIsBold ,
                                      bool aP21_MemoIsItalic ,
                                      bool aP22_MemoIsCapitalized ,
                                      string aP23_MemoTextColor )
      {
         execute(aP0_MemoId, aP1_ResidentGUID, aP2_MemoTitle, aP3_MemoDescription, aP4_MemoImage, aP5_MemoDocument, aP6_MemoStartDateTime, aP7_MemoEndDateTime, aP8_MemoDuration, aP9_MemoRemoveDate, aP10_MemoBgColorCode, aP11_MemoForm, aP12_MemoType, aP13_MemoName, aP14_MemoLeftOffset, aP15_MemoTopOffset, aP16_MemoTitleAngle, aP17_MemoTitleScale, aP18_MemoTextFontName, aP19_MemoTextAlignment, aP20_MemoIsBold, aP21_MemoIsItalic, aP22_MemoIsCapitalized, aP23_MemoTextColor, out aP24_Error);
         return AV8Error ;
      }

      public void executeSubmit( Guid aP0_MemoId ,
                                 string aP1_ResidentGUID ,
                                 string aP2_MemoTitle ,
                                 string aP3_MemoDescription ,
                                 string aP4_MemoImage ,
                                 string aP5_MemoDocument ,
                                 DateTime aP6_MemoStartDateTime ,
                                 DateTime aP7_MemoEndDateTime ,
                                 decimal aP8_MemoDuration ,
                                 DateTime aP9_MemoRemoveDate ,
                                 string aP10_MemoBgColorCode ,
                                 string aP11_MemoForm ,
                                 string aP12_MemoType ,
                                 string aP13_MemoName ,
                                 decimal aP14_MemoLeftOffset ,
                                 decimal aP15_MemoTopOffset ,
                                 decimal aP16_MemoTitleAngle ,
                                 decimal aP17_MemoTitleScale ,
                                 string aP18_MemoTextFontName ,
                                 string aP19_MemoTextAlignment ,
                                 bool aP20_MemoIsBold ,
                                 bool aP21_MemoIsItalic ,
                                 bool aP22_MemoIsCapitalized ,
                                 string aP23_MemoTextColor ,
                                 out SdtSDT_Error aP24_Error )
      {
         this.AV17MemoId = aP0_MemoId;
         this.AV23ResidentGUID = aP1_ResidentGUID;
         this.AV21MemoTitle = aP2_MemoTitle;
         this.AV12MemoDescription = aP3_MemoDescription;
         this.AV18MemoImage = aP4_MemoImage;
         this.AV13MemoDocument = aP5_MemoDocument;
         this.AV20MemoStartDateTime = aP6_MemoStartDateTime;
         this.AV15MemoEndDateTime = aP7_MemoEndDateTime;
         this.AV14MemoDuration = aP8_MemoDuration;
         this.AV19MemoRemoveDate = aP9_MemoRemoveDate;
         this.AV10MemoBgColorCode = aP10_MemoBgColorCode;
         this.AV16MemoForm = aP11_MemoForm;
         this.AV27MemoType = aP12_MemoType;
         this.AV28MemoName = aP13_MemoName;
         this.AV29MemoLeftOffset = aP14_MemoLeftOffset;
         this.AV30MemoTopOffset = aP15_MemoTopOffset;
         this.AV31MemoTitleAngle = aP16_MemoTitleAngle;
         this.AV26MemoTitleScale = aP17_MemoTitleScale;
         this.AV32MemoTextFontName = aP18_MemoTextFontName;
         this.AV33MemoTextAlignment = aP19_MemoTextAlignment;
         this.AV34MemoIsBold = aP20_MemoIsBold;
         this.AV35MemoIsItalic = aP21_MemoIsItalic;
         this.AV36MemoIsCapitalized = aP22_MemoIsCapitalized;
         this.AV37MemoTextColor = aP23_MemoTextColor;
         this.AV8Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP24_Error=this.AV8Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D12 */
         pr_default.execute(0, new Object[] {AV23ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00D12_A71ResidentGUID[0];
            A62ResidentId = P00D12_A62ResidentId[0];
            A29LocationId = P00D12_A29LocationId[0];
            A11OrganisationId = P00D12_A11OrganisationId[0];
            AV24ResidentId = A62ResidentId;
            AV9LocationId = A29LocationId;
            AV22OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV25Trn_Memo.Load(AV17MemoId);
         if ( AV25Trn_Memo.gxTpr_Residentid == AV24ResidentId )
         {
            AV25Trn_Memo.gxTpr_Sg_organisationid = AV22OrganisationId;
            AV25Trn_Memo.gxTpr_Sg_locationid = AV9LocationId;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MemoTitle)) )
            {
               AV25Trn_Memo.gxTpr_Memotitle = AV21MemoTitle;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12MemoDescription)) )
            {
               AV25Trn_Memo.gxTpr_Memodescription = AV12MemoDescription;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18MemoImage)) )
            {
               AV25Trn_Memo.gxTpr_Memoimage = AV18MemoImage;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13MemoDocument)) )
            {
               AV25Trn_Memo.gxTpr_Memodocument = AV13MemoDocument;
            }
            if ( ! (DateTime.MinValue==AV20MemoStartDateTime) )
            {
               AV25Trn_Memo.gxTpr_Memostartdatetime = AV20MemoStartDateTime;
            }
            if ( ! (DateTime.MinValue==AV15MemoEndDateTime) )
            {
               AV25Trn_Memo.gxTpr_Memoenddatetime = AV15MemoEndDateTime;
            }
            if ( ! (Convert.ToDecimal(0)==AV14MemoDuration) )
            {
               AV25Trn_Memo.gxTpr_Memoduration = AV14MemoDuration;
            }
            if ( ! (DateTime.MinValue==AV19MemoRemoveDate) )
            {
               AV25Trn_Memo.gxTpr_Memoremovedate = AV19MemoRemoveDate;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10MemoBgColorCode)) )
            {
               AV25Trn_Memo.gxTpr_Memobgcolorcode = AV10MemoBgColorCode;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16MemoForm)) )
            {
               AV25Trn_Memo.gxTpr_Memoform = AV16MemoForm;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27MemoType)) )
            {
               AV25Trn_Memo.gxTpr_Memotype = AV27MemoType;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MemoName)) )
            {
               AV25Trn_Memo.gxTpr_Memoname = AV28MemoName;
            }
            if ( ! (Convert.ToDecimal(0)==AV29MemoLeftOffset) )
            {
               AV25Trn_Memo.gxTpr_Memoleftoffset = AV29MemoLeftOffset;
            }
            if ( ! (Convert.ToDecimal(0)==AV30MemoTopOffset) )
            {
               AV25Trn_Memo.gxTpr_Memotopoffset = AV30MemoTopOffset;
            }
            if ( ! (Convert.ToDecimal(0)==AV31MemoTitleAngle) )
            {
               AV25Trn_Memo.gxTpr_Memotitleangle = AV31MemoTitleAngle;
            }
            if ( ! (Convert.ToDecimal(0)==AV26MemoTitleScale) )
            {
               AV25Trn_Memo.gxTpr_Memotitlescale = AV26MemoTitleScale;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32MemoTextFontName)) )
            {
               AV25Trn_Memo.gxTpr_Memotextfontname = AV32MemoTextFontName;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33MemoTextAlignment)) )
            {
               AV25Trn_Memo.gxTpr_Memotextalignment = AV33MemoTextAlignment;
            }
            if ( ! (false==AV34MemoIsBold) )
            {
               AV25Trn_Memo.gxTpr_Memoisbold = AV34MemoIsBold;
            }
            if ( ! (false==AV35MemoIsItalic) )
            {
               AV25Trn_Memo.gxTpr_Memoisitalic = AV35MemoIsItalic;
            }
            if ( ! (false==AV36MemoIsCapitalized) )
            {
               AV25Trn_Memo.gxTpr_Memoiscapitalized = AV36MemoIsCapitalized;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37MemoTextColor)) )
            {
               AV25Trn_Memo.gxTpr_Memotextcolor = AV37MemoTextColor;
            }
            AV25Trn_Memo.Save();
            if ( AV25Trn_Memo.Success() )
            {
               context.CommitDataStores("prc_updatememo",pr_default);
               AV8Error.gxTpr_Status = context.GetMessage( "Success", "");
               AV8Error.gxTpr_Message = context.GetMessage( "Memo created successfully", "");
            }
            else
            {
               AV8Error.gxTpr_Status = context.GetMessage( "Error", "");
               AV8Error.gxTpr_Message = context.GetMessage( "Failed to update memo", "");
               context.RollbackDataStores("prc_updatememo",pr_default);
            }
         }
         else
         {
            AV8Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8Error.gxTpr_Message = context.GetMessage( "Failed to update memo, the memo does not belong to the resident", "");
            context.RollbackDataStores("prc_updatememo",pr_default);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8Error = new SdtSDT_Error(context);
         P00D12_A71ResidentGUID = new string[] {""} ;
         P00D12_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00D12_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV24ResidentId = Guid.Empty;
         AV9LocationId = Guid.Empty;
         AV22OrganisationId = Guid.Empty;
         AV25Trn_Memo = new SdtTrn_Memo(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatememo__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatememo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatememo__default(),
            new Object[][] {
                new Object[] {
               P00D12_A71ResidentGUID, P00D12_A62ResidentId, P00D12_A29LocationId, P00D12_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private decimal AV14MemoDuration ;
      private decimal AV29MemoLeftOffset ;
      private decimal AV30MemoTopOffset ;
      private decimal AV31MemoTitleAngle ;
      private decimal AV26MemoTitleScale ;
      private string AV16MemoForm ;
      private string AV33MemoTextAlignment ;
      private DateTime AV20MemoStartDateTime ;
      private DateTime AV15MemoEndDateTime ;
      private DateTime AV19MemoRemoveDate ;
      private bool AV34MemoIsBold ;
      private bool AV35MemoIsItalic ;
      private bool AV36MemoIsCapitalized ;
      private string AV18MemoImage ;
      private string AV23ResidentGUID ;
      private string AV21MemoTitle ;
      private string AV12MemoDescription ;
      private string AV13MemoDocument ;
      private string AV10MemoBgColorCode ;
      private string AV27MemoType ;
      private string AV28MemoName ;
      private string AV32MemoTextFontName ;
      private string AV37MemoTextColor ;
      private string A71ResidentGUID ;
      private Guid AV17MemoId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV24ResidentId ;
      private Guid AV9LocationId ;
      private Guid AV22OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV8Error ;
      private IDataStoreProvider pr_default ;
      private string[] P00D12_A71ResidentGUID ;
      private Guid[] P00D12_A62ResidentId ;
      private Guid[] P00D12_A29LocationId ;
      private Guid[] P00D12_A11OrganisationId ;
      private SdtTrn_Memo AV25Trn_Memo ;
      private SdtSDT_Error aP24_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatememo__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_updatememo__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_updatememo__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00D12;
       prmP00D12 = new Object[] {
       new ParDef("AV23ResidentGUID",GXType.VarChar,100,60)
       };
       def= new CursorDef[] {
           new CursorDef("P00D12", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV23ResidentGUID) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D12,100, GxCacheFrequency.OFF ,false,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
    }
 }

}

}
