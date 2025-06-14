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
   public class prc_mainmanagerscount : GXProcedure
   {
      public prc_mainmanagerscount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_mainmanagerscount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           out short aP1_MainManagers )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9MainManagers = 0 ;
         initialize();
         ExecuteImpl();
         aP1_MainManagers=this.AV9MainManagers;
      }

      public short executeUdp( Guid aP0_OrganisationId )
      {
         execute(aP0_OrganisationId, out aP1_MainManagers);
         return AV9MainManagers ;
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 out short aP1_MainManagers )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9MainManagers = 0 ;
         SubmitImpl();
         aP1_MainManagers=this.AV9MainManagers;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized group. */
         /* Using cursor P00AQ2 */
         pr_default.execute(0, new Object[] {AV8OrganisationId});
         cV9MainManagers = P00AQ2_AV9MainManagers[0];
         pr_default.close(0);
         AV9MainManagers = (short)(AV9MainManagers+cV9MainManagers*1);
         /* End optimized group. */
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
         P00AQ2_AV9MainManagers = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_mainmanagerscount__default(),
            new Object[][] {
                new Object[] {
               P00AQ2_AV9MainManagers
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9MainManagers ;
      private short cV9MainManagers ;
      private Guid AV8OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00AQ2_AV9MainManagers ;
      private short aP1_MainManagers ;
   }

   public class prc_mainmanagerscount__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AQ2;
          prmP00AQ2 = new Object[] {
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AQ2", "SELECT COUNT(*) FROM Trn_Manager WHERE (OrganisationId = :AV8OrganisationId) AND (ManagerIsMainManager = TRUE) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ2,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
