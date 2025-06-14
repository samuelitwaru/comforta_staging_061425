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
   public class prc_updateappversiontheme : GXProcedure
   {
      public prc_updateappversiontheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateappversiontheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_ThemeId ,
                           out SdtSDT_Theme aP2_SDT_Theme ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV10ThemeId = aP1_ThemeId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_Theme=this.AV11SDT_Theme;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_ThemeId ,
                                      out SdtSDT_Theme aP2_SDT_Theme )
      {
         execute(aP0_AppVersionId, aP1_ThemeId, out aP2_SDT_Theme, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_ThemeId ,
                                 out SdtSDT_Theme aP2_SDT_Theme ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV10ThemeId = aP1_ThemeId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_Theme=this.AV11SDT_Theme;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtoserver(context ).execute(  context.GetMessage( "&AppVersionId", "")+AV9AppVersionId.ToString()) ;
         new prc_logtoserver(context ).execute(  context.GetMessage( "&ThemeId", "")+AV10ThemeId.ToString()) ;
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00GD2 */
         pr_default.execute(0, new Object[] {AV9AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTGD2 = 0;
            A523AppVersionId = P00GD2_A523AppVersionId[0];
            A273Trn_ThemeId = P00GD2_A273Trn_ThemeId[0];
            A273Trn_ThemeId = AV10ThemeId;
            GXTGD2 = 1;
            GXt_SdtSDT_Theme1 = AV11SDT_Theme;
            new prc_getthemesdt(context ).execute(  AV10ThemeId, out  GXt_SdtSDT_Theme1) ;
            AV11SDT_Theme = GXt_SdtSDT_Theme1;
            new prc_logtoserver(context ).execute(  context.GetMessage( "Updated", "")+AV11SDT_Theme.ToJSonString(false, true)) ;
            /* Using cursor P00GD3 */
            pr_default.execute(1, new Object[] {A273Trn_ThemeId, A523AppVersionId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            if ( GXTGD2 == 1 )
            {
               context.CommitDataStores("prc_updateappversiontheme",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateappversiontheme",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11SDT_Theme = new SdtSDT_Theme(context);
         AV8SDT_Error = new SdtSDT_Error(context);
         P00GD2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GD2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         GXt_SdtSDT_Theme1 = new SdtSDT_Theme(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversiontheme__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversiontheme__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversiontheme__default(),
            new Object[][] {
                new Object[] {
               P00GD2_A523AppVersionId, P00GD2_A273Trn_ThemeId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTGD2 ;
      private Guid AV9AppVersionId ;
      private Guid AV10ThemeId ;
      private Guid A523AppVersionId ;
      private Guid A273Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Theme AV11SDT_Theme ;
      private SdtSDT_Error AV8SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GD2_A523AppVersionId ;
      private Guid[] P00GD2_A273Trn_ThemeId ;
      private SdtSDT_Theme GXt_SdtSDT_Theme1 ;
      private SdtSDT_Theme aP2_SDT_Theme ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateappversiontheme__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateappversiontheme__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateappversiontheme__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00GD2;
       prmP00GD2 = new Object[] {
       new ParDef("AV9AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GD3;
       prmP00GD3 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00GD2", "SELECT AppVersionId, Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :AV9AppVersionId ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GD2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00GD3", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET Trn_ThemeId=:Trn_ThemeId  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GD3)
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
