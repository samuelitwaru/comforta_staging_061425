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
   public class prc_savepagev2 : GXProcedure
   {
      public prc_savepagev2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_savepagev2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           string aP3_PageType ,
                           string aP4_PageStructure ,
                           out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV14PageId = aP1_PageId;
         this.AV15PageName = aP2_PageName;
         this.AV17PageType = aP3_PageType;
         this.AV16PageStructure = aP4_PageStructure;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP5_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_PageId ,
                                      string aP2_PageName ,
                                      string aP3_PageType ,
                                      string aP4_PageStructure )
      {
         execute(aP0_AppVersionId, aP1_PageId, aP2_PageName, aP3_PageType, aP4_PageStructure, out aP5_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 string aP3_PageType ,
                                 string aP4_PageStructure ,
                                 out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV14PageId = aP1_PageId;
         this.AV15PageName = aP2_PageName;
         this.AV17PageType = aP3_PageType;
         this.AV16PageStructure = aP4_PageStructure;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP5_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00BG2 */
         pr_default.execute(0, new Object[] {AV9AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00BG2_A523AppVersionId[0];
            /* Using cursor P00BG3 */
            pr_default.execute(1, new Object[] {A523AppVersionId, AV14PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               GXTBG3 = 0;
               A516PageId = P00BG3_A516PageId[0];
               A517PageName = P00BG3_A517PageName[0];
               A525PageType = P00BG3_A525PageType[0];
               A518PageStructure = P00BG3_A518PageStructure[0];
               O518PageStructure = A518PageStructure;
               O518PageStructure = A518PageStructure;
               A517PageName = AV15PageName;
               if ( ( ( StringUtil.StrCmp(A525PageType, "Menu") == 0 ) ) || ( ( StringUtil.StrCmp(A525PageType, "MyLiving") == 0 ) ) || ( ( StringUtil.StrCmp(A525PageType, "MyService") == 0 ) ) || ( ( StringUtil.StrCmp(A525PageType, "MyCare") == 0 ) ) )
               {
                  AV19SDT_MenuPage.FromJSonString(AV16PageStructure, null);
                  AV10CleanedPageStructure = AV19SDT_MenuPage.ToJSonString(false, true);
               }
               else
               {
                  if ( StringUtil.StrCmp(A525PageType, "Information") == 0 )
                  {
                     AV22SDT_InfoContent.FromJSonString(AV16PageStructure, null);
                     AV10CleanedPageStructure = AV22SDT_InfoContent.ToJSonString(false, true);
                  }
                  else
                  {
                     AV18SDT_ContentPage.FromJSonString(AV16PageStructure, null);
                     AV10CleanedPageStructure = AV18SDT_ContentPage.ToJSonString(false, true);
                  }
               }
               A518PageStructure = AV10CleanedPageStructure;
               if ( ! ( ( StringUtil.StrCmp(O518PageStructure, AV10CleanedPageStructure) == 0 ) ) )
               {
                  new prc_updatetoolboxstatus(context ).execute(  true) ;
                  GXTBG3 = 1;
               }
               /* Using cursor P00BG4 */
               pr_default.execute(2, new Object[] {A517PageName, A518PageStructure, A523AppVersionId, A516PageId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
               if ( GXTBG3 == 1 )
               {
                  context.CommitDataStores("prc_savepagev2",pr_default);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_savepagev2",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SDT_Error = new SdtSDT_Error(context);
         P00BG2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00BG3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00BG3_A516PageId = new Guid[] {Guid.Empty} ;
         P00BG3_A517PageName = new string[] {""} ;
         P00BG3_A525PageType = new string[] {""} ;
         P00BG3_A518PageStructure = new string[] {""} ;
         A516PageId = Guid.Empty;
         A517PageName = "";
         A525PageType = "";
         A518PageStructure = "";
         O518PageStructure = "";
         AV19SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV10CleanedPageStructure = "";
         AV22SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV18SDT_ContentPage = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__default(),
            new Object[][] {
                new Object[] {
               P00BG2_A523AppVersionId
               }
               , new Object[] {
               P00BG3_A523AppVersionId, P00BG3_A516PageId, P00BG3_A517PageName, P00BG3_A525PageType, P00BG3_A518PageStructure
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTBG3 ;
      private string AV16PageStructure ;
      private string A518PageStructure ;
      private string O518PageStructure ;
      private string AV10CleanedPageStructure ;
      private string AV15PageName ;
      private string AV17PageType ;
      private string A517PageName ;
      private string A525PageType ;
      private Guid AV9AppVersionId ;
      private Guid AV14PageId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV8SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BG2_A523AppVersionId ;
      private Guid[] P00BG3_A523AppVersionId ;
      private Guid[] P00BG3_A516PageId ;
      private string[] P00BG3_A517PageName ;
      private string[] P00BG3_A525PageType ;
      private string[] P00BG3_A518PageStructure ;
      private SdtSDT_MenuPage AV19SDT_MenuPage ;
      private SdtSDT_InfoContent AV22SDT_InfoContent ;
      private SdtSDT_ContentPage AV18SDT_ContentPage ;
      private SdtSDT_Error aP5_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_savepagev2__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_savepagev2__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_savepagev2__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00BG2;
       prmP00BG2 = new Object[] {
       new ParDef("AV9AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG3;
       prmP00BG3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV14PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG4;
       prmP00BG4 = new Object[] {
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BG2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV9AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BG3", "SELECT AppVersionId, PageId, PageName, PageType, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV14PageId ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG3,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BG4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageName=:PageName, PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BG4)
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
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
    }
 }

}

}
