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
   public class prc_islocationhomepagecreated : GXProcedure
   {
      public prc_islocationhomepagecreated( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_islocationhomepagecreated( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_IsHomePageCreated )
      {
         this.AV9IsHomePageCreated = false ;
         initialize();
         ExecuteImpl();
         aP0_IsHomePageCreated=this.AV9IsHomePageCreated;
      }

      public bool executeUdp( )
      {
         execute(out aP0_IsHomePageCreated);
         return AV9IsHomePageCreated ;
      }

      public void executeSubmit( out bool aP0_IsHomePageCreated )
      {
         this.AV9IsHomePageCreated = false ;
         SubmitImpl();
         aP0_IsHomePageCreated=this.AV9IsHomePageCreated;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_guid1 = AV8LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV8LocationId = GXt_guid1;
         new prc_logtofile(context ).execute(  ">>>>>>> "+AV8LocationId.ToString()) ;
         AV10GXLvl7 = 0;
         /* Using cursor P00AX2 */
         pr_default.execute(0, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00AX2_A29LocationId[0];
            A397Trn_PageName = P00AX2_A397Trn_PageName[0];
            A392Trn_PageId = P00AX2_A392Trn_PageId[0];
            if ( StringUtil.StrCmp(A397Trn_PageName, context.GetMessage( "Home", "")) == 0 )
            {
               AV10GXLvl7 = 1;
               AV9IsHomePageCreated = true;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl7 == 0 )
         {
            AV9IsHomePageCreated = false;
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
         AV8LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00AX2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AX2_A397Trn_PageName = new string[] {""} ;
         P00AX2_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A397Trn_PageName = "";
         A392Trn_PageId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_islocationhomepagecreated__default(),
            new Object[][] {
                new Object[] {
               P00AX2_A29LocationId, P00AX2_A397Trn_PageName, P00AX2_A392Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl7 ;
      private bool AV9IsHomePageCreated ;
      private string A397Trn_PageName ;
      private Guid AV8LocationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A392Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AX2_A29LocationId ;
      private string[] P00AX2_A397Trn_PageName ;
      private Guid[] P00AX2_A392Trn_PageId ;
      private bool aP0_IsHomePageCreated ;
   }

   public class prc_islocationhomepagecreated__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AX2;
          prmP00AX2 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AX2", "SELECT LocationId, Trn_PageName, Trn_PageId FROM Trn_Page WHERE LocationId = :AV8LocationId ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AX2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
