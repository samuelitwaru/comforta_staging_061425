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
   public class prc_getdefaulttheme : GXProcedure
   {
      public prc_getdefaulttheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getdefaulttheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_ThemeId )
      {
         this.AV8ThemeId = Guid.Empty ;
         initialize();
         ExecuteImpl();
         aP0_ThemeId=this.AV8ThemeId;
      }

      public Guid executeUdp( )
      {
         execute(out aP0_ThemeId);
         return AV8ThemeId ;
      }

      public void executeSubmit( out Guid aP0_ThemeId )
      {
         this.AV8ThemeId = Guid.Empty ;
         SubmitImpl();
         aP0_ThemeId=this.AV8ThemeId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A274Trn_ThemeName = P009Y2_A274Trn_ThemeName[0];
            A273Trn_ThemeId = P009Y2_A273Trn_ThemeId[0];
            AV8ThemeId = A273Trn_ThemeId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV8ThemeId = Guid.Empty;
         P009Y2_A274Trn_ThemeName = new string[] {""} ;
         P009Y2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A274Trn_ThemeName = "";
         A273Trn_ThemeId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getdefaulttheme__default(),
            new Object[][] {
                new Object[] {
               P009Y2_A274Trn_ThemeName, P009Y2_A273Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A274Trn_ThemeName ;
      private Guid AV8ThemeId ;
      private Guid A273Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009Y2_A274Trn_ThemeName ;
      private Guid[] P009Y2_A273Trn_ThemeId ;
      private Guid aP0_ThemeId ;
   }

   public class prc_getdefaulttheme__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009Y2;
          prmP009Y2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P009Y2", "SELECT Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeName = ( 'Minimalistic') ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
