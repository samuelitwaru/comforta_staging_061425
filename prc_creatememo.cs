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
   public class prc_creatememo : GXProcedure
   {
      public prc_creatememo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_creatememo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentGUID ,
                           string aP1_MemoTitle ,
                           string aP2_MemoDescription ,
                           string aP3_MemoImage ,
                           string aP4_MemoDocument ,
                           DateTime aP5_MemoStartDateTime ,
                           DateTime aP6_MemoEndDateTime ,
                           decimal aP7_MemoDuration ,
                           DateTime aP8_MemoRemoveDate ,
                           string aP9_MemoBgColorCode ,
                           string aP10_MemoForm ,
                           string aP11_MemoType ,
                           string aP12_MemoName ,
                           decimal aP13_MemoLeftOffset ,
                           decimal aP14_MemoTopOffset ,
                           decimal aP15_MemoTitleAngle ,
                           decimal aP16_MemoTitleScale ,
                           string aP17_MemoTextFontName ,
                           string aP18_MemoTextAlignment ,
                           bool aP19_MemoIsBold ,
                           bool aP20_MemoIsItalic ,
                           bool aP21_MemoIsCapitalized ,
                           string aP22_MemoTextColor ,
                           out SdtSDT_Error aP23_Error )
      {
         this.AV19ResidentGUID = aP0_ResidentGUID;
         this.AV18MemoTitle = aP1_MemoTitle;
         this.AV11MemoDescription = aP2_MemoDescription;
         this.AV15MemoImage = aP3_MemoImage;
         this.AV12MemoDocument = aP4_MemoDocument;
         this.AV17MemoStartDateTime = aP5_MemoStartDateTime;
         this.AV14MemoEndDateTime = aP6_MemoEndDateTime;
         this.AV13MemoDuration = aP7_MemoDuration;
         this.AV16MemoRemoveDate = aP8_MemoRemoveDate;
         this.AV23MemoBgColorCode = aP9_MemoBgColorCode;
         this.AV24MemoForm = aP10_MemoForm;
         this.AV27MemoType = aP11_MemoType;
         this.AV28MemoName = aP12_MemoName;
         this.AV29MemoLeftOffset = aP13_MemoLeftOffset;
         this.AV30MemoTopOffset = aP14_MemoTopOffset;
         this.AV31MemoTitleAngle = aP15_MemoTitleAngle;
         this.AV26MemoTitleScale = aP16_MemoTitleScale;
         this.AV32MemoTextFontName = aP17_MemoTextFontName;
         this.AV33MemoTextAlignment = aP18_MemoTextAlignment;
         this.AV34MemoIsBold = aP19_MemoIsBold;
         this.AV35MemoIsItalic = aP20_MemoIsItalic;
         this.AV36MemoIsCapitalized = aP21_MemoIsCapitalized;
         this.AV37MemoTextColor = aP22_MemoTextColor;
         this.AV9Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP23_Error=this.AV9Error;
      }

      public SdtSDT_Error executeUdp( string aP0_ResidentGUID ,
                                      string aP1_MemoTitle ,
                                      string aP2_MemoDescription ,
                                      string aP3_MemoImage ,
                                      string aP4_MemoDocument ,
                                      DateTime aP5_MemoStartDateTime ,
                                      DateTime aP6_MemoEndDateTime ,
                                      decimal aP7_MemoDuration ,
                                      DateTime aP8_MemoRemoveDate ,
                                      string aP9_MemoBgColorCode ,
                                      string aP10_MemoForm ,
                                      string aP11_MemoType ,
                                      string aP12_MemoName ,
                                      decimal aP13_MemoLeftOffset ,
                                      decimal aP14_MemoTopOffset ,
                                      decimal aP15_MemoTitleAngle ,
                                      decimal aP16_MemoTitleScale ,
                                      string aP17_MemoTextFontName ,
                                      string aP18_MemoTextAlignment ,
                                      bool aP19_MemoIsBold ,
                                      bool aP20_MemoIsItalic ,
                                      bool aP21_MemoIsCapitalized ,
                                      string aP22_MemoTextColor )
      {
         execute(aP0_ResidentGUID, aP1_MemoTitle, aP2_MemoDescription, aP3_MemoImage, aP4_MemoDocument, aP5_MemoStartDateTime, aP6_MemoEndDateTime, aP7_MemoDuration, aP8_MemoRemoveDate, aP9_MemoBgColorCode, aP10_MemoForm, aP11_MemoType, aP12_MemoName, aP13_MemoLeftOffset, aP14_MemoTopOffset, aP15_MemoTitleAngle, aP16_MemoTitleScale, aP17_MemoTextFontName, aP18_MemoTextAlignment, aP19_MemoIsBold, aP20_MemoIsItalic, aP21_MemoIsCapitalized, aP22_MemoTextColor, out aP23_Error);
         return AV9Error ;
      }

      public void executeSubmit( string aP0_ResidentGUID ,
                                 string aP1_MemoTitle ,
                                 string aP2_MemoDescription ,
                                 string aP3_MemoImage ,
                                 string aP4_MemoDocument ,
                                 DateTime aP5_MemoStartDateTime ,
                                 DateTime aP6_MemoEndDateTime ,
                                 decimal aP7_MemoDuration ,
                                 DateTime aP8_MemoRemoveDate ,
                                 string aP9_MemoBgColorCode ,
                                 string aP10_MemoForm ,
                                 string aP11_MemoType ,
                                 string aP12_MemoName ,
                                 decimal aP13_MemoLeftOffset ,
                                 decimal aP14_MemoTopOffset ,
                                 decimal aP15_MemoTitleAngle ,
                                 decimal aP16_MemoTitleScale ,
                                 string aP17_MemoTextFontName ,
                                 string aP18_MemoTextAlignment ,
                                 bool aP19_MemoIsBold ,
                                 bool aP20_MemoIsItalic ,
                                 bool aP21_MemoIsCapitalized ,
                                 string aP22_MemoTextColor ,
                                 out SdtSDT_Error aP23_Error )
      {
         this.AV19ResidentGUID = aP0_ResidentGUID;
         this.AV18MemoTitle = aP1_MemoTitle;
         this.AV11MemoDescription = aP2_MemoDescription;
         this.AV15MemoImage = aP3_MemoImage;
         this.AV12MemoDocument = aP4_MemoDocument;
         this.AV17MemoStartDateTime = aP5_MemoStartDateTime;
         this.AV14MemoEndDateTime = aP6_MemoEndDateTime;
         this.AV13MemoDuration = aP7_MemoDuration;
         this.AV16MemoRemoveDate = aP8_MemoRemoveDate;
         this.AV23MemoBgColorCode = aP9_MemoBgColorCode;
         this.AV24MemoForm = aP10_MemoForm;
         this.AV27MemoType = aP11_MemoType;
         this.AV28MemoName = aP12_MemoName;
         this.AV29MemoLeftOffset = aP13_MemoLeftOffset;
         this.AV30MemoTopOffset = aP14_MemoTopOffset;
         this.AV31MemoTitleAngle = aP15_MemoTitleAngle;
         this.AV26MemoTitleScale = aP16_MemoTitleScale;
         this.AV32MemoTextFontName = aP17_MemoTextFontName;
         this.AV33MemoTextAlignment = aP18_MemoTextAlignment;
         this.AV34MemoIsBold = aP19_MemoIsBold;
         this.AV35MemoIsItalic = aP20_MemoIsItalic;
         this.AV36MemoIsCapitalized = aP21_MemoIsCapitalized;
         this.AV37MemoTextColor = aP22_MemoTextColor;
         this.AV9Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP23_Error=this.AV9Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CX2 */
         pr_default.execute(0, new Object[] {AV19ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00CX2_A71ResidentGUID[0];
            A62ResidentId = P00CX2_A62ResidentId[0];
            A29LocationId = P00CX2_A29LocationId[0];
            A11OrganisationId = P00CX2_A11OrganisationId[0];
            AV20ResidentId = A62ResidentId;
            AV22LocationId = A29LocationId;
            AV25OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV21Trn_Memo = new SdtTrn_Memo(context);
         AV21Trn_Memo.gxTpr_Memotitle = AV18MemoTitle;
         AV21Trn_Memo.gxTpr_Memodescription = AV11MemoDescription;
         AV21Trn_Memo.gxTpr_Memoimage = AV15MemoImage;
         AV21Trn_Memo.gxTpr_Memodocument = AV12MemoDocument;
         AV21Trn_Memo.gxTpr_Memostartdatetime = AV17MemoStartDateTime;
         AV21Trn_Memo.gxTpr_Memoenddatetime = AV14MemoEndDateTime;
         AV21Trn_Memo.gxTpr_Memoduration = AV13MemoDuration;
         AV21Trn_Memo.gxTpr_Memoremovedate = AV16MemoRemoveDate;
         AV21Trn_Memo.gxTpr_Residentid = AV20ResidentId;
         AV21Trn_Memo.gxTpr_Memobgcolorcode = AV23MemoBgColorCode;
         AV21Trn_Memo.gxTpr_Memoform = AV24MemoForm;
         AV21Trn_Memo.gxTpr_Sg_organisationid = AV25OrganisationId;
         AV21Trn_Memo.gxTpr_Sg_locationid = AV22LocationId;
         AV21Trn_Memo.gxTpr_Memotype = AV27MemoType;
         AV21Trn_Memo.gxTpr_Memoname = AV28MemoName;
         AV21Trn_Memo.gxTpr_Memoleftoffset = AV29MemoLeftOffset;
         AV21Trn_Memo.gxTpr_Memotopoffset = AV30MemoTopOffset;
         AV21Trn_Memo.gxTpr_Memotitleangle = AV31MemoTitleAngle;
         AV21Trn_Memo.gxTpr_Memotitlescale = AV26MemoTitleScale;
         AV21Trn_Memo.gxTpr_Memotextfontname = AV32MemoTextFontName;
         AV21Trn_Memo.gxTpr_Memotextalignment = AV33MemoTextAlignment;
         AV21Trn_Memo.gxTpr_Memoisbold = AV34MemoIsBold;
         AV21Trn_Memo.gxTpr_Memoisitalic = AV35MemoIsItalic;
         AV21Trn_Memo.gxTpr_Memoiscapitalized = AV36MemoIsCapitalized;
         AV21Trn_Memo.gxTpr_Memotextcolor = AV37MemoTextColor;
         AV21Trn_Memo.Save();
         if ( AV21Trn_Memo.Success() )
         {
            context.CommitDataStores("prc_creatememo",pr_default);
            AV9Error.gxTpr_Status = context.GetMessage( "Success", "");
            AV9Error.gxTpr_Message = context.GetMessage( "Memo created successfully", "");
         }
         else
         {
            AV9Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9Error.gxTpr_Message = context.GetMessage( "Failed to create memo", "");
            context.RollbackDataStores("prc_creatememo",pr_default);
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
         AV9Error = new SdtSDT_Error(context);
         P00CX2_A71ResidentGUID = new string[] {""} ;
         P00CX2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00CX2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00CX2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV20ResidentId = Guid.Empty;
         AV22LocationId = Guid.Empty;
         AV25OrganisationId = Guid.Empty;
         AV21Trn_Memo = new SdtTrn_Memo(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_creatememo__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_creatememo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_creatememo__default(),
            new Object[][] {
                new Object[] {
               P00CX2_A71ResidentGUID, P00CX2_A62ResidentId, P00CX2_A29LocationId, P00CX2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private decimal AV13MemoDuration ;
      private decimal AV29MemoLeftOffset ;
      private decimal AV30MemoTopOffset ;
      private decimal AV31MemoTitleAngle ;
      private decimal AV26MemoTitleScale ;
      private string AV24MemoForm ;
      private string AV33MemoTextAlignment ;
      private DateTime AV17MemoStartDateTime ;
      private DateTime AV14MemoEndDateTime ;
      private DateTime AV16MemoRemoveDate ;
      private bool AV34MemoIsBold ;
      private bool AV35MemoIsItalic ;
      private bool AV36MemoIsCapitalized ;
      private string AV15MemoImage ;
      private string AV19ResidentGUID ;
      private string AV18MemoTitle ;
      private string AV11MemoDescription ;
      private string AV12MemoDocument ;
      private string AV23MemoBgColorCode ;
      private string AV27MemoType ;
      private string AV28MemoName ;
      private string AV32MemoTextFontName ;
      private string AV37MemoTextColor ;
      private string A71ResidentGUID ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV20ResidentId ;
      private Guid AV22LocationId ;
      private Guid AV25OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV9Error ;
      private IDataStoreProvider pr_default ;
      private string[] P00CX2_A71ResidentGUID ;
      private Guid[] P00CX2_A62ResidentId ;
      private Guid[] P00CX2_A29LocationId ;
      private Guid[] P00CX2_A11OrganisationId ;
      private SdtTrn_Memo AV21Trn_Memo ;
      private SdtSDT_Error aP23_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_creatememo__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_creatememo__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_creatememo__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00CX2;
       prmP00CX2 = new Object[] {
       new ParDef("AV19ResidentGUID",GXType.VarChar,100,60)
       };
       def= new CursorDef[] {
           new CursorDef("P00CX2", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV19ResidentGUID) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CX2,100, GxCacheFrequency.OFF ,false,false )
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
