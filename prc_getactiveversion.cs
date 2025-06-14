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
   public class prc_getactiveversion : GXProcedure
   {
      public prc_getactiveversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getactiveversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ActiveVersion )
      {
         this.AV8ActiveVersion = "" ;
         initialize();
         ExecuteImpl();
         aP0_ActiveVersion=this.AV8ActiveVersion;
      }

      public string executeUdp( )
      {
         execute(out aP0_ActiveVersion);
         return AV8ActiveVersion ;
      }

      public void executeSubmit( out string aP0_ActiveVersion )
      {
         this.AV8ActiveVersion = "" ;
         SubmitImpl();
         aP0_ActiveVersion=this.AV8ActiveVersion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P00EZ2 */
         pr_default.execute(0, new Object[] {AV10Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00EZ2_A29LocationId[0];
            n29LocationId = P00EZ2_n29LocationId[0];
            A535IsActive = P00EZ2_A535IsActive[0];
            A524AppVersionName = P00EZ2_A524AppVersionName[0];
            A523AppVersionId = P00EZ2_A523AppVersionId[0];
            AV8ActiveVersion = A524AppVersionName;
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
         AV8ActiveVersion = "";
         AV10Udparg1 = Guid.Empty;
         P00EZ2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00EZ2_n29LocationId = new bool[] {false} ;
         P00EZ2_A535IsActive = new bool[] {false} ;
         P00EZ2_A524AppVersionName = new string[] {""} ;
         P00EZ2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A524AppVersionName = "";
         A523AppVersionId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getactiveversion__default(),
            new Object[][] {
                new Object[] {
               P00EZ2_A29LocationId, P00EZ2_n29LocationId, P00EZ2_A535IsActive, P00EZ2_A524AppVersionName, P00EZ2_A523AppVersionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n29LocationId ;
      private bool A535IsActive ;
      private string AV8ActiveVersion ;
      private string A524AppVersionName ;
      private Guid AV10Udparg1 ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00EZ2_A29LocationId ;
      private bool[] P00EZ2_n29LocationId ;
      private bool[] P00EZ2_A535IsActive ;
      private string[] P00EZ2_A524AppVersionName ;
      private Guid[] P00EZ2_A523AppVersionId ;
      private string aP0_ActiveVersion ;
   }

   public class prc_getactiveversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EZ2;
          prmP00EZ2 = new Object[] {
          new ParDef("AV10Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EZ2", "SELECT LocationId, IsActive, AppVersionName, AppVersionId FROM Trn_AppVersion WHERE (LocationId = :AV10Udparg1) AND (IsActive = TRUE) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EZ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
